using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mime;
using System.Net.Mail;
using System.Collections;
using System.IO;

namespace FLXDSK.Listas.Administracion
{
    public partial class Form_List_Cupones : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Catalogos.Administracion.Class_CuponDescuento ClsCupon = new Classes.Catalogos.Administracion.Class_CuponDescuento();
        BindingSource bs = new BindingSource();

        public Form_List_Cupones()
        {
            InitializeComponent();
        }

        private void Form_List_Cupones_Load(object sender, EventArgs e)
        {
            Lista_Cupones();
        }

        private void Lista_Cupones()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView1.DataSource = null;
            string sql = " SELECT top 300 C.iidCupon Folio, C.vchCodigo, convert(varchar(10),C.dfechaVence,103)[Vence],  " +
                        "     U.vchNombre [Usuario Creo], CASE SiUtilizado when 1 then 'SI' else 'NO' end Utilizado,  " +
                        "     fdescuento Descuento, vchLugar Lugar, C.vchCorreo Correo, " +
                        "     DATEDIFF(DAY, GETDATE(), DATEADD(MI,10,dfechaVence) )diasVence " +
                        " FROM catCuponDescuento (NOLOCK) C, catUsuarios (NOLOCK) U " +
                        " WHERE C.iidEstatus = 1 " +
                        " AND C.iidUsuario = U.iidUsuario " +
                        " ORDER BY dfechaVence desc ";
            SqlDataAdapter mesas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                mesas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];


                dataGridView1.Columns["vchCodigo"].Visible = false;
                dataGridView1.Columns["diasVence"].Visible = false;
                dataGridView1.Columns["Folio"].Width = 80;
                dataGridView1.Columns["Folio"].ReadOnly = true;
                dataGridView1.Columns["Vence"].Width = 120;
                dataGridView1.Columns["Vence"].ReadOnly = true;
                dataGridView1.Columns["Usuario Creo"].Width = 250;
                dataGridView1.Columns["Usuario Creo"].ReadOnly = true;
                dataGridView1.Columns["Utilizado"].Width = 200;
                dataGridView1.Columns["Utilizado"].ReadOnly = true;
                dataGridView1.Columns["Descuento"].Width = 100;
                dataGridView1.Columns["Descuento"].ReadOnly = true;
                dataGridView1.Columns["Lugar"].Width = 80;
                dataGridView1.Columns["Lugar"].ReadOnly = true;
                dataGridView1.Columns["Correo"].Width = 150;
                dataGridView1.Columns["Correo"].ReadOnly = true;

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

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" [Usuario Creo]+' '+Correo+' '+Descuento LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }

        private void toolStripButton_Borrar_Click(object sender, EventArgs e)
        {
            string idCupon = "";
            int contador = 0;
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        idCupon = registro.Cells["Folio"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }

            DialogResult resultado = MessageBox.Show(@"Esta seguro de eliminar este registro", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == resultado)
            {
                if (ClsCupon.EliminaCupon(idCupon))
                {
                    MessageBox.Show("Eliminado con exito");
                    Lista_Cupones();
                }
                else
                {
                    MessageBox.Show("Problema al eliminar, intente nuevamente");
                }
            }
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Administracion.Form_CuponDescuento frm = new Formularios.Administracion.Form_CuponDescuento();
            frm.Lista_Cupones += new Form1.MessageHandler(Lista_Cupones);
            frm.ShowDialog();
        }

        private void toolStripButton_Enviar_Click(object sender, EventArgs e)
        {
            int contador = 0;
            string Folio = "";
            string CodigoCupon = "";
            string Correo = "";
            string Vence="";
            string Utilizado ="";
            string Porcentaje="";
            int diasVence = 0;

            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        Folio = registro.Cells["Folio"].Value.ToString();
                        CodigoCupon = registro.Cells["vchCodigo"].Value.ToString();
                        Vence = registro.Cells["Vence"].Value.ToString();
                        Correo = registro.Cells["Correo"].Value.ToString();
                        Porcentaje = registro.Cells["Descuento"].Value.ToString();
                        Utilizado = registro.Cells["Utilizado"].Value.ToString();

                        diasVence = Convert.ToInt32(registro.Cells["diasVence"].Value);
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }
            if(Utilizado=="SI")
            {
                MessageBox.Show("El cupon ya fue utilizado, por lo que no puede enviarse");
                return;
            }
            if (diasVence <= 0)
            {
                MessageBox.Show("El cupon ya fue expirado");
                return;
            }

            DialogResult resultado = MessageBox.Show(@"Esta seguro de eliminar este registro", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == resultado)
            {
                Classes.Herramientas.Class_HostMails ClsHos = new Classes.Herramientas.Class_HostMails();
                Classes.Class_Empresa ClsEmp = new Classes.Class_Empresa();


                DataTable dtHost = ClsHos.GetInfoHostEnvio();
                if(dtHost.Rows.Count == 0)
                {
                    MessageBox.Show("La configuración de envio de correo, no ha sido configurada aun");
                    return;
                }

                DataTable dtsresultEmp = ClsEmp.GetInfoById(Classes.Class_Session.IDEMPRESA.ToString());
                if(dtsresultEmp.Rows.Count == 0)
                {
                    MessageBox.Show("La configuración de empresa, no ha sido configurada aun");
                    return;
                }



                if (EnviarMail(dtHost, dtsresultEmp, Correo, CodigoCupon, Porcentaje, "Codigo de Descuento", Vence))
                {
                    MessageBox.Show("Cupon enviado por correo electronico");
                    return;
                }
                else
                {
                    MessageBox.Show("Problema en el envio, favor de intentar mas tarde");
                    return;
                }
            }
        }

        public bool EnviarMail(DataTable dtHost, DataTable dtEmp, string correos, string cupon, string porcentaje, string asuntoE, string vence)
        {
            string host = dtHost.Rows[0]["host"].ToString();
            string usuario = dtHost.Rows[0]["usuario"].ToString();
            string puerto = dtHost.Rows[0]["puerto"].ToString();
            string clave = dtHost.Rows[0]["clave"].ToString();


            char[] delimit = new char[] { ';' };
            var mail = new MailMessage();

            
            
            
            string razonSocial = dtEmp.Rows[0]["vchRazon"].ToString();

            
            string bodyHtml = "<style type=\"text/css\"> ";
            bodyHtml += ".Estilo2 {font-family: Arial, Helvetica, sans-serif;font-size: 10px;color: #006699;}";
            bodyHtml += ".Estilo1 {font-family: Arial, Helvetica, sans-serif;font-size: 11px;color:#000000;}";
            bodyHtml += "</style></head><body><table width=\"700\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:12px; font-family:arial;\">";
            bodyHtml += "<tr><td style=\"padding-bottom:8px;\"><img src=\"http://flexorerp.mx/img/flexor-mini.png\"></td></tr><tr>";
            bodyHtml += "<td style=\"background-color:#E1E1E1; font-size:18px; color:#656565; padding:5px; font-weight:bold;\">Cupon de Descuento</td>";
            bodyHtml += " </tr><tr><td height=\"44\" align=\"center\" style=\"background-color:#F4F4F4;\">";
            bodyHtml += " Se ha generado un cupon de descuento por parte de Morrison Bar<br>";
            bodyHtml += razonSocial + " , con los siguientes datos:</td>";
            bodyHtml += " </tr>";

            if (cupon != "")
            {
                bodyHtml += "<tr><td width=\"48%\" align=\"center\" class=\"Estilo1\" style=\"background-color:#E1E1E1; color:#656565; padding:5px; padding-left:10px;\"><b>Cupon: </b>" + cupon + "   <b>Descuento de: </b>-" + porcentaje + "%</td>";
                bodyHtml += "<tr><td width=\"48%\" align=\"center\" class=\"Estilo1\" style=\"background-color:#E1E1E1; color:#656565; padding:5px; padding-left:10px;\"><b>Fecha de Vencimiento: </b>" + vence + "</td>";
            }
            bodyHtml += "<tr><td align=\"left\" valign=\"top\"></td></tr></table></td></tr><tr><td align=\"center\" style=\"background-color:#F4F4F4; padding:8px; font-size:16px; color:#656565;\"><em>";
            bodyHtml += "</em></td></tr></table></td></tr></table><table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-family:arial; font-size:12px;\">";
            bodyHtml += "<tr><td colspan=\"3\" height=\"30\" align=\"center\" style=\"font-size:10px;\">Si usted no solicit&oacute; est&aacute; informaci&oacute;n, haz caso omiso de est&eacute; correo electr&oacute;nico.</td>";
            bodyHtml += "</tr><tr><td colspan=\"3\" height=\"40\" align=\"center\" style=\"background:#0F1837; color:#FFF;\">@ Copyright CHEFCONTROL Software| Todos los derechos Reservados | 2014</td></tr></table></body></html>";

            //Se indica que el el tipo de body
            ContentType mimeType = new System.Net.Mime.ContentType("text/html");
            AlternateView alternate = AlternateView.CreateAlternateViewFromString(bodyHtml, mimeType);
            //se agrega el body
            mail.AlternateViews.Add(alternate);

            string emisor = usuario;
            string receptor = correos;
            string asunto = asuntoE;

            // En caso de que sean multiples destinatarios se recorre el Array de receptor que contiene todos los mail destinatarios
            foreach (string enviar_a in receptor.Split(delimit))
            {
                mail.To.Add(new MailAddress(enviar_a));
            }

            mail.IsBodyHtml = true;
            mail.From = new MailAddress(emisor);
            mail.Subject = asunto;
            mail.Priority = MailPriority.Normal;

            var archivos = new ArrayList();

            

            SmtpClient cliente = new SmtpClient();
            cliente.Host = host;
            cliente.Port = Convert.ToInt32(puerto);
            cliente.Credentials = new System.Net.NetworkCredential(usuario, clave);

            try
            {
                cliente.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return false;
            }
        }
    }
}
