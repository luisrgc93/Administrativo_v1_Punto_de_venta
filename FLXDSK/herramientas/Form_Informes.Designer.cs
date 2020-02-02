namespace FLXDSK.herramientas
{
    partial class Form_Informes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Informes));
            this.button_Comenzar = new System.Windows.Forms.Button();
            this.label_porcentaje = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // button_Comenzar
            // 
            this.button_Comenzar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Comenzar.Location = new System.Drawing.Point(7, 6);
            this.button_Comenzar.Name = "button_Comenzar";
            this.button_Comenzar.Size = new System.Drawing.Size(79, 23);
            this.button_Comenzar.TabIndex = 131;
            this.button_Comenzar.Text = "Comenzar";
            this.button_Comenzar.UseVisualStyleBackColor = true;
            this.button_Comenzar.Click += new System.EventHandler(this.button_Comenzar_Click);
            // 
            // label_porcentaje
            // 
            this.label_porcentaje.Font = new System.Drawing.Font("Arial", 9F);
            this.label_porcentaje.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label_porcentaje.Location = new System.Drawing.Point(200, 61);
            this.label_porcentaje.Name = "label_porcentaje";
            this.label_porcentaje.Size = new System.Drawing.Size(121, 18);
            this.label_porcentaje.TabIndex = 130;
            this.label_porcentaje.Text = "0%";
            this.label_porcentaje.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(7, 35);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(314, 23);
            this.progressBar1.TabIndex = 129;
            // 
            // Form_Informes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 85);
            this.Controls.Add(this.button_Comenzar);
            this.Controls.Add(this.label_porcentaje);
            this.Controls.Add(this.progressBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_Informes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Envío de informes";
            this.Load += new System.EventHandler(this.Form_Informes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Comenzar;
        private System.Windows.Forms.Label label_porcentaje;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}