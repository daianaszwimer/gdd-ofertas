namespace FrbaOfertas.EntregaDeOferta
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bajaCupon = new System.Windows.Forms.Button();
            this.clienteDni = new System.Windows.Forms.TextBox();
            this.codigoCupon = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "DNI cliente :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Codigo cupon:";
            // 
            // bajaCupon
            // 
            this.bajaCupon.Location = new System.Drawing.Point(283, 182);
            this.bajaCupon.Name = "bajaCupon";
            this.bajaCupon.Size = new System.Drawing.Size(99, 23);
            this.bajaCupon.TabIndex = 12;
            this.bajaCupon.Text = "DAR DE BAJA";
            this.bajaCupon.UseVisualStyleBackColor = true;
            this.bajaCupon.Click += new System.EventHandler(this.bajaCupon_Click);
            // 
            // clienteDni
            // 
            this.clienteDni.Location = new System.Drawing.Point(138, 121);
            this.clienteDni.Name = "clienteDni";
            this.clienteDni.Size = new System.Drawing.Size(221, 20);
            this.clienteDni.TabIndex = 21;
            // 
            // codigoCupon
            // 
            this.codigoCupon.FormattingEnabled = true;
            this.codigoCupon.Location = new System.Drawing.Point(138, 83);
            this.codigoCupon.Name = "codigoCupon";
            this.codigoCupon.Size = new System.Drawing.Size(221, 21);
            this.codigoCupon.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.codigoCupon);
            this.Controls.Add(this.clienteDni);
            this.Controls.Add(this.bajaCupon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.bajaCupon, 0);
            this.Controls.SetChildIndex(this.clienteDni, 0);
            this.Controls.SetChildIndex(this.codigoCupon, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bajaCupon;
        private System.Windows.Forms.TextBox clienteDni;
        private System.Windows.Forms.ComboBox codigoCupon;
    }
}