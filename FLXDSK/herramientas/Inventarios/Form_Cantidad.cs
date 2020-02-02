using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.herramientas.Inventarios
{
    public partial class Form_Cantidad : Form
    {
        string iidMateriPrima = "";
     

        Classes.Internos.Class_UnidadesMetricas ClsUnidadMetrica = new Classes.Internos.Class_UnidadesMetricas();
        Classes.Catalogos.Mercancia.Class_Materia_Prima ClsMateriaPrim = new Classes.Catalogos.Mercancia.Class_Materia_Prima();

        public Form_Cantidad(string iidMateriPrima)
        {
            InitializeComponent();
            this.iidMateriPrima = iidMateriPrima;
        }
        public void LlenadoUnidades(string vchAbreviacion)
        {
            DataTable dtInfo = ClsUnidadMetrica.getListaWhere(" WHERE vchPar = '" + vchAbreviacion + "' ");
            comboBox_UnidadMetrica.DataSource = dtInfo;
            comboBox_UnidadMetrica.DisplayMember = "vchNombre";
            comboBox_UnidadMetrica.ValueMember = "iidUnidad";
        }

        private void Form_Cantidad_Load(object sender, EventArgs e)
        {
            if (iidMateriPrima == "")
            {
                MessageBox.Show("Informacion Incorrecta");
                this.Close();
                return;
            }

            DataTable dtInfo = ClsMateriaPrim.getLista(" AND M.iidMateriPrima = " + iidMateriPrima);
            if (dtInfo.Rows.Count == 0)
            {
                MessageBox.Show("Informacion no encontrada");
                this.Close();
                return;
            }

            LlenadoUnidades(dtInfo.Rows[0]["vchAbreviacion"].ToString());
            string iidUnidadMateria = dtInfo.Rows[0]["iidUnidad"].ToString();
            try
            {
                comboBox_UnidadMetrica.SelectedValue = iidUnidadMateria;
            }
            catch { }
        }

        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            ValidaCantidad();
        }

        private void ValidaCantidad()
        {
            string IdUnidad = "";
            if (textBox_Cantidad.Text.Trim() != "")
            {
                
                try
                {
                    IdUnidad = comboBox_UnidadMetrica.SelectedValue.ToString();
                    Classes.Class_Session.NameMedida = comboBox_UnidadMetrica.Text;
                }
                catch { }

                if (IdUnidad == "" || IdUnidad == "0")
                {
                    MessageBox.Show("Seleccione una Unidad");
                    return;
                }

                DataTable dtInfoExis = ClsUnidadMetrica.getListaWhere(" WHERE iidUnidad = "+IdUnidad);
                if(dtInfoExis.Rows.Count == 0)
                {
                    MessageBox.Show("Medida Seleccionada Incorrecta");
                    return;
                }
                

                try
                {
                    Classes.Class_Session.fNewExistencia = Convert.ToDouble(textBox_Cantidad.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Formato Numerico Incorrecto");
                    return;
                }
                
                
                this.Close();
            }
            else
            {
                MessageBox.Show("Ingrese la Cantidad");
            }
        }

        private void textBox_Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                ValidaCantidad();
            }
        }

        
    }
}
