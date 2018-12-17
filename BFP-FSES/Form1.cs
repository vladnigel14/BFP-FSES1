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
            if (!panel.Controls.Contains(ucMASTERLIST.Instance))
            {
                panel.Controls.Add(ucMASTERLIST.Instance);
                ucMASTERLIST.Instance.Dock = DockStyle.Fill;
                ucMASTERLIST.Instance.showData();
                ucMASTERLIST.Instance.BringToFront();
            }
            else
            {
                ucMASTERLIST.Instance.showData();
                ucMASTERLIST.Instance.BringToFront();
            }
            
        }

        private void panellogo_Click(object sender, EventArgs e)
        {
            
            btnREGISTER.Font = new Font("Bahnschrift", 9, FontStyle.Bold);
            btnMASTERLIST.Font = new Font("Bahnschrift", 9, FontStyle.Bold);
            btnREGISTER.BackColor = Color.FromArgb(39, 55, 70);
            btnMASTERLIST.BackColor = Color.FromArgb(39, 55, 70);
            Sidepanel1.BackColor = Color.FromArgb(39, 55, 70);
            Sidepanel2.BackColor = Color.FromArgb(39, 55, 70);
            panel.Controls.Remove(ucREGISTER.Instance);
            panel.Controls.Remove(ucMASTERLIST.Instance);
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //SHOW CODE FOR COUNT ALL APARTMENT
            countSTORE();
            //END......
            //SHOW CODE FOR COUNT ALL APARTMENT
            countAPARTMENT();
            //END......
            //SHOW CODE FOR COUNT ALL HOTEL
            countHOTEL();
            //END......
            //SHOW CODE FOR COUNT ALL MALL
            countMALL();
            //END......
            //SHOW CODE FOR COUNT ALL NEW APPLICATION
            countNEWAPP();
            //END......
            //SHOW CODE FOR COUNT ALL RENEW APPLICATION
            countRENEW();
            //END......
            //SHOW CODE FOR COUNT ALL INSPECTED
            countNOTINSPECTED();
            //END......
            //SHOW CODE FOR COUNT ALL INSPECTED
            countINSPECTED();
            //END......
            //SHOW DATA FROM LABEL ESTABLISHMENT
            showTOTAL_ESTABLISHMENT();
            //END......

            //THIS FOR TIMER
            time.Text = DateTime.Now.ToLongTimeString();
            Timer timez = new Timer();
            timez.Interval = 1000;
            timez.Start();
            timez.Tick += new EventHandler(timer);
            //TIMER CODE END...
        }

        void timer(object sender, EventArgs e)
        {
            
            time.Text = DateTime.Now.ToLongTimeString();
        }

        //CODE FOR COUNT ALL ESTABLISHMENTS.....................
        public void showTOTAL_ESTABLISHMENT() 
        {
            con.Open();
            String query = "SELECT COUNT(*) as `COUNT` FROM record";
            OleDbCommand Adpt = new OleDbCommand(query, con);
            OleDbDataReader reader = Adpt.ExecuteReader();

            while (reader.Read())
            {
                lblESTABLISHMENT.Text = reader["COUNT"].ToString();
            }
            con.Close();
        }
        //END HERE ..............................................
        //CODE FOR COUNT ALL INSPECTED.....................
        public void countINSPECTED()
        {
            con.Open();
            String query = "SELECT COUNT(inspected) as `COUNT` FROM record WHERE inspected = true";
            OleDbCommand Adpt = new OleDbCommand(query, con);
            OleDbDataReader reader = Adpt.ExecuteReader();

            while (reader.Read())
            {
                lblINSPECTED.Text = reader["COUNT"].ToString();
            }
            con.Close();
        }
        //END HERE ..............................................
        //CODE FOR COUNT ALL NOTINSPECTED.....................
        public void countNOTINSPECTED()
        {
            con.Open();
            String query = "SELECT COUNT(inspected) as `COUNT` FROM record WHERE inspected = false";
            OleDbCommand Adpt = new OleDbCommand(query, con);
            OleDbDataReader reader = Adpt.ExecuteReader();

            while (reader.Read())
            {
                lblNOTINSPECTED.Text = reader["COUNT"].ToString();
            }
            con.Close();
        }
        //END HERE ..............................................
        //CODE FOR COUNT ALL NEW APPLICATION.....................
        public void countNEWAPP()
        {
            con.Open();
            String query = "SELECT COUNT(status_of_application) as `COUNT` FROM record WHERE status_of_application = 'NEW'";
            OleDbCommand Adpt = new OleDbCommand(query, con);
            OleDbDataReader reader = Adpt.ExecuteReader();

            while (reader.Read())
            {
                lblNEWAPP.Text = reader["COUNT"].ToString();
            }
            con.Close();
        }
        //END HERE ..............................................
        //CODE FOR COUNT ALL RENEW APPLICATION.....................
        public void countRENEW()
        {
            con.Open();
            String query = "SELECT COUNT(status_of_application) as `COUNT` FROM record WHERE status_of_application = 'RENEW'";
            OleDbCommand Adpt = new OleDbCommand(query, con);
            OleDbDataReader reader = Adpt.ExecuteReader();

            while (reader.Read())
            {
                lblRENEW.Text = reader["COUNT"].ToString();
            }
            con.Close();
        }
        //END HERE ..............................................
        //CODE FOR COUNT ALL ESTABLISHMENT TYPE = MALL...........
        public void countMALL() 
        {
                con.Open();
                String query = "SELECT COUNT(est_type) as `COUNT` FROM record WHERE est_type = 'MALL'";
                OleDbCommand Adpt = new OleDbCommand(query, con);
                OleDbDataReader reader = Adpt.ExecuteReader();

                while (reader.Read())
                {
                    lblMALL.Text = reader["COUNT"].ToString();
                }
                con.Close();
        }
        //END HERE.................................................
        //CODE FOR COUNT ALL ESTABLISHMENT TYPE = HOTEL...........
        public void countHOTEL()
        {
            con.Open();
            String query = "SELECT COUNT(est_type) as `COUNT` FROM record WHERE est_type = 'HOTEL'";
            OleDbCommand Adpt = new OleDbCommand(query, con);
            OleDbDataReader reader = Adpt.ExecuteReader();

            while (reader.Read())
            {
                lblHOTEL.Text = reader["COUNT"].ToString();
            }
            con.Close();
        }
        //END HERE................................................
        //CODE FOR COUNT ALL ESTABLISHMENT TYPE = APARTMENT...........
        public void countAPARTMENT()
        {
            con.Open();
            String query = "SELECT COUNT(est_type) as `COUNT` FROM record WHERE est_type = 'APARTMENT'";
            OleDbCommand Adpt = new OleDbCommand(query, con);
            OleDbDataReader reader = Adpt.ExecuteReader();

            while (reader.Read())
            {
                lblAPARTMENT.Text = reader["COUNT"].ToString();
            }
            con.Close();
        }
        //END HERE................................................
        //CODE FOR COUNT ALL ESTABLISHMENT TYPE = STORE...........
        public void countSTORE()
        {
            con.Open();
            String query = "SELECT COUNT(est_type) as `COUNT` FROM record WHERE est_type = 'STORE'";
            OleDbCommand Adpt = new OleDbCommand(query, con);
            OleDbDataReader reader = Adpt.ExecuteReader();

            while (reader.Read())
            {
                lblSTORE.Text = reader["COUNT"].ToString();
            }
            con.Close();
        }
        //END HERE................................................

    }
}
