namespace DBMulticast
{
	partial class MultiCast
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiCast));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.execute = new System.Windows.Forms.Button();
            this.msgTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.sqlTextBox = new ScintillaNet.Scintilla();
            this.lblTimeout = new System.Windows.Forms.Label();
            this.tabResults = new System.Windows.Forms.TabControl();
            this.tbTimeout = new System.Windows.Forms.TextBox();
            this.lblRecords = new System.Windows.Forms.Label();
            this.rbText = new System.Windows.Forms.RadioButton();
            this.rbGrid = new System.Windows.Forms.RadioButton();
            this.resultsTextBox = new ScintillaNet.Scintilla();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dbTree = new DBMulticast.AutoExpandTreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnRefreshDBs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtSearchServer = new System.Windows.Forms.ToolStripTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grdExecutionStatus = new System.Windows.Forms.DataGridView();
            this.Status = new System.Windows.Forms.DataGridViewImageColumn();
            this.DBID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Database = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.lblSum = new System.Windows.Forms.ToolStripStatusLabel();
            this.executionProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.lblExecutionTimer = new System.Windows.Forms.ToolStripStatusLabel();
            this.executionTimer = new System.Windows.Forms.Timer(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.ctxmenu_DBTree_RightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmenu_AddServer = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmenu_EditServer = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sqlTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdExecutionStatus)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.ctxmenu_DBTree_RightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // execute
            // 
            this.execute.Location = new System.Drawing.Point(3, 3);
            this.execute.Name = "execute";
            this.execute.Size = new System.Drawing.Size(78, 23);
            this.execute.TabIndex = 2;
            this.execute.Text = "Execute SQL";
            this.execute.UseVisualStyleBackColor = true;
            this.execute.Click += new System.EventHandler(this.ExecuteClick);
            // 
            // msgTextBox
            // 
            this.msgTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.msgTextBox.Location = new System.Drawing.Point(3, 3);
            this.msgTextBox.Name = "msgTextBox";
            this.msgTextBox.Size = new System.Drawing.Size(1036, 113);
            this.msgTextBox.TabIndex = 7;
            this.msgTextBox.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1050, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exportResultsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.newWindowToolStripMenuItem.Text = "New";
            this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.newWindowToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveMenuItemClick);
            // 
            // exportResultsToolStripMenuItem
            // 
            this.exportResultsToolStripMenuItem.Name = "exportResultsToolStripMenuItem";
            this.exportResultsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportResultsToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.exportResultsToolStripMenuItem.Text = "Export Results";
            this.exportResultsToolStripMenuItem.Click += new System.EventHandler(this.SaveToCSV);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitMenuItemClick);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshDBToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // refreshDBToolStripMenuItem
            // 
            this.refreshDBToolStripMenuItem.Name = "refreshDBToolStripMenuItem";
            this.refreshDBToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.refreshDBToolStripMenuItem.Text = "RefreshDB";
            this.refreshDBToolStripMenuItem.Click += new System.EventHandler(this.refreshDBToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 532);
            this.panel1.TabIndex = 9;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.sqlTextBox);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lblTimeout);
            this.splitContainer3.Panel2.Controls.Add(this.tabResults);
            this.splitContainer3.Panel2.Controls.Add(this.tbTimeout);
            this.splitContainer3.Panel2.Controls.Add(this.execute);
            this.splitContainer3.Panel2.Controls.Add(this.lblRecords);
            this.splitContainer3.Panel2.Controls.Add(this.rbText);
            this.splitContainer3.Panel2.Controls.Add(this.rbGrid);
            this.splitContainer3.Panel2.Controls.Add(this.resultsTextBox);
            this.splitContainer3.Size = new System.Drawing.Size(804, 532);
            this.splitContainer3.SplitterDistance = 277;
            this.splitContainer3.TabIndex = 11;
            // 
            // sqlTextBox
            // 
            this.sqlTextBox.ConfigurationManager.Language = "mssql";
            this.sqlTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqlTextBox.Location = new System.Drawing.Point(0, 0);
            this.sqlTextBox.Margins.Margin0.Width = 15;
            this.sqlTextBox.Name = "sqlTextBox";
            this.sqlTextBox.Size = new System.Drawing.Size(804, 277);
            this.sqlTextBox.Styles.BraceBad.FontName = "Verdana";
            this.sqlTextBox.Styles.BraceLight.FontName = "Verdana";
            this.sqlTextBox.Styles.ControlChar.FontName = "Verdana";
            this.sqlTextBox.Styles.Default.FontName = "Verdana";
            this.sqlTextBox.Styles.IndentGuide.FontName = "Verdana";
            this.sqlTextBox.Styles.LastPredefined.FontName = "Verdana";
            this.sqlTextBox.Styles.LineNumber.FontName = "Verdana";
            this.sqlTextBox.Styles.Max.FontName = "Verdana";
            this.sqlTextBox.TabIndex = 6;
            // 
            // lblTimeout
            // 
            this.lblTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimeout.Location = new System.Drawing.Point(673, 8);
            this.lblTimeout.Name = "lblTimeout";
            this.lblTimeout.Size = new System.Drawing.Size(78, 20);
            this.lblTimeout.TabIndex = 13;
            this.lblTimeout.Text = "Timeout (s):";
            this.lblTimeout.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabResults
            // 
            this.tabResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabResults.Location = new System.Drawing.Point(0, 32);
            this.tabResults.Name = "tabResults";
            this.tabResults.SelectedIndex = 0;
            this.tabResults.Size = new System.Drawing.Size(804, 219);
            this.tabResults.TabIndex = 12;
            // 
            // tbTimeout
            // 
            this.tbTimeout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTimeout.Location = new System.Drawing.Point(753, 5);
            this.tbTimeout.Name = "tbTimeout";
            this.tbTimeout.Size = new System.Drawing.Size(47, 20);
            this.tbTimeout.TabIndex = 11;
            this.tbTimeout.Text = "30";
            // 
            // lblRecords
            // 
            this.lblRecords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecords.Location = new System.Drawing.Point(205, 8);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(260, 20);
            this.lblRecords.TabIndex = 10;
            // 
            // rbText
            // 
            this.rbText.AutoSize = true;
            this.rbText.Location = new System.Drawing.Point(137, 6);
            this.rbText.Name = "rbText";
            this.rbText.Size = new System.Drawing.Size(46, 17);
            this.rbText.TabIndex = 9;
            this.rbText.Text = "Text";
            this.rbText.UseVisualStyleBackColor = true;
            this.rbText.CheckedChanged += new System.EventHandler(this.rbText_CheckedChanged);
            // 
            // rbGrid
            // 
            this.rbGrid.AutoSize = true;
            this.rbGrid.Checked = true;
            this.rbGrid.Location = new System.Drawing.Point(87, 6);
            this.rbGrid.Name = "rbGrid";
            this.rbGrid.Size = new System.Drawing.Size(44, 17);
            this.rbGrid.TabIndex = 8;
            this.rbGrid.TabStop = true;
            this.rbGrid.Text = "Grid";
            this.rbGrid.UseVisualStyleBackColor = true;
            this.rbGrid.CheckedChanged += new System.EventHandler(this.rbGrid_CheckedChanged);
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsTextBox.ConfigurationManager.Language = "mssql";
            this.resultsTextBox.Location = new System.Drawing.Point(0, 32);
            this.resultsTextBox.Margins.Margin0.Width = 15;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.Size = new System.Drawing.Size(804, 219);
            this.resultsTextBox.Styles.BraceBad.FontName = "Verdana";
            this.resultsTextBox.Styles.BraceLight.FontName = "Verdana";
            this.resultsTextBox.Styles.ControlChar.FontName = "Verdana";
            this.resultsTextBox.Styles.Default.FontName = "Verdana";
            this.resultsTextBox.Styles.IndentGuide.FontName = "Verdana";
            this.resultsTextBox.Styles.LastPredefined.FontName = "Verdana";
            this.resultsTextBox.Styles.LineNumber.FontName = "Verdana";
            this.resultsTextBox.Styles.Max.FontName = "Verdana";
            this.resultsTextBox.TabIndex = 7;
            this.resultsTextBox.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dbTree);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Size = new System.Drawing.Size(1050, 532);
            this.splitContainer1.SplitterDistance = 804;
            this.splitContainer1.TabIndex = 12;
            // 
            // dbTree
            // 
            this.dbTree.AllowDrop = true;
            this.dbTree.CheckBoxes = true;
            this.dbTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dbTree.ImageIndex = 0;
            this.dbTree.ImageList = this.imageList1;
            this.dbTree.Location = new System.Drawing.Point(0, 25);
            this.dbTree.Name = "dbTree";
            this.dbTree.SelectedImageIndex = 0;
            this.dbTree.ShowNodeToolTips = true;
            this.dbTree.Size = new System.Drawing.Size(242, 507);
            this.dbTree.TabIndex = 1;
            this.dbTree.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.dbTree_ItemDrag);
            this.dbTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.dbTree_DragDrop);
            this.dbTree.DragEnter += new System.Windows.Forms.DragEventHandler(this.dbTree_DragEnter);
            this.dbTree.DragOver += new System.Windows.Forms.DragEventHandler(this.dbTree_DragOver);
            this.dbTree.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dbTree_MouseDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Folder.png");
            this.imageList1.Images.SetKeyName(1, "data-server-icon.png");
            this.imageList1.Images.SetKeyName(2, "Bubble-White.bmp");
            this.imageList1.Images.SetKeyName(3, "refresh.bmp");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshDBs,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txtSearchServer});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(242, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnRefreshDBs
            // 
            this.btnRefreshDBs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshDBs.Image = ((System.Drawing.Image)(resources.GetObject("btnRefreshDBs.Image")));
            this.btnRefreshDBs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshDBs.Name = "btnRefreshDBs";
            this.btnRefreshDBs.Size = new System.Drawing.Size(23, 22);
            this.btnRefreshDBs.Text = "toolStripButton1";
            this.btnRefreshDBs.Click += new System.EventHandler(this.btnRefreshDBs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel1.Text = "Search:";
            // 
            // txtSearchServer
            // 
            this.txtSearchServer.Name = "txtSearchServer";
            this.txtSearchServer.Size = new System.Drawing.Size(100, 25);
            this.txtSearchServer.TextChanged += new System.EventHandler(this.txtSearchServer_TextChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 24);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1050, 681);
            this.splitContainer2.SplitterDistance = 532;
            this.splitContainer2.TabIndex = 13;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1050, 145);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grdExecutionStatus);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1042, 119);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Execution Servers";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grdExecutionStatus
            // 
            this.grdExecutionStatus.AllowUserToAddRows = false;
            this.grdExecutionStatus.AllowUserToDeleteRows = false;
            this.grdExecutionStatus.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdExecutionStatus.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdExecutionStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdExecutionStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdExecutionStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Status,
            this.DBID,
            this.Database,
            this.StatusText,
            this.StartTime,
            this.Message});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdExecutionStatus.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdExecutionStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdExecutionStatus.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grdExecutionStatus.GridColor = System.Drawing.SystemColors.ControlLightLight;
            this.grdExecutionStatus.Location = new System.Drawing.Point(3, 3);
            this.grdExecutionStatus.MultiSelect = false;
            this.grdExecutionStatus.Name = "grdExecutionStatus";
            this.grdExecutionStatus.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdExecutionStatus.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdExecutionStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdExecutionStatus.Size = new System.Drawing.Size(1036, 113);
            this.grdExecutionStatus.TabIndex = 8;
            // 
            // Status
            // 
            this.Status.Frozen = true;
            this.Status.HeaderText = "";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 20;
            // 
            // DBID
            // 
            this.DBID.Frozen = true;
            this.DBID.HeaderText = "DBID";
            this.DBID.Name = "DBID";
            this.DBID.ReadOnly = true;
            this.DBID.Visible = false;
            // 
            // Database
            // 
            this.Database.Frozen = true;
            this.Database.HeaderText = "Database";
            this.Database.Name = "Database";
            this.Database.ReadOnly = true;
            // 
            // StatusText
            // 
            this.StatusText.Frozen = true;
            this.StatusText.HeaderText = "Status";
            this.StatusText.Name = "StatusText";
            this.StatusText.ReadOnly = true;
            // 
            // StartTime
            // 
            this.StartTime.Frozen = true;
            this.StartTime.HeaderText = "Elapsed";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            // 
            // Message
            // 
            this.Message.Frozen = true;
            this.Message.HeaderText = "Message";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            this.Message.Width = 500;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.msgTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1042, 119);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Overall Messages";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(145, 22);
            this.toolStripMenuItem1.Text = "export to CSV";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.SaveToCSV);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(146, 26);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSum,
            this.executionProgress,
            this.lblExecutionTimer});
            this.statusStrip2.Location = new System.Drawing.Point(0, 705);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(1050, 22);
            this.statusStrip2.TabIndex = 8;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // lblSum
            // 
            this.lblSum.Name = "lblSum";
            this.lblSum.Size = new System.Drawing.Size(0, 17);
            // 
            // executionProgress
            // 
            this.executionProgress.Name = "executionProgress";
            this.executionProgress.Size = new System.Drawing.Size(340, 16);
            this.executionProgress.Visible = false;
            // 
            // lblExecutionTimer
            // 
            this.lblExecutionTimer.Name = "lblExecutionTimer";
            this.lblExecutionTimer.Size = new System.Drawing.Size(49, 17);
            this.lblExecutionTimer.Text = "00:00:00";
            this.lblExecutionTimer.Visible = false;
            // 
            // executionTimer
            // 
            this.executionTimer.Interval = 1000;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Bubble-Green.bmp");
            this.imageList2.Images.SetKeyName(1, "Bubble-Red.bmp");
            this.imageList2.Images.SetKeyName(2, "Bubble-White.bmp");
            this.imageList2.Images.SetKeyName(3, "Bubble-Yellow.bmp");
            this.imageList2.Images.SetKeyName(4, "Bubble-Blue.bmp");
            // 
            // ctxmenu_DBTree_RightClick
            // 
            this.ctxmenu_DBTree_RightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmenu_AddServer,
            this.copyToolStripMenuItem,
            this.tsmenu_EditServer,
            this.deleteToolStripMenuItem});
            this.ctxmenu_DBTree_RightClick.Name = "ctxmenu_DBTree_RightClick";
            this.ctxmenu_DBTree_RightClick.Size = new System.Drawing.Size(108, 92);
            // 
            // tsmenu_AddServer
            // 
            this.tsmenu_AddServer.Name = "tsmenu_AddServer";
            this.tsmenu_AddServer.Size = new System.Drawing.Size(107, 22);
            this.tsmenu_AddServer.Text = "Add";
            this.tsmenu_AddServer.Click += new System.EventHandler(this.tsmenu_AddServer_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // tsmenu_EditServer
            // 
            this.tsmenu_EditServer.Name = "tsmenu_EditServer";
            this.tsmenu_EditServer.Size = new System.Drawing.Size(107, 22);
            this.tsmenu_EditServer.Text = "Edit";
            this.tsmenu_EditServer.Click += new System.EventHandler(this.tsmenu_EditServer_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // MultiCast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 727);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip2);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MultiCast";
            this.Text = "SQLMulticast";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sqlTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultsTextBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdExecutionStatus)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.ctxmenu_DBTree_RightClick.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Button execute;
        private System.Windows.Forms.RichTextBox msgTextBox;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exportResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem refreshDBToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private ScintillaNet.Scintilla sqlTextBox;
        private ScintillaNet.Scintilla resultsTextBox;
        private System.Windows.Forms.RadioButton rbText;
        private System.Windows.Forms.RadioButton rbGrid;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox tbTimeout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox txtSearchServer;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnRefreshDBs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.TabControl tabResults;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.ToolStripProgressBar executionProgress;
        private System.Windows.Forms.ToolStripStatusLabel lblSum;
        private System.Windows.Forms.ToolStripStatusLabel lblExecutionTimer;
        private System.Windows.Forms.Timer executionTimer;
        private System.Windows.Forms.DataGridView grdExecutionStatus;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.DataGridViewImageColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn DBID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Database;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusText;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        public DBMulticast.AutoExpandTreeView dbTree;
        private System.Windows.Forms.ContextMenuStrip ctxmenu_DBTree_RightClick;
        private System.Windows.Forms.ToolStripMenuItem tsmenu_AddServer;
        private System.Windows.Forms.ToolStripMenuItem tsmenu_EditServer;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;

        private System.Windows.Forms.Label lblTimeout;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
	}
}

