using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BFP_FSES
{
    public partial class ucREGISTER : UserControl
    {
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ucREGISTER_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

      
    }
}
