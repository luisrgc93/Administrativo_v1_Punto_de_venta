using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Administracion
{
    public partial class Form_ParametrosGenerales : Form
    {
        Classes.Class_ParametrosGenerales fnParaGen = new Classes.Class_ParametrosGenerales();

        public Form_ParametrosGenerales()
        {
            InitializeComponent();
        }

        private void Form_ParametrosGenerales_Load(object sender, EventArgs e)
        {
            CargaListaParametros();
        }

        private void CargaListaParametros()
        {
            DataTable dt = new DataTable("Lista");
            dt = fnParaGen.getListaconfiguraciones();

            comboBox_IdParametro.DataSource = dt;
            comboBox_IdParametro.DisplayMember = "vchTipo";
            comboBox_IdParametro.ValueMember = "iidConfiguracion";
        }

        private void comboBox_IdParametro_SelectedValueChanged(object sender, EventArgs e)
        {
            string idconf = comboBox_IdParametro.SelectedValue.ToString();
            if (idconf != "" && idconf != "0")
            {
                string valor = fnParaGen.getValueConfigByID(idconf);
                textBox_Mensaje.Text = valor;
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            string idconf = comboBox_IdParametro.SelectedValue.ToString();
            string valor = textBox_Mensaje.Text;

            if (valor != "")
            {
                if (fnParaGen.ActualizaConfiguracion(idconf, valor))
                {
                    MessageBox.Show("Almacenado con éxito");
                    Classes.Class_Session.dtParamConf = fnParaGen.getListaconfiguraciones();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problema al almacenar, comuníquese con el administrador.");
                }
            }
            else { MessageBox.Show("Favor de Ingresar el valor"); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
