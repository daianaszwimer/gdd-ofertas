namespace FrbaOfertas.Facturar
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
            this.label1 = new System.Windows.Forms.Label();
            this.desde = new System.Windows.Forms.DateTimePicker();
            this.hasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tablaDeResultados = new System.Windows.Forms.DataGridView();
            this.facturar = new System.Windows.Forms.Button();
            this.nroFactura = new System.Windows.Forms.TextBox();
            this.proveedor = new System.Windows.Forms.TextBox();
            this.seleccionar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.montoFactura = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.errorProveedor = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeResultados)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Proveedor";
            // 
            // desde
            // 
            this.desde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.desde.Location = new System.Drawing.Point(34, 105);
            this.desde.Name = "desde";
            this.desde.Size = new System.Drawing.Size(100, 20);
            this.desde.TabIndex = 10;
            this.desde.Value = new System.DateTime(2019, 11, 20, 0, 0, 0, 0);
            // 
            // hasta
            // 
            this.hasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.hasta.Location = new System.Drawing.Point(189, 105);
            this.hasta.Name = "hasta";
            this.hasta.Size = new System.Drawing.Size(98, 20);
            this.hasta.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(186, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Hasta";
            // 
            // tablaDeResultados
            // 
            this.tablaDeResultados.AllowUserToAddRows = false;
            this.tablaDeResultados.AllowUserToDeleteRows = false;
            this.tablaDeResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaDeResultados.BackgroundColor = System.Drawing.Color.Beige;
            this.tablaDeResultados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.tablaDeResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDeResultados.Location = new System.Drawing.Point(16, 54);
            this.tablaDeResultados.Name = "tablaDeResultados";
            this.tablaDeResultados.ReadOnly = true;
            this.tablaDeResultados.Size = new System.Drawing.Size(677, 191);
            this.tablaDeResultados.TabIndex = 14;
            // 
            // facturar
            // 
            this.facturar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.facturar.BackColor = System.Drawing.Color.SandyBrown;
            this.facturar.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.facturar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.facturar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.facturar.ForeColor = System.Drawing.SystemColors.InfoText;
            this.facturar.Location = new System.Drawing.Point(618, 105);
            this.facturar.Name = "facturar";
            this.facturar.Size = new System.Drawing.Size(114, 32);
            this.facturar.TabIndex = 16;
            this.facturar.Text = "Facturar";
            this.facturar.UseVisualStyleBackColor = false;
            this.facturar.Click += new System.EventHandler(this.facturar_Click);
            // 
            // nroFactura
            // 
            this.nroFactura.BackColor = System.Drawing.SystemColors.ControlDark;
            this.nroFactura.Location = new System.Drawing.Point(16, 28);
            this.nroFactura.Name = "nroFactura";
            this.nroFactura.Size = new System.Drawing.Size(100, 20);
            this.nroFactura.TabIndex = 17;
            // 
            // proveedor
            // 
            this.proveedor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.proveedor.Location = new System.Drawing.Point(30, 56);
            this.proveedor.Name = "proveedor";
            this.proveedor.Size = new System.Drawing.Size(191, 20);
            this.proveedor.TabIndex = 18;
            // 
            // seleccionar
            // 
            this.seleccionar.BackColor = System.Drawing.Color.SandyBrown;
            this.seleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seleccionar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seleccionar.Location = new System.Drawing.Point(247, 54);
            this.seleccionar.Name = "seleccionar";
            this.seleccionar.Size = new System.Drawing.Size(75, 23);
            this.seleccionar.TabIndex = 19;
            this.seleccionar.Text = "Seleccionar";
            this.seleccionar.UseVisualStyleBackColor = false;
            this.seleccionar.Click += new System.EventHandler(this.seleccionar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Nro Factura";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "Monto";
            // 
            // montoFactura
            // 
            this.montoFactura.BackColor = System.Drawing.SystemColors.ControlDark;
            this.montoFactura.Location = new System.Drawing.Point(132, 28);
            this.montoFactura.Name = "montoFactura";
            this.montoFactura.Size = new System.Drawing.Size(100, 20);
            this.montoFactura.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.SandyBrown;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tablaDeResultados);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.nroFactura);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.montoFactura);
            this.panel2.Location = new System.Drawing.Point(12, 145);
            this.panel2.Name = "panel2";
            this.panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel2.Size = new System.Drawing.Size(720, 269);
            this.panel2.TabIndex = 24;
            // 
            // errorProveedor
            // 
            this.errorProveedor.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProveedor.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 438);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.seleccionar);
            this.Controls.Add(this.proveedor);
            this.Controls.Add(this.facturar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hasta);
            this.Controls.Add(this.desde);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Facturar a Proveedor";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.desde, 0);
            this.Controls.SetChildIndex(this.hasta, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.facturar, 0);
            this.Controls.SetChildIndex(this.proveedor, 0);
            this.Controls.SetChildIndex(this.seleccionar, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeResultados)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker desde;
        private System.Windows.Forms.DateTimePicker hasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView tablaDeResultados;
        private System.Windows.Forms.Button facturar;
        private System.Windows.Forms.TextBox nroFactura;
        private System.Windows.Forms.TextBox proveedor;
        private System.Windows.Forms.Button seleccionar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox montoFactura;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ErrorProvider errorProveedor;

    }
}