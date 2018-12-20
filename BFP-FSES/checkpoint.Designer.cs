namespace BFP_FSES
{
    partial class checkpoint
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(checkpoint));
            this.label1 = new System.Windows.Forms.Label();
            this.btnYES = new System.Windows.Forms.Button();
            this.btnNO = new System.Windows.Forms.Button();
            this.btnauthorize = new System.Windows.Forms.Button();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "You have already marked this as paid. \r\nDo you wish to overwrite the record?";
            // 
            // btnYES
            // 
            this.btnYES.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYES.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(64)))), ((int)(((byte)(83)))));
            this.btnYES.FlatAppearance.BorderSize = 2;
            this.btnYES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYES.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYES.Location = new System.Drawing.Point(58, 103);
            this.btnYES.Name = "btnYES";
            this.btnYES.Size = new System.Drawing.Size(90, 30);
            this.btnYES.TabIndex = 1;
            this.btnYES.Text = "YES";
            this.btnYES.UseVisualStyleBackColor = true;
            this.btnYES.Click += new System.EventHandler(this.btnYES_Click);
            // 
            // btnNO
            // 
            this.btnNO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNO.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(64)))), ((int)(((byte)(83)))));
            this.btnNO.FlatAppearance.BorderSize = 2;
            this.btnNO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNO.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNO.Location = new System.Drawing.Point(180, 103);
            this.btnNO.Name = "btnNO";
            this.btnNO.Size = new System.Drawing.Size(90, 30);
            this.btnNO.TabIndex = 2;
            this.btnNO.Text = "NO";
            this.btnNO.UseVisualStyleBackColor = true;
            // 
            // btnauthorize
            // 
            this.btnauthorize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnauthorize.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(64)))), ((int)(((byte)(83)))));
            this.btnauthorize.FlatAppearance.BorderSize = 2;
            this.btnauthorize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnauthorize.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnauthorize.Location = new System.Drawing.Point(197, 128);
            this.btnauthorize.Name = "btnauthorize";
            this.btnauthorize.Size = new System.Drawing.Size(96, 34);
            this.btnauthorize.TabIndex = 3;
            this.btnauthorize.Text = "Authorize";
            this.btnauthorize.UseVisualStyleBackColor = true;
            this.btnauthorize.Visible = false;
            // 
            // txtpassword
            // 
            this.txtpassword.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtpassword.Location = new System.Drawing.Point(35, 93);
            this.txtpassword.Multiline = true;
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '•';
            this.txtpassword.Size = new System.Drawing.Size(258, 29);
            this.txtpassword.TabIndex = 4;
            this.txtpassword.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(64)))), ((int)(((byte)(83)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 33);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bahnschrift", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(9, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "SYSTEM NOTICE";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(299, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(34, 33);
            this.panel2.TabIndex = 4;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // checkpoint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 174);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnauthorize);
            this.Controls.Add(this.btnNO);
            this.Controls.Add(this.btnYES);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtpassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "checkpoint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attempt to Overwrite";
            this.Load += new System.EventHandler(this.checkpoint_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnYES;
        private System.Windows.Forms.Button btnNO;
        private System.Windows.Forms.Button btnauthorize;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
    }
}