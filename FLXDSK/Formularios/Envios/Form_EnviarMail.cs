using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MessagingToolkit.QRCode.Codec;
using System.Net.Mime;
using System.Net.Mail;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml;
using CrystalDecisions.Shared;

namespace FLXDSK.Formularios.Envios
{
    public partial class Form_EnviarMail : Form
    {
        Classes.Facturas.Class_HistoMail ClsHis = new Classes.Facturas.Class_HistoMail();
        Classes.Class_Empresa ClsEmp = new Classes.Class_Empresa();
        Classes.Class_Clientes ClsCliente = new Classes.Class_Clientes();
        Classes.Facturas.Class_Factura ClsFactura = new Classes.Facturas.Class_Factura();

        Classes.Facturas.Class_ComentFac ClsCFac = new Classes.Facturas.Class_ComentFac();

        Classes.Herramientas.Class_HostMails ClsHsMail = new Classes.Herramientas.Class_HostMails();
        Classes.Catalogos.Class_TiposCfdi ClsTipoCom = new Classes.Catalogos.Class_TiposCfdi();

        Classes.Class_Logs ClsLogs = new Classes.Class_Logs();

        string rutaArch = @"C:\temp\";
        private string IdsFacturas = "";
        DataTable dtFacs = null;

        //Empresa
        string NombreEpresa = "";

        //Cliente
        string razonCliente = "";




        public Form_EnviarMail(string idFac)
        {
            IdsFacturas = idFac;
            InitializeComponent();
        }
        private static void CreaDirectorios(string path)
        {
            string rutaxml = path;
            if (!Directory.Exists(rutaxml))
            {
                Directory.CreateDirectory(rutaxml);
            }
        }

        private void Form_EnviarMail_Load(object sender, EventArgs e)
        {
            CreaDirectorios("C:/temp/");
            string idEmp = Classes.Class_Session.IDEMPRESA.ToString();

            dtFacs = ClsFactura.getListaWhere(" WHERE iidFactura IN (" + IdsFacturas + ") ");
            if (dtFacs.Rows.Count == 0)
            {
                MessageBox.Show("Seleccione almenos una Factura");
                this.Close();
                return;
            }

            string SerisFacs="";
            string correoCliente="";

            foreach(DataRow Row in dtFacs.Rows)
                SerisFacs+= ",  "+Row["vchSerie"].ToString()+"-"+Row["iFolio"].ToString();

            DataTable dtCliente = ClsCliente.getInfoByID(dtFacs.Rows[0]["iidCliente"].ToString());
            if(dtCliente.Rows.Count > 0)
                correoCliente = dtCliente.Rows[0]["vchCorreo"].ToString();


            razonCliente = dtCliente.Rows[0]["vchRazon"].ToString();

            text_asunto.Text = "Facturas (" + SerisFacs + ")";
            text_correo.Text = correoCliente;
            rtext_mensaje.Text = "";


            ///Empresa
            DataTable dtsresultEmp = ClsEmp.GetInfoById(Classes.Class_Session.IDEMPRESA.ToString());
            if (dtsresultEmp.Rows.Count == 0)
            {
                MessageBox.Show("Empresa no encontrada");
                this.Close();
                return;
            }

            NombreEpresa = dtsresultEmp.Rows[0]["vchRazon"].ToString();




            DirectoryInfo DIR = new DirectoryInfo(rutaArch);
            if (!DIR.Exists)
                DIR.Create();
        }

        private void button_CancelarEnvio_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_enviarMail_Click(object sender, EventArgs e)
        {
            pictureBox_Enviando.Visible = true;
            button_enviarMail.Enabled = false;


            char[] delimit = new char[] { ';' };  //separador de correos
            char[] delimitArch = new char[] { ',' }; //separador de mails

            string correos = text_correo.Text;
            string asunto = text_asunto.Text;
            string mensaje = rtext_mensaje.Text;

            
            foreach (string correo in correos.Split(delimit))
            {
                if (!validarEmail(correo))
                {
                    pictureBox_Enviando.Visible = false;
                    button_enviarMail.Enabled = true;
                    MessageBox.Show("El correo: " + correo + " es incorrecto");
                    return;
                }
            }

            //Enviar Mail
            if (EnviarMail(correos, mensaje, asunto))
            {
                try
                {
                    string[] ficherosCarpeta = Directory.GetFiles(@"C:\temp\");
                    foreach (string ficheroActual in ficherosCarpeta)
                        File.Delete(ficheroActual);
                }
                catch { }

               
                pictureBox_Enviando.Visible = false;
                button_enviarMail.Enabled = true;
                MessageBox.Show("Enviado correctamente");
                this.Close();
            }
            else
            {
                MessageBox.Show("Problema al enviar el email");
                pictureBox_Enviando.Visible = false;
                button_enviarMail.Enabled = true;
                return;
            }
        }

        public bool EnviarMail(string correos, string mensaje, string asuntoE)
        {
            DataTable dthost = ClsHsMail.GetInfoHostEnvio(); //Obtener informacion de envio
            if (dthost.Rows.Count == 0)
            {
                MessageBox.Show("Es necesario configurar la cuenta de correo en herramientas/configurar correo.");
                ClsLogs.InsertaInformacion("Envio de facturas", "Es necesario configurar la cuenta de correo en herramientas/configurar correo.");
                return false;
            }
            string host = dthost.Rows[0]["host"].ToString();
            string usuario = dthost.Rows[0]["usuario"].ToString();
            string puerto = dthost.Rows[0]["puerto"].ToString();
            string clave = dthost.Rows[0]["clave"].ToString();
           

            char[] delimit = new char[] { ';' };//Separador de correos
            var mail = new MailMessage();
           
            //Se genera el body del Mail
            string bodyHtml = "<style type=\"text/css\"> ";
            bodyHtml += ".Estilo2 {font-family: Arial, Helvetica, sans-serif;font-size: 10px;color: #006699;}";
            bodyHtml += ".Estilo1 {font-family: Arial, Helvetica, sans-serif;font-size: 11px;color:#000000;}";
            bodyHtml += "</style></head><body><table width=\"700\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:12px; font-family:arial;\">";
            bodyHtml += "<tr><td style=\"padding-bottom:8px;\"><img src=\"http://flexorerp.mx/img/flexor-mini.png\"></td></tr><tr>";
            bodyHtml += "<td style=\"background-color:#E1E1E1; font-size:18px; color:#656565; padding:5px; font-weight:bold;\">Generaci&oacute;n de CFDI</td>";
            bodyHtml += " </tr><tr><td height=\"44\" align=\"center\" style=\"background-color:#F4F4F4;\">";
            bodyHtml += " Se ha generado una nueva factura eletrónica por parte de la empresa <br>";
            bodyHtml += NombreEpresa + " , con los siguientes datos:</td>";
            bodyHtml += " </tr><tr><td align=\"center\" style=\"background-color:#F4F4F4;\">";
            bodyHtml += "<table width=\"90%\"  align=\"center\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-size:12px; font-family:arial;\">";
            bodyHtml += "<tr><td width=\"48%\" align=\"left\"  class=\"Estilo1\" style=\"background-color:#E1E1E1; color:#656565; padding:5px; padding-left:10px;\"><b>Informaci&oacute;n </b></td>";
            bodyHtml += " <tr><td align=\"left\" valign=\"top\" style=\"padding:10px;\">";
            bodyHtml += "<table style=\"font-size:12px; font-family:arial;\"><tr><td width=\"280\"><b>UUID</b></td>";
            bodyHtml += "<td width=\"55\"><b>Folio</b></td><td width=\"75\"><b>Importe</b></td><td width=\"120\"><b>Fecha timbrado</b></td></tr>";

            foreach (DataRow RowFac in dtFacs.Rows)
            {
                    string uuidb = RowFac["vchuuid"].ToString();
                    string fechaTim = RowFac["dfechaTimbrado"].ToString();
                    string folio = RowFac["vchSerie"].ToString()+"-"+RowFac["iFolio"].ToString();
                    string total_Formateado = string.Format("{0:00.00}", Convert.ToDouble(RowFac["ftotal"].ToString()));

                    bodyHtml += "<tr> <td width=\"280\">" + uuidb + "</td>";
                    bodyHtml += " <td width=\"55\">" + folio + "</td>";
                    bodyHtml += " <td width=\"75\">" + total_Formateado + "</td>";
                    bodyHtml += " <td width=\"120\">" + fechaTim + "</td></tr>";
            }
            bodyHtml += "  </table></td></tr>";
            if (mensaje != "")
            {
                bodyHtml += "<tr><td width=\"48%\" align=\"left\" class=\"Estilo1\" style=\"background-color:#E1E1E1; color:#656565; padding:5px; padding-left:10px;\"><b>Mensaje: </b></td><tr> ";
                bodyHtml += "<tr><td align=\"left\">" + mensaje + "</td></tr>";
            }
            bodyHtml += "<tr><td align=\"left\" valign=\"top\"></td></tr></table></td></tr><tr>";
            bodyHtml += "<td width=\"371\"  align=\"center\" style=\"background-color:#F4F4F4; padding-top:10px; font-size:11px; padding-bottom:8px;\">";
            bodyHtml += "<p align=\"center\"><b>Asi mismo adjuntamos una copia del CFDI en formato XML y una copia de la representaci&oacute;n grafica del CFDI para su descarga.</b><b></b></p>";
            bodyHtml += "</td></tr><tr><td align=\"center\" style=\"background-color:#F4F4F4; padding:8px; font-size:16px; color:#656565;\"><em>";
            bodyHtml += "</em></td></tr></table></td></tr></table><table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-family:arial; font-size:12px;\">";
            bodyHtml += "<tr><td colspan=\"3\" height=\"30\" align=\"center\" style=\"font-size:10px;\">Si usted no solicitó está información, haz caso omiso de esté correo electrónico.</td>";
            bodyHtml += "</tr><tr><td colspan=\"3\" height=\"40\" align=\"center\" style=\"background:#0F1837; color:#FFF;\">@ Copyright FLEXOR ERP Software| Todos los derechos Reservados | 2012</td></tr></table></body></html>";

            
            ContentType mimeType = new System.Net.Mime.ContentType("text/html");
            AlternateView alternate = AlternateView.CreateAlternateViewFromString(bodyHtml, mimeType);
            mail.AlternateViews.Add(alternate);

            string emisor = usuario;
            string receptor = correos;
            string asunto = asuntoE;

            foreach (string enviar_a in receptor.Split(delimit))
                mail.To.Add(new MailAddress(enviar_a));
            

            mail.IsBodyHtml = true;
            mail.From = new MailAddress(emisor);
            mail.Subject = asunto;
            mail.Priority = MailPriority.Normal;
            var archivos = new ArrayList();


            foreach (DataRow RowFac in dtFacs.Rows)
            {
                string rutaName = ClsFactura.GetNamePdf(RowFac["vchuuid"].ToString());
                if (GeneraPDF(RowFac, rutaArch + rutaName + ".pdf") == true)
                        archivos.Add(rutaArch + rutaName + ".pdf");


                    string archivo = (string)RowFac["vchCfdi"];
                    
                    System.IO.StreamWriter sw = new System.IO.StreamWriter(rutaArch + rutaName + ".xml");
                    sw.WriteLine(archivo);
                    sw.Close();
                    archivos.Add(rutaArch + rutaName + ".xml");

            }

            MemoryStream memoryStream = new MemoryStream();
            foreach (string arhpath in archivos)
            {
                try
                {
                    MemoryStream ms = new MemoryStream(File.ReadAllBytes(arhpath));
                    string nameFile = arhpath.Replace("Ctemp", "");
                    nameFile = nameFile.Replace("C:\\temp\\", "");
                    Attachment dts = new Attachment(ms, nameFile, MediaTypeNames.Application.Octet);
                    mail.Attachments.Add(dts);
                }
                catch { }
            }
            SmtpClient cliente = new SmtpClient();
            cliente.Host = host;
            cliente.Port = Convert.ToInt32(puerto);
            cliente.Credentials = new System.Net.NetworkCredential(usuario, clave);
            // cliente.EnableSsl = true;



            try
            {
                cliente.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                ClsLogs.InsertaInformacion(ex.ToString(), "Envio de correo electronico");
                return false;
            }
        }

        public bool validarEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                { return true; }
                else
                { return false; }
            }
            else
            { return false; }
        }

        private bool GeneraPDF(DataRow Row, string RutaFile)
        {
            try
            {
                Classes.DataSet.Class_Factura ClsDSfac = new Classes.DataSet.Class_Factura();

                string xmlrespuesta = Row["vchCfdi"].ToString();
                string idEmpresa = Row["iidEmpresa"].ToString();
                string vchComentario = Row["vchComentario"].ToString();
                string vchVersion = "3.3";
                string Banco = "";


                if (!ClsDSfac.LlenaDatos(xmlrespuesta, idEmpresa, vchVersion, vchComentario, Banco))
                    return false;
                

                ////empezando a generar el pdf-----------------------------------------------------------------
                pdf.facturarep pdf = new pdf.facturarep();
                pdf.Load("pdf.facturarep.rpt");

                pdf.SetDataSource(ClsDSfac.ds);
                pdf.Refresh();
                pdf.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, RutaFile);
            }
            catch
            {
                return false;
            }

            return true;
        }

       
    }
}
