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
    public partial class checkpoint : Form
    {
        public checkpoint()
        {
            InitializeComponent();
        }

        private void checkpoint_Load(object sender, EventArgs e)
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

        private void btnYES_Click(object sender, EventArgs e)
        {
            btnYES.Visible = false;
            txtpassword.Visible = true;
            btnauthorize.Visible = true;
            btnNO.Visible = false;
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
