using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Data.SqlClient;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Threading;

namespace FLXDSK.Formularios.Catalogos.Personal
{
    public partial class Form_Personal : Form
    {
        string idPersonal = "";
        Classes.Catalogos.Personal.Class_Personal ClsPer = new Classes.Catalogos.Personal.Class_Personal();
        Classes.Catalogos.Personal.Class_Puestos ClsPue = new Classes.Catalogos.Personal.Class_Puestos();
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Nomina.Class_ImagenPersonal ClsImg = new Classes.Nomina.Class_ImagenPersonal();
        Classes.Nomina.Class_RegimenEmpleado ClsReg = new Classes.Nomina.Class_RegimenEmpleado();
        Classes.Nomina.Class_RiesgoPuesto ClsRiesg = new Classes.Nomina.Class_RiesgoPuesto();
        Classes.Nomina.Class_Percepciones ClsPercep = new Classes.Nomina.Class_Percepciones();
        Classes.Nomina.Class_Deducciones ClsDeduc = new Classes.Nomina.Class_Deducciones();
        Classes.Nomina.Class_TipoContrato ClsTContrato = new Classes.Nomina.Class_TipoContrato();
        Classes.Nomina.Class_TipoJornada ClsTJornada = new Classes.Nomina.Class_TipoJornada();
        Classes.Nomina.Class_TipoPeriodicidad ClsTPerio = new Classes.Nomina.Class_TipoPeriodicidad();
        Classes.Class_ConfigNomina ClsConfNom = new Classes.Class_ConfigNomina();
        Classes.Nomina.Class_detNomina ClsDetNom = new Classes.Nomina.Class_detNomina();
        
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        /// SAT
        Classes.SAT.Class_Estados ClsEstados = new Classes.SAT.Class_Estados();


        public event Form1.MessageHandler lista_personal;

        public Form_Personal(string temp)
        {
            InitializeComponent();
            idPersonal = temp;
        }
        public void llenarCombos()
        {
            DataTable dtEstados = ClsEstados.getListaWhere(" WHERE iidEstatus =  1  ");
            comboBox_Estado.DataSource = dtEstados;
            comboBox_Estado.DisplayMember = "vchNombre";
            comboBox_Estado.ValueMember = "iidEstado";

            DataTable puestos = new DataTable();
            puestos = ClsPue.getPuestoAll();

            comboBox_Puesto.DataSource = puestos;
            comboBox_Puesto.DisplayMember = "nombre";
            comboBox_Puesto.ValueMember = "id";

            DataTable sexo = new DataTable("TablaSexo");
            sexo.Columns.Add("sexo");
            sexo.Columns.Add("idsexo");
            DataRow drsexo;
            drsexo = sexo.NewRow();
            drsexo[1] = "0";
            drsexo[0] = "Seleccionar";
            sexo.Rows.Add(drsexo);
            drsexo = sexo.NewRow();
            drsexo[1] = "H";
            drsexo[0] = "Hombre";
            sexo.Rows.Add(drsexo);
            drsexo = sexo.NewRow();
            drsexo[1] = "M";
            drsexo[0] = "Mujer";
            sexo.Rows.Add(drsexo);

            comboBox_Sexo.DataSource = sexo;
            comboBox_Sexo.DisplayMember = "sexo";
            comboBox_Sexo.ValueMember = "idsexo";

            DataTable estCivil = new DataTable("TablaestCivil");
            estCivil.Columns.Add("estCivil");
            estCivil.Columns.Add("idestCivil");
            DataRow drcivil;
            drcivil = estCivil.NewRow();
            drcivil[1] = "0";
            drcivil[0] = "Seleccionar";
            estCivil.Rows.Add(drcivil);
            drcivil = estCivil.NewRow();
            drcivil[1] = "1";
            drcivil[0] = "Soltero(a)";
            estCivil.Rows.Add(drcivil);
            drcivil = estCivil.NewRow();
            drcivil[1] = "2";
            drcivil[0] = "Casado(a)";
            estCivil.Rows.Add(drcivil);
            drcivil = estCivil.NewRow();
            drcivil[1] = "3";
            drcivil[0] = "Separado(a)";
            estCivil.Rows.Add(drcivil);
            drcivil = estCivil.NewRow();
            drcivil[1] = "4";
            drcivil[0] = "Divorsiado(a)";
            estCivil.Rows.Add(drcivil);
            drcivil = estCivil.NewRow();
            drcivil[1] = "5";
            drcivil[0] = "Viudo(a)";
            estCivil.Rows.Add(drcivil);
            drcivil = estCivil.NewRow();
            drcivil[1] = "6";
            drcivil[0] = "Union Libre";
            estCivil.Rows.Add(drcivil);

            comboBox_EstadoCivil.DataSource = estCivil;
            comboBox_EstadoCivil.DisplayMember = "estCivil";
            comboBox_EstadoCivil.ValueMember = "idestCivil";
        }

        private void Form_Personal_Load(object sender, EventArgs e)
        {
            BloquearPagoNomina();
            CargaListas();

            dateTimePicker_Ingreso.Format = DateTimePickerFormat.Custom;
            dateTimePicker_Ingreso.CustomFormat = "dd/MM/yyyy";
            dateTimePicker_Nacimiento.Format = DateTimePickerFormat.Custom;
            dateTimePicker_Nacimiento.CustomFormat = "dd/MM/yyyy";

            llenarCombos();

            if (idPersonal != "")
            {
                DesbloquearPagoNomina();
                llenarDatos();

                //////////nomina
                CargaListaPagoNominaPercepciones(idPersonal);
                CargaListaPagoNominaDeducciones(idPersonal);
                setMontos();

            }
        }

        /*------------------------------------------------------------------ Información y pago de nomina del personal --------------------------------------------------------------------*/
        

        public void BloquearPagoNomina()
        {
            button_AddPercepcion.Enabled = false;            
            comboBox_Percepciones.Enabled = false;
            textBox_MontoPercepcion.Enabled = false;
            textBox_GravaPercepcion.Enabled = false;

            button_AddDeduccion.Enabled = false;
            comboBox_Deducciones.Enabled = false;
            textBox_GravaDeduccion.Enabled = false;
            textBox_MontoDeduccion.Enabled = false;
        }
        public void DesbloquearPagoNomina()
        {
            button_AddPercepcion.Enabled = true;
            comboBox_Percepciones.Enabled = true;
            textBox_MontoPercepcion.Enabled = true;
            textBox_GravaPercepcion.Enabled = true;

            button_AddDeduccion.Enabled = true;
            comboBox_Deducciones.Enabled = true;
            textBox_GravaDeduccion.Enabled = true;
            textBox_MontoDeduccion.Enabled = true;
        }

        private void CargaListas()
        {
            LlenadoRegimen();
            LlenadoRiesgo();
            LlenadoPercepciones();
            LlenadoDeducciones();
            LlenaPuestos();
            LlenaTipoContrato();
            LlenaTipoJornada();
            LlenaPeriodicidad();         
        }
        private void LlenadoRegimen()
        {
            DataTable dt = new DataTable("data");
            dt = ClsReg.GetListaSeleccion();
            comboBox_Regimen.DataSource = dt;
            comboBox_Regimen.DisplayMember = "nombre";
            comboBox_Regimen.ValueMember = "id";
        }
        private void LlenadoRiesgo()
        {
            DataTable dt = new DataTable("data");
            dt = ClsRiesg.GetListaSeleccion();
            comboBox_TipoRiesgo.DataSource = dt;
            comboBox_TipoRiesgo.DisplayMember = "nombre";
            comboBox_TipoRiesgo.ValueMember = "id";
        }
        private void LlenadoPercepciones()
        {
            DataTable dt = new DataTable("data");
            dt = ClsPercep.GetListaSeleccion();
            comboBox_Percepciones.DataSource = dt;
            comboBox_Percepciones.DisplayMember = "nombre";
            comboBox_Percepciones.ValueMember = "id";
        }
        private void LlenadoDeducciones()
        {
            DataTable dt = new DataTable("data");
            dt = ClsDeduc.GetListaSeleccion();
            comboBox_Deducciones.DataSource = dt;
            comboBox_Deducciones.DisplayMember = "nombre";
            comboBox_Deducciones.ValueMember = "id";
        }
        private void LlenaPuestos()
        {
            DataTable dt = new DataTable("data");
            dt = ClsPue.getPuestoAll();
            comboBox_Puesto.DataSource = dt;
            comboBox_Puesto.DisplayMember = "nombre";
            comboBox_Puesto.ValueMember = "id";
        }
        private void LlenaTipoContrato()
        {
            DataTable dt = new DataTable("data");
            dt = ClsTContrato.GetListaSeleccion();
            comboBox_TipoContrato.DataSource = dt;
            comboBox_TipoContrato.DisplayMember = "nombre";
            comboBox_TipoContrato.ValueMember = "id";
        }
        private void LlenaTipoJornada()
        {
            DataTable dt = new DataTable("data");
            dt = ClsTJornada.GetListaSeleccion();
            comboBox_TipoJornada.DataSource = dt;
            comboBox_TipoJornada.DisplayMember = "nombre";
            comboBox_TipoJornada.ValueMember = "id";
        }
        private void LlenaPeriodicidad()
        {
            DataTable dt = new DataTable("data");
            dt = ClsTPerio.GetListaSeleccion();
            comboBox_PeriodicidadPago.DataSource = dt;
            comboBox_PeriodicidadPago.DisplayMember = "nombre";
            comboBox_PeriodicidadPago.ValueMember = "id";
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        public void llenarDatos() 
        {
            DataTable datos = new DataTable();
            datos = ClsPer.obtener_personal_x_id(idPersonal);

            DataRow row = datos.Rows[0];

            comboBox_Puesto.SelectedValue = row["iidPuesto"].ToString();
            comboBox_TipoContrato.SelectedValue = row["iidTipoContrato"].ToString();
            comboBox_TipoJornada.SelectedValue = row["iidTipoJornada"].ToString();
            comboBox_TipoRiesgo.SelectedValue = row["iidRiesgo"].ToString();
            comboBox_Regimen.SelectedValue = row["iidRegimen"].ToString();
            comboBox_PeriodicidadPago.SelectedValue = row["iidPeriodicidad"].ToString();
            textBox_Correo.Text = row["vchCorreo"].ToString();
            textBox_ClaveEmp.Text = row["vchCodigo"].ToString();
            dateTimePicker_Ingreso.Text = row["dfechaIngreso"].ToString();
            dateTimePicker_Nacimiento.Text = row["dfechaNacimiento"].ToString();
            textBox_Nombres.Text = row["vchNombres"].ToString();
            textBox_Paterno.Text = row["vchApellidoPat"].ToString();
            textBox_Materno.Text = row["vchApellidoMat"].ToString();
            textBox_Calle.Text = row["vchDomicilio"].ToString();
            textBox_NumExt.Text = row["vchNumExt"].ToString();
            textBox_NumInt.Text = row["vchNumInt"].ToString();
            textBox_Localidad.Text = row["vchLocalidad"].ToString();
            textBox_Municipio.Text = row["vchMunicipio"].ToString();
            textBox_Colonia.Text = row["vchColonia"].ToString();
            comboBox_Estado.SelectedValue = row["iidEstado"].ToString();
            textBox_CP.Text = row["vchCp"].ToString();
            textBox_Telefono.Text = row["vchTelefono"].ToString();
            comboBox_EstadoCivil.Text = row["vchEstadoCivil"].ToString();
            comboBox_Sexo.SelectedValue = row["vchSexo"].ToString();
            textBox_CURP.Text = row["vchCURP"].ToString();
            textBox_RFC.Text = row["vchRfc"].ToString();
            textBox_Observacion.Text = row["vchObservacion"].ToString();
            textBox_CtaPago.Text = row["vchCtaPago"].ToString();
            textBox_Clave.Text = row["vchClave"].ToString();
            textBox_Usuario.Text = row["vchUsuario"].ToString();

            ///IMAGEN
            datos = ClsPer.GetImagen(idPersonal);
            try
            {
                row = datos.Rows[0];
                byte[] dibujoByteArray = (byte[])row["imgFoto"];
                MemoryStream ms = new MemoryStream();
                ms.Write(dibujoByteArray, 0, dibujoByteArray.Length);
                System.Drawing.Bitmap b = new Bitmap(ms);
                pictureBox_Imagen.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox_Imagen.Image = new System.Drawing.Bitmap(b);
            }
            catch
            {
            }
        }

        public void guardarImagen() 
        {
            idPersonal = ClsPer.obtener_id_x_curp(textBox_CURP.Text);

            bool existeImagen = true;
            Image ImgRedimencionada = null;
            try
            {
                //Image dibujo = new Bitmap(rutaAplicacion + @"\Imagen.bmp");
                Image dibujo = new Bitmap(pictureBox_Imagen.Image);
                //Creamos un stream en memoria para guardar la imagen
                MemoryStream memStream = new MemoryStream();
                //Guardamos la imagen en nuestro stream especificando el formato (jpg,bmp...) atentos al parámetro ImageFormat
                dibujo.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //Guardamos el stream en un array de bytes
                Byte[] dibujoByteArray = memStream.GetBuffer();
                System.Text.Encoding enc = System.Text.Encoding.ASCII;
                string myString = enc.GetString(dibujoByteArray);

                ImgRedimencionada = ResizeImage(pictureBox_Imagen.Image, 400, 400);
            }
            catch
            { existeImagen = false; }


            if (idPersonal != "")
            {
                //imagen
                if (existeImagen == true)
                {
                    DataTable InfoImg = new DataTable();
                    DataRow img;
                    InfoImg.Columns.Add("imagen", System.Type.GetType("System.Byte[]"));
                    img = InfoImg.NewRow();
                    img["imagen"] = ImageToByte(ImgRedimencionada);
                    InfoImg.Rows.Add(img);
                    ClsPer.inserta_imagen(InfoImg, idPersonal);
                }
                idPersonal = "";
                this.Close();
            }
            else
            {
                MessageBox.Show("Problema al actualizar");
            }
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

        public static byte[] ImageToByte(Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

        private void button_Imagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox_Imagen.Image = Image.FromFile(dialog.FileName);
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (textBox_Nombres.Text == "" || textBox_Paterno.Text == "" || textBox_Materno.Text == "" ||
               textBox_Calle.Text == "" ||
               textBox_Colonia.Text == "" || textBox_Municipio.Text == ""
               )
            {
                MessageBox.Show("Llenar los campos requeridos");
                return;
            }

            try
            {
                if (comboBox_Estado.SelectedValue.ToString() == "0" || comboBox_EstadoCivil.SelectedValue.ToString() == "0" ||
                   comboBox_Sexo.SelectedValue.ToString() == "0" || comboBox_Puesto.SelectedValue.ToString() == "0" ||
                   comboBox_TipoContrato.SelectedValue.ToString() == "0" || comboBox_TipoJornada.SelectedValue.ToString() == "0" ||
                   //comboBox_TipoRiesgo.SelectedValue.ToString() == "0" || comboBox_Regimen.SelectedValue.ToString() == "0" ||
                   comboBox_PeriodicidadPago.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Llenar los campos requeridos");
                    return;
                }
            }
            catch {
                MessageBox.Show("Llenar los campos requeridos");
                return;
            }


            string ingreso = "";
            if (idPersonal != "")
            {
                try
                {
                    string[] var = dateTimePicker_Ingreso.Text.Split('/');
                    ingreso = var[2] + "-" + var[1] + "-" + var[0] + "T00:00:00";
                }
                catch
                {
                    DataTable dt = new DataTable();
                    dt = ClsPer.obtener_personal_x_id(idPersonal);

                    DataRow rows = dt.Rows[0];

                    string fingreso = rows["dfechaIngreso"].ToString();
                    string[] var = fingreso.Split('/');
                    ingreso = var[2] + "-" + var[1] + "-" + var[0] + "T00:00:00";
                }
            }
            else
            {
                string[] var = dateTimePicker_Ingreso.Text.Split('/');
                ingreso = var[2] + "-" + var[1] + "-" + var[0] + "T00:00:00";
            }

            string[] var2 = dateTimePicker_Nacimiento.Text.Split('/');
            string nacimiento = var2[2] + "-" + var2[1] + "-" + var2[0] + "T00:00:00";

            if (textBox_Usuario.Text.Trim() != "")
            {
                if (textBox_Clave.Text.Trim() != "")
                {
                    if (textBox_Clave.Text.Trim().Length != 4)
                    {
                        MessageBox.Show("La contraseña debe tener 4 digitos");
                        return;
                    }
                    try
                    {
                        Convert.ToInt32(textBox_Clave.Text.Trim());
                    }
                    catch
                    {
                        MessageBox.Show("La contraseña debe ser numérica");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Ingresa una contraseña");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Ingresa un nombre de usuario para iniciar sesión");
                return;
            }

            DataTable Info = new DataTable();
            DataRow row;

            Info.Columns.Add("idpersonal", System.Type.GetType("System.String"));
            Info.Columns.Add("Nombre", System.Type.GetType("System.String"));
            Info.Columns.Add("paterno", System.Type.GetType("System.String"));
            Info.Columns.Add("materno", System.Type.GetType("System.String"));
            Info.Columns.Add("curp", System.Type.GetType("System.String"));
            Info.Columns.Add("rfc", System.Type.GetType("System.String"));
            Info.Columns.Add("nacimiento", System.Type.GetType("System.String"));
            Info.Columns.Add("sexo", System.Type.GetType("System.String"));
            Info.Columns.Add("civil", System.Type.GetType("System.String"));
            Info.Columns.Add("calle", System.Type.GetType("System.String"));
            Info.Columns.Add("exteriro", System.Type.GetType("System.String"));
            Info.Columns.Add("interior", System.Type.GetType("System.String"));
            Info.Columns.Add("colonia", System.Type.GetType("System.String"));
            Info.Columns.Add("municipio", System.Type.GetType("System.String"));
            Info.Columns.Add("localidad", System.Type.GetType("System.String"));
            Info.Columns.Add("cp", System.Type.GetType("System.String"));
            Info.Columns.Add("idestado", System.Type.GetType("System.String"));
            Info.Columns.Add("telefono", System.Type.GetType("System.String"));
            Info.Columns.Add("correo", System.Type.GetType("System.String"));
            Info.Columns.Add("ingreso", System.Type.GetType("System.String"));
            Info.Columns.Add("idpuesto", System.Type.GetType("System.String"));
            Info.Columns.Add("idTipoContrato", System.Type.GetType("System.String"));
            Info.Columns.Add("idTipoJornada", System.Type.GetType("System.String"));
            Info.Columns.Add("idTipoRiesgo", System.Type.GetType("System.String"));
            Info.Columns.Add("idRegimen", System.Type.GetType("System.String"));
            Info.Columns.Add("idPeriocidadPago", System.Type.GetType("System.String"));
            Info.Columns.Add("clave", System.Type.GetType("System.String"));
            Info.Columns.Add("observacion", System.Type.GetType("System.String"));
            Info.Columns.Add("ctaPago", System.Type.GetType("System.String"));
            Info.Columns.Add("vchclave", System.Type.GetType("System.String"));
            Info.Columns.Add("vchUsuario", System.Type.GetType("System.String"));

            row = Info.NewRow();
            row["idpersonal"] = idPersonal;
            row["Nombre"] = textBox_Nombres.Text;
            row["paterno"] = textBox_Paterno.Text;
            row["materno"] = textBox_Materno.Text;
            row["curp"] = textBox_CURP.Text;
            row["rfc"] = textBox_RFC.Text;
            row["nacimiento"] = nacimiento;
            row["sexo"] = comboBox_Sexo.SelectedValue.ToString();
            row["civil"] = comboBox_EstadoCivil.Text;
            row["calle"] = textBox_Calle.Text;
            row["exteriro"] = textBox_NumExt.Text;
            row["interior"] = textBox_NumInt.Text;
            row["colonia"] = textBox_Colonia.Text;
            row["municipio"] = textBox_Municipio.Text;
            row["localidad"] = textBox_Localidad.Text;
            row["cp"] = textBox_CP.Text;
            row["idestado"] = comboBox_Estado.SelectedValue.ToString();
            row["telefono"] = textBox_Telefono.Text; ;
            row["correo"] = textBox_Correo.Text;
            row["ingreso"] = ingreso;
            row["idpuesto"] = comboBox_Puesto.SelectedValue.ToString();
            row["idTipoContrato"] = comboBox_TipoContrato.SelectedValue.ToString();
            row["idTipoJornada"] = comboBox_TipoJornada.SelectedValue.ToString();
            row["idTipoRiesgo"] = comboBox_TipoRiesgo.SelectedValue.ToString();
            row["idRegimen"] = comboBox_Regimen.SelectedValue.ToString();
            row["idPeriocidadPago"] = comboBox_PeriodicidadPago.SelectedValue.ToString();
            row["clave"] = textBox_ClaveEmp.Text;
            row["observacion"] = textBox_Observacion.Text;
            row["ctaPago"] = textBox_CtaPago.Text;
            row["vchclave"] = textBox_Clave.Text;
            row["vchUsuario"] = textBox_Usuario.Text;
            Info.Rows.Add(row);

            if (idPersonal == "")
            {
                if (textBox_CURP.Text.Trim() != "")
                {
                    if (ClsPer.existe_curp(row["curp"].ToString()))
                    {
                        MessageBox.Show("El personal que desea guardar ya existe con esa curp.");
                        return;
                    }
                }

                

                if (textBox_Clave.Text.Trim() != "")
                {
                    DataTable dtExis = ClsPer.getListaWhere(" WHERE vchclave = '" + textBox_Clave.Text.Trim() + "' AND iidEstatus = 1 ");
                    if (dtExis.Rows.Count > 0)
                    {
                        MessageBox.Show("Intente con otra clave");
                        return;
                    }

                }

                if (ClsPer.inserta_personal(Info))
                {
                    guardarImagen();
                    MessageBox.Show("Personal guardado con exito.");
                    lista_personal();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problemas al guardar el personal, intente mas tarde.");
                }

            }
            else
            {
                if (textBox_Clave.Text.Trim() != "")
                {
                    DataTable dtExis = ClsPer.getListaWhere(" WHERE vchclave = '" + textBox_Clave.Text.Trim() + "' AND iidEstatus = 1 AND iidPersonal <> " + idPersonal);
                    if (dtExis.Rows.Count > 0)
                    {
                        MessageBox.Show("Intente con otra clave");
                        return;
                    }

                }

                if (ClsPer.actualiza_personal(Info))
                {
                    guardarImagen();
                    MessageBox.Show("Personal actualizado con exito.");
                    lista_personal();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problemas al actualizar el personal, intente mas tarde.");
                }
            }
        }

        private void button_AddPercepcion_Click(object sender, EventArgs e)
        {
            if (comboBox_Percepciones.Text == "Seleccionar")
            {
                MessageBox.Show("Favor de Seleecionar un tipo de Percepción");
                return;
            }
            if ((textBox_GravaPercepcion.Text == "" || textBox_GravaPercepcion.Text == "0") && (textBox_MontoPercepcion.Text == "" || textBox_MontoPercepcion.Text == "0"))
            {
                MessageBox.Show("Es necesario al menos un monto");
                return;
            }

            double montoGravado = 0;
            double montoPercepcion = 0;

            if (textBox_GravaPercepcion.Text != "")
            {
                try
                {
                    montoGravado = Convert.ToDouble(textBox_GravaPercepcion.Text);
                }
                catch
                {
                    MessageBox.Show("Monto grabado incorrecto");
                    return;
                }
            }

            if (textBox_MontoPercepcion.Text != "")
            {
                try
                {
                    montoPercepcion = Convert.ToDouble(textBox_MontoPercepcion.Text);
                }
                catch
                {
                    MessageBox.Show("Monto de la percepcion incorrecto");
                    return;
                }
            }

            if (montoGravado <= 0 && montoPercepcion <= 0)
            {
                MessageBox.Show("Es necesario al menos un monto");
                return;
            }

            if (montoGravado < 0)
            {
                MessageBox.Show("Monto grabado incorrecto");
                return;
            }

            if (montoPercepcion < 0)
            {
                MessageBox.Show("Monto de la percepcion incorrecto");
                return;
            }


            DataTable Info = new DataTable();
            DataRow Drw;

            Info.Columns.Add("usuario", System.Type.GetType("System.String"));
            Info.Columns.Add("idDeduccion", System.Type.GetType("System.String"));
            Info.Columns.Add("idPercepcion", System.Type.GetType("System.String"));
            Info.Columns.Add("fmontoG", System.Type.GetType("System.String"));
            Info.Columns.Add("fmontoE", System.Type.GetType("System.String"));

            Drw = Info.NewRow();
            Drw["usuario"] = idPersonal;
            Drw["idPercepcion"] = comboBox_Percepciones.SelectedValue.ToString();
            Drw["idDeduccion"] = 0;
            Drw["fmontoG"] = textBox_GravaPercepcion.Text;
            Drw["fmontoE"] = textBox_MontoPercepcion.Text;

            Info.Rows.Add(Drw);
            if (ClsConfNom.existeRegistroPercepcion(Info))
            {
                if (ClsConfNom.ActualizaInformacionPercepcion(Info))
                {
                    CargaListaPagoNominaPercepciones(idPersonal);
                    comboBox_Percepciones.Text = "Seleccionar";
                    textBox_MontoPercepcion.Clear();
                    textBox_GravaPercepcion.Clear();
                    setMontos();
                }
            }
            else
            {
                if (ClsConfNom.InsertaInformacionPercepcion(Info))
                {
                    CargaListaPagoNominaPercepciones(idPersonal);
                    comboBox_Percepciones.Text = "Seleccionar";
                    textBox_MontoPercepcion.Clear();
                    textBox_GravaPercepcion.Clear();
                    setMontos();
                }
            }
        }

        private void CargaListaPagoNominaPercepciones(string id)
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            string sql = "select C.iidConfigurador ID, C.vchNombre Descripcion, P.fMontoE+P.fMontoG as Monto " +
                         "   from catPagoNomina P " +
                         "   inner join catConfiguracionNombreNom C on C.iidConfigurador=P.iidPercepcion " +
                         "   where P.iidPersonal=" + id + " and C.vchTipo='PERCEPCION' and C.iidEstatus=1";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Percecpciones.DataSource = dstConsulta.Tables[0];
                //Se define el tamaño de las columnas
                dataGridView_Percecpciones.Columns["ID"].Visible = false;
                dataGridView_Percecpciones.Columns["Descripcion"].Width = 280;
                dataGridView_Percecpciones.Columns["Monto"].Width = 80;

                dataGridView_Percecpciones.Columns["Descripcion"].ReadOnly = true;
                dataGridView_Percecpciones.Columns["Monto"].ReadOnly = true;

                dataGridView_Percecpciones.Columns["Monto"].DefaultCellStyle.Format = "c";
            }
            catch
            {
            }
            bs.DataSource = dataGridView_Percecpciones.DataSource;
        }

        private void setMontos()
        {
            int sumDeducciones = 0;
            for (int i = 0; i < dataGridView_Deducciones.Rows.Count; ++i)
            {
                sumDeducciones += Convert.ToInt32(dataGridView_Deducciones.Rows[i].Cells["Monto"].Value);
            }

            int sumPercepcion = 0;
            for (int i = 0; i < dataGridView_Percecpciones.Rows.Count; ++i)
            {
                sumPercepcion += Convert.ToInt32(dataGridView_Percecpciones.Rows[i].Cells["Monto"].Value);
            }

            label_deducciones.Text = sumDeducciones.ToString("C2");
            label_percepciones.Text = sumPercepcion.ToString("C2");
            string deduccion = sumDeducciones.ToString();
            string percepcion = sumPercepcion.ToString();
            float valor = float.Parse(percepcion) - float.Parse(deduccion);
            label_total.Text = valor.ToString("C2");
        }

        private void button_AddDeduccion_Click(object sender, EventArgs e)
        {
            if (comboBox_Deducciones.Text == "Seleccionar")
            {
                MessageBox.Show("Favor de Seleecionar un tipo de Deducción");
                return;
            }
            if ((textBox_GravaDeduccion.Text == "") && (textBox_MontoPercepcion.Text == ""))
            {
                MessageBox.Show("Es necesario al menos un monto");
                return;
            }

            double montoGravado = 0;
            double montoDeduccion = 0;

            if (textBox_GravaDeduccion.Text != "")
            {
                try
                {
                    montoGravado = Convert.ToDouble(textBox_GravaDeduccion.Text);
                }
                catch
                {
                    MessageBox.Show("Monto grabado incorrecto");
                    return;
                }
            }

            if (textBox_MontoDeduccion.Text != "")
            {
                try
                {
                    montoDeduccion = Convert.ToDouble(textBox_MontoDeduccion.Text);
                }
                catch
                {
                    MessageBox.Show("Monto de la deduccion incorrecto");
                    return;
                }
            }

            if (montoGravado <= 0 && montoDeduccion <= 0)
            {
                MessageBox.Show("Es necesario al menos un monto");
                return;
            }

            if (montoGravado < 0)
            {
                MessageBox.Show("Monto grabado incorrecto");
                return;
            }

            if (montoDeduccion < 0)
            {
                MessageBox.Show("Monto de la deduccion incorrecto");
                return;
            }

            DataTable Info = new DataTable();
            DataRow Drw;

            Info.Columns.Add("usuario", System.Type.GetType("System.String"));
            Info.Columns.Add("idDeduccion", System.Type.GetType("System.String"));
            Info.Columns.Add("idPercepcion", System.Type.GetType("System.String"));
            Info.Columns.Add("fmontoG", System.Type.GetType("System.String"));
            Info.Columns.Add("fmontoE", System.Type.GetType("System.String"));

            Drw = Info.NewRow();
            Drw["usuario"] = idPersonal;
            Drw["idPercepcion"] = 0;
            Drw["idDeduccion"] = comboBox_Deducciones.SelectedValue.ToString();
            Drw["fmontoG"] = textBox_GravaDeduccion.Text;
            Drw["fmontoE"] = textBox_MontoDeduccion.Text;
            Info.Rows.Add(Drw);

            if (ClsConfNom.existeRegistroDeduccion(Info))
            {
                if (ClsConfNom.ActualizaInformacionDeduccion(Info))
                {
                    CargaListaPagoNominaDeducciones(idPersonal);
                    comboBox_Percepciones.Text = "Seleccionar";
                    textBox_MontoDeduccion.Clear();
                    textBox_GravaDeduccion.Clear();
                    setMontos();
                }
            }
            else
            {
                if (ClsConfNom.InsertaInformacionDeduccion(Info))
                {
                    CargaListaPagoNominaDeducciones(idPersonal);
                    comboBox_Deducciones.Text = "Seleccionar";
                    textBox_MontoDeduccion.Clear();
                    textBox_GravaDeduccion.Clear();
                    setMontos();
                }
            }
        }

        private void CargaListaPagoNominaDeducciones(string id)
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            string sql = " select C.iidConfigurador ID, C.vchNombre Descripcion, P.fMontoE+P.fMontoG as Monto " +
                         "   from catPagoNomina P  " +
                         "   inner join catConfiguracionNombreNom C on C.iidConfigurador=P.iidDeduccion " +
                         "   where P.iidPersonal=" + id + " and C.vchTipo='DEDUCCION' and C.iidEstatus=1";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Deducciones.DataSource = dstConsulta.Tables[0];
                //Se define el tamaño de las columnas
                dataGridView_Deducciones.Columns["ID"].Visible = false;
                dataGridView_Deducciones.Columns["Descripcion"].Width = 280;
                dataGridView_Deducciones.Columns["Monto"].Width = 80;

                dataGridView_Deducciones.Columns["Descripcion"].ReadOnly = true;
                dataGridView_Deducciones.Columns["Monto"].ReadOnly = true;

                dataGridView_Deducciones.Columns["Monto"].DefaultCellStyle.Format = "c";

            }
            catch
            {
            }
            bs.DataSource = dataGridView_Deducciones.DataSource;
        }

        private void dataGridView_Percecpciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedCellCollection col = this.dataGridView_Percecpciones.SelectedCells;
            try
            {
                if (col[1].Value.ToString() != "")
                {
                    DialogResult resultado = MessageBox.Show(@"Esta seguro de eliminar esta percepcion", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (DialogResult.OK == resultado)
                    {
                        string idPercepcion = col[0].Value.ToString();
                        if (ClsConfNom.deletePercepcionPagoNomina(idPersonal, idPercepcion))
                        {
                            MessageBox.Show("Eliminada correctamente");
                            CargaListaPagoNominaPercepciones(idPersonal);
                            setMontos();
                        }
                        else
                        {
                            MessageBox.Show("Problema al eliminar la Percepcion intente nuevamente");
                        }
                    }
                }
            }
            catch { }
        }
        private void dataGridView_Deducciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedCellCollection col = this.dataGridView_Deducciones.SelectedCells;
            try
            {
                if (col[1].Value.ToString() != "")
                {
                    DialogResult resultado = MessageBox.Show(@"Esta seguro de eliminar esta deduccion", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (DialogResult.OK == resultado)
                    {
                        string idDeduccion = col[0].Value.ToString();
                        if (ClsConfNom.deleteDeduccionPagoNomina(idPersonal, idDeduccion))
                        {
                            MessageBox.Show("Eliminada correctamente");
                            CargaListaPagoNominaDeducciones(idPersonal);
                            setMontos();
                        }
                        else
                        {
                            MessageBox.Show("Problema al eliminar la Deduccion intente nuevamente");
                        }
                    }
                }
            }
            catch { }
        }

        private void comboBox_Puesto_SelectedValueChanged(object sender, EventArgs e)
        {
            string IdPue = "";
            try
            {
                IdPue = comboBox_Puesto.SelectedValue.ToString();
                if (IdPue == "0" || IdPue == "")
                {
                    textBox_Clave.Text = "";
                    textBox_Clave.Visible = false;
                    label_Contrasena.Visible = false;
                    return;
                }

                DataTable dtInfoPue = ClsPue.getListaWhere(" WHERE iidPuesto = " + IdPue + " AND isMesero = 1 ");
                if (dtInfoPue.Rows.Count > 0)
                {
                    label_Usuario.Visible = true;
                    textBox_Usuario.Text = "";
                    textBox_Usuario.Visible = true;
                    textBox_Clave.Text = "";
                    textBox_Clave.Visible = true;
                    label_Contrasena.Visible = true;
                }
                else
                {
                    textBox_Clave.Text = "";
                    textBox_Clave.Visible = false;
                    label_Contrasena.Visible = false;
                }
            }
            catch { }

        }


       

       

    }
}
