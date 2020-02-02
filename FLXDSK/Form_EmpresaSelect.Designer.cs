namespace FLXDSK
{
    partial class Form_EmpresaSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_EmpresaSelect));
            this.label1 = new System.Windows.Forms.Label();
            this.button_Ingresar = new System.Windows.Forms.Button();
            this.comboBox_Empresa = new System.Windows.Forms.ComboBox();
            this.button_Salir = new System.Windows.Forms.Button();
            this.pictureBox_Empresa = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Empresa)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 13F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(159, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selección de Empresa";
            // 
            // button_Ingresar
            // 
            this.button_Ingresar.Location = new System.Drawing.Point(321, 196);
            this.button_Ingresar.Name = "button_Ingresar";
            this.button_Ingresar.Size = new System.Drawing.Size(81, 27);
            this.button_Ingresar.TabIndex = 1;
            this.button_Ingresar.Text = "Seleccionar";
            this.button_Ingresar.UseVisualStyleBackColor = true;
            this.button_Ingresar.Click += new System.EventHandler(this.button_Ingresar_Click);
            // 
            // comboBox_Empresa
            // 
            this.comboBox_Empresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Empresa.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Empresa.FormattingEnabled = true;
            this.comboBox_Empresa.Location = new System.Drawing.Point(163, 152);
            this.comboBox_Empresa.Name = "comboBox_Empresa";
            this.comboBox_Empresa.Size = new System.Drawing.Size(313, 22);
            this.comboBox_Empresa.TabIndex = 0;
            // 
            // button_Salir
            // 
            this.button_Salir.Location = new System.Drawing.Point(408, 196);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(68, 27);
            this.button_Salir.TabIndex = 2;
            this.button_Salir.Text = "Salir";
            this.button_Salir.UseVisualStyleBackColor = true;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // pictureBox_Empresa
            // 
            this.pictureBox_Empresa.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Empresa.BackgroundImage = global::FLXDSK.Properties.Resources.icon_empresa;
            this.pictureBox_Empresa.Location = new System.Drawing.Point(96, 101);
            this.pictureBox_Empresa.Name = "pictureBox_Empresa";
            this.pictureBox_Empresa.Size = new System.Drawing.Size(38, 38);
            this.pictureBox_Empresa.TabIndex = 142;
            this.pictureBox_Empresa.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.label2.Location = new System.Drawing.Point(160, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(279, 15);
            this.label2.TabIndex = 143;
            this.label2.Text = "Seleccione la empresa con la que desea trabajar.";
            // 
            // Form_EmpresaSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::FLXDSK.Properties.Resources.fondo_empresa;
            this.ClientSize = new System.Drawing.Size(600, 320);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox_Empresa);
            this.Controls.Add(this.button_Salir);
            this.Controls.Add(this.comboBox_Empresa);
            this.Controls.Add(this.button_Ingresar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_EmpresaSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Selecciona tu Empresa";
            this.Load += new System.EventHandler(this.Form_EmpresaSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Empresa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Ingresar;
        private System.Windows.Forms.ComboBox comboBox_Empresa;
        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.PictureBox pictureBox_Empresa;
        private System.Windows.Forms.Label label2;
    }
}