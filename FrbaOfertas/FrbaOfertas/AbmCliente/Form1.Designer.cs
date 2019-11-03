namespace FrbaOfertas.AbmCliente
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
            this.altaCliente = new System.Windows.Forms.Button();
            this.listadoCliente = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(322, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "ADM Cliente";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.altaCliente);
            this.panel1.Controls.Add(this.listadoCliente);
            this.panel1.Location = new System.Drawing.Point(214, 125);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(347, 226);
            this.panel1.TabIndex = 5;
            // 
            // altaCliente
            // 
            this.altaCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.altaCliente.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.altaCliente.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.altaCliente.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.altaCliente.ForeColor = System.Drawing.SystemColors.InfoText;
            this.altaCliente.Location = new System.Drawing.Point(90, 55);
            this.altaCliente.Name = "altaCliente";
            this.altaCliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.altaCliente.Size = new System.Drawing.Size(160, 33);
            this.altaCliente.TabIndex = 4;
            this.altaCliente.Text = "ALTA";
            this.altaCliente.UseVisualStyleBackColor = false;
            this.altaCliente.Click += new System.EventHandler(this.newCliente_Click);
            // 
            // listadoCliente
            // 
            this.listadoCliente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listadoCliente.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.listadoCliente.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.listadoCliente.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listadoCliente.ForeColor = System.Drawing.SystemColors.InfoText;
            this.listadoCliente.Location = new System.Drawing.Point(90, 125);
            this.listadoCliente.Name = "listadoCliente";
            this.listadoCliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listadoCliente.Size = new System.Drawing.Size(160, 33);
            this.listadoCliente.TabIndex = 3;
            this.listadoCliente.Text = "LISTADO";
            this.listadoCliente.UseVisualStyleBackColor = false;
            this.listadoCliente.Click += new System.EventHandler(this.editCliente_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 438);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button altaCliente;
        private System.Windows.Forms.Button listadoCliente;
    }
}