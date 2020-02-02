namespace FLXDSK.Listas.Inventarios
{
    partial class Form_List_Compras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_List_Compras));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pictureBox_Serch = new System.Windows.Forms.PictureBox();
            this.textBox_Buscar = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Editar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Borrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Procesar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_PDF = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Abonar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Salir = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_Lista = new System.Windows.Forms.DataGridView();
            this.button_Filtrar = new System.Windows.Forms.Button();
            this.dateTimePicker_FF = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_FI = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Serch)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lista)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Serch
            // 
            this.pictureBox_Serch.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Serch.BackgroundImage = global::FLXDSK.Properties.Resources.lupita;
            this.pictureBox_Serch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_Serch.Location = new System.Drawing.Point(798, 5);
            this.pictureBox_Serch.Name = "pictureBox_Serch";
            this.pictureBox_Serch.Size = new System.Drawing.Size(31, 27);
            this.pictureBox_Serch.TabIndex = 152;
            this.pictureBox_Serch.TabStop = false;
            // 
            // textBox_Buscar
            // 
            this.textBox_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Buscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Buscar.Location = new System.Drawing.Point(597, 6);
            this.textBox_Buscar.Name = "textBox_Buscar";
            this.textBox_Buscar.Size = new System.Drawing.Size(210, 23);
            this.textBox_Buscar.TabIndex = 151;
            this.textBox_Buscar.TextChanged += new System.EventHandler(this.textBox_Buscar_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Add,
            this.toolStripButton_Editar,
            this.toolStripButton_Borrar,
            this.toolStripSeparator1,
            this.toolStripButton_Procesar,
            this.toolStripButton_PDF,
            this.toolStripButton_Abonar,
            this.toolStripButton_Salir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(915, 38);
            this.toolStrip1.TabIndex = 145;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Add.Image = global::FLXDSK.Properties.Resources.agregar;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(23, 35);
            this.toolStripButton_Add.Text = "Agregar";
            this.toolStripButton_Add.Click += new System.EventHandler(this.toolStripButton_Add_Click);
            // 
            // toolStripButton_Editar
            // 
            this.toolStripButton_Editar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Editar.Image = global::FLXDSK.Properties.Resources.editar;
            this.toolStripButton_Editar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Editar.Name = "toolStripButton_Editar";
            this.toolStripButton_Editar.Size = new System.Drawing.Size(23, 35);
            this.toolStripButton_Editar.Text = "toolStripButton1";
            this.toolStripButton_Editar.ToolTipText = "Editar Seleccion";
            this.toolStripButton_Editar.Click += new System.EventHandler(this.toolStripButton_Editar_Click);
            // 
            // toolStripButton_Borrar
            // 
            this.toolStripButton_Borrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Borrar.Image = global::FLXDSK.Properties.Resources.eliminar;
            this.toolStripButton_Borrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Borrar.Name = "toolStripButton_Borrar";
            this.toolStripButton_Borrar.Size = new System.Drawing.Size(23, 35);
            this.toolStripButton_Borrar.Text = "Borrar Seleccion";
            this.toolStripButton_Borrar.Click += new System.EventHandler(this.toolStripButton_Borrar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // toolStripButton_Procesar
            // 
            this.toolStripButton_Procesar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Procesar.Image = global::FLXDSK.Properties.Resources.guardar;
            this.toolStripButton_Procesar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Procesar.Name = "toolStripButton_Procesar";
            this.toolStripButton_Procesar.Size = new System.Drawing.Size(23, 35);
            this.toolStripButton_Procesar.Text = "Procesar Compra";
            this.toolStripButton_Procesar.ToolTipText = "Procesar y Finalizar";
            this.toolStripButton_Procesar.Click += new System.EventHandler(this.toolStripButton_Procesar_Click);
            // 
            // toolStripButton_PDF
            // 
            this.toolStripButton_PDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_PDF.Image = global::FLXDSK.Properties.Resources.pdf;
            this.toolStripButton_PDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_PDF.Name = "toolStripButton_PDF";
            this.toolStripButton_PDF.Size = new System.Drawing.Size(23, 35);
            this.toolStripButton_PDF.Text = "PDF";
            this.toolStripButton_PDF.ToolTipText = "Pdf ";
            this.toolStripButton_PDF.Click += new System.EventHandler(this.toolStripButton_PDF_Click);
            // 
            // toolStripButton_Abonar
            // 
            this.toolStripButton_Abonar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Abonar.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Abonar.Image")));
            this.toolStripButton_Abonar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Abonar.Name = "toolStripButton_Abonar";
            this.toolStripButton_Abonar.Size = new System.Drawing.Size(23, 35);
            this.toolStripButton_Abonar.Text = "Agregar Pagos";
            this.toolStripButton_Abonar.ToolTipText = "Abonar";
            this.toolStripButton_Abonar.Click += new System.EventHandler(this.toolStripButton_Abonar_Click);
            // 
            // toolStripButton_Salir
            // 
            this.toolStripButton_Salir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Salir.Image = global::FLXDSK.Properties.Resources.salir1;
            this.toolStripButton_Salir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Salir.Name = "toolStripButton_Salir";
            this.toolStripButton_Salir.Size = new System.Drawing.Size(23, 35);
            this.toolStripButton_Salir.Text = "Salir";
            this.toolStripButton_Salir.Click += new System.EventHandler(this.toolStripButton_Salir_Click);
            // 
            // dataGridView_Lista
            // 
            this.dataGridView_Lista.AllowUserToAddRows = false;
            this.dataGridView_Lista.AllowUserToDeleteRows = false;
            this.dataGridView_Lista.AllowUserToOrderColumns = true;
            this.dataGridView_Lista.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.dataGridView_Lista.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_Lista.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView_Lista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_Lista.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_Lista.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Arial", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_Lista.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_Lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Lista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView_Lista.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView_Lista.Location = new System.Drawing.Point(0, 38);
            this.dataGridView_Lista.Name = "dataGridView_Lista";
            this.dataGridView_Lista.RowHeadersVisible = false;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView_Lista.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView_Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Lista.Size = new System.Drawing.Size(915, 379);
            this.dataGridView_Lista.TabIndex = 2;
            this.dataGridView_Lista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // button_Filtrar
            // 
            this.button_Filtrar.BackColor = System.Drawing.Color.Transparent;
            this.button_Filtrar.BackgroundImage = global::FLXDSK.Properties.Resources.recargar;
            this.button_Filtrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Filtrar.FlatAppearance.BorderSize = 0;
            this.button_Filtrar.Location = new System.Drawing.Point(435, 7);
            this.button_Filtrar.Name = "button_Filtrar";
            this.button_Filtrar.Size = new System.Drawing.Size(29, 25);
            this.button_Filtrar.TabIndex = 325;
            this.button_Filtrar.UseVisualStyleBackColor = false;
            this.button_Filtrar.Click += new System.EventHandler(this.button_Filtrar_Click);
            // 
            // dateTimePicker_FF
            // 
            this.dateTimePicker_FF.Font = new System.Drawing.Font("Arial", 8F);
            this.dateTimePicker_FF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_FF.Location = new System.Drawing.Point(332, 9);
            this.dateTimePicker_FF.Name = "dateTimePicker_FF";
            this.dateTimePicker_FF.Size = new System.Drawing.Size(97, 20);
            this.dateTimePicker_FF.TabIndex = 324;
            this.dateTimePicker_FF.Value = new System.DateTime(2012, 7, 31, 0, 41, 43, 0);
            // 
            // dateTimePicker_FI
            // 
            this.dateTimePicker_FI.Font = new System.Drawing.Font("Arial", 8F);
            this.dateTimePicker_FI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_FI.Location = new System.Drawing.Point(214, 9);
            this.dateTimePicker_FI.Name = "dateTimePicker_FI";
            this.dateTimePicker_FI.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker_FI.TabIndex = 323;
            this.dateTimePicker_FI.Value = new System.DateTime(2012, 7, 31, 0, 41, 43, 0);
            // 
            // Form_List_Compras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 417);
            this.Controls.Add(this.button_Filtrar);
            this.Controls.Add(this.dateTimePicker_FF);
            this.Controls.Add(this.dateTimePicker_FI);
            this.Controls.Add(this.dataGridView_Lista);
            this.Controls.Add(this.pictureBox_Serch);
            this.Controls.Add(this.textBox_Buscar);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Name = "Form_List_Compras";
            this.Text = "Form_List_Compras";
            this.Load += new System.EventHandler(this.Form_List_Compras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Serch)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Serch;
        private System.Windows.Forms.TextBox textBox_Buscar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Borrar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Salir;
        private System.Windows.Forms.DataGridView dataGridView_Lista;
        private System.Windows.Forms.ToolStripButton toolStripButton_Abonar;
        private System.Windows.Forms.ToolStripButton toolStripButton_Editar;
        private System.Windows.Forms.Button button_Filtrar;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FF;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FI;
        private System.Windows.Forms.ToolStripButton toolStripButton_Procesar;
        private System.Windows.Forms.ToolStripButton toolStripButton_PDF;
    }
}