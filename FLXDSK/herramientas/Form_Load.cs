using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Configuration;
using System.Data.Sql;

namespace FLXDSK.herramientas
{
    public partial class Form_Load : Form
    {
        System.Windows.Forms.Timer MyTimer = new System.Windows.Forms.Timer();
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();

        public Form_Load()
        {
            InitializeComponent();
        }
        
        private void Form_Load_Load(object sender, EventArgs e)
        {
            labelInfo.Text = "";
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += delegate(object s, EventArgs ee)
            {
                ((Timer)s).Stop();
                IniciaProceso();
            };
            timer.Start();

        }
        
        private void IniciaProceso(){
            if (ExisteInstanciaFlex())
            {
                labelInfo.Text = labelInfo.Text + " \n La instancia ya se encuentra Instalada....";
                labelInfo.Text = labelInfo.Text + " \n Intentando crear la Base de datos....";
                IniciaProcesoBasedDatos();
            }
            else
            {
                labelInfo.Text = labelInfo.Text + " \n Inicia el Proceso de instalación del servidor...";
                string Clavesa = "FlexItrolMx12";
                string Instancia = "SQLITROL";
                string MachinName = System.Windows.Forms.SystemInformation.ComputerName;
                string serverMachine = MachinName + "\\" + Instancia;
                 try
                 {
                     ///comensar instalador servidor.
                     Process p = new Process();
                     ProcessStartInfo psi = new ProcessStartInfo();
                     psi.FileName = Application.StartupPath.Trim() + @"/program/SQLEXPR_x86_ESN.exe";
                     //labelInfo.Text = labelInfo.Text + " \n " + Application.StartupPath.Trim() + @"/program/SQLEXPR_x86_ESN.exe";
                     //psi.FileName =  @"program/SQLEXPR_x86_ESN.exe";
                     //-q[n|b|r|f]   Sets user interface (UI) level:
                     //n = no UI
                     //b = basic UI (progress only, no prompts)
                     //r = reduced UI (dialog at the end of installation)
                     //f = full UI
                     labelInfo.Text = labelInfo.Text + " \n Preparando Instrucciones del motor de datos...";

                     psi.Arguments = " /ACTION=Install /QS /FEATURES=SQL /INSTANCENAME=SQLITROL /SECURITYMODE=\"SQL\" /SQLSVCACCOUNT=\"NT AUTHORITY\\SYSTEM\" /SAPWD=\"FlexItrolMx12\" /SQLSYSADMINACCOUNTS=\"BUILTIN\\ADMINISTRATORS\" /ENABLERANU=1 /AGTSVCACCOUNT=\"NT AUTHORITY\\SYSTEM\" /TCPENABLED=1 /ERRORREPORTING=1 ";
                     p.StartInfo = psi;
                     p.Start();
                     p.WaitForExit();
                     //MessageBox.Show("Process exited with {0}!" + p.ExitCode);
                     labelInfo.Text = labelInfo.Text + " \n Instalacion del motor datos con exito...";
                     ///Inscribimos los balores
                     GuardarInfoConec(serverMachine, "sa", "DBFLEX", Clavesa);
                     //////Inicira proceso de creacion DB
                     IniciaProcesoBasedDatos();
                 }
                 catch
                 {
                 }

                
                ///Escribimos valores
            }
        }
        private void IniciaProcesoBasedDatos()
        {
            
           // labelInfo.Text = labelInfo.Text + " \n Instalacion del motor datos con exito...";
            labelInfo.Text = "";
            Timer timer = new Timer();
            timer.Interval = 8000;
            timer.Tick += delegate(object s, EventArgs ee)
            {
                ((Timer)s).Stop();
                BegininDB();
            };
            timer.Start();
        }
        private void BegininDB(){
            labelInfo.Text = labelInfo.Text + " \n Obteniendo las Bases de datos";
            string MachinName = System.Windows.Forms.SystemInformation.ComputerName;
            string sql = getSqlDb();

            labelInfo.Text = labelInfo.Text + " \n Instalando la base de datos...";
            string respuesta = conx.EjecutaQueryIni(sql);
            //MessageBox.Show(respuesta);
            if (respuesta == "La base de datos fue creada con exito.")
            {
                labelInfo.Text = labelInfo.Text + " \n Instalado Correctamente...";
                MessageBox.Show("Instalado Correctamente. Inicie session de nuevo");
                Application.Exit();
            }
            else {
                labelInfo.Text = labelInfo.Text + " \n Problema al Instalar la Base de datos...";
                labelInfo.Text = labelInfo.Text + " \n " ;
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
        private void GuardarInfoConec(string server, string usuario, string db, string clave)
        {
            labelInfo.Text = "Guardando valores de conexion...";
            EscribeValores("server", server);
            EscribeValores("usuario_DB", usuario);
            EscribeValores("DB", db);
            EscribeValores("clave_DB", clave);
        }
        public bool EscribeValores(string parametro, string valor)
        {
            /*System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration
                    (ConfigurationUserLevel.None);*/

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
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
        ////////Nombres de Isntancias
        public bool ExisteInstanciaFlex()
        {
            DataTable table = new DataTable();
            table = getInstances();
            foreach (System.Data.DataRow row in table.Rows)
            {
                if (row["InstanceName"].ToString() == "SQLITROL")
                {
                    return true;
                }
                /* foreach (System.Data.DataColumn col in table.Columns)
                 {
                     MessageBox.Show("{0} = {1}"+ col.ColumnName.ToString()+" - "+row[col].ToString());
                 }*/
            }
            return false;
        }
        public DataTable getInstances()
        {
            // Retrieve the enumerator instance and then the data.
            SqlDataSourceEnumerator instance =
              SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table = instance.GetDataSources();
            return table;
        }
    }
}
