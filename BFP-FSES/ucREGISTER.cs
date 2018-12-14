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
    public partial class ucREGISTER : UserControl
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\BFP-FSES\\BFP-FSES.accdb;Persist Security Info=False;");
        public static ucREGISTER _instance;
        public static ucREGISTER Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucREGISTER();
                return _instance;
            }
        }
        public ucREGISTER()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((txtBIN.Text == "" || txtname.Text == "" || txtaddress.Text == "" || txtowner.Text == "" || cbappstatus.Text == ""))
                {
                    MessageBox.Show("Please Fill up the blank!", "System", MessageBoxButtons.OK);
                }
                else
                {
                    con.Open();
                    
                    OleDbCommand x = new OleDbCommand("insert into establishment_table(BIN,establishment_name,establishment_address,establishment_owner,establishment_status,nob,occupancy_id,storey_no,portion_occupied,floor_area,violation_id,inspected) values (@bin,@establishment_name,@establishment_address,@establishment_owner,@establishment_status,@nob,@occupancy_id,@storey_no,@portion_occupied,@floor_area,@violation_id,@inspected)", con);
                    x.Parameters.AddWithValue("@bin", txtBIN.Text);
                    x.Parameters.AddWithValue("@establishment_name", txtname.Text);
                    x.Parameters.AddWithValue("@establishment_address", txtaddress.Text);
                    x.Parameters.AddWithValue("@establishment_owner", txtowner.Text);
                    x.Parameters.AddWithValue("@establishment_status", cbeststatus.Text);
                    x.Parameters.AddWithValue("@nob", txtNOB.Text);
                    x.Parameters.AddWithValue("@occupancy_id", txtOID.Text);
                    x.Parameters.AddWithValue("@storey_no", txtSTONUM.Text);
                    x.Parameters.AddWithValue("@portion_occupied", txtPOROCC.Text);
                    x.Parameters.AddWithValue("@floor_area", txtFLAREA.Text);
                    x.Parameters.AddWithValue("@violation_id", txtNOV.Text);
                    x.Parameters.AddWithValue("@inspected", "NO");

                    x.ExecuteNonQuery();

                    OleDbCommand y = new OleDbCommand("insert into fire_inspector_table(inspectors)values(@inspectors)", con);
                    y.Parameters.AddWithValue("@inspectors", txtFSI.Text);
                    y.ExecuteNonQuery();


                    DateTime date = DateTime.Parse(dtpDATE.Text);
                    DateTime dateInspected = DateTime.Parse(dtpINSPECTED.Text);

                    String queryToFsic = "INSERT INTO fsic_table (`fsic_no`,`BIN`,`date`,`application_status`,`amount`,`date_inspected`) VALUES (@fsic,@BIN,@date,@as,@amt,@datei)";
                    OleDbCommand toFsic = new OleDbCommand(queryToFsic, con);
                    toFsic.Parameters.AddWithValue("@fsic", txtFSIC.Text);
                    toFsic.Parameters.AddWithValue("@BIN", txtBIN.Text);
                    toFsic.Parameters.AddWithValue("@date", date);
                    toFsic.Parameters.AddWithValue("@as", cbappstatus.Text);
                    toFsic.Parameters.AddWithValue("@amt", txtAMOUNT.Text);
                    toFsic.Parameters.AddWithValue("@datei",dateInspected);

                    toFsic.ExecuteNonQuery();

                    con.Close();
                    String query = "Select * from establishment_table ";
                    OleDbDataAdapter xz = new OleDbDataAdapter(query, con);
                     DataSet ds = new DataSet();
                     xz.Fill(ds, "establishment_table");
                     new ucMASTERLIST().dataGRID.DataSource = ds;

                MessageBox.Show("Create Successfully!", "System", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void kD(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void e(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }   
    }
}
