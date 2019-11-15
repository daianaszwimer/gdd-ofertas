namespace FrbaOfertas.CragaCredito
{
    partial class DatosTarjeta
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numero = new System.Windows.Forms.TextBox();
            this.fechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.codigoSeguridad = new System.Windows.Forms.TextBox();
            this.guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha de vencimiento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Codigo de seguridad";
            // 
            // numero
            // 
            this.numero.Location = new System.Drawing.Point(145, 31);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(126, 20);
            this.numero.TabIndex = 4;
            // 
            // fechaVencimiento
            // 
            this.fechaVencimiento.Location = new System.Drawing.Point(145, 58);
            this.fechaVencimiento.Name = "fechaVencimiento";
            this.fechaVencimiento.Size = new System.Drawing.Size(126, 20);
            this.fechaVencimiento.TabIndex = 5;
            // 
            // codigoSeguridad
            // 
            this.codigoSeguridad.Location = new System.Drawing.Point(222, 86);
            this.codigoSeguridad.Name = "codigoSeguridad";
            this.codigoSeguridad.Size = new System.Drawing.Size(49, 20);
            this.codigoSeguridad.TabIndex = 6;
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(196, 117);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 7;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // DatosTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 152);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.codigoSeguridad);
            this.Controls.Add(this.fechaVencimiento);
            this.Controls.Add(this.numero);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DatosTarjeta";
            this.Text = "DatosTarjeta";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.numero, 0);
            this.Controls.SetChildIndex(this.fechaVencimiento, 0);
            this.Controls.SetChildIndex(this.codigoSeguridad, 0);
            this.Controls.SetChildIndex(this.guardar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox numero;
        private System.Windows.Forms.DateTimePicker fechaVencimiento;
        private System.Windows.Forms.TextBox codigoSeguridad;
        private System.Windows.Forms.Button guardar;
    }
}