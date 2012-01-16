using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DBMulticast
{
    public partial class ServerEdit : Form
    {
        TreeNode tn = null;
        bool IsEdit { get; set; }
        public ServerEdit()
        {
            InitializeComponent();
        }

        public ServerEdit(TreeNode tn, bool isEdit)
        {
            InitializeComponent();
            IsEdit = isEdit;
            this.tn = tn;
            if (tn.Tag != null && tn.Tag.GetType() == typeof(DBMulticast.Server) && isEdit)
            {
                var svr = tn.Tag as Server;
                rdoServer.Checked = true;
                tb_Name.Text = svr.servername;
                tb_Database.Text = svr.database;
                tb_Location.Text = svr.svr;
                tb_Password.Text = svr.password;
                tb_Username.Text = svr.username;
                cb_UseSqlCredentials.Checked = svr.usesspi;
            }
            else
            {
                var svrList = tn.Tag as ServerList;
                rdoFolder.Checked = true;
                if(isEdit)
                    tb_Name.Text = svrList.Name;
            }
        }

        private void cb_UseSSPI_CheckedChanged(object sender, EventArgs e)
        {
            var val = cb_UseSqlCredentials.Checked;
            lblUserName.Enabled = val;
            lblPassword.Enabled = val;
            tb_Username.Enabled = val;
            tb_Password.Enabled = val;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (rdoFolder.Checked)
            {
                var svrList = new ServerList();
                svrList.Name = tb_Name.Text;

                if (IsEdit)
                {
                    tn.Text = tb_Name.Text;
                    tn.Tag = svrList;
                }
                else
                {
                    TreeNode node = new TreeNode();
                    node.Text = svrList.Name;
                    node.Tag = svrList;
                    if (tn.Tag.GetType() == typeof(Server))
                    {
                        tn.Parent.Nodes.Add(node);
                    }
                    else if (tn.Tag.GetType() == typeof(ServerList))
                    {
                        tn.Nodes.Add(node);
                        tn.Expand();
                    }
                }
            }
            else if (rdoServer.Checked)
            {
                var svr = new Server();
                svr.servername = tb_Name.Text;
                svr.database = tb_Database.Text;
                svr.svr = tb_Location.Text;
                svr.password = cb_UseSqlCredentials.Checked ? tb_Password.Text : null;
                svr.username = cb_UseSqlCredentials.Checked ? tb_Username.Text : null;
                svr.usesspi = !cb_UseSqlCredentials.Checked;

                if (IsEdit)
                {
                    if (tn.Tag.GetType() == typeof(Server))
                    {
                        tn.Text = svr.servername;
                        tn.Tag = svr;
                    }
                }
                else
                {
                    TreeNode node = new TreeNode();
                    node.Text = tb_Name.Text;
                    node.Tag = svr;
                    if (tn.Tag.GetType() == typeof(Server))
                    {
                        tn.Parent.Nodes.Add(node);
                    }
                    else if (tn.Tag.GetType() == typeof(ServerList))
                    {
                        tn.Nodes.Add(node);
                        tn.Expand();
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void editFolder_CheckedChanged(object sender, EventArgs e)
        {
            lblUserName.Enabled = false;
            tb_Username.Enabled = false;
            lblPassword.Enabled = false;
            tb_Password.Enabled = false;
            lblLocation.Enabled = false;
            tb_Location.Enabled = false;
            lblDatabase.Enabled = false;
            tb_Database.Enabled = false;
            cb_UseSqlCredentials.Enabled = false;
        }

        private void editServer_CheckedChanged(object sender, EventArgs e)
        {
            lblLocation.Enabled = true;
            tb_Location.Enabled = true;
            lblDatabase.Enabled = true;
            tb_Database.Enabled = true;
            cb_UseSqlCredentials.Enabled = true;
        }
    }
}