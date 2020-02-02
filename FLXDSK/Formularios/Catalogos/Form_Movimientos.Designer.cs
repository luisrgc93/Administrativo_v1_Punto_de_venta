namespace FLXDSK.Formularios.Catalogos
{
    partial class Form_Movimientos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Movimientos));
            this.comboBox_destino = new System.Windows.Forms.ComboBox();
            this.comboBox_origen = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_requerido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAgregar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_cantidad = new System.Windows.Forms.TextBox();
            this.label_modelo = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_buscar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_tipo_producto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.labelTit = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.button_terminar = new System.Windows.Forms.Button();
            this.comboBox_unidades = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_destino
            // 
            this.comboBox_destino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_destino.FormattingEnabled = true;
            this.comboBox_destino.Location = new System.Drawing.Point(367, 56);
            this.comboBox_destino.Name = "comboBox_destino";
            this.comboBox_destino.Size = new System.Drawing.Size(140, 23);
            this.comboBox_destino.TabIndex = 1;
            // 
            // comboBox_origen
            // 
            this.comboBox_origen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_origen.FormattingEnabled = true;
            this.comboBox_origen.Location = new System.Drawing.Point(108, 56);
            this.comboBox_origen.Name = "comboBox_origen";
            this.comboBox_origen.Size = new System.Drawing.Size(140, 23);
            this.comboBox_origen.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.Location = new System.Drawing.Point(9, 154);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F);
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(709, 171);
            this.dataGridView1.TabIndex = 594;
            // 
            // textBox_requerido
            // 
            this.textBox_requerido.Location = new System.Drawing.Point(138, 127);
            this.textBox_requerido.Name = "textBox_requerido";
            this.textBox_requerido.Size = new System.Drawing.Size(82, 21);
            this.textBox_requerido.TabIndex = 600;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.Location = new System.Drawing.Point(9, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 15);
            this.label3.TabIndex = 607;
            this.label3.Text = "*Cantidad Requerida";
            // 
            // buttonAgregar
            // 
            this.buttonAgregar.Location = new System.Drawing.Point(377, 126);
            this.buttonAgregar.Name = "buttonAgregar";
            this.buttonAgregar.Size = new System.Drawing.Size(66, 23);
            this.buttonAgregar.TabIndex = 604;
            this.buttonAgregar.Text = "Agregar";
            this.buttonAgregar.UseVisualStyleBackColor = true;
            this.buttonAgregar.Click += new System.EventHandler(this.buttonAgregar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F);
            this.label8.Location = new System.Drawing.Point(145, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 605;
            this.label8.Text = "*Codigo";
            // 
            // textBox_cantidad
            // 
            this.textBox_cantidad.Enabled = false;
            this.textBox_cantidad.Location = new System.Drawing.Point(628, 94);
            this.textBox_cantidad.Name = "textBox_cantidad";
            this.textBox_cantidad.Size = new System.Drawing.Size(90, 21);
            this.textBox_cantidad.TabIndex = 601;
            // 
            // label_modelo
            // 
            this.label_modelo.BackColor = System.Drawing.SystemColors.Window;
            this.label_modelo.Font = new System.Drawing.Font("Arial", 9F);
            this.label_modelo.Location = new System.Drawing.Point(200, 94);
            this.label_modelo.Name = "label_modelo";
            this.label_modelo.Padding = new System.Windows.Forms.Padding(3);
            this.label_modelo.Size = new System.Drawing.Size(293, 20);
            this.label_modelo.TabIndex = 596;
            this.label_modelo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 9F);
            this.label9.Location = new System.Drawing.Point(502, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 15);
            this.label9.TabIndex = 606;
            this.label9.Text = "Cantidad Disponible";
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(9, 93);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(126, 23);
            this.button_buscar.TabIndex = 598;
            this.button_buscar.Text = "Buscar Producto";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label1.Location = new System.Drawing.Point(9, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 15);
            this.label1.TabIndex = 611;
            this.label1.Text = "Amacen Origen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label2.Location = new System.Drawing.Point(259, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 15);
            this.label2.TabIndex = 612;
            this.label2.Text = "Almacen Destino";
            // 
            // comboBox_tipo_producto
            // 
            this.comboBox_tipo_producto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tipo_producto.FormattingEnabled = true;
            this.comboBox_tipo_producto.Location = new System.Drawing.Point(608, 56);
            this.comboBox_tipo_producto.Name = "comboBox_tipo_producto";
            this.comboBox_tipo_producto.Size = new System.Drawing.Size(110, 23);
            this.comboBox_tipo_producto.TabIndex = 597;
            this.comboBox_tipo_producto.SelectedValueChanged += new System.EventHandler(this.comboBox_tipo_producto_SelectedValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label6.Location = new System.Drawing.Point(520, 60);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 15);
            this.label6.TabIndex = 609;
            this.label6.Text = "Descontar de";
            // 
            // labelTit
            // 
            this.labelTit.AutoSize = true;
            this.labelTit.BackColor = System.Drawing.Color.Transparent;
            this.labelTit.Font = new System.Drawing.Font("Arial", 15F);
            this.labelTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelTit.Location = new System.Drawing.Point(11, 10);
            this.labelTit.Name = "labelTit";
            this.labelTit.Size = new System.Drawing.Size(232, 23);
            this.labelTit.TabIndex = 615;
            this.labelTit.Text = "Movimiento de Productos";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label14.Location = new System.Drawing.Point(-4, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(775, 23);
            this.label14.TabIndex = 616;
            this.label14.Text = "_________________________________________________________________________________" +
                "_____________________________________________________________________________";
            // 
            // button_terminar
            // 
            this.button_terminar.Location = new System.Drawing.Point(449, 126);
            this.button_terminar.Name = "button_terminar";
            this.button_terminar.Size = new System.Drawing.Size(66, 23);
            this.button_terminar.TabIndex = 617;
            this.button_terminar.Text = "Terminar";
            this.button_terminar.UseVisualStyleBackColor = true;
            this.button_terminar.Click += new System.EventHandler(this.button_terminar_Click);
            // 
            // comboBox_unidades
            // 
            this.comboBox_unidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_unidades.FormattingEnabled = true;
            this.comboBox_unidades.Location = new System.Drawing.Point(275, 126);
            this.comboBox_unidades.Name = "comboBox_unidades";
            this.comboBox_unidades.Size = new System.Drawing.Size(96, 23);
            this.comboBox_unidades.TabIndex = 618;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label4.Location = new System.Drawing.Point(226, 130);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 619;
            this.label4.Text = "Unidad";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::FLXDSK.Properties.Resources.equis;
            this.pictureBox2.Location = new System.Drawing.Point(688, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 614;
            this.pictureBox2.TabStop = false;
            // 
            // Form_Movimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 335);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_unidades);
            this.Controls.Add(this.button_terminar);
            this.Controls.Add(this.labelTit);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_tipo_producto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_requerido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonAgregar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_cantidad);
            this.Controls.Add(this.label_modelo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button_buscar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox_origen);
            this.Controls.Add(this.comboBox_destino);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Movimientos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Catálogo de Movimientos";
            this.Load += new System.EventHandler(this.Form_Movimientos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_destino;
        private System.Windows.Forms.ComboBox comboBox_origen;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox_requerido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAgregar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_cantidad;
        private System.Windows.Forms.Label label_modelo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_tipo_producto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelTit;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button button_terminar;
        private System.Windows.Forms.ComboBox comboBox_unidades;
        private System.Windows.Forms.Label label4;
    }
}