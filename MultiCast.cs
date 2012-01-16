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
using System.Threading.Tasks;
using System.Threading;

namespace DBMulticast
{
    public partial class MultiCast : Form
    {
        private BackgroundWorker queryWorker = new BackgroundWorker();
        private DateTime executionStart = new DateTime();
        TreeNode lastDragDestination = null;
        DateTime lastDragDestinationTime;

        public MultiCast()
        {
            InitializeComponent();
            LoadDatabaseDefinitions();
            ToolTip tt = new ToolTip();
            tt.SetToolTip(tbTimeout, "Command Timeout");
            queryWorker.DoWork += new DoWorkEventHandler(queryWorker_DoWork);
            queryWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(queryWorker_RunWorkerCompleted);
            queryWorker.ProgressChanged += new ProgressChangedEventHandler(queryWorker_ProgressChanged);
            queryWorker.WorkerReportsProgress = true;
            queryWorker.WorkerSupportsCancellation = true;
            executionTimer.Tick += new EventHandler(executionTimer_Tick);
        }

        List<DataTable> ResultData = new List<DataTable>();
        StringBuilder ResultDataText = null;

        void queryWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.UserState != null)
            {
                QueryProgress prog = (QueryProgress)e.UserState;
                if (!string.IsNullOrEmpty(prog.Message))
                    AddMsg((!string.IsNullOrEmpty(prog.ServerID) ? prog.ServerID + ": " : "") + prog.Message);
                if (prog.ResultData != null)
                {
                    if (ResultData == null) ResultData = new List<DataTable>();
                    MergeDataSet(ResultData, prog.ResultData);
                    //ResultData.Merge(prog.ResultData);
                }
                else if (prog.ResultDataText != null)
                {
                    if (ResultDataText == null) ResultDataText = new StringBuilder();
                    ResultDataText.AppendLine(prog.ResultDataText);
                }
                if (!string.IsNullOrEmpty(prog.ServerID))
                {
                    if (prog.Status == ExecutionStatus.Success || prog.Status == ExecutionStatus.Error)
                        executionProgress.Value = Math.Min(executionProgress.Value + 1, executionProgress.Maximum);
                    // Find the appropriate row in the grid and update it with the relevant information.
                    foreach (DataGridViewRow row in grdExecutionStatus.Rows)
                    {
                        if (row.Cells[1].Value.Equals(prog.ServerID))
                        {
                            int imgIndex = 0;
                            string status = "";
                            switch (prog.Status)
                            {
                                case ExecutionStatus.Success:
                                    if (!string.IsNullOrEmpty(prog.ResultDataText) ||
                                        (prog.ResultData != null && prog.ResultData.Tables[0].Rows.Count > 0))
                                    {
                                        imgIndex = 0; // Green
                                        status = "Success";
                                    }
                                    else
                                    {
                                        imgIndex = 3; // Yellow
                                        status = "No Records";
                                    }
                                    break;
                                case ExecutionStatus.Error:
                                    imgIndex = 1; // Red
                                    status = "Error";
                                    break;
                                case ExecutionStatus.NotStarted:
                                    imgIndex = 2; // White
                                    break;
                                case ExecutionStatus.Executing:
                                    imgIndex = 4; // Blue
                                    status = "Executing";
                                    break;
                            }
                            ((DataGridViewImageCell)row.Cells[0]).Value = imageList2.Images[imgIndex];
                            row.Cells[3].Value = status;
                            if (prog.Elapsed.Ticks > 0)
                            {
                                row.Cells[4].Value = prog.Elapsed.ToString(@"hh\:mm\:ss\.ff");
                            }
                            if (!string.IsNullOrEmpty(prog.Message))
                                row.Cells[5].Value = prog.Message;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// This merge will not merge tables with different columns in them.
        /// </summary>
        /// <param name="Destination"></param>
        /// <param name="Source"></param>
        private void MergeDataSet(List<DataTable> Destination, DataSet Source)
        {
            List<DataTable> tablesToAdd = new List<DataTable>();
            foreach (DataTable srcTable in Source.Tables)
            {
                bool isFound = false;
                foreach (DataTable destTable in Destination)
                {
                    bool colsSame = true;
                    if (srcTable.Columns.Count == destTable.Columns.Count)
                    {
                        for (int i = 0; i < srcTable.Columns.Count; i++)
                        {
                            if (string.Compare(srcTable.Columns[i].ColumnName, destTable.Columns[i].ColumnName, true) != 0)
                            {
                                colsSame = false;
                                break;
                            }
                        }
                    }
                    else
                        colsSame = false;
                    if (colsSame)
                    {
                        destTable.Merge(srcTable);
                        isFound = true;
                        break;
                    }
                }
                if (!isFound)
                {
                    tablesToAdd.Add(srcTable);
                }
            }
            foreach (DataTable dt in tablesToAdd)
            {
                Destination.Add(dt);
            }
            Source.Dispose();
        }

        void queryWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (rbGrid.Checked && ResultData != null && ResultData.Count > 0)
            {
                int rows = 0;
                // Display multiple grids per result table, each in its own tab.
                for (int i = 0; i < ResultData.Count; i++)
                {
                    var dt = ResultData[i];
                    var newPage = new TabPage();
                    newPage.Text = string.Format("Result {0} ({1} Rows)", (i + 1).ToString(), dt.Rows.Count);
                    var grid = new DataGridView();
                    grid.DataError += new DataGridViewDataErrorEventHandler(resultsGridView_DataError);
                    grid.SelectionChanged += new EventHandler(grid_SelectionChanged);
                    grid.ContextMenuStrip = contextMenuStrip1;
                    newPage.Controls.Add(grid);
                    grid.Dock = DockStyle.Fill;
                    grid.ColumnWidthChanged += new DataGridViewColumnEventHandler(grid_ColumnWidthChanged);
                    grid.ColumnAdded += new DataGridViewColumnEventHandler(grid_ColumnAdded);
                    grid.AllowUserToResizeColumns = true;
                    grid.DataSource = dt;
                    tabResults.TabPages.Add(newPage);
                    rows += ResultData[i].Rows.Count;
                }
                lblRecords.Text = string.Format("{0} rows / {1} servers", rows.ToString(), executionProgress.Maximum);
            }
            else if (ResultDataText != null)
            {
                resultsTextBox.Text = ResultDataText.ToString();
            }

            executionProgress.Visible = false;
            lblExecutionTimer.Visible = false;
            executionTimer.Stop();
            execute.Text = "Execute SQL";
            execute.Enabled = true;
            sqlTextBox.Focus();
        }

        void grid_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            // limit the resize based on the grid width
            if (e.Column.Width > ((DataGridView)sender).Width * 2)
            {
                e.Column.Width = ((DataGridView)sender).Width * 2;
            }
        }

        void grid_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            // attempt to set the sizes based on the data
            int textLength = e.Column.HeaderText.Length > 0 ? e.Column.HeaderText.Length : 1;
            e.Column.MinimumWidth = textLength * 4;
            e.Column.FillWeight = textLength * 2;
        }


        void grid_SelectionChanged(object sender, EventArgs e)
        {
            var dgv = sender as DataGridView;
            double max = 0;
            double min = 0;
            double sum = 0;
            double sd = 0; //standard deviation
            bool first = false;
            bool isNum = false;
            int count = 0;
            foreach (DataGridViewCell c in dgv.SelectedCells)
            {
                if (c is DataGridViewTextBoxCell)
                {
                    count++;
                    if (c.ColumnIndex == 0 || (c != null && c.Value != null && String.IsNullOrEmpty(c.Value.ToString()))) continue;
                    Int64 s = 0;
                    if (c != null && c.Value != null)
                        isNum = Int64.TryParse(c.Value.ToString(), out s);
                    if (!isNum) continue;
                    isNum = false;
                    sum += s;
                    if (first == false)
                    {
                        first = true;
                        min = s;
                        max = s;
                    }
                    else
                    {
                        if (s > max) max = s;
                        if (s < min) min = s;

                    }
                }
            }

            foreach (DataGridViewCell c in dgv.SelectedCells)
            {
                if (c is DataGridViewTextBoxCell)
                {
                    if (c.ColumnIndex == 0 || (c != null && c.Value != null && String.IsNullOrEmpty(c.Value.ToString()))) continue;
                    Int64 s = 0;
                    if (c != null && c.Value != null)
                        isNum = Int64.TryParse(c.Value.ToString(), out s);
                    if (!isNum) continue;
                    sd += (s - sum / count) * (s - sum / count);
                }
            }
            string display = "";
            if (count > 0)
            {
                if (isNum && count > 1)
                {
                    var avg = sum / count;
                    sd = Math.Sqrt(sd / count);
                    display = string.Format("Cell Count: {0:#,#}  Avg: {1:#,##0.0}  Min: {2:#,##0.0}  Max: {3:#,##0.0}  Σ: {4:#,##0.0}  σ: {5:#,##0.0}  σ±: ({6:#,##0.0}, {7:#,##0.0})",
                        count, avg, min, max, sum, sd, avg + sd, avg - sd);
                }
                else
                {
                    display = string.Format("Cell Count: {0:#,#}", count);
                }
            }
            lblSum.Text = display;
        }

        private string formatstr(double d)
        {
            return String.Format("{0:0,0.0}", d);
        }

        TimeSpan TotalTime;
        void queryWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var args = (QueryArguments)e.Argument;

            foreach (var dt in ResultData) dt.Dispose();
            ResultData.Clear();
            if (ResultDataText != null) ResultDataText.Clear();
            DateTime start = DateTime.Now;
            TotalTime = new TimeSpan();
            int timeout = 0;
            if (!Int32.TryParse(tbTimeout.Text, out timeout))
            {
                timeout = 30;
            }

            Parallel.For(0, args.Servers.Count, (j) =>
                {
                    if (queryWorker.CancellationPending)
                        return;

                    var item = args.Servers[j];
                    var serverID = item.servername + "|" + item.database;
                    var svrstart = DateTime.Now;
                    try
                    {
                        queryWorker.ReportProgress(0,
                                                   new QueryProgress() { ServerID = serverID, Status = ExecutionStatus.Executing });
                        using (DataSet _ds = DBAccess.GetDataSet(args.SqlText, DBAccess.GetServerConnectionString(item), timeout, item))
                        {
                            TimeSpan elapsed = DateTime.Now.Subtract(svrstart);
                            TotalTime += elapsed;
                            if (_ds.Tables.Count == 0)
                            {
                                queryWorker.ReportProgress(0,
                                                           new QueryProgress()
                                                           {
                                                               Message = "Did not return a record set.",
                                                               ServerID = serverID,
                                                               Status = ExecutionStatus.Error,
                                                               Elapsed = elapsed
                                                           });
                            }
                            else
                            {
                                if (!args.ReturnText)
                                {
                                    queryWorker.ReportProgress(0, new QueryProgress()
                                    {
                                        ResultData = _ds,
                                        ServerID = serverID,
                                        Status = ExecutionStatus.Success,
                                        Elapsed = elapsed
                                    });
                                }
                                else
                                {
                                    var sb = new StringBuilder(_ds.Tables[0].Rows.Count * 10);
                                    foreach (DataRow dr in _ds.Tables[0].Rows)
                                    {
                                        if (queryWorker.CancellationPending)
                                            break;
                                        sb.Append(dr[1].ToString());
                                    }
                                    queryWorker.ReportProgress(0, new QueryProgress()
                                    {
                                        ResultDataText = sb.ToString(),
                                        ServerID = serverID,
                                        Status = ExecutionStatus.Success,
                                        Elapsed = elapsed
                                    });
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Operation cancelled by user."))
                        {
                            queryWorker.ReportProgress(0, new QueryProgress()
                            {
                                Message = "Cancelled.",
                                ServerID = serverID,
                                Status = ExecutionStatus.Success,
                                Elapsed = DateTime.Now.Subtract(svrstart)
                            });
                        }
                        else
                        {
                            queryWorker.ReportProgress(0, new QueryProgress()
                            {
                                Message = ex.Message,
                                ServerID = serverID,
                                Status = ExecutionStatus.Error,
                                Elapsed = DateTime.Now.Subtract(svrstart)
                            });
                        }
                    }
                }
            );
            queryWorker.ReportProgress(args.Servers.Count, new QueryProgress() { Message = "Elapsed Query Time: " + DateTime.Now.Subtract(start) + " --  Total Execution Time On Threads: " + TotalTime });
        }

        private ServerList _ServerList = new ServerList();

        private void LoadDatabaseDefinitions()
        {
            var s = new XmlSerializer(typeof(ServerList));
            using (TextReader r = new StreamReader(Path.Combine(Settings.Default.ServerConfigLocation, "servers.xml")))
            {
                _ServerList = (ServerList)s.Deserialize(r);
            }

            AddServerListToTree(_ServerList, null);
        }

        private void SaveDatabaseDefinitions()
        {
            UpdateServerList();
            var s = new XmlSerializer(typeof(ServerList));
            File.Copy(Path.Combine(Settings.Default.ServerConfigLocation, "servers.xml"), Path.Combine(Settings.Default.ServerConfigLocation, "servers.xml_backup"), true);
            using (TextWriter w = new StreamWriter(Path.Combine(Settings.Default.ServerConfigLocation, "servers.xml")))
            {
                s.Serialize(w, _ServerList);
            }
            LoadDatabaseDefinitions();
        }

        private void UpdateServerList()
        {
            _ServerList = ExtractData(dbTree.Nodes[0], dbTree.Nodes[0].IsExpanded);
        }

        private ServerList ExtractData(TreeNode tn, bool expanded)
        {
            var retval = new ServerList();
            retval.Name = tn.Text;
            retval.Expanded = expanded;
            foreach (TreeNode node in tn.Nodes)
            {
                if (node.Tag.GetType() == typeof(ServerList))
                {
                    if (retval.ServerLists == null)
                    {
                        retval.ServerLists = new List<ServerList>();
                    }
                    retval.ServerLists.Add(ExtractData(node, node.IsExpanded));
                }
                else if (node.Tag.GetType() == typeof(Server))
                {
                    retval.AddServer((Server)node.Tag);
                }
            }
            return retval;
        }

        private void AddServerListToTree(ServerList serverList, TreeNode parentNode)
        {
            var self = new TreeNode(serverList.Name);
            self.ContextMenuStrip = ctxmenu_DBTree_RightClick;
            if (serverList.Servers != null)
            {
                foreach (var s in serverList.Servers)
                {
                    if (txtSearchServer.Text.Trim().Length == 0 ||
                        s.servername.ToUpper().Contains(txtSearchServer.Text.Trim().ToUpper()))
                    {
                        var serverNode = new TreeNode(s.servername, 1, 1);
                        serverNode.ToolTipText = s.svr;
                        serverNode.Tag = s;
                        serverNode.Checked = (txtSearchServer.Text.Trim().Length > 0);
                        serverNode.ContextMenuStrip = ctxmenu_DBTree_RightClick;
                        self.Nodes.Add(serverNode);
                    }
                }
            }
            if (serverList.ServerLists != null)
            {
                foreach (var s in serverList.ServerLists)
                {
                    AddServerListToTree(s, self);
                }
            }
            self.Tag = serverList;
            if (self.Nodes.Count > 0)
            {
                if (parentNode == null)
                {
                    dbTree.Nodes.Clear();
                    dbTree.Nodes.Add(self);
                    if (txtSearchServer.Text.Trim().Length > 0)
                        self.ExpandAll();
                    else
                        self.Expand();
                }
                else
                    parentNode.Nodes.Add(self);
                if (serverList.Expanded) self.Expand();
            }
        }



        private void GetCheckedServers(TreeNode currentNode, List<Server> checkedServers)
        {
            if (currentNode.Checked && currentNode.Tag is Server)
                checkedServers.Add((Server)currentNode.Tag);
            foreach (TreeNode node in currentNode.Nodes)
                GetCheckedServers(node, checkedServers);
        }

        private void ExecuteClick(object sender, EventArgs e)
        {
            RunQueries();
        }

        public void RunQueries()
        {
            if (execute.Text == "Execute SQL")
            {
                execute.Text = "Cancel";
                lblRecords.Text = "";
                ClearResultTabs();
                resultsTextBox.Text = null;
                List<Server> servers = new List<Server>();
                GetCheckedServers(dbTree.Nodes[0], servers);
                if (servers.Count == 0)
                {
                    AddMsg("No databases selected");
                    execute.Text = "Execute SQL";
                    return;
                }
                grdExecutionStatus.Rows.Clear();
                foreach (Server s in servers)
                {
                    grdExecutionStatus.Rows.Add(new object[] { imageList2.Images[2], s.servername + "|" + s.database, s.servername });
                }
                executionProgress.Value = 0;
                executionProgress.Minimum = 0;
                executionProgress.Maximum = servers.Count;
                executionProgress.Step = 1;
                executionProgress.Visible = true;
                lblExecutionTimer.Text = "00:00:00";
                lblExecutionTimer.Visible = true;
                executionStart = DateTime.Now;
                executionTimer.Start();

                string sql = sqlTextBox.Text;
                if (!string.IsNullOrEmpty(sqlTextBox.Selection.Text))
                    sql = sqlTextBox.Selection.Text;
                var args = new QueryArguments()
                {
                    Servers = servers,
                    ReturnText = rbText.Checked,
                    SqlText = sql
                };
                queryWorker.RunWorkerAsync(args);
            }
            else if (execute.Text == "Cancel")
            {
                execute.Text = "Canceling";
                execute.Enabled = false;
                queryWorker.CancelAsync();
                DBAccess.CancelCommands();
            }
        }

        void executionTimer_Tick(object sender, EventArgs e)
        {
            lblExecutionTimer.Text = ((TimeSpan)(DateTime.Now - executionStart)).ToString(@"hh\:mm\:ss");
        }

        private void ClearResultTabs()
        {
            foreach (TabPage tab in tabResults.TabPages)
            {
                foreach (Control ctrl in tab.Controls)
                    ctrl.Dispose();
                tab.Controls.Clear();
                tab.Dispose();
            }
            tabResults.TabPages.Clear();
        }

        private void AddMsg(string msg)
        {
            if (String.IsNullOrEmpty(msgTextBox.Text))
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
            if (tabResults.SelectedTab != null && tabResults.SelectedTab.Controls[0] != null)
            {
                var resultsGridView = (DataGridView)tabResults.SelectedTab.Controls[0];
                var fileLocation = GetSaveLocation("CSV file (*.csv)|*.csv");
                if (String.IsNullOrEmpty(fileLocation)) return;
                var sbExport = new StringBuilder(1000);
                var strExport = resultsGridView.Columns.Cast<DataGridViewColumn>().Aggregate("", (current, dc) => current + (dc.Name + ", "));
                strExport = strExport.Substring(0, strExport.Length - 2) + Environment.NewLine.ToString();
                sbExport.Append(strExport);
                int rowcount = resultsGridView.Rows.Count;
                int colcount = resultsGridView.Columns.Count;
                for (int i = 0; i < rowcount; i++)
                {
                    for (int j = 0; j < colcount; j++)
                    {
                        if (resultsGridView.Rows[i].Cells[j].Value != null)
                        {
                            sbExport.Append(resultsGridView.Rows[i].Cells[j].Value.ToString()).Append(", ");
                        }
                    }
                    if (i < rowcount - 1)
                        sbExport.AppendLine();
                }
                using (System.IO.TextWriter tw = new System.IO.StreamWriter(fileLocation))
                {
                    tw.Write(sbExport);
                }
            }
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
            }
            catch (Exception ex)
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

        private void refreshDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbTree.SuspendLayout();
            LoadDatabaseDefinitions();
            dbTree.ResumeLayout();
        }

        private void rbGrid_CheckedChanged(object sender, EventArgs e)
        {
            tabResults.Visible = true;
            resultsTextBox.Visible = false;
        }

        private void rbText_CheckedChanged(object sender, EventArgs e)
        {
            tabResults.Visible = false;
            resultsTextBox.Visible = true;
        }

        private void dbTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            dbTree.AfterCheck -= new TreeViewEventHandler(dbTree_AfterCheck);
            CheckChildNodes(e.Node);
            CheckParentNode(e.Node.Parent);
            dbTree.AfterCheck += new TreeViewEventHandler(dbTree_AfterCheck);
        }

        private void CheckParentNode(TreeNode parent)
        {
            if (parent != null)
            {
                parent.Checked = true;
                foreach (TreeNode sub in parent.Nodes)
                {
                    if (!sub.Checked)
                    {
                        parent.Checked = false;
                        break;
                    }
                }
                CheckParentNode(parent.Parent);
            }
        }

        private void CheckChildNodes(TreeNode treeNode)
        {
            foreach (TreeNode t in treeNode.Nodes)
            {
                if (t.Checked != treeNode.Checked)
                {
                    t.Checked = treeNode.Checked;
                    CheckChildNodes(t);
                }
            }
        }

        private void txtSearchServer_TextChanged(object sender, EventArgs e)
        {
            dbTree.SuspendLayout();
            AddServerListToTree(_ServerList, null);
            dbTree.ResumeLayout();
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm2 = new MultiCast();
            frm2.Show();
        }

        private void resultsGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void btnRefreshDBs_Click(object sender, EventArgs e)
        {
            dbTree.SuspendLayout();
            LoadDatabaseDefinitions();
            dbTree.ResumeLayout();
        }

        private void dbTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right) && !string.IsNullOrEmpty(e.Node.ToolTipText))
            {
                Clipboard.SetText(e.Node.ToolTipText);
            }
        }

        private void dbTree_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void dbTree_DragDrop(object sender, DragEventArgs e)
        {
            Point loc = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
            TreeNode node = (TreeNode)e.Data.GetData(typeof(TreeNode));
            TreeNode destNode = ((TreeView)sender).GetNodeAt(loc);

            if (node.Parent == null)
                node.TreeView.Nodes.Remove(node);
            else
                node.Parent.Nodes.Remove(node);


            if (destNode == null || destNode.TreeView == null) return;

            if (destNode.Tag.GetType() == typeof(ServerList))
            {
                destNode.Nodes.Insert(0, node);
            }
            else if (destNode.Tag.GetType() == typeof(Server) && destNode.Parent != null)
            {
                destNode.Parent.Nodes.Insert(destNode.Index + 1, node);
            }

            //if (destNode.Parent == null)
            //    destNode.TreeView.Nodes.Insert(destNode.Index - 1, node);
            //else
            //    destNode.Parent.Nodes.Insert(destNode.Index - 1, node);

            SaveDatabaseDefinitions();
        }

        private void dbTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            dbTree.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void dbTree_DragOver(object sender, DragEventArgs e)
        {
            Object dragDropObject = null;
            TreeNode dragDropNode = null;

            //always disallow by default
            //e.Effect = DragDropEffects.None;

            //make sure we have data to transfer
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                dragDropNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
                //dragDropObject = (IconObject)dragDropNode.Tag;
            }
            else if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                ListViewItem temp = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
                //dragDropObject = (IconObject)temp.Tag;
            }

            if (dragDropObject != null)
            {
                TreeNode destinationNode = null;
                //get current location
                Point pt = new Point(e.X, e.Y);
                pt = dbTree.PointToClient(pt);
                destinationNode = dbTree.GetNodeAt(pt);
                if (destinationNode == null)
                {
                    return;
                }

                //if we are on a new object, reset our timer
                //otherwise check to see if enough time has passed and expand the destination node
                if (destinationNode != lastDragDestination)
                {
                    lastDragDestination = destinationNode;
                    lastDragDestinationTime = DateTime.Now;
                }
                else
                {
                    TimeSpan hoverTime = DateTime.Now.Subtract(lastDragDestinationTime);
                    if (hoverTime.TotalSeconds > 2)
                    {
                        destinationNode.Expand();
                    }
                }
            }

        }

        private void tsmenu_AddServer_Click(object sender, EventArgs e)
        {
            ServerEdit frm = new ServerEdit(dbTree.SelectedNode as TreeNode, false);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                SaveDatabaseDefinitions();
            }
        }

        private void tsmenu_EditServer_Click(object sender, EventArgs e)
        {
            ServerEdit frm = new ServerEdit(dbTree.SelectedNode as TreeNode, true);
            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                SaveDatabaseDefinitions();
            }
        }

        private void dbTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dbTree.SelectedNode = dbTree.GetNodeAt(e.X, e.Y);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbTree.SelectedNode.Remove();
            //TODO:: Add Confirmation!!
            SaveDatabaseDefinitions();
        }

    }

    public struct QueryArguments
    {
        public List<Server> Servers;
        public bool ReturnText;
        public string SqlText;
    }

    public struct QueryProgress
    {
        public string Message;
        public DataSet ResultData;
        public string ResultDataText;
        public string ServerID;
        public ExecutionStatus Status;
        public TimeSpan Elapsed;
    }

    public enum ExecutionStatus
    {
        NotStarted,
        Executing,
        Success,
        Error
    }

    public class AutoExpandTreeView : TreeView
    {
        DelayedAction<TreeNode> _expandNode;

        public AutoExpandTreeView()
        {
            _expandNode = new DelayedAction<TreeNode>((node) => node.Expand(), 500);
        }

        private TreeNode _prevNode;
        protected override void OnDragOver(DragEventArgs e)
        {
            Point clientPos = PointToClient(new Point(e.X, e.Y));
            TreeViewHitTestInfo hti = HitTest(clientPos);
            if (hti.Node != null && hti.Node != _prevNode)
            {
                _prevNode = hti.Node;
                _expandNode.RunAfterDelay(hti.Node);
            }
            base.OnDragOver(e);
        }
    }

    public class DelayedAction<T>
    {
        private SynchronizationContext _syncContext;
        private Action<T> _action;
        private int _delay;

        private Thread _thread;

        public DelayedAction(Action<T> action)
            : this(action, 0)
        {
        }

        public DelayedAction(Action<T> action, int delay)
        {
            _action = action;
            _delay = delay;
            _syncContext = SynchronizationContext.Current;
        }

        public void RunAfterDelay()
        {
            RunAfterDelay(_delay, default(T));
        }

        public void RunAfterDelay(T param)
        {
            RunAfterDelay(_delay, param);
        }

        public void RunAfterDelay(int delay)
        {
            RunAfterDelay(delay, default(T));
        }

        public void RunAfterDelay(int delay, T param)
        {
            Cancel();
            InitThread(delay, param);
            _thread.Start();
        }

        public void Cancel()
        {
            if (_thread != null && _thread.IsAlive)
            {
                _thread.Abort();
            }
            _thread = null;
        }

        private void InitThread(int delay, T param)
        {
            ThreadStart ts =
                () =>
                {
                    Thread.Sleep(delay);
                    _syncContext.Send(
                        (state) =>
                        {
                            _action((T)state);
                        },
                        param);
                };
            _thread = new Thread(ts);
        }
    }

}
