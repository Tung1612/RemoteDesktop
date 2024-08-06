namespace client
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnKetNoi = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnChiaSe = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnKetNoi
            // 
            this.btnKetNoi.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise;
            this.btnKetNoi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.btnKetNoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKetNoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKetNoi.ForeColor = System.Drawing.Color.Black;
            this.btnKetNoi.Location = new System.Drawing.Point(91, 183);
            this.btnKetNoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnKetNoi.Name = "btnKetNoi";
            this.btnKetNoi.Size = new System.Drawing.Size(143, 49);
            this.btnKetNoi.TabIndex = 0;
            this.btnKetNoi.Text = "Kết nối";
            this.btnKetNoi.UseVisualStyleBackColor = true;
            this.btnKetNoi.Click += new System.EventHandler(this.btnKetNoi_Click);
            // 
            // txtIP
            // 
            this.txtIP.BackColor = System.Drawing.Color.White;
            this.txtIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtIP.ForeColor = System.Drawing.Color.Black;
            this.txtIP.Location = new System.Drawing.Point(49, 55);
            this.txtIP.Margin = new System.Windows.Forms.Padding(4);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(253, 30);
            this.txtIP.TabIndex = 1;
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.White;
            this.txtPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtPort.ForeColor = System.Drawing.Color.Black;
            this.txtPort.Location = new System.Drawing.Point(49, 133);
            this.txtPort.Margin = new System.Windows.Forms.Padding(4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(253, 30);
            this.txtPort.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(45, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(45, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port:";
            // 
            // btnChiaSe
            // 
            this.btnChiaSe.FlatAppearance.BorderColor = System.Drawing.Color.Turquoise;
            this.btnChiaSe.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Turquoise;
            this.btnChiaSe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChiaSe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChiaSe.ForeColor = System.Drawing.Color.Black;
            this.btnChiaSe.Location = new System.Drawing.Point(49, 240);
            this.btnChiaSe.Margin = new System.Windows.Forms.Padding(4);
            this.btnChiaSe.Name = "btnChiaSe";
            this.btnChiaSe.Size = new System.Drawing.Size(236, 49);
            this.btnChiaSe.TabIndex = 5;
            this.btnChiaSe.Text = "Chia sẻ màn hình";
            this.btnChiaSe.UseVisualStyleBackColor = true;
            this.btnChiaSe.Click += new System.EventHandler(this.btnChiaSe_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(351, 321);
            this.Controls.Add(this.btnChiaSe);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnKetNoi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnKetNoi;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnChiaSe;
        private System.Windows.Forms.Timer timer1;
    }
}
