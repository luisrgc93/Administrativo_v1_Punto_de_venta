namespace FLXDSK.Formularios.Administracion
{
    partial class Form_Empresas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Empresas));
            this.label19 = new System.Windows.Forms.Label();
            this.comboBox_Regimen = new System.Windows.Forms.ComboBox();
            this.textBox_alias = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox_telefono = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_correo = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.comboBox_estado = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_municipio = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBox_localidad = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_colonia = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_numint = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_numext = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_calle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_cp = new System.Windows.Forms.TextBox();
            this.textBox_rfc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_razon = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Logo = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl_Empresa = new System.Windows.Forms.TabControl();
            this.tabPage_Fiscales = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.button_Nuevo = new System.Windows.Forms.Button();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.sucursales = new System.Windows.Forms.TabPage();
            this.panel_sucursales = new System.Windows.Forms.Panel();
            this.txt_nombreSucursal = new System.Windows.Forms.TextBox();
            this.btn_Guardarsucursal = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txt_sucursal = new System.Windows.Forms.TextBox();
            this.certificados = new System.Windows.Forms.TabPage();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox_AccesoTimbrado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Key = new System.Windows.Forms.TextBox();
            this.textBox_Certificado = new System.Windows.Forms.TextBox();
            this.textBox_Clave = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.button_GuardaCer = new System.Windows.Forms.Button();
            this.button_cer = new System.Windows.Forms.Button();
            this.button_key = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.tabControl_Empresa.SuspendLayout();
            this.tabPage_Fiscales.SuspendLayout();
            this.sucursales.SuspendLayout();
            this.panel_sucursales.SuspendLayout();
            this.certificados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Arial", 9F);
            this.label19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label19.Location = new System.Drawing.Point(101, 246);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(36, 15);
            this.label19.TabIndex = 168;
            this.label19.Text = "* C.P.";
            // 
            // comboBox_Regimen
            // 
            this.comboBox_Regimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Regimen.Font = new System.Drawing.Font("Arial", 9F);
            this.comboBox_Regimen.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_Regimen.FormattingEnabled = true;
            this.comboBox_Regimen.Items.AddRange(new object[] {
            "moral",
            "fisica"});
            this.comboBox_Regimen.Location = new System.Drawing.Point(144, 107);
            this.comboBox_Regimen.Name = "comboBox_Regimen";
            this.comboBox_Regimen.Size = new System.Drawing.Size(404, 23);
            this.comboBox_Regimen.TabIndex = 4;
            // 
            // textBox_alias
            // 
            this.textBox_alias.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_alias.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_alias.Location = new System.Drawing.Point(144, 52);
            this.textBox_alias.MaxLength = 80;
            this.textBox_alias.Name = "textBox_alias";
            this.textBox_alias.Size = new System.Drawing.Size(403, 21);
            this.textBox_alias.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Arial", 9F);
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label17.Location = new System.Drawing.Point(23, 55);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(117, 15);
            this.label17.TabIndex = 167;
            this.label17.Text = "* Nombre comercial";
            // 
            // textBox_telefono
            // 
            this.textBox_telefono.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_telefono.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_telefono.Location = new System.Drawing.Point(147, 274);
            this.textBox_telefono.MaxLength = 20;
            this.textBox_telefono.Name = "textBox_telefono";
            this.textBox_telefono.Size = new System.Drawing.Size(176, 21);
            this.textBox_telefono.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label14.Location = new System.Drawing.Point(86, 277);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 15);
            this.label14.TabIndex = 166;
            this.label14.Text = "Teléfono";
            // 
            // textBox_correo
            // 
            this.textBox_correo.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_correo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_correo.Location = new System.Drawing.Point(389, 274);
            this.textBox_correo.MaxLength = 80;
            this.textBox_correo.Name = "textBox_correo";
            this.textBox_correo.Size = new System.Drawing.Size(159, 21);
            this.textBox_correo.TabIndex = 14;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Arial", 9F);
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label15.Location = new System.Drawing.Point(339, 277);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 15);
            this.label15.TabIndex = 165;
            this.label15.Text = "Correo";
            // 
            // comboBox_estado
            // 
            this.comboBox_estado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_estado.Font = new System.Drawing.Font("Arial", 9F);
            this.comboBox_estado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox_estado.FormattingEnabled = true;
            this.comboBox_estado.Location = new System.Drawing.Point(389, 243);
            this.comboBox_estado.Name = "comboBox_estado";
            this.comboBox_estado.Size = new System.Drawing.Size(158, 23);
            this.comboBox_estado.TabIndex = 12;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Arial", 9F);
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label12.Location = new System.Drawing.Point(330, 246);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 15);
            this.label12.TabIndex = 164;
            this.label12.Text = "* Estado";
            // 
            // textBox_municipio
            // 
            this.textBox_municipio.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_municipio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_municipio.Location = new System.Drawing.Point(146, 213);
            this.textBox_municipio.MaxLength = 50;
            this.textBox_municipio.Name = "textBox_municipio";
            this.textBox_municipio.Size = new System.Drawing.Size(177, 21);
            this.textBox_municipio.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Arial", 9F);
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label13.Location = new System.Drawing.Point(81, 218);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 15);
            this.label13.TabIndex = 163;
            this.label13.Text = "Municipio";
            // 
            // textBox_localidad
            // 
            this.textBox_localidad.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_localidad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_localidad.Location = new System.Drawing.Point(389, 213);
            this.textBox_localidad.MaxLength = 100;
            this.textBox_localidad.Name = "textBox_localidad";
            this.textBox_localidad.Size = new System.Drawing.Size(158, 21);
            this.textBox_localidad.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial", 9F);
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label10.Location = new System.Drawing.Point(323, 216);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 15);
            this.label10.TabIndex = 162;
            this.label10.Text = "Localidad";
            // 
            // textBox_colonia
            // 
            this.textBox_colonia.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_colonia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_colonia.Location = new System.Drawing.Point(389, 186);
            this.textBox_colonia.MaxLength = 100;
            this.textBox_colonia.Name = "textBox_colonia";
            this.textBox_colonia.Size = new System.Drawing.Size(158, 21);
            this.textBox_colonia.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial", 9F);
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label11.Location = new System.Drawing.Point(334, 189);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 15);
            this.label11.TabIndex = 161;
            this.label11.Text = "Colonia";
            // 
            // textBox_numint
            // 
            this.textBox_numint.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_numint.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_numint.Location = new System.Drawing.Point(264, 185);
            this.textBox_numint.MaxLength = 30;
            this.textBox_numint.Name = "textBox_numint";
            this.textBox_numint.Size = new System.Drawing.Size(59, 21);
            this.textBox_numint.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 9F);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label9.Location = new System.Drawing.Point(211, 188);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 15);
            this.label9.TabIndex = 160;
            this.label9.Text = "No. Int.:";
            // 
            // textBox_numext
            // 
            this.textBox_numext.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_numext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_numext.Location = new System.Drawing.Point(145, 185);
            this.textBox_numext.MaxLength = 30;
            this.textBox_numext.Name = "textBox_numext";
            this.textBox_numext.Size = new System.Drawing.Size(65, 21);
            this.textBox_numext.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 9F);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label8.Location = new System.Drawing.Point(92, 188);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 15);
            this.label8.TabIndex = 159;
            this.label8.Text = "No. Ext.";
            // 
            // textBox_calle
            // 
            this.textBox_calle.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_calle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_calle.Location = new System.Drawing.Point(145, 158);
            this.textBox_calle.MaxLength = 100;
            this.textBox_calle.Name = "textBox_calle";
            this.textBox_calle.Size = new System.Drawing.Size(402, 21);
            this.textBox_calle.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Arial", 9F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label7.Location = new System.Drawing.Point(73, 161);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 15);
            this.label7.TabIndex = 158;
            this.label7.Text = "Domicilio";
            // 
            // textBox_cp
            // 
            this.textBox_cp.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_cp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_cp.Location = new System.Drawing.Point(147, 243);
            this.textBox_cp.MaxLength = 6;
            this.textBox_cp.Name = "textBox_cp";
            this.textBox_cp.Size = new System.Drawing.Size(176, 21);
            this.textBox_cp.TabIndex = 11;
            // 
            // textBox_rfc
            // 
            this.textBox_rfc.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_rfc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_rfc.Location = new System.Drawing.Point(144, 80);
            this.textBox_rfc.MaxLength = 13;
            this.textBox_rfc.Name = "textBox_rfc";
            this.textBox_rfc.Size = new System.Drawing.Size(179, 21);
            this.textBox_rfc.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Arial", 9F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label5.Location = new System.Drawing.Point(97, 83);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 157;
            this.label5.Text = "* RFC";
            // 
            // textBox_razon
            // 
            this.textBox_razon.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_razon.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_razon.Location = new System.Drawing.Point(144, 25);
            this.textBox_razon.MaxLength = 150;
            this.textBox_razon.Name = "textBox_razon";
            this.textBox_razon.Size = new System.Drawing.Size(403, 21);
            this.textBox_razon.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label4.Location = new System.Drawing.Point(53, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 156;
            this.label4.Text = "* Razón Social";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label3.Location = new System.Drawing.Point(35, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 155;
            this.label3.Text = "* Régimen Fiscal";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 23);
            this.label1.TabIndex = 171;
            this.label1.Text = "Alta Empresa";
            // 
            // button_Logo
            // 
            this.button_Logo.Location = new System.Drawing.Point(161, 306);
            this.button_Logo.Name = "button_Logo";
            this.button_Logo.Size = new System.Drawing.Size(75, 23);
            this.button_Logo.TabIndex = 0;
            this.button_Logo.Text = "Examinar..";
            this.button_Logo.UseVisualStyleBackColor = true;
            this.button_Logo.Click += new System.EventHandler(this.button_Logo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.tabControl_Empresa);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button_Logo);
            this.panel1.Location = new System.Drawing.Point(-3, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 489);
            this.panel1.TabIndex = 190;
            // 
            // tabControl_Empresa
            // 
            this.tabControl_Empresa.Controls.Add(this.tabPage_Fiscales);
            this.tabControl_Empresa.Controls.Add(this.sucursales);
            this.tabControl_Empresa.Controls.Add(this.certificados);
            this.tabControl_Empresa.Location = new System.Drawing.Point(266, 56);
            this.tabControl_Empresa.Name = "tabControl_Empresa";
            this.tabControl_Empresa.SelectedIndex = 0;
            this.tabControl_Empresa.Size = new System.Drawing.Size(602, 411);
            this.tabControl_Empresa.TabIndex = 210;
            // 
            // tabPage_Fiscales
            // 
            this.tabPage_Fiscales.Controls.Add(this.button1);
            this.tabPage_Fiscales.Controls.Add(this.label24);
            this.tabPage_Fiscales.Controls.Add(this.label4);
            this.tabPage_Fiscales.Controls.Add(this.button_Nuevo);
            this.tabPage_Fiscales.Controls.Add(this.button_Guardar);
            this.tabPage_Fiscales.Controls.Add(this.label17);
            this.tabPage_Fiscales.Controls.Add(this.textBox_alias);
            this.tabPage_Fiscales.Controls.Add(this.label11);
            this.tabPage_Fiscales.Controls.Add(this.label7);
            this.tabPage_Fiscales.Controls.Add(this.textBox_correo);
            this.tabPage_Fiscales.Controls.Add(this.label15);
            this.tabPage_Fiscales.Controls.Add(this.textBox_calle);
            this.tabPage_Fiscales.Controls.Add(this.textBox_telefono);
            this.tabPage_Fiscales.Controls.Add(this.textBox_colonia);
            this.tabPage_Fiscales.Controls.Add(this.label14);
            this.tabPage_Fiscales.Controls.Add(this.textBox_razon);
            this.tabPage_Fiscales.Controls.Add(this.textBox_municipio);
            this.tabPage_Fiscales.Controls.Add(this.textBox_cp);
            this.tabPage_Fiscales.Controls.Add(this.label5);
            this.tabPage_Fiscales.Controls.Add(this.label19);
            this.tabPage_Fiscales.Controls.Add(this.label3);
            this.tabPage_Fiscales.Controls.Add(this.label13);
            this.tabPage_Fiscales.Controls.Add(this.comboBox_Regimen);
            this.tabPage_Fiscales.Controls.Add(this.comboBox_estado);
            this.tabPage_Fiscales.Controls.Add(this.textBox_rfc);
            this.tabPage_Fiscales.Controls.Add(this.label12);
            this.tabPage_Fiscales.Controls.Add(this.textBox_numint);
            this.tabPage_Fiscales.Controls.Add(this.textBox_localidad);
            this.tabPage_Fiscales.Controls.Add(this.label8);
            this.tabPage_Fiscales.Controls.Add(this.label10);
            this.tabPage_Fiscales.Controls.Add(this.textBox_numext);
            this.tabPage_Fiscales.Controls.Add(this.label9);
            this.tabPage_Fiscales.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Fiscales.Name = "tabPage_Fiscales";
            this.tabPage_Fiscales.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Fiscales.Size = new System.Drawing.Size(594, 385);
            this.tabPage_Fiscales.TabIndex = 0;
            this.tabPage_Fiscales.Text = "Datos Fiscales";
            this.tabPage_Fiscales.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(515, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 25);
            this.button1.TabIndex = 205;
            this.button1.Tag = "Salir del sistema";
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label24.Location = new System.Drawing.Point(11, 356);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(296, 13);
            this.label24.TabIndex = 204;
            this.label24.Text = "Nota: Los campos marcados con asterisco (*) son requeridos.";
            // 
            // button_Nuevo
            // 
            this.button_Nuevo.Location = new System.Drawing.Point(436, 344);
            this.button_Nuevo.Name = "button_Nuevo";
            this.button_Nuevo.Size = new System.Drawing.Size(73, 25);
            this.button_Nuevo.TabIndex = 19;
            this.button_Nuevo.Tag = "Nuevo";
            this.button_Nuevo.Text = "Nuevo";
            this.button_Nuevo.UseVisualStyleBackColor = true;
            this.button_Nuevo.Click += new System.EventHandler(this.button_Nuevo_Click);
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(357, 344);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(73, 25);
            this.button_Guardar.TabIndex = 16;
            this.button_Guardar.Tag = "Guardar";
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click_1);
            // 
            // sucursales
            // 
            this.sucursales.Controls.Add(this.panel_sucursales);
            this.sucursales.Location = new System.Drawing.Point(4, 22);
            this.sucursales.Name = "sucursales";
            this.sucursales.Padding = new System.Windows.Forms.Padding(3);
            this.sucursales.Size = new System.Drawing.Size(594, 385);
            this.sucursales.TabIndex = 2;
            this.sucursales.Text = "Sucursales";
            this.sucursales.UseVisualStyleBackColor = true;
            // 
            // panel_sucursales
            // 
            this.panel_sucursales.Controls.Add(this.txt_nombreSucursal);
            this.panel_sucursales.Controls.Add(this.btn_Guardarsucursal);
            this.panel_sucursales.Controls.Add(this.label21);
            this.panel_sucursales.Controls.Add(this.label22);
            this.panel_sucursales.Controls.Add(this.txt_sucursal);
            this.panel_sucursales.Location = new System.Drawing.Point(20, 7);
            this.panel_sucursales.Name = "panel_sucursales";
            this.panel_sucursales.Size = new System.Drawing.Size(551, 372);
            this.panel_sucursales.TabIndex = 170;
            // 
            // txt_nombreSucursal
            // 
            this.txt_nombreSucursal.Font = new System.Drawing.Font("Arial", 9F);
            this.txt_nombreSucursal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_nombreSucursal.Location = new System.Drawing.Point(95, 55);
            this.txt_nombreSucursal.MaxLength = 40;
            this.txt_nombreSucursal.Multiline = true;
            this.txt_nombreSucursal.Name = "txt_nombreSucursal";
            this.txt_nombreSucursal.Size = new System.Drawing.Size(260, 51);
            this.txt_nombreSucursal.TabIndex = 167;
            // 
            // btn_Guardarsucursal
            // 
            this.btn_Guardarsucursal.Location = new System.Drawing.Point(478, 344);
            this.btn_Guardarsucursal.Name = "btn_Guardarsucursal";
            this.btn_Guardarsucursal.Size = new System.Drawing.Size(73, 25);
            this.btn_Guardarsucursal.TabIndex = 169;
            this.btn_Guardarsucursal.Tag = "Guardar";
            this.btn_Guardarsucursal.Text = "Guardar";
            this.btn_Guardarsucursal.UseVisualStyleBackColor = true;
            this.btn_Guardarsucursal.Click += new System.EventHandler(this.btn_Guardarsucursal_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Arial", 9F);
            this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label21.Location = new System.Drawing.Point(3, 27);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(88, 15);
            this.label21.TabIndex = 168;
            this.label21.Text = "No. sucursal: *";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Arial", 9F);
            this.label22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label22.Location = new System.Drawing.Point(24, 55);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(55, 15);
            this.label22.TabIndex = 168;
            this.label22.Text = "Nombre:";
            // 
            // txt_sucursal
            // 
            this.txt_sucursal.Font = new System.Drawing.Font("Arial", 9F);
            this.txt_sucursal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txt_sucursal.Location = new System.Drawing.Point(95, 24);
            this.txt_sucursal.MaxLength = 20;
            this.txt_sucursal.Name = "txt_sucursal";
            this.txt_sucursal.Size = new System.Drawing.Size(260, 21);
            this.txt_sucursal.TabIndex = 167;
            // 
            // certificados
            // 
            this.certificados.Controls.Add(this.label25);
            this.certificados.Controls.Add(this.textBox_AccesoTimbrado);
            this.certificados.Controls.Add(this.label6);
            this.certificados.Controls.Add(this.textBox_Key);
            this.certificados.Controls.Add(this.textBox_Certificado);
            this.certificados.Controls.Add(this.textBox_Clave);
            this.certificados.Controls.Add(this.label16);
            this.certificados.Controls.Add(this.label18);
            this.certificados.Controls.Add(this.label20);
            this.certificados.Controls.Add(this.button_GuardaCer);
            this.certificados.Controls.Add(this.button_cer);
            this.certificados.Controls.Add(this.button_key);
            this.certificados.Location = new System.Drawing.Point(4, 22);
            this.certificados.Name = "certificados";
            this.certificados.Padding = new System.Windows.Forms.Padding(3);
            this.certificados.Size = new System.Drawing.Size(594, 385);
            this.certificados.TabIndex = 1;
            this.certificados.Text = "Certificados";
            this.certificados.UseVisualStyleBackColor = true;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.BackColor = System.Drawing.Color.Transparent;
            this.label25.Font = new System.Drawing.Font("Arial", 9F);
            this.label25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label25.Location = new System.Drawing.Point(28, 61);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(110, 15);
            this.label25.TabIndex = 232;
            this.label25.Text = "* Acceso Timbrado";
            // 
            // textBox_AccesoTimbrado
            // 
            this.textBox_AccesoTimbrado.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox_AccesoTimbrado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_AccesoTimbrado.Location = new System.Drawing.Point(148, 57);
            this.textBox_AccesoTimbrado.Name = "textBox_AccesoTimbrado";
            this.textBox_AccesoTimbrado.Size = new System.Drawing.Size(414, 23);
            this.textBox_AccesoTimbrado.TabIndex = 231;
            this.textBox_AccesoTimbrado.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 15F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label6.Location = new System.Drawing.Point(27, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 23);
            this.label6.TabIndex = 230;
            this.label6.Text = "Certificados";
            // 
            // textBox_Key
            // 
            this.textBox_Key.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox_Key.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Key.Location = new System.Drawing.Point(149, 115);
            this.textBox_Key.Name = "textBox_Key";
            this.textBox_Key.Size = new System.Drawing.Size(218, 23);
            this.textBox_Key.TabIndex = 223;
            // 
            // textBox_Certificado
            // 
            this.textBox_Certificado.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox_Certificado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Certificado.Location = new System.Drawing.Point(149, 89);
            this.textBox_Certificado.Name = "textBox_Certificado";
            this.textBox_Certificado.Size = new System.Drawing.Size(218, 23);
            this.textBox_Certificado.TabIndex = 221;
            // 
            // textBox_Clave
            // 
            this.textBox_Clave.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox_Clave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Clave.Location = new System.Drawing.Point(149, 141);
            this.textBox_Clave.Name = "textBox_Clave";
            this.textBox_Clave.Size = new System.Drawing.Size(218, 23);
            this.textBox_Clave.TabIndex = 225;
            this.textBox_Clave.UseSystemPasswordChar = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Arial", 9F);
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label16.Location = new System.Drawing.Point(103, 117);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 15);
            this.label16.TabIndex = 229;
            this.label16.Text = "* Key";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Arial", 9F);
            this.label18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label18.Location = new System.Drawing.Point(69, 144);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 15);
            this.label18.TabIndex = 228;
            this.label18.Text = "* Clave Key";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Arial", 9F);
            this.label20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label20.Location = new System.Drawing.Point(64, 91);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(74, 15);
            this.label20.TabIndex = 227;
            this.label20.Text = "* Certificado";
            // 
            // button_GuardaCer
            // 
            this.button_GuardaCer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.button_GuardaCer.Location = new System.Drawing.Point(294, 178);
            this.button_GuardaCer.Name = "button_GuardaCer";
            this.button_GuardaCer.Size = new System.Drawing.Size(73, 25);
            this.button_GuardaCer.TabIndex = 226;
            this.button_GuardaCer.Tag = "Guardar";
            this.button_GuardaCer.Text = "Guardar";
            this.button_GuardaCer.UseVisualStyleBackColor = true;
            this.button_GuardaCer.Click += new System.EventHandler(this.button_GuardaCer_Click);
            // 
            // button_cer
            // 
            this.button_cer.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cer.Location = new System.Drawing.Point(373, 86);
            this.button_cer.Name = "button_cer";
            this.button_cer.Size = new System.Drawing.Size(75, 23);
            this.button_cer.TabIndex = 222;
            this.button_cer.Text = "Examinar..";
            this.button_cer.UseVisualStyleBackColor = true;
            this.button_cer.Click += new System.EventHandler(this.button_cer_Click);
            // 
            // button_key
            // 
            this.button_key.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_key.Location = new System.Drawing.Point(373, 115);
            this.button_key.Name = "button_key";
            this.button_key.Size = new System.Drawing.Size(75, 23);
            this.button_key.TabIndex = 224;
            this.button_key.Text = "Examinar..";
            this.button_key.UseVisualStyleBackColor = true;
            this.button_key.Click += new System.EventHandler(this.button_key_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label2.Location = new System.Drawing.Point(0, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(893, 23);
            this.label2.TabIndex = 209;
            this.label2.Text = "_________________________________________________________________________________" +
    "_________________________________________________________________";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::FLXDSK.Properties.Resources.log_empresa;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(29, 91);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 209);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 188;
            this.pictureBox1.TabStop = false;
            // 
            // Form_Empresas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 505);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Empresas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empresas";
            this.Load += new System.EventHandler(this.Form_Empresas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl_Empresa.ResumeLayout(false);
            this.tabPage_Fiscales.ResumeLayout(false);
            this.tabPage_Fiscales.PerformLayout();
            this.sucursales.ResumeLayout(false);
            this.panel_sucursales.ResumeLayout(false);
            this.panel_sucursales.PerformLayout();
            this.certificados.ResumeLayout(false);
            this.certificados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBox_Regimen;
        private System.Windows.Forms.TextBox textBox_alias;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox_telefono;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_correo;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox comboBox_estado;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_municipio;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBox_localidad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_colonia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_numint;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_numext;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_calle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_cp;
        private System.Windows.Forms.TextBox textBox_rfc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_razon;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Nuevo;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_Logo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl_Empresa;
        private System.Windows.Forms.TabPage tabPage_Fiscales;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TabPage certificados;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBox_AccesoTimbrado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_Key;
        private System.Windows.Forms.TextBox textBox_Certificado;
        private System.Windows.Forms.TextBox textBox_Clave;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Button button_GuardaCer;
        private System.Windows.Forms.Button button_cer;
        private System.Windows.Forms.Button button_key;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage sucursales;
        private System.Windows.Forms.Button btn_Guardarsucursal;
        private System.Windows.Forms.TextBox txt_nombreSucursal;
        private System.Windows.Forms.TextBox txt_sucursal;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Panel panel_sucursales;
    }
}