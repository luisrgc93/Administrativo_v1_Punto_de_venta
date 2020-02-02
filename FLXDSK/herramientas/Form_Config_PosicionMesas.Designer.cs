namespace FLXDSK.herramientas
{
    partial class Form_Config_PosicionMesas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Config_PosicionMesas));
            this.panel_Mesas = new System.Windows.Forms.Panel();
            this.panel_Areas = new System.Windows.Forms.Panel();
            this.panel_Controles = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_idMesa = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button_Cambiar = new System.Windows.Forms.Button();
            this.label_NombreMesa = new System.Windows.Forms.Label();
            this.comboBox_Tamano = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_EditarTamano = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Mesas
            // 
            this.panel_Mesas.Location = new System.Drawing.Point(268, 108);
            this.panel_Mesas.Name = "panel_Mesas";
            this.panel_Mesas.Size = new System.Drawing.Size(233, 115);
            this.panel_Mesas.TabIndex = 7;
            // 
            // panel_Areas
            // 
            this.panel_Areas.Location = new System.Drawing.Point(27, 108);
            this.panel_Areas.Name = "panel_Areas";
            this.panel_Areas.Size = new System.Drawing.Size(233, 115);
            this.panel_Areas.TabIndex = 6;
            // 
            // panel_Controles
            // 
            this.panel_Controles.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel_Controles.Location = new System.Drawing.Point(313, 730);
            this.panel_Controles.Name = "panel_Controles";
            this.panel_Controles.Size = new System.Drawing.Size(239, 60);
            this.panel_Controles.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button_EditarTamano);
            this.panel1.Controls.Add(this.label_idMesa);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button_Cambiar);
            this.panel1.Controls.Add(this.label_NombreMesa);
            this.panel1.Controls.Add(this.comboBox_Tamano);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(2, 730);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 60);
            this.panel1.TabIndex = 9;
            // 
            // label_idMesa
            // 
            this.label_idMesa.AutoSize = true;
            this.label_idMesa.Location = new System.Drawing.Point(117, 7);
            this.label_idMesa.Name = "label_idMesa";
            this.label_idMesa.Size = new System.Drawing.Size(41, 15);
            this.label_idMesa.TabIndex = 5;
            this.label_idMesa.Text = "label2";
            this.label_idMesa.Visible = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button3.Font = new System.Drawing.Font("Arial", 8F);
            this.button3.Location = new System.Drawing.Point(177, 24);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(57, 30);
            this.button3.TabIndex = 3;
            this.button3.Text = "Nuevo";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button_Cambiar
            // 
            this.button_Cambiar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_Cambiar.Font = new System.Drawing.Font("Arial", 8F);
            this.button_Cambiar.Location = new System.Drawing.Point(240, 24);
            this.button_Cambiar.Name = "button_Cambiar";
            this.button_Cambiar.Size = new System.Drawing.Size(58, 30);
            this.button_Cambiar.TabIndex = 2;
            this.button_Cambiar.Text = "Guardar";
            this.button_Cambiar.UseVisualStyleBackColor = false;
            this.button_Cambiar.Click += new System.EventHandler(this.button_Cambiar_Click);
            // 
            // label_NombreMesa
            // 
            this.label_NombreMesa.AutoSize = true;
            this.label_NombreMesa.Location = new System.Drawing.Point(12, 7);
            this.label_NombreMesa.Name = "label_NombreMesa";
            this.label_NombreMesa.Size = new System.Drawing.Size(41, 15);
            this.label_NombreMesa.TabIndex = 1;
            this.label_NombreMesa.Text = "label2";
            // 
            // comboBox_Tamano
            // 
            this.comboBox_Tamano.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Tamano.FormattingEnabled = true;
            this.comboBox_Tamano.Location = new System.Drawing.Point(9, 28);
            this.comboBox_Tamano.Name = "comboBox_Tamano";
            this.comboBox_Tamano.Size = new System.Drawing.Size(164, 23);
            this.comboBox_Tamano.TabIndex = 0;
            this.comboBox_Tamano.SelectedValueChanged += new System.EventHandler(this.comboBox_Tamano_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(183, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            this.label1.Visible = false;
            // 
            // button_EditarTamano
            // 
            this.button_EditarTamano.BackColor = System.Drawing.Color.WhiteSmoke;
            this.button_EditarTamano.Font = new System.Drawing.Font("Arial", 8F);
            this.button_EditarTamano.Location = new System.Drawing.Point(177, 24);
            this.button_EditarTamano.Name = "button_EditarTamano";
            this.button_EditarTamano.Size = new System.Drawing.Size(57, 30);
            this.button_EditarTamano.TabIndex = 6;
            this.button_EditarTamano.Text = "Editar";
            this.button_EditarTamano.UseVisualStyleBackColor = false;
            this.button_EditarTamano.Visible = false;
            this.button_EditarTamano.Click += new System.EventHandler(this.button_EditarTamano_Click);
            // 
            // Form_Config_PosicionMesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(577, 792);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel_Controles);
            this.Controls.Add(this.panel_Mesas);
            this.Controls.Add(this.panel_Areas);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Config_PosicionMesas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Posición de Mesas";
            this.Load += new System.EventHandler(this.Form_Config_PosicionMesas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Mesas;
        private System.Windows.Forms.Panel panel_Areas;
        private System.Windows.Forms.Panel panel_Controles;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button_Cambiar;
        private System.Windows.Forms.Label label_NombreMesa;
        private System.Windows.Forms.ComboBox comboBox_Tamano;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_idMesa;
        private System.Windows.Forms.Button button_EditarTamano;
    }
}