namespace FrbaOfertas
{
    partial class RegistrarUsuario
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
            this.label4 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorUsername = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorPassword = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorRol = new System.Windows.Forms.ErrorProvider(this.components);
            this.rol = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorRol)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(164, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Rol Asignado";
            // 
            // password
            // 
            this.password.ForeColor = System.Drawing.SystemColors.InfoText;
            this.password.Location = new System.Drawing.Point(121, 60);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(156, 20);
            this.password.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(121, 21);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(156, 20);
            this.username.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(172, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Username";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(35, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 325);
            this.panel1.TabIndex = 18;
            // 
            // errorUsername
            // 
            this.errorUsername.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorUsername.ContainerControl = this;
            // 
            // errorPassword
            // 
            this.errorPassword.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorPassword.ContainerControl = this;
            // 
            // errorRol
            // 
            this.errorRol.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorRol.ContainerControl = this;
            // 
            // rol
            // 
            this.rol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rol.FormattingEnabled = true;
            this.rol.Location = new System.Drawing.Point(121, 105);
            this.rol.Name = "rol";
            this.rol.Size = new System.Drawing.Size(156, 21);
            this.rol.TabIndex = 19;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.SandyBrown;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.button1.Location = new System.Drawing.Point(121, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 33);
            this.button1.TabIndex = 20;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Beige;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.rol);
            this.panel2.Controls.Add(this.username);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.password);
            this.panel2.Location = new System.Drawing.Point(35, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 175);
            this.panel2.TabIndex = 21;
            // 
            // RegistrarUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(484, 201);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "RegistrarUsuario";
            this.Text = "RegistrarUsuario";
            ((System.ComponentModel.ISupportInitialize)(this.errorUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorRol)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Label label4;
        protected System.Windows.Forms.TextBox password;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox username;
        protected System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ErrorProvider errorUsername;
        private System.Windows.Forms.ErrorProvider errorPassword;
        private System.Windows.Forms.ErrorProvider errorRol;
        private System.Windows.Forms.ComboBox rol;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
    }
}