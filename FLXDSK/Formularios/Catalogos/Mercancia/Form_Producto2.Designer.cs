namespace FLXDSK.Formularios.Catalogos.Mercancia
{
    partial class Form_Producto2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Producto2));
            this.labelTit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkcombo = new System.Windows.Forms.CheckBox();
            this.textBox_Costo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label_Utilidad = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton_TipoBebida = new System.Windows.Forms.RadioButton();
            this.radioButton_TipoComida = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button_MedidaSat = new System.Windows.Forms.Button();
            this.button_CodigoSat = new System.Windows.Forms.Button();
            this.checkBox_siIVA = new System.Windows.Forms.CheckBox();
            this.comboBox_Almacen = new System.Windows.Forms.ComboBox();
            this.label_Almacen = new System.Windows.Forms.Label();
            this.label_Leyenda = new System.Windows.Forms.Label();
            this.button_Add_Categorias = new System.Windows.Forms.Button();
            this.textBox_MaximoxMesa = new System.Windows.Forms.TextBox();
            this.label_Maximo = new System.Windows.Forms.Label();
            this.checkBox_Paquete = new System.Windows.Forms.CheckBox();
            this.label_Vence = new System.Windows.Forms.Label();
            this.label_Activo = new System.Windows.Forms.Label();
            this.dateTimePicker_Fin = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_Inicio = new System.Windows.Forms.DateTimePicker();
            this.pictureBox_producto = new System.Windows.Forms.PictureBox();
            this.textBox_Precio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Categoria = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Descripcion = new System.Windows.Forms.TextBox();
            this.textBox_Codigo = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_FijarEnelProducto = new System.Windows.Forms.CheckBox();
            this.label_FCosto = new System.Windows.Forms.Label();
            this.dataGridView_MateriaPrima = new System.Windows.Forms.DataGridView();
            this.boton_buscar = new System.Windows.Forms.Button();
            this.button_borrar = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_producto)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MateriaPrima)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTit
            // 
            this.labelTit.AutoSize = true;
            this.labelTit.BackColor = System.Drawing.Color.Transparent;
            this.labelTit.Font = new System.Drawing.Font("Arial", 15F);
            this.labelTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelTit.Location = new System.Drawing.Point(24, 9);
            this.labelTit.Name = "labelTit";
            this.labelTit.Size = new System.Drawing.Size(212, 23);
            this.labelTit.TabIndex = 450;
            this.labelTit.Text = "Catálogo de Productos";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(-38, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(874, 23);
            this.label1.TabIndex = 451;
            this.label1.Text = "_________________________________________________________________________________" +
    "_______________________________________________";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 49);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(788, 336);
            this.tabControl1.TabIndex = 467;
            // 
            // tabPage1
            // 
            this.tabPage1.CausesValidation = false;
            this.tabPage1.Controls.Add(this.checkcombo);
            this.tabPage1.Controls.Add(this.textBox_Costo);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label_Utilidad);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.button_MedidaSat);
            this.tabPage1.Controls.Add(this.button_CodigoSat);
            this.tabPage1.Controls.Add(this.checkBox_siIVA);
            this.tabPage1.Controls.Add(this.comboBox_Almacen);
            this.tabPage1.Controls.Add(this.label_Almacen);
            this.tabPage1.Controls.Add(this.label_Leyenda);
            this.tabPage1.Controls.Add(this.button_Add_Categorias);
            this.tabPage1.Controls.Add(this.textBox_MaximoxMesa);
            this.tabPage1.Controls.Add(this.label_Maximo);
            this.tabPage1.Controls.Add(this.checkBox_Paquete);
            this.tabPage1.Controls.Add(this.label_Vence);
            this.tabPage1.Controls.Add(this.label_Activo);
            this.tabPage1.Controls.Add(this.dateTimePicker_Fin);
            this.tabPage1.Controls.Add(this.dateTimePicker_Inicio);
            this.tabPage1.Controls.Add(this.pictureBox_producto);
            this.tabPage1.Controls.Add(this.textBox_Precio);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.comboBox_Categoria);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.textBox_Descripcion);
            this.tabPage1.Controls.Add(this.textBox_Codigo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(780, 310);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkcombo
            // 
            this.checkcombo.AutoSize = true;
            this.checkcombo.Location = new System.Drawing.Point(246, 281);
            this.checkcombo.Name = "checkcombo";
            this.checkcombo.Size = new System.Drawing.Size(70, 17);
            this.checkcombo.TabIndex = 618;
            this.checkcombo.Text = "Es Juego";
            this.checkcombo.UseVisualStyleBackColor = true;
            // 
            // textBox_Costo
            // 
            this.textBox_Costo.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Costo.Location = new System.Drawing.Point(601, 21);
            this.textBox_Costo.MaxLength = 11;
            this.textBox_Costo.Name = "textBox_Costo";
            this.textBox_Costo.Size = new System.Drawing.Size(91, 21);
            this.textBox_Costo.TabIndex = 522;
            this.textBox_Costo.Tag = "";
            this.textBox_Costo.TextChanged += new System.EventHandler(this.textBox_Costo_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F);
            this.label8.Location = new System.Drawing.Point(553, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 15);
            this.label8.TabIndex = 523;
            this.label8.Text = "*Costo";
            // 
            // label_Utilidad
            // 
            this.label_Utilidad.Font = new System.Drawing.Font("Arial", 8F);
            this.label_Utilidad.Location = new System.Drawing.Point(695, 23);
            this.label_Utilidad.Name = "label_Utilidad";
            this.label_Utilidad.Size = new System.Drawing.Size(79, 15);
            this.label_Utilidad.TabIndex = 521;
            this.label_Utilidad.Text = "% 0 Utilidad";
            this.label_Utilidad.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton_TipoBebida);
            this.groupBox1.Controls.Add(this.radioButton_TipoComida);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 7F);
            this.groupBox1.Location = new System.Drawing.Point(516, 229);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 38);
            this.groupBox1.TabIndex = 520;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo";
            // 
            // radioButton_TipoBebida
            // 
            this.radioButton_TipoBebida.AutoSize = true;
            this.radioButton_TipoBebida.Location = new System.Drawing.Point(102, 13);
            this.radioButton_TipoBebida.Name = "radioButton_TipoBebida";
            this.radioButton_TipoBebida.Size = new System.Drawing.Size(63, 17);
            this.radioButton_TipoBebida.TabIndex = 522;
            this.radioButton_TipoBebida.Text = "Servicio";
            this.radioButton_TipoBebida.UseVisualStyleBackColor = true;
            // 
            // radioButton_TipoComida
            // 
            this.radioButton_TipoComida.AutoSize = true;
            this.radioButton_TipoComida.Checked = true;
            this.radioButton_TipoComida.Location = new System.Drawing.Point(14, 13);
            this.radioButton_TipoComida.Name = "radioButton_TipoComida";
            this.radioButton_TipoComida.Size = new System.Drawing.Size(52, 17);
            this.radioButton_TipoComida.TabIndex = 521;
            this.radioButton_TipoComida.TabStop = true;
            this.radioButton_TipoComida.Text = "Pieza";
            this.radioButton_TipoComida.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label7.Location = new System.Drawing.Point(434, 81);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 15);
            this.label7.TabIndex = 519;
            this.label7.Text = "*Medida SAT";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 9F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label6.Location = new System.Drawing.Point(159, 81);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 15);
            this.label6.TabIndex = 518;
            this.label6.Text = "*Código SAT";
            // 
            // button_MedidaSat
            // 
            this.button_MedidaSat.FlatAppearance.BorderSize = 0;
            this.button_MedidaSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button_MedidaSat.Location = new System.Drawing.Point(513, 77);
            this.button_MedidaSat.Name = "button_MedidaSat";
            this.button_MedidaSat.Size = new System.Drawing.Size(181, 23);
            this.button_MedidaSat.TabIndex = 517;
            this.button_MedidaSat.Tag = "E48";
            this.button_MedidaSat.Text = "E48 - Unidad de Servicio";
            this.button_MedidaSat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_MedidaSat.UseVisualStyleBackColor = true;
            this.button_MedidaSat.Click += new System.EventHandler(this.button_MedidaSat_Click);
            // 
            // button_CodigoSat
            // 
            this.button_CodigoSat.FlatAppearance.BorderSize = 0;
            this.button_CodigoSat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.button_CodigoSat.Location = new System.Drawing.Point(244, 77);
            this.button_CodigoSat.Name = "button_CodigoSat";
            this.button_CodigoSat.Size = new System.Drawing.Size(181, 23);
            this.button_CodigoSat.TabIndex = 516;
            this.button_CodigoSat.Tag = "01010101";
            this.button_CodigoSat.Text = "01010101 - No existe en el catálogo";
            this.button_CodigoSat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_CodigoSat.UseVisualStyleBackColor = true;
            this.button_CodigoSat.Click += new System.EventHandler(this.button_CodigoSat_Click);
            // 
            // checkBox_siIVA
            // 
            this.checkBox_siIVA.AutoSize = true;
            this.checkBox_siIVA.Location = new System.Drawing.Point(246, 170);
            this.checkBox_siIVA.Name = "checkBox_siIVA";
            this.checkBox_siIVA.Size = new System.Drawing.Size(92, 17);
            this.checkBox_siIVA.TabIndex = 515;
            this.checkBox_siIVA.Text = "I.V.A. Incluido";
            this.checkBox_siIVA.UseVisualStyleBackColor = true;
            // 
            // comboBox_Almacen
            // 
            this.comboBox_Almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Almacen.Font = new System.Drawing.Font("Arial", 9F);
            this.comboBox_Almacen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_Almacen.FormattingEnabled = true;
            this.comboBox_Almacen.Location = new System.Drawing.Point(513, 170);
            this.comboBox_Almacen.Name = "comboBox_Almacen";
            this.comboBox_Almacen.Size = new System.Drawing.Size(181, 23);
            this.comboBox_Almacen.TabIndex = 5;
            this.comboBox_Almacen.Tag = "";
            // 
            // label_Almacen
            // 
            this.label_Almacen.AutoSize = true;
            this.label_Almacen.Font = new System.Drawing.Font("Arial", 9F);
            this.label_Almacen.Location = new System.Drawing.Point(447, 173);
            this.label_Almacen.Name = "label_Almacen";
            this.label_Almacen.Size = new System.Drawing.Size(60, 15);
            this.label_Almacen.TabIndex = 514;
            this.label_Almacen.Text = "*Almacen";
            // 
            // label_Leyenda
            // 
            this.label_Leyenda.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label_Leyenda.Location = new System.Drawing.Point(3, 265);
            this.label_Leyenda.Name = "label_Leyenda";
            this.label_Leyenda.Size = new System.Drawing.Size(261, 13);
            this.label_Leyenda.TabIndex = 494;
            this.label_Leyenda.Text = "Leyenda";
            // 
            // button_Add_Categorias
            // 
            this.button_Add_Categorias.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_Add_Categorias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Add_Categorias.Font = new System.Drawing.Font("Arial", 9F);
            this.button_Add_Categorias.Location = new System.Drawing.Point(700, 49);
            this.button_Add_Categorias.Name = "button_Add_Categorias";
            this.button_Add_Categorias.Size = new System.Drawing.Size(22, 23);
            this.button_Add_Categorias.TabIndex = 508;
            this.button_Add_Categorias.Tag = "8";
            this.button_Add_Categorias.Text = "+";
            this.button_Add_Categorias.UseVisualStyleBackColor = true;
            this.button_Add_Categorias.Click += new System.EventHandler(this.button_Add_Categorias_Click);
            // 
            // textBox_MaximoxMesa
            // 
            this.textBox_MaximoxMesa.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_MaximoxMesa.Location = new System.Drawing.Point(516, 198);
            this.textBox_MaximoxMesa.MaxLength = 10;
            this.textBox_MaximoxMesa.Name = "textBox_MaximoxMesa";
            this.textBox_MaximoxMesa.Size = new System.Drawing.Size(78, 21);
            this.textBox_MaximoxMesa.TabIndex = 12;
            this.textBox_MaximoxMesa.Tag = "";
            // 
            // label_Maximo
            // 
            this.label_Maximo.AutoSize = true;
            this.label_Maximo.Font = new System.Drawing.Font("Arial", 9F);
            this.label_Maximo.Location = new System.Drawing.Point(420, 201);
            this.label_Maximo.Name = "label_Maximo";
            this.label_Maximo.Size = new System.Drawing.Size(86, 15);
            this.label_Maximo.TabIndex = 503;
            this.label_Maximo.Text = "Máximo x Caja";
            // 
            // checkBox_Paquete
            // 
            this.checkBox_Paquete.AutoSize = true;
            this.checkBox_Paquete.Location = new System.Drawing.Point(246, 191);
            this.checkBox_Paquete.Name = "checkBox_Paquete";
            this.checkBox_Paquete.Size = new System.Drawing.Size(103, 17);
            this.checkBox_Paquete.TabIndex = 1;
            this.checkBox_Paquete.Text = "Activar Vigencia";
            this.checkBox_Paquete.UseVisualStyleBackColor = true;
            this.checkBox_Paquete.Visible = false;
            this.checkBox_Paquete.CheckedChanged += new System.EventHandler(this.checkBox_Paquete_CheckedChanged);
            // 
            // label_Vence
            // 
            this.label_Vence.AutoSize = true;
            this.label_Vence.BackColor = System.Drawing.Color.Transparent;
            this.label_Vence.Location = new System.Drawing.Point(202, 247);
            this.label_Vence.Name = "label_Vence";
            this.label_Vence.Size = new System.Drawing.Size(38, 13);
            this.label_Vence.TabIndex = 498;
            this.label_Vence.Text = "Vence";
            this.label_Vence.Visible = false;
            // 
            // label_Activo
            // 
            this.label_Activo.AutoSize = true;
            this.label_Activo.BackColor = System.Drawing.Color.Transparent;
            this.label_Activo.Location = new System.Drawing.Point(203, 218);
            this.label_Activo.Name = "label_Activo";
            this.label_Activo.Size = new System.Drawing.Size(37, 13);
            this.label_Activo.TabIndex = 497;
            this.label_Activo.Text = "Activo";
            this.label_Activo.Visible = false;
            // 
            // dateTimePicker_Fin
            // 
            this.dateTimePicker_Fin.Font = new System.Drawing.Font("Arial", 9F);
            this.dateTimePicker_Fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Fin.Location = new System.Drawing.Point(246, 241);
            this.dateTimePicker_Fin.Name = "dateTimePicker_Fin";
            this.dateTimePicker_Fin.Size = new System.Drawing.Size(141, 21);
            this.dateTimePicker_Fin.TabIndex = 4;
            this.dateTimePicker_Fin.Visible = false;
            // 
            // dateTimePicker_Inicio
            // 
            this.dateTimePicker_Inicio.Font = new System.Drawing.Font("Arial", 9F);
            this.dateTimePicker_Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Inicio.Location = new System.Drawing.Point(246, 214);
            this.dateTimePicker_Inicio.Name = "dateTimePicker_Inicio";
            this.dateTimePicker_Inicio.Size = new System.Drawing.Size(141, 21);
            this.dateTimePicker_Inicio.TabIndex = 3;
            this.dateTimePicker_Inicio.Visible = false;
            // 
            // pictureBox_producto
            // 
            this.pictureBox_producto.BackgroundImage = global::FLXDSK.Properties.Resources.sin_imagen;
            this.pictureBox_producto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox_producto.Location = new System.Drawing.Point(22, 17);
            this.pictureBox_producto.Name = "pictureBox_producto";
            this.pictureBox_producto.Size = new System.Drawing.Size(129, 123);
            this.pictureBox_producto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_producto.TabIndex = 492;
            this.pictureBox_producto.TabStop = false;
            this.pictureBox_producto.Click += new System.EventHandler(this.pictureBox_producto_Click);
            // 
            // textBox_Precio
            // 
            this.textBox_Precio.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Precio.Location = new System.Drawing.Point(425, 21);
            this.textBox_Precio.MaxLength = 11;
            this.textBox_Precio.Name = "textBox_Precio";
            this.textBox_Precio.Size = new System.Drawing.Size(91, 21);
            this.textBox_Precio.TabIndex = 3;
            this.textBox_Precio.Tag = "";
            this.textBox_Precio.TextChanged += new System.EventHandler(this.textBox_Precio_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label2.Location = new System.Drawing.Point(169, 53);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 486;
            this.label2.Text = "*Categoría";
            // 
            // comboBox_Categoria
            // 
            this.comboBox_Categoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Categoria.Font = new System.Drawing.Font("Arial", 9F);
            this.comboBox_Categoria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_Categoria.FormattingEnabled = true;
            this.comboBox_Categoria.Location = new System.Drawing.Point(244, 48);
            this.comboBox_Categoria.Name = "comboBox_Categoria";
            this.comboBox_Categoria.Size = new System.Drawing.Size(450, 23);
            this.comboBox_Categoria.TabIndex = 1;
            this.comboBox_Categoria.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.Location = new System.Drawing.Point(159, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 485;
            this.label4.Text = "*Descripción";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.Location = new System.Drawing.Point(183, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 484;
            this.label3.Text = "*Código";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F);
            this.label5.Location = new System.Drawing.Point(375, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 487;
            this.label5.Text = "*Precio";
            // 
            // textBox_Descripcion
            // 
            this.textBox_Descripcion.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Descripcion.Location = new System.Drawing.Point(243, 106);
            this.textBox_Descripcion.MaxLength = 250;
            this.textBox_Descripcion.Multiline = true;
            this.textBox_Descripcion.Name = "textBox_Descripcion";
            this.textBox_Descripcion.Size = new System.Drawing.Size(451, 55);
            this.textBox_Descripcion.TabIndex = 6;
            this.textBox_Descripcion.Tag = "";
            // 
            // textBox_Codigo
            // 
            this.textBox_Codigo.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Codigo.Location = new System.Drawing.Point(244, 21);
            this.textBox_Codigo.MaxLength = 80;
            this.textBox_Codigo.Name = "textBox_Codigo";
            this.textBox_Codigo.Size = new System.Drawing.Size(118, 21);
            this.textBox_Codigo.TabIndex = 0;
            this.textBox_Codigo.Tag = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.checkBox_FijarEnelProducto);
            this.tabPage2.Controls.Add(this.label_FCosto);
            this.tabPage2.Controls.Add(this.dataGridView_MateriaPrima);
            this.tabPage2.Controls.Add(this.boton_buscar);
            this.tabPage2.Controls.Add(this.button_borrar);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(780, 310);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "composición";
            this.tabPage2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(533, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 24);
            this.button1.TabIndex = 617;
            this.button1.Text = "Producto definido";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_FijarEnelProducto
            // 
            this.checkBox_FijarEnelProducto.AutoSize = true;
            this.checkBox_FijarEnelProducto.Checked = true;
            this.checkBox_FijarEnelProducto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_FijarEnelProducto.Location = new System.Drawing.Point(9, 262);
            this.checkBox_FijarEnelProducto.Name = "checkBox_FijarEnelProducto";
            this.checkBox_FijarEnelProducto.Size = new System.Drawing.Size(117, 17);
            this.checkBox_FijarEnelProducto.TabIndex = 616;
            this.checkBox_FijarEnelProducto.Text = "Fijar en el Producto";
            this.checkBox_FijarEnelProducto.UseVisualStyleBackColor = true;
            this.checkBox_FijarEnelProducto.CheckedChanged += new System.EventHandler(this.checkBox_FijarEnelProducto_CheckedChanged);
            // 
            // label_FCosto
            // 
            this.label_FCosto.BackColor = System.Drawing.Color.DimGray;
            this.label_FCosto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_FCosto.Location = new System.Drawing.Point(652, 261);
            this.label_FCosto.Name = "label_FCosto";
            this.label_FCosto.Size = new System.Drawing.Size(116, 19);
            this.label_FCosto.TabIndex = 615;
            this.label_FCosto.Text = "$ 0.00";
            this.label_FCosto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dataGridView_MateriaPrima
            // 
            this.dataGridView_MateriaPrima.AllowUserToAddRows = false;
            this.dataGridView_MateriaPrima.AllowUserToDeleteRows = false;
            this.dataGridView_MateriaPrima.AllowUserToOrderColumns = true;
            this.dataGridView_MateriaPrima.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView_MateriaPrima.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_MateriaPrima.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView_MateriaPrima.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView_MateriaPrima.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_MateriaPrima.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_MateriaPrima.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_MateriaPrima.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_MateriaPrima.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_MateriaPrima.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView_MateriaPrima.Location = new System.Drawing.Point(8, 41);
            this.dataGridView_MateriaPrima.Name = "dataGridView_MateriaPrima";
            this.dataGridView_MateriaPrima.RowHeadersVisible = false;
            this.dataGridView_MateriaPrima.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F);
            this.dataGridView_MateriaPrima.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_MateriaPrima.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_MateriaPrima.Size = new System.Drawing.Size(761, 218);
            this.dataGridView_MateriaPrima.TabIndex = 614;
            this.dataGridView_MateriaPrima.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_MateriaPrima_CellDoubleClick);
            this.dataGridView_MateriaPrima.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_MateriaPrima_CellEndEdit);
            this.dataGridView_MateriaPrima.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_MateriaPrima_CellEnter);
            this.dataGridView_MateriaPrima.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_MateriaPrima_CellValueChanged);
            // 
            // boton_buscar
            // 
            this.boton_buscar.Font = new System.Drawing.Font("Arial", 9F);
            this.boton_buscar.Location = new System.Drawing.Point(9, 11);
            this.boton_buscar.Name = "boton_buscar";
            this.boton_buscar.Size = new System.Drawing.Size(97, 24);
            this.boton_buscar.TabIndex = 483;
            this.boton_buscar.Text = "Buscar";
            this.boton_buscar.UseVisualStyleBackColor = false;
            this.boton_buscar.Click += new System.EventHandler(this.boton_buscar_Click);
            // 
            // button_borrar
            // 
            this.button_borrar.Font = new System.Drawing.Font("Arial", 9F);
            this.button_borrar.Location = new System.Drawing.Point(671, 11);
            this.button_borrar.Name = "button_borrar";
            this.button_borrar.Size = new System.Drawing.Size(97, 24);
            this.button_borrar.TabIndex = 483;
            this.button_borrar.Text = "Borrar todo";
            this.button_borrar.UseVisualStyleBackColor = false;
            this.button_borrar.Click += new System.EventHandler(this.button_borrar_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label24.Location = new System.Drawing.Point(17, 426);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(296, 13);
            this.label24.TabIndex = 491;
            this.label24.Text = "Nota: Los campos marcados con asterisco (*) son requeridos.";
            // 
            // button_Guardar
            // 
            this.button_Guardar.Font = new System.Drawing.Font("Arial", 9F);
            this.button_Guardar.Location = new System.Drawing.Point(633, 404);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(79, 35);
            this.button_Guardar.TabIndex = 6;
            this.button_Guardar.Tag = "8";
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Font = new System.Drawing.Font("Arial", 9F);
            this.button_Cancelar.Location = new System.Drawing.Point(718, 404);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(79, 35);
            this.button_Cancelar.TabIndex = 7;
            this.button_Cancelar.Tag = "";
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // Form_Producto2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 460);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.labelTit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.button_Cancelar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Producto2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.Form_Producto2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_producto)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_MateriaPrima)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox checkBox_siIVA;
        private System.Windows.Forms.ComboBox comboBox_Almacen;
        private System.Windows.Forms.Label label_Almacen;
        private System.Windows.Forms.Button button_Add_Categorias;
        private System.Windows.Forms.TextBox textBox_MaximoxMesa;
        private System.Windows.Forms.Label label_Maximo;
        private System.Windows.Forms.CheckBox checkBox_Paquete;
        private System.Windows.Forms.Label label_Vence;
        private System.Windows.Forms.Label label_Activo;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Fin;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Inicio;
        private System.Windows.Forms.Label label_Leyenda;
        private System.Windows.Forms.PictureBox pictureBox_producto;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox textBox_Precio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Categoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.TextBox textBox_Descripcion;
        private System.Windows.Forms.TextBox textBox_Codigo;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_borrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_MedidaSat;
        private System.Windows.Forms.Button button_CodigoSat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView_MateriaPrima;
        private System.Windows.Forms.Label label_FCosto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton_TipoBebida;
        private System.Windows.Forms.RadioButton radioButton_TipoComida;
        private System.Windows.Forms.Label label_Utilidad;
        private System.Windows.Forms.TextBox textBox_Costo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox_FijarEnelProducto;
        private System.Windows.Forms.CheckBox checkcombo;
        private System.Windows.Forms.Button boton_buscar;
        private System.Windows.Forms.Button button1;
    }
}