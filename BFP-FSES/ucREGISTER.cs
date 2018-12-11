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
                if ((txtBIN.Text == "" || txtname.Text == "" || txtaddress.Text == "" || txtowner.Text == "" || txtstatus.Text == ""))
                {
                    MessageBox.Show("Please Fill up the blank!", "System", MessageBoxButtons.OK);
                }
                else
                {
                    con.Open();

                    OleDbCommand x = new OleDbCommand("insert into establishment_table(BIN,establishment_name,establishment_address,establishment_owner,establishment_status,nob,occupancy_id,storey_no,portion_occupied,floor_area,violation_id) values (@bin,@establishment_name,@establishment_address,@establishment_owner,@establishment_status,@nob,@occupancy_id,@storey_no,@portion_occupied,@floor_area,@violation_id)", con);
                    x.Parameters.AddWithValue("@bin", txtBIN.Text);
                    x.Parameters.AddWithValue("@establishment_name", txtname.Text);
                    x.Parameters.AddWithValue("@establishment_address", txtaddress.Text);
                    x.Parameters.AddWithValue("@establishment_owner", txtowner.Text);
                    x.Parameters.AddWithValue("@establishment_status", txtstatus.Text);
                    x.Parameters.AddWithValue("@nob", txtNOB.Text);
                    x.Parameters.AddWithValue("@occupancy_id", txtOID.Text);
                    x.Parameters.AddWithValue("@storey_no", txtSTONUM.Text);
                    x.Parameters.AddWithValue("@portion_occupied", txtPOROCC.Text);
                    x.Parameters.AddWithValue("@floor_area", txtFLAREA.Text);
                    x.Parameters.AddWithValue("@violation_id", txtNOV.Text);

                    x.ExecuteNonQuery();

                    OleDbCommand y = new OleDbCommand("insert into fire_inspector_table(fsiid,inspectors)values(@fsiid,@inspectors)", con);
                    y.Parameters.AddWithValue("@fsiid", txtFSIC.Text);
                    y.Parameters.AddWithValue("@inspectors", txtFSI.Text);
                    y.ExecuteNonQuery();


                    DateTime date = DateTime.Parse(dtpDATE.Text);
                    DateTime dateInspected = DateTime.Parse(dtpINSPECTED.Text);

                    String queryToFsic = "INSERT INTO fsic_table (`BIN`,`date`,`application_status`,`amount`,`date_inspected`) VALUES (@BIN,@date,@as,@amt,@datei)";
                    OleDbCommand toFsic = new OleDbCommand(queryToFsic, con);
                    toFsic.Parameters.AddWithValue("@BIN", txtBIN.Text);
                    toFsic.Parameters.AddWithValue("@date", date);
                    toFsic.Parameters.AddWithValue("@as", txtAPPSTATUS.Text);
                    toFsic.Parameters.AddWithValue("@amt", txtAMOUNT.Text);
                    toFsic.Parameters.AddWithValue("@datei",dateInspected);

                    toFsic.ExecuteNonQuery();

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
    }
}
