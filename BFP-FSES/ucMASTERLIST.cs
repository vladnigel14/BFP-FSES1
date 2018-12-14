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
            //String query = "SELECT * from record";
            String query = "Select `fsic_number` as `FSIC NUMBER`,`bin` as BIN,`est_name` as  `ESTABLISHMENT NAME`,`est_address` as ADDRESS,`est_owner` as OWNER, `est_status` as STATUS,`fsic_exp_date` as `FSIC EXP DATE`,`date_issued` as `DATE ISSUE`, `status_of_application` as `STATUS OF APPLICATION`, `amount` as `AMOUNT`, `or` as `OR`, `_date` as `DATE`,  `io_number` as `IO`, `date_inspected` as `DATE INSPECTED`,`nature_of_business` as `NATURE OF BUSINESS`, `occupancy_type` as OCCUPANCY, `safety_inspectors` as INSPECTORS, `cons_materials` as `MATERIALS`, `storey_no` as STOREY, `portion_occupied` as `PORTION OCCUPIED`, `floor_area` as `FLOOR AREA`, `noted_violation` as VIOLATION, `inspected` as INSPECTED from record";
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
                    String status = dataGRID.Rows[i].Cells[10].Value.ToString();

                    if (status == "YES")
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



        private void RefreshGridView()
        {
            if (dataGRID.InvokeRequired)
            {
                dataGRID.Invoke((MethodInvoker)delegate()
                {
                    RefreshGridView();
                });
            }
            else
                dataGRID.Refresh();
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


            int row = dataGRID.SelectedRows[0].Index;

            String fsic = dataGRID.Rows[row].Cells[0].Value.ToString();
            String BIN = dataGRID.Rows[row].Cells[1].Value.ToString();
            String ESTABLISHMENTNAME = dataGRID.Rows[row].Cells[2].Value.ToString();
            String ADDRESS = dataGRID.Rows[row].Cells[3].Value.ToString();
            String OWNER = dataGRID.Rows[row].Cells[4].Value.ToString();
            String STATUS = dataGRID.Rows[row].Cells[5].Value.ToString();
            String NATURE = dataGRID.Rows[row].Cells[6].Value.ToString();
            String STOREY = dataGRID.Rows[row].Cells[7].Value.ToString();
            String PORTOCC = dataGRID.Rows[row].Cells[8].Value.ToString();
            String FLOORAREA = dataGRID.Rows[row].Cells[9].Value.ToString();
            String INSPECTED = dataGRID.Rows[row].Cells[10].Value.ToString();


            dataINFO info = new dataINFO();
            info.txtFSIC.Text = fsic;
            info.txtBIN.Text = BIN;
            info.txtname.Text = ESTABLISHMENTNAME;
            info.txtaddress.Text = ADDRESS;
            info.txtowner.Text = OWNER;
            info.cbeststatus.Text = STATUS;
            info.txtNOB.Text = NATURE;
            info.txtSTONUM.Text = STOREY;
            info.txtPOROCC.Text = PORTOCC;
            info.txtFLAREA.Text = FLOORAREA;
            info.cbinspected.Text = INSPECTED;
            info.ShowDialog();
        }

        private void dataGRID_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void binded(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGRID.ClearSelection();
        }
    }
}
