namespace FrbaOfertas.EntregaDeOferta
{
    partial class ListadoCupon
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
            this.tablaDeResultados = new System.Windows.Forms.DataGridView();
            this.confirm = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buscar = new System.Windows.Forms.Button();
            this.codigoCupon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // tablaDeResultados
            // 
            this.tablaDeResultados.AllowUserToAddRows = false;
            this.tablaDeResultados.AllowUserToDeleteRows = false;
            this.tablaDeResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaDeResultados.BackgroundColor = System.Drawing.Color.Beige;
            this.tablaDeResultados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.tablaDeResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDeResultados.Location = new System.Drawing.Point(20, 114);
            this.tablaDeResultados.Name = "tablaDeResultados";
            this.tablaDeResultados.ReadOnly = true;
            this.tablaDeResultados.Size = new System.Drawing.Size(240, 156);
            this.tablaDeResultados.TabIndex = 4;
            // 
            // confirm
            // 
            this.confirm.BackColor = System.Drawing.Color.SandyBrown;
            this.confirm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.confirm.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirm.Location = new System.Drawing.Point(185, 276);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(75, 23);
            this.confirm.TabIndex = 7;
            this.confirm.Text = "Confirmar";
            this.confirm.UseVisualStyleBackColor = false;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(20, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 20);
            this.textBox1.TabIndex = 8;
            // 
            // buscar
            // 
            this.buscar.BackColor = System.Drawing.Color.SandyBrown;
            this.buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar.Location = new System.Drawing.Point(185, 72);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(75, 23);
            this.buscar.TabIndex = 9;
            this.buscar.Text = "Buscar";
            this.buscar.UseVisualStyleBackColor = false;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // codigoCupon
            // 
            this.codigoCupon.AutoSize = true;
            this.codigoCupon.Location = new System.Drawing.Point(17, 59);
            this.codigoCupon.Name = "codigoCupon";
            this.codigoCupon.Size = new System.Drawing.Size(73, 13);
            this.codigoCupon.TabIndex = 10;
            this.codigoCupon.Text = "Codigo cupon";
            // 
            // ListadoCupon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 311);
            this.Controls.Add(this.codigoCupon);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.tablaDeResultados);
            this.Name = "ListadoCupon";
            this.Text = "Listado Cupon";
            this.Controls.SetChildIndex(this.tablaDeResultados, 0);
            this.Controls.SetChildIndex(this.buscar, 0);
            this.Controls.SetChildIndex(this.confirm, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.codigoCupon, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeResultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tablaDeResultados;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Label codigoCupon;
    }
}