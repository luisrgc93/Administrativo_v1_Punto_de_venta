namespace FLXDSK.Formularios
{
    partial class Form_NuevoTamano
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_NuevoTamano));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_TamanoX = new System.Windows.Forms.TextBox();
            this.textBox_TamanoY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.textBox_Nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(33, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tamaño X";
            // 
            // textBox_TamanoX
            // 
            this.textBox_TamanoX.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_TamanoX.Location = new System.Drawing.Point(101, 57);
            this.textBox_TamanoX.Name = "textBox_TamanoX";
            this.textBox_TamanoX.Size = new System.Drawing.Size(111, 21);
            this.textBox_TamanoX.TabIndex = 1;
            this.textBox_TamanoX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_TamanoX_KeyPress);
            // 
            // textBox_TamanoY
            // 
            this.textBox_TamanoY.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_TamanoY.Location = new System.Drawing.Point(101, 84);
            this.textBox_TamanoY.Name = "textBox_TamanoY";
            this.textBox_TamanoY.Size = new System.Drawing.Size(111, 21);
            this.textBox_TamanoY.TabIndex = 2;
            this.textBox_TamanoY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_TamanoY_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(33, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tamaño Y";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Cancelar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.Location = new System.Drawing.Point(56, 153);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(75, 30);
            this.button_Aceptar.TabIndex = 4;
            this.button_Aceptar.Text = "Guardar";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // textBox_Nombre
            // 
            this.textBox_Nombre.Font = new System.Drawing.Font("Arial", 9F);
            this.textBox_Nombre.Location = new System.Drawing.Point(101, 111);
            this.textBox_Nombre.Name = "textBox_Nombre";
            this.textBox_Nombre.Size = new System.Drawing.Size(111, 21);
            this.textBox_Nombre.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.Location = new System.Drawing.Point(45, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nombre";
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Font = new System.Drawing.Font("Arial", 15F);
            this.label85.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label85.Location = new System.Drawing.Point(11, 14);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(137, 23);
            this.label85.TabIndex = 425;
            this.label85.Text = "Tamaño Botón";
            // 
            // Form_NuevoTamano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 211);
            this.Controls.Add(this.label85);
            this.Controls.Add(this.textBox_Nombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_Aceptar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_TamanoY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_TamanoX);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_NuevoTamano";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear nuevo tamaño";
            this.Load += new System.EventHandler(this.Form_NuevoTamano_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_TamanoX;
        private System.Windows.Forms.TextBox textBox_TamanoY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.TextBox textBox_Nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label85;
    }
}