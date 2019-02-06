using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;



namespace BFP_FSES
{
    public partial class MainForm : Form
    {

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\BFP-FSES\\BFP-FSES.accdb;Persist Security Info=False;");
        public String state = "nk";
        public MainForm()
        {
            InitializeComponent();
            

        }

        private void btnREGISTER_Click(object sender, EventArgs e)
        {
            Sidepanel1.BackColor = Color.FromArgb(120, 40, 31);
            Sidepanel2.BackColor = Color.FromArgb(39, 55, 70);
        }

        private void btnMASTERLIST_Click(object sender, EventArgs e)
        {
            Sidepanel1.BackColor = Color.FromArgb(39, 55, 70);
            Sidepanel2.BackColor = Color.FromArgb(120, 40, 31);
        }

        private void btnREGISTER_Click_1(object sender, EventArgs e)
        {
            btnREGISTER.BackColor = Color.FromArgb(46, 64, 83);
            btnMASTERLIST.BackColor = Color.FromArgb(39, 55, 70);
            btnREGISTER.Font = new Font("Bahnschrift", 11, FontStyle.Bold);
            btnMASTERLIST.Font = new Font("Bahnschrift", 9, FontStyle.Bold);
            if (!panel.Controls.Contains(ucREGISTER.Instance))
            {
                popCom();
                panel.Controls.Add(ucREGISTER.Instance);
                ucREGISTER.Instance.Dock = DockStyle.Fill;
                ucREGISTER.Instance.BringToFront();
            }
            else
            {
                popCom();
                ucREGISTER.Instance.BringToFront();
            }
            Sidepanel1.BackColor = Color.FromArgb(120, 40, 31);
            Sidepanel2.BackColor = Color.FromArgb(39, 55, 70);


        }

        public void popCom()
        {

            String query = "SELECT * FROM e_type";
            OleDbDataAdapter u = new OleDbDataAdapter(query,con);
            DataSet ds = new DataSet();
            u.Fill(ds);
            ucREGISTER.Instance.comboBox1.DisplayMember = "title";
            ucREGISTER.Instance.comboBox1.ValueMember = "ID";
            ucREGISTER.Instance.comboBox1.DataSource = ds.Tables[0];

        }

        private void btnMASTERLIST_Click_1(object sender, EventArgs e)
        {
            Sidepanel1.BackColor = Color.FromArgb(39, 55, 70);
            Sidepanel2.BackColor = Color.FromArgb(120, 40, 31);
            btnREGISTER.Font = new Font("Bahnschrift", 9, FontStyle.Bold);
            btnMASTERLIST.Font = new Font("Bahnschrift", 11, FontStyle.Bold);
            btnREGISTER.BackColor = Color.FromArgb(39, 55, 70);
            btnMASTERLIST.BackColor = Color.FromArgb(46, 64, 83);
            int yr = Convert.ToInt32(DateTime.Now.Year.ToString());
            if (!panel.Controls.Contains(ucMASTERLIST.Instance))
            {
                panel.Controls.Add(ucMASTERLIST.Instance);
                ucMASTERLIST.Instance.Dock = DockStyle.Fill;
                ucMASTERLIST.Instance.loadYearData(yr);
                ucMASTERLIST.Instance.loadcbx();
                ucMASTERLIST.Instance.BringToFront();
            }
            else
            {
                ucMASTERLIST.Instance.loadYearData(yr);
                ucMASTERLIST.Instance.loadcbx();
                ucMASTERLIST.Instance.BringToFront();
            }
            
        }

        //private void panellogo_Click(object sender, EventArgs e)
        //{
        //    countESTABLISHMENT();
        //    //SHOW CODE FOR COUNT ALL NEW APPLICATION
        //    countNEWAPP();
        //    //END......
        //    //SHOW CODE FOR COUNT ALL RENEW APPLICATION
        //    countRENEW();
        //    //END......
        //    //SHOW CODE FOR COUNT ALL INSPECTED
        //    countNOTINSPECTED();
        //    //END......
        //    //SHOW CODE FOR COUNT ALL INSPECTED
        //    countINSPECTED();
        //    //END......
        //    //SHOW DATA FROM LABEL ESTABLISHMENT
        //    showTOTAL_ESTABLISHMENT();
        //    //END......
        //    btnREGISTER.Font = new Font("Bahnschrift", 9, FontStyle.Bold);
        //    btnMASTERLIST.Font = new Font("Bahnschrift", 9, FontStyle.Bold);
        //    btnREGISTER.BackColor = Color.FromArgb(39, 55, 70);
        //    btnMASTERLIST.BackColor = Color.FromArgb(39, 55, 70);
        //    Sidepanel1.BackColor = Color.FromArgb(39, 55, 70);
        //    Sidepanel2.BackColor = Color.FromArgb(39, 55, 70);
        //    panel.Controls.Remove(ucREGISTER.Instance);
        //    panel.Controls.Remove(ucMASTERLIST.Instance);
        //}

        private void panel8_Click(object sender, EventArgs e)
        {
            DialogResult exit = MessageBox.Show("Logout Program?","Logout Confirmation",MessageBoxButtons.YesNo);

            if (exit == DialogResult.Yes)
            {
                frmLOGIN x = new frmLOGIN();
                x.ShowDialog();
            }   
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (state == "nk")
            {
                frmLOGIN login = new frmLOGIN();
                login.ShowDialog();
            }
            System.Threading.Thread initproc = new System.Threading.Thread(new System.Threading.ThreadStart(initiate));
            ucLOADING y = new ucLOADING();
           
            initproc.Start();

            //countESTABLISHMENT();
            ////SHOW CODE FOR COUNT ALL NEW APPLICATION
            //countNEWAPP();
            ////END......
            ////SHOW CODE FOR COUNT ALL RENEW APPLICATION
            //countRENEW();
            ////END......
            ////SHOW CODE FOR COUNT ALL INSPECTED
            //countNOTINSPECTED();
            ////END......
            ////SHOW CODE FOR COUNT ALL INSPECTED
            //countINSPECTED();
            ////END......
            ////SHOW DATA FROM LABEL ESTABLISHMENT
            //showTOTAL_ESTABLISHMENT();
            ////END......

            initproc.Abort();
            //THIS FOR TIMER
            time.Text = DateTime.Now.ToLongTimeString();
            Timer timez = new Timer();
            timez.Interval = 1000;
            timez.Start();
            timez.Tick += new EventHandler(timer);
            //TIMER CODE END...
        }

        public void initiate()
        {
            
        }
        void timer(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
