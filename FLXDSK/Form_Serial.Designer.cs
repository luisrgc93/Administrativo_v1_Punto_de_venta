namespace FLXDSK
{
    partial class Form_Serial
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Serial));
            this.button_Salir = new System.Windows.Forms.Button();
            this.text_key = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.pictureBox_Enviando = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Enviando)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Salir
            // 
            this.button_Salir.Location = new System.Drawing.Point(431, 203);
            this.button_Salir.Name = "button_Salir";
            this.button_Salir.Size = new System.Drawing.Size(73, 30);
            this.button_Salir.TabIndex = 2;
            this.button_Salir.Text = "Salir";
            this.button_Salir.UseVisualStyleBackColor = true;
            this.button_Salir.Click += new System.EventHandler(this.button_Salir_Click);
            // 
            // text_key
            // 
            this.text_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_key.Location = new System.Drawing.Point(108, 144);
            this.text_key.Name = "text_key";
            this.text_key.Size = new System.Drawing.Size(396, 30);
            this.text_key.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 10F);
            this.label2.Location = new System.Drawing.Point(105, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "No. de Licencia:";
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.Location = new System.Drawing.Point(350, 203);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(73, 30);
            this.button_Aceptar.TabIndex = 1;
            this.button_Aceptar.Text = "Aceptar";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click_1);
            // 
            // pictureBox_Enviando
            // 
            this.pictureBox_Enviando.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Enviando.Location = new System.Drawing.Point(303, 206);
            this.pictureBox_Enviando.Name = "pictureBox_Enviando";
            this.pictureBox_Enviando.Size = new System.Drawing.Size(24, 27);
            this.pictureBox_Enviando.TabIndex = 19;
            this.pictureBox_Enviando.TabStop = false;
            this.pictureBox_Enviando.Visible = false;
            this.pictureBox_Enviando.WaitOnLoad = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::FLXDSK.Properties.Resources.candado;
            this.pictureBox1.Location = new System.Drawing.Point(76, 144);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 29);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(95)))), ((int)(((byte)(165)))));
            this.label3.Location = new System.Drawing.Point(105, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(224, 15);
            this.label3.TabIndex = 145;
            this.label3.Text = "Por favor introduzca el número de serie.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 15F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label4.Location = new System.Drawing.Point(104, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 23);
            this.label4.TabIndex = 144;
            this.label4.Text = "Llave de Acceso";
            // 
            // Form_Serial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::FLXDSK.Properties.Resources.fondo_empresa;
            this.ClientSize = new System.Drawing.Size(588, 304);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox_Enviando);
            this.Controls.Add(this.button_Aceptar);
            this.Controls.Add(this.button_Salir);
            this.Controls.Add(this.text_key);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Serial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Numero de Serie";
            this.Load += new System.EventHandler(this.Form_Serial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Enviando)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Salir;
        private System.Windows.Forms.TextBox text_key;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.PictureBox pictureBox_Enviando;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}