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
        public Boolean x;
        public String version;
        public int sync;
        public int id;
        public dataINFO()
        {
            InitializeComponent();
        }

        private void dataINFO_Load(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
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

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            String updateQuery;
            updateQuery = "UPDATE record SET `bin`=@bin,`est_name`= @est_name,`est_address` =@est_address, `est_owner` =@est_owner,`est_status`= @est_status,`fsic_exp_date` =@fsic_exp_date,`date_issued`=@date_issued,`fsic_number`= @fsic_number,`status_of_application`= @status_of_application,`amount`= @amount,`or`= @or, `_date`= @_date,`io_number` =@io_number, `date_inspected`= @date_inspected, `nature_of_business`= @nature_of_business,`occupancy_type`= @occupancy_type,`safety_inspectors` =@safety_inspectors, `cons_materials`=@cons_materials, `storey_no`= @storey_no,`portion_occupied` =@portion_occupied, `floor_area` =@floor_area, `noted_violation` =@noted_violation,`inspected`=@inspected, `est_type`= @est_type ,`paid` = @paid, `_month` =@month where id=@id";


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
            addRecordCommand.Parameters.AddWithValue("@paid", cboxPAID.Checked ? true : false);
            addRecordCommand.Parameters.AddWithValue("@month", cmbmonth1.Text);
            addRecordCommand.Parameters.AddWithValue("@id",id);
            addRecordCommand.ExecuteNonQuery();

            if (cboxPAID.Checked && x!=true)
            {
                String query = "insert into record  (`bin`,`est_name`,`est_address`, `est_owner`,`est_status`,`fsic_exp_date`,`date_issued`,`fsic_number`,`status_of_application`,`amount`,`or`,`_date`,`io_number`, `nature_of_business`,`occupancy_type`,`safety_inspectors`, `cons_materials`, `storey_no`,`portion_occupied`, `floor_area`, `noted_violation`,`inspected`,`est_type`,`paid`,`version`) values (@bin,@est_name,@est_address,@est_owner,@est_status,@fsic_exp_date,@date_issued,@fsic_number,@status_of_application,@amount,@or,@_date,@io_number,@nature_of_business,@occupancy_type,@safety_inspectors,@cons_materials,@storey_no,@portion_occupied,@floor_area,@noted_violation,@inspected, @est_type ,@paid,@version)";


                OleDbCommand addRecordCommand1 = new OleDbCommand(query,con);

                addRecordCommand1.Parameters.AddWithValue("@bin", txtBIN.Text);
                addRecordCommand1.Parameters.AddWithValue("@est_name", txtname.Text);
                addRecordCommand1.Parameters.AddWithValue("@est_address", txtaddress.Text);
                addRecordCommand1.Parameters.AddWithValue("@est_owner", txtowner.Text);
                addRecordCommand1.Parameters.AddWithValue("@est_status", cbeststatus.Text);
                addRecordCommand1.Parameters.AddWithValue("@fsic_exp_date", DateTime.Parse(dtpDATE.Text));
                addRecordCommand1.Parameters.AddWithValue("@date_issued", DateTime.Parse(dtpDATE.Text));
                addRecordCommand1.Parameters.AddWithValue("@fsic_number", txtFSIC.Text);
                addRecordCommand1.Parameters.AddWithValue("@status_of_application", "RENEW");
                addRecordCommand1.Parameters.AddWithValue("@amount", txtAMOUNT.Text);
                addRecordCommand1.Parameters.AddWithValue("@or", txtOR.Text);
                addRecordCommand1.Parameters.AddWithValue("@_date", DateTime.Parse(dtpDATE.Text));
                addRecordCommand1.Parameters.AddWithValue("@io_number", txtIO.Text);
                //addRecordCommand1.Parameters.AddWithValue("@date_inspected", DateTime.Parse(dtpINSPECTED.Text));
                addRecordCommand1.Parameters.AddWithValue("@nature_of_business", txtNOB.Text);
                addRecordCommand1.Parameters.AddWithValue("@occupancy_type", cbOCCTYPE.Text);
                addRecordCommand1.Parameters.AddWithValue("@safety_inspectors", txtFSI.Text);
                addRecordCommand1.Parameters.AddWithValue("@cons_materials", txtCONMAT.Text);
                addRecordCommand1.Parameters.AddWithValue("@storey_no", txtSTONUM.Text);
                addRecordCommand1.Parameters.AddWithValue("@portion_occupied", txtPOROCC.Text);
                addRecordCommand1.Parameters.AddWithValue("@floor_area", txtFLAREA.Text);
                addRecordCommand1.Parameters.AddWithValue("@noted_violation", txtNOV.Text);
                addRecordCommand1.Parameters.AddWithValue("@inspected", false);
                addRecordCommand1.Parameters.AddWithValue("@est_type", comboBox1.Text);
                addRecordCommand1.Parameters.AddWithValue("@paid",  false);
                addRecordCommand1.Parameters.AddWithValue("@version", Convert.ToInt32(version)+1);

                String c = "select count(*) from tbl_year where record_year=@version";
                OleDbCommand getYear = new OleDbCommand(c, con);
                getYear.Parameters.AddWithValue("@version",Convert.ToInt32(version)+1);
                int count = Convert.ToInt32(getYear.ExecuteScalar().ToString());

                if (count > 0)
                {
                    if (addRecordCommand1.ExecuteNonQuery() > 0)
                    {
                        MessageBox.Show("INSERTED!");
                    }

                }
                else
                {
                    OleDbCommand addyear = new OleDbCommand("insert into tbl_year (`record_year`) values (@version)",con);
                    addyear.Parameters.AddWithValue("@version",Convert.ToInt32(version)+1);

                    if (addyear.ExecuteNonQuery() > 0)
                    {
                        if (addRecordCommand1.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("INSERTED!");
                        }

                        ucMASTERLIST.Instance.loadcbx();

                    }
                }
            }

            pictureBox1.Visible = true;
            ot.Interval = 1250;
            ot.Start();
            ot.Tick += new EventHandler(ot_Tick);

            con.Close();

            ucMASTERLIST.Instance.loadYearData(sync);   
        }

        void ot_Tick(object sender, EventArgs e)
        {
            ot.Stop();
            pictureBox1.Visible = false;
        }

        private void cboxPAID_CheckedChanged(object sender, EventArgs e)
        {
            Boolean state = cboxPAID.Checked;

            if (!state)
            {

                checkpoint cp = new checkpoint();
                cp.ShowDialog();

                cboxPAID.CheckState = CheckState.Checked;
            
            }
        }
    }
}
