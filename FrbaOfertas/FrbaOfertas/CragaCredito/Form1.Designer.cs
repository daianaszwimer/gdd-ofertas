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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.monto = new System.Windows.Forms.TextBox();
            this.tipoDePago = new System.Windows.Forms.ComboBox();
            this.cargarCredito = new System.Windows.Forms.Button();
            this.nuevaTarjeta = new System.Windows.Forms.Button();
            this.seleccionarCliente = new System.Windows.Forms.Button();
            this.cliente = new System.Windows.Forms.TextBox();
            this.labelCliente = new System.Windows.Forms.Label();
            this.tarjetaTextBox = new System.Windows.Forms.TextBox();
            this.errorTipoDePago = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorMonto = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorTarjeta = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorCliente = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorTipoDePago)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorMonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorTarjeta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tipo de pago";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Monto";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tarjeta";
            // 
            // monto
            // 
            this.monto.Location = new System.Drawing.Point(245, 95);
            this.monto.Name = "monto";
            this.monto.Size = new System.Drawing.Size(76, 20);
            this.monto.TabIndex = 4;
            // 
            // tipoDePago
            // 
            this.tipoDePago.FormattingEnabled = true;
            this.tipoDePago.Location = new System.Drawing.Point(112, 51);
            this.tipoDePago.Name = "tipoDePago";
            this.tipoDePago.Size = new System.Drawing.Size(209, 21);
            this.tipoDePago.TabIndex = 5;
            // 
            // cargarCredito
            // 
            this.cargarCredito.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cargarCredito.BackColor = System.Drawing.Color.SandyBrown;
            this.cargarCredito.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.cargarCredito.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cargarCredito.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cargarCredito.ForeColor = System.Drawing.SystemColors.InfoText;
            this.cargarCredito.Location = new System.Drawing.Point(214, 220);
            this.cargarCredito.Name = "cargarCredito";
            this.cargarCredito.Size = new System.Drawing.Size(107, 33);
            this.cargarCredito.TabIndex = 7;
            this.cargarCredito.Text = "Cargar";
            this.cargarCredito.UseVisualStyleBackColor = false;
            this.cargarCredito.Click += new System.EventHandler(this.cargarCredito_Click);
            // 
            // nuevaTarjeta
            // 
            this.nuevaTarjeta.BackColor = System.Drawing.Color.SandyBrown;
            this.nuevaTarjeta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.nuevaTarjeta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nuevaTarjeta.Location = new System.Drawing.Point(245, 136);
            this.nuevaTarjeta.Name = "nuevaTarjeta";
            this.nuevaTarjeta.Size = new System.Drawing.Size(76, 23);
            this.nuevaTarjeta.TabIndex = 8;
            this.nuevaTarjeta.Text = "Añadir";
            this.nuevaTarjeta.UseVisualStyleBackColor = false;
            this.nuevaTarjeta.Click += new System.EventHandler(this.nuevaTarjeta_Click);
            // 
            // seleccionarCliente
            // 
            this.seleccionarCliente.BackColor = System.Drawing.Color.SandyBrown;
            this.seleccionarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seleccionarCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seleccionarCliente.Location = new System.Drawing.Point(244, 180);
            this.seleccionarCliente.Name = "seleccionarCliente";
            this.seleccionarCliente.Size = new System.Drawing.Size(76, 23);
            this.seleccionarCliente.TabIndex = 32;
            this.seleccionarCliente.Text = "Seleccionar";
            this.seleccionarCliente.UseVisualStyleBackColor = false;
            this.seleccionarCliente.Click += new System.EventHandler(this.seleccionarCliente_Click);
            // 
            // cliente
            // 
            this.cliente.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cliente.Enabled = false;
            this.cliente.Location = new System.Drawing.Point(111, 182);
            this.cliente.Name = "cliente";
            this.cliente.Size = new System.Drawing.Size(127, 20);
            this.cliente.TabIndex = 31;
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(60, 185);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(45, 13);
            this.labelCliente.TabIndex = 30;
            this.labelCliente.Text = "Cliente :";
            // 
            // tarjetaTextBox
            // 
            this.tarjetaTextBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tarjetaTextBox.Enabled = false;
            this.tarjetaTextBox.Location = new System.Drawing.Point(112, 138);
            this.tarjetaTextBox.Name = "tarjetaTextBox";
            this.tarjetaTextBox.Size = new System.Drawing.Size(127, 20);
            this.tarjetaTextBox.TabIndex = 33;
            // 
            // errorTipoDePago
            // 
            this.errorTipoDePago.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorTipoDePago.ContainerControl = this;
            // 
            // errorMonto
            // 
            this.errorMonto.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorMonto.ContainerControl = this;
            // 
            // errorTarjeta
            // 
            this.errorTarjeta.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorTarjeta.ContainerControl = this;
            // 
            // errorCliente
            // 
            this.errorCliente.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorCliente.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 275);
            this.Controls.Add(this.tarjetaTextBox);
            this.Controls.Add(this.seleccionarCliente);
            this.Controls.Add(this.cliente);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.nuevaTarjeta);
            this.Controls.Add(this.cargarCredito);
            this.Controls.Add(this.tipoDePago);
            this.Controls.Add(this.monto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Carga de Credito";
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.monto, 0);
            this.Controls.SetChildIndex(this.tipoDePago, 0);
            this.Controls.SetChildIndex(this.cargarCredito, 0);
            this.Controls.SetChildIndex(this.nuevaTarjeta, 0);
            this.Controls.SetChildIndex(this.labelCliente, 0);
            this.Controls.SetChildIndex(this.cliente, 0);
            this.Controls.SetChildIndex(this.seleccionarCliente, 0);
            this.Controls.SetChildIndex(this.tarjetaTextBox, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorTipoDePago)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorMonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorTarjeta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox monto;
        private System.Windows.Forms.ComboBox tipoDePago;
        private System.Windows.Forms.Button cargarCredito;
        private System.Windows.Forms.Button nuevaTarjeta;
        private System.Windows.Forms.Button seleccionarCliente;
        public System.Windows.Forms.TextBox cliente;
        private System.Windows.Forms.Label labelCliente;
        public System.Windows.Forms.TextBox tarjetaTextBox;
        private System.Windows.Forms.ErrorProvider errorTipoDePago;
        private System.Windows.Forms.ErrorProvider errorMonto;
        private System.Windows.Forms.ErrorProvider errorTarjeta;
        private System.Windows.Forms.ErrorProvider errorCliente;
    }
}