namespace FLXDSK.Formularios.Existencias
{
    partial class Form_Abonos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Abonos));
            this.textBox_Abono = new System.Windows.Forms.TextBox();
            this.dataGridView_Lista = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label_abonado = new System.Windows.Forms.Label();
            this.button_AddAbono = new System.Windows.Forms.Button();
            this.label_FolioCompra = new System.Windows.Forms.Label();
            this.label_SaldoPediente = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelTit = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label_proveedor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_FormaPago = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label_FechaCompra = new System.Windows.Forms.Label();
            this.label_TotalCompra = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_Abono
            // 
            this.textBox_Abono.Location = new System.Drawing.Point(378, 142);
            this.textBox_Abono.Name = "textBox_Abono";
            this.textBox_Abono.Size = new System.Drawing.Size(90, 21);
            this.textBox_Abono.TabIndex = 0;
            // 
            // dataGridView_Lista
            // 
            this.dataGridView_Lista.AllowUserToAddRows = false;
            this.dataGridView_Lista.AllowUserToDeleteRows = false;
            this.dataGridView_Lista.AllowUserToOrderColumns = true;
            this.dataGridView_Lista.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dataGridView_Lista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Lista.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView_Lista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_Lista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Lista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Lista.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Lista.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView_Lista.Location = new System.Drawing.Point(12, 173);
            this.dataGridView_Lista.Name = "dataGridView_Lista";
            this.dataGridView_Lista.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F);
            this.dataGridView_Lista.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Lista.Size = new System.Drawing.Size(532, 115);
            this.dataGridView_Lista.TabIndex = 593;
            this.dataGridView_Lista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Lista_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(317, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 21);
            this.label1.TabIndex = 594;
            this.label1.Text = "ABONADO";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_abonado
            // 
            this.label_abonado.BackColor = System.Drawing.Color.White;
            this.label_abonado.ForeColor = System.Drawing.Color.Black;
            this.label_abonado.Location = new System.Drawing.Point(448, 296);
            this.label_abonado.Name = "label_abonado";
            this.label_abonado.Size = new System.Drawing.Size(96, 21);
            this.label_abonado.TabIndex = 595;
            this.label_abonado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_AddAbono
            // 
            this.button_AddAbono.Location = new System.Drawing.Point(474, 139);
            this.button_AddAbono.Name = "button_AddAbono";
            this.button_AddAbono.Size = new System.Drawing.Size(70, 25);
            this.button_AddAbono.TabIndex = 596;
            this.button_AddAbono.Text = "Abonar";
            this.button_AddAbono.UseVisualStyleBackColor = true;
            this.button_AddAbono.Click += new System.EventHandler(this.button_abonar_Click);
            // 
            // label_FolioCompra
            // 
            this.label_FolioCompra.BackColor = System.Drawing.Color.White;
            this.label_FolioCompra.ForeColor = System.Drawing.Color.Black;
            this.label_FolioCompra.Location = new System.Drawing.Point(448, 50);
            this.label_FolioCompra.Name = "label_FolioCompra";
            this.label_FolioCompra.Size = new System.Drawing.Size(96, 21);
            this.label_FolioCompra.TabIndex = 598;
            this.label_FolioCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_SaldoPediente
            // 
            this.label_SaldoPediente.BackColor = System.Drawing.Color.White;
            this.label_SaldoPediente.ForeColor = System.Drawing.Color.Black;
            this.label_SaldoPediente.Location = new System.Drawing.Point(448, 320);
            this.label_SaldoPediente.Name = "label_SaldoPediente";
            this.label_SaldoPediente.Size = new System.Drawing.Size(96, 21);
            this.label_SaldoPediente.TabIndex = 602;
            this.label_SaldoPediente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(317, 320);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 21);
            this.label8.TabIndex = 601;
            this.label8.Text = "POR PAGAR";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(329, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 15);
            this.label5.TabIndex = 603;
            this.label5.Text = "Abonar";
            // 
            // labelTit
            // 
            this.labelTit.AutoSize = true;
            this.labelTit.BackColor = System.Drawing.Color.Transparent;
            this.labelTit.Font = new System.Drawing.Font("Arial", 15F);
            this.labelTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelTit.Location = new System.Drawing.Point(6, 9);
            this.labelTit.Name = "labelTit";
            this.labelTit.Size = new System.Drawing.Size(169, 23);
            this.labelTit.TabIndex = 607;
            this.labelTit.Text = "Abono a Compras";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::FLXDSK.Properties.Resources.equis;
            this.pictureBox2.Location = new System.Drawing.Point(514, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 606;
            this.pictureBox2.TabStop = false;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label14.Location = new System.Drawing.Point(-9, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(574, 23);
            this.label14.TabIndex = 608;
            this.label14.Text = "_________________________________________________________________________________" +
    "___";
            // 
            // label_proveedor
            // 
            this.label_proveedor.Location = new System.Drawing.Point(4, 27);
            this.label_proveedor.Name = "label_proveedor";
            this.label_proveedor.Size = new System.Drawing.Size(271, 35);
            this.label_proveedor.TabIndex = 614;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 616;
            this.label2.Text = "Forma de Pago";
            // 
            // comboBox_FormaPago
            // 
            this.comboBox_FormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FormaPago.FormattingEnabled = true;
            this.comboBox_FormaPago.Location = new System.Drawing.Point(100, 142);
            this.comboBox_FormaPago.Name = "comboBox_FormaPago";
            this.comboBox_FormaPago.Size = new System.Drawing.Size(217, 23);
            this.comboBox_FormaPago.TabIndex = 617;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label6.Font = new System.Drawing.Font("Arial", 9F);
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(314, 50);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(3);
            this.label6.Size = new System.Drawing.Size(128, 21);
            this.label6.TabIndex = 618;
            this.label6.Text = "Folio de Compra";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label7.Font = new System.Drawing.Font("Arial", 9F);
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(314, 75);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(3);
            this.label7.Size = new System.Drawing.Size(128, 21);
            this.label7.TabIndex = 619;
            this.label7.Text = "Fecha de Compra";
            // 
            // label_FechaCompra
            // 
            this.label_FechaCompra.BackColor = System.Drawing.Color.White;
            this.label_FechaCompra.ForeColor = System.Drawing.Color.Black;
            this.label_FechaCompra.Location = new System.Drawing.Point(448, 75);
            this.label_FechaCompra.Name = "label_FechaCompra";
            this.label_FechaCompra.Size = new System.Drawing.Size(96, 21);
            this.label_FechaCompra.TabIndex = 620;
            this.label_FechaCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_TotalCompra
            // 
            this.label_TotalCompra.BackColor = System.Drawing.Color.White;
            this.label_TotalCompra.ForeColor = System.Drawing.Color.Black;
            this.label_TotalCompra.Location = new System.Drawing.Point(448, 99);
            this.label_TotalCompra.Name = "label_TotalCompra";
            this.label_TotalCompra.Size = new System.Drawing.Size(96, 21);
            this.label_TotalCompra.TabIndex = 622;
            this.label_TotalCompra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label10.Font = new System.Drawing.Font("Arial", 9F);
            this.label10.ForeColor = System.Drawing.SystemColors.Window;
            this.label10.Location = new System.Drawing.Point(314, 99);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(3);
            this.label10.Size = new System.Drawing.Size(128, 21);
            this.label10.TabIndex = 621;
            this.label10.Text = "Total";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label_proveedor);
            this.panel1.Location = new System.Drawing.Point(12, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(282, 70);
            this.panel1.TabIndex = 623;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Arial", 10F);
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(281, 22);
            this.label3.TabIndex = 253;
            this.label3.Text = "Proveedor:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(12, 296);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 14);
            this.label4.TabIndex = 624;
            this.label4.Text = "Nota: Doble clic para eliminar";
            // 
            // Form_Abonos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 375);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_TotalCompra);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label_FechaCompra);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox_FormaPago);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelTit);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label_SaldoPediente);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label_FolioCompra);
            this.Controls.Add(this.button_AddAbono);
            this.Controls.Add(this.label_abonado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_Lista);
            this.Controls.Add(this.textBox_Abono);
            this.Controls.Add(this.label14);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Abonos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saldo de Compras";
            this.Load += new System.EventHandler(this.Form_Abonos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Abono;
        private System.Windows.Forms.DataGridView dataGridView_Lista;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_abonado;
        private System.Windows.Forms.Button button_AddAbono;
        private System.Windows.Forms.Label label_FolioCompra;
        private System.Windows.Forms.Label label_SaldoPediente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelTit;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label_proveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_FormaPago;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_FechaCompra;
        private System.Windows.Forms.Label label_TotalCompra;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}