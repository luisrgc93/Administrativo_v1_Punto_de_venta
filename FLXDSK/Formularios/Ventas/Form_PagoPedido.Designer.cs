namespace FLXDSK.Formularios.Ventas
{
    partial class Form_PagoPedido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label_Numpedido = new System.Windows.Forms.Label();
            this.comboBox_FormaPago = new System.Windows.Forms.ComboBox();
            this.textBox_Subtotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Descuento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label_titulo = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label_AreaMesa = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label_nombre = new System.Windows.Forms.Label();
            this.label_idMesero = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel_pago = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_TarjetaCredito = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Propina = new System.Windows.Forms.TextBox();
            this.textBox_comentario = new System.Windows.Forms.TextBox();
            this.button_agregarPago = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox_monto = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label_restante = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_pagos = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.button_Terminar = new System.Windows.Forms.Button();
            this.label_total = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel_pago.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Numpedido
            // 
            this.label_Numpedido.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Numpedido.Location = new System.Drawing.Point(146, 11);
            this.label_Numpedido.Name = "label_Numpedido";
            this.label_Numpedido.Size = new System.Drawing.Size(124, 18);
            this.label_Numpedido.TabIndex = 1;
            this.label_Numpedido.Text = "1";
            // 
            // comboBox_FormaPago
            // 
            this.comboBox_FormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FormaPago.FormattingEnabled = true;
            this.comboBox_FormaPago.Location = new System.Drawing.Point(110, 7);
            this.comboBox_FormaPago.Name = "comboBox_FormaPago";
            this.comboBox_FormaPago.Size = new System.Drawing.Size(137, 21);
            this.comboBox_FormaPago.TabIndex = 9;
            this.comboBox_FormaPago.SelectedValueChanged += new System.EventHandler(this.comboBox_MetodoPago_SelectedValueChanged);
            // 
            // textBox_Subtotal
            // 
            this.textBox_Subtotal.Location = new System.Drawing.Point(469, 9);
            this.textBox_Subtotal.Name = "textBox_Subtotal";
            this.textBox_Subtotal.ReadOnly = true;
            this.textBox_Subtotal.Size = new System.Drawing.Size(74, 20);
            this.textBox_Subtotal.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(408, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Subtotal:";
            // 
            // textBox_Descuento
            // 
            this.textBox_Descuento.Location = new System.Drawing.Point(328, 9);
            this.textBox_Descuento.Name = "textBox_Descuento";
            this.textBox_Descuento.ReadOnly = true;
            this.textBox_Descuento.Size = new System.Drawing.Size(74, 20);
            this.textBox_Descuento.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(252, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Descuento:";
            // 
            // label_titulo
            // 
            this.label_titulo.AutoSize = true;
            this.label_titulo.BackColor = System.Drawing.Color.Transparent;
            this.label_titulo.Font = new System.Drawing.Font("Arial", 15F);
            this.label_titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label_titulo.Location = new System.Drawing.Point(11, 7);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(129, 23);
            this.label_titulo.TabIndex = 503;
            this.label_titulo.Text = "Pago Pedido:";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label14.Location = new System.Drawing.Point(12, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(716, 18);
            this.label14.TabIndex = 504;
            this.label14.Text = "_________________________________________________________________________________" +
    "_____________________________________________________________________________";
            // 
            // label_AreaMesa
            // 
            this.label_AreaMesa.BackColor = System.Drawing.SystemColors.Window;
            this.label_AreaMesa.Font = new System.Drawing.Font("Arial", 9F);
            this.label_AreaMesa.Location = new System.Drawing.Point(500, 60);
            this.label_AreaMesa.Name = "label_AreaMesa";
            this.label_AreaMesa.Padding = new System.Windows.Forms.Padding(3);
            this.label_AreaMesa.Size = new System.Drawing.Size(206, 25);
            this.label_AreaMesa.TabIndex = 556;
            this.label_AreaMesa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label9.Font = new System.Drawing.Font("Arial", 9F);
            this.label9.ForeColor = System.Drawing.SystemColors.Window;
            this.label9.Location = new System.Drawing.Point(420, 60);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(3);
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(74, 25);
            this.label9.TabIndex = 555;
            this.label9.Text = "Ubicación";
            // 
            // label_nombre
            // 
            this.label_nombre.BackColor = System.Drawing.SystemColors.Window;
            this.label_nombre.Font = new System.Drawing.Font("Arial", 9F);
            this.label_nombre.Location = new System.Drawing.Point(89, 60);
            this.label_nombre.Name = "label_nombre";
            this.label_nombre.Padding = new System.Windows.Forms.Padding(3);
            this.label_nombre.Size = new System.Drawing.Size(325, 25);
            this.label_nombre.TabIndex = 550;
            this.label_nombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_idMesero
            // 
            this.label_idMesero.BackColor = System.Drawing.SystemColors.Window;
            this.label_idMesero.Font = new System.Drawing.Font("Arial", 9F);
            this.label_idMesero.Location = new System.Drawing.Point(524, 448);
            this.label_idMesero.Name = "label_idMesero";
            this.label_idMesero.Padding = new System.Windows.Forms.Padding(3);
            this.label_idMesero.Size = new System.Drawing.Size(31, 25);
            this.label_idMesero.TabIndex = 549;
            this.label_idMesero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_idMesero.Visible = false;
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label33.Font = new System.Drawing.Font("Arial", 9F);
            this.label33.ForeColor = System.Drawing.SystemColors.Window;
            this.label33.Location = new System.Drawing.Point(490, 448);
            this.label33.Name = "label33";
            this.label33.Padding = new System.Windows.Forms.Padding(3);
            this.label33.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label33.Size = new System.Drawing.Size(28, 25);
            this.label33.TabIndex = 547;
            this.label33.Text = "ID";
            this.label33.Visible = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label10.Font = new System.Drawing.Font("Arial", 9F);
            this.label10.ForeColor = System.Drawing.SystemColors.Window;
            this.label10.Location = new System.Drawing.Point(16, 60);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(3);
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(67, 25);
            this.label10.TabIndex = 548;
            this.label10.Text = "Mesero";
            // 
            // panel_pago
            // 
            this.panel_pago.Controls.Add(this.label4);
            this.panel_pago.Controls.Add(this.textBox_TarjetaCredito);
            this.panel_pago.Controls.Add(this.label1);
            this.panel_pago.Controls.Add(this.textBox_Propina);
            this.panel_pago.Controls.Add(this.textBox_comentario);
            this.panel_pago.Controls.Add(this.button_agregarPago);
            this.panel_pago.Controls.Add(this.label11);
            this.panel_pago.Controls.Add(this.label12);
            this.panel_pago.Controls.Add(this.label15);
            this.panel_pago.Controls.Add(this.textBox_monto);
            this.panel_pago.Controls.Add(this.comboBox_FormaPago);
            this.panel_pago.Controls.Add(this.label3);
            this.panel_pago.Controls.Add(this.textBox_Descuento);
            this.panel_pago.Controls.Add(this.label2);
            this.panel_pago.Controls.Add(this.textBox_Subtotal);
            this.panel_pago.Location = new System.Drawing.Point(14, 98);
            this.panel_pago.Name = "panel_pago";
            this.panel_pago.Size = new System.Drawing.Size(698, 113);
            this.panel_pago.TabIndex = 559;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 15);
            this.label4.TabIndex = 542;
            this.label4.Text = "Nombre Tarjeta";
            // 
            // textBox_TarjetaCredito
            // 
            this.textBox_TarjetaCredito.Location = new System.Drawing.Point(110, 31);
            this.textBox_TarjetaCredito.Name = "textBox_TarjetaCredito";
            this.textBox_TarjetaCredito.ReadOnly = true;
            this.textBox_TarjetaCredito.Size = new System.Drawing.Size(137, 20);
            this.textBox_TarjetaCredito.TabIndex = 543;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(546, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 540;
            this.label1.Text = "Propina:";
            // 
            // textBox_Propina
            // 
            this.textBox_Propina.Location = new System.Drawing.Point(606, 8);
            this.textBox_Propina.Name = "textBox_Propina";
            this.textBox_Propina.Size = new System.Drawing.Size(85, 20);
            this.textBox_Propina.TabIndex = 541;
            this.textBox_Propina.TextChanged += new System.EventHandler(this.textBox_Propina_TextChanged);
            this.textBox_Propina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Propina_KeyPress);
            // 
            // textBox_comentario
            // 
            this.textBox_comentario.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_comentario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_comentario.Location = new System.Drawing.Point(93, 64);
            this.textBox_comentario.Multiline = true;
            this.textBox_comentario.Name = "textBox_comentario";
            this.textBox_comentario.Size = new System.Drawing.Size(450, 43);
            this.textBox_comentario.TabIndex = 525;
            // 
            // button_agregarPago
            // 
            this.button_agregarPago.Location = new System.Drawing.Point(581, 67);
            this.button_agregarPago.Name = "button_agregarPago";
            this.button_agregarPago.Size = new System.Drawing.Size(109, 32);
            this.button_agregarPago.TabIndex = 539;
            this.button_agregarPago.Text = "Agregar pago";
            this.button_agregarPago.UseVisualStyleBackColor = true;
            this.button_agregarPago.Click += new System.EventHandler(this.button_agregarPago_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 9F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label11.Location = new System.Drawing.Point(14, 63);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 15);
            this.label11.TabIndex = 524;
            this.label11.Text = "Comentario";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial", 9F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label12.Location = new System.Drawing.Point(4, 6);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 15);
            this.label12.TabIndex = 527;
            this.label12.Text = "* Forma de Pago";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Arial", 9F);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label15.Location = new System.Drawing.Point(549, 42);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 15);
            this.label15.TabIndex = 529;
            this.label15.Text = "Pago ($)";
            // 
            // textBox_monto
            // 
            this.textBox_monto.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_monto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_monto.Location = new System.Drawing.Point(604, 36);
            this.textBox_monto.Name = "textBox_monto";
            this.textBox_monto.Size = new System.Drawing.Size(85, 21);
            this.textBox_monto.TabIndex = 528;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label24.Location = new System.Drawing.Point(12, 551);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(296, 13);
            this.label24.TabIndex = 560;
            this.label24.Text = "Nota: Los campos marcados con asterisco (*) son requeridos.";
            // 
            // label_restante
            // 
            this.label_restante.BackColor = System.Drawing.SystemColors.Window;
            this.label_restante.Font = new System.Drawing.Font("Arial", 9F);
            this.label_restante.Location = new System.Drawing.Point(611, 507);
            this.label_restante.Name = "label_restante";
            this.label_restante.Padding = new System.Windows.Forms.Padding(3);
            this.label_restante.Size = new System.Drawing.Size(93, 25);
            this.label_restante.TabIndex = 567;
            this.label_restante.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label7.Font = new System.Drawing.Font("Arial", 9F);
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(478, 507);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(3);
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(117, 25);
            this.label7.TabIndex = 566;
            this.label7.Text = "Restante";
            // 
            // label_pagos
            // 
            this.label_pagos.BackColor = System.Drawing.SystemColors.Window;
            this.label_pagos.Font = new System.Drawing.Font("Arial", 9F);
            this.label_pagos.Location = new System.Drawing.Point(611, 477);
            this.label_pagos.Name = "label_pagos";
            this.label_pagos.Padding = new System.Windows.Forms.Padding(3);
            this.label_pagos.Size = new System.Drawing.Size(93, 25);
            this.label_pagos.TabIndex = 565;
            this.label_pagos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label16.Font = new System.Drawing.Font("Arial", 9F);
            this.label16.ForeColor = System.Drawing.SystemColors.Window;
            this.label16.Location = new System.Drawing.Point(478, 477);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(3);
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label16.Size = new System.Drawing.Size(117, 25);
            this.label16.TabIndex = 564;
            this.label16.Text = "Suma de Pagos";
            // 
            // button_Terminar
            // 
            this.button_Terminar.Location = new System.Drawing.Point(615, 540);
            this.button_Terminar.Name = "button_Terminar";
            this.button_Terminar.Size = new System.Drawing.Size(90, 34);
            this.button_Terminar.TabIndex = 563;
            this.button_Terminar.Text = "Terminar";
            this.button_Terminar.UseVisualStyleBackColor = true;
            this.button_Terminar.Click += new System.EventHandler(this.button_Terminar_Click);
            // 
            // label_total
            // 
            this.label_total.BackColor = System.Drawing.SystemColors.Window;
            this.label_total.Font = new System.Drawing.Font("Arial", 9F);
            this.label_total.Location = new System.Drawing.Point(611, 448);
            this.label_total.Name = "label_total";
            this.label_total.Padding = new System.Windows.Forms.Padding(3);
            this.label_total.Size = new System.Drawing.Size(93, 25);
            this.label_total.TabIndex = 562;
            this.label_total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label17.Font = new System.Drawing.Font("Arial", 9F);
            this.label17.ForeColor = System.Drawing.SystemColors.Window;
            this.label17.Location = new System.Drawing.Point(478, 448);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(3);
            this.label17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label17.Size = new System.Drawing.Size(117, 25);
            this.label17.TabIndex = 561;
            this.label17.Text = "Total de la venta";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial Narrow", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 251);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(694, 191);
            this.dataGridView1.TabIndex = 568;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label5.Font = new System.Drawing.Font("Arial", 9F);
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(10, 226);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(3);
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(696, 25);
            this.label5.TabIndex = 570;
            this.label5.Text = "Historial de Pagos";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::FLXDSK.Properties.Resources.equis;
            this.pictureBox2.Location = new System.Drawing.Point(682, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 502;
            this.pictureBox2.TabStop = false;
            // 
            // Form_PagoPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 584);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label_restante);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_pagos);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.button_Terminar);
            this.Controls.Add(this.label_total);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.panel_pago);
            this.Controls.Add(this.label_AreaMesa);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label_nombre);
            this.Controls.Add(this.label_idMesero);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label_titulo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label_Numpedido);
            this.MaximizeBox = false;
            this.Name = "Form_PagoPedido";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago del Pedido";
            this.Load += new System.EventHandler(this.Form_PagoPedido_Load);
            this.panel_pago.ResumeLayout(false);
            this.panel_pago.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Numpedido;
        private System.Windows.Forms.ComboBox comboBox_FormaPago;
        private System.Windows.Forms.TextBox textBox_Subtotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Descuento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label_AreaMesa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label_nombre;
        private System.Windows.Forms.Label label_idMesero;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel_pago;
        private System.Windows.Forms.TextBox textBox_comentario;
        private System.Windows.Forms.Button button_agregarPago;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox_monto;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label_restante;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_pagos;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button button_Terminar;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Propina;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_TarjetaCredito;
    }
}