namespace Proyecto_III_Parcial_2021
{
    partial class Menu
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
            this.btPersonal = new System.Windows.Forms.Button();
            this.btRegistroJuicios = new System.Windows.Forms.Button();
            this.btFacturar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btPersonal
            // 
            this.btPersonal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btPersonal.Location = new System.Drawing.Point(115, 164);
            this.btPersonal.Name = "btPersonal";
            this.btPersonal.Size = new System.Drawing.Size(115, 57);
            this.btPersonal.TabIndex = 0;
            this.btPersonal.Text = "CERRAR SISTEMA";
            this.btPersonal.UseVisualStyleBackColor = false;
            this.btPersonal.Click += new System.EventHandler(this.btPersonal_Click);
            // 
            // btRegistroJuicios
            // 
            this.btRegistroJuicios.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btRegistroJuicios.Location = new System.Drawing.Point(203, 78);
            this.btRegistroJuicios.Name = "btRegistroJuicios";
            this.btRegistroJuicios.Size = new System.Drawing.Size(115, 57);
            this.btRegistroJuicios.TabIndex = 1;
            this.btRegistroJuicios.Text = "REGISTRO DE JUICIOS";
            this.btRegistroJuicios.UseVisualStyleBackColor = false;
            this.btRegistroJuicios.Click += new System.EventHandler(this.btRegistroJuicios_Click);
            // 
            // btFacturar
            // 
            this.btFacturar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btFacturar.Location = new System.Drawing.Point(37, 78);
            this.btFacturar.Name = "btFacturar";
            this.btFacturar.Size = new System.Drawing.Size(115, 57);
            this.btFacturar.TabIndex = 2;
            this.btFacturar.Text = "FACTURAR";
            this.btFacturar.UseVisualStyleBackColor = false;
            this.btFacturar.Click += new System.EventHandler(this.btFacturar_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(376, 296);
            this.Controls.Add(this.btFacturar);
            this.Controls.Add(this.btRegistroJuicios);
            this.Controls.Add(this.btPersonal);
            this.Name = "Menu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btPersonal;
        private System.Windows.Forms.Button btRegistroJuicios;
        private System.Windows.Forms.Button btFacturar;
    }
}