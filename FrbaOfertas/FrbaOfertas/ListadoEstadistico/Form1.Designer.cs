namespace FrbaOfertas.ListadoEstadistico
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
            this.buscar = new System.Windows.Forms.Button();
            this.limpiar = new System.Windows.Forms.Button();
            this.tablaDeResultados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tipoDeListado = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.anio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.semestre = new System.Windows.Forms.ComboBox();
            this.errorListado = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorSemestre = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorSemestre)).BeginInit();
            this.SuspendLayout();
            // 
            // buscar
            // 
            this.buscar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buscar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buscar.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.buscar.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buscar.ForeColor = System.Drawing.SystemColors.InfoText;
            this.buscar.Location = new System.Drawing.Point(622, 141);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(113, 30);
            this.buscar.TabIndex = 5;
            this.buscar.Text = "Estadistica";
            this.buscar.UseVisualStyleBackColor = false;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // limpiar
            // 
            this.limpiar.Location = new System.Drawing.Point(15, 144);
            this.limpiar.Name = "limpiar";
            this.limpiar.Size = new System.Drawing.Size(72, 23);
            this.limpiar.TabIndex = 4;
            this.limpiar.Text = "Limpiar";
            this.limpiar.UseVisualStyleBackColor = true;
            this.limpiar.Click += new System.EventHandler(this.limpiar_Click);
            // 
            // tablaDeResultados
            // 
            this.tablaDeResultados.AllowUserToAddRows = false;
            this.tablaDeResultados.AllowUserToDeleteRows = false;
            this.tablaDeResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tablaDeResultados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.tablaDeResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tablaDeResultados.Location = new System.Drawing.Point(12, 177);
            this.tablaDeResultados.Name = "tablaDeResultados";
            this.tablaDeResultados.ReadOnly = true;
            this.tablaDeResultados.Size = new System.Drawing.Size(723, 229);
            this.tablaDeResultados.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Tipo de listado";
            // 
            // tipoDeListado
            // 
            this.tipoDeListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoDeListado.FormattingEnabled = true;
            this.tipoDeListado.Items.AddRange(new object[] {
            "Proveedores con mayor descuento",
            "Proveedores con mayor facturacion"});
            this.tipoDeListado.Location = new System.Drawing.Point(143, 50);
            this.tipoDeListado.Name = "tipoDeListado";
            this.tipoDeListado.Size = new System.Drawing.Size(274, 21);
            this.tipoDeListado.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Año";
            // 
            // anio
            // 
            this.anio.Location = new System.Drawing.Point(93, 91);
            this.anio.Name = "anio";
            this.anio.Size = new System.Drawing.Size(121, 20);
            this.anio.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(241, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Semestre";
            // 
            // semestre
            // 
            this.semestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.semestre.FormattingEnabled = true;
            this.semestre.Items.AddRange(new object[] {
            "1",
            "2"});
            this.semestre.Location = new System.Drawing.Point(298, 91);
            this.semestre.Name = "semestre";
            this.semestre.Size = new System.Drawing.Size(119, 21);
            this.semestre.TabIndex = 11;
            // 
            // errorListado
            // 
            this.errorListado.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorListado.ContainerControl = this;
            // 
            // errorSemestre
            // 
            this.errorSemestre.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorSemestre.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 438);
            this.Controls.Add(this.semestre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.anio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tipoDeListado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buscar);
            this.Controls.Add(this.limpiar);
            this.Controls.Add(this.tablaDeResultados);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.tablaDeResultados, 0);
            this.Controls.SetChildIndex(this.limpiar, 0);
            this.Controls.SetChildIndex(this.buscar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tipoDeListado, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.anio, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.semestre, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tablaDeResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorSemestre)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button limpiar;
        private System.Windows.Forms.DataGridView tablaDeResultados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox tipoDeListado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker anio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox semestre;
        private System.Windows.Forms.ErrorProvider errorListado;
        private System.Windows.Forms.ErrorProvider errorSemestre;
    }
}