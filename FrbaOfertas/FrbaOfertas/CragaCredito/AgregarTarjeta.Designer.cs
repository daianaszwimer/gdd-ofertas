namespace FrbaOfertas.CragaCredito
{
    partial class AgregarTarjeta
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numero = new System.Windows.Forms.TextBox();
            this.fechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.codigoSeguridad = new System.Windows.Forms.TextBox();
            this.guardar = new System.Windows.Forms.Button();
            this.errorNumero = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorFecha = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorCodigo = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorNumero)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorCodigo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(83, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha de vencimiento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Codigo de seguridad";
            // 
            // numero
            // 
            this.numero.Location = new System.Drawing.Point(141, 67);
            this.numero.Name = "numero";
            this.numero.Size = new System.Drawing.Size(126, 20);
            this.numero.TabIndex = 4;
            // 
            // fechaVencimiento
            // 
            this.fechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaVencimiento.Location = new System.Drawing.Point(141, 105);
            this.fechaVencimiento.Name = "fechaVencimiento";
            this.fechaVencimiento.Size = new System.Drawing.Size(126, 20);
            this.fechaVencimiento.TabIndex = 5;
            // 
            // codigoSeguridad
            // 
            this.codigoSeguridad.Location = new System.Drawing.Point(218, 145);
            this.codigoSeguridad.Name = "codigoSeguridad";
            this.codigoSeguridad.Size = new System.Drawing.Size(49, 20);
            this.codigoSeguridad.TabIndex = 6;
            // 
            // guardar
            // 
            this.guardar.Location = new System.Drawing.Point(192, 186);
            this.guardar.Name = "guardar";
            this.guardar.Size = new System.Drawing.Size(75, 23);
            this.guardar.TabIndex = 7;
            this.guardar.Text = "Guardar";
            this.guardar.UseVisualStyleBackColor = true;
            this.guardar.Click += new System.EventHandler(this.guardar_Click);
            // 
            // errorNumero
            // 
            this.errorNumero.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorNumero.ContainerControl = this;
            // 
            // errorFecha
            // 
            this.errorFecha.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorFecha.ContainerControl = this;
            // 
            // errorCodigo
            // 
            this.errorCodigo.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorCodigo.ContainerControl = this;
            // 
            // AgregarTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.guardar);
            this.Controls.Add(this.codigoSeguridad);
            this.Controls.Add(this.fechaVencimiento);
            this.Controls.Add(this.numero);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AgregarTarjeta";
            this.Text = "DatosTarjeta";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.numero, 0);
            this.Controls.SetChildIndex(this.fechaVencimiento, 0);
            this.Controls.SetChildIndex(this.codigoSeguridad, 0);
            this.Controls.SetChildIndex(this.guardar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorNumero)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorCodigo)).EndInit();
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
        private System.Windows.Forms.ErrorProvider errorNumero;
        private System.Windows.Forms.ErrorProvider errorFecha;
        private System.Windows.Forms.ErrorProvider errorCodigo;
    }
}