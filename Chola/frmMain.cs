using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlexiLibrary;
using Chola.Chola_DL;
using Arms_Scan;
namespace Chola
{
    public partial class frmMain : Form
    {
        string user_name = "";
        int UserId = 0;
        int Usergroupid = 0;
        string Password = "";


        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(int compid, string user_code)
        {
            InitializeComponent();
            UserId = compid;
            user_name = user_code;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Boolean TestFlag = true;
            try
            {
                this.Visible = false;
                TestFlag = false;

                if (TestFlag == true)
                {
                    main();
                    
                }

                this.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void main()
        {
            try
            {
                iSecurity gobjSecurity = new iSecurity();
                iODBCconnection gobjConnection = new iODBCconnection();
                GlobalClass ObjGlobal = new GlobalClass();

                gobjSecurity.LoginCaption = "CHOLA";
                gobjSecurity.LoginSoftCode = "CHOLA";
                gobjSecurity.LoginSoftVersion = "1.3.8";

                gobjSecurity.GetConfig(Application.StartupPath + "\\AppConfig.ini");
                gobjSecurity.ShowLoginDialog();

                if (!gobjSecurity.LoginState)
                {
                    Application.Exit();
                }
                else
                {
                    if (gobjSecurity.DbApplication != "")
                    {
                        gobjConnection.OpenConnection(gobjSecurity);
                    }
                }

                ObjGlobal.gUserName = gobjSecurity.LoginUserCode;
                ObjGlobal.gUid = Convert.ToInt16(gobjSecurity.LoginUserGID);
                ObjGlobal.gUserFullName = gobjSecurity.LoginUserName;
                ObjGlobal.gUserRights = gobjSecurity.LoginUserDesignationGID;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuScanning_Click(object sender, EventArgs e)
        {
            try
            {

                frmPacketQue frmprintinv = new frmPacketQue("PacketQueue");
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is frmPacketQue)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void fc_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Refresh();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Are you sure to exit ?", "", MessageBoxButtons.YesNo))
            {
                Application.Exit();
            }
        }

        private void ScanEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                frmPacketQue frmprintinv = new frmPacketQue("ScanQueue");
                frmprintinv.MdiParent = this;
                //frmprintinv.Dock = DockStyle.Fill;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is frmPacketQue)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void imageAttachmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                frmImageAttachment frmprintinv = new frmImageAttachment();
                frmprintinv.MdiParent = this;
                foreach (Form f in Application.OpenForms)
                {
                    if (f is frmImageAttachment)
                    {
                        f.Focus();
                        return;
                    }
                }
                frmprintinv.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
