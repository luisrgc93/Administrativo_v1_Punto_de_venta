namespace FLXDSK.Formularios.SAT
{
    partial class Form_BuscaCodigoProd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_BuscaCodigoProd));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Filtro = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_Load = new System.Windows.Forms.PictureBox();
            this.dataGridView_Lista = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Division = new System.Windows.Forms.ComboBox();
            this.comboBox_Grupo = new System.Windows.Forms.ComboBox();
            this.comboBox_Clase = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Load)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lista)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 214;
            this.label1.Text = "División";
            // 
            // textBox_Filtro
            // 
            this.textBox_Filtro.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Filtro.Location = new System.Drawing.Point(12, 107);
            this.textBox_Filtro.Name = "textBox_Filtro";
            this.textBox_Filtro.Size = new System.Drawing.Size(620, 21);
            this.textBox_Filtro.TabIndex = 216;
            this.textBox_Filtro.TextChanged += new System.EventHandler(this.textBox_Filtro_TextChanged);
            this.textBox_Filtro.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Filtro_KeyPress);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox_Load);
            this.panel1.Controls.Add(this.dataGridView_Lista);
            this.panel1.Location = new System.Drawing.Point(12, 135);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 248);
            this.panel1.TabIndex = 215;
            // 
            // pictureBox_Load
            // 
            this.pictureBox_Load.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_Load.Name = "pictureBox_Load";
            this.pictureBox_Load.Size = new System.Drawing.Size(614, 242);
            this.pictureBox_Load.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox_Load.TabIndex = 304;
            this.pictureBox_Load.TabStop = false;
            this.pictureBox_Load.Visible = false;
            // 
            // dataGridView_Lista
            // 
            this.dataGridView_Lista.AllowUserToAddRows = false;
            this.dataGridView_Lista.AllowUserToDeleteRows = false;
            this.dataGridView_Lista.AllowUserToResizeRows = false;
            this.dataGridView_Lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Lista.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dataGridView_Lista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView_Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Lista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_Lista.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_Lista.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_Lista.Name = "dataGridView_Lista";
            this.dataGridView_Lista.RowHeadersVisible = false;
            this.dataGridView_Lista.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Lista.Size = new System.Drawing.Size(620, 248);
            this.dataGridView_Lista.TabIndex = 303;
            this.dataGridView_Lista.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Lista_CellDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(22, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 15);
            this.label2.TabIndex = 217;
            this.label2.Text = "Grupo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.Location = new System.Drawing.Point(23, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 218;
            this.label3.Text = "Clase";
            // 
            // comboBox_Division
            // 
            this.comboBox_Division.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Division.Font = new System.Drawing.Font("Arial", 8F);
            this.comboBox_Division.FormattingEnabled = true;
            this.comboBox_Division.Location = new System.Drawing.Point(69, 17);
            this.comboBox_Division.Name = "comboBox_Division";
            this.comboBox_Division.Size = new System.Drawing.Size(560, 22);
            this.comboBox_Division.TabIndex = 219;
            this.comboBox_Division.SelectedValueChanged += new System.EventHandler(this.comboBox_Division_SelectedValueChanged);
            // 
            // comboBox_Grupo
            // 
            this.comboBox_Grupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Grupo.Font = new System.Drawing.Font("Arial", 8F);
            this.comboBox_Grupo.FormattingEnabled = true;
            this.comboBox_Grupo.Location = new System.Drawing.Point(69, 45);
            this.comboBox_Grupo.Name = "comboBox_Grupo";
            this.comboBox_Grupo.Size = new System.Drawing.Size(560, 22);
            this.comboBox_Grupo.TabIndex = 220;
            this.comboBox_Grupo.SelectedValueChanged += new System.EventHandler(this.comboBox_Grupo_SelectedValueChanged);
            // 
            // comboBox_Clase
            // 
            this.comboBox_Clase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Clase.Font = new System.Drawing.Font("Arial", 8F);
            this.comboBox_Clase.FormattingEnabled = true;
            this.comboBox_Clase.Location = new System.Drawing.Point(69, 73);
            this.comboBox_Clase.Name = "comboBox_Clase";
            this.comboBox_Clase.Size = new System.Drawing.Size(560, 22);
            this.comboBox_Clase.TabIndex = 221;
            this.comboBox_Clase.SelectedValueChanged += new System.EventHandler(this.comboBox_Clase_SelectedValueChanged);
            // 
            // Form_BuscaCodigoProd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 395);
            this.Controls.Add(this.comboBox_Clase);
            this.Controls.Add(this.comboBox_Grupo);
            this.Controls.Add(this.comboBox_Division);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Filtro);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_BuscaCodigoProd";
            this.Text = "Buscar Producto Servicio";
            this.Load += new System.EventHandler(this.Form_BuscaCodigoProd_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Load)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Filtro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView_Lista;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Division;
        private System.Windows.Forms.ComboBox comboBox_Grupo;
        private System.Windows.Forms.ComboBox comboBox_Clase;
        private System.Windows.Forms.PictureBox pictureBox_Load;
    }
}