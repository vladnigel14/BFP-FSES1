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
            btnREGISTER.Font = new Font("Bahnschrift", 10, FontStyle.Bold);
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

            String query = "Select * from establishment_type_table";
            OleDbDataAdapter u = new OleDbDataAdapter(query,con);
            DataSet ds = new DataSet();
            u.Fill(ds);
            ucREGISTER.Instance.comboBox1.DisplayMember = "type";
            ucREGISTER.Instance.comboBox1.ValueMember = "ID";
            ucREGISTER.Instance.comboBox1.DataSource = ds.Tables[0];

        }

        private void btnMASTERLIST_Click_1(object sender, EventArgs e)
        {
            Sidepanel1.BackColor = Color.FromArgb(39, 55, 70);
            Sidepanel2.BackColor = Color.FromArgb(120, 40, 31);
            btnREGISTER.Font = new Font("Bahnschrift", 9, FontStyle.Bold);
            btnMASTERLIST.Font = new Font("Bahnschrift", 10, FontStyle.Bold);
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

        private void panel7_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //SHOW DATA FROM LABEL INSPECTED
            showTOTAL_INSPECTED();
            //END
            //SHOW DATA FROM LABEL ESTABLISHMENT
            showTOTAL_ESTABLISHMENT();
            //END......
            time.Text = DateTime.Now.ToLongTimeString();
            Timer timez = new Timer();
            timez.Interval = 1000;
            timez.Start();
            timez.Tick += new EventHandler(timer);
        }

        void timer(object sender, EventArgs e)
        {
            
            time.Text = DateTime.Now.ToLongTimeString();
        }

        private void panel29_Paint(object sender, PaintEventArgs e)
        {

        }

        public void showTOTAL_NOTINSPECTED()
        {
            con.Open();
            String query = "SELECT COUNT(inspected='NO') AS `COUNT` FROM establishment_table;";
            OleDbCommand Adpt = new OleDbCommand(query, con);
            OleDbDataReader reader = Adpt.ExecuteReader();

            while (reader.Read())
            {
                lblNOTINSPECTED.Text = reader["COUNT"].ToString();
            }
            con.Close();
        }

        public void showTOTAL_INSPECTED()
        {
            con.Open();
            String query = "SELECT COUNT(inspected='YES') AS `COUNT` FROM establishment_table;";
            OleDbCommand Adpt = new OleDbCommand(query, con);
            OleDbDataReader reader = Adpt.ExecuteReader();

            while (reader.Read())
            {
                lblINSPECTED.Text = reader["COUNT"].ToString();
            }
            con.Close();
        }

        public void showTOTAL_ESTABLISHMENT() 
        {
            con.Open();
            String query = "SELECT COUNT(*) as `COUNT` FROM establishment_table";
            OleDbCommand Adpt = new OleDbCommand(query, con);
            OleDbDataReader reader = Adpt.ExecuteReader();

            while (reader.Read())
            {
                lblESTABLISHMENT.Text = reader["COUNT"].ToString();
            }
            con.Close();
        }


    }
}
