namespace FLXDSK.Formularios.Facturacion
{
    partial class Form_FacTicket
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label_RFC_Emisor = new System.Windows.Forms.Label();
            this.label_RazonEmisor = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_SelectCliente = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label_razon = new System.Windows.Forms.Label();
            this.label_rfc = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Comentario = new System.Windows.Forms.TextBox();
            this.comboBox_Uso = new System.Windows.Forms.ComboBox();
            this.comboBox_MetodoPago = new System.Windows.Forms.ComboBox();
            this.comboBox_FormaPago = new System.Windows.Forms.ComboBox();
            this.comboBox_Moneda = new System.Windows.Forms.ComboBox();
            this.comboBox_Serie = new System.Windows.Forms.ComboBox();
            this.comboBox_TipoCFDI = new System.Windows.Forms.ComboBox();
            this.dataGridView_Lista = new System.Windows.Forms.DataGridView();
            this.button_Generar = new System.Windows.Forms.Button();
            this.label_total = new System.Windows.Forms.Label();
            this.label_IVA = new System.Windows.Forms.Label();
            this.label_Subtotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lista)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label_RFC_Emisor);
            this.panel1.Controls.Add(this.label_RazonEmisor);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 111);
            this.panel1.TabIndex = 350;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("Arial", 10F);
            this.label10.ForeColor = System.Drawing.SystemColors.Window;
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label10.Size = new System.Drawing.Size(392, 22);
            this.label10.TabIndex = 253;
            this.label10.Text = "Emisor:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_RFC_Emisor
            // 
            this.label_RFC_Emisor.AutoSize = true;
            this.label_RFC_Emisor.Font = new System.Drawing.Font("Arial", 9F);
            this.label_RFC_Emisor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label_RFC_Emisor.Location = new System.Drawing.Point(4, 26);
            this.label_RFC_Emisor.Name = "label_RFC_Emisor";
            this.label_RFC_Emisor.Size = new System.Drawing.Size(32, 15);
            this.label_RFC_Emisor.TabIndex = 210;
            this.label_RFC_Emisor.Text = "RFC";
            // 
            // label_RazonEmisor
            // 
            this.label_RazonEmisor.AutoSize = true;
            this.label_RazonEmisor.Font = new System.Drawing.Font("Arial", 9F);
            this.label_RazonEmisor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label_RazonEmisor.Location = new System.Drawing.Point(4, 41);
            this.label_RazonEmisor.Name = "label_RazonEmisor";
            this.label_RazonEmisor.Size = new System.Drawing.Size(121, 15);
            this.label_RazonEmisor.TabIndex = 211;
            this.label_RazonEmisor.Text = "Razón Social Cliente";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button_SelectCliente);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label_razon);
            this.panel2.Controls.Add(this.label_rfc);
            this.panel2.Location = new System.Drawing.Point(420, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(377, 111);
            this.panel2.TabIndex = 351;
            // 
            // button_SelectCliente
            // 
            this.button_SelectCliente.Font = new System.Drawing.Font("Arial", 8F);
            this.button_SelectCliente.Image = global::FLXDSK.Properties.Resources.lupita;
            this.button_SelectCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_SelectCliente.Location = new System.Drawing.Point(299, 24);
            this.button_SelectCliente.Name = "button_SelectCliente";
            this.button_SelectCliente.Size = new System.Drawing.Size(73, 23);
            this.button_SelectCliente.TabIndex = 0;
            this.button_SelectCliente.Text = "Buscar";
            this.button_SelectCliente.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label11.Font = new System.Drawing.Font("Arial", 10F);
            this.label11.ForeColor = System.Drawing.SystemColors.Window;
            this.label11.Location = new System.Drawing.Point(-3, 0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            this.label11.Size = new System.Drawing.Size(389, 22);
            this.label11.TabIndex = 249;
            this.label11.Text = "Receptor:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_razon
            // 
            this.label_razon.AutoSize = true;
            this.label_razon.Font = new System.Drawing.Font("Arial", 9F);
            this.label_razon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label_razon.Location = new System.Drawing.Point(12, 46);
            this.label_razon.Name = "label_razon";
            this.label_razon.Size = new System.Drawing.Size(121, 15);
            this.label_razon.TabIndex = 126;
            this.label_razon.Text = "Razón Social Cliente";
            // 
            // label_rfc
            // 
            this.label_rfc.AutoSize = true;
            this.label_rfc.Font = new System.Drawing.Font("Arial", 9F);
            this.label_rfc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label_rfc.Location = new System.Drawing.Point(12, 31);
            this.label_rfc.Name = "label_rfc";
            this.label_rfc.Size = new System.Drawing.Size(32, 15);
            this.label_rfc.TabIndex = 125;
            this.label_rfc.Text = "RFC";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label7.Font = new System.Drawing.Font("Arial", 9F);
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(629, 136);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(3);
            this.label7.Size = new System.Drawing.Size(71, 21);
            this.label7.TabIndex = 372;
            this.label7.Text = "Moneda";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(325, 167);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3);
            this.label2.Size = new System.Drawing.Size(128, 21);
            this.label2.TabIndex = 371;
            this.label2.Text = "Uso Comprobante";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label6.Font = new System.Drawing.Font("Arial", 9F);
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(325, 138);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(3);
            this.label6.Size = new System.Drawing.Size(128, 21);
            this.label6.TabIndex = 370;
            this.label6.Text = "Serie";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.SystemColors.Window;
            this.label14.Location = new System.Drawing.Point(12, 229);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(3);
            this.label14.Size = new System.Drawing.Size(128, 21);
            this.label14.TabIndex = 369;
            this.label14.Text = "Comentarios";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label5.Font = new System.Drawing.Font("Arial", 9F);
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(12, 195);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(3);
            this.label5.Size = new System.Drawing.Size(128, 21);
            this.label5.TabIndex = 368;
            this.label5.Text = "Metodo de Pago";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(12, 166);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(128, 21);
            this.label1.TabIndex = 367;
            this.label1.Text = "Forma de Pago";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(12, 137);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(3);
            this.label4.Size = new System.Drawing.Size(128, 21);
            this.label4.TabIndex = 366;
            this.label4.Text = "Tipo Comprobante";
            // 
            // textBox_Comentario
            // 
            this.textBox_Comentario.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Comentario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Comentario.Location = new System.Drawing.Point(145, 229);
            this.textBox_Comentario.Name = "textBox_Comentario";
            this.textBox_Comentario.Size = new System.Drawing.Size(652, 21);
            this.textBox_Comentario.TabIndex = 364;
            // 
            // comboBox_Uso
            // 
            this.comboBox_Uso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Uso.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Uso.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_Uso.FormattingEnabled = true;
            this.comboBox_Uso.Location = new System.Drawing.Point(459, 166);
            this.comboBox_Uso.Name = "comboBox_Uso";
            this.comboBox_Uso.Size = new System.Drawing.Size(339, 22);
            this.comboBox_Uso.TabIndex = 363;
            // 
            // comboBox_MetodoPago
            // 
            this.comboBox_MetodoPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_MetodoPago.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_MetodoPago.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_MetodoPago.FormattingEnabled = true;
            this.comboBox_MetodoPago.Location = new System.Drawing.Point(145, 195);
            this.comboBox_MetodoPago.Name = "comboBox_MetodoPago";
            this.comboBox_MetodoPago.Size = new System.Drawing.Size(166, 22);
            this.comboBox_MetodoPago.TabIndex = 362;
            // 
            // comboBox_FormaPago
            // 
            this.comboBox_FormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FormaPago.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_FormaPago.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_FormaPago.FormattingEnabled = true;
            this.comboBox_FormaPago.Location = new System.Drawing.Point(145, 166);
            this.comboBox_FormaPago.Name = "comboBox_FormaPago";
            this.comboBox_FormaPago.Size = new System.Drawing.Size(166, 22);
            this.comboBox_FormaPago.TabIndex = 361;
            // 
            // comboBox_Moneda
            // 
            this.comboBox_Moneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Moneda.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Moneda.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_Moneda.FormattingEnabled = true;
            this.comboBox_Moneda.Location = new System.Drawing.Point(706, 135);
            this.comboBox_Moneda.Name = "comboBox_Moneda";
            this.comboBox_Moneda.Size = new System.Drawing.Size(92, 22);
            this.comboBox_Moneda.TabIndex = 360;
            // 
            // comboBox_Serie
            // 
            this.comboBox_Serie.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Serie.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Serie.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_Serie.FormattingEnabled = true;
            this.comboBox_Serie.Location = new System.Drawing.Point(459, 137);
            this.comboBox_Serie.Name = "comboBox_Serie";
            this.comboBox_Serie.Size = new System.Drawing.Size(149, 22);
            this.comboBox_Serie.TabIndex = 359;
            // 
            // comboBox_TipoCFDI
            // 
            this.comboBox_TipoCFDI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TipoCFDI.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_TipoCFDI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_TipoCFDI.FormattingEnabled = true;
            this.comboBox_TipoCFDI.Location = new System.Drawing.Point(145, 136);
            this.comboBox_TipoCFDI.Name = "comboBox_TipoCFDI";
            this.comboBox_TipoCFDI.Size = new System.Drawing.Size(166, 22);
            this.comboBox_TipoCFDI.TabIndex = 358;
            // 
            // dataGridView_Lista
            // 
            this.dataGridView_Lista.AllowUserToAddRows = false;
            this.dataGridView_Lista.AllowUserToDeleteRows = false;
            this.dataGridView_Lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Lista.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView_Lista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Lista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView_Lista.Location = new System.Drawing.Point(12, 258);
            this.dataGridView_Lista.Name = "dataGridView_Lista";
            this.dataGridView_Lista.RowHeadersVisible = false;
            this.dataGridView_Lista.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView_Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Lista.Size = new System.Drawing.Size(785, 185);
            this.dataGridView_Lista.TabIndex = 373;
            // 
            // button_Generar
            // 
            this.button_Generar.Location = new System.Drawing.Point(20, 487);
            this.button_Generar.Name = "button_Generar";
            this.button_Generar.Size = new System.Drawing.Size(87, 27);
            this.button_Generar.TabIndex = 374;
            this.button_Generar.Text = "Generar";
            this.button_Generar.UseVisualStyleBackColor = true;
            // 
            // label_total
            // 
            this.label_total.BackColor = System.Drawing.SystemColors.Window;
            this.label_total.Font = new System.Drawing.Font("Arial", 9F);
            this.label_total.Location = new System.Drawing.Point(688, 505);
            this.label_total.Name = "label_total";
            this.label_total.Padding = new System.Windows.Forms.Padding(3);
            this.label_total.Size = new System.Drawing.Size(109, 25);
            this.label_total.TabIndex = 380;
            this.label_total.Text = "0";
            this.label_total.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_IVA
            // 
            this.label_IVA.BackColor = System.Drawing.SystemColors.Window;
            this.label_IVA.Font = new System.Drawing.Font("Arial", 9F);
            this.label_IVA.Location = new System.Drawing.Point(688, 477);
            this.label_IVA.Name = "label_IVA";
            this.label_IVA.Padding = new System.Windows.Forms.Padding(3);
            this.label_IVA.Size = new System.Drawing.Size(109, 25);
            this.label_IVA.TabIndex = 379;
            this.label_IVA.Text = "0";
            this.label_IVA.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_Subtotal
            // 
            this.label_Subtotal.BackColor = System.Drawing.SystemColors.Window;
            this.label_Subtotal.Font = new System.Drawing.Font("Arial", 9F);
            this.label_Subtotal.Location = new System.Drawing.Point(688, 450);
            this.label_Subtotal.Name = "label_Subtotal";
            this.label_Subtotal.Padding = new System.Windows.Forms.Padding(3);
            this.label_Subtotal.Size = new System.Drawing.Size(109, 25);
            this.label_Subtotal.TabIndex = 378;
            this.label_Subtotal.Text = "0";
            this.label_Subtotal.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label8.Font = new System.Drawing.Font("Arial", 9F);
            this.label8.ForeColor = System.Drawing.SystemColors.Window;
            this.label8.Location = new System.Drawing.Point(551, 504);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(3);
            this.label8.Size = new System.Drawing.Size(131, 25);
            this.label8.TabIndex = 377;
            this.label8.Text = "Total";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label9.Font = new System.Drawing.Font("Arial", 9F);
            this.label9.ForeColor = System.Drawing.SystemColors.Window;
            this.label9.Location = new System.Drawing.Point(551, 477);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(3);
            this.label9.Size = new System.Drawing.Size(131, 25);
            this.label9.TabIndex = 376;
            this.label9.Text = "IVA";
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label12.Font = new System.Drawing.Font("Arial", 9F);
            this.label12.ForeColor = System.Drawing.SystemColors.Window;
            this.label12.Location = new System.Drawing.Point(551, 450);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(3);
            this.label12.Size = new System.Drawing.Size(131, 25);
            this.label12.TabIndex = 375;
            this.label12.Text = "SubTotal";
            // 
            // Form_FacTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 539);
            this.Controls.Add(this.label_total);
            this.Controls.Add(this.label_IVA);
            this.Controls.Add(this.label_Subtotal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.button_Generar);
            this.Controls.Add(this.dataGridView_Lista);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Comentario);
            this.Controls.Add(this.comboBox_Uso);
            this.Controls.Add(this.comboBox_MetodoPago);
            this.Controls.Add(this.comboBox_FormaPago);
            this.Controls.Add(this.comboBox_Moneda);
            this.Controls.Add(this.comboBox_Serie);
            this.Controls.Add(this.comboBox_TipoCFDI);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form_FacTicket";
            this.Text = "Form_FacTicket";
            this.Load += new System.EventHandler(this.Form_FacTicket_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label_RFC_Emisor;
        private System.Windows.Forms.Label label_RazonEmisor;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_SelectCliente;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label_razon;
        private System.Windows.Forms.Label label_rfc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Comentario;
        private System.Windows.Forms.ComboBox comboBox_Uso;
        private System.Windows.Forms.ComboBox comboBox_MetodoPago;
        private System.Windows.Forms.ComboBox comboBox_FormaPago;
        private System.Windows.Forms.ComboBox comboBox_Moneda;
        private System.Windows.Forms.ComboBox comboBox_Serie;
        private System.Windows.Forms.ComboBox comboBox_TipoCFDI;
        private System.Windows.Forms.DataGridView dataGridView_Lista;
        private System.Windows.Forms.Button button_Generar;
        private System.Windows.Forms.Label label_total;
        private System.Windows.Forms.Label label_IVA;
        private System.Windows.Forms.Label label_Subtotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
    }
}