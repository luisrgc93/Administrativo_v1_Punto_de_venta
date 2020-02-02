namespace FLXDSK.herramientas.Inventarios
{
    partial class Form_Cantidad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Cantidad));
            this.textBox_Cantidad = new System.Windows.Forms.TextBox();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_UnidadMetrica = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBox_Cantidad
            // 
            this.textBox_Cantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Cantidad.Location = new System.Drawing.Point(53, 45);
            this.textBox_Cantidad.Name = "textBox_Cantidad";
            this.textBox_Cantidad.Size = new System.Drawing.Size(172, 35);
            this.textBox_Cantidad.TabIndex = 0;
            this.textBox_Cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Cantidad_KeyPress);
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.Location = new System.Drawing.Point(56, 124);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(172, 39);
            this.button_Aceptar.TabIndex = 2;
            this.button_Aceptar.Text = "Aceptar";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F);
            this.label6.Location = new System.Drawing.Point(53, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 15);
            this.label6.TabIndex = 610;
            this.label6.Text = "Cantidad";
            // 
            // comboBox_UnidadMetrica
            // 
            this.comboBox_UnidadMetrica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_UnidadMetrica.Font = new System.Drawing.Font("Arial", 14F);
            this.comboBox_UnidadMetrica.FormattingEnabled = true;
            this.comboBox_UnidadMetrica.Location = new System.Drawing.Point(56, 86);
            this.comboBox_UnidadMetrica.Name = "comboBox_UnidadMetrica";
            this.comboBox_UnidadMetrica.Size = new System.Drawing.Size(169, 30);
            this.comboBox_UnidadMetrica.TabIndex = 1;
            // 
            // Form_Cantidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 171);
            this.Controls.Add(this.comboBox_UnidadMetrica);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_Aceptar);
            this.Controls.Add(this.textBox_Cantidad);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Cantidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cantidad";
            this.Load += new System.EventHandler(this.Form_Cantidad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Cantidad;
        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_UnidadMetrica;
    }
}