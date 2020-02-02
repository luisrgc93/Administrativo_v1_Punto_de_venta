using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Data.SqlClient;

namespace FLXDSK.Listas.Ventas
{
    public partial class Form_List_Facturas : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Facturas.Class_Factura ClsFac = new Classes.Facturas.Class_Factura();
        Classes.Class_Empresa ClsEmp = new Classes.Class_Empresa();
        Classes.Catalogos.Administracion.Class_AccesosUsuarios ClsAccUsu = new Classes.Catalogos.Administracion.Class_AccesosUsuarios();
        Classes.Facturas.Class_Certificado ClsCer = new Classes.Facturas.Class_Certificado();
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();


        private string folderName;
        [FileIOPermission(SecurityAction.Demand, Write = @"C:\")]

        public Form_List_Facturas()
        {
            InitializeComponent();

            int largo = this.Width;
            textBox_Buscar.Location = new Point(largo - 100, 5);//mide 
            pictureBox_Serch.Location = new Point(largo - (100 - 175), 3);
        }

        private void Form_List_Facturas_Load(object sender, EventArgs e)
        {
            dateTimePicker_FI.Value = DateTime.Now.AddDays(-2);
            dateTimePicker_FF.Value = DateTime.Now.AddDays(1);

            dateTimePicker_FI.Format = DateTimePickerFormat.Custom;
            dateTimePicker_FI.CustomFormat = "dd/MM/yyyy";
            dateTimePicker_FF.Format = DateTimePickerFormat.Custom;
            dateTimePicker_FF.CustomFormat = "dd/MM/yyyy";


            HabilitarMenuOpc();
            CargaListaAllFac();
        }
        private void HabilitarMenuOpc()
        {
            string idUsuario = Convert.ToString(Classes.Class_Session.Idusuario);
            string idEmpresa = Classes.Class_Session.IDEMPRESA.ToString();
            DataTable accUsu = new DataTable();
            accUsu = ClsAccUsu.gerAccesoModuloUsu(idUsuario, idEmpresa);

            if (accUsu.Rows.Count > 0)
            {
                foreach (DataRow modulo in accUsu.Rows)
                {
                    string nameToolModulo = modulo["vchNameToolMenu"].ToString();
                    if (nameToolModulo == "crearFacturaToolStripMenuItem")
                    {
                        toolStripButton_Add.Enabled = true;
                    }
                    if (nameToolModulo == "toolStripButton_Cancelar")
                    {
                        toolStripButton_Cancelar.Enabled = true;
                    }

                }
            }
        }
        private void CargaListaAllFac()
        {
            string filtro = "";
            string[] val = dateTimePicker_FI.Text.Split('/');
            string FI = val[2] + "-" + val[1] + "-" + val[0] + "T00:00:00";

            val = dateTimePicker_FF.Text.Split('/');
            string FF = val[2] + "-" + val[1] + "-" + val[0] + "T23:59:59";

            if (FI == "" || FF == "") { MessageBox.Show("Informacion de fechas requerida"); return; }
            filtro = " AND V.dfechaTimbrado between '" + FI + "' AND '" + FF + "' ";


            string sql = " " +
            " SELECT V.iidFactura Id, " +
                " V.vchSerie+'-'+CAST(V.iFolio as varchar(11)) Folio,  " +
                " CONVERT(VARCHAR(10),V.dfechaTimbrado,103) FechaTimbrado,  " +
                " CASE SiCancelado WHEN 1 Then 'Cancelado' else 'Vigente' END Estatus, " +
                " F.vchDescripcion FormaPago, " +
                " C.vchRFC RFC, " +
                " C.vchAlias Cliente, " +
                " ftotal Total " +
             " FROM MovFacturas V (NOLOCK) , catClientes C (NOLOCK) , int_satFormaPago F (NOLOCK) " +
             " WHERE V.iidCliente = C.iidCliente  " +
             " AND V.iidFormaPago = F.iidFormaPago " +
             " AND V.SiCompletado =  1 " +
             " AND V.iidEmpresa = " +Classes.Class_Session.IDEMPRESA.ToString() + 
                  " " +filtro   + 
             " ORDER BY V.dfechaTimbrado desc ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];
                //Se define el tamaño de las columnas
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["Folio"].Width = 50;
                dataGridView1.Columns["FechaTimbrado"].Width = 80;
                dataGridView1.Columns["FormaPago"].Width = 70;
                dataGridView1.Columns["RFC"].Width = 100;
                dataGridView1.Columns["Cliente"].Width = 100;
                dataGridView1.Columns["Total"].Width = 60;

                dataGridView1.Columns["Folio"].ReadOnly = true;
                dataGridView1.Columns["FechaTimbrado"].ReadOnly = true;
                dataGridView1.Columns["FormaPago"].ReadOnly = true;
                dataGridView1.Columns["RFC"].ReadOnly = true;
                dataGridView1.Columns["Cliente"].ReadOnly = true;
                dataGridView1.Columns["Total"].ReadOnly = true;

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
            }
            bs.DataSource = dataGridView1.DataSource;

        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Facturacion.Form_Factura frm = new Formularios.Facturacion.Form_Factura();
            frm.CargaListaAllFac += new Form1.MessageHandler(CargaListaAllFac);
            frm.Show();
        }

        private void toolStripButton_downloadXml_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            int contador = 0;
            string IdRegistros = "0";
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistros += "," + registro.Cells["Id"].Value;
                    }

                }
                catch { }
            }
            if (contador == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un registro.");
                return;
            }


            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                folderName = folderBrowserDialog1.SelectedPath;
                string[] Listas = IdRegistros.Split(',');
                foreach (string folio in Listas)
                {
                    if (folio != "" && folio != "0")
                    {
                        DataTable dtarchivo = ClsFac.getInfoByID(folio);
                        
                        string archivo = (string)dtarchivo.Rows[0]["vchCfdi"] + "";
                        string uuid = dtarchivo.Rows[0]["vchuuid"].ToString();

                        //save the file xml
                        System.IO.StreamWriter sw = new System.IO.StreamWriter(folderName + "\\" + uuid + ".xml");
                        sw.WriteLine(archivo);
                        sw.Close();
                    }
                }


                MessageBox.Show("Archivo(s) guardado(s)");
                
            }
            else
            {
                return;
            }
        }

        private void toolStripButton_DowloandPDF_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            int contador = 0;
            string  IdRegistros = "0";
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistros += "," + registro.Cells["Id"].Value;
                    }
                }
                catch { }
            }
            if (contador == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un registro.");
                return;
            }

            string[] Listas = IdRegistros.Split(',');
            foreach (string folio in Listas)
            {
                if (folio != "" && folio != "0")
                {
                    Reportes.Catalogos.Form_Factura frmfacturas = new Reportes.Catalogos.Form_Factura(folio);
                    frmfacturas.Show();
                }
            }
        }

        private void toolStripButton_Enviar_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            int contador = 0;
            string IdRegistros = "0";
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistros += "," + registro.Cells["Id"].Value;
                    }
                }
                catch { }
            }
            if (contador <=  0)
            {
                MessageBox.Show("Para enviar la factura, debe seleccionar al menos un registro.");
                return;
            }

            DialogResult resultado;
            resultado = MessageBox.Show(@"Enviará esta(s) factura(s)", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (DialogResult.OK == resultado)
            {
                Formularios.Envios.Form_EnviarMail frmEnviarMail = new Formularios.Envios.Form_EnviarMail(IdRegistros);
                frmEnviarMail.Show();
            }
            else { }  
        }

        private void toolStripButton_Cancelar_Click(object sender, EventArgs e)
        {
            dataGridView1.EndEdit();
            //Cancelar Facturas
            int contador = 0;
            //Recorrar data grid y selecionar solo un registro
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
            if (contador == 0)
            {
                MessageBox.Show("Para cancelar una cactura, debe seleccionar al menos un registro.");
                return;
            }

            DialogResult resultado;
            resultado = MessageBox.Show(@"Esta seguro de cancelar esta factura", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == resultado)
            {
                string resulCancela = "";
                string uuidCan = "";
                string NouuidCan = "";

                //consumo webservice
                wFlexor.ServiceTimbrado WFlexSer = new wFlexor.ServiceTimbrado();


                ////
                try
                {

                    

                    foreach (DataGridViewRow registro in dataGridView1.Rows)
                    {
                        try
                        {
                            if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                            {
                                //solicitud al web service

                                string uuid = registro.Cells["FolioFiscal"].Value.ToString();
                                string rfc = ClsEmp.GetRfcEmitioFacById(uuid);
                                string serial = Classes.Class_Session.Serial;
                                /////cancelacion///
                                
                                string UsuarioPax = "";//ClsCer.GetPacUsuario(Classes.Class_Session.IDEMPRESA.ToString());
                                string NuMCertClave = "";// ClsCer.GetNumClaveUsuario(Classes.Class_Session.IDEMPRESA.ToString());


                                resulCancela = "";// WFlexSer.CancelacionFacturaExpress(serial, uuid, rfc, UsuarioPax, NuMCertClave, "DSK");
                                if (resulCancela == "1")
                                {
                                    ClsFac.CancelaFac(uuid);
                                    uuidCan = uuidCan + uuid + Environment.NewLine;
                                }
                                else
                                {
                                    NouuidCan = NouuidCan + uuid + " -  " + resulCancela + Environment.NewLine;
                                }
                            }
                        }
                        catch { }
                    }

                }
                catch 
                { 
                    MessageBox.Show("Problema en el consumo del servicio: " + resultado); 
                }

                if (uuidCan != "")
                {
                    MessageBox.Show("Factura(s) cancelada(s) correctamente: " + Environment.NewLine + Environment.NewLine + uuidCan);
                }
                if (NouuidCan != "")
                {
                    MessageBox.Show("Error al cancelar factura(s): " + Environment.NewLine + Environment.NewLine + NouuidCan);
                }
                //    MessageBox.Show(resulCancela);                
            }
            else { }  
        }

        private void button_Filtrar_Click(object sender, EventArgs e)
        {
            CargaListaAllFac();
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Folio+' '+Cliente+' '+RazonSocial+' '+MetodoPago LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }
    }
}
