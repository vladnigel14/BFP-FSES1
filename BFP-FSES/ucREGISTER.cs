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
          
                    con.Open();

                    String addRecordQuery;

                    addRecordQuery = "INSERT INTO record (`bin`,`est_name`,`est_address`,`est_owner`,`est_status`,`fsic_exp_date`,`date_issued`,`fsic_number`,`status_of_application`,`amount`,`or`,`_date`,`io_number`,`date_inspected`,`nature_of_business`,`occupancy_type`,`safety_inspectors`,`cons_materials`,`storey_no`,`portion_occupied`,`floor_area`,`noted_violation`,`inspected`) VALUES (@bin,@est_name,@est_address,@est_owner,@est_status,@fsic_exp_date,@date_issued,@fsic_number,@status_of_application,@amount,@or,@_date,@io_number,@date_inspected,@nature_of_business,@occupancy_type,@safety_inspectors,@cons_materials,@storey_no,@portion_occupied,@floor_area,@noted_violation,@inspected)";

                    OleDbCommand addRecordCommand = new OleDbCommand(addRecordQuery,con);
                    addRecordCommand.Parameters.AddWithValue("@bin",txtBIN.Text);
                    addRecordCommand.Parameters.AddWithValue("@est_name",txtname.Text);
                    addRecordCommand.Parameters.AddWithValue("@est_address", txtaddress.Text);
                    addRecordCommand.Parameters.AddWithValue("@est_owner",txtowner.Text);
                    addRecordCommand.Parameters.AddWithValue("@est_status",cbeststatus.Text);
                    addRecordCommand.Parameters.AddWithValue("@fsic_exp_date",DateTime.Parse(dtpDATE.Text));
                    addRecordCommand.Parameters.AddWithValue("@date_issued", DateTime.Parse(dtpDATE.Text));
                    addRecordCommand.Parameters.AddWithValue("@fsic_number",txtFSIC.Text);
                    addRecordCommand.Parameters.AddWithValue("@status_of_application",cbeststatus.Text);
                    addRecordCommand.Parameters.AddWithValue("@amount",txtAMOUNT.Text);
                    addRecordCommand.Parameters.AddWithValue("@or",txtOR.Text);
                    addRecordCommand.Parameters.AddWithValue("@_date",DateTime.Parse(dtpDATE.Text));
                    addRecordCommand.Parameters.AddWithValue("@io_number",txtIO.Text);
                    addRecordCommand.Parameters.AddWithValue("@date_inspected",DateTime.Parse(dtpINSPECTED.Text));
                    addRecordCommand.Parameters.AddWithValue("@nature_of_business",txtNOB.Text);
                    addRecordCommand.Parameters.AddWithValue("@occupancy_type",txtOID.Text);
                    addRecordCommand.Parameters.AddWithValue("@safety_inspectors",txtFSI.Text);
                    addRecordCommand.Parameters.AddWithValue("@cons_materials",txtCONMAT.Text);
                    addRecordCommand.Parameters.AddWithValue("@storey_no",txtSTONUM.Text);
                    addRecordCommand.Parameters.AddWithValue("@portion_occupied",txtPOROCC.Text);
                    addRecordCommand.Parameters.AddWithValue("@floor_area",txtFLAREA.Text);
                    addRecordCommand.Parameters.AddWithValue("@noted_violation",txtNOV.Text);
                    addRecordCommand.Parameters.AddWithValue("@inspected", false);

                    addRecordCommand.ExecuteNonQuery();
                    MessageBox.Show("Record Inserted");
                    

                    con.Close();
                   
            
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
