using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Catalogos.Mercancia
{
    public partial class Form_Categoria_MateriaPrima : Form
    {
        string IdPassetext = "";

        Classes.Catalogos.Mercancia.Class_Materia_Prima_Categoria ClsCatMateriaPrima = new Classes.Catalogos.Mercancia.Class_Materia_Prima_Categoria();

        public event Form1.MessageHandler CargaLista;

        public Form_Categoria_MateriaPrima(string id)
        {
            InitializeComponent();
            IdPassetext = id;
        }

        private void Form_Categoria_MateriaPrima_Load(object sender, EventArgs e)
        {
            if (IdPassetext != "")
                getInfoById();
            
        }

        public void getInfoById()
        {
            DataTable dtInfo = ClsCatMateriaPrima.getListaWhere(" WHERE iidCategoriaMateriPrima = " + IdPassetext);
            if (dtInfo.Rows.Count == 0)
            {
                MessageBox.Show("Informacion no encontradad ");
                this.Close();
                return;
            }
            textBox_Codigo.Text = dtInfo.Rows[0]["vchCodigo"].ToString();
            textBox_Descripcion.Text = dtInfo.Rows[0]["vchDescripcion"].ToString();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (textBox_Descripcion.Text.Trim() == "")
            { 
                MessageBox.Show("Llenar los campos requeridos"); 
                return; 
            }


            if (IdPassetext == "")
            {
                DataTable dtExis = ClsCatMateriaPrima.getListaWhere(" WHERE iidEstatus = 1 AND vchDescripcion = '" + textBox_Descripcion.Text.Trim() + "' ");
                if (dtExis.Rows.Count > 0)
                {
                    MessageBox.Show("El Nombre ingresado ya existe, elige otro");
                    return; 
                }


                if (ClsCatMateriaPrima.InsertaInformacion(textBox_Codigo.Text.Trim(), textBox_Descripcion.Text.Trim()))
                {
                    MessageBox.Show("Guardado con exito.");

                    try
                    {
                        CargaLista();
                    }
                    catch { }

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problemas al guardar, intente mas tarde.");
                }
            }
            else
            {

                DataTable dtExis = ClsCatMateriaPrima.getListaWhere(" WHERE iidEstatus = 1 AND vchDescripcion = '" + textBox_Descripcion.Text.Trim() + "' AND iidCategoriaMateriPrima <>  "+ IdPassetext);
                if (dtExis.Rows.Count > 0)
                {
                    MessageBox.Show("El Nombre ingresado ya existe, elige otro");
                    return;
                }

                if (ClsCatMateriaPrima.ActualizaInformacion(textBox_Codigo.Text.Trim(), textBox_Descripcion.Text.Trim(), IdPassetext))
                {
                    MessageBox.Show("Actualizado con exito.");
                    try
                    {
                        CargaLista();
                    }
                    catch { }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problemas al actualizar, intente mas tarde.");
                }
            }
        }
    }
}
