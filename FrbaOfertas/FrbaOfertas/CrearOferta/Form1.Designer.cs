namespace FrbaOfertas.CrearOferta
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelProveedor = new System.Windows.Forms.Label();
            this.descripcion = new System.Windows.Forms.TextBox();
            this.fechaPublicacion = new System.Windows.Forms.DateTimePicker();
            this.fechaVencimiento = new System.Windows.Forms.DateTimePicker();
            this.precio = new System.Windows.Forms.TextBox();
            this.descuento = new System.Windows.Forms.TextBox();
            this.stock = new System.Windows.Forms.TextBox();
            this.restriccion = new System.Windows.Forms.TextBox();
            this.proveedor = new System.Windows.Forms.TextBox();
            this.crear = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.seleccionarProveedor = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.validezCupon = new System.Windows.Forms.TextBox();
            this.errorDescripcion = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorFechaPublicacion = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorFechaVencimiento = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorPrecio = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorDescuento = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorStock = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorRestriccionUnidades = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorTiempoCupon = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProveedor = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorDescripcion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorFechaPublicacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorFechaVencimiento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDescuento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorRestriccionUnidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorTiempoCupon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Descripcion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha de publicacion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha de vencimiento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Precio de lista";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(270, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Descuento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Stock disponible";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Restriccion unidades";
            // 
            // labelProveedor
            // 
            this.labelProveedor.AutoSize = true;
            this.labelProveedor.Location = new System.Drawing.Point(42, 291);
            this.labelProveedor.Name = "labelProveedor";
            this.labelProveedor.Size = new System.Drawing.Size(56, 13);
            this.labelProveedor.TabIndex = 8;
            this.labelProveedor.Text = "Proveedor";
            // 
            // descripcion
            // 
            this.descripcion.Location = new System.Drawing.Point(166, 50);
            this.descripcion.Name = "descripcion";
            this.descripcion.Size = new System.Drawing.Size(142, 20);
            this.descripcion.TabIndex = 9;
            // 
            // fechaPublicacion
            // 
            this.fechaPublicacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaPublicacion.Location = new System.Drawing.Point(166, 84);
            this.fechaPublicacion.Name = "fechaPublicacion";
            this.fechaPublicacion.Size = new System.Drawing.Size(142, 20);
            this.fechaPublicacion.TabIndex = 10;
            // 
            // fechaVencimiento
            // 
            this.fechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.fechaVencimiento.Location = new System.Drawing.Point(166, 115);
            this.fechaVencimiento.Name = "fechaVencimiento";
            this.fechaVencimiento.Size = new System.Drawing.Size(142, 20);
            this.fechaVencimiento.TabIndex = 11;
            // 
            // precio
            // 
            this.precio.Location = new System.Drawing.Point(147, 152);
            this.precio.Name = "precio";
            this.precio.Size = new System.Drawing.Size(99, 20);
            this.precio.TabIndex = 12;
            // 
            // descuento
            // 
            this.descuento.Location = new System.Drawing.Point(335, 151);
            this.descuento.Name = "descuento";
            this.descuento.Size = new System.Drawing.Size(64, 20);
            this.descuento.TabIndex = 13;
            // 
            // stock
            // 
            this.stock.Location = new System.Drawing.Point(147, 187);
            this.stock.Name = "stock";
            this.stock.Size = new System.Drawing.Size(99, 20);
            this.stock.TabIndex = 14;
            // 
            // restriccion
            // 
            this.restriccion.Location = new System.Drawing.Point(147, 221);
            this.restriccion.Name = "restriccion";
            this.restriccion.Size = new System.Drawing.Size(99, 20);
            this.restriccion.TabIndex = 15;
            // 
            // proveedor
            // 
            this.proveedor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.proveedor.Enabled = false;
            this.proveedor.Location = new System.Drawing.Point(104, 288);
            this.proveedor.Name = "proveedor";
            this.proveedor.Size = new System.Drawing.Size(242, 20);
            this.proveedor.TabIndex = 16;
            // 
            // crear
            // 
            this.crear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.crear.BackColor = System.Drawing.Color.SandyBrown;
            this.crear.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.crear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.crear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.crear.ForeColor = System.Drawing.SystemColors.InfoText;
            this.crear.Location = new System.Drawing.Point(329, 325);
            this.crear.Name = "crear";
            this.crear.Size = new System.Drawing.Size(98, 33);
            this.crear.TabIndex = 17;
            this.crear.Text = "Crear";
            this.crear.UseVisualStyleBackColor = false;
            this.crear.Click += new System.EventHandler(this.crear_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(405, 154);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "%";
            // 
            // seleccionarProveedor
            // 
            this.seleccionarProveedor.BackColor = System.Drawing.Color.SandyBrown;
            this.seleccionarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seleccionarProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seleccionarProveedor.Location = new System.Drawing.Point(352, 286);
            this.seleccionarProveedor.Name = "seleccionarProveedor";
            this.seleccionarProveedor.Size = new System.Drawing.Size(75, 23);
            this.seleccionarProveedor.TabIndex = 19;
            this.seleccionarProveedor.Text = "Seleccionar";
            this.seleccionarProveedor.UseVisualStyleBackColor = false;
            this.seleccionarProveedor.Click += new System.EventHandler(this.seleccionarProveedor_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(36, 259);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Tiempo validez cupon";
            // 
            // validezCupon
            // 
            this.validezCupon.Location = new System.Drawing.Point(148, 256);
            this.validezCupon.Name = "validezCupon";
            this.validezCupon.Size = new System.Drawing.Size(100, 20);
            this.validezCupon.TabIndex = 21;
            // 
            // errorDescripcion
            // 
            this.errorDescripcion.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorDescripcion.ContainerControl = this;
            // 
            // errorFechaPublicacion
            // 
            this.errorFechaPublicacion.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorFechaPublicacion.ContainerControl = this;
            // 
            // errorFechaVencimiento
            // 
            this.errorFechaVencimiento.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorFechaVencimiento.ContainerControl = this;
            // 
            // errorPrecio
            // 
            this.errorPrecio.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorPrecio.ContainerControl = this;
            // 
            // errorDescuento
            // 
            this.errorDescuento.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorDescuento.ContainerControl = this;
            // 
            // errorStock
            // 
            this.errorStock.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorStock.ContainerControl = this;
            // 
            // errorRestriccionUnidades
            // 
            this.errorRestriccionUnidades.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorRestriccionUnidades.ContainerControl = this;
            // 
            // errorTiempoCupon
            // 
            this.errorTiempoCupon.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorTiempoCupon.ContainerControl = this;
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
            this.ClientSize = new System.Drawing.Size(448, 370);
            this.Controls.Add(this.validezCupon);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.seleccionarProveedor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.crear);
            this.Controls.Add(this.proveedor);
            this.Controls.Add(this.restriccion);
            this.Controls.Add(this.stock);
            this.Controls.Add(this.descuento);
            this.Controls.Add(this.precio);
            this.Controls.Add(this.fechaVencimiento);
            this.Controls.Add(this.fechaPublicacion);
            this.Controls.Add(this.descripcion);
            this.Controls.Add(this.labelProveedor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Confeccion de Oferta";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.labelProveedor, 0);
            this.Controls.SetChildIndex(this.descripcion, 0);
            this.Controls.SetChildIndex(this.fechaPublicacion, 0);
            this.Controls.SetChildIndex(this.fechaVencimiento, 0);
            this.Controls.SetChildIndex(this.precio, 0);
            this.Controls.SetChildIndex(this.descuento, 0);
            this.Controls.SetChildIndex(this.stock, 0);
            this.Controls.SetChildIndex(this.restriccion, 0);
            this.Controls.SetChildIndex(this.proveedor, 0);
            this.Controls.SetChildIndex(this.crear, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.seleccionarProveedor, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.validezCupon, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorDescripcion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorFechaPublicacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorFechaVencimiento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDescuento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorRestriccionUnidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorTiempoCupon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelProveedor;
        private System.Windows.Forms.TextBox descripcion;
        private System.Windows.Forms.DateTimePicker fechaPublicacion;
        private System.Windows.Forms.DateTimePicker fechaVencimiento;
        private System.Windows.Forms.TextBox precio;
        private System.Windows.Forms.TextBox descuento;
        private System.Windows.Forms.TextBox stock;
        private System.Windows.Forms.TextBox restriccion;
        private System.Windows.Forms.Button crear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button seleccionarProveedor;
        public System.Windows.Forms.TextBox proveedor;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox validezCupon;
        private System.Windows.Forms.ErrorProvider errorDescripcion;
        private System.Windows.Forms.ErrorProvider errorFechaPublicacion;
        private System.Windows.Forms.ErrorProvider errorFechaVencimiento;
        private System.Windows.Forms.ErrorProvider errorPrecio;
        private System.Windows.Forms.ErrorProvider errorDescuento;
        private System.Windows.Forms.ErrorProvider errorStock;
        private System.Windows.Forms.ErrorProvider errorRestriccionUnidades;
        private System.Windows.Forms.ErrorProvider errorTiempoCupon;
        private System.Windows.Forms.ErrorProvider errorProveedor;
    }
}