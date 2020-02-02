namespace FLXDSK.Formularios
{
    partial class Form_GastosFijos
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.textBox_Monto = new System.Windows.Forms.TextBox();
            this.textBox_Descripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker_fin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_inicio = new System.Windows.Forms.DateTimePicker();
            this.textBox_Tipo = new System.Windows.Forms.TextBox();
            this.checkBox_SiMensual = new System.Windows.Forms.CheckBox();
            this.label_Mensaje = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::FLXDSK.Properties.Resources.equis;
            this.pictureBox2.Location = new System.Drawing.Point(268, 9);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 227;
            this.pictureBox2.TabStop = false;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label14.Location = new System.Drawing.Point(-8, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(364, 23);
            this.label14.TabIndex = 228;
            this.label14.Text = "_______________________________________________________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 22);
            this.label1.TabIndex = 226;
            this.label1.Text = "Gastos Fijos";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(49, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 225;
            this.label5.Text = "*Tipo:";
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(225, 242);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(73, 32);
            this.button_Cancelar.TabIndex = 8;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(144, 242);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(73, 32);
            this.button_Guardar.TabIndex = 7;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // textBox_Monto
            // 
            this.textBox_Monto.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox_Monto.Location = new System.Drawing.Point(94, 131);
            this.textBox_Monto.Name = "textBox_Monto";
            this.textBox_Monto.Size = new System.Drawing.Size(191, 23);
            this.textBox_Monto.TabIndex = 3;
            this.textBox_Monto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Monto_KeyPress);
            // 
            // textBox_Descripcion
            // 
            this.textBox_Descripcion.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox_Descripcion.Location = new System.Drawing.Point(94, 102);
            this.textBox_Descripcion.Name = "textBox_Descripcion";
            this.textBox_Descripcion.Size = new System.Drawing.Size(191, 23);
            this.textBox_Descripcion.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 223;
            this.label3.Text = "*Monto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 15);
            this.label2.TabIndex = 222;
            this.label2.Text = "*Descripción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.Location = new System.Drawing.Point(64, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 15);
            this.label4.TabIndex = 308;
            this.label4.Text = "Fin";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Arial", 9F);
            this.label6.Location = new System.Drawing.Point(52, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 15);
            this.label6.TabIndex = 307;
            this.label6.Text = "Inicio";
            // 
            // dateTimePicker_fin
            // 
            this.dateTimePicker_fin.Font = new System.Drawing.Font("Arial", 9F);
            this.dateTimePicker_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_fin.Location = new System.Drawing.Point(94, 191);
            this.dateTimePicker_fin.Name = "dateTimePicker_fin";
            this.dateTimePicker_fin.Size = new System.Drawing.Size(101, 21);
            this.dateTimePicker_fin.TabIndex = 5;
            // 
            // dateTimePicker_inicio
            // 
            this.dateTimePicker_inicio.Font = new System.Drawing.Font("Arial", 9F);
            this.dateTimePicker_inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_inicio.Location = new System.Drawing.Point(94, 163);
            this.dateTimePicker_inicio.Name = "dateTimePicker_inicio";
            this.dateTimePicker_inicio.Size = new System.Drawing.Size(101, 21);
            this.dateTimePicker_inicio.TabIndex = 4;
            // 
            // textBox_Tipo
            // 
            this.textBox_Tipo.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox_Tipo.Location = new System.Drawing.Point(94, 67);
            this.textBox_Tipo.Name = "textBox_Tipo";
            this.textBox_Tipo.Size = new System.Drawing.Size(191, 23);
            this.textBox_Tipo.TabIndex = 1;
            // 
            // checkBox_SiMensual
            // 
            this.checkBox_SiMensual.AutoSize = true;
            this.checkBox_SiMensual.Location = new System.Drawing.Point(94, 218);
            this.checkBox_SiMensual.Name = "checkBox_SiMensual";
            this.checkBox_SiMensual.Size = new System.Drawing.Size(94, 17);
            this.checkBox_SiMensual.TabIndex = 6;
            this.checkBox_SiMensual.Text = "Pago Mensual";
            this.checkBox_SiMensual.UseVisualStyleBackColor = true;
            this.checkBox_SiMensual.CheckedChanged += new System.EventHandler(this.checkBox_SiMensual_CheckedChanged);
            // 
            // label_Mensaje
            // 
            this.label_Mensaje.AutoSize = true;
            this.label_Mensaje.Location = new System.Drawing.Point(2, 261);
            this.label_Mensaje.Name = "label_Mensaje";
            this.label_Mensaje.Size = new System.Drawing.Size(77, 13);
            this.label_Mensaje.TabIndex = 310;
            this.label_Mensaje.Text = "Pago Bimestral";
            this.label_Mensaje.Visible = false;
            // 
            // Form_GastosFijos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 279);
            this.Controls.Add(this.label_Mensaje);
            this.Controls.Add(this.checkBox_SiMensual);
            this.Controls.Add(this.textBox_Tipo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker_fin);
            this.Controls.Add(this.dateTimePicker_inicio);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.textBox_Monto);
            this.Controls.Add(this.textBox_Descripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "Form_GastosFijos";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form_GastosFijos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.TextBox textBox_Monto;
        private System.Windows.Forms.TextBox textBox_Descripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_inicio;
        private System.Windows.Forms.TextBox textBox_Tipo;
        private System.Windows.Forms.CheckBox checkBox_SiMensual;
        private System.Windows.Forms.Label label_Mensaje;
    }
}