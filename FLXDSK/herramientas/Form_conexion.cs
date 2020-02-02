using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace FLXDSK.herramientas
{
    public partial class Form_conexion : Form
    {
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();

        public Form_conexion()
        {
            InitializeComponent();
        }

        private void button_Test_Click(object sender, EventArgs e)
        {
            if (conx.TestConexion())
            {
                MessageBox.Show("Conexión Realizada con Éxito!!");
                MessageBox.Show("El sistema necesita iniciarse nuevamente para aplicar los cambios de la conexión.");
            }
            else {
                MessageBox.Show("Error de Conexión :( ");
            }
        }

        private void Form_conexion_Load(object sender, EventArgs e)
        {
            //Obtener la informacion del config
            textBox_Servidor.Text = ConfigurationManager.AppSettings["server"];
            textBox_Usuario.Text = ConfigurationManager.AppSettings["usuario_DB"];
            textBox_Db.Text = ConfigurationManager.AppSettings["DB"];
            textBox_Clave.Text = ConfigurationManager.AppSettings["clave_DB"];
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            button_Guardar.Enabled = true;
            if (conx.TestConexion())
            {
                GuardarInfoConec();
            }
            else {
                if (MessageBox.Show(@"La conexión no es correcta desea guardar de todas formas?", "Confirm guardar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    GuardarInfoConec();
                }
                else
                {
                    this.Close();
                }
            }
            button_Guardar.Enabled = false ;
            Application.Exit();
        }
        private void GuardarInfoConec() {
            EscribeValores("server", textBox_Servidor.Text);
            EscribeValores("usuario_DB", textBox_Usuario.Text);
            EscribeValores("DB", textBox_Db.Text);
            EscribeValores("clave_DB", textBox_Clave.Text);
            MessageBox.Show("Guardado con Exito");
        }
        public bool EscribeValores(string parametro, string valor)
        {
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration
                    (ConfigurationUserLevel.None);
            //config.AppSettings.Settings.Add("ModificationDate",DateTime.Now.ToLongTimeString() + " ");
            //eliminamos la clave actual (si existe), si no la eliminamos
            //los valores se irán acumulando separados por coma
            config.AppSettings.Settings.Remove(parametro);
            config.AppSettings.Settings.Add(parametro, valor);

            try
            {
                config.Save(ConfigurationSaveMode.Modified);
                //config.Save(ConfigurationSaveMode.Modified);
                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
