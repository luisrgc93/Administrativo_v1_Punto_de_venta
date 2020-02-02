namespace FLXDSK.herramientas
{
    partial class Form_conexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_conexion));
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_Clave = new System.Windows.Forms.TextBox();
            this.textBox_Usuario = new System.Windows.Forms.TextBox();
            this.textBox_Db = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_Servidor = new System.Windows.Forms.TextBox();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_Test = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.textBox_Clave);
            this.panel1.Controls.Add(this.textBox_Usuario);
            this.panel1.Controls.Add(this.textBox_Db);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox_Servidor);
            this.panel1.Controls.Add(this.button_Guardar);
            this.panel1.Controls.Add(this.button_Test);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(-3, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 270);
            this.panel1.TabIndex = 0;
            // 
            // textBox_Clave
            // 
            this.textBox_Clave.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Clave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Clave.Location = new System.Drawing.Point(122, 159);
            this.textBox_Clave.Name = "textBox_Clave";
            this.textBox_Clave.Size = new System.Drawing.Size(133, 21);
            this.textBox_Clave.TabIndex = 3;
            this.textBox_Clave.UseSystemPasswordChar = true;
            // 
            // textBox_Usuario
            // 
            this.textBox_Usuario.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Usuario.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Usuario.Location = new System.Drawing.Point(122, 126);
            this.textBox_Usuario.Name = "textBox_Usuario";
            this.textBox_Usuario.Size = new System.Drawing.Size(133, 21);
            this.textBox_Usuario.TabIndex = 2;
            // 
            // textBox_Db
            // 
            this.textBox_Db.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Db.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Db.Location = new System.Drawing.Point(122, 94);
            this.textBox_Db.Name = "textBox_Db";
            this.textBox_Db.Size = new System.Drawing.Size(133, 21);
            this.textBox_Db.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.Location = new System.Drawing.Point(26, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Base de datos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.Location = new System.Drawing.Point(61, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Usuario:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F);
            this.label5.Location = new System.Drawing.Point(74, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Clave:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(61, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Servidor:";
            // 
            // textBox_Servidor
            // 
            this.textBox_Servidor.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Servidor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_Servidor.Location = new System.Drawing.Point(122, 63);
            this.textBox_Servidor.Name = "textBox_Servidor";
            this.textBox_Servidor.Size = new System.Drawing.Size(133, 21);
            this.textBox_Servidor.TabIndex = 0;
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(187, 209);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(68, 27);
            this.button_Guardar.TabIndex = 5;
            this.button_Guardar.Tag = "Guardar";
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_Test
            // 
            this.button_Test.Location = new System.Drawing.Point(94, 209);
            this.button_Test.Name = "button_Test";
            this.button_Test.Size = new System.Drawing.Size(87, 27);
            this.button_Test.TabIndex = 4;
            this.button_Test.Text = "Test Conexión";
            this.button_Test.UseVisualStyleBackColor = true;
            this.button_Test.Click += new System.EventHandler(this.button_Test_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuración Conexión";
            // 
            // Form_conexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_conexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurar Conexión";
            this.Load += new System.EventHandler(this.Form_conexion_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Test;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_Servidor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Clave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Usuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Db;
    }
}