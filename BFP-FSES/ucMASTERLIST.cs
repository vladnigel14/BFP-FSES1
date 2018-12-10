using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BFP_FSES
{
    public partial class ucMASTERLIST : UserControl
    {
        MySqlConnection conn = new MySqlConnection("datasource=127.0.0.1;port=3306;uid=root;pwd=;database=db_librarysystem");
        public static ucMASTERLIST _instance;
        public static ucMASTERLIST Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucMASTERLIST();
                return _instance;
            }
        }
        public ucMASTERLIST()
        {
            InitializeComponent();
        }

        private void ucMASTERLIST_Load(object sender, EventArgs e)
        {
            showdata();
        }

        private void txtSEARCH_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSEARCH_Click(object sender, EventArgs e)
        {
            if (txtSEARCH.Text == "Search")
            {
                txtSEARCH.Text = "";
            }
        }

        public void showdata() 
        {
            string query = "SELECT * FROM tbl_returnbook";
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            conn.Open();

            DataSet ds = new DataSet();
            adapter.Fill(ds, "tbl_returnbook");
            dataGRID.DataSource = ds.Tables["tbl_returnbook"];
            conn.Close();
        }


    }
}
