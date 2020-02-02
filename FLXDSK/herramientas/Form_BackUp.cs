using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using aejw.Network;

namespace FLXDSK.heramientas
{
    public partial class Form_BackUp : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Herramientas.Class_BackUp ClsBac = new Classes.Herramientas.Class_BackUp();
        public Form_BackUp()
        {
            InitializeComponent();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (textBox_Nombre.Text != "")
            {
                GuardarBackUp();
                textBox_Nombre.Text = "";
            }
            else
            {
                MessageBox.Show("Ingrese un nombre al backup");
                return;
            }
        }

        protected void GuardarBackUp()
        {
            
            string RUTASERVER = "";
            string USERSERVER = "";
            string CLAVESERVER = "";
            try
            {
                //Veo si existen la infomracion correcta dpara el conection server
                RUTASERVER = ConfigurationManager.AppSettings["RUTASERVER"];
                USERSERVER = Conexion.Decrypt(ConfigurationManager.AppSettings["USERSERVER"]);
                CLAVESERVER = Conexion.Decrypt(ConfigurationManager.AppSettings["CLAVESERVER"]);
            }
            catch {
                MessageBox.Show("Informacion de configuracion con el server file, necesaria");
                return;
            }
            if (RUTASERVER == "" || USERSERVER == "" || CLAVESERVER == "")
            {
                MessageBox.Show("Es necesario configurar la conexion con el servidor para los archivos");
                return;
            }

            NetworkDrive oNetDrive = new aejw.Network.NetworkDrive();
            try
            {                
                oNetDrive.LocalDrive = "Y:";
                oNetDrive.ShareName = @RUTASERVER;
                try
                {
                    try
                    {
                        oNetDrive.UnMapDrive();
                    }
                    catch { }
                    oNetDrive.MapDrive(USERSERVER, CLAVESERVER);
                }
                catch { }
            }
            catch
            {
                MessageBox.Show("No se pudo conectar con el servidor de archivos");
                return;
            }
            CreateFolder(RUTASERVER + "\\BackUp");
            button_Guardar.Enabled = false;

            string FechAc = DateTime.Now.Date.ToString().Substring(0, 10);

            string[] val2 = FechAc.Split('/');
            string fecha = val2[2] + val2[1] + val2[0];

            string NombreBackup = RUTASERVER+"\\BackUp\\" + fecha + "-" + textBox_Nombre.Text + ".bak";
            
            string sql = " BACKUP DATABASE [FLEXCIM] TO  DISK = N'" + NombreBackup + "'" +
                            " WITH NOFORMAT, NOINIT,  NAME = N'FLEXCIM-Completa Base de datos Copia de seguridad', " +
                            " SKIP, NOREWIND, NOUNLOAD,  STATS = 10";

         

            if (Conexion.InsertaSql(sql))
            {
                string ruta = RUTASERVER + "\\BackUp";
                string rutacompleta = ruta + "\\"  + fecha + "-" + textBox_Nombre.Text + ".bak";
                try
                {
                    
                    DataTable dtInfo = new DataTable();
                    dtInfo.Columns.Add("idUsuario", System.Type.GetType("System.String"));
                    dtInfo.Columns.Add("idEmpresa", System.Type.GetType("System.String"));
                    dtInfo.Columns.Add("Nombre", System.Type.GetType("System.String"));
                    dtInfo.Columns.Add("Ruta", System.Type.GetType("System.String"));
                    DataRow Drw;

                    Drw = dtInfo.NewRow();
                    Drw["idUsuario"] = Classes.Class_Session.Idusuario;
                    Drw["idEmpresa"] = Classes.Class_Session.IDEMPRESA;
                    Drw["Nombre"] = fecha + "-" + textBox_Nombre.Text + ".bak";
                    Drw["Ruta"] = ruta;
                    dtInfo.Rows.Add(Drw);

                    if (ClsBac.GuardarRegistroBackup(dtInfo))
                    {
                        MessageBox.Show("Backup Generado Exsitosamente.");
                        CargaListaBackup();
                    }
                    else
                    {
                        MessageBox.Show("Problema al Guardar");
                    }

                }
                catch (Exception exp)
                {
                    MessageBox.Show("El backup se genero correctamente pero el registro tuvo algun problema.\n\r" + exp.ToString());
                }

            }
            else
            {
                MessageBox.Show("Problemas al generar el backup.");
            }
            oNetDrive.LocalDrive = "Y:";
            oNetDrive.ShareName = @RUTASERVER;
            try
            {
                oNetDrive.UnMapDrive();
            }
            catch { }
            button_Guardar.Enabled = true;
        }
        
        private void CreateFolder(string ruta)
        {
            bool isExists = System.IO.Directory.Exists(ruta);
            if (!isExists)
                System.IO.Directory.CreateDirectory(ruta);
        }

        private void CargaListaBackup()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView1.DataSource = null;
            string sql = " SELECT TOP 5 B.iidBackUp idBackup,U.vchNombre Usuario,B.vchNombre Nombre,B.vchRuta Ruta, " +
                         " CONVERT(DATE,B.dFechaIn,103) AS Fecha FROM catBackUp B, catUsuarios U  WHERE B.iidUsuario = U.iidUsuario ORDER BY B.dFechaIn DESC";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];
                dataGridView1.Columns["idBackup"].Visible = false;
                dataGridView1.Columns["Usuario"].Width = 190;
                dataGridView1.Columns["Usuario"].ReadOnly = true;
                dataGridView1.Columns["Nombre"].Width = 190;
                dataGridView1.Columns["Nombre"].ReadOnly = true;
                dataGridView1.Columns["Ruta"].Width = 190;
                dataGridView1.Columns["Ruta"].ReadOnly = true;
                dataGridView1.Columns["Fecha"].Width = 190;
                dataGridView1.Columns["Fecha"].ReadOnly = true;

                if (!dataGridView1.Columns.Contains("Seleccionar"))
                {
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "Seleccionar";
                    checkColumn.HeaderText = "Seleccionar";
                    checkColumn.Width = 80;
                    checkColumn.FillWeight = 40;
                    dataGridView1.Columns.Insert(0, checkColumn);
                }


            }
            catch
            {
                MessageBox.Show("No hay Informacion");
            }


        }

        private void Form_BackUp_Load(object sender, EventArgs e)
        {
            CargaListaBackup();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string RUTASERVER = "";
            string USERSERVER = "";
            string CLAVESERVER = "";
            try
            {
                //Veo si existen la infomracion correcta dpara el conection server
                RUTASERVER = ConfigurationManager.AppSettings["RUTASERVER"];
                USERSERVER = Conexion.Decrypt(ConfigurationManager.AppSettings["USERSERVER"]);
                CLAVESERVER = Conexion.Decrypt(ConfigurationManager.AppSettings["CLAVESERVER"]);
            }
            catch
            {
                MessageBox.Show("Informacion de configuracion con el server file, necesaria");
                return;
            }
            if (RUTASERVER == "" || USERSERVER == "" || CLAVESERVER == "")
            {
                MessageBox.Show("Es necesario configurar la conexion con el servidor para los archivos");
                return;
            }

            //Valida que haya mas de un registro seleccionado  
            int contador = 0;
            //Finaliza modo de edicion
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar al un Backup.");
                return;
            }

            DialogResult resultado;
            resultado = MessageBox.Show(@"Desea descargar estos Backup´s", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);


            if (DialogResult.OK == resultado)
            {
                dataGridView1.EndEdit();
                foreach (DataGridViewRow registro in dataGridView1.Rows)
                {
                    try
                    {
                        if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                        {
                            try
                            {
                                string backup = registro.Cells["Nombre"].Value.ToString();
                                string origen = registro.Cells["Ruta"].Value.ToString();
                                string destino = "";
                                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                                {
                                    destino = folderBrowserDialog1.SelectedPath;
                                }
                                else {
                                    return;
                                }

                                string origFil = System.IO.Path.Combine(origen, backup);
                                string destArch = System.IO.Path.Combine(destino, backup);

                                if (!System.IO.Directory.Exists(destino))
                                {
                                    System.IO.Directory.CreateDirectory(destino);
                                }

                                NetworkDrive oNetDrive = new aejw.Network.NetworkDrive();
                                oNetDrive.LocalDrive = "Y:";
                                oNetDrive.ShareName = @RUTASERVER;
                                try
                                {
                                    try
                                    {
                                        oNetDrive.UnMapDrive();
                                    }
                                    catch { 
                                    }
                                    oNetDrive.MapDrive(USERSERVER, CLAVESERVER);
                                }
                                catch { }
                                try
                                {
                                    System.IO.File.Copy(origFil, destArch, true);
                                }
                                catch {
                                    MessageBox.Show("El archivo no se encuentra disponible");
                                }

                                oNetDrive.LocalDrive = "Y:";
                                oNetDrive.ShareName = @RUTASERVER;
                                oNetDrive.UnMapDrive();

                                MessageBox.Show("Descargados con exito");
                            }
                            catch
                            {
                                MessageBox.Show("Problema al descargar el archivo");
                            }
                        }
                    }
                    catch { }                    
                }
            }
        
        }

        private void button_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
