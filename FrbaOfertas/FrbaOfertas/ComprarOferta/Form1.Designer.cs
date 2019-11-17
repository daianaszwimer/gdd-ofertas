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
            this.label1 = new System.Windows.Forms.Label();
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
            this.comprar.Location = new System.Drawing.Point(321, 228);
            this.comprar.Name = "comprar";
            this.comprar.Size = new System.Drawing.Size(118, 34);
            this.comprar.TabIndex = 4;
            this.comprar.Text = "Comprar";
            this.comprar.UseVisualStyleBackColor = true;
            this.comprar.Click += new System.EventHandler(this.comprar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(25, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ofertas Disponibles";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // descripcionOferta
            // 
            this.descripcionOferta.BackColor = System.Drawing.SystemColors.Control;
            this.descripcionOferta.Location = new System.Drawing.Point(137, 120);
            this.descripcionOferta.Name = "descripcionOferta";
            this.descripcionOferta.Size = new System.Drawing.Size(221, 20);
            this.descripcionOferta.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Oferta seleccionada:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cantidad:";
            // 
            // unidadDeOferta
            // 
            this.unidadDeOferta.Location = new System.Drawing.Point(137, 153);
            this.unidadDeOferta.Name = "unidadDeOferta";
            this.unidadDeOferta.Size = new System.Drawing.Size(44, 20);
            this.unidadDeOferta.TabIndex = 10;
            this.unidadDeOferta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 297);
            this.Controls.Add(this.unidadDeOferta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.descripcionOferta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comprar);
            this.Controls.Add(this.buscar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Controls.SetChildIndex(this.buscar, 0);
            this.Controls.SetChildIndex(this.comprar, 0);
            this.Controls.SetChildIndex(this.label1, 0);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox descripcionOferta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown unidadDeOferta;
    }
}