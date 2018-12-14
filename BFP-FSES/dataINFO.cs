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
            con.Open();
            String updateQuery;
            updateQuery = "UPDATE record SET `bin`=@bin,`est_name`= @est_name,`est_address` =@est_address, `est_owner` =@est_owner,`est_status`= @est_status,`fsic_exp_date` =@fsic_exp_date,`date_issued`=@date_issued,`fsic_number`= @fsic_number,`status_of_application`= @status_of_application,`amount`= @amount,`or`= @or, `_date`= @_date,`io_number` =@io_number, `date_inspected`= @date_inspected, `nature_of_business`= @nature_of_business,`occupancy_type`= @occupancy_type,`safety_inspectors` =@safety_inspectors, `cons_materials`=@cons_materials, `storey_no`= @storey_no,`portion_occupied` =@portion_occupied, `floor_area` =@floor_area, `noted_violation` =@noted_violation,`inspected`=@inspected, `est_type`= @est_type where bin=@bin";


            OleDbCommand addRecordCommand = new OleDbCommand(updateQuery,con);

            addRecordCommand.Parameters.AddWithValue("@bin", txtBIN.Text);
            addRecordCommand.Parameters.AddWithValue("@est_name", txtname.Text);
            addRecordCommand.Parameters.AddWithValue("@est_address", txtaddress.Text);
            addRecordCommand.Parameters.AddWithValue("@est_owner", txtowner.Text);
            addRecordCommand.Parameters.AddWithValue("@est_status", cbeststatus.Text);
            addRecordCommand.Parameters.AddWithValue("@fsic_exp_date", DateTime.Parse(dtpDATE.Text));
            addRecordCommand.Parameters.AddWithValue("@date_issued", DateTime.Parse(dtpDATE.Text));
            addRecordCommand.Parameters.AddWithValue("@fsic_number", txtFSIC.Text);
            addRecordCommand.Parameters.AddWithValue("@status_of_application", cbappstatus.Text);
            addRecordCommand.Parameters.AddWithValue("@amount", txtAMOUNT.Text);
            addRecordCommand.Parameters.AddWithValue("@or", txtOR.Text);
            addRecordCommand.Parameters.AddWithValue("@_date", DateTime.Parse(dtpDATE.Text));
            addRecordCommand.Parameters.AddWithValue("@io_number", txtIO.Text);
            addRecordCommand.Parameters.AddWithValue("@date_inspected", DateTime.Parse(dtpINSPECTED.Text));
            addRecordCommand.Parameters.AddWithValue("@nature_of_business", txtNOB.Text);
            addRecordCommand.Parameters.AddWithValue("@occupancy_type", cbOCCTYPE.Text);
            addRecordCommand.Parameters.AddWithValue("@safety_inspectors", txtFSI.Text);
            addRecordCommand.Parameters.AddWithValue("@cons_materials", txtCONMAT.Text);
            addRecordCommand.Parameters.AddWithValue("@storey_no", txtSTONUM.Text);
            addRecordCommand.Parameters.AddWithValue("@portion_occupied", txtPOROCC.Text);
            addRecordCommand.Parameters.AddWithValue("@floor_area", txtFLAREA.Text);
            addRecordCommand.Parameters.AddWithValue("@noted_violation", txtNOV.Text);
            addRecordCommand.Parameters.AddWithValue("@inspected", cbinspected.Text=="YES"?true:false);
            addRecordCommand.Parameters.AddWithValue("@est_type", comboBox1.Text);

            pictureBox1.Visible = true;

            addRecordCommand.ExecuteNonQuery();
            
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
