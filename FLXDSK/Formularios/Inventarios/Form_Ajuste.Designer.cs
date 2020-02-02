namespace FLXDSK.Formularios.Inventarios
{
    partial class Form_Ajuste
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Ajuste));
            this.dataGridView_Lista = new System.Windows.Forms.DataGridView();
            this.button_guardar = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_Almacen = new System.Windows.Forms.ComboBox();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.textBox_Buscar = new System.Windows.Forms.TextBox();
            this.textBox_Comentario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Tipo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lista)).BeginInit();
            this.SuspendLayout();
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
            this.dataGridView_Lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dataGridView_Lista.Location = new System.Drawing.Point(12, 114);
            this.dataGridView_Lista.Name = "dataGridView_Lista";
            this.dataGridView_Lista.RowHeadersVisible = false;
            this.dataGridView_Lista.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9.75F);
            this.dataGridView_Lista.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Lista.Size = new System.Drawing.Size(757, 298);
            this.dataGridView_Lista.TabIndex = 613;
            // 
            // button_guardar
            // 
            this.button_guardar.Location = new System.Drawing.Point(672, 418);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(96, 36);
            this.button_guardar.TabIndex = 614;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label12.Font = new System.Drawing.Font("Arial", 9F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(13, 18);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 24);
            this.label12.TabIndex = 617;
            this.label12.Text = "* Almacen";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_Almacen
            // 
            this.comboBox_Almacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Almacen.Font = new System.Drawing.Font("Arial", 9F);
            this.comboBox_Almacen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_Almacen.FormattingEnabled = true;
            this.comboBox_Almacen.Location = new System.Drawing.Point(146, 17);
            this.comboBox_Almacen.Name = "comboBox_Almacen";
            this.comboBox_Almacen.Size = new System.Drawing.Size(372, 23);
            this.comboBox_Almacen.TabIndex = 616;
            this.comboBox_Almacen.SelectedValueChanged += new System.EventHandler(this.comboBox_Almacen_SelectedValueChanged);
            // 
            // button_Buscar
            // 
            this.button_Buscar.Location = new System.Drawing.Point(697, 85);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(71, 23);
            this.button_Buscar.TabIndex = 618;
            this.button_Buscar.Text = "Buscar";
            this.button_Buscar.UseVisualStyleBackColor = true;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // textBox_Buscar
            // 
            this.textBox_Buscar.Location = new System.Drawing.Point(12, 87);
            this.textBox_Buscar.Name = "textBox_Buscar";
            this.textBox_Buscar.Size = new System.Drawing.Size(679, 20);
            this.textBox_Buscar.TabIndex = 619;
            this.textBox_Buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Buscar_KeyPress);
            // 
            // textBox_Comentario
            // 
            this.textBox_Comentario.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Comentario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Comentario.Location = new System.Drawing.Point(146, 46);
            this.textBox_Comentario.MaxLength = 80;
            this.textBox_Comentario.Multiline = true;
            this.textBox_Comentario.Name = "textBox_Comentario";
            this.textBox_Comentario.Size = new System.Drawing.Size(372, 24);
            this.textBox_Comentario.TabIndex = 620;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 622;
            this.label1.Text = "Comentario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Tipo
            // 
            this.label_Tipo.BackColor = System.Drawing.Color.Transparent;
            this.label_Tipo.Font = new System.Drawing.Font("Arial", 15F);
            this.label_Tipo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label_Tipo.Location = new System.Drawing.Point(634, 19);
            this.label_Tipo.Name = "label_Tipo";
            this.label_Tipo.Size = new System.Drawing.Size(134, 23);
            this.label_Tipo.TabIndex = 623;
            this.label_Tipo.Text = "Ajuste";
            this.label_Tipo.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form_Ajuste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 468);
            this.Controls.Add(this.label_Tipo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Comentario);
            this.Controls.Add(this.textBox_Buscar);
            this.Controls.Add(this.button_Buscar);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBox_Almacen);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.dataGridView_Lista);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Ajuste";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ajuste";
            this.Load += new System.EventHandler(this.Form_Ajuste_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Lista;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_Almacen;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.TextBox textBox_Buscar;
        private System.Windows.Forms.TextBox textBox_Comentario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Tipo;
    }
}