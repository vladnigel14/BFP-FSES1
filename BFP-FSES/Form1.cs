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
            btnREGISTER.BackColor = Color.FromArgb(46, 64, 83);
            btnMASTERLIST.BackColor = Color.FromArgb(39, 55, 70);
            btnREGISTER.Font = new Font("Bahnschrift", 10, FontStyle.Bold);
            btnMASTERLIST.Font = new Font("Bahnschrift", 9, FontStyle.Bold);
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
            Sidepanel1.BackColor = Color.FromArgb(39, 55, 70);
            Sidepanel2.BackColor = Color.FromArgb(120, 40, 31);
            btnREGISTER.Font = new Font("Bahnschrift", 9, FontStyle.Bold);
            btnMASTERLIST.Font = new Font("Bahnschrift", 10, FontStyle.Bold);
            btnREGISTER.BackColor = Color.FromArgb(39, 55, 70);
            btnMASTERLIST.BackColor = Color.FromArgb(46, 64, 83);
            if (!panel.Controls.Contains(ucMASTERLIST.Instance))
            {
                panel.Controls.Add(ucMASTERLIST.Instance);
                ucMASTERLIST.Instance.Dock = DockStyle.Fill;
                ucMASTERLIST.Instance.BringToFront();
            }
            else
            {
                ucMASTERLIST.Instance.BringToFront();
            }
            
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panellogo_Click(object sender, EventArgs e)
        {
            btnREGISTER.Font = new Font("Bahnschrift", 9, FontStyle.Bold);
            btnMASTERLIST.Font = new Font("Bahnschrift", 9, FontStyle.Bold);
            btnREGISTER.BackColor = Color.FromArgb(39, 55, 70);
            btnMASTERLIST.BackColor = Color.FromArgb(39, 55, 70);
            Sidepanel1.BackColor = Color.FromArgb(39, 55, 70);
            Sidepanel2.BackColor = Color.FromArgb(39, 55, 70);
            panel.Controls.Remove(ucREGISTER.Instance);
            panel.Controls.Remove(ucMASTERLIST.Instance);
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panellogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
