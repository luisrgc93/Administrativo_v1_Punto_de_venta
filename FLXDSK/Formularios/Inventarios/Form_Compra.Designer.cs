namespace FLXDSK.Formularios.Inventarios
{
    partial class Form_Compra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Compra));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_SeleccionarProveedor = new System.Windows.Forms.Label();
            this.label_proveedor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.labelTit = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button_buscar = new System.Windows.Forms.Button();
            this.dataGridView_Lista = new System.Windows.Forms.DataGridView();
            this.button_Crear = new System.Windows.Forms.Button();
            this.checkBox_Pagado = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker_Compra = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Serie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Comentario = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Folio = new System.Windows.Forms.TextBox();
            this.textBox_Total = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_FormaPago = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_TipoCfdi = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_Almacen = new System.Windows.Forms.ComboBox();
            this.textBox_Buscar = new System.Windows.Forms.TextBox();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.label_CargaCFDI = new System.Windows.Forms.Label();
            this.label_CreaProveedor = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lista)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_CreaProveedor);
            this.panel1.Controls.Add(this.label_SeleccionarProveedor);
            this.panel1.Controls.Add(this.label_proveedor);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(16, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 75);
            this.panel1.TabIndex = 612;
            // 
            // label_SeleccionarProveedor
            // 
            this.label_SeleccionarProveedor.AutoSize = true;
            this.label_SeleccionarProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label_SeleccionarProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_SeleccionarProveedor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_SeleccionarProveedor.Location = new System.Drawing.Point(2, 4);
            this.label_SeleccionarProveedor.Name = "label_SeleccionarProveedor";
            this.label_SeleccionarProveedor.Size = new System.Drawing.Size(130, 13);
            this.label_SeleccionarProveedor.TabIndex = 641;
            this.label_SeleccionarProveedor.Text = "[ Seleccionar Proveedor ] ";
            this.label_SeleccionarProveedor.Click += new System.EventHandler(this.label_SeleccionarProveedor_Click);
            // 
            // label_proveedor
            // 
            this.label_proveedor.Location = new System.Drawing.Point(15, 30);
            this.label_proveedor.Name = "label_proveedor";
            this.label_proveedor.Size = new System.Drawing.Size(309, 38);
            this.label_proveedor.TabIndex = 581;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Arial", 9F);
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label7.Size = new System.Drawing.Size(375, 25);
            this.label7.TabIndex = 253;
            this.label7.Text = "Proveedor:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelTit
            // 
            this.labelTit.AutoSize = true;
            this.labelTit.BackColor = System.Drawing.Color.Transparent;
            this.labelTit.Font = new System.Drawing.Font("Arial", 15F);
            this.labelTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelTit.Location = new System.Drawing.Point(12, 9);
            this.labelTit.Name = "labelTit";
            this.labelTit.Size = new System.Drawing.Size(287, 23);
            this.labelTit.TabIndex = 613;
            this.labelTit.Text = "Compra / Ingreso de Productos";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label14.Location = new System.Drawing.Point(-3, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(775, 23);
            this.label14.TabIndex = 614;
            this.label14.Text = "_________________________________________________________________________________" +
    "_____________________________________________________________________________";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F);
            this.label8.Location = new System.Drawing.Point(19, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 617;
            this.label8.Text = "Buscar";
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(624, 217);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(66, 23);
            this.button_buscar.TabIndex = 615;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click_1);
            // 
            // dataGridView_Lista
            // 
            this.dataGridView_Lista.AllowUserToAddRows = false;
            this.dataGridView_Lista.AllowUserToDeleteRows = false;
            this.dataGridView_Lista.AllowUserToResizeColumns = false;
            this.dataGridView_Lista.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView_Lista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_Lista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Lista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Lista.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Lista.Location = new System.Drawing.Point(17, 244);
            this.dataGridView_Lista.Name = "dataGridView_Lista";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Lista.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Lista.RowHeadersVisible = false;
            this.dataGridView_Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView_Lista.Size = new System.Drawing.Size(745, 280);
            this.dataGridView_Lista.TabIndex = 618;
            this.dataGridView_Lista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Lista_CellDoubleClick);
            this.dataGridView_Lista.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Lista_CellEndEdit);
            this.dataGridView_Lista.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Lista_CellValueChanged);
            // 
            // button_Crear
            // 
            this.button_Crear.Location = new System.Drawing.Point(696, 217);
            this.button_Crear.Name = "button_Crear";
            this.button_Crear.Size = new System.Drawing.Size(66, 23);
            this.button_Crear.TabIndex = 619;
            this.button_Crear.Text = "Crear";
            this.button_Crear.UseVisualStyleBackColor = true;
            this.button_Crear.Click += new System.EventHandler(this.button_Crear_Click);
            // 
            // checkBox_Pagado
            // 
            this.checkBox_Pagado.AutoSize = true;
            this.checkBox_Pagado.Location = new System.Drawing.Point(19, 182);
            this.checkBox_Pagado.Name = "checkBox_Pagado";
            this.checkBox_Pagado.Size = new System.Drawing.Size(63, 17);
            this.checkBox_Pagado.TabIndex = 620;
            this.checkBox_Pagado.Text = "Pagada";
            this.checkBox_Pagado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox_Pagado.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Black;
            this.label10.Font = new System.Drawing.Font("Arial", 9F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(553, 528);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(3);
            this.label10.Size = new System.Drawing.Size(65, 25);
            this.label10.TabIndex = 622;
            this.label10.Text = "TOTAL";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker_Compra
            // 
            this.dateTimePicker_Compra.Font = new System.Drawing.Font("Arial", 9F);
            this.dateTimePicker_Compra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_Compra.Location = new System.Drawing.Point(563, 56);
            this.dateTimePicker_Compra.Name = "dateTimePicker_Compra";
            this.dateTimePicker_Compra.Size = new System.Drawing.Size(199, 21);
            this.dateTimePicker_Compra.TabIndex = 623;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(427, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 22);
            this.label2.TabIndex = 624;
            this.label2.Text = "* Fecha Compra";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_Serie
            // 
            this.textBox_Serie.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Serie.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Serie.Location = new System.Drawing.Point(562, 83);
            this.textBox_Serie.MaxLength = 4;
            this.textBox_Serie.Name = "textBox_Serie";
            this.textBox_Serie.Size = new System.Drawing.Size(200, 21);
            this.textBox_Serie.TabIndex = 625;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(427, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 22);
            this.label1.TabIndex = 629;
            this.label1.Text = "Serie";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(427, 110);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 22);
            this.label3.TabIndex = 630;
            this.label3.Text = "Folio";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_Comentario
            // 
            this.textBox_Comentario.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Comentario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Comentario.Location = new System.Drawing.Point(17, 156);
            this.textBox_Comentario.MaxLength = 80;
            this.textBox_Comentario.Name = "textBox_Comentario";
            this.textBox_Comentario.Size = new System.Drawing.Size(376, 21);
            this.textBox_Comentario.TabIndex = 631;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 130);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 22);
            this.label4.TabIndex = 632;
            this.label4.Text = "Comentario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_Folio
            // 
            this.textBox_Folio.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Folio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Folio.Location = new System.Drawing.Point(562, 110);
            this.textBox_Folio.MaxLength = 10;
            this.textBox_Folio.Name = "textBox_Folio";
            this.textBox_Folio.Size = new System.Drawing.Size(200, 21);
            this.textBox_Folio.TabIndex = 627;
            // 
            // textBox_Total
            // 
            this.textBox_Total.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Total.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Total.Location = new System.Drawing.Point(624, 529);
            this.textBox_Total.MaxLength = 11;
            this.textBox_Total.Name = "textBox_Total";
            this.textBox_Total.Size = new System.Drawing.Size(138, 21);
            this.textBox_Total.TabIndex = 633;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label5.Font = new System.Drawing.Font("Arial", 9F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(426, 163);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 637;
            this.label5.Text = "* Forma de Pago";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_FormaPago
            // 
            this.comboBox_FormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FormaPago.Font = new System.Drawing.Font("Arial", 9F);
            this.comboBox_FormaPago.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_FormaPago.FormattingEnabled = true;
            this.comboBox_FormaPago.Items.AddRange(new object[] {
            "Kilo",
            "Litro",
            "Metro",
            "Pieza"});
            this.comboBox_FormaPago.Location = new System.Drawing.Point(562, 162);
            this.comboBox_FormaPago.Name = "comboBox_FormaPago";
            this.comboBox_FormaPago.Size = new System.Drawing.Size(199, 23);
            this.comboBox_FormaPago.TabIndex = 635;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label12.Font = new System.Drawing.Font("Arial", 9F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(426, 139);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 19);
            this.label12.TabIndex = 636;
            this.label12.Text = "* Tipo Comprobante";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_TipoCfdi
            // 
            this.comboBox_TipoCfdi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TipoCfdi.Font = new System.Drawing.Font("Arial", 9F);
            this.comboBox_TipoCfdi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_TipoCfdi.FormattingEnabled = true;
            this.comboBox_TipoCfdi.Location = new System.Drawing.Point(562, 135);
            this.comboBox_TipoCfdi.Name = "comboBox_TipoCfdi";
            this.comboBox_TipoCfdi.Size = new System.Drawing.Size(199, 23);
            this.comboBox_TipoCfdi.TabIndex = 634;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label6.Font = new System.Drawing.Font("Arial", 9F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(426, 190);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(129, 20);
            this.label6.TabIndex = 639;
            this.label6.Text = "* Almacen";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_Almacen
            // 
            this.comboBox_Almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Almacen.Font = new System.Drawing.Font("Arial", 9F);
            this.comboBox_Almacen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_Almacen.FormattingEnabled = true;
            this.comboBox_Almacen.Items.AddRange(new object[] {
            "Kilo",
            "Litro",
            "Metro",
            "Pieza"});
            this.comboBox_Almacen.Location = new System.Drawing.Point(562, 189);
            this.comboBox_Almacen.Name = "comboBox_Almacen";
            this.comboBox_Almacen.Size = new System.Drawing.Size(199, 23);
            this.comboBox_Almacen.TabIndex = 638;
            this.comboBox_Almacen.SelectedValueChanged += new System.EventHandler(this.comboBox_Almacen_SelectedValueChanged);
            // 
            // textBox_Buscar
            // 
            this.textBox_Buscar.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Buscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Buscar.Location = new System.Drawing.Point(71, 218);
            this.textBox_Buscar.Name = "textBox_Buscar";
            this.textBox_Buscar.Size = new System.Drawing.Size(547, 21);
            this.textBox_Buscar.TabIndex = 640;
            this.textBox_Buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Buscar_KeyPress);
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(22, 530);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(70, 28);
            this.button_Guardar.TabIndex = 582;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // label_CargaCFDI
            // 
            this.label_CargaCFDI.AutoSize = true;
            this.label_CargaCFDI.BackColor = System.Drawing.SystemColors.Control;
            this.label_CargaCFDI.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_CargaCFDI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label_CargaCFDI.Location = new System.Drawing.Point(669, 13);
            this.label_CargaCFDI.Name = "label_CargaCFDI";
            this.label_CargaCFDI.Size = new System.Drawing.Size(92, 13);
            this.label_CargaCFDI.TabIndex = 642;
            this.label_CargaCFDI.Text = "[ Examinar CFDI ] ";
            this.label_CargaCFDI.Click += new System.EventHandler(this.label_CargaCFDI_Click);
            // 
            // label_CreaProveedor
            // 
            this.label_CreaProveedor.AutoSize = true;
            this.label_CreaProveedor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label_CreaProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_CreaProveedor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_CreaProveedor.Location = new System.Drawing.Point(324, 4);
            this.label_CreaProveedor.Name = "label_CreaProveedor";
            this.label_CreaProveedor.Size = new System.Drawing.Size(47, 13);
            this.label_CreaProveedor.TabIndex = 642;
            this.label_CreaProveedor.Text = "[ Crear ] ";
            this.label_CreaProveedor.Click += new System.EventHandler(this.label_CreaProveedor_Click);
            // 
            // Form_Compra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 562);
            this.Controls.Add(this.label_CargaCFDI);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.textBox_Buscar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox_Almacen);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_FormaPago);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBox_TipoCfdi);
            this.Controls.Add(this.textBox_Total);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Comentario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Folio);
            this.Controls.Add(this.textBox_Serie);
            this.Controls.Add(this.dateTimePicker_Compra);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.checkBox_Pagado);
            this.Controls.Add(this.button_Crear);
            this.Controls.Add(this.dataGridView_Lista);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_buscar);
            this.Controls.Add(this.labelTit);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Compra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compra";
            this.Load += new System.EventHandler(this.Form_Compra_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_proveedor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelTit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.DataGridView dataGridView_Lista;
        private System.Windows.Forms.Button button_Crear;
        private System.Windows.Forms.CheckBox checkBox_Pagado;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker_Compra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Serie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Comentario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Folio;
        private System.Windows.Forms.TextBox textBox_Total;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_FormaPago;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_TipoCfdi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_Almacen;
        private System.Windows.Forms.TextBox textBox_Buscar;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Label label_SeleccionarProveedor;
        private System.Windows.Forms.Label label_CargaCFDI;
        private System.Windows.Forms.Label label_CreaProveedor;
    }
}