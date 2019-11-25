namespace FrbaOfertas.AbmRol
{
    partial class AltaYModificacion
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
            this.nombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.funcionalidadesASeleccionar = new System.Windows.Forms.CheckedListBox();
            this.confirmar = new System.Windows.Forms.Button();
            this.habilitado = new System.Windows.Forms.CheckBox();
            this.errorFuncionalidades = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorRol = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorFuncionalidades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorRol)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // nombre
            // 
            this.nombre.Location = new System.Drawing.Point(135, 44);
            this.nombre.Name = "nombre";
            this.nombre.Size = new System.Drawing.Size(100, 20);
            this.nombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Funcionalidades";
            // 
            // funcionalidadesASeleccionar
            // 
            this.funcionalidadesASeleccionar.FormattingEnabled = true;
            this.funcionalidadesASeleccionar.Location = new System.Drawing.Point(48, 113);
            this.funcionalidadesASeleccionar.Name = "funcionalidadesASeleccionar";
            this.funcionalidadesASeleccionar.Size = new System.Drawing.Size(212, 154);
            this.funcionalidadesASeleccionar.TabIndex = 4;
            // 
            // confirmar
            // 
            this.confirmar.BackColor = System.Drawing.Color.SandyBrown;
            this.confirmar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.confirmar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmar.Location = new System.Drawing.Point(175, 275);
            this.confirmar.Name = "confirmar";
            this.confirmar.Size = new System.Drawing.Size(85, 23);
            this.confirmar.TabIndex = 5;
            this.confirmar.Text = "CONFIRMAR";
            this.confirmar.UseVisualStyleBackColor = false;
            this.confirmar.Click += new System.EventHandler(this.confirmar_Click);
            // 
            // habilitado
            // 
            this.habilitado.AutoSize = true;
            this.habilitado.Location = new System.Drawing.Point(48, 279);
            this.habilitado.Name = "habilitado";
            this.habilitado.Size = new System.Drawing.Size(73, 17);
            this.habilitado.TabIndex = 6;
            this.habilitado.Text = "Habilitado";
            this.habilitado.UseVisualStyleBackColor = true;
            // 
            // errorFuncionalidades
            // 
            this.errorFuncionalidades.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorFuncionalidades.ContainerControl = this;
            // 
            // errorRol
            // 
            this.errorRol.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorRol.ContainerControl = this;
            // 
            // AltaYModificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 321);
            this.Controls.Add(this.habilitado);
            this.Controls.Add(this.confirmar);
            this.Controls.Add(this.funcionalidadesASeleccionar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nombre);
            this.Controls.Add(this.label1);
            this.Name = "AltaYModificacion";
            this.Text = "Alta";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.nombre, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.funcionalidadesASeleccionar, 0);
            this.Controls.SetChildIndex(this.confirmar, 0);
            this.Controls.SetChildIndex(this.habilitado, 0);
            ((System.ComponentModel.ISupportInitialize)(this.errorFuncionalidades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorRol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        protected System.Windows.Forms.TextBox nombre;
        protected System.Windows.Forms.CheckedListBox funcionalidadesASeleccionar;
        protected System.Windows.Forms.Button confirmar;
        protected System.Windows.Forms.CheckBox habilitado;
        private System.Windows.Forms.ErrorProvider errorFuncionalidades;
        private System.Windows.Forms.ErrorProvider errorRol;
    }
}