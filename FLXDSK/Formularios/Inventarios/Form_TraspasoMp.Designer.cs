namespace FLXDSK.Formularios.Inventarios
{
    partial class Form_TraspasoMp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_TraspasoMp));
            this.labelTit = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Destino = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_Origen = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Comentario = new System.Windows.Forms.TextBox();
            this.textBox_Buscar = new System.Windows.Forms.TextBox();
            this.dataGridView_Lista = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.button_buscar = new System.Windows.Forms.Button();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_UsuarioEnvia = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lista)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTit
            // 
            this.labelTit.AutoSize = true;
            this.labelTit.BackColor = System.Drawing.Color.Transparent;
            this.labelTit.Font = new System.Drawing.Font("Arial", 15F);
            this.labelTit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.labelTit.Location = new System.Drawing.Point(12, 9);
            this.labelTit.Name = "labelTit";
            this.labelTit.Size = new System.Drawing.Size(102, 23);
            this.labelTit.TabIndex = 615;
            this.labelTit.Text = "Traspasos";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label14.Location = new System.Drawing.Point(-3, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(775, 23);
            this.label14.TabIndex = 616;
            this.label14.Text = "_________________________________________________________________________________" +
    "_____________________________________________________________________________";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label5.Font = new System.Drawing.Font("Arial", 9F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(18, 81);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 20);
            this.label5.TabIndex = 641;
            this.label5.Text = "* Almacen Destino";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_Destino
            // 
            this.comboBox_Destino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Destino.Font = new System.Drawing.Font("Arial", 9F);
            this.comboBox_Destino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_Destino.FormattingEnabled = true;
            this.comboBox_Destino.Items.AddRange(new object[] {
            "Kilo",
            "Litro",
            "Metro",
            "Pieza"});
            this.comboBox_Destino.Location = new System.Drawing.Point(154, 80);
            this.comboBox_Destino.Name = "comboBox_Destino";
            this.comboBox_Destino.Size = new System.Drawing.Size(223, 23);
            this.comboBox_Destino.TabIndex = 639;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label12.Font = new System.Drawing.Font("Arial", 9F);
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(18, 54);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 19);
            this.label12.TabIndex = 640;
            this.label12.Text = "* Almacen Origen";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_Origen
            // 
            this.comboBox_Origen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Origen.Font = new System.Drawing.Font("Arial", 9F);
            this.comboBox_Origen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_Origen.FormattingEnabled = true;
            this.comboBox_Origen.Location = new System.Drawing.Point(154, 53);
            this.comboBox_Origen.Name = "comboBox_Origen";
            this.comboBox_Origen.Size = new System.Drawing.Size(223, 23);
            this.comboBox_Origen.TabIndex = 638;
            this.comboBox_Origen.SelectedValueChanged += new System.EventHandler(this.comboBox_Origen_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 108);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(360, 22);
            this.label4.TabIndex = 643;
            this.label4.Text = "Comentario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_Comentario
            // 
            this.textBox_Comentario.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Comentario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Comentario.Location = new System.Drawing.Point(16, 133);
            this.textBox_Comentario.MaxLength = 80;
            this.textBox_Comentario.Name = "textBox_Comentario";
            this.textBox_Comentario.Size = new System.Drawing.Size(745, 21);
            this.textBox_Comentario.TabIndex = 642;
            // 
            // textBox_Buscar
            // 
            this.textBox_Buscar.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Buscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Buscar.Location = new System.Drawing.Point(70, 166);
            this.textBox_Buscar.Name = "textBox_Buscar";
            this.textBox_Buscar.Size = new System.Drawing.Size(619, 21);
            this.textBox_Buscar.TabIndex = 648;
            this.textBox_Buscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Buscar_KeyPress);
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
            this.dataGridView_Lista.Location = new System.Drawing.Point(16, 192);
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
            this.dataGridView_Lista.TabIndex = 646;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 9F);
            this.label8.Location = new System.Drawing.Point(18, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 645;
            this.label8.Text = "Buscar";
            // 
            // button_buscar
            // 
            this.button_buscar.Location = new System.Drawing.Point(695, 164);
            this.button_buscar.Name = "button_buscar";
            this.button_buscar.Size = new System.Drawing.Size(66, 23);
            this.button_buscar.TabIndex = 644;
            this.button_buscar.Text = "Buscar";
            this.button_buscar.UseVisualStyleBackColor = true;
            this.button_buscar.Click += new System.EventHandler(this.button_buscar_Click);
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(21, 487);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(70, 28);
            this.button_Guardar.TabIndex = 649;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(487, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 22);
            this.label1.TabIndex = 650;
            this.label1.Text = "Usuario envia";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_UsuarioEnvia
            // 
            this.label_UsuarioEnvia.BackColor = System.Drawing.Color.Transparent;
            this.label_UsuarioEnvia.Font = new System.Drawing.Font("Arial", 9F);
            this.label_UsuarioEnvia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label_UsuarioEnvia.Location = new System.Drawing.Point(625, 54);
            this.label_UsuarioEnvia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_UsuarioEnvia.Name = "label_UsuarioEnvia";
            this.label_UsuarioEnvia.Size = new System.Drawing.Size(130, 22);
            this.label_UsuarioEnvia.TabIndex = 651;
            this.label_UsuarioEnvia.Text = "Serie";
            this.label_UsuarioEnvia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form_TraspasoMp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 526);
            this.Controls.Add(this.label_UsuarioEnvia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.textBox_Buscar);
            this.Controls.Add(this.dataGridView_Lista);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_buscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_Comentario);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_Destino);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.comboBox_Origen);
            this.Controls.Add(this.labelTit);
            this.Controls.Add(this.label14);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_TraspasoMp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traspasos";
            this.Load += new System.EventHandler(this.Form_TraspasoMp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTit;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_Destino;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_Origen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Comentario;
        private System.Windows.Forms.TextBox textBox_Buscar;
        private System.Windows.Forms.DataGridView dataGridView_Lista;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button_buscar;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_UsuarioEnvia;
    }
}