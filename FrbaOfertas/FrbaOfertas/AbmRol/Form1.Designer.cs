namespace FrbaOfertas.AbmRol
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.altaRol = new System.Windows.Forms.Button();
            this.listadoRol = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(335, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "ABM Rol";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.Beige;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.altaRol);
            this.panel1.Controls.Add(this.listadoRol);
            this.panel1.Location = new System.Drawing.Point(211, 125);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(347, 226);
            this.panel1.TabIndex = 9;
            // 
            // altaRol
            // 
            this.altaRol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.altaRol.BackColor = System.Drawing.Color.SandyBrown;
            this.altaRol.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.altaRol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.altaRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altaRol.ForeColor = System.Drawing.SystemColors.InfoText;
            this.altaRol.Location = new System.Drawing.Point(91, 56);
            this.altaRol.Name = "altaRol";
            this.altaRol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.altaRol.Size = new System.Drawing.Size(160, 33);
            this.altaRol.TabIndex = 4;
            this.altaRol.Text = "ALTA";
            this.altaRol.UseVisualStyleBackColor = false;
            this.altaRol.Click += new System.EventHandler(this.altaRol_Click);
            // 
            // listadoRol
            // 
            this.listadoRol.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listadoRol.BackColor = System.Drawing.Color.SandyBrown;
            this.listadoRol.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.listadoRol.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.listadoRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listadoRol.ForeColor = System.Drawing.SystemColors.InfoText;
            this.listadoRol.Location = new System.Drawing.Point(91, 126);
            this.listadoRol.Name = "listadoRol";
            this.listadoRol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listadoRol.Size = new System.Drawing.Size(160, 33);
            this.listadoRol.TabIndex = 3;
            this.listadoRol.Text = "LISTADO";
            this.listadoRol.UseVisualStyleBackColor = false;
            this.listadoRol.Click += new System.EventHandler(this.listadoRol_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 438);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button altaRol;
        private System.Windows.Forms.Button listadoRol;

    }
}