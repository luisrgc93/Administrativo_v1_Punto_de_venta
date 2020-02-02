namespace FLXDSK.Formularios.Administracion
{
    partial class Form_ParametrosGenerales
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label_Cantidad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Mensaje = new System.Windows.Forms.TextBox();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBox_IdParametro = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label_Cantidad);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_Mensaje);
            this.panel1.Controls.Add(this.button_Guardar);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.comboBox_IdParametro);
            this.panel1.Location = new System.Drawing.Point(3, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 206);
            this.panel1.TabIndex = 293;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(284, 116);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 31);
            this.button1.TabIndex = 4;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_Cantidad
            // 
            this.label_Cantidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label_Cantidad.Font = new System.Drawing.Font("Arial", 9F);
            this.label_Cantidad.ForeColor = System.Drawing.SystemColors.Window;
            this.label_Cantidad.Location = new System.Drawing.Point(19, 85);
            this.label_Cantidad.Name = "label_Cantidad";
            this.label_Cantidad.Padding = new System.Windows.Forms.Padding(3);
            this.label_Cantidad.Size = new System.Drawing.Size(87, 21);
            this.label_Cantidad.TabIndex = 301;
            this.label_Cantidad.Text = "Mensaje";
            this.label_Cantidad.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(19, 56);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(87, 24);
            this.label1.TabIndex = 299;
            this.label1.Text = "Parámetro";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(19, 89);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(87, 21);
            this.label2.TabIndex = 298;
            this.label2.Text = "Valor";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox_Mensaje
            // 
            this.textBox_Mensaje.Font = new System.Drawing.Font("Arial", 11F);
            this.textBox_Mensaje.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Mensaje.Location = new System.Drawing.Point(112, 86);
            this.textBox_Mensaje.MaxLength = 100;
            this.textBox_Mensaje.Name = "textBox_Mensaje";
            this.textBox_Mensaje.Size = new System.Drawing.Size(252, 24);
            this.textBox_Mensaje.TabIndex = 2;
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(198, 116);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(80, 31);
            this.button_Guardar.TabIndex = 3;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.SystemColors.Window;
            this.label14.Location = new System.Drawing.Point(-3, 0);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(3);
            this.label14.Size = new System.Drawing.Size(404, 31);
            this.label14.TabIndex = 290;
            this.label14.Text = "Parámetros Generales";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboBox_IdParametro
            // 
            this.comboBox_IdParametro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_IdParametro.Font = new System.Drawing.Font("Arial", 10F);
            this.comboBox_IdParametro.FormattingEnabled = true;
            this.comboBox_IdParametro.Location = new System.Drawing.Point(112, 56);
            this.comboBox_IdParametro.Name = "comboBox_IdParametro";
            this.comboBox_IdParametro.Size = new System.Drawing.Size(252, 24);
            this.comboBox_IdParametro.TabIndex = 1;
            this.comboBox_IdParametro.SelectedValueChanged += new System.EventHandler(this.comboBox_IdParametro_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(8, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 13);
            this.label3.TabIndex = 302;
            this.label3.Text = "Nota: Seleccione un parámetro y guarde su valor.";
            // 
            // Form_ParametrosGenerales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(417, 228);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Form_ParametrosGenerales";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurador de Parámetros";
            this.Load += new System.EventHandler(this.Form_ParametrosGenerales_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Cantidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Mensaje;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox comboBox_IdParametro;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
    }
}