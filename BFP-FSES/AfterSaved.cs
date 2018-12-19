using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BFP_FSES
{
    public partial class AfterSaved : Form
    {
        public AfterSaved()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"D:\MasterList.xlsx");
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"D:\");
            this.Close();
        }

        private void AfterSaved_Load(object sender, EventArgs e)
        {

        }

        private const int CS_DROPSHADOW = 0x00020000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
