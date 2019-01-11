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
    public partial class frmLOGIN : Form
    {

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\BFP-FSES\\BFP-FSES.accdb;Persist Security Info=False;");

        public frmLOGIN()
        {
            InitializeComponent();
        }

        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        private void panel1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                signin();
            }
        }

        public void signin()
        {

            con.Open();
            String password = textBox1.Text;
            String query = "SELECT COUNT(password) from user_table where password=@password";

            OleDbCommand sign = new OleDbCommand(query, con);
            sign.Parameters.AddWithValue("@password", password);

            Int64 count = Convert.ToInt64(sign.ExecuteScalar().ToString());

            if (count > 0)
            {
                MainForm x = new MainForm();
                x.state = "ok";
                this.Close();
                x.ShowDialog();
            }
            else
            {
                MessageBox.Show("Login not successful","Access denied",MessageBoxButtons.OK);
            }

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            signin();
        }  
    }
}
