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
    public partial class dataINFO : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\BFP-FSES\\BFP-FSES.accdb;Persist Security Info=False;");
        Timer ot = new Timer();
        public dataINFO()
        {
            InitializeComponent();
        }

        private void dataINFO_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void A(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String query = "Update establishment_table set BIN = @txtBIN, establishment_name = @txtNAME, establishment_address=@txtaddress, establishment_owner=@txtowner, establishment_status=@cbstatus, nob=@txtNOB, occupancy_id=@txtOID, storey_no=@txtSTONUM, portion_occupied=@txtPOROCC, floor_area= @txtFLAREA, violation_id=@txtNOV, inspected= @cbinspected";
            con.Open();
            OleDbCommand M = new OleDbCommand(query,con);
            M.Parameters.AddWithValue("@txtBIN", txtBIN.Text);
            M.Parameters.AddWithValue("@txtNAME", txtname.Text);
            M.Parameters.AddWithValue("@txtaddress", txtaddress.Text);
            M.Parameters.AddWithValue("@txtowner", txtowner.Text);
            M.Parameters.AddWithValue("@cbstatus", cbeststatus.Text);
            M.Parameters.AddWithValue("@txtNOB", txtNOB.Text);
            M.Parameters.AddWithValue("@txtOID", txtOID.Text);
            M.Parameters.AddWithValue("@txtSTONUM", txtSTONUM.Text);
            M.Parameters.AddWithValue("@txtPOROCC", txtPOROCC.Text);
            M.Parameters.AddWithValue("@txtFLAREA", txtFLAREA.Text);
            M.Parameters.AddWithValue("@txtNOV", txtNOV.Text);
            M.Parameters.AddWithValue("@cbinspected", cbinspected.Text);

            String query2 = "Update fire_inspector_table set inspectors=@txtFSI";
            OleDbCommand N = new OleDbCommand(query2,con);
            N.Parameters.AddWithValue("@txtFSI", txtFSI.Text);

            DateTime date = DateTime.Parse(dtpDATE.Text);
            DateTime dateInspected = DateTime.Parse(dtpINSPECTED.Text);


            //String query3 = "UPDATE fsic_table SET fsic_no=@txtFSIC,BIN=@txtBIN ,date=@dtpDATE,application_status=@cbappstatus,amount=@txtAMOUNT,date_inspected=@dtpINSPECTED";
            //OleDbCommand P = new OleDbCommand(query3,con);
            //P.Parameters.AddWithValue("@txtFSIC", txtFSIC.Text);
            //P.Parameters.AddWithValue("@txtBIN", txtBIN.Text);
            //P.Parameters.AddWithValue("@dtpDATE", date);
            //P.Parameters.AddWithValue("@cbappstatus", cbappstatus.Text);
            //P.Parameters.AddWithValue("@txtAMOUNT", txtAMOUNT.Text);
            //P.Parameters.AddWithValue("@dtpINSPECTED", dateInspected);


            
            
            M.ExecuteNonQuery();
            N.ExecuteNonQuery();
            //P.ExecuteNonQuery();


            pictureBox1.Visible = true;

            
            ot.Interval = 1250;
            ot.Start();
            ot.Tick += new EventHandler(ot_Tick);

            con.Close();

            ucMASTERLIST.Instance.showData();
            
        }

        void ot_Tick(object sender, EventArgs e)
        {
            ot.Stop();
            pictureBox1.Visible = false;
        }

        


    }
}
