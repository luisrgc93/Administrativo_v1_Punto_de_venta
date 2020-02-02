namespace FLXDSK.Listas.Ventas
{
    partial class Form_List_CortesMeseros
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Cerrar_Corte = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_reeimprimir = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Salir = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_Buscar = new System.Windows.Forms.TextBox();
            this.pictureBox_Serch = new System.Windows.Forms.PictureBox();
            this.dateTimePicker_FF = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_FI = new System.Windows.Forms.DateTimePicker();
            this.button_Filtrar = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Serch)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Cerrar_Corte,
            this.toolStripButton_reeimprimir,
            this.toolStripButton_Salir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(828, 33);
            this.toolStrip1.TabIndex = 148;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_Cerrar_Corte
            // 
            this.toolStripButton_Cerrar_Corte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Cerrar_Corte.Image = global::FLXDSK.Properties.Resources.agregar;
            this.toolStripButton_Cerrar_Corte.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Cerrar_Corte.Name = "toolStripButton_Cerrar_Corte";
            this.toolStripButton_Cerrar_Corte.Size = new System.Drawing.Size(23, 30);
            this.toolStripButton_Cerrar_Corte.Text = "s";
            this.toolStripButton_Cerrar_Corte.Click += new System.EventHandler(this.toolStripButton_Cerrar_Corte_Click);
            // 
            // toolStripButton_reeimprimir
            // 
            this.toolStripButton_reeimprimir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_reeimprimir.Image = global::FLXDSK.Properties.Resources.print;
            this.toolStripButton_reeimprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_reeimprimir.Name = "toolStripButton_reeimprimir";
            this.toolStripButton_reeimprimir.Size = new System.Drawing.Size(23, 30);
            this.toolStripButton_reeimprimir.Text = "Reeimprimir";
            this.toolStripButton_reeimprimir.Click += new System.EventHandler(this.toolStripButton_reeimprimir_Click);
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
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(244)))), ((int)(((byte)(251)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridView1.Location = new System.Drawing.Point(0, 33);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(828, 424);
            this.dataGridView1.TabIndex = 149;
            // 
            // textBox_Buscar
            // 
            this.textBox_Buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_Buscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Buscar.Location = new System.Drawing.Point(578, 5);
            this.textBox_Buscar.Name = "textBox_Buscar";
            this.textBox_Buscar.Size = new System.Drawing.Size(181, 23);
            this.textBox_Buscar.TabIndex = 157;
            // 
            // pictureBox_Serch
            // 
            this.pictureBox_Serch.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Serch.BackgroundImage = global::FLXDSK.Properties.Resources.lupita;
            this.pictureBox_Serch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox_Serch.Location = new System.Drawing.Point(753, 5);
            this.pictureBox_Serch.Name = "pictureBox_Serch";
            this.pictureBox_Serch.Size = new System.Drawing.Size(27, 23);
            this.pictureBox_Serch.TabIndex = 158;
            this.pictureBox_Serch.TabStop = false;
            // 
            // dateTimePicker_FF
            // 
            this.dateTimePicker_FF.Font = new System.Drawing.Font("Arial", 8F);
            this.dateTimePicker_FF.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_FF.Location = new System.Drawing.Point(229, 6);
            this.dateTimePicker_FF.Name = "dateTimePicker_FF";
            this.dateTimePicker_FF.Size = new System.Drawing.Size(97, 20);
            this.dateTimePicker_FF.TabIndex = 323;
            this.dateTimePicker_FF.Value = new System.DateTime(2012, 7, 31, 0, 41, 43, 0);
            // 
            // dateTimePicker_FI
            // 
            this.dateTimePicker_FI.Font = new System.Drawing.Font("Arial", 8F);
            this.dateTimePicker_FI.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_FI.Location = new System.Drawing.Point(126, 6);
            this.dateTimePicker_FI.Name = "dateTimePicker_FI";
            this.dateTimePicker_FI.Size = new System.Drawing.Size(95, 20);
            this.dateTimePicker_FI.TabIndex = 322;
            this.dateTimePicker_FI.Value = new System.DateTime(2012, 7, 31, 0, 41, 43, 0);
            // 
            // button_Filtrar
            // 
            this.button_Filtrar.BackColor = System.Drawing.Color.Transparent;
            this.button_Filtrar.BackgroundImage = global::FLXDSK.Properties.Resources.recargar;
            this.button_Filtrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_Filtrar.FlatAppearance.BorderSize = 0;
            this.button_Filtrar.Location = new System.Drawing.Point(332, 4);
            this.button_Filtrar.Name = "button_Filtrar";
            this.button_Filtrar.Size = new System.Drawing.Size(29, 25);
            this.button_Filtrar.TabIndex = 324;
            this.button_Filtrar.UseVisualStyleBackColor = false;
            this.button_Filtrar.Click += new System.EventHandler(this.button_Filtrar_Click);
            // 
            // Form_List_CortesMeseros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 457);
            this.Controls.Add(this.button_Filtrar);
            this.Controls.Add(this.dateTimePicker_FF);
            this.Controls.Add(this.dateTimePicker_FI);
            this.Controls.Add(this.pictureBox_Serch);
            this.Controls.Add(this.textBox_Buscar);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form_List_CortesMeseros";
            this.Text = "Form_List_CortesMeseros";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_List_CortesMeseros_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Serch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Cerrar_Corte;
        private System.Windows.Forms.ToolStripButton toolStripButton_reeimprimir;
        private System.Windows.Forms.ToolStripButton toolStripButton_Salir;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox_Serch;
        private System.Windows.Forms.TextBox textBox_Buscar;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FF;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FI;
        private System.Windows.Forms.Button button_Filtrar;
    }
}