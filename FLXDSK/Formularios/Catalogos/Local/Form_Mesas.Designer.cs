namespace FLXDSK.Formularios.Catalogos.Local
{
    partial class Form_Mesas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Mesas));
            this.labelTit = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.textBox_Descripcion = new System.Windows.Forms.TextBox();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_area = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Restaurar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTit
            // 
            this.labelTit.AutoSize = true;
            this.labelTit.BackColor = System.Drawing.Color.Transparent;
            this.labelTit.Font = new System.Drawing.Font("Arial", 15F);
            this.labelTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelTit.Location = new System.Drawing.Point(2, 9);
            this.labelTit.Name = "labelTit";
            this.labelTit.Size = new System.Drawing.Size(182, 23);
            this.labelTit.TabIndex = 413;
            this.labelTit.Text = "Catálogo de Mesas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.Location = new System.Drawing.Point(18, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 412;
            this.label4.Text = "*Descripción";
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(126, 228);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(71, 32);
            this.button_Guardar.TabIndex = 3;
            this.button_Guardar.Tag = "3";
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // textBox_Descripcion
            // 
            this.textBox_Descripcion.Location = new System.Drawing.Point(99, 103);
            this.textBox_Descripcion.MaxLength = 250;
            this.textBox_Descripcion.Multiline = true;
            this.textBox_Descripcion.Name = "textBox_Descripcion";
            this.textBox_Descripcion.Size = new System.Drawing.Size(181, 55);
            this.textBox_Descripcion.TabIndex = 2;
            this.textBox_Descripcion.Tag = "2";
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(203, 228);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(77, 32);
            this.button_Cancelar.TabIndex = 4;
            this.button_Cancelar.Tag = "4";
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(-6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(358, 23);
            this.label1.TabIndex = 415;
            this.label1.Text = "____________________________________________";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::FLXDSK.Properties.Resources.equis;
            this.pictureBox2.Location = new System.Drawing.Point(250, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 414;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(58, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 416;
            this.label2.Text = "*Área";
            // 
            // comboBox_area
            // 
            this.comboBox_area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_area.FormattingEnabled = true;
            this.comboBox_area.Location = new System.Drawing.Point(99, 76);
            this.comboBox_area.Name = "comboBox_area";
            this.comboBox_area.Size = new System.Drawing.Size(181, 21);
            this.comboBox_area.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.Location = new System.Drawing.Point(31, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 15);
            this.label3.TabIndex = 417;
            this.label3.Text = "Ubicación";
            this.label3.Visible = false;
            // 
            // button_Restaurar
            // 
            this.button_Restaurar.Location = new System.Drawing.Point(99, 164);
            this.button_Restaurar.Name = "button_Restaurar";
            this.button_Restaurar.Size = new System.Drawing.Size(113, 28);
            this.button_Restaurar.TabIndex = 418;
            this.button_Restaurar.Text = "Eliminar Ubicación";
            this.button_Restaurar.UseVisualStyleBackColor = true;
            this.button_Restaurar.Visible = false;
            this.button_Restaurar.Click += new System.EventHandler(this.button_Restaurar_Click);
            // 
            // Form_Mesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 272);
            this.Controls.Add(this.button_Restaurar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_area);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelTit);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.textBox_Descripcion);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(3, 10);
            this.Name = "Form_Mesas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo de Mesas";
            this.Load += new System.EventHandler(this.Form_Mesas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelTit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.TextBox textBox_Descripcion;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_area;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Restaurar;
    }
}