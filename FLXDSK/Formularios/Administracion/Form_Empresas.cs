using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Configuration;

namespace FLXDSK.Formularios.Administracion
{
    public partial class Form_Empresas : Form
    {
        string passedInText = "";
        string idempresNew = "";
        Classes.Class_Limpiar Clean = new Classes.Class_Limpiar();
        Classes.Class_Empresa ClsEmp = new Classes.Class_Empresa();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        Classes.Class_Validaciones ClsValida = new Classes.Class_Validaciones();
        Classes.Catalogos.Administracion.Class_Sucursales ClsSucursales = new Classes.Catalogos.Administracion.Class_Sucursales();


        Classes.Catalogos.Administracion.Class_Usuarios ClsUSuarios = new Classes.Catalogos.Administracion.Class_Usuarios();
        Classes.Facturas.Class_Certificado ClsCer = new Classes.Facturas.Class_Certificado();
        public event Form1.MessageHandler CargaListaAllEmpre;



        Classes.SAT.Class_Regimen ClsRegimen = new Classes.SAT.Class_Regimen();
        Classes.SAT.Class_Estados ClsEstados = new Classes.SAT.Class_Estados();

        bool isRegitrarPrimeraVez;

        public Form_Empresas(string id,bool isRegistroPrimero=false)
        {
            isRegitrarPrimeraVez = isRegistroPrimero;
            InitializeComponent();
            if (isRegitrarPrimeraVez)
            {
                button1.Visible = true;
                panel_sucursales.Enabled = false;
            }
            
            passedInText = id;
        }

        private void LlenadoCombos()
        {
            DataTable dtEstados = ClsEstados.getListaWhere(" WHERE iidEstatus = 1 ");
            comboBox_estado.DataSource = dtEstados;
            comboBox_estado.DisplayMember = "vchNombre";
            comboBox_estado.ValueMember = "iidEstado";

            DataTable dtRegimen = ClsRegimen.getListaWhere(" WHERE iidEstatus = 1 ");
            comboBox_Regimen.DataSource = dtRegimen;
            comboBox_Regimen.DisplayMember = "vchDescripcion";
            comboBox_Regimen.ValueMember = "vchClave";
       
        }
        private void Form_Empresas_Load(object sender, EventArgs e)
        {
            //Clean.Activar(this.tabControl_Empresa);            
            LlenadoCombos();
            if (passedInText != "")
            {
                getInfoID();
                Clean.Editar(this.tabControl_Empresa);
                button_Logo.Enabled = true;
                CargaInfoCertificados(passedInText);
            }
            else
            {
                button_Logo.Enabled = false;
            }
        }
        private void CargaInfoCertificados(string empresa)
        {
            DataTable InfoCrip = ClsCer.getListaWhere(" WHERE iidEmpresa = " + empresa);
            if (InfoCrip.Rows.Count > 0)
            {
                textBox_Certificado.Text = InfoCrip.Rows[0]["vchrutacer"].ToString();
                textBox_Clave.Text = InfoCrip.Rows[0]["vchpass"].ToString();
                textBox_Key.Text = InfoCrip.Rows[0]["vchrutakey"].ToString();
            }
        }
        private void getInfoID()
        {
            DataTable dtresult = new DataTable();
            dtresult = ClsEmp.GetInfoById(passedInText);
            if (dtresult.Rows.Count == 0)
            {
                MessageBox.Show("Informacion de la empresa incorrecta");
                return;
            }
            DataRow row = dtresult.Rows[0];

            textBox_alias.Text = row["vchAlias"].ToString();
            textBox_rfc.Text = row["vchRFC"].ToString();
            textBox_razon.Text = row["vchRazon"].ToString();
            textBox_calle.Text = row["vchCalle"].ToString();
            textBox_numext.Text = row["vchNumExt"].ToString();
            textBox_numint.Text = row["vchNumInt"].ToString();
            textBox_colonia.Text = row["vchColonia"].ToString();
            textBox_localidad.Text = row["vchLocalidad"].ToString();
            textBox_municipio.Text = row["vchMunicipio"].ToString();
            comboBox_estado.SelectedValue = row["iidEstado"].ToString();
            textBox_correo.Text = row["vchCorreo"].ToString();
            textBox_telefono.Text = row["vchTelefono"].ToString();
            textBox_cp.Text = row["vchCP"].ToString();
            textBox_AccesoTimbrado.Text = row["vchKeyTimbrado"].ToString();
            txt_sucursal.Text= row["sucursal"].ToString();
            txt_nombreSucursal.Text = row["nombreSucursal"].ToString();

            try
            {
                comboBox_Regimen.SelectedValue = row["vchRegimen"].ToString();
            }
            catch { }

            ///IMAGEN
            dtresult = ClsEmp.GerImagen(passedInText);
            try
            {
                row = dtresult.Rows[0];
                byte[] dibujoByteArray = (byte[])row["vchImagen"];
                //txt_descripMesa.Text = row["vchImagen"].ToString();
                MemoryStream ms = new MemoryStream();
                ms.Write(dibujoByteArray, 0, dibujoByteArray.Length);
                System.Drawing.Bitmap b = new Bitmap(ms);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.Image = new System.Drawing.Bitmap(b);
            }
            catch
            {
            }
        }


        /// <summary>
        /// /////////////////////////////////
        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }
        public static Image ResizeImage(Image srcImage, int newWidth, int newHeight)
        {
            using (Bitmap imagenBitmap =
               new Bitmap(newWidth, newHeight, PixelFormat.Format32bppRgb))
            {
                imagenBitmap.SetResolution(
                   Convert.ToInt32(srcImage.HorizontalResolution),
                   Convert.ToInt32(srcImage.HorizontalResolution));

                using (Graphics imagenGraphics =
                        Graphics.FromImage(imagenBitmap))
                {
                    imagenGraphics.SmoothingMode =
                       SmoothingMode.AntiAlias;
                    imagenGraphics.InterpolationMode =
                       InterpolationMode.HighQualityBicubic;
                    imagenGraphics.PixelOffsetMode =
                       PixelOffsetMode.HighQuality;
                    imagenGraphics.DrawImage(srcImage,
                       new Rectangle(0, 0, newWidth, newHeight),
                       new Rectangle(0, 0, srcImage.Width, srcImage.Height),
                       GraphicsUnit.Pixel);
                    MemoryStream imagenMemoryStream = new MemoryStream();
                    imagenBitmap.Save(imagenMemoryStream, ImageFormat.Jpeg);
                    srcImage = Image.FromStream(imagenMemoryStream);
                }
            }
            return srcImage;
        }        
        private void button_Logo_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(dialog.FileName);
            }
        }
        private void button_Guardar_Click_1(object sender, EventArgs e)
        {
            string Regimen = "";
            string Estado = "";
           
            
            try
            {
                Regimen = comboBox_Regimen.SelectedValue.ToString();
            }
            catch
            {}
            try
            {
                Estado = comboBox_estado.SelectedValue.ToString();
            }
            catch
            { }
            if (Regimen == "")
            {
                MessageBox.Show("Régimen requerido");
                return;
            }
            if (Estado == "")
            {
                MessageBox.Show("Estado requerido");
                return;
            }
            if (textBox_alias.Text.Trim() == "" || textBox_razon.Text.Trim() == "" || textBox_rfc.Text.Trim() == "" || textBox_cp.Text.Trim() == "")
            {
                MessageBox.Show("Favor de completar la informacion requerida");
                return;
            }
            if (!ClsValida.isRFC(textBox_rfc.Text.Trim()))
            {
                MessageBox.Show("Formato del RFC incorrecto");
                return;
            }
          
           
            DataTable Info = new DataTable();
            DataRow Drw;
            Info.Columns.Add("alias", System.Type.GetType("System.String"));
            Info.Columns.Add("razon", System.Type.GetType("System.String"));
            Info.Columns.Add("rfc", System.Type.GetType("System.String"));
            Info.Columns.Add("tipo", System.Type.GetType("System.String"));
            Info.Columns.Add("calle", System.Type.GetType("System.String"));
            Info.Columns.Add("numext", System.Type.GetType("System.String"));
            Info.Columns.Add("numint", System.Type.GetType("System.String"));
            Info.Columns.Add("colonia", System.Type.GetType("System.String"));
            Info.Columns.Add("localidad", System.Type.GetType("System.String"));
            Info.Columns.Add("cp", System.Type.GetType("System.String"));
            Info.Columns.Add("municipio", System.Type.GetType("System.String"));
            Info.Columns.Add("estado", System.Type.GetType("System.String"));
            Info.Columns.Add("correo", System.Type.GetType("System.String"));
            Info.Columns.Add("telefono", System.Type.GetType("System.String"));
            Info.Columns.Add("regimen", System.Type.GetType("System.String"));
            Info.Columns.Add("licencia", System.Type.GetType("System.String"));
            Info.Columns.Add("cuenta", System.Type.GetType("System.String"));
            Info.Columns.Add("registropatronal", System.Type.GetType("System.String"));
            Info.Columns.Add("key_serie", System.Type.GetType("System.String"));
          
            ///////////////
            Drw = Info.NewRow();
            Drw["alias"] = textBox_alias.Text;
            Drw["razon"] = textBox_razon.Text;
            Drw["rfc"] = textBox_rfc.Text.ToUpper();
            Drw["regimen"] = Regimen;
            Drw["calle"] = textBox_calle.Text;
            Drw["numext"] = textBox_numext.Text;
            Drw["numint"] = textBox_numint.Text;
            Drw["colonia"] = textBox_colonia.Text;
            Drw["localidad"] = textBox_localidad.Text;
            Drw["cp"] = textBox_cp.Text;
            Drw["municipio"] = textBox_municipio.Text;
            Drw["estado"] = Estado;
            Drw["correo"] = textBox_correo.Text;
            Drw["telefono"] = textBox_telefono.Text;
            Drw["licencia"] = "";
            Drw["cuenta"] = "";
            Drw["registropatronal"] = "";
            Drw["key_serie"] = Classes.Class_Session.Key_serie;
             
            Info.Rows.Add(Drw);

            if (passedInText == "")
            {
                //nuevo
                if( (Classes.Class_Session.Serial == "")||(Classes.Class_Session.Serial == null))
                    Classes.Class_Session.Serial = ClsEmp.GetMeSerialNumer();
                
                string Permitidas = "2";// Flexweb.NumEmpPermitidas(Classes.Class_Session.Serial);

                int perm = System.Convert.ToInt32(Permitidas);
                int activas = ClsEmp.NumEmpresasActivas();

                if (activas >= perm)
                {
                    MessageBox.Show("ha superado el Numero de Empresas Autorizadas");
                }
                else
                {
                    //int numero = 
                    if (ClsEmp.InsertaInformacion(Info))
                    {
                        idempresNew = ClsEmp.GetIdEmpresaInsertada();
                        if(Classes.Class_Session.siPrimeroIngreso == "SI")
                        {
                            ClsUSuarios.InsertaAccesosUsuario(Classes.Class_Session.Idusuario.ToString(), idempresNew.ToString());
                        }
                        Classes.Class_Session.SiRegistroEmpresa = true;
                        MessageBox.Show(@"Guardado Correctamente, ahora registra la sucursal.","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        panel_sucursales.Enabled = true;
                        tabControl_Empresa.SelectedIndex = 1; 
                        try
                        {
                            CargaListaAllEmpre();
                        }
                        catch { }

                     
                    }
                    else
                    {
                        MessageBox.Show("Problema al Guardar");
                    }
                }
            }
            else
            {
                bool existeImagen = true;
                Image ImgRedimencionada = null;
                try
                {
                    //Image dibujo = new Bitmap(rutaAplicacion + @"\Imagen.bmp");
                    Image dibujo = new Bitmap(pictureBox1.Image);
                    //Creamos un stream en memoria para guardar la imagen
                    MemoryStream memStream = new MemoryStream();
                    //Guardamos la imagen en nuestro stream especificando el formato (jpg,bmp...) atentos al parámetro ImageFormat
                    dibujo.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //Guardamos el stream en un array de bytes
                    Byte[] dibujoByteArray = memStream.GetBuffer();
                    System.Text.Encoding enc = System.Text.Encoding.ASCII;
                    string myString = enc.GetString(dibujoByteArray);

                    ImgRedimencionada = ResizeImage(pictureBox1.Image, 400, 400);
                }
                catch
                { existeImagen = false; }


                if (ClsEmp.ActualizaInformacion(Info, passedInText))
                {
                    //imagen
                    if (existeImagen == true)
                    {
                        DataTable InfoImg = new DataTable();
                        InfoImg.Columns.Add("imagen", System.Type.GetType("System.Byte[]"));
                        Drw = InfoImg.NewRow();
                        Drw["imagen"] = ImageToByte(ImgRedimencionada);
                        InfoImg.Rows.Add(Drw);
                        ClsEmp.ActualizaImagen(InfoImg, passedInText);
                    }
                    MessageBox.Show("Actualizado correctamente");
                    try
                    {
                        CargaListaAllEmpre();
                    }
                    catch (Exception)
                    {
                     
                    }
                 

                    pictureBox1.Image = null;
                    passedInText = "";
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problema al actualizar");
                }
            }



            
        }
        private void button_Nuevo_Click(object sender, EventArgs e)
        {
            Clean.Limpiar(this.tabControl_Empresa);
            pictureBox1.Image = null;
            passedInText = "";
        }

       


        ////////////////////////////////////////////////////////////CERTIFICADOS***********************************

        private void button_cer_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_Certificado.Text = dialog.FileName;
            }
        }

        private void button_key_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox_Key.Text = dialog.FileName;
            }
        }

        private void button_GuardaCer_Click(object sender, EventArgs e)
        {
            if (passedInText == "")
            {
                MessageBox.Show("Es necesario abrir una empresa ya creada.");
                return;
            }
            else
            {
                BeginCargaCertificados();
                if (textBox_AccesoTimbrado.Text.Trim() != "")
                {
                    GuardaAccesoTimbrado();
                }
            }
        }
        private void BeginCargaCertificados()
        {
            button_GuardaCer.Enabled = false;
            DataTable dtEmpresa = ClsEmp.GetInfoById(passedInText);

            string licencia = Classes.Class_Session.Serial;
            if (licencia == "")
            {
                MessageBox.Show("Es necesario el Serial de licencia del sistema");
                button_GuardaCer.Enabled = true;
                return;
            }


            string rfc = dtEmpresa.Rows[0]["vchRFC"].ToString();
            string cer = textBox_Certificado.Text;
            string key = textBox_Key.Text;
            string pass = textBox_Clave.Text;
            cer = cer.Replace("\\", "//");
            key = key.Replace("\\", "//");

            string cerText = getCerter(cer);
            if (cerText == "")
            {
                button_GuardaCer.Enabled = true;
                MessageBox.Show("Certificado incorrecto, favor de verificarlo");
                return;
            }

            string NumCertificado = fnNumCertificado(cerText);
            if (!validateKey(key, pass))
            {
                button_GuardaCer.Enabled = true;
                MessageBox.Show("El Certificado no ha sido guardado, Key Incorrecto");
                return;
            }


            byte[] bytesCer = GetFileStream(textBox_Certificado.Text);
            byte[] bytesKey = GetFileStream(textBox_Key.Text);

            /////Creamos el Usuario
            string UsuarioPrincipal = "PlsControl" + NumCertificado;
            string ClavePrincipal = NumCertificado + "pCntrl";
           
            DataTable Info = new DataTable();
            DataRow Drw;

            Info.Columns.Add("vchrutacer", System.Type.GetType("System.String"));
            Info.Columns.Add("vchrutakey", System.Type.GetType("System.String"));
            Info.Columns.Add("vchpass", System.Type.GetType("System.String"));
            Info.Columns.Add("vchnumcertificado", System.Type.GetType("System.String"));
            Info.Columns.Add("vchtextcer", System.Type.GetType("System.String"));
            Info.Columns.Add("fileCer", System.Type.GetType("System.Byte[]"));
            Info.Columns.Add("fileKey", System.Type.GetType("System.Byte[]"));
            Info.Columns.Add("vchPasPc", System.Type.GetType("System.String"));
            Info.Columns.Add("vchUsrPc", System.Type.GetType("System.String"));

            Drw = Info.NewRow();
            Drw["vchrutacer"] = cer;
            Drw["vchrutakey"] = key;
            Drw["vchpass"] = pass;
            Drw["vchnumcertificado"] = NumCertificado;
            Drw["vchtextcer"] = cerText;
            Drw["fileCer"] = bytesCer;
            Drw["fileKey"] = bytesKey;
            Drw["vchPasPc"] = ClavePrincipal;
            Drw["vchUsrPc"] = UsuarioPrincipal;
            Info.Rows.Add(Drw);


            if (ClsCer.InsertaInformacion(Info, passedInText))
            {
                MessageBox.Show("Guardado");
                this.Close();
            }
            else
            {
                MessageBox.Show("Problema al guardar el certificado");
            }

            button_GuardaCer.Enabled = true;
        }
        private string fnNumCertificado(string cerTXT)
        {

            //carga el certificado del comprobante
            byte[] bytes = System.Convert.FromBase64String(cerTXT);
            var x509 = new X509Certificate2(bytes);
            var NoCertificado = hexString2Ascii(x509.SerialNumber);
            return NoCertificado.ToString();

        }
        private static string hexString2Ascii(string hexString)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i <= hexString.Length - 2; i += 2)
            {
                sb.Append(Convert.ToString(Convert.ToChar(Int32.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber))));
            }
            return sb.ToString();
        }
        private string getCerter(string ruta)
        {
            string certdigital = "";
            Chilkat.Cert certificado = new Chilkat.Cert();
            ///verifica que sea un certificado debuelbe un true
            bool es_certificado = certificado.LoadFromFile(ruta);
            if (es_certificado)
            {
                int revocado = certificado.CheckRevoked();
                string larg_numcer = certificado.SerialNumber;

                if (revocado == 1)
                {
                    MessageBox.Show("Certificado Revocado");
                }
                else
                {
                    certdigital = certificado.ExportCertPem();
                    certdigital = certdigital.Replace("-----BEGIN CERTIFICATE-----", "");
                    certdigital = certdigital.Replace("-----END CERTIFICATE-----", "");
                    certdigital = certdigital.Replace("\r\n", "");
                }
            }
            else
            {
                MessageBox.Show("No es certificado");
            }

            return certdigital;
        }
        private bool validateKey(string Key, string clave)
        {
            Chilkat.PrivateKey obj = new Chilkat.PrivateKey();
            bool respuesta = obj.LoadPkcs8EncryptedFile(Key, clave);
            return respuesta;
        }
        private byte[] GetFileStream(string fullFilePath)
        {
            FileStream fs = File.OpenRead(fullFilePath);
            try
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                return bytes;
            }
            finally
            {
                fs.Close();
            }
        }
        private void GuardaAccesoTimbrado()
        {
            bool resp = ClsEmp.InsertaAccesoTimbrado(textBox_AccesoTimbrado.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Guardarsucursal_Click(object sender, EventArgs e)
        {
            int NoSucursal;
            string nombresucursal;
            string empresa="";
            if (passedInText!="")
            {
                empresa = passedInText;
            }
            else
            {
                empresa = idempresNew;
            }

            try
            {
                NoSucursal = Convert.ToInt32(txt_sucursal.Text);
                nombresucursal = txt_nombreSucursal.Text;
                if (NoSucursal == 0) { MessageBox.Show(@"El numero de sucursal debe ser diferente de cero","Mensaje.",  MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                if (nombresucursal == "") { MessageBox.Show( @"Ingresa el nombre de la sucursal.","Mensaje.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
            }
            catch (Exception)
            {
                MessageBox.Show(@"Mensaje.", "El numero de sucursal debe ser valor nuemerico.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //if (!ClsSucursales.siExisteSucursal(NoSucursal.ToString(), idempresNew))
            if (true)        //quemado...   aqui se valida si ya existe con el webser
            {
                if (ClsSucursales.inserta_num_sucursal(NoSucursal.ToString(), empresa,nombresucursal))
                {
                    MessageBox.Show(@"Guardado correctamente.", "Mensaje", MessageBoxButtons.OK);
                    this.Close();
                }
                else
                {
                      MessageBox.Show(@"No se pudo registrar la sucursal.", "Mensaje", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show(@"Esta sucursal ya se en cuentra registrada.", "Mensaje", MessageBoxButtons.OK);
            }          
        }        
    }
}
