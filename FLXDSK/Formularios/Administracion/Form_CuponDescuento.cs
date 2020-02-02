using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using System.Text.RegularExpressions;
using System.Net.Mime;
using System.Net.Mail;
using System.Collections;
using System.IO;

namespace FLXDSK.Formularios.Administracion
{
    public partial class Form_CuponDescuento : Form
    {
        Classes.Class_Empresa ClsEmp = new Classes.Class_Empresa();
        Classes.Class_Logs ClsLogs = new Classes.Class_Logs();
        Classes.Herramientas.Class_HostMails ClsHsMail = new Classes.Herramientas.Class_HostMails();
        Classes.Catalogos.Administracion.Class_CuponDescuento fnCuponDescuento = new Classes.Catalogos.Administracion.Class_CuponDescuento();
        public event Form1.MessageHandler Lista_Cupones;

        string filtro = "";
        private string arrayuuids = "";

        public Form_CuponDescuento()
        {
            InitializeComponent();
        }

        private string genera_clave(int l)
        {
            Random aleatorio = new Random();
            string res = "";
            string[] vals = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            for (int i = 0; i <= l; i++)
            {
                res = res + vals[aleatorio.Next(vals.GetUpperBound(0) + 1)];
            }
            return res;
        }

        private void button_Guardar_Click(object sender, EventArgs e)
         {
            if (textBox_Cupon.Text == "" || textBox_Correo.Text == "" || textBox_Cantidad.Text == "") 
            { 
                MessageBox.Show("Favor de llenar todos los campos"); 
                return; 
            }

            if (Convert.ToInt32(textBox_Cantidad.Text) < 1 || Convert.ToInt32(textBox_Cantidad.Text) > 50) 
            { 
                MessageBox.Show("La cantidad de descuento debe ser mayor a 1 y menor a 50"); 
                return; 
            }

            enviarCorreo();
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

        public bool EnviarMail(string id, string correos, string cupon, string Cantidad, string asuntoE, string vence)
        {
            DataTable dthost = ClsHsMail.GetInfoHostEnvio(); //Obtener informacion de envio
            string host = "";
            string usuario = "";
            string puerto = "";
            string clave = "";
            try
            {
                DataRow Rows;
                Rows = dthost.Rows[0];
                host = Rows["host"].ToString();
                puerto = Rows["puerto"].ToString();
                usuario = Rows["usuario"].ToString();
                clave = Rows["clave"].ToString();
            }
            catch
            {
                MessageBox.Show("Es necesario configurar la cuenta de correo en herramientas/configurar correo.");
                button_Guardar.Enabled = true;
                return false;
            }

            char[] delimit = new char[] { ';' };//Separador de correos
            var mail = new MailMessage();
            //Obtengo los datos de la empresa
            DataTable dtsresultEmp = new DataTable();
            dtsresultEmp = ClsEmp.GetInfoById(id);
            DataRow rows = dtsresultEmp.Rows[0];
            string razonSocial = rows["vchRazon"].ToString();

            //Se genera el body del Mail
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
                bodyHtml += "<tr><td width=\"48%\" align=\"center\" class=\"Estilo1\" style=\"background-color:#E1E1E1; color:#656565; padding:5px; padding-left:10px;\"><b>Cupon: </b>" + cupon + "   <b>Descuento de: </b>-"+Cantidad+"%</td>";
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
            //  mail.Body = "";
            mail.From = new MailAddress(emisor);
            //con copia
            mail.Subject = asunto;
            //  mail.Body = mensajeBody;
            mail.Priority = MailPriority.Normal;

            //Obtener los archivos a enviar           
            //declaracion del arreglo que guardara las rutas de los archivos a enviar
            var archivos = new ArrayList();

            //Crea una secuencia cuyo almacén de respaldo es la memoria.
            MemoryStream memoryStream = new MemoryStream();
            foreach (string arhpath in archivos)
            {
                try
                {
                    //Con el memoryStream Libera los archivos                 
                    MemoryStream ms = new MemoryStream(File.ReadAllBytes(arhpath));
                    //Adjunta el archivo
                    //Attachment dts = new Attachment(ms, MediaTypeNames.Application.Octet); 
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
            
            try
            {  //Envía el mensaje.
                cliente.Send(mail);
                //Si se envia
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                button_Guardar.Enabled = true;
                //ClsLogs.InsertaInformacion(ex.ToString(), "Envio de correo electronico");
                return false;
            }
        }

        public void enviarCorreo()
        {
            button_Guardar.Enabled = false;
            string idEmp = Classes.Class_Session.IDEMPRESA.ToString();//Obtener id de la empresa

            char[] delimit = new char[] { ';' };  //separador de correos
            char[] delimitArch = new char[] { ',' }; //separador de mails

            string correos = textBox_Correo.Text;
            string asunto = "Cupon de Descuento";
            string cupon = textBox_Cupon.Text;
            string cantidad = textBox_Cantidad.Text;

            string[] varF = dateTimePicker_fin.Text.Split('/');
            string final = varF[2] + "-" + varF[1] + "-" + varF[0] + "T23:59:59";
            DateTime FechAc = DateTime.Now.Date;
            DateTime vence = Convert.ToDateTime(final);

            if (vence < FechAc)
            {
                MessageBox.Show("La fecha de vencimiento no pude ser menor a la fecha actual.");
                button_Guardar.Enabled = true;
                return;                
            }

            // En caso de que sean multiples destinatarios recorro el Array
            foreach (string correo in correos.Split(delimit))
            {
                //validamos todos los e-mails
                if (!validarEmail(correo))
                {
                    MessageBox.Show("El correo: " + correo + " es incorrecto");
                    button_Guardar.Enabled = true;
                    return;
                }
            }

            ////ciclamos y enviamos

            if (cupon != "")
            {
                DataTable Info = new DataTable();
                DataRow Drw;
                Info.Columns.Add("vence", System.Type.GetType("System.String"));
                Info.Columns.Add("cupon", System.Type.GetType("System.String"));
                Info.Columns.Add("cantidad", System.Type.GetType("System.String"));
                Info.Columns.Add("empresa", System.Type.GetType("System.String"));
                Info.Columns.Add("correo", System.Type.GetType("System.String"));

                Drw = Info.NewRow();
                Drw["vence"] = final;
                Drw["cupon"] = cupon;
                Drw["cantidad"] = cantidad;
                Drw["empresa"] = idEmp;
                Drw["correo"] = correos;
                Info.Rows.Add(Drw);
                try
                {
                    if (fnCuponDescuento.existeCupon(cupon)) { MessageBox.Show("Este cupon ya se encuentra dado de alta"); button_Guardar.Enabled = true; return; }
                    else
                    {
                        if (fnCuponDescuento.InsertCupon(Info))
                        {
                            if (EnviarMail(idEmp, correos, cupon, cantidad, asunto, vence.ToString()))
                            { }
                            try
                            {
                                Lista_Cupones();
                            }
                            catch { }
                        }
                        else { MessageBox.Show("Problemas al guardar el cupon"); button_Guardar.Enabled = true; return; }
                    }
                }
                catch { }
            }
        
            //Se eliminan los archivos temporales
            try
            {
                string[] ficherosCarpeta = Directory.GetFiles(@"C:\temp\");
                foreach (string ficheroActual in ficherosCarpeta)
                    File.Delete(ficheroActual);
            }
            catch { }
            MessageBox.Show("Enviado correctamente");
            this.Close();
        }

        private void textBox_Cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
            {
                if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_CuponDescuento_Load(object sender, EventArgs e)
        {
            dateTimePicker_fin.Format = DateTimePickerFormat.Custom;
            dateTimePicker_fin.CustomFormat = "dd/MM/yyyy"; 
            filtro = "";

            textBox_Cupon.Text = genera_clave(8);
        }
    }
}
