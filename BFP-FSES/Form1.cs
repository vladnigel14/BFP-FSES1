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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnREGISTER_Click(object sender, EventArgs e)
        {
            Sidepanel1.BackColor = Color.FromArgb(120, 40, 31);
            Sidepanel2.BackColor = Color.FromArgb(39, 55, 70);
        }

        private void btnMASTERLIST_Click(object sender, EventArgs e)
        {
            Sidepanel1.BackColor = Color.FromArgb(39, 55, 70);
            Sidepanel2.BackColor = Color.FromArgb(120, 40, 31);
        }

        private void btnREGISTER_Click_1(object sender, EventArgs e)
        {

            if (!panel.Controls.Contains(ucREGISTER.Instance))
            {
                panel.Controls.Add(ucREGISTER.Instance);
                ucREGISTER.Instance.Dock = DockStyle.Fill;
                ucREGISTER.Instance.BringToFront();
            }
            else
            {
                ucREGISTER.Instance.BringToFront();
            }
            Sidepanel1.BackColor = Color.FromArgb(120, 40, 31);
            Sidepanel2.BackColor = Color.FromArgb(39, 55, 70);
            

        }

        private void btnMASTERLIST_Click_1(object sender, EventArgs e)
        {
            if (!panel.Controls.Contains(ucREGISTER.Instance))
            {
                panel.Controls.Add(ucREGISTER.Instance);
                ucREGISTER.Instance.Dock = DockStyle.Fill;
                ucREGISTER.Instance.BringToFront();
            }
            else
            {
                ucREGISTER.Instance.BringToFront();
            }
            Sidepanel1.BackColor = Color.FromArgb(39, 55, 70);
            Sidepanel2.BackColor = Color.FromArgb(120, 40, 31);
        }
    }
}
