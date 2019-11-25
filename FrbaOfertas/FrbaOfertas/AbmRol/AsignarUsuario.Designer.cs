namespace FrbaOfertas.AbmRol
{
    partial class AsignarUsuario
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
            this.descripcionRol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.TextBox();
            this.seleccionar = new System.Windows.Forms.Button();
            this.nuevo = new System.Windows.Forms.Button();
            this.asignar = new System.Windows.Forms.Button();
            this.errorUsuario = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rol";
            // 
            // descripcionRol
            // 
            this.descripcionRol.Enabled = false;
            this.descripcionRol.Location = new System.Drawing.Point(83, 42);
            this.descripcionRol.Name = "descripcionRol";
            this.descripcionRol.Size = new System.Drawing.Size(139, 20);
            this.descripcionRol.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Usuario";
            // 
            // usuario
            // 
            this.usuario.Enabled = false;
            this.usuario.Location = new System.Drawing.Point(83, 77);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(139, 20);
            this.usuario.TabIndex = 3;
            // 
            // seleccionar
            // 
            this.seleccionar.Location = new System.Drawing.Point(83, 103);
            this.seleccionar.Name = "seleccionar";
            this.seleccionar.Size = new System.Drawing.Size(79, 23);
            this.seleccionar.TabIndex = 4;
            this.seleccionar.Text = "Seleccionar";
            this.seleccionar.UseVisualStyleBackColor = true;
            this.seleccionar.Click += new System.EventHandler(this.seleccionar_Click);
            // 
            // nuevo
            // 
            this.nuevo.Location = new System.Drawing.Point(168, 103);
            this.nuevo.Name = "nuevo";
            this.nuevo.Size = new System.Drawing.Size(54, 23);
            this.nuevo.TabIndex = 5;
            this.nuevo.Text = "Nuevo";
            this.nuevo.UseVisualStyleBackColor = true;
            this.nuevo.Click += new System.EventHandler(this.nuevo_Click);
            // 
            // asignar
            // 
            this.asignar.Location = new System.Drawing.Point(147, 145);
            this.asignar.Name = "asignar";
            this.asignar.Size = new System.Drawing.Size(75, 23);
            this.asignar.TabIndex = 6;
            this.asignar.Text = "Asignar";
            this.asignar.UseVisualStyleBackColor = true;
            this.asignar.Click += new System.EventHandler(this.asignar_Click);
            // 
            // errorUsuario
            // 
            this.errorUsuario.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorUsuario.ContainerControl = this;
            // 
            // AsignarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 189);
            this.Controls.Add(this.asignar);
            this.Controls.Add(this.nuevo);
            this.Controls.Add(this.seleccionar);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.descripcionRol);
            this.Controls.Add(this.label1);
            this.Name = "AsignarUsuario";
            this.Text = "AsignarUsuario";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.descripcionRol, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.usuario, 0);
            this.Controls.SetChildIndex(this.seleccionar, 0);
            this.Controls.SetChildIndex(this.nuevo, 0);
            this.Controls.SetChildIndex(this.asignar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox descripcionRol;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.Button seleccionar;
        private System.Windows.Forms.Button nuevo;
        private System.Windows.Forms.Button asignar;
        private System.Windows.Forms.ErrorProvider errorUsuario;
    }
}