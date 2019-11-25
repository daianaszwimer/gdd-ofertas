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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bajaCupon = new System.Windows.Forms.Button();
            this.clienteDni = new System.Windows.Forms.TextBox();
            this.codigo = new System.Windows.Forms.TextBox();
            this.seleccionarCupon = new System.Windows.Forms.Button();
            this.errorCodCupon = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorDniCliente = new System.Windows.Forms.ErrorProvider(this.components);
            this.seleccionarProveedor = new System.Windows.Forms.Button();
            this.proveedor = new System.Windows.Forms.TextBox();
            this.labelProveedor = new System.Windows.Forms.Label();
            this.errorProveedor = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorCodCupon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDniCliente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProveedor)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "DNI cliente :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Codigo cupon:";
            // 
            // bajaCupon
            // 
            this.bajaCupon.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bajaCupon.BackColor = System.Drawing.Color.SandyBrown;
            this.bajaCupon.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.bajaCupon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bajaCupon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bajaCupon.ForeColor = System.Drawing.SystemColors.InfoText;
            this.bajaCupon.Location = new System.Drawing.Point(246, 156);
            this.bajaCupon.Name = "bajaCupon";
            this.bajaCupon.Size = new System.Drawing.Size(117, 33);
            this.bajaCupon.TabIndex = 12;
            this.bajaCupon.Text = "DAR DE BAJA";
            this.bajaCupon.UseVisualStyleBackColor = false;
            this.bajaCupon.Click += new System.EventHandler(this.bajaCupon_Click);
            // 
            // clienteDni
            // 
            this.clienteDni.BackColor = System.Drawing.SystemColors.Window;
            this.clienteDni.Location = new System.Drawing.Point(109, 124);
            this.clienteDni.Name = "clienteDni";
            this.clienteDni.Size = new System.Drawing.Size(148, 20);
            this.clienteDni.TabIndex = 21;
            // 
            // codigo
            // 
            this.codigo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.codigo.Location = new System.Drawing.Point(110, 88);
            this.codigo.Name = "codigo";
            this.codigo.Size = new System.Drawing.Size(147, 20);
            this.codigo.TabIndex = 22;
            // 
            // seleccionarCupon
            // 
            this.seleccionarCupon.BackColor = System.Drawing.Color.SandyBrown;
            this.seleccionarCupon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seleccionarCupon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seleccionarCupon.Location = new System.Drawing.Point(284, 86);
            this.seleccionarCupon.Name = "seleccionarCupon";
            this.seleccionarCupon.Size = new System.Drawing.Size(79, 23);
            this.seleccionarCupon.TabIndex = 23;
            this.seleccionarCupon.Text = "Seleccionar";
            this.seleccionarCupon.UseVisualStyleBackColor = false;
            this.seleccionarCupon.Click += new System.EventHandler(this.seleccionarCupon_Click);
            // 
            // errorCodCupon
            // 
            this.errorCodCupon.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorCodCupon.ContainerControl = this;
            // 
            // errorDniCliente
            // 
            this.errorDniCliente.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorDniCliente.ContainerControl = this;
            // 
            // seleccionarProveedor
            // 
            this.seleccionarProveedor.BackColor = System.Drawing.Color.SandyBrown;
            this.seleccionarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.seleccionarProveedor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seleccionarProveedor.Location = new System.Drawing.Point(284, 48);
            this.seleccionarProveedor.Name = "seleccionarProveedor";
            this.seleccionarProveedor.Size = new System.Drawing.Size(79, 23);
            this.seleccionarProveedor.TabIndex = 26;
            this.seleccionarProveedor.Text = "Seleccionar";
            this.seleccionarProveedor.UseVisualStyleBackColor = false;
            this.seleccionarProveedor.Click += new System.EventHandler(this.seleccionarProveedor_Click);
            // 
            // proveedor
            // 
            this.proveedor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.proveedor.Location = new System.Drawing.Point(110, 50);
            this.proveedor.Name = "proveedor";
            this.proveedor.Size = new System.Drawing.Size(147, 20);
            this.proveedor.TabIndex = 25;
            // 
            // labelProveedor
            // 
            this.labelProveedor.AutoSize = true;
            this.labelProveedor.Location = new System.Drawing.Point(44, 57);
            this.labelProveedor.Name = "labelProveedor";
            this.labelProveedor.Size = new System.Drawing.Size(59, 13);
            this.labelProveedor.TabIndex = 24;
            this.labelProveedor.Text = "Proveedor:";
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
            this.ClientSize = new System.Drawing.Size(405, 201);
            this.Controls.Add(this.seleccionarProveedor);
            this.Controls.Add(this.proveedor);
            this.Controls.Add(this.labelProveedor);
            this.Controls.Add(this.seleccionarCupon);
            this.Controls.Add(this.codigo);
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
            this.Controls.SetChildIndex(this.codigo, 0);
            this.Controls.SetChildIndex(this.seleccionarCupon, 0);
            this.Controls.SetChildIndex(this.labelProveedor, 0);
            this.Controls.SetChildIndex(this.proveedor, 0);
            this.Controls.SetChildIndex(this.seleccionarProveedor, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorCodCupon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorDniCliente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProveedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bajaCupon;
        private System.Windows.Forms.TextBox clienteDni;
        private System.Windows.Forms.TextBox codigo;
        private System.Windows.Forms.Button seleccionarCupon;
        private System.Windows.Forms.ErrorProvider errorCodCupon;
        private System.Windows.Forms.ErrorProvider errorDniCliente;
        private System.Windows.Forms.Button seleccionarProveedor;
        public System.Windows.Forms.TextBox proveedor;
        private System.Windows.Forms.Label labelProveedor;
        private System.Windows.Forms.ErrorProvider errorProveedor;
    }
}