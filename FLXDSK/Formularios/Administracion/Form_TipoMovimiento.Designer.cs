namespace FLXDSK.Formularios.Administracion
{
    partial class Form_TipoMovimiento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TipoMovimiento));
            this.labelTit = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_vchNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Tipo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTit
            // 
            this.labelTit.AutoSize = true;
            this.labelTit.BackColor = System.Drawing.Color.Transparent;
            this.labelTit.Font = new System.Drawing.Font("Arial", 15F);
            this.labelTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelTit.Location = new System.Drawing.Point(12, 9);
            this.labelTit.Name = "labelTit";
            this.labelTit.Size = new System.Drawing.Size(180, 23);
            this.labelTit.TabIndex = 162;
            this.labelTit.Text = "Tipo de Movimiento";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label14.Location = new System.Drawing.Point(10, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(342, 23);
            this.label14.TabIndex = 163;
            this.label14.Text = "_________________________________________________________________________________" +
    "________________";
            // 
            // textBox_vchNombre
            // 
            this.textBox_vchNombre.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_vchNombre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_vchNombre.Location = new System.Drawing.Point(101, 52);
            this.textBox_vchNombre.MaxLength = 35;
            this.textBox_vchNombre.Name = "textBox_vchNombre";
            this.textBox_vchNombre.Size = new System.Drawing.Size(242, 21);
            this.textBox_vchNombre.TabIndex = 164;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label3.Location = new System.Drawing.Point(22, 55);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 165;
            this.label3.Text = "* Nombre";
            // 
            // comboBox_Tipo
            // 
            this.comboBox_Tipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tipo.Font = new System.Drawing.Font("Arial", 9F);
            this.comboBox_Tipo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_Tipo.FormattingEnabled = true;
            this.comboBox_Tipo.Items.AddRange(new object[] {
            "Administrador",
            "Mesero"});
            this.comboBox_Tipo.Location = new System.Drawing.Point(101, 79);
            this.comboBox_Tipo.Name = "comboBox_Tipo";
            this.comboBox_Tipo.Size = new System.Drawing.Size(242, 23);
            this.comboBox_Tipo.TabIndex = 166;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 9F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label8.Location = new System.Drawing.Point(43, 87);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 167;
            this.label8.Text = "* Tipo";
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(268, 108);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(75, 25);
            this.button_Guardar.TabIndex = 168;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // Form_TipoMovimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 172);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.comboBox_Tipo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_vchNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelTit);
            this.Controls.Add(this.label14);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_TipoMovimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tipo Movimiento";
            this.Load += new System.EventHandler(this.Form_TipoMovimiento_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_vchNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Tipo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_Guardar;
    }
}