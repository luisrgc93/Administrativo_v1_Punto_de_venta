using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenPop.Pop3;
using OpenPop.Mime.Header;
using OpenPop.Mime;
using System.Net.Mail;

namespace FLXDSK.herramientas
{
    public partial class Form_ConfigMail : Form
    {
        Classes.Herramientas.Class_HostMails ClsHos = new Classes.Herramientas.Class_HostMails();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();

        public Form_ConfigMail()
        {
            InitializeComponent();
        }

        private void Form_ConfigMail_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = ClsHos.GetInfoHostEnvio();
            DataRow Rws; 

            try
            {
                Rws = dt.Rows[0];
                textBox_Host.Text = Rws["host"].ToString();
                textBox_Puerto.Text = Rws["puerto"].ToString();
                textBox_Usuario.Text = Rws["usuario"].ToString();
                textBox_Clave.Text = Rws["clave"].ToString();
            }
            catch {
                textBox_Host.Text = "mail.flexorerp.mx";
                textBox_Puerto.Text = "888";
                textBox_Usuario.Text = "enviodsk@flexorerp.mx";
                textBox_Clave.Text = "Flex2013itx";
            }
            dt = ClsHos.GetInfoHostRecepcion();
            if (dt.Rows.Count > 0) {
                Rws = dt.Rows[0];
                textBox_Host_Recep.Text = Rws["host"].ToString();
                textBox_Puerto_Recep.Text = Rws["puerto"].ToString();
                textBox_Correo_Recep.Text = Rws["usuario"].ToString();
                textBox_Clave_Recep.Text = Rws["clave"].ToString();
            }

        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            button_Guardar.Enabled = false;
            string host = textBox_Host.Text.Trim();
            string puerto = textBox_Puerto.Text.Trim();
            string usuario = textBox_Usuario.Text.Trim();
            string clave = textBox_Clave.Text.Trim();
            if (host == "" || puerto == "" || usuario == "" || clave == "")
            {
                MessageBox.Show("Favor de completar toda la información requerida.");
            }
            else {
                ///valida  si es correcta la  informacion
                if (validaEnvioMail(host, puerto, usuario, clave))
                {
                    if (ClsHos.GuardaHOstEnvio(host, puerto, usuario, clave))
                    {
                        MessageBox.Show("Guardado con exito!");
                    }
                    else {
                        MessageBox.Show("Problema al guardar intente de nuevo");
                    }
                }else{
                    MessageBox.Show("Verifique la informacion, host/correo/clave Incorrecta.");
                    //ClsLog.InsertaInformacion("Configurar mail", "host: "+host+" puerto: "+puerto+" usuario:"+usuario+" Clave:"+clave);
                }
            }
            button_Guardar.Enabled = true;
        }
        private bool validaEnvioMail(string servidor, string puerto, string correo, string clave)
        {
            try{
                SmtpClient cliente = new SmtpClient();
                cliente.Host = servidor;
                cliente.Port = Convert.ToInt32(puerto);
                cliente.Credentials = new System.Net.NetworkCredential(correo, clave);
                return true;
            }catch
            {
                //ClsLog.InsertaInformacion(exp.ToString(), "conect, atentificate");
                return false;
            }
        }
        private bool ValidaEntradaMail(string servidor, string puerto, string correo, string clave)
        {

            using (Pop3Client client = new Pop3Client())
            {
                try
                {
                    // Connect to the server
                    client.Connect(servidor, Convert.ToInt32(puerto), false);
                    // Authenticate ourselves towards the server
                    client.Authenticate(correo, clave);
                    return true;
                }
                catch
                {
                    //ClsLog.InsertaInformacion(exp.ToString(), "conect, atentificate");
                    return false;                    
                }

            }
            ////////////////////////////////////////////////////////////////
            
        }
        
        private void button_Recepcion_Click(object sender, EventArgs e)
        {
            button_Recepcion.Enabled = false;
            string host = textBox_Host_Recep.Text;
            string correo = textBox_Correo_Recep.Text;
            string clave = textBox_Clave_Recep.Text;
            string puerto = textBox_Puerto_Recep.Text;
            if (host == "" || correo == "" || clave == "" || puerto == "") {
                MessageBox.Show("Complete la información requerida");
                textBox_Host_Recep.Focus();
                return;
            }
            try
            {
                Convert.ToInt32(puerto);
            }
            catch {
                MessageBox.Show("EL puerto es incorrecto");
                textBox_Puerto_Recep.Focus();
                return;
            }
            if (!ClsHos.validarEmail(correo)) {
                MessageBox.Show("EL correo es incorrecto");
                textBox_Correo_Recep.Focus();
                return;
            }
            ///valida  si es correcta la  informacion
            if (ValidaEntradaMail(host, puerto, correo, clave))
            {
                if (ClsHos.GuardaHOstRecepcion(host, puerto, correo, clave))
                {
                    MessageBox.Show("Guardado con exito!");
                }
                else
                {
                    MessageBox.Show("Problema al guardar intente de nuevo");
                }
            }
            else
            {
                MessageBox.Show("Verifique la informacion, host/correo/clave Incorrecta.");
                //ClsLog.InsertaInformacion("Configurar mail recepcion", "host: " + host + " puerto: " + puerto + " usuario:" + correo + " Clave:" + clave);
            }
            button_Recepcion.Enabled = true;
        }
    }
}
