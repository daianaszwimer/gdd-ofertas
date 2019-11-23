namespace FrbaOfertas.BajaYModificacionUsuario
{
    partial class Modificacion
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
            this.label3 = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordNueva = new System.Windows.Forms.TextBox();
            this.confirmar = new System.Windows.Forms.Button();
            this.errorPassword = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorPassword)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre de usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nueva Contraseña";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Enabled = false;
            this.usernameTextBox.Location = new System.Drawing.Point(125, 42);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(118, 20);
            this.usernameTextBox.TabIndex = 3;
            // 
            // passwordNueva
            // 
            this.passwordNueva.Location = new System.Drawing.Point(125, 75);
            this.passwordNueva.Name = "passwordNueva";
            this.passwordNueva.Size = new System.Drawing.Size(118, 20);
            this.passwordNueva.TabIndex = 5;
            // 
            // confirmar
            // 
            this.confirmar.Location = new System.Drawing.Point(168, 109);
            this.confirmar.Name = "confirmar";
            this.confirmar.Size = new System.Drawing.Size(75, 23);
            this.confirmar.TabIndex = 6;
            this.confirmar.Text = "Confirmar";
            this.confirmar.UseVisualStyleBackColor = true;
            this.confirmar.Click += new System.EventHandler(this.confirmar_Click);
            // 
            // errorPassword
            // 
            this.errorPassword.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorPassword.ContainerControl = this;
            // 
            // Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 152);
            this.Controls.Add(this.confirmar);
            this.Controls.Add(this.passwordNueva);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Modificacion";
            this.Text = "Modificacion";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.usernameTextBox, 0);
            this.Controls.SetChildIndex(this.passwordNueva, 0);
            this.Controls.SetChildIndex(this.confirmar, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorPassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordNueva;
        private System.Windows.Forms.Button confirmar;
        private System.Windows.Forms.ErrorProvider errorPassword;
    }
}