namespace FLXDSK.Listas.Ventas
{
    partial class Form_List_Facturas
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
            this.pictureBox_Serch = new System.Windows.Forms.PictureBox();
            this.textBox_Buscar = new System.Windows.Forms.TextBox();
            this.button_Filtrar = new System.Windows.Forms.Button();
            this.dateTimePicker_FF = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_FI = new System.Windows.Forms.DateTimePicker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_downloadXml = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_DowloandPDF = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Enviar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Cancelar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Salir = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Serch)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Serch
            // 
            this.pictureBox_Serch.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Serch.BackgroundImage = global::FLXDSK.Properties.Resources.lupita;
            this.pictureBox_Serch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_Serch.Location = new System.Drawing.Point(776, 4);
            this.pictureBox_Serch.Name = "pictureBox_Serch";
            this.pictureBox_Serch.Size = new System.Drawing.Size(27, 23);
            this.pictureBox_Serch.TabIndex = 324;
            this.pictureBox_Serch.TabStop = false;
            // 
            // textBox_Buscar
            // 
            this.textBox_Buscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Buscar.Font = new System.Drawing.Font("Arial", 14F);
            this.textBox_Buscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Buscar.Location = new System.Drawing.Point(612, 5);
            this.textBox_Buscar.Name = "textBox_Buscar";
            this.textBox_Buscar.Size = new System.Drawing.Size(181, 22);
            this.textBox_Buscar.TabIndex = 323;
            this.textBox_Buscar.TextChanged += new System.EventHandler(this.textBox_Buscar_TextChanged);
            // 
            // button_Filtrar
            // 
            this.button_Filtrar.BackColor = System.Drawing.Color.Transparent;
            this.button_Filtrar.BackgroundImage = global::FLXDSK.Properties.Resources.recargar;
            this.button_Filtrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Filtrar.FlatAppearance.BorderSize = 0;
            this.button_Filtrar.Location = new System.Drawing.Point(453, 3);
            this.button_Filtrar.Name = "button_Filtrar";
            this.button_Filtrar.Size = new System.Drawing.Size(29, 25);
            this.button_Filtrar.TabIndex = 322;
            this.button_Filtrar.UseVisualStyleBackColor = false;
            this.button_Filtrar.Click += new System.EventHandler(this.button_Filtrar_Click);
            // 
            // dateTimePicker_FF
            // 
            this.dateTimePicker_FF.Font = new System.Drawing.Font("Arial", 8F);
            this.dateTimePicker_FF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_FF.Location = new System.Drawing.Point(350, 5);
            this.dateTimePicker_FF.Name = "dateTimePicker_FF";
            this.dateTimePicker_FF.Size = new System.Drawing.Size(97, 20);
            this.dateTimePicker_FF.TabIndex = 321;
            this.dateTimePicker_FF.Value = new System.DateTime(2012, 7, 31, 0, 41, 43, 0);
            // 
            // dateTimePicker_FI
            // 
            this.dateTimePicker_FI.Font = new System.Drawing.Font("Arial", 8F);
            this.dateTimePicker_FI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_FI.Location = new System.Drawing.Point(232, 5);
            this.dateTimePicker_FI.Name = "dateTimePicker_FI";
            this.dateTimePicker_FI.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker_FI.TabIndex = 320;
            this.dateTimePicker_FI.Value = new System.DateTime(2012, 7, 31, 0, 41, 43, 0);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_downloadXml,
            this.toolStripButton_DowloandPDF,
            this.toolStripButton_Enviar,
            this.toolStripButton_Cancelar,
            this.toolStripSeparator1,
            this.toolStripButton_Salir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(924, 33);
            this.toolStrip1.TabIndex = 150;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Add.Image = global::FLXDSK.Properties.Resources.agregar;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(23, 30);
            this.toolStripButton_Add.Text = "Agregar";
            this.toolStripButton_Add.Click += new System.EventHandler(this.toolStripButton_Add_Click);
            // 
            // toolStripButton_downloadXml
            // 
            this.toolStripButton_downloadXml.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_downloadXml.Image = global::FLXDSK.Properties.Resources.xml;
            this.toolStripButton_downloadXml.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_downloadXml.Name = "toolStripButton_downloadXml";
            this.toolStripButton_downloadXml.Size = new System.Drawing.Size(23, 30);
            this.toolStripButton_downloadXml.Text = "Descargar_Xml";
            this.toolStripButton_downloadXml.Click += new System.EventHandler(this.toolStripButton_downloadXml_Click);
            // 
            // toolStripButton_DowloandPDF
            // 
            this.toolStripButton_DowloandPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_DowloandPDF.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.toolStripButton_DowloandPDF.Image = global::FLXDSK.Properties.Resources.pdf;
            this.toolStripButton_DowloandPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_DowloandPDF.Name = "toolStripButton_DowloandPDF";
            this.toolStripButton_DowloandPDF.Size = new System.Drawing.Size(23, 30);
            this.toolStripButton_DowloandPDF.Text = "Descargar_PDF";
            this.toolStripButton_DowloandPDF.Click += new System.EventHandler(this.toolStripButton_DowloandPDF_Click);
            // 
            // toolStripButton_Enviar
            // 
            this.toolStripButton_Enviar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Enviar.Image = global::FLXDSK.Properties.Resources.mail;
            this.toolStripButton_Enviar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Enviar.Name = "toolStripButton_Enviar";
            this.toolStripButton_Enviar.Size = new System.Drawing.Size(23, 30);
            this.toolStripButton_Enviar.Text = "Enviar_Mail";
            this.toolStripButton_Enviar.Click += new System.EventHandler(this.toolStripButton_Enviar_Click);
            // 
            // toolStripButton_Cancelar
            // 
            this.toolStripButton_Cancelar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Cancelar.Enabled = false;
            this.toolStripButton_Cancelar.Image = global::FLXDSK.Properties.Resources.cancelar;
            this.toolStripButton_Cancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Cancelar.Name = "toolStripButton_Cancelar";
            this.toolStripButton_Cancelar.Size = new System.Drawing.Size(23, 30);
            this.toolStripButton_Cancelar.Text = "Cancelar";
            this.toolStripButton_Cancelar.Click += new System.EventHandler(this.toolStripButton_Cancelar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripButton_Salir
            // 
            this.toolStripButton_Salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Salir.Image = global::FLXDSK.Properties.Resources.salir1;
            this.toolStripButton_Salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Salir.Name = "toolStripButton_Salir";
            this.toolStripButton_Salir.Size = new System.Drawing.Size(23, 30);
            this.toolStripButton_Salir.Text = "Salir";
            this.toolStripButton_Salir.Click += new System.EventHandler(this.toolStripButton_Salir_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.Location = new System.Drawing.Point(0, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(924, 564);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form_List_Facturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 597);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox_Serch);
            this.Controls.Add(this.button_Filtrar);
            this.Controls.Add(this.textBox_Buscar);
            this.Controls.Add(this.dateTimePicker_FF);
            this.Controls.Add(this.dateTimePicker_FI);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_List_Facturas";
            this.Text = "Form_List_Facturas";
            this.Load += new System.EventHandler(this.Form_List_Facturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Serch)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Serch;
        private System.Windows.Forms.TextBox textBox_Buscar;
        private System.Windows.Forms.Button button_Filtrar;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FF;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FI;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_downloadXml;
        private System.Windows.Forms.ToolStripButton toolStripButton_DowloandPDF;
        private System.Windows.Forms.ToolStripButton toolStripButton_Enviar;
        private System.Windows.Forms.ToolStripButton toolStripButton_Cancelar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Salir;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}