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
                //if ((txtBIN.Text == "" || txtname.Text == "" || txtaddress.Text == "" || txtowner.Text == "" || txtstatus.Text == ""))
                //{
                //    MessageBox.Show("Please Fill up the blank!", "System", MessageBoxButtons.OK);
                //}
                //else
                //{
                    con.Open();
                   // string query = "INSERT INTO Table1 (BIN, est_name, est_address, est_owner, est_status) values ('" + txtBIN.Text + "', '" + txtname.Text + "', '" + txtaddress.Text + "', '" + txtowner.Text + "', '" + txtstatus.Text + "', '" + txtFSIC.Text + "', '" + txtNOB.Text + "', '" + txtOID.Text + "', '" + txtSTONUM.Text + "', '" + txtPOROCC.Text + "', '" + txtFLAREA.Text + "', '" + txtNOV.Text + "', '" + txtFSI.Text + "', '" + txtCONMAT.Text + "', '" + txtOR.Text + "', '" + txtIO.Text + "', '" + dtpDATE + "', '" + txtAPPSTATUS.Text + "', '" + dtpINSPECTED + "', '" + txtAMOUNT.Text + "')";
                  //  OleDbCommand cmd = new OleDbCommand(query, con);
                  //  cmd.ExecuteNonQuery();

                    OleDbCommand x = new OleDbCommand("insert into establishment_table(BIN,establishment_name,establishment_address,establishment_owner,establishment_status,nob,occupancy_id,storey_no,portion_occupied,floor_area,violation_id) values (@bin,@establishment_name,@establishment_address,@establishment_owner,@establishment_status,@nob,@occupancy_id,@storey_no,@portion_occupied,@floor_area,@violation_id)", con);
                    x.Parameters.AddWithValue("@bin",txtBIN.Text);
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

                    con.Close();

                    con.Open();
                    OleDbCommand y = new OleDbCommand("insert into fire_inspector_table(fsiid,inspectors)values(@fsiid,@inspectors)",con);
                    x.Parameters.AddWithValue("@fsiid", txtFSIC.Text);
                    x.Parameters.AddWithValue("@inspectors", txtFSI.Text);
                    con.Close();

                    //x.ExecuteNonQuery();   
                    //MessageBox.Show("Create Successfully!", "System", MessageBoxButtons.OK)
                //}


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
