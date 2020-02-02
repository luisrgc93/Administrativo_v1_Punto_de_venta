namespace FLXDSK.Formularios.Catalogos.Personal
{
    partial class Form_Puestos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Puestos));
            this.button_Guardar = new System.Windows.Forms.Button();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.label_Nombre = new System.Windows.Forms.Label();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelTit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Propina = new System.Windows.Forms.TextBox();
            this.label_siDarPropina = new System.Windows.Forms.Label();
            this.checkBox_IsMesero = new System.Windows.Forms.CheckBox();
            this.checkBox_RepartirPropina = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(146, 150);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(82, 34);
            this.button_Guardar.TabIndex = 4;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Nombre.Location = new System.Drawing.Point(81, 65);
            this.textBox_Nombre.MaxLength = 80;
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(235, 21);
            this.textBox_Nombre.TabIndex = 1;
            // 
            // label_Nombre
            // 
            this.label_Nombre.AutoSize = true;
            this.label_Nombre.Font = new System.Drawing.Font("Arial", 9F);
            this.label_Nombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label_Nombre.Location = new System.Drawing.Point(15, 68);
            this.label_Nombre.Name = "label_Nombre";
            this.label_Nombre.Size = new System.Drawing.Size(60, 15);
            this.label_Nombre.TabIndex = 171;
            this.label_Nombre.Text = "* Nombre";
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(234, 150);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(82, 34);
            this.button_Cancelar.TabIndex = 5;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::FLXDSK.Properties.Resources.equis;
            this.pictureBox2.Location = new System.Drawing.Point(290, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 408;
            this.pictureBox2.TabStop = false;
            // 
            // labelTit
            // 
            this.labelTit.AutoSize = true;
            this.labelTit.BackColor = System.Drawing.Color.Transparent;
            this.labelTit.Font = new System.Drawing.Font("Arial", 15F);
            this.labelTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelTit.Location = new System.Drawing.Point(3, 10);
            this.labelTit.Name = "labelTit";
            this.labelTit.Size = new System.Drawing.Size(194, 23);
            this.labelTit.TabIndex = 407;
            this.labelTit.Text = "Catálogo de Puestos";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(-3, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 23);
            this.label1.TabIndex = 409;
            this.label1.Text = "__________________________________________________";
            // 
            // textBox_Propina
            // 
            this.textBox_Propina.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Propina.Location = new System.Drawing.Point(81, 115);
            this.textBox_Propina.MaxLength = 4;
            this.textBox_Propina.Name = "textBox_Propina";
            this.textBox_Propina.Size = new System.Drawing.Size(82, 21);
            this.textBox_Propina.TabIndex = 410;
            this.textBox_Propina.Visible = false;
            // 
            // label_siDarPropina
            // 
            this.label_siDarPropina.AutoSize = true;
            this.label_siDarPropina.Font = new System.Drawing.Font("Arial", 9F);
            this.label_siDarPropina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label_siDarPropina.Location = new System.Drawing.Point(25, 118);
            this.label_siDarPropina.Name = "label_siDarPropina";
            this.label_siDarPropina.Size = new System.Drawing.Size(50, 15);
            this.label_siDarPropina.TabIndex = 411;
            this.label_siDarPropina.Text = "Propina";
            this.label_siDarPropina.Visible = false;
            // 
            // checkBox_IsMesero
            // 
            this.checkBox_IsMesero.AutoSize = true;
            this.checkBox_IsMesero.Location = new System.Drawing.Point(234, 95);
            this.checkBox_IsMesero.Name = "checkBox_IsMesero";
            this.checkBox_IsMesero.Size = new System.Drawing.Size(76, 17);
            this.checkBox_IsMesero.TabIndex = 412;
            this.checkBox_IsMesero.Text = "Es Mesero";
            this.checkBox_IsMesero.UseVisualStyleBackColor = true;
            // 
            // checkBox_RepartirPropina
            // 
            this.checkBox_RepartirPropina.AutoSize = true;
            this.checkBox_RepartirPropina.Location = new System.Drawing.Point(82, 93);
            this.checkBox_RepartirPropina.Name = "checkBox_RepartirPropina";
            this.checkBox_RepartirPropina.Size = new System.Drawing.Size(102, 17);
            this.checkBox_RepartirPropina.TabIndex = 413;
            this.checkBox_RepartirPropina.Text = "Repartir Propina";
            this.checkBox_RepartirPropina.UseVisualStyleBackColor = true;
            this.checkBox_RepartirPropina.CheckedChanged += new System.EventHandler(this.checkBox_RepartirPropina_CheckedChanged);
            // 
            // Form_Puestos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 196);
            this.Controls.Add(this.checkBox_RepartirPropina);
            this.Controls.Add(this.checkBox_IsMesero);
            this.Controls.Add(this.label_siDarPropina);
            this.Controls.Add(this.textBox_Propina);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelTit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.textBox_Nombre);
            this.Controls.Add(this.label_Nombre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Puestos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Puestos";
            this.Load += new System.EventHandler(this.Form_Puestos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.Label label_Nombre;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelTit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Propina;
        private System.Windows.Forms.Label label_siDarPropina;
        private System.Windows.Forms.CheckBox checkBox_IsMesero;
        private System.Windows.Forms.CheckBox checkBox_RepartirPropina;
    }
}