using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BFP_FSES
{
    public partial class ucMASTERLIST : UserControl
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\BFP-FSES\\BFP-FSES.accdb;Persist Security Info=False;");
        public static ucMASTERLIST _instance;
        Timer x = new Timer();
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
            showData();
            RowsColor();
            foreach (DataGridViewColumn dgvc in dataGRID.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
           
        }
        public void showData()
        {

            String query = "Select fsic_table.fsic_no as  `FSIC`,establishment_table.BIN, establishment_name as  `ESTABLISHMENT NAME`,establishment_address as `ADDRESS`,establishment_owner as `OWNER`, establishment_status as `STATUS`, nob as `NATURE`, storey_no as `STOREY`, portion_occupied as `PORTION OCCUPIED`, floor_area as `FLOOR AREA`, inspected as `INSPECTED` from establishment_table INNER JOIN fsic_table on establishment_table.BIN = fsic_table.BIN";
            OleDbDataAdapter x = new OleDbDataAdapter(query, con);
            DataTable dt = new DataTable();
            x.Fill(dt);
            dataGRID.DataSource = dt;
          

        }

        public void RowsColor()
        {
            Timer y = new Timer();
            y.Interval = 100;
            y.Start();
            y.Tick+=new EventHandler(y_Tick);
        }

        void y_Tick(Object sender, EventArgs e)
        {
            for (int i = 0; i < dataGRID.Rows.Count - 1; i++)
            {
                try
                {
                    String status = dataGRID.Rows[i].Cells[5].Value.ToString();

                    if (status == "NEW")
                    {
                        dataGRID.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(169, 223, 191);

                    }

                    else
                    {
                        dataGRID.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb (249, 231, 159);
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }

            
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

        private void button1_Click(object sender, EventArgs e)
        {
            dataGRID.Refresh();
        }

        private void dataGRID_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("LANGAW NI MARC");
        }
    }
}
