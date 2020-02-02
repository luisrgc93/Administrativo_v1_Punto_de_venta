namespace FLXDSK.Formularios.Ventas
{
    partial class Form_AgregarGasto
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
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.textBox_Monto = new System.Windows.Forms.TextBox();
            this.textBox_Descripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.comboBox_Motivo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton_Entrada = new System.Windows.Forms.RadioButton();
            this.radioButton_Salida = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label14.Location = new System.Drawing.Point(-7, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(364, 23);
            this.label14.TabIndex = 324;
            this.label14.Text = "_______________________________________________________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 22);
            this.label1.TabIndex = 322;
            this.label1.Text = "Agregar Movimiento";
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(209, 171);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(73, 32);
            this.button_Cancelar.TabIndex = 318;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(128, 171);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(73, 32);
            this.button_Guardar.TabIndex = 317;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // textBox_Monto
            // 
            this.textBox_Monto.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox_Monto.Location = new System.Drawing.Point(91, 142);
            this.textBox_Monto.MaxLength = 11;
            this.textBox_Monto.Name = "textBox_Monto";
            this.textBox_Monto.Size = new System.Drawing.Size(191, 23);
            this.textBox_Monto.TabIndex = 313;
            // 
            // textBox_Descripcion
            // 
            this.textBox_Descripcion.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox_Descripcion.Location = new System.Drawing.Point(91, 113);
            this.textBox_Descripcion.MaxLength = 80;
            this.textBox_Descripcion.Name = "textBox_Descripcion";
            this.textBox_Descripcion.Size = new System.Drawing.Size(191, 23);
            this.textBox_Descripcion.TabIndex = 312;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 320;
            this.label3.Text = "*Monto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 319;
            this.label2.Text = "*Descripción:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::FLXDSK.Properties.Resources.equis;
            this.pictureBox2.Location = new System.Drawing.Point(313, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 323;
            this.pictureBox2.TabStop = false;
            // 
            // comboBox_Motivo
            // 
            this.comboBox_Motivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Motivo.Font = new System.Drawing.Font("Arial", 9F);
            this.comboBox_Motivo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_Motivo.FormattingEnabled = true;
            this.comboBox_Motivo.Location = new System.Drawing.Point(91, 85);
            this.comboBox_Motivo.Name = "comboBox_Motivo";
            this.comboBox_Motivo.Size = new System.Drawing.Size(191, 23);
            this.comboBox_Motivo.TabIndex = 492;
            this.comboBox_Motivo.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.Location = new System.Drawing.Point(51, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 493;
            this.label4.Text = "*Tipo:";
            // 
            // radioButton_Entrada
            // 
            this.radioButton_Entrada.AutoSize = true;
            this.radioButton_Entrada.Checked = true;
            this.radioButton_Entrada.Location = new System.Drawing.Point(97, 56);
            this.radioButton_Entrada.Name = "radioButton_Entrada";
            this.radioButton_Entrada.Size = new System.Drawing.Size(62, 17);
            this.radioButton_Entrada.TabIndex = 494;
            this.radioButton_Entrada.TabStop = true;
            this.radioButton_Entrada.Text = "Entrada";
            this.radioButton_Entrada.UseVisualStyleBackColor = true;
            this.radioButton_Entrada.CheckedChanged += new System.EventHandler(this.radioButton_Entrada_CheckedChanged);
            // 
            // radioButton_Salida
            // 
            this.radioButton_Salida.AutoSize = true;
            this.radioButton_Salida.Location = new System.Drawing.Point(196, 56);
            this.radioButton_Salida.Name = "radioButton_Salida";
            this.radioButton_Salida.Size = new System.Drawing.Size(54, 17);
            this.radioButton_Salida.TabIndex = 495;
            this.radioButton_Salida.TabStop = true;
            this.radioButton_Salida.Text = "Salida";
            this.radioButton_Salida.UseVisualStyleBackColor = true;
            // 
            // Form_AgregarGasto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(358, 240);
            this.Controls.Add(this.radioButton_Salida);
            this.Controls.Add(this.radioButton_Entrada);
            this.Controls.Add(this.comboBox_Motivo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.textBox_Monto);
            this.Controls.Add(this.textBox_Descripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "Form_AgregarGasto";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_AgregarGasto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.TextBox textBox_Monto;
        private System.Windows.Forms.TextBox textBox_Descripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Motivo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButton_Entrada;
        private System.Windows.Forms.RadioButton radioButton_Salida;
    }
}