namespace FrbaOfertas.ComprarOferta
{
    partial class ListadoClientes
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
            this.confirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // eliminar
            // 
            this.eliminar.Location = new System.Drawing.Point(391, 339);
            // 
            // modificar
            // 
            this.modificar.Location = new System.Drawing.Point(310, 340);
            // 
            // confirmar
            // 
            this.confirmar.Location = new System.Drawing.Point(472, 340);
            this.confirmar.Name = "confirmar";
            this.confirmar.Size = new System.Drawing.Size(75, 23);
            this.confirmar.TabIndex = 20;
            this.confirmar.Text = "Confirmar";
            this.confirmar.UseVisualStyleBackColor = true;
            this.confirmar.Click += new System.EventHandler(this.confirmar_Click);
            // 
            // ListadoClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 375);
            this.Controls.Add(this.confirmar);
            this.Name = "ListadoClientes";
            this.Text = "ListadoClientes";
            this.Controls.SetChildIndex(this.modificar, 0);
            this.Controls.SetChildIndex(this.eliminar, 0);
            this.Controls.SetChildIndex(this.confirmar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmar;
    }
}