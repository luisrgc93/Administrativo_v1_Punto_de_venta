using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Net.Mail;
using System.Net.Mime;

namespace FLXDSK.Classes.Correo
{
    class Class_EnviaCorte
    {
        Classes.Cortes.Class_Corte ClsCorte = new Cortes.Class_Corte();
        Classes.Herramientas.Class_HostMails ClsHost = new Herramientas.Class_HostMails();

        private string getHTML()
        {
            string Folder = Directory.GetCurrentDirectory();

            if (File.Exists(@"" + Folder + "\\email\\corte.htm"))
                return System.IO.File.ReadAllText(@"" + Folder + "\\email\\corte.htm");
            return "";
        }

        public bool EnviaCorreo(string idCorte, string receptor)
        {
            string HTML = getHTML();

            DataTable dtCorte = ClsCorte.getListaWhere(" WHERE iidCorte = " + idCorte);
            if (dtCorte.Rows.Count == 0)
                return false;

            HTML = HTML.Replace("{IDCORTE}", Convert.ToInt32(idCorte).ToString("000000"));
            string BodyContent = "";

            BodyContent +="<br/>";
            BodyContent +="<br/>";
            BodyContent += "<center>No Corte: " + Convert.ToInt32(idCorte).ToString("000000")+"</center>";
            BodyContent += "<center>" + dtCorte.Rows[0]["dfechaIn103"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + dtCorte.Rows[0]["dfechaIn108"].ToString() + "</center>";
            BodyContent += "<br/>";
            BodyContent += "<center> V E N T A   T O T A L </center>";
            BodyContent += "<center>"+string.Format("{0:c}", Convert.ToDouble(dtCorte.Rows[0]["fVentaTotal"].ToString()))+" </center>";
            BodyContent += "<br/>";
            BodyContent += "<table width='200' style='font-size:12px' align='center'>";
            //BodyContent += "<tr><td width='100'>Propinas </td><td width='100' align='right'>" + string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fPropinaTotal"].ToString())) + "</td></tr>";
            BodyContent += "<tr><td width='100'>Salidas </td><td width='100' align='right'>" + string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fMontoSalidaDinero"].ToString())) + "</td></tr>";
            BodyContent += "<tr><td width='100'>Entrada </td><td width='100' align='right'>" + string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fMontoEntradaDinero"].ToString())) + "</td></tr>";
            BodyContent += "<tr><td colspan='2' style='border-top:solid 1px #333;'>&nbsp;</td></tr>";
            BodyContent += "<tr><td>Total Final </td><td width='100' align='right'>" + string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fTotalFinal"].ToString())) +"</td></tr>";
            BodyContent += "<tr><td>Entregado </td><td width='100' align='right'>" +string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fTotalEntregado"].ToString())) +"</td></tr>";

            if (Convert.ToDouble(dtCorte.Rows[0]["fTotalFinal"].ToString()) > Convert.ToDouble(dtCorte.Rows[0]["fTotalEntregado"].ToString()))
            {
                double Faltante = Convert.ToDouble(dtCorte.Rows[0]["fTotalFinal"].ToString()) - Convert.ToDouble(dtCorte.Rows[0]["fTotalEntregado"].ToString());
                BodyContent += "<tr><td>Faltante</td><td width='100' align='right'>" +string.Format("{0:c}",Faltante)+"</td></tr>";
            }
            else
            {
                if (Convert.ToDouble(dtCorte.Rows[0]["fTotalEntregado"].ToString()) > Convert.ToDouble(dtCorte.Rows[0]["fTotalFinal"].ToString()))
                {
                    double Sobrante = Convert.ToDouble(dtCorte.Rows[0]["fTotalEntregado"].ToString()) - Convert.ToDouble(dtCorte.Rows[0]["fTotalFinal"].ToString());
                    BodyContent += "<tr><td>Sobrante</td><td width='100' align='right'>" + string.Format("{0:c}", Sobrante) + "</td></tr>";
                }
            }
            BodyContent += "</table>";
            BodyContent += "<br/>";
            BodyContent += "<br/>";
            BodyContent += "<center><b>ENTREGAS</b></center>";
            BodyContent += "<table width='200' style='font-size:12px' align='center'>";
            BodyContent += "<tr><td width='100'>Efectivo </td><td width='100' align='right'>" + string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fEntregaEfectivo"].ToString())) + "</td></tr>";
            BodyContent += "<tr><td width='100'>Credito </td><td width='100' align='right'>" + string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fEntregaCreditoTC"].ToString())) + "</td></tr>";
            BodyContent += "<tr><td width='100'>Debito </td><td width='100' align='right'>" + string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fEntregaDebito"].ToString())) + "</td></tr>";
            BodyContent += "<tr><td width='100'>Vales </td><td width='100' align='right'>" + string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fEntregaVales"].ToString())) + "</td></tr>";
            BodyContent += "<tr><td width='100'>Cheque </td><td width='100' align='right'>" + string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fEntregaCheque"].ToString())) + "</td></tr>";
            BodyContent += "<tr><td width='100'>Otro </td><td width='100' align='right'>" + string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fEntregaOtro"].ToString())) + "</td></tr>";
            BodyContent += "</table>";
            BodyContent += "<br/>";
            BodyContent += "<br/>";
            BodyContent += "<center><b>VENTAS X FORMA DE PAGO</b></center>";
            BodyContent += "<table width='200' style='font-size:12px' align='center'>";
            BodyContent += "<tr><td width='100'>Efectivo </td><td width='100' align='right'>" + string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fVentaEfectivo"].ToString())) + "</td></tr>";
            BodyContent += "<tr><td width='100'>Credito </td><td width='100' align='right'>" + string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fVentaCreditoTC"].ToString())) + "</td></tr>";
            BodyContent += "<tr><td width='100'>Debito </td><td width='100' align='right'>" + string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fVentaDebito"].ToString()))+ "</td></tr>";
            BodyContent += "<tr><td width='100'>Vales </td><td width='100' align='right'>" + string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fVentaVales"].ToString())) + "</td></tr>";
            BodyContent += "<tr><td width='100'>Cheque </td><td width='100' align='right'>" + string.Format("{0:c}",Convert.ToDouble(dtCorte.Rows[0]["fVentaCheque"].ToString())) + "</td></tr>";
            BodyContent += "<tr><td width='100'>Otro </td><td width='100' align='right'>" + string.Format("{0:c}", Convert.ToDouble(dtCorte.Rows[0]["fVentaOtro"].ToString())) + "</td></tr>";
            BodyContent += "</table>";
            BodyContent += "<br/>";
            BodyContent += "<br/>";

            BodyContent += "</table>";
            BodyContent += "<br/>";
            BodyContent += "<br/>";
            BodyContent += "<br/>";
            BodyContent += "<br/>";
            HTML = HTML.Replace("{BODYCORTE}", BodyContent);


            DataTable dtInfo = ClsHost.GetInfoHostEnvio();
            if(dtInfo.Rows.Count == 0)
                return false;

            string host  =dtInfo.Rows[0]["host"].ToString();
            string puerto  =dtInfo.Rows[0]["puerto"].ToString();
            string usuario  =dtInfo.Rows[0]["usuario"].ToString();
            string clave  =dtInfo.Rows[0]["clave"].ToString();

            if (host == "" || usuario == "")
                return false;

            char[] delimit = new char[] { ';' };
            var mail = new MailMessage();


            ContentType mimeType = new System.Net.Mime.ContentType("text/html");
            AlternateView alternate = AlternateView.CreateAlternateViewFromString(HTML, mimeType);
            mail.AlternateViews.Add(alternate);

            foreach (string enviar_a in receptor.Split(delimit))
                mail.To.Add(new MailAddress(enviar_a));


            mail.IsBodyHtml = true;
            mail.From = new MailAddress("contacto@flexor.mx");
            mail.Subject = "Corte No."+idCorte;
            mail.Priority = MailPriority.Normal;


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
            catch
            {
                return false;
            }

        }
    }
}
