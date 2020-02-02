using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FLXDSK.Formularios.Catalogos.Mercancia
{
    public partial class Form_Producto2 : Form
    {
        string IdPassText = "";
        bool LoadComplete = false;
        DataTable dtListaProd;
        DataTable dtListaCom;
        double CostoTotal = 0;
        double PrecioNeto = 0;

        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();

        Classes.Catalogos.Mercancia.Class_Productos ClsProducto = new Classes.Catalogos.Mercancia.Class_Productos();
        Classes.Catalogos.Mercancia.Class_Materia_Prima ClsMateriaPrima = new Classes.Catalogos.Mercancia.Class_Materia_Prima();
        
        Classes.Catalogos.Mercancia.Class_Categorias ClsCat = new Classes.Catalogos.Mercancia.Class_Categorias();
        Classes.Inventarios.Class_Almacen fnAlmacen = new Classes.Inventarios.Class_Almacen();
        Classes.SAT.Productos.Class_ProductoServicio ClsProductoSat = new Classes.SAT.Productos.Class_ProductoServicio();
        Classes.SAT.Class_UnidadMedida ClsMedidaSat = new Classes.SAT.Class_UnidadMedida();


        Classes.Class_Composicion ClsComposicion = new Classes.Class_Composicion();
        
        public event Form1.MessageHandler CargaLista;  
        public Form_Producto2(string id)
        {
            IdPassText = id;
            InitializeComponent();

            dtListaProd = new DataTable();
            dtListaProd.Columns.Add("iidMateriPrima", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("iidUnidad", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("Medida", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("Cantidad", System.Type.GetType("System.Double"));
            dtListaProd.Columns.Add("fCosto", System.Type.GetType("System.Double"));
            iniciaTabla();
            
        }
        public void LlenadoCategorias()
        {
            DataTable dtCatagorias = ClsCat.getCategoriasAll();
            comboBox_Categoria.DataSource = dtCatagorias;
            comboBox_Categoria.DisplayMember = "nombre";
            comboBox_Categoria.ValueMember = "id";
        }
        public void llenarCombos()
        {
            LlenadoCategorias();

            DataTable dtAlmacen = fnAlmacen.getAlmacenesAll();
            comboBox_Almacen.DataSource = dtAlmacen;
            comboBox_Almacen.DisplayMember = "nombre";
            comboBox_Almacen.ValueMember = "id";

        }
        public static void EnableTab(TabPage page, bool enable)
        {
            foreach (Control ctl in page.Controls) ctl.Enabled = enable;
        }
        private void checkBox_Paquete_CheckedChanged(object sender, EventArgs e)
        {
            if (LoadComplete)
            {
                if (checkBox_Paquete.Checked)
                {
                    dateTimePicker_Fin.Visible = true;
                    dateTimePicker_Inicio.Visible = true;
                }
            }
        }
        private byte[] GetImagen()
        {
            try
            {
                Image dibujo = new Bitmap(pictureBox_producto.Image);
                ImageConverter converter = new ImageConverter();
                return (byte[])converter.ConvertTo(dibujo, typeof(byte[]));
            }
            catch
            {
                return null;
            }
        }

        private void button_Add_Categorias_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Mercancia.Form_Categorias form = new Mercancia.Form_Categorias("");
            form.ShowDialog();

            //REcargamos
            LlenadoCategorias();
        }
        private void pictureBox_producto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox_producto.Image = Image.FromFile(dialog.FileName);
                //rutaOriginal = dialog.FileName;
                //imagenName = Path.GetFileName(dialog.FileName);
            }
        }
        private void Form_Producto2_Load(object sender, EventArgs e)
        {

            dateTimePicker_Inicio.Format = DateTimePickerFormat.Custom;
            dateTimePicker_Inicio.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker_Fin.Format = DateTimePickerFormat.Custom;
            dateTimePicker_Fin.CustomFormat = "dd/MM/yyyy HH:mm";

            dateTimePicker_Inicio.Value = DateTime.Now.AddDays(-2);
            dateTimePicker_Fin.Value = DateTime.Now.AddDays(1);


            textBox_Costo.Enabled = false;

            label_Leyenda.Text = "";
            llenarCombos();

            if (IdPassText != "")
            {
                getIdProducto();
                checkBox_Paquete.Enabled = false;
            }
            else
            {
                EnableTab(tabPage2, false);
            }

            try
            {
                if (pictureBox_producto.Image == null)
                    pictureBox_producto.Image = Image.FromFile(@"img\sin_imagen.png");
            }
            catch { }
            LoadComplete = true;
        }
        private void getIdProducto()
        {
            DataTable dtInfo = ClsProducto.getListaWhere(" WHERE iidProducto = " + IdPassText);
            if (dtInfo.Rows.Count == 0)
            {
                MessageBox.Show("Producto no encontrado");
                this.Close();
                return;
            }

            

            textBox_Codigo.Text = dtInfo.Rows[0]["vchcodigo"].ToString();
            textBox_Precio.Text = dtInfo.Rows[0]["fprecio"].ToString();
            textBox_Costo.Text = dtInfo.Rows[0]["fCosto"].ToString();
            textBox_Descripcion.Text = dtInfo.Rows[0]["vchdescripcion"].ToString();
            textBox_MaximoxMesa.Text = dtInfo.Rows[0]["iNumMesasPermitidas"].ToString();
            try
            {
                comboBox_Almacen.SelectedValue = dtInfo.Rows[0]["iidAlmacen"].ToString();
            }
            catch { }
            try {
                comboBox_Categoria.SelectedValue = dtInfo.Rows[0]["iidcategoria"].ToString();
            }
            catch { }


            DataTable dtCodigoSAt = ClsProductoSat.getListaWhere(" WHERE vchCodigo = '" + dtInfo.Rows[0]["vchCodigoSat"].ToString() + "'");
            if (dtCodigoSAt.Rows.Count > 0)
            {
                button_CodigoSat.Text = dtInfo.Rows[0]["vchCodigoSat"].ToString() + " - " + dtCodigoSAt.Rows[0]["vchNombre"].ToString();
                button_CodigoSat.Tag = dtInfo.Rows[0]["vchCodigoSat"].ToString();
            }

            DataTable dtMedidaSAt = ClsMedidaSat.getListaWhere(" WHERE iidUnidadMedida = " + dtInfo.Rows[0]["iidUnidadMedida"].ToString());
            if (dtMedidaSAt.Rows.Count > 0)
            {
                button_MedidaSat.Text = dtMedidaSAt.Rows[0]["vchClave"].ToString() + " - " + dtMedidaSAt.Rows[0]["vchNombre"].ToString();
                button_MedidaSat.Tag = dtMedidaSAt.Rows[0]["vchClave"].ToString();
            }

            bool isCombo = false;
            if (Convert.ToBoolean(dtInfo.Rows[0]["isCombo"]) == true)
            {
                checkcombo.Checked = true;
                checkcombo.Enabled = false;
                isCombo = true;
               
            }
            else {
                button1.Visible = false;
                checkcombo.Checked = false;
                checkcombo.Enabled = false;
            }
         

            if (dtInfo.Rows[0]["siPromo"].ToString() == "1")
                checkBox_Paquete.Checked = true;

            if (dtInfo.Rows[0]["siIVA"].ToString() == "1")
                checkBox_siIVA.Checked = true;


            if (dtInfo.Rows[0]["siComida"].ToString() == "1")
                radioButton_TipoComida.Checked = true;
            else
                radioButton_TipoBebida.Checked = true;


            if (dtInfo.Rows[0]["siCostoCalculado"].ToString() == "1")
                checkBox_FijarEnelProducto.Checked = true;
            else
                checkBox_FijarEnelProducto.Checked = false;

            try
            {
                byte[] dibujoByteArray = (byte[])dtInfo.Rows[0]["IFileImagen"];
                if (dibujoByteArray != null)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(dibujoByteArray, 0, dibujoByteArray.Length);
                    System.Drawing.Bitmap b = new Bitmap(ms);
                    pictureBox_producto.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_producto.Image = new System.Drawing.Bitmap(b);
                }
            }
            catch
            {
            }



            //////Composicion
            if (isCombo)
            {
                DataTable dtListaComp = ClsComposicion.getListaComboWhere(" WHERE iidProducto = " + IdPassText);
                if (dtListaComp.Rows.Count > 0)
                    foreach (DataRow ROw in dtListaComp.Rows)
                    {
                        Classes.Class_Session.Idproducto = ROw["iidTipoProducto"].ToString();
                        Classes.Class_Session.fCantidad =float.Parse( ROw["fCantidad"].ToString());
                        if (Convert.ToBoolean(ROw["siProductoDefinido"]))
                        {
                            Classes.Class_Session.isDefinido = true;
                        }


                        AgregaproductoCombo();
                    }
                LoadComplete = true;
                CalculaUtilidad();
            }
            else
            {
                DataTable dtListaComp = ClsComposicion.getListaWhere(" WHERE iidProducto = " + IdPassText);
                if (dtListaComp.Rows.Count > 0)
                    foreach (DataRow ROw in dtListaComp.Rows)
                    {
                        Classes.Class_Session.MateriaPrima = ROw["iidMateriPrima"].ToString();
                        Classes.Class_Session.fNewExistencia = Convert.ToDouble(ROw["fCantidad"].ToString());

                        AgregaTempMateriaPrima();
                    }
                LoadComplete = true;
                CalculaUtilidad();
            }
        }
        

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (textBox_Codigo.Text.Trim() == "" || textBox_Descripcion.Text.Trim() =="" || textBox_Precio.Text.Trim() =="")
            {
                MessageBox.Show("Ingresar la Información Requerida");
                return;
            }

            double Precio = 0;
            try
            {
                Precio = Convert.ToDouble(textBox_Precio.Text.Trim());
            }
            catch {
                MessageBox.Show("Formato del Precio Incorrecto");
                return;
            }
            string IdAlmacen = "";
            string IdCategoria = "";

            try
            {
                IdCategoria = comboBox_Categoria.SelectedValue.ToString();
            }
            catch { }
            if (IdCategoria == "" || IdCategoria == "0")
            {
                MessageBox.Show("Seleccionar la Categoría");
                return;
            }

            try
            {
                IdAlmacen = comboBox_Almacen.SelectedValue.ToString();
                //IdAlmacen="1";
            }
            catch { }
            if (IdAlmacen == "" || IdAlmacen == "0")
            {
                MessageBox.Show("Seleccionar el Almacen");
                return;
            }

            if (button_CodigoSat.Tag.ToString() == "")
            {
                MessageBox.Show("Código del Sat Requerido");
                return;
            }

            if (button_MedidaSat.Tag.ToString() == "")
            {
                MessageBox.Show("Medida del Sat Requerida");
                return;
            }

            /*int MaximoxMesa = 0;
            if (textBox_MaximoxMesa.Text.Trim() != "")
            {
                try
                {
                    MaximoxMesa = Convert.ToInt32(textBox_MaximoxMesa.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("El Número Máximo por Mesa es incorrecto, debe ser númerico");
                    return;
                }
            }*/


            string siIVA = "0";
            if (checkBox_siIVA.Checked)
                siIVA = "1";

            string siPromo = "0";
            if (checkBox_Paquete.Checked)
                siPromo = "0";

            string siComida = "0";
            if (radioButton_TipoComida.Checked)
                siComida = "1";

            //Validamos Exista
            DataTable dtExist = ClsProductoSat.getListaWhere(" WHERE vchCodigo= '" + button_CodigoSat.Tag.ToString() + "' ");
            if (dtExist.Rows.Count == 0)
            {
                MessageBox.Show("Código del Sat Incorrecto");
                return;
            }
            dtExist = ClsMedidaSat.getListaWhere(" WHERE vchClave= '" + button_MedidaSat.Tag.ToString() + "' ");
            if (dtExist.Rows.Count == 0)
            {
                MessageBox.Show("Medida del Sat Incorrecta");
                return;
            }
            string IdUnidadMedidad = dtExist.Rows[0]["iidUnidadMedida"].ToString();


            /*string FInicio = "";
            string FFin = "";
            if (siPromo == "1")
            {
                try
                {
                    string[] varI = dateTimePicker_Inicio.Text.Split('/', ' ', ':');
                    FInicio = varI[2] + "-" + varI[1] + "-" + varI[0] + "T" + varI[3] + ":" + varI[4] + ":00";

                    string[] varF = dateTimePicker_Fin.Text.Split('/', ' ', ':');
                    FFin = varF[2] + "-" + varF[1] + "-" + varF[0] + "T" + varF[3] + ":" + varF[4] + ":00";

                    DateTime ini = Convert.ToDateTime(FInicio);
                    DateTime fin = Convert.ToDateTime(FFin);
                    DateTime fechaActual = DateTime.Now;

                    if (ini > fin)
                    {
                        MessageBox.Show("La fecha final no pude ser menor a la inicial.");
                        return;
                    }
                }
                catch {
                    MessageBox.Show("Verifique la fecha de la promoción.");
                    return;
                }

            }*/


            string siCostoCalculado = "0";
            if (checkBox_FijarEnelProducto.Checked)
                siCostoCalculado = "1";


            double Costo = 0;
            try
            {
                Costo = Convert.ToDouble(textBox_Costo.Text.Trim().Replace("$", "").Replace(",", ""));
            }
            catch { }

            DataTable Info = new DataTable();
            DataRow row;
            Info.Columns.Add("iidCategoria", System.Type.GetType("System.String"));
            Info.Columns.Add("vchCodigo", System.Type.GetType("System.String"));
            Info.Columns.Add("vchDescripcion", System.Type.GetType("System.String"));
            Info.Columns.Add("fPrecio", System.Type.GetType("System.String"));
            Info.Columns.Add("fCosto", System.Type.GetType("System.String"));
            Info.Columns.Add("siIVA", System.Type.GetType("System.String"));
            Info.Columns.Add("siComida", System.Type.GetType("System.String"));
            Info.Columns.Add("iidDivisa", System.Type.GetType("System.String"));
            Info.Columns.Add("iidAlmacen", System.Type.GetType("System.String"));
            Info.Columns.Add("iidUnidad", System.Type.GetType("System.String"));
            //Info.Columns.Add("dfechaActivo", System.Type.GetType("System.String"));
            //Info.Columns.Add("dfechaVence", System.Type.GetType("System.String"));
            Info.Columns.Add("IFileImagen", System.Type.GetType("System.Byte[]"));
            //Info.Columns.Add("iNumMesasPermitidas", System.Type.GetType("System.String"));
            Info.Columns.Add("siPromo", System.Type.GetType("System.String"));
            Info.Columns.Add("siCostoCalculado", System.Type.GetType("System.String"));
            Info.Columns.Add("iidUnidadMedida", System.Type.GetType("System.String"));
            Info.Columns.Add("vchCodigoSat", System.Type.GetType("System.String"));
            Info.Columns.Add("isCombo", System.Type.GetType("System.String"));
            

            
            

            row = Info.NewRow();
            row["iidCategoria"] = IdCategoria;
            row["vchCodigo"] = textBox_Codigo.Text.Trim();
            row["vchDescripcion"] = textBox_Descripcion.Text.Trim();
            row["fPrecio"] = Precio;
            row["fCosto"] = Costo;
            row["siIVA"] = siIVA;
            row["siComida"] = siComida;

            row["iidDivisa"] = "100";//MXN
            row["iidAlmacen"] = IdAlmacen;
            row["iidUnidad"] = "1";//1 - catUnidadesProductos (compuesto)

            //row["dfechaActivo"] = FInicio;
            //row["dfechaVence"] = FFin;

            row["IFileImagen"] = GetImagen();
            //row["iNumMesasPermitidas"] = MaximoxMesa;
            row["siPromo"] = siPromo;
            row["siCostoCalculado"] = siCostoCalculado;

            row["iidUnidadMedida"] = IdUnidadMedidad;
            row["vchCodigoSat"] = button_CodigoSat.Tag.ToString();
            

            if (checkcombo.Checked)
            {
                row["isCombo"] = "1";
            }
            else { row["isCombo"] = "0"; }

            Info.Rows.Add(row);


            if (IdPassText == "")
            {
                dtExist = ClsProducto.getListaWhere(" WHERE vchCodigo = '" + textBox_Codigo.Text.Trim() + "' AND iidEstatus =  1  ");
                if (dtExist.Rows.Count > 0)
                {
                    MessageBox.Show("Código del Producto Ya Existe Elige otro");
                    return;
                }
                dtExist = ClsProducto.getListaWhere(" WHERE vchDescripcion = '" + textBox_Descripcion.Text.Trim() + "' AND iidEstatus =  1  ");
                if (dtExist.Rows.Count > 0)
                {
                    MessageBox.Show("Descripcion del Producto Ya Existe Elige otra");
                    return;
                }

                if (ClsProducto.InsertaInformacion(Info))
                {
                    MessageBox.Show("Ingresar Composición");

                    IdPassText = ClsProducto.getIdProductoCreado();

                    if (dtListaProd.Rows.Count > 0)
                        foreach (DataRow Row in dtListaProd.Rows)
                        {
                            double Cantidad = Convert.ToDouble(Row["Cantidad"].ToString());
                            string iidUnidadMedida = Row["iidUnidad"].ToString();//MAs Baja Modificada

                            ClsComposicion.InsertaInformacion(IdPassText, Row["iidMateriPrima"].ToString(), Cantidad, iidUnidadMedida);
                        }

                    ///Actualiza el COSTO
                   DataTable dt= ClsProducto.isCombo(IdPassText);
                   if (Convert.ToBoolean(dt.Rows[0]["isCombo"].ToString()))
                   {
                       tabControl1.SelectedTab = tabPage2;
                      button1.Visible = true;
                      button1.Enabled = true;
                      boton_buscar.Enabled = true;
                       dataGridView_MateriaPrima.Enabled = true;

                   }
                   else
                   {
                       button1.Visible = false;
                       tabControl1.SelectedTab = tabPage2;
                       button1.Visible = false;
                       boton_buscar.Enabled = true;
                       button_borrar.Enabled = true;
                       dataGridView_MateriaPrima.Enabled = true;

                   }
                    try
                    {
                        CargaLista();
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("Problemas al guardar");
                    return;
                }



              }//fin de si es producto nuevo
          else
            {
                     int isCombo;
                     DataTable dt = ClsProducto.isCombo(IdPassText);
                    try 
                    {
                     isCombo=Convert.ToInt32(dt.Rows[0]["isCombo"]);

                    }
                    catch (Exception)
                    {
		
                     isCombo=0;
                    } 

                if (isCombo == 1) //si es combo
                {
                  ClsComposicion.Clear_Combo(IdPassText);

                    foreach (DataRow fila in dtListaCom.Rows)
	                {
                        string idProductoDefinido = "0";
                        if (fila["Definido"].ToString() == "SI")
                        {
                            idProductoDefinido = "1";
                        }
                        if (!ClsComposicion.CrearCombo(IdPassText, fila["Categoria"].ToString(), idProductoDefinido, fila["Cantidad"].ToString()))//cero para poder elgir e producto 
                        {
                            MessageBox.Show("Error al crear combo. ");
                            return;
                        }

	                }


                    MessageBox.Show(@"Combo armado.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
  


                }
              
                dtExist = ClsProducto.getListaWhere(" WHERE vchCodigo = '" + textBox_Codigo.Text.Trim() + "' AND iidEstatus =  1 AND iidProducto <>  " + IdPassText);
                if (dtExist.Rows.Count > 0)
                {
                    MessageBox.Show("Código del Producto Ya Existe Elige otro");
                    return;
                }
                dtExist = ClsProducto.getListaWhere(" WHERE vchDescripcion = '" + textBox_Descripcion.Text.Trim() + "' AND iidEstatus =  1  AND iidProducto <>  " + IdPassText);
                if (dtExist.Rows.Count > 0)
                {
                    MessageBox.Show("Descripcion del Producto Ya Existe Elige otra");
                    return;
                }

                if (ClsProducto.ActualizaInformacion(Info, IdPassText))
                {
                    MessageBox.Show("Guardado Correctamente");

                    ClsComposicion.Clear_Composicion(IdPassText);
                    if (dtListaProd.Rows.Count > 0)
                    {
                        foreach (DataRow Row in dtListaProd.Rows)
                        {
                            double Cantidad = Convert.ToDouble(Row["Cantidad"].ToString());
                            string iidUnidadMedida = Row["iidUnidad"].ToString();//MAs Baja Modificada

                            ClsComposicion.InsertaInformacion(IdPassText, Row["iidMateriPrima"].ToString(), Cantidad, iidUnidadMedida);
                        }
                    }

                    this.Close();
                    try
                    {
                        CargaLista();
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("Problemas al guardar");
                    return;
                }
            
            }
        }


        /// <summary>
        /// Composicion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CargaCarrito()
        {
            dataGridView_MateriaPrima.DataSource = dtListaProd;
            dataGridView_MateriaPrima.Columns["iidMateriPrima"].Visible = false;
            dataGridView_MateriaPrima.Columns["fCosto"].Visible = false;
            dataGridView_MateriaPrima.Columns["iidUnidad"].Visible = false;

            dataGridView_MateriaPrima.Columns["Descripcion"].ReadOnly = true;
            dataGridView_MateriaPrima.Columns["Medida"].ReadOnly = true;
            ShowTotals();
        }
        private void ShowTotals()
        {
            try
            {
                CostoTotal = 0;
                foreach (DataRow Row in dtListaProd.Rows)
                {
                    double Cantidad = Convert.ToDouble(Row["Cantidad"].ToString());
                    double fCosto = Convert.ToDouble(Row["fCosto"].ToString());
                    CostoTotal += Math.Round(Cantidad * fCosto, 2);
                }
                label_FCosto.Text = string.Format("{0:c}", CostoTotal);

                if (checkBox_FijarEnelProducto.Checked)
                    textBox_Costo.Text = CostoTotal.ToString();


                CalculaUtilidad();
            }
            catch { }
        }
        private void AgregaTempMateriaPrima()
        {
            DataTable dtMatPrima = ClsMateriaPrima.getLista(" AND M.iidMateriPrima = " + Classes.Class_Session.MateriaPrima);
            if (dtMatPrima.Rows.Count > 0)
            {
                double CostoPz = Convert.ToDouble(dtMatPrima.Rows[0]["fCosto"].ToString());
                double CostoUnitario = Convert.ToDouble(dtMatPrima.Rows[0]["fCosto"].ToString());
                string iidUnidad = dtMatPrima.Rows[0]["iidUnidad"].ToString();
                int contenido = Convert.ToInt32(dtMatPrima.Rows[0]["fContenido"].ToString());
                string Medida = dtMatPrima.Rows[0]["vchNombre"].ToString();
                if (dtMatPrima.Rows[0]["vchNombre"].ToString() == "Litros")
                {
                    Medida = "Mililitros";
                    CostoUnitario = CostoPz / 1000;
                    iidUnidad = "5";
                }
                else
                {
                    if (dtMatPrima.Rows[0]["vchNombre"].ToString() == "Kilos")
                    {
                        Medida = "Gramos";
                        CostoUnitario = CostoPz / contenido;
                        iidUnidad = "3";
                    }

                    if (dtMatPrima.Rows[0]["vchNombre"].ToString() == "Pieza")
                    {
                        Medida = "Pieza";
                        CostoUnitario = CostoPz / contenido;
                        iidUnidad = "4";
                    }
                }

                if (Classes.Class_Session.fNewExistencia == null)
                    Classes.Class_Session.fNewExistencia = 1;
                if (Classes.Class_Session.fNewExistencia == 0)
                    Classes.Class_Session.fNewExistencia = 1;

                DataRow Drw = dtListaProd.NewRow();
                Drw["iidMateriPrima"] = dtMatPrima.Rows[0]["iidMateriPrima"].ToString();
                Drw["iidUnidad"] = iidUnidad;
                Drw["fCosto"] = CostoUnitario;
                Drw["Descripcion"] = "(" + dtMatPrima.Rows[0]["vchCodigo"].ToString() + ") - " + dtMatPrima.Rows[0]["vchDescripcion"].ToString();
                Drw["Medida"] = Medida;
                Drw["Cantidad"] = Classes.Class_Session.fNewExistencia;
                dtListaProd.Rows.Add(Drw);
                CargaCarrito();
            }
        }
        void iniciaTabla()
        {
        
                dtListaCom = new DataTable();
                dtListaCom.Columns.Add("No", System.Type.GetType("System.String"));
                dtListaCom.Columns.Add("Categoria", System.Type.GetType("System.String"));
                dtListaCom.Columns.Add("Descripcion", System.Type.GetType("System.String"));
               
                dtListaCom.Columns.Add("iidUnidad", System.Type.GetType("System.String"));
               
                dtListaCom.Columns.Add("fCosto", System.Type.GetType("System.String"));
                dtListaCom.Columns.Add("Medida", System.Type.GetType("System.String"));
                dtListaCom.Columns.Add("Cantidad", System.Type.GetType("System.String"));
                dtListaCom.Columns.Add("Definido", System.Type.GetType("System.String"));

                dtListaCom.Columns["Medida"].ReadOnly = true;
                dtListaCom.Columns["Definido"].ReadOnly = true;



                dtListaCom.Columns["No"].AutoIncrement = true;
        
        
        }

        private void AgregaproductoCombo()
        {
            bool definido = Classes.Class_Session.isDefinido;
            Classes.Class_Session.isDefinido = false;
            if (definido)
            {
                DataTable dtProduc = ClsProducto.getListaProductodef(Classes.Class_Session.Idproducto);
                if (dtProduc.Rows.Count > 0)
                {

                    // double CostoPz = Convert.ToDouble(dtMatPrima.Rows[0]["fPrecio"].ToString());
                    //double CostoUnitario = Convert.ToDouble(dtMatPrima.Rows[0]["fCosto"].ToString());
                    // string iidUnidad = dtMatPrima.Rows[0]["iidUnidad"].ToString();
                    // int contenido = Convert.ToInt32(dtMatPrima.Rows[0]["fContenido"].ToString());
                    //  string Medida = dtMatPrima.Rows[0]["vchNombre"].ToString();


                    DataRow Drw = dtListaCom.NewRow();


                    Drw["Categoria"] = Classes.Class_Session.Idproducto;
                    Drw["Descripcion"] = dtProduc.Rows[0]["vchDescripcion"].ToString();
                    Drw["Cantidad"] = Classes.Class_Session.fCantidad.ToString();


                    Drw["iidUnidad"] = "1";
                    Drw["fCosto"] = dtProduc.Rows[0]["fcosto"].ToString();

                    Drw["Medida"] = "Unidad";
                    Drw["Definido"] = "SI";
                    dtListaCom.Rows.Add(Drw);
                    dataGridView_MateriaPrima.DataSource = dtListaCom;

                    dataGridView_MateriaPrima.Columns["fCosto"].Visible = false;
                    dataGridView_MateriaPrima.Columns["iidUnidad"].Visible = false;
                    dataGridView_MateriaPrima.Columns["Categoria"].Visible = false;

                }
            }
                else
                {
                    DataTable dtProductos = ClsProducto.getListacombo(Classes.Class_Session.Idproducto);
                    if (dtProductos.Rows.Count > 0)
                    {
                        try
                        {

                            DataTable dtMatPrima = ClsMateriaPrima.getLista(" AND M.iidCategoriaMateriPrima = " + dtProductos.Rows[0]["iidCategoriaMateriPrima"].ToString());
                            if (dtMatPrima.Rows.Count > 0)
                            {
                                double CostoPz = Convert.ToDouble(dtMatPrima.Rows[0]["fCosto"].ToString());
                                double CostoUnitario = Convert.ToDouble(dtMatPrima.Rows[0]["fCosto"].ToString());
                                string iidUnidad = dtMatPrima.Rows[0]["iidUnidad"].ToString();
                                int contenido = Convert.ToInt32(dtMatPrima.Rows[0]["fContenido"].ToString());
                                string Medida = dtMatPrima.Rows[0]["vchNombre"].ToString();
                                if (dtMatPrima.Rows[0]["vchNombre"].ToString() == "Litros")
                                {
                                    Medida = "Mililitros";
                                    CostoUnitario = CostoPz / 1000;
                                    iidUnidad = "5";
                                }
                                else
                                {
                                    if (dtMatPrima.Rows[0]["vchNombre"].ToString() == "Kilos")
                                    {
                                        Medida = "Gramos";
                                        CostoUnitario = CostoPz / contenido;
                                        iidUnidad = "3";
                                    }

                                    if (dtMatPrima.Rows[0]["vchNombre"].ToString() == "Pieza")
                                    {
                                        Medida = "Pieza";
                                        CostoUnitario = CostoPz / contenido;
                                        iidUnidad = "4";
                                    }
                                }


                                DataRow Drw = dtListaCom.NewRow();


                                Drw["Categoria"] = dtProductos.Rows[0]["iidCategoriaMateriPrima"].ToString();
                                Drw["Descripcion"] = dtProductos.Rows[0]["vchDescripcion"].ToString();
                                Drw["Cantidad"] = Classes.Class_Session.fCantidad.ToString();


                                Drw["iidUnidad"] = iidUnidad;
                                Drw["fCosto"] = CostoUnitario;

                                Drw["Medida"] = Medida;
                                Drw["Definido"] = "NO";
                                dtListaCom.Rows.Add(Drw);
                                dataGridView_MateriaPrima.DataSource = dtListaCom;

                                dataGridView_MateriaPrima.Columns["fCosto"].Visible = false;
                                dataGridView_MateriaPrima.Columns["iidUnidad"].Visible = false;
                                dataGridView_MateriaPrima.Columns["Categoria"].Visible = false;



                            }






                        }
                        catch (Exception e)
                        {
                            MessageBox.Show(e.ToString());

                        }
                    }
                }


            }
        
        
      

        private void dataGridView_MateriaPrima_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ShowTotals();
            /*try
            {
                CostoTotal = 0;
                foreach (DataRow Row in dtListaProd.Rows)
                {
                    double Cantidad = Convert.ToDouble(Row["Cantidad"].ToString());
                    double fCosto = Convert.ToDouble(Row["fCosto"].ToString());
                    CostoTotal += Math.Round(Cantidad * fCosto, 2);
                }
                label_FCosto.Text = string.Format("{0:c}", CostoTotal);

                CalculaUtilidad();
            }
            catch { }*/
        }

        private void dataGridView_MateriaPrima_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            ShowTotals();
            /*try
            {
                CostoTotal = 0;
                foreach (DataRow Row in dtListaProd.Rows)
                {
                    double Cantidad = Convert.ToDouble(Row["Cantidad"].ToString());
                    double fCosto = Convert.ToDouble(Row["fCosto"].ToString());
                    CostoTotal += Math.Round(Cantidad * fCosto, 2);
                }
                label_FCosto.Text = string.Format("{0:c}", CostoTotal);

                CalculaUtilidad();
            }
            catch { }*/
        }

        private void dataGridView_MateriaPrima_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*CostoTotal = 0;
            foreach (DataRow Row in dtListaProd.Rows)
            {
                double Cantidad = Convert.ToDouble(Row["Cantidad"].ToString());
                double fCosto = Convert.ToDouble(Row["fCosto"].ToString());
                CostoTotal += Math.Round(Cantidad * fCosto, 2);
            }
            label_FCosto.Text = string.Format("{0:c}", CostoTotal);

            CalculaUtilidad();*/
        }

        private void dataGridView_MateriaPrima_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_MateriaPrima.Rows[e.RowIndex];
                string iidMateriPrima = row.Cells["iidMateriPrima"].Value.ToString();

                for (int i = dtListaProd.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dtListaProd.Rows[i];
                    if (dr["iidMateriPrima"].ToString() == iidMateriPrima)
                        dr.Delete();
                }
                
                CargaCarrito();
            }
            }
            catch (Exception)
            {


            }
        }
        private void CalculaUtilidad()
        {
            if (LoadComplete)
            {
                try
                {
                    if (!checkBox_FijarEnelProducto.Checked)
                    {
                        CostoTotal = 0;
                        try
                        {
                            CostoTotal = Convert.ToDouble(textBox_Costo.Text);
                        }
                        catch {
                            return;
                        }
                    }


                    double Precio = 0;
                    if (textBox_Precio.Text.Trim() != "")
                    {
                        try
                        {
                            Precio = Convert.ToDouble(textBox_Precio.Text.Trim());
                        }
                        catch { }
                    }

                    double MontoUtilidad = Precio - CostoTotal;
                    double Porcentaje = (MontoUtilidad / CostoTotal) * 100;
                    label_Utilidad.Text = Math.Round(Porcentaje, 2) + " % Utilidad";
                }
                catch
                { }
            }
        }
        private void textBox_Costo_TextChanged(object sender, EventArgs e)
        {
            CalculaUtilidad();
        }

        private void button_CodigoSat_Click(object sender, EventArgs e)
        {
            Classes.Class_Session.Idtmp = "";
            Formularios.SAT.Form_BuscaCodigoProd formSat = new SAT.Form_BuscaCodigoProd();
            formSat.ShowDialog();
            if (Classes.Class_Session.Idtmp != "")
            {
                DataTable DtInfo = ClsProductoSat.getListaWhere(" WHERE vchCodigo = '" + Classes.Class_Session.Idtmp + "'");
                if (DtInfo.Rows.Count > 0)
                {
                    button_CodigoSat.Text = Classes.Class_Session.Idtmp + " - " + DtInfo.Rows[0]["vchNombre"].ToString();
                    button_CodigoSat.Tag = Classes.Class_Session.Idtmp;
                }
            }
        }

        private void button_MedidaSat_Click(object sender, EventArgs e)
        {
            Classes.Class_Session.IdBuscador = 0;

            Formularios.Form_Buscar form = new Formularios.Form_Buscar("Medida SAT");
            form.ShowDialog();

            if (Classes.Class_Session.IdBuscador != 0)
            {
                DataTable DtInfo = ClsMedidaSat.getListaWhere(" WHERE iidUnidadMedida = " + Classes.Class_Session.IdBuscador);
                if (DtInfo.Rows.Count > 0)
                {
                    button_MedidaSat.Text = DtInfo.Rows[0]["vchClave"].ToString() + " - " + DtInfo.Rows[0]["vchNombre"].ToString();
                    button_MedidaSat.Tag = DtInfo.Rows[0]["vchClave"].ToString();
                }
            }
        }

        private void textBox_Precio_TextChanged(object sender, EventArgs e)
        {
            CalculaUtilidad();
        }

        private void checkBox_FijarEnelProducto_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_FijarEnelProducto.Checked)
                textBox_Costo.Enabled = false;
            else
                textBox_Costo.Enabled = true;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void button_borrar_Click(object sender, EventArgs e)
        {
            dtListaCom.Clear();
                dtListaProd.Clear();
            dataGridView_MateriaPrima.DataSource = null;
        }

        private void boton_buscar_Click(object sender, EventArgs e)
        {

            int isCombo;
            DataTable dt = ClsProducto.isCombo(IdPassText);
            try
            {
                isCombo = Convert.ToInt32(dt.Rows[0]["isCombo"]);

            }
            catch (Exception)
            {

                isCombo = 0;
            }

            if (isCombo == 1)
            {
                Formularios.Catalogos.Form_Armarcombo frm = new Formularios.Catalogos.Form_Armarcombo();
                frm.AgregaproductoCombo += new Form1.MessageHandler(AgregaproductoCombo);
                frm.ShowDialog();


            }
            else
            {

                Classes.Class_Session.MateriaPrima = "";
                Classes.Class_Session.fNewExistencia = 0;
                Formularios.Form_AgregarMateriaPrima frm = new Formularios.Form_AgregarMateriaPrima();
                frm.AgregaTempMateriaPrima += new Form1.MessageHandler(AgregaTempMateriaPrima);
                frm.ShowDialog();


            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Formularios.Form_DefinirProducto frm =new Formularios.Form_DefinirProducto();
            frm.AgregaproductoCombo += new Form1.MessageHandler(AgregaproductoCombo);
            frm.ShowDialog();

        }

       

        

        
    }
}
