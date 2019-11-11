namespace FrbaOfertas.CragaCredito
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
            this.label3 = new System.Windows.Forms.Label();
            this.monto = new System.Windows.Forms.TextBox();
            this.tipoDePago = new System.Windows.Forms.ComboBox();
            this.tarjeta = new System.Windows.Forms.TextBox();
            this.cargarCredito = new System.Windows.Forms.Button();
            this.insertarDatosTarjeta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo de pago";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Monto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Datos Tarjeta";
            // 
            // monto
            // 
            this.monto.Location = new System.Drawing.Point(115, 48);
            this.monto.Name = "monto";
            this.monto.Size = new System.Drawing.Size(140, 20);
            this.monto.TabIndex = 4;
            // 
            // tipoDePago
            // 
            this.tipoDePago.FormattingEnabled = true;
            this.tipoDePago.Location = new System.Drawing.Point(115, 17);
            this.tipoDePago.Name = "tipoDePago";
            this.tipoDePago.Size = new System.Drawing.Size(140, 21);
            this.tipoDePago.TabIndex = 5;
            // 
            // tarjeta
            // 
            this.tarjeta.Location = new System.Drawing.Point(115, 80);
            this.tarjeta.Name = "tarjeta";
            this.tarjeta.Size = new System.Drawing.Size(110, 20);
            this.tarjeta.TabIndex = 6;
            // 
            // cargarCredito
            // 
            this.cargarCredito.Location = new System.Drawing.Point(180, 113);
            this.cargarCredito.Name = "cargarCredito";
            this.cargarCredito.Size = new System.Drawing.Size(75, 23);
            this.cargarCredito.TabIndex = 7;
            this.cargarCredito.Text = "Cargar";
            this.cargarCredito.UseVisualStyleBackColor = true;
            // 
            // insertarDatosTarjeta
            // 
            this.insertarDatosTarjeta.Location = new System.Drawing.Point(231, 78);
            this.insertarDatosTarjeta.Name = "insertarDatosTarjeta";
            this.insertarDatosTarjeta.Size = new System.Drawing.Size(24, 23);
            this.insertarDatosTarjeta.TabIndex = 8;
            this.insertarDatosTarjeta.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 152);
            this.Controls.Add(this.insertarDatosTarjeta);
            this.Controls.Add(this.cargarCredito);
            this.Controls.Add(this.tarjeta);
            this.Controls.Add(this.tipoDePago);
            this.Controls.Add(this.monto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox monto;
        private System.Windows.Forms.ComboBox tipoDePago;
        private System.Windows.Forms.TextBox tarjeta;
        private System.Windows.Forms.Button cargarCredito;
        private System.Windows.Forms.Button insertarDatosTarjeta;
    }
}