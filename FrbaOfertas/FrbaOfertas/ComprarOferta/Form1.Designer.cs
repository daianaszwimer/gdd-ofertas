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
            this.buscar = new System.Windows.Forms.Button();
            this.comprar = new System.Windows.Forms.Button();
            this.descripcionOferta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.unidadDeOferta = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.unidadDeOferta)).BeginInit();
            this.SuspendLayout();
            // 
            // buscar
            // 
            this.buscar.Location = new System.Drawing.Point(364, 118);
            this.buscar.Name = "buscar";
            this.buscar.Size = new System.Drawing.Size(75, 23);
            this.buscar.TabIndex = 3;
            this.buscar.Text = "Buscar ";
            this.buscar.UseVisualStyleBackColor = true;
            this.buscar.Click += new System.EventHandler(this.buscar_Click);
            // 
            // comprar
            // 
            this.comprar.Location = new System.Drawing.Point(321, 230);
            this.comprar.Name = "comprar";
            this.comprar.Size = new System.Drawing.Size(118, 22);
            this.comprar.TabIndex = 4;
            this.comprar.Text = "Comprar";
            this.comprar.UseVisualStyleBackColor = true;
            this.comprar.Click += new System.EventHandler(this.comprar_Click);
            // 
            // descripcionOferta
            // 
            this.descripcionOferta.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.descripcionOferta.Location = new System.Drawing.Point(49, 120);
            this.descripcionOferta.Name = "descripcionOferta";
            this.descripcionOferta.Size = new System.Drawing.Size(309, 20);
            this.descripcionOferta.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Seleccionar oferta :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cantidad:";
            // 
            // unidadDeOferta
            // 
            this.unidadDeOferta.Location = new System.Drawing.Point(107, 154);
            this.unidadDeOferta.Name = "unidadDeOferta";
            this.unidadDeOferta.Size = new System.Drawing.Size(52, 20);
            this.unidadDeOferta.TabIndex = 10;
            this.unidadDeOferta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 312);
            this.Controls.Add(this.unidadDeOferta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.descripcionOferta);
            this.Controls.Add(this.comprar);
            this.Controls.Add(this.buscar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.buscar, 0);
            this.Controls.SetChildIndex(this.comprar, 0);
            this.Controls.SetChildIndex(this.descripcionOferta, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.unidadDeOferta, 0);
            ((System.ComponentModel.ISupportInitialize)(this.unidadDeOferta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buscar;
        private System.Windows.Forms.Button comprar;
        private System.Windows.Forms.TextBox descripcionOferta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown unidadDeOferta;
    }
}