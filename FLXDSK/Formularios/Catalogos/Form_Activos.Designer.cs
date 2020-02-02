namespace FLXDSK.Formularios.Catalogos
{
    partial class Form_Activos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Activos));
            this.labelTit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.textBox_Descripcion = new System.Windows.Forms.TextBox();
            this.textBox_Cantidad = new System.Windows.Forms.TextBox();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Precio = new System.Windows.Forms.TextBox();
            this.comboBox_Categorias = new System.Windows.Forms.ComboBox();
            this.button_Agregar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Almacen = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTit
            // 
            this.labelTit.AutoSize = true;
            this.labelTit.BackColor = System.Drawing.Color.Transparent;
            this.labelTit.Font = new System.Drawing.Font("Arial", 15F);
            this.labelTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelTit.Location = new System.Drawing.Point(14, 11);
            this.labelTit.Name = "labelTit";
            this.labelTit.Size = new System.Drawing.Size(232, 23);
            this.labelTit.TabIndex = 448;
            this.labelTit.Text = "Catálogo de Activos Fijos";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(-174, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(689, 28);
            this.label1.TabIndex = 450;
            this.label1.Text = "_________________________________________________________________________________" +
                "_______________________";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.Location = new System.Drawing.Point(33, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 447;
            this.label4.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.Location = new System.Drawing.Point(51, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 446;
            this.label3.Text = "Cantidad";
            // 
            // button_Guardar
            // 
            this.button_Guardar.Font = new System.Drawing.Font("Arial", 9F);
            this.button_Guardar.Location = new System.Drawing.Point(132, 338);
            this.button_Guardar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(80, 33);
            this.button_Guardar.TabIndex = 5;
            this.button_Guardar.Tag = "3";
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // textBox_Descripcion
            // 
            this.textBox_Descripcion.Location = new System.Drawing.Point(125, 155);
            this.textBox_Descripcion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Descripcion.MaxLength = 250;
            this.textBox_Descripcion.Multiline = true;
            this.textBox_Descripcion.Name = "textBox_Descripcion";
            this.textBox_Descripcion.Size = new System.Drawing.Size(352, 89);
            this.textBox_Descripcion.TabIndex = 2;
            this.textBox_Descripcion.Tag = "2";
            // 
            // textBox_Cantidad
            // 
            this.textBox_Cantidad.Location = new System.Drawing.Point(125, 252);
            this.textBox_Cantidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Cantidad.MaxLength = 80;
            this.textBox_Cantidad.Name = "textBox_Cantidad";
            this.textBox_Cantidad.Size = new System.Drawing.Size(104, 23);
            this.textBox_Cantidad.TabIndex = 3;
            this.textBox_Cantidad.Tag = "1";
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Font = new System.Drawing.Font("Arial", 9F);
            this.button_Cancelar.Location = new System.Drawing.Point(219, 338);
            this.button_Cancelar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(84, 33);
            this.button_Cancelar.TabIndex = 6;
            this.button_Cancelar.Tag = "4";
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(69, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 452;
            this.label2.Text = "Precio";
            // 
            // textBox_Precio
            // 
            this.textBox_Precio.Location = new System.Drawing.Point(125, 284);
            this.textBox_Precio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Precio.MaxLength = 80;
            this.textBox_Precio.Name = "textBox_Precio";
            this.textBox_Precio.Size = new System.Drawing.Size(104, 23);
            this.textBox_Precio.TabIndex = 4;
            this.textBox_Precio.Tag = "1";
            // 
            // comboBox_Categorias
            // 
            this.comboBox_Categorias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Categorias.FormattingEnabled = true;
            this.comboBox_Categorias.Location = new System.Drawing.Point(125, 91);
            this.comboBox_Categorias.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_Categorias.Name = "comboBox_Categorias";
            this.comboBox_Categorias.Size = new System.Drawing.Size(201, 24);
            this.comboBox_Categorias.TabIndex = 0;
            // 
            // button_Agregar
            // 
            this.button_Agregar.Font = new System.Drawing.Font("Arial", 9F);
            this.button_Agregar.Location = new System.Drawing.Point(334, 91);
            this.button_Agregar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button_Agregar.Name = "button_Agregar";
            this.button_Agregar.Size = new System.Drawing.Size(80, 24);
            this.button_Agregar.TabIndex = 1;
            this.button_Agregar.Tag = "3";
            this.button_Agregar.Text = "Agregar";
            this.button_Agregar.UseVisualStyleBackColor = true;
            this.button_Agregar.Click += new System.EventHandler(this.button_Agregar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F);
            this.label6.Location = new System.Drawing.Point(45, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 15);
            this.label6.TabIndex = 457;
            this.label6.Text = "Categoría";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::FLXDSK.Properties.Resources.equis;
            this.pictureBox2.Location = new System.Drawing.Point(473, 7);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 37);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 449;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F);
            this.label5.Location = new System.Drawing.Point(45, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 15);
            this.label5.TabIndex = 459;
            this.label5.Text = "Almacen";
            // 
            // comboBox_Almacen
            // 
            this.comboBox_Almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Almacen.FormattingEnabled = true;
            this.comboBox_Almacen.Location = new System.Drawing.Point(125, 123);
            this.comboBox_Almacen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBox_Almacen.Name = "comboBox_Almacen";
            this.comboBox_Almacen.Size = new System.Drawing.Size(201, 24);
            this.comboBox_Almacen.TabIndex = 458;
            // 
            // Form_Activos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 408);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_Almacen);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button_Agregar);
            this.Controls.Add(this.comboBox_Categorias);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Precio);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelTit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.textBox_Descripcion);
            this.Controls.Add(this.textBox_Cantidad);
            this.Controls.Add(this.button_Cancelar);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_Activos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Activos Fijos";
            this.Load += new System.EventHandler(this.Form_Activos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label labelTit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.TextBox textBox_Descripcion;
        private System.Windows.Forms.TextBox textBox_Cantidad;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Precio;
        private System.Windows.Forms.ComboBox comboBox_Categorias;
        private System.Windows.Forms.Button button_Agregar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_Almacen;
    }
}