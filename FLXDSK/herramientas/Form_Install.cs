using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace FLXDSK.herramientas
{
    public partial class Form_Install : Form
    {
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();

        public Form_Install()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {///salir
            MessageBox.Show("Esta usted saliendo de la instalación, es necesario inicie de nuevo el sistema.");
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Esta usted saliendo de la instalación, es necesario inicie de nuevo el sistema.");
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form_Load frm = new Form_Load();
            frm.ShowDialog();
        }
        
        private void label9_Click(object sender, EventArgs e)
        {
            Form_conexion frm = new Form_conexion();
            frm.ShowDialog();
        }

        private void Form_Install_Load(object sender, EventArgs e)
        {
           
        }

        private void label_DB_Click(object sender, EventArgs e)
        {
           
            string MachinName = System.Windows.Forms.SystemInformation.ComputerName;
            string sql = getSqlDb();
            string respuesta = conx.EjecutaQueryIni(sql);
            if (respuesta == "La base de datos fue creada con exito.")
            {
                MessageBox.Show("Instalado Correctamente. Inicie session de nuevo");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Problema al instalar lad Base de datos.");
            }

        }
        public string getSqlDb()
        {
            string url = "http://flexorerp.mx/administracion/Classes/sql/flexor/SQL_Flexor.sql";
            WebRequest request = HttpWebRequest.Create(url);
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("ISO-8859-2"));
            string urlText = reader.ReadToEnd();
            return urlText;
        }
        
        
    }
}
