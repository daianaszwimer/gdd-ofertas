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
            this.proveedor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.desde = new System.Windows.Forms.DateTimePicker();
            this.hasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tablaDeResultados = new System.Windows.Forms.DataGridView();
            this.facturar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // proveedor
            // 
            this.proveedor.FormattingEnabled = true;
            this.proveedor.Location = new System.Drawing.Point(28, 50);
            this.proveedor.Name = "proveedor";
            this.proveedor.Size = new System.Drawing.Size(121, 21);
            this.proveedor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Proveedor";
            // 
            // desde
            // 
            this.desde.Location = new System.Drawing.Point(69, 101);
            this.desde.Name = "desde";
            this.desde.Size = new System.Drawing.Size(121, 20);
            this.desde.TabIndex = 10;
            // 
            // hasta
            // 
            this.hasta.Location = new System.Drawing.Point(240, 101);
            this.hasta.Name = "hasta";
            this.hasta.Size = new System.Drawing.Size(121, 20);
            this.hasta.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(237, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Hasta";
            // 
            // tablaDeResultados
            // 
            this.tablaDeResultados.AllowUserToAddRows = false;
            this.tablaDeResultados.AllowUserToDeleteRows = false;
            this.tablaDeResultados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.tablaDeResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDeResultados.Location = new System.Drawing.Point(30, 244);
            this.tablaDeResultados.Name = "tablaDeResultados";
            this.tablaDeResultados.ReadOnly = true;
            this.tablaDeResultados.Size = new System.Drawing.Size(416, 191);
            this.tablaDeResultados.TabIndex = 14;
            // 
            // facturar
            // 
            this.facturar.Location = new System.Drawing.Point(369, 155);
            this.facturar.Name = "facturar";
            this.facturar.Size = new System.Drawing.Size(75, 23);
            this.facturar.TabIndex = 16;
            this.facturar.Text = "Facturar";
            this.facturar.UseVisualStyleBackColor = true;
            this.facturar.Click += new System.EventHandler(this.facturar_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(28, 155);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(72, 23);
            this.limpiar.TabIndex = 15;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(30, 218);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 462);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.facturar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.tablaDeResultados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hasta);
            this.Controls.Add(this.desde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.proveedor);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.proveedor, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.desde, 0);
            this.Controls.SetChildIndex(this.hasta, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tablaDeResultados, 0);
            this.Controls.SetChildIndex(this.limpiar, 0);
            this.Controls.SetChildIndex(this.facturar, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox proveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker desde;
        private System.Windows.Forms.DateTimePicker hasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView tablaDeResultados;
        private System.Windows.Forms.Button facturar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.TextBox textBox1;
    }
}