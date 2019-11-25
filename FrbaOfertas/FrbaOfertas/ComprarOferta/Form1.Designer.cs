namespace FrbaOfertas.ComprarOferta
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
            this.seleccionarOferta = new System.Windows.Forms.Button();
            this.comprar = new System.Windows.Forms.Button();
            this.descripcionOferta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.unidadDeOferta = new System.Windows.Forms.NumericUpDown();
            this.seleccionarCliente = new System.Windows.Forms.Button();
            this.cliente = new System.Windows.Forms.TextBox();
            this.labelCliente = new System.Windows.Forms.Label();
            this.errorCliente = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorOferta = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorCantidad = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.unidadDeOferta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorOferta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // seleccionarOferta
            // 
            this.seleccionarOferta.BackColor = System.Drawing.Color.SandyBrown;
            this.seleccionarOferta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seleccionarOferta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seleccionarOferta.Location = new System.Drawing.Point(335, 90);
            this.seleccionarOferta.Name = "seleccionarOferta";
            this.seleccionarOferta.Size = new System.Drawing.Size(79, 23);
            this.seleccionarOferta.TabIndex = 3;
            this.seleccionarOferta.Text = "Seleccionar";
            this.seleccionarOferta.UseVisualStyleBackColor = false;
            this.seleccionarOferta.Click += new System.EventHandler(this.seleccionarOferta_Click);
            // 
            // comprar
            // 
            this.comprar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comprar.BackColor = System.Drawing.Color.SandyBrown;
            this.comprar.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.comprar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comprar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comprar.ForeColor = System.Drawing.SystemColors.InfoText;
            this.comprar.Location = new System.Drawing.Point(296, 144);
            this.comprar.Name = "comprar";
            this.comprar.Size = new System.Drawing.Size(118, 33);
            this.comprar.TabIndex = 4;
            this.comprar.Text = "Comprar";
            this.comprar.UseVisualStyleBackColor = false;
            this.comprar.Click += new System.EventHandler(this.comprar_Click);
            // 
            // descripcionOferta
            // 
            this.descripcionOferta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.descripcionOferta.Location = new System.Drawing.Point(84, 92);
            this.descripcionOferta.Name = "descripcionOferta";
            this.descripcionOferta.Size = new System.Drawing.Size(218, 20);
            this.descripcionOferta.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Oferta :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cantidad:";
            // 
            // unidadDeOferta
            // 
            this.unidadDeOferta.Location = new System.Drawing.Point(84, 131);
            this.unidadDeOferta.Name = "unidadDeOferta";
            this.unidadDeOferta.Size = new System.Drawing.Size(52, 20);
            this.unidadDeOferta.TabIndex = 10;
            this.unidadDeOferta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // seleccionarCliente
            // 
            this.seleccionarCliente.BackColor = System.Drawing.Color.SandyBrown;
            this.seleccionarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seleccionarCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seleccionarCliente.Location = new System.Drawing.Point(335, 53);
            this.seleccionarCliente.Name = "seleccionarCliente";
            this.seleccionarCliente.Size = new System.Drawing.Size(79, 23);
            this.seleccionarCliente.TabIndex = 29;
            this.seleccionarCliente.Text = "Seleccionar";
            this.seleccionarCliente.UseVisualStyleBackColor = false;
            this.seleccionarCliente.Click += new System.EventHandler(this.seleccionarCliente_Click);
            // 
            // cliente
            // 
            this.cliente.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.cliente.Location = new System.Drawing.Point(84, 55);
            this.cliente.Name = "cliente";
            this.cliente.Size = new System.Drawing.Size(218, 20);
            this.cliente.TabIndex = 28;
            // 
            // labelCliente
            // 
            this.labelCliente.AutoSize = true;
            this.labelCliente.Location = new System.Drawing.Point(33, 58);
            this.labelCliente.Name = "labelCliente";
            this.labelCliente.Size = new System.Drawing.Size(45, 13);
            this.labelCliente.TabIndex = 27;
            this.labelCliente.Text = "Cliente :";
            // 
            // errorCliente
            // 
            this.errorCliente.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorCliente.ContainerControl = this;
            // 
            // errorOferta
            // 
            this.errorOferta.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorOferta.ContainerControl = this;
            // 
            // errorCantidad
            // 
            this.errorCantidad.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorCantidad.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 198);
            this.Controls.Add(this.seleccionarCliente);
            this.Controls.Add(this.cliente);
            this.Controls.Add(this.labelCliente);
            this.Controls.Add(this.unidadDeOferta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.descripcionOferta);
            this.Controls.Add(this.comprar);
            this.Controls.Add(this.seleccionarOferta);
            this.Name = "Form1";
            this.Text = "Compra de oferta";
            this.Controls.SetChildIndex(this.seleccionarOferta, 0);
            this.Controls.SetChildIndex(this.comprar, 0);
            this.Controls.SetChildIndex(this.descripcionOferta, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.unidadDeOferta, 0);
            this.Controls.SetChildIndex(this.labelCliente, 0);
            this.Controls.SetChildIndex(this.cliente, 0);
            this.Controls.SetChildIndex(this.seleccionarCliente, 0);
            ((System.ComponentModel.ISupportInitialize)(this.unidadDeOferta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorOferta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button seleccionarOferta;
        private System.Windows.Forms.Button comprar;
        private System.Windows.Forms.TextBox descripcionOferta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown unidadDeOferta;
        private System.Windows.Forms.Button seleccionarCliente;
        public System.Windows.Forms.TextBox cliente;
        private System.Windows.Forms.Label labelCliente;
        private System.Windows.Forms.ErrorProvider errorCliente;
        private System.Windows.Forms.ErrorProvider errorOferta;
        private System.Windows.Forms.ErrorProvider errorCantidad;
    }
}