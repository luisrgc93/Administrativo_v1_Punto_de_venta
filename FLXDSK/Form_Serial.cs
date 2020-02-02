using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Management;
using Newtonsoft.Json.Linq;


namespace FLXDSK
{
    public partial class Form_Serial : Form
    {
        Classes.Class_Empresa ClsEmp = new Classes.Class_Empresa();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        

        public Form_Serial()
        {
            InitializeComponent();
        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form_Serial_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
        }


        private void button_Aceptar_Click_1(object sender, EventArgs e)
        {
            pictureBox_Enviando.Visible = true;
            button_Aceptar.Enabled = false;

            string key = text_key.Text.Trim();

            wschefControl.Service1 webChef = new wschefControl.Service1();

            string respAcceso = webChef.CheckSiLicenciaValida(key);

            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(respAcceso);
            var details = JObject.Parse(obj.ToString());  
            //string respuesta = obj["rRespuesta"];
            if (respAcceso != "")
            {
                string resp = details["rRespuesta"].ToString();
                string dispDisponibles = details["DispDisponibles"].ToString();
                string dispUsados = details["DispUsuados"].ToString();
                resp = resp.Replace('"',' ');
                if (resp.Trim() == "true")
                {
                    dispDisponibles = dispDisponibles.Replace('"',' ');
                    dispUsados = dispUsados.Replace('"', ' ');
                    if (int.Parse(dispDisponibles.Trim()) > int.Parse(dispUsados.Trim()))
                    {
                        MessageBox.Show(@"¡Bienvenido a SoftSolution POS!, Ahora registrar tu empresa.", "Mensaje de bienvenida.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(@"Lo siento no cuentas con dispositivos disponibles, contacta a tu proveedor", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else 
                {
                    MessageBox.Show(@"La licencia insertada no es valida", "Información.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        
        public String getMotherBoardID()
        {
            string volumeSerial = "";
            try
            {

                //Get motherboard's serial number 
                ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_BaseBoard");
                foreach (ManagementObject mo in mbs.Get())
                {
                    volumeSerial += mo["SerialNumber"].ToString();
                }
                return volumeSerial;
            }
            catch (Exception) { return volumeSerial; }
            
        }
    }
}
