using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;


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
            popME();
            RowsColor();
            foreach (DataGridViewColumn dgvc in dataGRID.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }    
        }
        public void loadcbx()
        {
            String query = "SELECT * from tbl_year";
            OleDbDataAdapter load = new OleDbDataAdapter(query, con);
            DataSet ds = new DataSet();
            load.Fill(ds);
            ucMASTERLIST.Instance.comboBox2.DisplayMember = "record_year";
            ucMASTERLIST.Instance.comboBox2.ValueMember = "id";
            ucMASTERLIST.Instance.comboBox2.DataSource = ds.Tables[0];
        }

        public void loadYearData(int sentyear)
        {
           //load records per year
           int year = Convert.ToInt32(DateTime.Now.Year.ToString());

           String query1 = "Select `fsic_number` as `FSIC NUMBER`,`bin` as BIN,`est_name` as  `ESTABLISHMENT NAME`,`est_address` as ADDRESS,`est_owner` as OWNER, `est_status` as STATUS,`fsic_exp_date` as `FSIC EXP DATE`,`date_issued` as `DATE ISSUE`, `status_of_application` as `STATUS OF APPLICATION`, `amount` as `AMOUNT`, `or` as `OR`, `_date` as `DATE`,  `io_number` as `IO`, `date_inspected` as `DATE INSPECTED`,`nature_of_business` as `NATURE OF BUSINESS`, `occupancy_type` as OCCUPANCY, `safety_inspectors` as INSPECTORS, `cons_materials` as `MATERIALS`, `storey_no` as STOREY, `portion_occupied` as `PORTION OCCUPIED`, `floor_area` as `FLOOR AREA`, `noted_violation` as VIOLATION, `inspected` as INSPECTED, `est_type` as TYPE, `paid` as PAID,`version` as VERSION, `_month` as `MONTH` ,`id` as ID  from record where version=year";
           OleDbCommand y = new OleDbCommand(query1,con);
           y.Parameters.AddWithValue("@year",sentyear);
           OleDbDataAdapter latest = new OleDbDataAdapter(y);
           DataTable dt = new DataTable();
           latest.Fill(dt);
           DataView dview = new DataView();
           ucMASTERLIST.Instance.dataGRID.DataSource = dview;
           //ucMASTERLIST.Instance.dataGRID.DataSource = dt;

        }
        public void showData()
        {
            //String query = "SELECT * from record";
            String query = "Select `fsic_number` as `FSIC NUMBER`,`bin` as BIN,`est_name` as  `ESTABLISHMENT NAME`,`est_address` as ADDRESS,`est_owner` as OWNER, `est_status` as STATUS,`fsic_exp_date` as `FSIC EXP DATE`,`date_issued` as `DATE ISSUE`, `status_of_application` as `STATUS OF APPLICATION`, `amount` as `AMOUNT`, `or` as `OR`, `_date` as `DATE`,  `io_number` as `IO`, `date_inspected` as `DATE INSPECTED`,`nature_of_business` as `NATURE OF BUSINESS`, `occupancy_type` as OCCUPANCY, `safety_inspectors` as INSPECTORS, `cons_materials` as `MATERIALS`, `storey_no` as STOREY, `portion_occupied` as `PORTION OCCUPIED`, `floor_area` as `FLOOR AREA`, `noted_violation` as VIOLATION, `inspected` as INSPECTED, `est_type` as TYPE, `paid` as PAID  from record";
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
                    Boolean status = Convert.ToBoolean(dataGRID.Rows[i].Cells[22].Value.ToString());

                    if (status == true)
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
            try
            {
                String query1 = "Select `fsic_number` as `FSIC NUMBER`,`bin` as BIN,`est_name` as  `ESTABLISHMENT NAME`,`est_address` as ADDRESS,`est_owner` as OWNER, `est_status` as STATUS,`fsic_exp_date` as `FSIC EXP DATE`,`date_issued` as `DATE ISSUE`, `status_of_application` as `STATUS OF APPLICATION`, `amount` as `AMOUNT`, `or` as `OR`, `_date` as `DATE`,  `io_number` as `IO`, `date_inspected` as `DATE INSPECTED`,`nature_of_business` as `NATURE OF BUSINESS`, `occupancy_type` as OCCUPANCY, `safety_inspectors` as INSPECTORS, `cons_materials` as `MATERIALS`, `storey_no` as STOREY, `portion_occupied` as `PORTION OCCUPIED`, `floor_area` as `FLOOR AREA`, `noted_violation` as VIOLATION, `inspected` as INSPECTED, `est_type` as TYPE, `paid` as PAID,`version` as VERSION,`id` as ID  from record where `version`=@year and est_name like '%" + txtSEARCH.Text + "%'";
                OleDbCommand cmd = new OleDbCommand(query1, con);
                cmd.Parameters.AddWithValue("@year", Convert.ToInt32(comboBox2.Text));
                OleDbDataAdapter x = new OleDbDataAdapter(cmd);

                DataTable dt = new DataTable();
                x.Fill(dt);
                dataGRID.DataSource = dt;
            }
            catch (Exception)
            {
            }
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
            String EXPIREDATE = dataGRID.Rows[row].Cells[6].Value.ToString();
            String DATEISSUED = dataGRID.Rows[row].Cells[7].Value.ToString();
            String STATUSAPPLICATION = dataGRID.Rows[row].Cells[8].Value.ToString();
            String AMOUNT = dataGRID.Rows[row].Cells[9].Value.ToString();
            String OR = dataGRID.Rows[row].Cells[10].Value.ToString();
            String DATE = dataGRID.Rows[row].Cells[11].Value.ToString();
            String IONUMBER = dataGRID.Rows[row].Cells[12].Value.ToString();
            String DATEINSPECTED = dataGRID.Rows[row].Cells[13].Value.ToString();
            String NATUREBUSINESS = dataGRID.Rows[row].Cells[14].Value.ToString();
            String OCCUPANCYTYPE = dataGRID.Rows[row].Cells[15].Value.ToString();
            String INSPECTOR = dataGRID.Rows[row].Cells[16].Value.ToString();
            String MATERIALS = dataGRID.Rows[row].Cells[17].Value.ToString();
            String STOREY = dataGRID.Rows[row].Cells[18].Value.ToString();
            String PORTIONOCCUPIED = dataGRID.Rows[row].Cells[19].Value.ToString();
            String FLOORAREA = dataGRID.Rows[row].Cells[20].Value.ToString();
            String VIOLATION = dataGRID.Rows[row].Cells[21].Value.ToString();
            String ESTABLISHMENTTYPE = dataGRID.Rows[row].Cells[22].Value.ToString();
            Boolean cbi = Convert.ToBoolean(dataGRID.Rows[row].Cells[22].Value.ToString());
            Boolean paid = Convert.ToBoolean(dataGRID.Rows[row].Cells[24].Value.ToString());
            string version = dataGRID.Rows[row].Cells[25].Value.ToString();
            string id = dataGRID.Rows[row].Cells[27].Value.ToString();

            dataINFO info = new dataINFO();
            info.txtFSIC.Text = fsic;
            info.cbinspected.Text = cbi?"YES":"NO";
            info.txtBIN.Text = BIN;
            info.txtname.Text = ESTABLISHMENTNAME;
            info.txtaddress.Text = ADDRESS;
            info.txtowner.Text = OWNER;
            info.cbeststatus.Text = STATUS;
            info.dtpEXPIREDATE.Text = EXPIREDATE;
            info.dtpISSUED.Text = DATEISSUED;
            info.cbappstatus.Text = STATUSAPPLICATION;
            info.txtAMOUNT.Text = AMOUNT;
            info.txtOR.Text = OR;
            info.dtpDATE.Text = DATE;
            info.txtIO.Text = IONUMBER;
            info.dtpINSPECTED.Text = DATEINSPECTED;
            info.txtNOB.Text = NATUREBUSINESS;
            info.cbOCCTYPE.Text = OCCUPANCYTYPE;
            info.txtFSI.Text = INSPECTOR;
            info.txtCONMAT.Text = MATERIALS;
            info.txtSTONUM.Text = STOREY;
            info.txtPOROCC.Text = PORTIONOCCUPIED;
            info.txtFLAREA.Text = FLOORAREA;
            info.txtNOV.Text = VIOLATION;
            info.comboBox1.Text = ESTABLISHMENTTYPE;
            info.x = paid;
            info.version = version;
            info.sync = Convert.ToInt32(comboBox2.Text);
            info.id = Convert.ToInt32(id);

            if (paid)
            {
                info.cboxPAID.CheckState = CheckState.Checked;
            }

            if(!paid)
            {
                info.cboxPAID.CheckState=CheckState.Unchecked;
            }
            
            String query = "SELECT * FROM e_type";
            OleDbDataAdapter u = new OleDbDataAdapter(query, con);
            DataSet ds = new DataSet();
            u.Fill(ds);
            info.comboBox1.DisplayMember = "title";
            info.comboBox1.ValueMember = "ID";
            info.comboBox1.DataSource = ds.Tables[0];
            info.ShowDialog();
        }

        private void binded(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGRID.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // creating Excel Application  
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            // creating new WorkBook within Excel application  
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            // creating new Excelsheet in workbook  
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            // see the excel sheet behind the program  
            app.Visible = true;
            // get the reference of first sheet. By default its name is Sheet1.  
            // store its reference to worksheet  
            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            // changing the name of active sheet  
            worksheet.Name = "Exported From Database";
            // storing header part in Excel  
            for (int i = 1; i < dataGRID.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGRID.Columns[i - 1].HeaderText;
            }
            // storing Each row and column value to excel sheet  
            for (int i = 0; i < dataGRID.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGRID.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGRID.Rows[i].Cells[j].Value.ToString();
                }
            }
            // save the application  
            app.DisplayAlerts = false;
            workbook.SaveAs("D:\\MasterList.xlsx");
            app.Quit();

            //REOPEN AND RECOLOR
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook1 = application.Workbooks.Open("D:\\MasterList.xlsx");
            Excel.Worksheet worksheet1 = workbook1.ActiveSheet;
            Excel.Range usedRange = worksheet1.UsedRange;
            Excel.Range rows = usedRange.Rows;

            int count = 0;
            foreach (Excel.Range row in rows)
            {
                Excel.Range firstCell = row.Cells[23];

               // String y = firstCell.Value as String;
                if (count>0)
                {
                    if (Boolean.Parse(firstCell.Value.ToString()))
                    {
                        row.Interior.Color = Color.FromArgb(169,223,191);
                    }
                    else
                    {
                        row.Interior.Color = Color.FromArgb(249,231,159);
                    }
                }
                count++;
            }
            application.DisplayAlerts = false;
            worksheet1.Columns.AutoFit();
            worksheet1.Rows.AutoFit();
            worksheet1.Cells[28,Type.Missing].EntireColumn.Delete(null);
            //worksheet1.Columns.Delete(26);
            worksheet1.PageSetup.CenterHeader = "2019 Masterlist - Bureau of Fire Protection";
            workbook1.Save();
            application.Quit();

            AfterSaved execute = new AfterSaved();
            execute.ShowDialog();

            // Exit from the application
        }
        private void popME()
        {
            //String query = "SELECT * FROM e_type";
            //OleDbDataAdapter u = new OleDbDataAdapter(query, con);
            //DataSet ds = new DataSet();
            //u.Fill(ds);
            //ucMASTERLIST.Instance.comboBox1.DisplayMember = "title";
            //ucMASTERLIST.Instance.comboBox1.ValueMember = "ID";
            //ucMASTERLIST.Instance.comboBox1.DataSource = ds.Tables[0];

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ucMASTERLIST.Instance.loadYearData(Convert.ToInt32(comboBox2.Text));           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query1 = "Select `fsic_number` as `FSIC NUMBER`,`bin` as BIN,`est_name` as  `ESTABLISHMENT NAME`,`est_address` as ADDRESS,`est_owner` as OWNER, `est_status` as STATUS,`fsic_exp_date` as `FSIC EXP DATE`,`date_issued` as `DATE ISSUE`, `status_of_application` as `STATUS OF APPLICATION`, `amount` as `AMOUNT`, `or` as `OR`, `_date` as `DATE`,  `io_number` as `IO`, `date_inspected` as `DATE INSPECTED`,`nature_of_business` as `NATURE OF BUSINESS`, `occupancy_type` as OCCUPANCY, `safety_inspectors` as INSPECTORS, `cons_materials` as `MATERIALS`, `storey_no` as STOREY, `portion_occupied` as `PORTION OCCUPIED`, `floor_area` as `FLOOR AREA`, `noted_violation` as VIOLATION, `inspected` as INSPECTED, `est_type` as TYPE, `paid` as PAID,`version` as VERSION, `_month` as `MONTH` ,`id` as ID  from record where `version`=@year and `_month`=@month";
            OleDbCommand n = new OleDbCommand(query1,con);
            n.Parameters.AddWithValue("@year",comboBox2.Text);
            n.Parameters.AddWithValue("@month", comboBox1.Text);
            OleDbDataAdapter m = new OleDbDataAdapter(n);
            DataTable l = new DataTable();
            m.Fill(l);
            ucMASTERLIST.Instance.dataGRID.DataSource = l;
       
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            //print mechanism
            printMyExcelFile();
        }
        private void printMyExcelFile()
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook1 = application.Workbooks.Open("D:\\MasterList.xlsx");
            Excel.Worksheet worksheet1 = workbook1.ActiveSheet;
            try
            {
                //var print = application.ActivePrinter;
                //var work = workbook1;
                //printMyExcelFile();

        worksheet1.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
        worksheet1.PrintOut(Type.Missing, Type.Missing, Type.Missing, Type.Missing, 
        Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            }
            catch 
            { 
            }
            application.Quit();
        }

        private void autosize(object sender, DataGridViewAutoSizeColumnModeEventArgs e)
        {
            DataGridViewColumn column = dataGRID.Columns[2];
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
           // column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void numbering(object sender, DataGridViewRowsAddedEventArgs e)
        {

            foreach (DataGridViewRow row in dataGRID.Rows)
            {
                row.HeaderCell.Value = row.Index + 1;
            }
            dataGRID.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }
    }
}
