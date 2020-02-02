namespace FLXDSK.Formularios.Ventas
{
    partial class Form_CobrarVenta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_CobrarVenta));
            this.label_titulo = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_NoPedido = new System.Windows.Forms.TextBox();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Efectivo = new System.Windows.Forms.TextBox();
            this.textBox_CreditoTC = new System.Windows.Forms.TextBox();
            this.textBox_DebitoT = new System.Windows.Forms.TextBox();
            this.textBox_Vales = new System.Windows.Forms.TextBox();
            this.textBox_Cheque = new System.Windows.Forms.TextBox();
            this.textBox_Otro = new System.Windows.Forms.TextBox();
            this.label_Subtotal = new System.Windows.Forms.Label();
            this.label_Descuento = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label_Total = new System.Windows.Forms.Label();
            this.label_Cambio = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button_Terminar = new System.Windows.Forms.Button();
            this.label_Resta = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_Propina = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_titulo
            // 
            this.label_titulo.AutoSize = true;
            this.label_titulo.BackColor = System.Drawing.Color.Transparent;
            this.label_titulo.Font = new System.Drawing.Font("Arial", 15F);
            this.label_titulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label_titulo.Location = new System.Drawing.Point(10, 9);
            this.label_titulo.Name = "label_titulo";
            this.label_titulo.Size = new System.Drawing.Size(129, 23);
            this.label_titulo.TabIndex = 506;
            this.label_titulo.Text = "Pago Pedido:";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label14.Location = new System.Drawing.Point(2, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(421, 18);
            this.label14.TabIndex = 507;
            this.label14.Text = "_________________________________________________________________________________" +
    "_____________________________________________________________________________";
            // 
            // textBox_NoPedido
            // 
            this.textBox_NoPedido.Font = new System.Drawing.Font("Arial", 12F);
            this.textBox_NoPedido.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_NoPedido.Location = new System.Drawing.Point(145, 9);
            this.textBox_NoPedido.MaxLength = 20;
            this.textBox_NoPedido.Name = "textBox_NoPedido";
            this.textBox_NoPedido.Size = new System.Drawing.Size(161, 26);
            this.textBox_NoPedido.TabIndex = 0;
            this.textBox_NoPedido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_NoPedido_KeyPress);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(312, 10);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_Cancelar.TabIndex = 9;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label1.Location = new System.Drawing.Point(11, 355);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(421, 18);
            this.label1.TabIndex = 528;
            this.label1.Text = "_________________________________________________________________________________" +
    "_____________________________________________________________________________";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label9.Font = new System.Drawing.Font("Arial", 12F);
            this.label9.ForeColor = System.Drawing.SystemColors.Window;
            this.label9.Location = new System.Drawing.Point(44, 155);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(3);
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(155, 25);
            this.label9.TabIndex = 556;
            this.label9.Text = "Efectivo";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label2.Font = new System.Drawing.Font("Arial", 12F);
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(44, 188);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(155, 25);
            this.label2.TabIndex = 557;
            this.label2.Text = "Tarjeta de Crédito";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(44, 222);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3);
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(155, 25);
            this.label3.TabIndex = 558;
            this.label3.Text = "Tarjeta de Débito";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(44, 255);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(3);
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(155, 25);
            this.label4.TabIndex = 559;
            this.label4.Text = "Vales";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label5.Font = new System.Drawing.Font("Arial", 12F);
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(44, 287);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(3);
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(155, 25);
            this.label5.TabIndex = 560;
            this.label5.Text = "Cheque";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label6.Font = new System.Drawing.Font("Arial", 12F);
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(44, 321);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(3);
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(155, 25);
            this.label6.TabIndex = 561;
            this.label6.Text = "Otro";
            // 
            // textBox_Efectivo
            // 
            this.textBox_Efectivo.Font = new System.Drawing.Font("Arial", 12F);
            this.textBox_Efectivo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Efectivo.Location = new System.Drawing.Point(205, 154);
            this.textBox_Efectivo.MaxLength = 20;
            this.textBox_Efectivo.Name = "textBox_Efectivo";
            this.textBox_Efectivo.Size = new System.Drawing.Size(161, 26);
            this.textBox_Efectivo.TabIndex = 1;
            this.textBox_Efectivo.TextChanged += new System.EventHandler(this.textBox_Efectivo_TextChanged);
            this.textBox_Efectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Efectivo_KeyPress);
            // 
            // textBox_CreditoTC
            // 
            this.textBox_CreditoTC.Font = new System.Drawing.Font("Arial", 12F);
            this.textBox_CreditoTC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_CreditoTC.Location = new System.Drawing.Point(205, 188);
            this.textBox_CreditoTC.MaxLength = 20;
            this.textBox_CreditoTC.Name = "textBox_CreditoTC";
            this.textBox_CreditoTC.Size = new System.Drawing.Size(161, 26);
            this.textBox_CreditoTC.TabIndex = 2;
            this.textBox_CreditoTC.TextChanged += new System.EventHandler(this.textBox_CreditoTC_TextChanged);
            this.textBox_CreditoTC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_CreditoTC_KeyPress);
            // 
            // textBox_DebitoT
            // 
            this.textBox_DebitoT.Font = new System.Drawing.Font("Arial", 12F);
            this.textBox_DebitoT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_DebitoT.Location = new System.Drawing.Point(205, 221);
            this.textBox_DebitoT.MaxLength = 20;
            this.textBox_DebitoT.Name = "textBox_DebitoT";
            this.textBox_DebitoT.Size = new System.Drawing.Size(161, 26);
            this.textBox_DebitoT.TabIndex = 3;
            this.textBox_DebitoT.TextChanged += new System.EventHandler(this.textBox_DebitoT_TextChanged);
            this.textBox_DebitoT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_DebitoT_KeyPress);
            // 
            // textBox_Vales
            // 
            this.textBox_Vales.Font = new System.Drawing.Font("Arial", 12F);
            this.textBox_Vales.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Vales.Location = new System.Drawing.Point(205, 255);
            this.textBox_Vales.MaxLength = 20;
            this.textBox_Vales.Name = "textBox_Vales";
            this.textBox_Vales.Size = new System.Drawing.Size(161, 26);
            this.textBox_Vales.TabIndex = 4;
            this.textBox_Vales.TextChanged += new System.EventHandler(this.textBox_Vales_TextChanged);
            this.textBox_Vales.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Vales_KeyPress);
            // 
            // textBox_Cheque
            // 
            this.textBox_Cheque.Font = new System.Drawing.Font("Arial", 12F);
            this.textBox_Cheque.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Cheque.Location = new System.Drawing.Point(205, 286);
            this.textBox_Cheque.MaxLength = 20;
            this.textBox_Cheque.Name = "textBox_Cheque";
            this.textBox_Cheque.Size = new System.Drawing.Size(161, 26);
            this.textBox_Cheque.TabIndex = 5;
            this.textBox_Cheque.TextChanged += new System.EventHandler(this.textBox_Cheque_TextChanged);
            this.textBox_Cheque.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Cheque_KeyPress);
            // 
            // textBox_Otro
            // 
            this.textBox_Otro.Font = new System.Drawing.Font("Arial", 12F);
            this.textBox_Otro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Otro.Location = new System.Drawing.Point(205, 321);
            this.textBox_Otro.MaxLength = 20;
            this.textBox_Otro.Name = "textBox_Otro";
            this.textBox_Otro.Size = new System.Drawing.Size(161, 26);
            this.textBox_Otro.TabIndex = 6;
            this.textBox_Otro.TextChanged += new System.EventHandler(this.textBox_Otro_TextChanged);
            this.textBox_Otro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Otro_KeyPress);
            // 
            // label_Subtotal
            // 
            this.label_Subtotal.BackColor = System.Drawing.Color.Transparent;
            this.label_Subtotal.Font = new System.Drawing.Font("Arial", 10F);
            this.label_Subtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label_Subtotal.Location = new System.Drawing.Point(203, 63);
            this.label_Subtotal.Name = "label_Subtotal";
            this.label_Subtotal.Size = new System.Drawing.Size(161, 23);
            this.label_Subtotal.TabIndex = 568;
            this.label_Subtotal.Text = "0.00";
            this.label_Subtotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Descuento
            // 
            this.label_Descuento.BackColor = System.Drawing.Color.Transparent;
            this.label_Descuento.Font = new System.Drawing.Font("Arial", 10F);
            this.label_Descuento.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label_Descuento.Location = new System.Drawing.Point(205, 91);
            this.label_Descuento.Name = "label_Descuento";
            this.label_Descuento.Size = new System.Drawing.Size(159, 23);
            this.label_Descuento.TabIndex = 569;
            this.label_Descuento.Text = "0.00";
            this.label_Descuento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label8.Font = new System.Drawing.Font("Arial", 12F);
            this.label8.ForeColor = System.Drawing.SystemColors.Window;
            this.label8.Location = new System.Drawing.Point(43, 61);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(3);
            this.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label8.Size = new System.Drawing.Size(155, 25);
            this.label8.TabIndex = 570;
            this.label8.Text = "SubTotal";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label10.Font = new System.Drawing.Font("Arial", 12F);
            this.label10.ForeColor = System.Drawing.SystemColors.Window;
            this.label10.Location = new System.Drawing.Point(44, 90);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(3);
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(155, 25);
            this.label10.TabIndex = 571;
            this.label10.Text = "Descuento";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label11.Font = new System.Drawing.Font("Arial", 12F);
            this.label11.ForeColor = System.Drawing.SystemColors.Window;
            this.label11.Location = new System.Drawing.Point(43, 119);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(3);
            this.label11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label11.Size = new System.Drawing.Size(155, 25);
            this.label11.TabIndex = 572;
            this.label11.Text = "Total";
            // 
            // label_Total
            // 
            this.label_Total.BackColor = System.Drawing.Color.Transparent;
            this.label_Total.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label_Total.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label_Total.Location = new System.Drawing.Point(205, 120);
            this.label_Total.Name = "label_Total";
            this.label_Total.Size = new System.Drawing.Size(159, 23);
            this.label_Total.TabIndex = 573;
            this.label_Total.Text = "0.00";
            this.label_Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_Cambio
            // 
            this.label_Cambio.BackColor = System.Drawing.Color.Transparent;
            this.label_Cambio.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label_Cambio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label_Cambio.Location = new System.Drawing.Point(207, 407);
            this.label_Cambio.Name = "label_Cambio";
            this.label_Cambio.Size = new System.Drawing.Size(159, 23);
            this.label_Cambio.TabIndex = 575;
            this.label_Cambio.Text = "0.00";
            this.label_Cambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label12.Font = new System.Drawing.Font("Arial", 12F);
            this.label12.ForeColor = System.Drawing.SystemColors.Window;
            this.label12.Location = new System.Drawing.Point(45, 406);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(3);
            this.label12.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label12.Size = new System.Drawing.Size(155, 25);
            this.label12.TabIndex = 574;
            this.label12.Text = "Cambio";
            // 
            // button_Terminar
            // 
            this.button_Terminar.Location = new System.Drawing.Point(206, 473);
            this.button_Terminar.Name = "button_Terminar";
            this.button_Terminar.Size = new System.Drawing.Size(161, 40);
            this.button_Terminar.TabIndex = 8;
            this.button_Terminar.Text = "Terminar";
            this.button_Terminar.UseVisualStyleBackColor = true;
            this.button_Terminar.Click += new System.EventHandler(this.button_Terminar_Click);
            // 
            // label_Resta
            // 
            this.label_Resta.BackColor = System.Drawing.Color.Transparent;
            this.label_Resta.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.label_Resta.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label_Resta.Location = new System.Drawing.Point(207, 376);
            this.label_Resta.Name = "label_Resta";
            this.label_Resta.Size = new System.Drawing.Size(159, 23);
            this.label_Resta.TabIndex = 578;
            this.label_Resta.Text = "0.00";
            this.label_Resta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label13.Font = new System.Drawing.Font("Arial", 12F);
            this.label13.ForeColor = System.Drawing.SystemColors.Window;
            this.label13.Location = new System.Drawing.Point(45, 375);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(3);
            this.label13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label13.Size = new System.Drawing.Size(155, 25);
            this.label13.TabIndex = 577;
            this.label13.Text = "Resta";
            // 
            // textBox_Propina
            // 
            this.textBox_Propina.Font = new System.Drawing.Font("Arial", 12F);
            this.textBox_Propina.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Propina.Location = new System.Drawing.Point(206, 437);
            this.textBox_Propina.MaxLength = 20;
            this.textBox_Propina.Name = "textBox_Propina";
            this.textBox_Propina.Size = new System.Drawing.Size(161, 26);
            this.textBox_Propina.TabIndex = 7;
            this.textBox_Propina.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Propina_KeyPress);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label7.Font = new System.Drawing.Font("Arial", 12F);
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(45, 437);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(3);
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(155, 25);
            this.label7.TabIndex = 579;
            this.label7.Text = "Propina";
            // 
            // Form_CobrarVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(438, 527);
            this.Controls.Add(this.textBox_Propina);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label_Resta);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button_Terminar);
            this.Controls.Add(this.label_Cambio);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label_Total);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label_Descuento);
            this.Controls.Add(this.label_Subtotal);
            this.Controls.Add(this.textBox_Otro);
            this.Controls.Add(this.textBox_Cheque);
            this.Controls.Add(this.textBox_Vales);
            this.Controls.Add(this.textBox_DebitoT);
            this.Controls.Add(this.textBox_CreditoTC);
            this.Controls.Add(this.textBox_Efectivo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.textBox_NoPedido);
            this.Controls.Add(this.label_titulo);
            this.Controls.Add(this.label14);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_CobrarVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cobrar Venta";
            this.Load += new System.EventHandler(this.Form_CobrarVenta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_titulo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_NoPedido;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Efectivo;
        private System.Windows.Forms.TextBox textBox_CreditoTC;
        private System.Windows.Forms.TextBox textBox_DebitoT;
        private System.Windows.Forms.TextBox textBox_Vales;
        private System.Windows.Forms.TextBox textBox_Cheque;
        private System.Windows.Forms.TextBox textBox_Otro;
        private System.Windows.Forms.Label label_Subtotal;
        private System.Windows.Forms.Label label_Descuento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_Total;
        private System.Windows.Forms.Label label_Cambio;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button_Terminar;
        private System.Windows.Forms.Label label_Resta;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_Propina;
        private System.Windows.Forms.Label label7;
    }
}