namespace FLXDSK.Formularios.Ventas
{
    partial class Form_AddPropina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_AddPropina));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Monto = new System.Windows.Forms.TextBox();
            this.textBox_Folio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Agregar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox_Ultimos = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::FLXDSK.Properties.Resources.equis;
            this.pictureBox2.Location = new System.Drawing.Point(632, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 503;
            this.pictureBox2.TabStop = false;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label14.Location = new System.Drawing.Point(16, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(364, 23);
            this.label14.TabIndex = 504;
            this.label14.Text = "_______________________________________________________";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 22);
            this.label1.TabIndex = 502;
            this.label1.Text = "Guardar Propina";
            // 
            // textBox_Monto
            // 
            this.textBox_Monto.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox_Monto.Location = new System.Drawing.Point(217, 57);
            this.textBox_Monto.MaxLength = 11;
            this.textBox_Monto.Name = "textBox_Monto";
            this.textBox_Monto.Size = new System.Drawing.Size(86, 23);
            this.textBox_Monto.TabIndex = 497;
            this.textBox_Monto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Monto_KeyPress);
            // 
            // textBox_Folio
            // 
            this.textBox_Folio.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox_Folio.Location = new System.Drawing.Point(66, 57);
            this.textBox_Folio.MaxLength = 15;
            this.textBox_Folio.Name = "textBox_Folio";
            this.textBox_Folio.Size = new System.Drawing.Size(80, 23);
            this.textBox_Folio.TabIndex = 496;
            this.textBox_Folio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_Folio_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(168, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 501;
            this.label3.Text = "*Monto:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 15);
            this.label2.TabIndex = 500;
            this.label2.Text = "*Folio:";
            // 
            // button_Agregar
            // 
            this.button_Agregar.Location = new System.Drawing.Point(325, 54);
            this.button_Agregar.Name = "button_Agregar";
            this.button_Agregar.Size = new System.Drawing.Size(95, 28);
            this.button_Agregar.TabIndex = 505;
            this.button_Agregar.Text = "Agregar";
            this.button_Agregar.UseVisualStyleBackColor = true;
            this.button_Agregar.Click += new System.EventHandler(this.button_Agregar_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label4.Location = new System.Drawing.Point(16, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(633, 23);
            this.label4.TabIndex = 506;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // groupBox_Ultimos
            // 
            this.groupBox_Ultimos.Location = new System.Drawing.Point(21, 117);
            this.groupBox_Ultimos.Name = "groupBox_Ultimos";
            this.groupBox_Ultimos.Size = new System.Drawing.Size(641, 246);
            this.groupBox_Ultimos.TabIndex = 0;
            this.groupBox_Ultimos.TabStop = false;
            this.groupBox_Ultimos.Text = "Últimos Pedidos Pagados";
            // 
            // Form_AddPropina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 375);
            this.Controls.Add(this.groupBox_Ultimos);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button_Agregar);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Monto);
            this.Controls.Add(this.textBox_Folio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_AddPropina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Guardar Propina";
            this.Load += new System.EventHandler(this.Form_AddPropina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Monto;
        private System.Windows.Forms.TextBox textBox_Folio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Agregar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox_Ultimos;
    }
}