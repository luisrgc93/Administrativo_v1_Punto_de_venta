namespace FLXDSK.Formularios.Catalogos
{
    partial class Form_MovimientosActivos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MovimientosActivos));
            this.label_AlmacenActualTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Producto = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox_Cantidad = new System.Windows.Forms.TextBox();
            this.comboBox_Destino = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Destino = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Mover = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_AlmacenActualTitle
            // 
            this.label_AlmacenActualTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label_AlmacenActualTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label_AlmacenActualTitle.Font = new System.Drawing.Font("Arial", 10F);
            this.label_AlmacenActualTitle.ForeColor = System.Drawing.SystemColors.Window;
            this.label_AlmacenActualTitle.Location = new System.Drawing.Point(0, 0);
            this.label_AlmacenActualTitle.Name = "label_AlmacenActualTitle";
            this.label_AlmacenActualTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label_AlmacenActualTitle.Size = new System.Drawing.Size(500, 22);
            this.label_AlmacenActualTitle.TabIndex = 253;
            this.label_AlmacenActualTitle.Text = "Almacen Origen";
            this.label_AlmacenActualTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_AlmacenActualTitle);
            this.panel1.Controls.Add(this.label_Producto);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(501, 111);
            this.panel1.TabIndex = 350;
            // 
            // label_Producto
            // 
            this.label_Producto.AutoSize = true;
            this.label_Producto.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label_Producto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label_Producto.Location = new System.Drawing.Point(11, 31);
            this.label_Producto.Name = "label_Producto";
            this.label_Producto.Size = new System.Drawing.Size(59, 15);
            this.label_Producto.TabIndex = 211;
            this.label_Producto.Text = "Producto";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.textBox_Cantidad);
            this.panel2.Controls.Add(this.comboBox_Destino);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label_Destino);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(12, 138);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(501, 111);
            this.panel2.TabIndex = 351;
            // 
            // textBox_Cantidad
            // 
            this.textBox_Cantidad.Font = new System.Drawing.Font("Arial", 10F);
            this.textBox_Cantidad.Location = new System.Drawing.Point(373, 79);
            this.textBox_Cantidad.Name = "textBox_Cantidad";
            this.textBox_Cantidad.Size = new System.Drawing.Size(123, 23);
            this.textBox_Cantidad.TabIndex = 255;
            // 
            // comboBox_Destino
            // 
            this.comboBox_Destino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Destino.FormattingEnabled = true;
            this.comboBox_Destino.Location = new System.Drawing.Point(254, -1);
            this.comboBox_Destino.Name = "comboBox_Destino";
            this.comboBox_Destino.Size = new System.Drawing.Size(242, 21);
            this.comboBox_Destino.TabIndex = 254;
            this.comboBox_Destino.SelectionChangeCommitted += new System.EventHandler(this.comboBox_Destino_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label1.Size = new System.Drawing.Size(500, 22);
            this.label1.TabIndex = 253;
            this.label1.Text = "Seleccione el Almacen de Recepcion:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_Destino
            // 
            this.label_Destino.AutoSize = true;
            this.label_Destino.Font = new System.Drawing.Font("Arial", 9F);
            this.label_Destino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label_Destino.Location = new System.Drawing.Point(11, 32);
            this.label_Destino.Name = "label_Destino";
            this.label_Destino.Size = new System.Drawing.Size(68, 15);
            this.label_Destino.TabIndex = 210;
            this.label_Destino.Text = "Seleccione";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(67)))), ((int)(((byte)(67)))));
            this.label3.Location = new System.Drawing.Point(251, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 15);
            this.label3.TabIndex = 211;
            this.label3.Text = "Transferir Cantidad:";
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(422, 281);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(87, 27);
            this.button_Cancelar.TabIndex = 352;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Mover
            // 
            this.button_Mover.Location = new System.Drawing.Point(329, 281);
            this.button_Mover.Name = "button_Mover";
            this.button_Mover.Size = new System.Drawing.Size(87, 27);
            this.button_Mover.TabIndex = 353;
            this.button_Mover.Text = "Mover";
            this.button_Mover.UseVisualStyleBackColor = true;
            this.button_Mover.Click += new System.EventHandler(this.button_Mover_Click);
            // 
            // Form_MovimientosActivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 320);
            this.Controls.Add(this.button_Mover);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_MovimientosActivos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Movimientos de Activos";
            this.Load += new System.EventHandler(this.Form_MovimientosActivos_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_AlmacenActualTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Producto;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Destino;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Destino;
        private System.Windows.Forms.TextBox textBox_Cantidad;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Mover;
    }
}