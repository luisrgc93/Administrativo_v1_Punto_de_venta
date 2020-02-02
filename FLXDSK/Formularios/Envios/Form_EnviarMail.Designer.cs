namespace FLXDSK.Formularios.Envios
{
    partial class Form_EnviarMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_EnviarMail));
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Mensaje = new System.Windows.Forms.Label();
            this.rtext_mensaje = new System.Windows.Forms.RichTextBox();
            this.Asunto = new System.Windows.Forms.Label();
            this.text_asunto = new System.Windows.Forms.TextBox();
            this.text_correo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_enviarMail = new System.Windows.Forms.Button();
            this.button_CancelarEnvio = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox_Enviando = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Enviando)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(84)))), ((int)(((byte)(84)))));
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 23);
            this.label2.TabIndex = 211;
            this.label2.Text = "Envío de Comprobantes CFDI";
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 9F);
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(168)))));
            this.label14.Location = new System.Drawing.Point(6, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(369, 23);
            this.label14.TabIndex = 213;
            this.label14.Text = "_________________________________________________________________________________" +
                "________________";
            // 
            // Mensaje
            // 
            this.Mensaje.AutoSize = true;
            this.Mensaje.Font = new System.Drawing.Font("Arial", 9F);
            this.Mensaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.Mensaje.Location = new System.Drawing.Point(19, 112);
            this.Mensaje.Name = "Mensaje";
            this.Mensaje.Size = new System.Drawing.Size(54, 15);
            this.Mensaje.TabIndex = 209;
            this.Mensaje.Text = "Mensaje";
            // 
            // rtext_mensaje
            // 
            this.rtext_mensaje.Font = new System.Drawing.Font("Arial", 9F);
            this.rtext_mensaje.ForeColor = System.Drawing.SystemColors.ControlText;
            this.rtext_mensaje.Location = new System.Drawing.Point(79, 112);
            this.rtext_mensaje.Name = "rtext_mensaje";
            this.rtext_mensaje.Size = new System.Drawing.Size(270, 75);
            this.rtext_mensaje.TabIndex = 205;
            this.rtext_mensaje.Text = "";
            // 
            // Asunto
            // 
            this.Asunto.AutoSize = true;
            this.Asunto.Font = new System.Drawing.Font("Arial", 9F);
            this.Asunto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.Asunto.Location = new System.Drawing.Point(21, 87);
            this.Asunto.Name = "Asunto";
            this.Asunto.Size = new System.Drawing.Size(52, 15);
            this.Asunto.TabIndex = 206;
            this.Asunto.Text = "* Asunto";
            // 
            // text_asunto
            // 
            this.text_asunto.Font = new System.Drawing.Font("Arial", 9F);
            this.text_asunto.ForeColor = System.Drawing.SystemColors.ControlText;
            this.text_asunto.Location = new System.Drawing.Point(79, 84);
            this.text_asunto.Name = "text_asunto";
            this.text_asunto.Size = new System.Drawing.Size(270, 21);
            this.text_asunto.TabIndex = 204;
            // 
            // text_correo
            // 
            this.text_correo.Font = new System.Drawing.Font("Arial", 9F);
            this.text_correo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.text_correo.Location = new System.Drawing.Point(79, 55);
            this.text_correo.Name = "text_correo";
            this.text_correo.Size = new System.Drawing.Size(270, 21);
            this.text_correo.TabIndex = 202;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(21)))));
            this.label1.Location = new System.Drawing.Point(32, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 203;
            this.label1.Text = "* Para";
            // 
            // button_enviarMail
            // 
            this.button_enviarMail.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_enviarMail.Location = new System.Drawing.Point(197, 199);
            this.button_enviarMail.Name = "button_enviarMail";
            this.button_enviarMail.Size = new System.Drawing.Size(73, 25);
            this.button_enviarMail.TabIndex = 207;
            this.button_enviarMail.Text = "Enviar";
            this.button_enviarMail.UseVisualStyleBackColor = true;
            this.button_enviarMail.Click += new System.EventHandler(this.button_enviarMail_Click);
            // 
            // button_CancelarEnvio
            // 
            this.button_CancelarEnvio.Location = new System.Drawing.Point(276, 199);
            this.button_CancelarEnvio.Name = "button_CancelarEnvio";
            this.button_CancelarEnvio.Size = new System.Drawing.Size(73, 25);
            this.button_CancelarEnvio.TabIndex = 208;
            this.button_CancelarEnvio.Text = "Cancelar";
            this.button_CancelarEnvio.UseVisualStyleBackColor = true;
            this.button_CancelarEnvio.Click += new System.EventHandler(this.button_CancelarEnvio_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::FLXDSK.Properties.Resources.equis;
            this.pictureBox1.Location = new System.Drawing.Point(319, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 212;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox_Enviando
            // 
            this.pictureBox_Enviando.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Enviando.Image = global::FLXDSK.Properties.Resources.loading;
            this.pictureBox_Enviando.Location = new System.Drawing.Point(159, 200);
            this.pictureBox_Enviando.Name = "pictureBox_Enviando";
            this.pictureBox_Enviando.Size = new System.Drawing.Size(21, 23);
            this.pictureBox_Enviando.TabIndex = 210;
            this.pictureBox_Enviando.TabStop = false;
            this.pictureBox_Enviando.Visible = false;
            this.pictureBox_Enviando.WaitOnLoad = true;
            // 
            // Form_EnviarMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 233);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.Mensaje);
            this.Controls.Add(this.rtext_mensaje);
            this.Controls.Add(this.Asunto);
            this.Controls.Add(this.text_asunto);
            this.Controls.Add(this.text_correo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_Enviando);
            this.Controls.Add(this.button_enviarMail);
            this.Controls.Add(this.button_CancelarEnvio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_EnviarMail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enviar Factura";
            this.Load += new System.EventHandler(this.Form_EnviarMail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Enviando)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label Mensaje;
        private System.Windows.Forms.RichTextBox rtext_mensaje;
        private System.Windows.Forms.Label Asunto;
        private System.Windows.Forms.TextBox text_asunto;
        private System.Windows.Forms.TextBox text_correo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_Enviando;
        private System.Windows.Forms.Button button_enviarMail;
        private System.Windows.Forms.Button button_CancelarEnvio;
    }
}