namespace FLXDSK.Formularios.Configuracion
{
    partial class Form_QrConexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_QrConexion));
            this.pictureBox_Qr = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Qr)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Qr
            // 
            this.pictureBox_Qr.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox_Qr.Location = new System.Drawing.Point(99, 116);
            this.pictureBox_Qr.Name = "pictureBox_Qr";
            this.pictureBox_Qr.Size = new System.Drawing.Size(300, 300);
            this.pictureBox_Qr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Qr.TabIndex = 0;
            this.pictureBox_Qr.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 10.25F);
            this.label1.Location = new System.Drawing.Point(73, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Escanie el Qr que se muestra abajo para habilitar los dispositivos móviles";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form_QrConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(499, 458);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_Qr);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_QrConexion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Qr de Conexión";
            this.Load += new System.EventHandler(this.Form_QrConexion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Qr)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Qr;
        private System.Windows.Forms.Label label1;
    }
}