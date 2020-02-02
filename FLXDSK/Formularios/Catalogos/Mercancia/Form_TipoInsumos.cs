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
    public partial class Form_TipoInsumos : Form
    {
        string idtipo = "";
        Classes.Catalogos.Class_Insumos ClsIns = new Classes.Catalogos.Class_Insumos();

        public event Form1.MessageHandler Lista_tipos_insumos;

        public Form_TipoInsumos(string idtemp)
        {
            InitializeComponent();
            idtipo = idtemp;
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            string nombre = textBox_Nombre.Text;
            string descripcion = textBox_descripcion.Text;

            if ( nombre == "")
            {
                MessageBox.Show("Llenar los campos requeridos");
                return;
            }

            if (idtipo == "")
            {
                if (!ClsIns.existe_tipo_insumo(nombre))
                {
                    if (ClsIns.inserta_tipo_insumos(nombre,descripcion))
                    {
                        MessageBox.Show("Tipo de insumos guardado exitosamente", "Exito");
                        try
                        {
                            Lista_tipos_insumos();
                            this.Close();
                        }
                        catch
                        { }
                    }
                    else
                    {
                        MessageBox.Show("Probleamas al guardar. Intente mas tarde", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("El nombre para el tipo de insumo que desea registrar ya existe", "Error");
                    return;
                }
            }
            else
            {
                if (ClsIns.actualiza_tipo_insumo(nombre,descripcion,idtipo))
                {
                    MessageBox.Show("Tipo de Insumo actualizado exitosamente");
                    try
                    {
                        Lista_tipos_insumos();
                        this.Close();
                    }
                    catch
                    { }
                }
                else
                {
                    MessageBox.Show("Probleamas al actualizar. Intente mas tarde");
                }
            }
        }

        private void Form_TipoInsumos_Load(object sender, EventArgs e)
        {
            if (idtipo != "")
            {
                obtener_datos();
            }
        }

        private void obtener_datos()
        {
            DataTable datos = new DataTable();
            datos = ClsIns.obtener_tipo_insumos(idtipo);

            DataRow row = datos.Rows[0];

            textBox_Nombre.Text = row["vchNombre"].ToString();
            textBox_descripcion.Text = row["vchDescripcion"].ToString();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
