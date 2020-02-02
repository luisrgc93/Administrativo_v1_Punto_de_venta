using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MessagingToolkit.QRCode.Codec;
using System.Configuration;
using System.Security.Cryptography;
using System.IO;

namespace FLXDSK.Formularios.Configuracion
{
    public partial class Form_QrConexion : Form
    {
        Classes.Class_Empresa ClsEmpresa = new Classes.Class_Empresa();
        Classes.Herramientas.Class_Encript ClsEncrip = new Classes.Herramientas.Class_Encript();


        public Form_QrConexion()
        {
            InitializeComponent();
        }

        private void Form_QrConexion_Load(object sender, EventArgs e)
        {
            string server = ConfigurationManager.AppSettings["server"];
            string usuario = ClsEncrip.DecryptString(ConfigurationManager.AppSettings["usuario_DB"]);
            string db = ClsEncrip.DecryptString(ConfigurationManager.AppSettings["DB"]);
            string pas = ClsEncrip.DecryptString(ConfigurationManager.AppSettings["clave_DB"]);

            string Serial = ClsEmpresa.GetMeSerialNumer();
            if (Serial == "")
            {
                MessageBox.Show("Serial no pudo encontrarse");
                this.Close();
                return;
            }

            string urlAll = "" + Serial +  "&" + server + "&" + usuario + "&" + db + "&" + ClsEncrip.EncryptString(pas);
            //string resp = ClsEncrip.EncryptString(urlAll);
            try
            {
                QRCodeEncoder enc = new QRCodeEncoder();
                Bitmap qrcode = enc.Encode(urlAll);
                pictureBox_Qr.Image = qrcode as Image;//Displays generated code in PictureBox
            }
            catch { }
        }

    }
}
