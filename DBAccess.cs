using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms.VisualStyles;

namespace DBMulticast
{
	public class DBAccess
	{
		public const string SSPICONN = "Data Source={0};Integrated Security=SSPI;initial catalog={1}";
		public const string SQLLOGINCONN = " data source={0};user id={1};pwd={2};initial catalog={3}";

        private static List<SqlCommand> _ActiveCommands = new List<SqlCommand>();
        private static object _ActiveCommandsLock = new object();

		public static DataSet GetDataSet(String sql, string connstr, int timeout, Server server)
		{
            if (!sql.StartsWith("use", true, CultureInfo.CurrentCulture))
            {
                string db = connstr.Substring(connstr.IndexOf("initial catalog="));
                db = db.Substring(db.IndexOf("=") + 1);
                sql = "USE " + db + Environment.NewLine + sql;
            }
            sql = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED " + Environment.NewLine + sql;
            sql = GetSqlForServer(sql, server);
            var retval = new DataSet();
            using (var adapter = GetDataAdapter(sql, connstr, timeout))
            {
                var fill = adapter.Fill(retval);
            }
            foreach (DataTable t in retval.Tables)
            {
                var svrcol = "ServerName";
                if (t.Columns["ServerName"] != null)
                    svrcol = "_ServerName_";
                t.Columns.Add(svrcol);
                t.Columns[svrcol].SetOrdinal(0);
                foreach (DataRow dr in t.Rows)
                {
                    dr[svrcol] = server.servername;
                }
            }
            return retval;
		}

        private static string GetSqlForServer(string origSql, Server server)
        {
            StringBuilder retVal = new StringBuilder();
            string[] lines = origSql.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            bool include = true;
            bool insideIf = false;
            foreach (var line in lines)
            {
                if (line.StartsWith("#if"))
                {
                    if (insideIf)
                        throw new SyntaxErrorException("Don't know how to handle nested #ifs yet.");
                    else
                    {
                        insideIf = true;
                        retVal.AppendLine(); //Append empty line to keep line numbers consistent across calls.

                        var criteria = line.Substring(3).Trim().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                        if (criteria.Length < 1)
                            throw new SyntaxErrorException("Malformed #if statement. No criteria specified.");
                        include = false;
                        foreach (var c in criteria)
                        {
                            var ops = c.Split(new char[] { '=', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                            if (ops.Length < 2)
                                throw new SyntaxErrorException("Malformed #if statement. Invalid criteria format.");
                            if (ops[0] == "type" && server.type == ops[1])
                                include = true;
                            else if (ops[0] == "name" && server.servername == ops[1])
                                include = true;
                            if (include) break;
                        }
                    }
                }
                else if (line.StartsWith("#else"))
                {
                    if(insideIf)
                    {
                        // If we were inside an if statement and we had not matched, then we are eligible for the else statement
                        if (!include) include = true;
                        retVal.AppendLine(); //Append empty line to keep line numbers consistent across calls.
                    }
                    else
                        throw new SyntaxErrorException("Unexpected #endif found.");
                }
                else if (line.StartsWith("#endif"))
                {
                    if (insideIf)
                    {
                        insideIf = false;
                        include = true;
                        retVal.AppendLine(); //Append empty line to keep line numbers consistent across calls.
                    }
                    else
                        throw new SyntaxErrorException("Unexpected #endif found.");
                }
                else if (include)
                    retVal.AppendLine(line);
                else
                    retVal.AppendLine(); //Append empty line to keep line numbers consistent across calls.
            }
            return retVal.ToString();
        }

		public static DataAdapter GetDataAdapter(String sql, string connstr, int timeout)
		{
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandTimeout = timeout;
            cmd.StatementCompleted += new StatementCompletedEventHandler(cmd_StatementCompleted);
            lock (_ActiveCommandsLock)
            {
                _ActiveCommands.Add(cmd);
            }
			return new SqlDataAdapter(cmd);
		}

        static void cmd_StatementCompleted(object sender, StatementCompletedEventArgs e)
        {
            if (sender is SqlCommand && _ActiveCommands.Contains((SqlCommand)sender))
            {
                lock (_ActiveCommandsLock)
                {
                    _ActiveCommands.Remove((SqlCommand)sender);
                    ((SqlCommand)sender).Dispose();
                }
            }
        }

        public static String GetServerConnectionString(Server server)
        {
            return server.usesspi
                ? String.Format(SSPICONN, server.svr, server.database)
                : String.Format(SQLLOGINCONN, server.svr, server.username, server.password, server.database);
        }

        public static void CancelCommands()
        {
            lock (_ActiveCommandsLock)
            {
                while (_ActiveCommands.Count > 0)
                {
                    try
                    {
                        _ActiveCommands[0].Cancel();
                        _ActiveCommands.RemoveAt(0);
                    }
                    catch { }
                }
            }
        }

		//public static String ConnectionString { get { return Config.GetValue("dbconn", typeof(String)) as String; } }
		//public static AppSettingsReader Config { get { return _cfg ?? (_cfg = new AppSettingsReader()); } set { _cfg = value; } }
 
	}
}
