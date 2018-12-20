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
            countESTABLISHMENT();
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



            System.Threading.Thread initproc = new System.Threading.Thread(new System.Threading.ThreadStart(initiate));
            ucLOADING y = new ucLOADING();
           
            initproc.Start();

            countESTABLISHMENT();
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
        public void countESTABLISHMENT()
        {
            listView1.Items.Clear();
            con.Open();
            ListView lv = new ListView();
            String query = "SELECT est_type AS `TYPE`, COUNT(*) AS `COUNT` FROM record GROUP BY est_type;";
            OleDbCommand Adpt = new OleDbCommand(query, con);
            OleDbDataReader reader = Adpt.ExecuteReader();
            
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["TYPE"].ToString());
                item.SubItems.Add(reader["COUNT"].ToString());
                listView1.Items.Add(item); //Add this row to the ListView
            }

            
            con.Close();
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



        private void panellogo_Paint(object sender, PaintEventArgs e)
        {

        }

        //END HERE................................................

    }
}
