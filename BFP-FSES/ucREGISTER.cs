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

                    addRecordQuery = "INSERT INTO record (`bin`,`est_name`,`est_address`,`est_owner`,`est_status`,`fsic_exp_date`,`date_issued`,`fsic_number`,`status_of_application`,`amount`,`or`,`_date`,`io_number`,`date_inspected`,`nature_of_business`,`occupancy_type`,`safety_inspectors`,`cons_materials`,`storey_no`,`portion_occupied`,`floor_area`,`noted_violation`,`inspected`,`est_type`,`version`) VALUES (@bin,@est_name,@est_address,@est_owner,@est_status,@fsic_exp_date,@date_issued,@fsic_number,@status_of_application,@amount,@or,@_date,@io_number,@date_inspected,@nature_of_business,@occupancy_type,@safety_inspectors,@cons_materials,@storey_no,@portion_occupied,@floor_area,@noted_violation,@inspected,@est_type,@version)";

                    OleDbCommand addRecordCommand = new OleDbCommand(addRecordQuery,con);
                    addRecordCommand.Parameters.AddWithValue("@bin",txtBIN.Text);
                    addRecordCommand.Parameters.AddWithValue("@est_name",txtname.Text);
                    addRecordCommand.Parameters.AddWithValue("@est_address", txtaddress.Text);
                    addRecordCommand.Parameters.AddWithValue("@est_owner",txtowner.Text);
                    addRecordCommand.Parameters.AddWithValue("@est_status",cbeststatus.Text);
                    addRecordCommand.Parameters.AddWithValue("@fsic_exp_date",DateTime.Parse(dtpDATE.Text));
                    addRecordCommand.Parameters.AddWithValue("@date_issued", DateTime.Parse(dtpDATE.Text));
                    addRecordCommand.Parameters.AddWithValue("@fsic_number",txtFSIC.Text);
                    addRecordCommand.Parameters.AddWithValue("@status_of_application",cbappstatus.Text);
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
                    addRecordCommand.Parameters.AddWithValue("@est_type", comboBox1.Text);
                    addRecordCommand.Parameters.AddWithValue("@version", DateTime.Now.Year);
                    


                    OleDbCommand yr = new OleDbCommand("select count(*) from tbl_year where record_year=@ryr", con);
                    yr.Parameters.AddWithValue("@ryr", DateTime.Parse(dtpDATE.Text).Year);
                    int count = Convert.ToInt32(yr.ExecuteScalar().ToString());

                    if (count <= 0)
                    {


                        OleDbCommand addyear = new OleDbCommand("insert into tbl_year (`record_year`) values (@version)", con);
                        addyear.Parameters.AddWithValue("@version", Convert.ToInt32(DateTime.Parse(dtpDATE.Text).Year));

                        if (addyear.ExecuteNonQuery() > 0)
                        {
                            if (addRecordCommand.ExecuteNonQuery() > 0)
                            {
                                MessageBox.Show("REGISTERED!");
                            }

                            ucMASTERLIST.Instance.loadcbx();

                        }

                    }
                    else
                    {
                        if (addRecordCommand.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("REGISTERED!");
                        }

                        ucMASTERLIST.Instance.loadcbx();
                    }


                    con.Close();           
        }

        private void kD(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void e(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "ADD NEW TYPE")
            {
                comboBox1.Text = null;
            }
        }

        private void entere(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                DialogResult ak = MessageBox.Show("Save "+comboBox1.Text+ " ?","Confirm Type",MessageBoxButtons.YesNo);
                if(ak==DialogResult.Yes)
                {
                    
                con.Open();
                String query = "INSERT INTO e_type (title) VALUES (@type)";
                OleDbCommand cmd = new OleDbCommand(query,con);
                cmd.Parameters.AddWithValue("@type",comboBox1.Text);
                cmd.ExecuteNonQuery();
                comboBox1.Text = null;
                popCom();
                comboBox1.Text = null;
                con.Close();

                }
            }
        }

        private void popCom()
        {
            String query = "SELECT * FROM e_type";
            OleDbDataAdapter u = new OleDbDataAdapter(query, con);
            DataSet ds = new DataSet();
            u.Fill(ds);
            ucREGISTER.Instance.comboBox1.DisplayMember = "title";
            ucREGISTER.Instance.comboBox1.ValueMember = "ID";
            ucREGISTER.Instance.comboBox1.DataSource = ds.Tables[0];
           
        }
    }
}
