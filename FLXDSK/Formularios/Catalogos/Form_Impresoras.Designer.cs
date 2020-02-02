namespace FLXDSK.Formularios.Catalogos
{
    partial class Form_Impresoras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Impresoras));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.textBox_DireccionRed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_HardPrint = new System.Windows.Forms.ComboBox();
            this.button_GuardarPrint = new System.Windows.Forms.Button();
            this.comboBox_StopPrint = new System.Windows.Forms.ComboBox();
            this.comboBox_DataPrint = new System.Windows.Forms.ComboBox();
            this.comboBox_PartyPrint = new System.Windows.Forms.ComboBox();
            this.comboBox_PortPrint = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comboBox_BaudPrint = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_Nombre);
            this.groupBox4.Controls.Add(this.textBox_DireccionRed);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.comboBox_HardPrint);
            this.groupBox4.Controls.Add(this.button_GuardarPrint);
            this.groupBox4.Controls.Add(this.comboBox_StopPrint);
            this.groupBox4.Controls.Add(this.comboBox_DataPrint);
            this.groupBox4.Controls.Add(this.comboBox_PartyPrint);
            this.groupBox4.Controls.Add(this.comboBox_PortPrint);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.comboBox_BaudPrint);
            this.groupBox4.Controls.Add(this.label21);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Font = new System.Drawing.Font("Arial", 9F);
            this.groupBox4.Location = new System.Drawing.Point(6, 10);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(205, 346);
            this.groupBox4.TabIndex = 38;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Impresora Tikets";
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Location = new System.Drawing.Point(16, 40);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(173, 21);
            this.textBox_Nombre.TabIndex = 0;
            // 
            // textBox_DireccionRed
            // 
            this.textBox_DireccionRed.Location = new System.Drawing.Point(16, 81);
            this.textBox_DireccionRed.Name = "textBox_DireccionRed";
            this.textBox_DireccionRed.Size = new System.Drawing.Size(173, 21);
            this.textBox_DireccionRed.TabIndex = 1;
            this.textBox_DireccionRed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_DireccionRed_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 15);
            this.label2.TabIndex = 37;
            this.label2.Text = "Dirección de Red";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Nombre";
            // 
            // comboBox_HardPrint
            // 
            this.comboBox_HardPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_HardPrint.FormattingEnabled = true;
            this.comboBox_HardPrint.Location = new System.Drawing.Point(16, 258);
            this.comboBox_HardPrint.Name = "comboBox_HardPrint";
            this.comboBox_HardPrint.Size = new System.Drawing.Size(173, 23);
            this.comboBox_HardPrint.TabIndex = 7;
            // 
            // button_GuardarPrint
            // 
            this.button_GuardarPrint.Location = new System.Drawing.Point(121, 307);
            this.button_GuardarPrint.Name = "button_GuardarPrint";
            this.button_GuardarPrint.Size = new System.Drawing.Size(68, 33);
            this.button_GuardarPrint.TabIndex = 8;
            this.button_GuardarPrint.Text = "Guardar";
            this.button_GuardarPrint.UseVisualStyleBackColor = true;
            this.button_GuardarPrint.Click += new System.EventHandler(this.button_GuardarPrint_Click);
            // 
            // comboBox_StopPrint
            // 
            this.comboBox_StopPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_StopPrint.FormattingEnabled = true;
            this.comboBox_StopPrint.Location = new System.Drawing.Point(92, 213);
            this.comboBox_StopPrint.Name = "comboBox_StopPrint";
            this.comboBox_StopPrint.Size = new System.Drawing.Size(97, 23);
            this.comboBox_StopPrint.TabIndex = 6;
            // 
            // comboBox_DataPrint
            // 
            this.comboBox_DataPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DataPrint.FormattingEnabled = true;
            this.comboBox_DataPrint.Location = new System.Drawing.Point(92, 161);
            this.comboBox_DataPrint.Name = "comboBox_DataPrint";
            this.comboBox_DataPrint.Size = new System.Drawing.Size(97, 23);
            this.comboBox_DataPrint.TabIndex = 4;
            // 
            // comboBox_PartyPrint
            // 
            this.comboBox_PartyPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PartyPrint.FormattingEnabled = true;
            this.comboBox_PartyPrint.Location = new System.Drawing.Point(92, 187);
            this.comboBox_PartyPrint.Name = "comboBox_PartyPrint";
            this.comboBox_PartyPrint.Size = new System.Drawing.Size(97, 23);
            this.comboBox_PartyPrint.TabIndex = 5;
            // 
            // comboBox_PortPrint
            // 
            this.comboBox_PortPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_PortPrint.FormattingEnabled = true;
            this.comboBox_PortPrint.Location = new System.Drawing.Point(92, 109);
            this.comboBox_PortPrint.Name = "comboBox_PortPrint";
            this.comboBox_PortPrint.Size = new System.Drawing.Size(97, 23);
            this.comboBox_PortPrint.TabIndex = 2;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 112);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(29, 15);
            this.label20.TabIndex = 25;
            this.label20.Text = "Port";
            // 
            // comboBox_BaudPrint
            // 
            this.comboBox_BaudPrint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_BaudPrint.FormattingEnabled = true;
            this.comboBox_BaudPrint.Location = new System.Drawing.Point(92, 135);
            this.comboBox_BaudPrint.Name = "comboBox_BaudPrint";
            this.comboBox_BaudPrint.Size = new System.Drawing.Size(97, 23);
            this.comboBox_BaudPrint.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 139);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(60, 15);
            this.label21.TabIndex = 26;
            this.label21.Text = "Baud rate";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(13, 240);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(138, 15);
            this.label22.TabIndex = 30;
            this.label22.Text = "Hardware Handshaking";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(13, 166);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 15);
            this.label23.TabIndex = 27;
            this.label23.Text = "Data bits";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(13, 191);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(37, 15);
            this.label24.TabIndex = 29;
            this.label24.Text = "Parity";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(13, 216);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(55, 15);
            this.label25.TabIndex = 28;
            this.label25.Text = "Stop bits";
            // 
            // Form_Impresoras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(223, 368);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_Impresoras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Impresora";
            this.Load += new System.EventHandler(this.Form_Impresoras_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox_HardPrint;
        private System.Windows.Forms.Button button_GuardarPrint;
        private System.Windows.Forms.ComboBox comboBox_StopPrint;
        private System.Windows.Forms.ComboBox comboBox_DataPrint;
        private System.Windows.Forms.ComboBox comboBox_PartyPrint;
        private System.Windows.Forms.ComboBox comboBox_PortPrint;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox comboBox_BaudPrint;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.TextBox textBox_DireccionRed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;


    }
}