using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Catalogos
{
    public partial class Form_CategoriasActivos : Form
    {
        Classes.Catalogos.Class_CategorigasActivos ClsCatAct = new Classes.Catalogos.Class_CategorigasActivos();
        string iidTipo = "";
        public event Form1.MessageHandler Lista_Categorias;

        public Form_CategoriasActivos(string idtmp)
        {
            InitializeComponent();
            iidTipo = idtmp;
        }

        private void Form_CategoriasActivos_Load(object sender, EventArgs e)
        {
            if (iidTipo != "") {
                cargaIngoID();
            }
        }
        private void cargaIngoID() {
            DataTable dt = new DataTable();
            dt = ClsCatAct.getInfoById(iidTipo);
            if (dt.Rows.Count > 0) {
                textBox_Descripcion.Text = dt.Rows[0]["vchDescripcion"].ToString();
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (textBox_Descripcion.Text == "") {
                MessageBox.Show("La descripcion es requerida");
                return;
            }
            if (iidTipo == "")
            {
                if (ClsCatAct.ExisteDescripcion(textBox_Descripcion.Text.Trim()))
                {
                    MessageBox.Show("La descripcion ya existe, elige otra");
                    return;
                }
                if (ClsCatAct.Guardar(textBox_Descripcion.Text.Trim()))
                {
                    MessageBox.Show("Guardado");
                    try
                    {
                        Lista_Categorias();
                    }
                    catch { }
                    this.Close();
                }
            }
            else { 
                if(ClsCatAct.Actualiza(textBox_Descripcion.Text.Trim(), iidTipo))
                {
                    MessageBox.Show("Guardado");
                    try
                    {
                        Lista_Categorias();
                    }
                    catch { }
                    this.Close();
                }
            }

            
        }
    }
}
