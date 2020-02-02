namespace FLXDSK.Formularios.Catalogos.Local
{
    partial class Form_Areas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Areas));
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.textBox_Descripcion = new System.Windows.Forms.TextBox();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelTit = new System.Windows.Forms.Label();
            this.pictureBox_Areas = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Areas)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(214, 175);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(72, 30);
            this.button_Cancelar.TabIndex = 3;
            this.button_Cancelar.Tag = "4";
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Location = new System.Drawing.Point(105, 69);
            this.textBox_Nombre.MaxLength = 80;
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(181, 20);
            this.textBox_Nombre.TabIndex = 0;
            this.textBox_Nombre.Tag = "1";
            // 
            // textBox_Descripcion
            // 
            this.textBox_Descripcion.Location = new System.Drawing.Point(105, 96);
            this.textBox_Descripcion.MaxLength = 250;
            this.textBox_Descripcion.Multiline = true;
            this.textBox_Descripcion.Name = "textBox_Descripcion";
            this.textBox_Descripcion.Size = new System.Drawing.Size(181, 73);
            this.textBox_Descripcion.TabIndex = 1;
            this.textBox_Descripcion.Tag = "2";
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(139, 175);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(69, 30);
            this.button_Guardar.TabIndex = 2;
            this.button_Guardar.Tag = "3";
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.Location = new System.Drawing.Point(45, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.Location = new System.Drawing.Point(24, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Descripción";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::FLXDSK.Properties.Resources.equis;
            this.pictureBox2.Location = new System.Drawing.Point(373, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 405;
            this.pictureBox2.TabStop = false;
            // 
            // labelTit
            // 
            this.labelTit.AutoSize = true;
            this.labelTit.BackColor = System.Drawing.Color.Transparent;
            this.labelTit.Font = new System.Drawing.Font("Arial", 15F);
            this.labelTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelTit.Location = new System.Drawing.Point(9, 9);
            this.labelTit.Name = "labelTit";
            this.labelTit.Size = new System.Drawing.Size(175, 23);
            this.labelTit.TabIndex = 404;
            this.labelTit.Text = "Catálogo de Áreas";
            // 
            // pictureBox_Areas
            // 
            this.pictureBox_Areas.BackgroundImage = global::FLXDSK.Properties.Resources.sin_imagen;
            this.pictureBox_Areas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_Areas.Location = new System.Drawing.Point(292, 69);
            this.pictureBox_Areas.Name = "pictureBox_Areas";
            this.pictureBox_Areas.Size = new System.Drawing.Size(125, 100);
            this.pictureBox_Areas.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Areas.TabIndex = 440;
            this.pictureBox_Areas.TabStop = false;
            this.pictureBox_Areas.Click += new System.EventHandler(this.pictureBox_Areas_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(-152, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(730, 23);
            this.label1.TabIndex = 441;
            this.label1.Text = "_________________________________________________________________________________" +
    "_______________________";
            // 
            // Form_Areas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 225);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelTit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_Areas);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.textBox_Descripcion);
            this.Controls.Add(this.textBox_Nombre);
            this.Controls.Add(this.button_Cancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(3, 10);
            this.Name = "Form_Areas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo de Áreas";
            this.Load += new System.EventHandler(this.Form_Areas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Areas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.TextBox textBox_Descripcion;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelTit;
        private System.Windows.Forms.PictureBox pictureBox_Areas;
        private System.Windows.Forms.Label label1;

    }
}