using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using DBMulticast.Properties;

namespace DBMulticast
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			LoadDatabaseDefinitions();
			sqlTextBox.Text = "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED" + Environment.NewLine + sqlTextBox.Text;
		}

		//private void LoadDatabaseDefinitions()
		//{
		//  databasesListBox.Items.Clear();
		//  var da = DBAccess.GetDataSet("Select * from DBServers", DBAccess.ConnectionString);
		//  if (da == null || da.Tables == null || da.Tables.Count < 1) return;

		//  foreach (DataRow dr in da.Tables[0].Rows)
		//  {
		//    databasesListBox.Items.Add(dr["ServerName"]);
		//  }
		//}

		private void LoadDatabaseDefinitions()
		{
			ServerList loaded;
			var s = new XmlSerializer(typeof (ServerList));
			TextReader r = new StreamReader(@"servers.xml");
			loaded = (ServerList) s.Deserialize(r);
			r.Close();

			if (loaded != null)
			{
				foreach(var svr in loaded.Servers)
				{
					databasesListBox.Items.Add(svr);
				}
			}
	}

		private void ExecuteClick(object sender, EventArgs e)
		{
			execute.Enabled = false;
			RunQueries();
			execute.Enabled = true;
		}

		public void RunQueries()
		{
		    int count = 0;
		    lblRecords.Text = "";
		    progressBar.Value = 0;
		    progressBar.Minimum = 0;
		    progressBar.Maximum = databasesListBox.CheckedItems.Count;
		    progressBar.Step = 1;
		    var ds = new DataSet();
		    if (databasesListBox.CheckedItems.Count == 0) AddMsg("No databases selected");

		    resultsGridView.Columns.Clear();
		    resultsTextBox.Text = null;
		    foreach (object item in databasesListBox.CheckedItems)
		    {
		        try
		        {
		            using (DataSet _ds = DBAccess.GetDataSet(sqlTextBox.Text, DBAccess.GetServerConnectionString(item)))
		            {
                        if (_ds.Tables.Count == 0)
                        {
                            AddMsg(item + ": did not return a record set.");
                        }else
                        {
                            if (rbGrid.Checked)
                            {
                                ds.Merge(_ds);
                            }
                            else
                            {
                                foreach (DataRow dr in _ds.Tables[0].Rows)
                                {
                                    resultsTextBox.Text = resultsTextBox.Text + dr[0];
                                }
                            }
                        }
		            }
		        }
		        catch (Exception ex)
		        {
		            AddMsg(item + ": " + ex.Message);
		        }
		        progressBar.Value++;
		    }
            if(rbGrid.Checked && ds.Tables.Count > 0)
            {
                resultsGridView.DataSource = ds.Tables[0];
                lblRecords.Text = ds.Tables[0].Rows.Count + " rows";
            }
		}

        

	
	
		

		private void AddMsg(string msg)
		{
			if(String.IsNullOrEmpty(msgTextBox.Text))
				msgTextBox.Text = msg;
			else
				msgTextBox.Text = msg + "\r\n" + msgTextBox.Text;
		}

		private static void ShowHelp()
		{
			MessageBox.Show(Resources.Form1_ShowHelp_Help__);
		}

		private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.F1:
					ShowHelp();
					break;
				case Keys.F5:
					RunQueries();
					break;
			}
		}

		private void SaveToCSV(object sender, EventArgs e)
		{
			SaveToCSV();
		}

		private void SaveToCSV()
		{
			var fileLocation = GetSaveLocation("CSV file (*.csv)|*.csv");
			if (String.IsNullOrEmpty(fileLocation)) return;
			var strExport = resultsGridView.Columns.Cast<DataGridViewColumn>().Aggregate("", (current, dc) => current + (dc.Name + ", "));
			strExport = strExport.Substring(0, strExport.Length - 2) + Environment.NewLine.ToString();

			int rowcount = resultsGridView.Rows.Count;
			int colcount = resultsGridView.Columns.Count;
			for(int i = 0; i<rowcount; i++)
			{
				for (int j = 0; j<colcount; j++)
				{
					if (resultsGridView.Rows[i].Cells[j].Value != null)
					{
						strExport += resultsGridView.Rows[i].Cells[j].Value.ToString() + ", ";
					}
				} strExport += Environment.NewLine.ToString();
			}
			strExport = strExport.Substring(0, strExport.Length - 3) + Environment.NewLine.ToString();
			System.IO.TextWriter tw = new System.IO.StreamWriter(fileLocation);
			tw.Write(strExport);
			tw.Close();
		}

		private string GetSaveLocation(string filter)
		{
			var retval = String.Empty;
			try
			{

				var dialogSave = new SaveFileDialog();
				dialogSave.DefaultExt = "csv";
				dialogSave.Filter = filter;
				dialogSave.AddExtension = true;
				dialogSave.RestoreDirectory = true;
				dialogSave.Title = "Save File Location";
				if (dialogSave.ShowDialog() == DialogResult.OK)
				{
					retval = dialogSave.FileName;
				}

				dialogSave.Dispose();
				dialogSave = null;
			}catch(Exception ex)
			{
				AddMsg(ex.Message);
			}
			return retval;
		}

		private string GetOpenFileLocation()
		{
			var retval = String.Empty;
			var dialogOpen = new OpenFileDialog();
			dialogOpen.DefaultExt = "sql";
			dialogOpen.Filter = "SQL file (*.sql)|*.sql";
			dialogOpen.AddExtension = true;
			dialogOpen.RestoreDirectory = true;
			if (dialogOpen.ShowDialog() == DialogResult.OK)
				retval = dialogOpen.FileName;
			dialogOpen.Dispose();
			dialogOpen = null;
			return retval;
		}

		private void openMenuItem_Click(object sender, EventArgs e)
		{
			var fileLocation = GetOpenFileLocation();
			if (String.IsNullOrEmpty(fileLocation)) return;
			var tr = new System.IO.StreamReader(fileLocation);
			sqlTextBox.Text = tr.ReadToEnd();
			tr.Close();
		}

		private void SaveMenuItemClick(object sender, EventArgs e)
		{
			var fileLocation = GetSaveLocation("SQL file (*.sql)|*.sql");
			if (String.IsNullOrEmpty(fileLocation)) return;
			var tw = new System.IO.StreamWriter(fileLocation);
			tw.Write(sqlTextBox.Text);
			tw.Close();
		}

		private void ExitMenuItemClick(object sender, EventArgs e)
		{
			if (sender == null) throw new ArgumentNullException("sender");
			Application.Exit();
		}

		private void ToggleAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			for(int i = 0; i<databasesListBox.Items.Count; i++)
			{
				databasesListBox.SetItemChecked(i, !databasesListBox.GetItemChecked(i));
			}
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var val = databasesListBox.GetItemChecked(0);
			for (int i = 0; i < databasesListBox.Items.Count; i++)
			{
				databasesListBox.SetItemChecked(i, !val);
			}
		}

		private void refreshDBToolStripMenuItem_Click(object sender, EventArgs e)
		{
			databasesListBox.Items.Clear();
			LoadDatabaseDefinitions();
		}

        private void rbGrid_CheckedChanged(object sender, EventArgs e)
        {
            resultsGridView.Visible = true;
            resultsTextBox.Visible = false;
        }

        private void rbText_CheckedChanged(object sender, EventArgs e)
        {
            resultsGridView.Visible = false;
            resultsTextBox.Visible = true;
        }
	}
}
