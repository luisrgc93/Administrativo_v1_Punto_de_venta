using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aejw.Network;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace FLXDSK.Formularios.Catalogos.Mercancia
{
    public partial class Form_Productos : Form
    {
        string idproducto = "";
        string imagenName = "";
        string rutaOriginal = "";
        string idAlmacen = "";
        string maximoPermitido = "";
        string idAlmacenMP = "";
        string accion = "";
        string esPieza = "";
        double costo = 0;
        double totalCantidad = 0;
        int i = 1;
        string imagen = "";

        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();

        Classes.Catalogos.Mercancia.Class_Productos ClsPro = new Classes.Catalogos.Mercancia.Class_Productos();
        Classes.Catalogos.Mercancia.Class_Categorias ClsCat = new Classes.Catalogos.Mercancia.Class_Categorias();
        Classes.Class_Composicion fnComposicion = new Classes.Class_Composicion();


        Classes.SAT.Class_Divisas ClsDiv = new Classes.SAT.Class_Divisas();
                
        Classes.Catalogos.Class_Paquete fnPaquete = new Classes.Catalogos.Class_Paquete();
        Classes.Inventarios.Class_Almacen fnAlmacen = new Classes.Inventarios.Class_Almacen();
        Classes.Internos.Class_Unidad ClsUnidad = new Classes.Internos.Class_Unidad();


        DataGridViewTextBoxColumn titleColumn;
        DataGridViewButtonColumn buttonColumn;
        DataGridViewComboBoxColumn comboboxColumn;
        DataGridViewComboBoxColumn ColumnMonth;


        DataTable Info;
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();
        public event Form1.MessageHandler CargaLista;

        public Form_Productos(string temp, string temp2)
        {
            InitializeComponent();
            idproducto = temp;
            accion = temp2;
        }
        public void LlenadoCategorias()
        {
            DataTable dtCatagorias = ClsCat.getCategoriasAll();
            comboBox_categorias.DataSource = dtCatagorias;
            comboBox_categorias.DisplayMember = "nombre";
            comboBox_categorias.ValueMember = "id";
        }
        public void llenarCombos()
        {
            LlenadoCategorias();

            DataTable dtDivisas = ClsDiv.getListaWhere(" WHERE iidEstatus = 1 ");
            comboBox_divisas.DataSource = dtDivisas;
            comboBox_divisas.DisplayMember = "vchNombre";
            comboBox_divisas.ValueMember = "iidDivisa";

            DataTable dtAlmacen = fnAlmacen.getAlmacenesAll();
            comboBox_Almacen.DataSource = dtAlmacen;
            comboBox_Almacen.DisplayMember = "nombre";
            comboBox_Almacen.ValueMember = "id";
           
            
            DataTable dtUnidades = ClsUnidad.GetUnidadesSinPieza();
            comboBox_Unidad.DataSource = dtUnidades;
            comboBox_Unidad.DisplayMember = "nombre";
            comboBox_Unidad.ValueMember = "id";


        }

        public void LlenadoCombos()
        {
            DataTable dtTipos = null;// fnComposicion.GetTiposAll();
            comboBox_Tipo.DataSource = dtTipos;
            comboBox_Tipo.DisplayMember = "nombre";
            comboBox_Tipo.ValueMember = "id";

            DataTable Tipo = new DataTable("Tipo");
            Tipo.Columns.Add("Tipo");
            Tipo.Columns.Add("idTipo");

            DataRow drP;
            drP = Tipo.NewRow();
            drP[1] = "0";
            drP[0] = "Seleccionar";
            Tipo.Rows.Add(drP);
            drP = Tipo.NewRow();
            drP[1] = "1";
            drP[0] = "Comida";
            Tipo.Rows.Add(drP);
            drP = Tipo.NewRow();
            drP[1] = "2";
            drP[0] = "Bebida";
            Tipo.Rows.Add(drP);

            comboBox_NombreTipo.DataSource = Tipo;
            comboBox_NombreTipo.DisplayMember = "Tipo";
            comboBox_NombreTipo.ValueMember = "idTipo";
        }
        private void pictureBox_producto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox_producto.Image = Image.FromFile(dialog.FileName);
                rutaOriginal = dialog.FileName;
                imagenName = Path.GetFileName(dialog.FileName);
            }
        }

        private void Form_Productos_Load(object sender, EventArgs e)
        {
            dateTimePicker_inicio.Format = DateTimePickerFormat.Custom;
            dateTimePicker_inicio.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker_fin.Format = DateTimePickerFormat.Custom;
            dateTimePicker_fin.CustomFormat = "dd/MM/yyyy HH:mm";

            label_Leyenda.Text = "";
            llenarCombos();
            LlenadoCombos();
            formatoGrid();
            formatoGridPaquete();

            if (accion == "compras")
            {
                comboBox_Unidad.SelectedIndex = 2;
                comboBox_Unidad.Enabled = false;                                
            }

            if (idproducto != "")
            {
                CargaListaPaquete();
                CargaListaMP();
                getInfoProductos();
            }
            else
            {
                EnableTab(tabPage2, false);
                EnableTab(tabPage3, false);
            }
            if (pictureBox_producto.Image == null)
            {
                pictureBox_producto.Image = Image.FromFile(@"img\sin_imagen.png");
            }
        }

        
        public static void EnableTab(TabPage page, bool enable)
        {
            foreach (Control ctl in page.Controls) ctl.Enabled = enable;
        }


        /*-------------------------------- Datagridviews para paquete y compuestos --------------------------*/
        private void formatoGrid()
        {
            dataGridView_MateriaPrima.Columns["dataGridViewTextBoxColumn1"].Width = 90;
            dataGridView_MateriaPrima.Columns["dataGridViewTextBoxColumn2"].Width = 250;
            dataGridView_MateriaPrima.Columns["Column1"].Width = 300;
            dataGridView_MateriaPrima.Columns["dataGridViewTextBoxColumn1"].ReadOnly = true;
            dataGridView_MateriaPrima.Columns["dataGridViewTextBoxColumn2"].ReadOnly = true;
            dataGridView_MateriaPrima.Columns["Column1"].ReadOnly = true;
            dataGridView_MateriaPrima.Columns["dataGridViewTextBoxColumn1"].Visible = false;
            dataGridView_MateriaPrima.Columns["dataGridViewTextBoxColumn2"].Visible = false;

            if (!dataGridView_MateriaPrima.Columns.Contains("Accion"))
            {
                buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Name = "Accion";
                buttonColumn.HeaderText = "Accion";
                buttonColumn.Width = 80;
                buttonColumn.FillWeight = 40;

                dataGridView_MateriaPrima.Columns.Insert(0, buttonColumn);
            }

            if (!dataGridView_MateriaPrima.Columns.Contains("Tipo"))
            {
                comboboxColumn = CreateComboBoxColumn();

                DataTable dtTipos = null;// fnComposicion.GetTiposAll();
                comboboxColumn.DataSource = dtTipos;
                comboboxColumn.DisplayMember = "nombre";
                comboboxColumn.ValueMember = "id";
                dataGridView_MateriaPrima.Columns.Insert(4, comboboxColumn);
            }

            if (!dataGridView_MateriaPrima.Columns.Contains("Cantidad"))
            {
                titleColumn = new DataGridViewTextBoxColumn();
                titleColumn.Name = "Cantidad";
                titleColumn.HeaderText = "Cantidad";
                titleColumn.Width = 80;
                titleColumn.FillWeight = 40;

                dataGridView_MateriaPrima.Columns.Insert(6, titleColumn);
            }

        }
        private void formatoGridPaquete()
        {
            dataGridView4.Columns["iidPaquete"].Width = 90;
            dataGridView4.Columns["iidProducto"].Width = 90;
            dataGridView4.Columns["Nombre"].Width = 350;
            dataGridView4.Columns["Nombre"].ReadOnly = true;

            if (!dataGridView4.Columns.Contains("Accion"))
            {
                buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Name = "Accion";
                buttonColumn.HeaderText = "Accion";
                buttonColumn.Width = 80;
                buttonColumn.FillWeight = 40;

                dataGridView4.Columns.Insert(0, buttonColumn);
            }

            if (!dataGridView4.Columns.Contains("Almacen"))
            {

                ColumnMonth = new DataGridViewComboBoxColumn();
                DataTable dtAlmacenMP = new DataTable();
                dtAlmacenMP = ClsCat.getAlmacenProductoMateriaPrima();

                ColumnMonth.DataSource = dtAlmacenMP;
                ColumnMonth.DisplayMember = "nombre";
                ColumnMonth.ValueMember = "id";
                ColumnMonth.HeaderText = "Almacen";

                dataGridView4.Columns.Insert(4, ColumnMonth);
            }

            if (!dataGridView4.Columns.Contains("Cantidad"))
            {
                titleColumn =
                new DataGridViewTextBoxColumn();
                titleColumn.Name = "Cantidad";
                titleColumn.HeaderText = "Cantidad";
                titleColumn.Width = 80;
                titleColumn.FillWeight = 40;
                titleColumn.ReadOnly = false;

                dataGridView4.Columns.Insert(5, titleColumn);
            }
        }
        private DataGridViewComboBoxColumn CreateComboBoxColumn()
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            {
                column.DataPropertyName = "tipo";
                column.HeaderText = "Tipo";
                column.DropDownWidth = 160;
                column.Width = 120;
            }
            return column;
        }

        
        public void getInfoProductos()
        {            
            DataTable Tabla_productos = ClsPro.getListaWhere(" WHERE iidProducto = " + idproducto);
            if (Tabla_productos.Rows.Count == 0)
            {
                MessageBox.Show("Informacion no encontrada");
                this.Close();
                return;
            }

            DataRow row = Tabla_productos.Rows[0];

            textBox_codigo.Text = row["vchCodigo"].ToString();
            textBox_Descripcion.Text = row["vchDescripcion"].ToString();
            textBox_Precio.Text = row["fPrecio"].ToString();
            textBox_Unidad.Text = row["vchUnidad"].ToString();
            textBox_Stock.Text = row["fStockMinimo"].ToString();

            string unidad = row["iidUnidad"].ToString();
            string idcategoria = row["iidCategoria"].ToString();
            string iddivisa = row["iidDivisa"].ToString();
            
            string costo = row["fCosto"].ToString();
            string dfechaActivo = row["dfechaActivo103"].ToString();
            string dfechaVence = row["dfechaVence103"].ToString();

            
            comboBox_Unidad.Enabled = false;
            comboBox_Unidad.SelectedValue = unidad;
            comboBox_categorias.SelectedValue = idcategoria;
            comboBox_divisas.SelectedValue = iddivisa;


            if (row["siIVA"].ToString() == "1")
                checkBox_siIVA.Checked = true;
            else
                checkBox_siIVA.Checked = false;



            string iidAlmacen = "";
            if (row["iidAlmacen"].ToString() != "")
                iidAlmacen = row["iidAlmacen"].ToString();
            else
                iidAlmacen = "0";

            if (row["iNumMesasPermitidas"].ToString() != "")
                maximoPermitido = row["iNumMesasPermitidas"].ToString();
            
            
            
            try
            {
                comboBox_NombreTipo.SelectedValue = row["siComida"].ToString();
            }
            catch { }
            
            
            try
            {
                byte[] dibujoByteArray = (byte[])row["IFileImagen"];
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


            try
            {
                comboBox_Almacen.SelectedValue = iidAlmacen;
            }
            catch { }

            if (maximoPermitido == "") { maximoPermitido = "0"; }
            textBox_Maximo.Text = maximoPermitido;
            
            textBox_Costo.Text = costo.ToString();
            //textBox_Costo.ReadOnly = true;
            
            if (dfechaActivo != "" && dfechaVence != "")
            {
                checkBox_Paquete.Visible = true;
                checkBox_Paquete.Checked = true;
                checkBox_Paquete.Enabled = false;
                DateTime ini = Convert.ToDateTime(dfechaActivo);
                DateTime fin = Convert.ToDateTime(dfechaVence);
                dateTimePicker_fin.Value = fin;
                dateTimePicker_inicio.Value = ini;
                dateTimePicker_inicio.Enabled = false;
                dateTimePicker_fin.Enabled = false;
            }
            else
            {
                checkBox_Paquete.Visible = false;
                checkBox_Paquete.Checked = false;
            }

            if (unidad == "1") { EnableTab(tabPage3, false); } //si es compuesto desbloqueamos el tab            
            if (unidad == "3") { EnableTab(tabPage2, false); } //si es compuesto desbloqueamos el tab

            if (comboBox_Unidad.SelectedValue.ToString() == "1") { label_Maximo.Visible = false; textBox_Maximo.Visible = false; label_Leyenda.Text = "Platillo o Bebida compuesta por diferente materia prima."; }
            if (comboBox_Unidad.SelectedValue.ToString() == "3") 
            { 
                label_Leyenda.Text = "Paquete que se compone de diferentes productos.";
                textBox_Maximo.Visible = true;
                label_Maximo.Visible = true;
                if (dfechaActivo != "" && dfechaVence != "")
                {
                    if (!fnPaquete.aunNoCaducaPaquete(idproducto))
                    {
                        EnableTab(tabPage3, false);
                    }
                }
            }


            
            try
            {
                //imagen = row["vchRutaImg"].ToString();
            }
            catch
            {}

            if (imagen != "")
            {
                //pictureBox_producto.Image = Image.FromFile(@imagen);
            }
        }




        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void textBox_Precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool punto_decimales = false;
            int cantidad_decimales = 0;

            for (int i = 0; i < textBox_Precio.Text.Length; i++)
            {
                if (textBox_Precio.Text[i] == '.')
                    punto_decimales = true;

                if (punto_decimales && cantidad_decimales++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (punto_decimales) ? true : false;
            else
                e.Handled = true;
        }

        private void CreateFolder(string ruta)
        {
            bool isExists = System.IO.Directory.Exists(ruta);
            if (!isExists)
                System.IO.Directory.CreateDirectory(ruta);
        }

        private void button_Cancelar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        
        
        private void button_Guardar_Click_1(object sender, EventArgs e)
        {
            string codigo = textBox_codigo.Text;
            string descripcion = textBox_Descripcion.Text;
            string precio = textBox_Precio.Text;
            string unidad = textBox_Unidad.Text;

            string idcategoria = "";
            string iddivisa = "";
            string idUnida = "";
            string NombreTipo="";
            try
            {
                idcategoria = comboBox_categorias.SelectedValue.ToString();
                iddivisa = comboBox_divisas.SelectedValue.ToString();
                idUnida = comboBox_Unidad.SelectedValue.ToString();
                NombreTipo = comboBox_NombreTipo.SelectedValue.ToString();
            }
            catch { }
            
            
            string stock = "";
            string idAlmacen = comboBox_Almacen.SelectedValue.ToString();
            
            if (idUnida == "2") { stock = textBox_Stock.Text; }            
            if (textBox_Costo.Text == "") { costo = 0; }           
            else { costo = Convert.ToDouble(textBox_Costo.Text); }

            string siIVA = "0";
            if(checkBox_siIVA.Checked)
                siIVA = "1";
            


            if (codigo == "" || descripcion == "" || idUnida == "0" || precio == "")
            {
                MessageBox.Show("Favor de llenar los campos requeridos");
                return;
            }

            if (idcategoria == "0" || iddivisa == "0" || NombreTipo == "0")
            {
                MessageBox.Show("Favor de seleccionar los campos requeridos");
                return;
            }
            if (idAlmacen == "" || idAlmacen == "0")
            {
                MessageBox.Show("Seleccione un almacen");
                return;
            }


            if (idUnida == "3")
            {
                //-------------------------------------- Insertar o Actualizar Paquete --------------------------------------------
                if (checkBox_Paquete.Checked == true)
                {
                    string[] varI = dateTimePicker_inicio.Text.Split('/', ' ', ':');
                    string inicio = varI[2] + "-" + varI[1] + "-" + varI[0] + "T" + varI[3] + ":" + varI[4] + ":00";

                    string[] varF = dateTimePicker_fin.Text.Split('/', ' ', ':');
                    string final = varF[2] + "-" + varF[1] + "-" + varF[0] + "T" + varF[3] + ":" + varF[4] + ":00";

                    DateTime ini = Convert.ToDateTime(inicio);
                    DateTime fin = Convert.ToDateTime(final);
                    DateTime fechaActual = DateTime.Now;

                    if (ini > fin)
                    {
                        MessageBox.Show("La fecha final no pude ser menor a la inicial.");
                        return;
                    }

                    Info = new DataTable();
                    DataRow row;

                    Info.Columns.Add("idProducto", System.Type.GetType("System.String"));
                    Info.Columns.Add("codigo", System.Type.GetType("System.String"));
                    Info.Columns.Add("descripcion", System.Type.GetType("System.String"));
                    Info.Columns.Add("unidad", System.Type.GetType("System.String"));
                    Info.Columns.Add("precio", System.Type.GetType("System.String"));
                    Info.Columns.Add("siIVA", System.Type.GetType("System.String"));
                    Info.Columns.Add("divisa", System.Type.GetType("System.String"));
                    Info.Columns.Add("categoria", System.Type.GetType("System.String"));
                    Info.Columns.Add("fechaInicia", System.Type.GetType("System.String"));
                    Info.Columns.Add("fechaVence", System.Type.GetType("System.String"));
                    Info.Columns.Add("imagen", System.Type.GetType("System.String"));
                    Info.Columns.Add("costo", System.Type.GetType("System.String"));
                    Info.Columns.Add("maximo", System.Type.GetType("System.String"));
                    Info.Columns.Add("tipo", System.Type.GetType("System.String"));
                    Info.Columns.Add("unidadfac", System.Type.GetType("System.String"));

                    row = Info.NewRow();
                    row["idProducto"] = idproducto;
                    row["codigo"] = codigo;
                    row["descripcion"] = descripcion;
                    row["unidad"] = idUnida;
                    row["precio"] = precio;
                    row["siIVA"] = siIVA;
                    row["divisa"] = iddivisa;
                    row["categoria"] = idcategoria;
                    row["fechaInicia"] = inicio;
                    row["fechaVence"] = final;
                    row["costo"] = costo;
                    row["maximo"] = textBox_Maximo.Text;
                    row["tipo"] = comboBox_NombreTipo.SelectedValue.ToString();
                    row["unidadfac"] = unidad;
                    row["imagen"] = GetImagen();
                    Info.Rows.Add(row);

                    if (idproducto == "")
                    {
                        DataTable dtExist = ClsPro.getListaWhere(" WHERE vchCodigo = '"+codigo+"' AND iidEstatus = 1 ");
                        if (dtExist.Rows.Count > 0)
                        {
                            MessageBox.Show("El codigo que desea registrar ya existe");
                            return;
                        }

                        /*if (ClsPro.InsertaInformacion(Info))
                        {
                            MessageBox.Show("Guardado con exito");
                            idproducto = ClsPro.getIdProducto();
                            getInfoProductos();
                            if (idUnida == "1") { this.tabControl1.SelectedTab = tabPage2; } //si es compuesto desbloqueamos el tab
                            if (idUnida == "3") { this.tabControl1.SelectedTab = tabPage3; CargaListaPaquete(); } //si es compuesto desbloqueamos el tab
                            try{
                            CargaLista();
                            }catch{}
                            //this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Problemas al guardar");
                            return;
                        }*/
                        
                    }
                    else
                    {
                        if (ClsPro.ActualizaInformacion(Info, "paquete"))
                        {
                            MessageBox.Show("Producto actualizado con exito");
                            /*idproducto = ClsPro.getIdProducto();
                            getInfoProductos();
                            if (idUnida == "1") { this.tabControl1.SelectedTab = tabPage2; } //si es compuesto desbloqueamos el tab
                            if (idUnida == "3") { this.tabControl1.SelectedTab = tabPage3; CargaListaPaquete(); } //si es paquete desbloqueamos el tab
                            try
                            {
                                CargaLista();
                            }
                            catch { }*/
                        }
                        else
                        {
                            MessageBox.Show("Problemas al actualizar el prducto");
                            return;
                        }
                    }
                }
                else
                {                    
                    Info = new DataTable();
                    DataRow row;

                    Info.Columns.Add("idProducto", System.Type.GetType("System.String"));
                    Info.Columns.Add("codigo", System.Type.GetType("System.String"));
                    Info.Columns.Add("descripcion", System.Type.GetType("System.String"));
                    Info.Columns.Add("unidad", System.Type.GetType("System.String"));
                    Info.Columns.Add("precio", System.Type.GetType("System.String"));
                    Info.Columns.Add("siIVA", System.Type.GetType("System.String"));
                    Info.Columns.Add("divisa", System.Type.GetType("System.String"));
                    Info.Columns.Add("categoria", System.Type.GetType("System.String"));
                    Info.Columns.Add("imagen", System.Type.GetType("System.Byte[]"));
                    Info.Columns.Add("costo", System.Type.GetType("System.String"));
                    Info.Columns.Add("maximo", System.Type.GetType("System.String"));
                    Info.Columns.Add("tipo", System.Type.GetType("System.String"));
                    Info.Columns.Add("unidadfac", System.Type.GetType("System.String"));
                    Info.Columns.Add("stock", System.Type.GetType("System.String"));
                    Info.Columns.Add("almacen", System.Type.GetType("System.String"));
                    
                    row = Info.NewRow();
                    row["idProducto"] = idproducto;
                    row["codigo"] = codigo;
                    row["descripcion"] = descripcion;
                    row["unidad"] = idUnida;
                    row["precio"] = precio;
                    row["siIVA"] = siIVA;
                    row["divisa"] = iddivisa;
                    row["categoria"] = idcategoria;
                    row["costo"] = costo;
                    row["maximo"] = textBox_Maximo.Text;
                    row["tipo"] = comboBox_NombreTipo.SelectedValue.ToString();
                    row["unidadfac"] = unidad;
                    row["stock"] = "0";
                    row["almacen"] = "0";
                    row["imagen"] = GetImagen();
                    Info.Rows.Add(row);


                    if (idproducto == "")
                    {
                        DataTable dtExis = ClsPro.getListaWhere(" WHERE vchCodigo = '" + codigo + "' AND iidEstatus = 1 ");
                        if (dtExis.Rows.Count > 0)
                        {
                            MessageBox.Show("El codigo que desea registrar ya existe");
                            return;
                        }


                        if (ClsPro.InsertaInformacion(Info))
                        {
                            MessageBox.Show("Guardado con exito");
                            /*idproducto = ClsPro.getIdProducto();
                            getInfoProductos();
                            if (idUnida == "1") { this.tabControl1.SelectedTab = tabPage2; } //si es compuesto desbloqueamos el tab
                            if (idUnida == "3") { this.tabControl1.SelectedTab = tabPage3; CargaListaPaquete(); } //si es compuesto desbloqueamos el tab
                            try
                            {
                                CargaLista();
                            }
                            catch { }
                            //this.Close();*/
                        }
                        else
                        {
                            MessageBox.Show("Problemas al guardar");
                            return;
                        }
                        
                    }
                    else
                    {
                        if (ClsPro.ActualizaInformacion(Info, ""))
                        {
                            MessageBox.Show("Producto actualizado con exito");
                            /*idproducto = ClsPro.getIdProducto();
                            getInfoProductos();
                            if (idUnida == "1") { this.tabControl1.SelectedTab = tabPage2; } //si es compuesto desbloqueamos el tab
                            if (idUnida == "3") { this.tabControl1.SelectedTab = tabPage3; CargaListaPaquete(); } //si es paquete desbloqueamos el tab
                            try
                            {
                                CargaLista();
                            }
                            catch { }*/
                        }
                        else
                        {
                            MessageBox.Show("Problemas al actualizar el prducto");
                            return;
                        }
                    }
                
                }
            }
            else
            {
                //-------------------------------------- Insertar o Actualizar Pieza o Producto Compuesto --------------------------------------------
                Info = new DataTable();
                DataRow row;

                Info.Columns.Add("idProducto", System.Type.GetType("System.String"));
                Info.Columns.Add("codigo", System.Type.GetType("System.String"));
                Info.Columns.Add("descripcion", System.Type.GetType("System.String"));
                Info.Columns.Add("unidad", System.Type.GetType("System.String"));
                Info.Columns.Add("precio", System.Type.GetType("System.String"));
                Info.Columns.Add("siIVA", System.Type.GetType("System.String"));
                Info.Columns.Add("divisa", System.Type.GetType("System.String"));
                Info.Columns.Add("categoria", System.Type.GetType("System.String"));
                Info.Columns.Add("imagen", System.Type.GetType("System.Byte[]"));
                Info.Columns.Add("costo", System.Type.GetType("System.String"));
                Info.Columns.Add("maximo", System.Type.GetType("System.String"));
                Info.Columns.Add("tipo", System.Type.GetType("System.String"));
                Info.Columns.Add("unidadfac", System.Type.GetType("System.String"));
                Info.Columns.Add("stock", System.Type.GetType("System.String"));
                Info.Columns.Add("almacen", System.Type.GetType("System.String")); 
                row = Info.NewRow();

                row["idProducto"] = idproducto;
                row["codigo"] = codigo;
                row["descripcion"] = descripcion;
                row["unidad"] = idUnida;
                row["precio"] = precio;
                row["siIVA"] = siIVA;
                row["divisa"] = iddivisa;
                row["categoria"] = idcategoria;
                row["costo"] = costo;
                row["maximo"] = "0";
                row["tipo"] = comboBox_NombreTipo.SelectedValue.ToString();
                row["unidadfac"] = unidad;
                if (idAlmacen != "")
                {
                    row["almacen"] = idAlmacen;
                }
                else { row["almacen"] = "0"; }
                if (stock != "")
                {
                    row["stock"] = stock;
                }
                else { row["stock"] = "0"; }

                row["imagen"] = GetImagen();
                Info.Rows.Add(row);

                if (idproducto == "")
                {
                    DataTable dtExis = ClsPro.getListaWhere(" WHERE vchCodigo = '" + codigo + "' AND iidEstatus = 1 ");
                    if (dtExis.Rows.Count > 0)
                    {
                        MessageBox.Show("El codigo que desea registrar ya existe");
                        return;
                    }


                    if (ClsPro.InsertaInformacion(Info))
                    {
                        MessageBox.Show("Guardado con exito");
                        if (accion == "compras")
                        {
                            this.Close();
                        }
                        else
                        {
                            /*idproducto = ClsPro.getIdProducto();
                            getInfoProductos();
                            if (idUnida == "1") { this.tabControl1.SelectedTab = tabPage2; CargaListaMP(); } //si es compuesto desbloqueamos el tab
                            if (idUnida == "2") { EnableTab(tabPage2, false); EnableTab(tabPage3, false); } //si es pieza bloqueamos todo
                            if (idUnida == "3") { this.tabControl1.SelectedTab = tabPage3; } //si es compuesto desbloqueamos el tab
                            try
                            {
                                CargaLista();
                            }
                            catch { }*/
                        }
                    }
                    else
                    {
                        MessageBox.Show("Problemas al guardar");
                        return;
                    }
                   
                }
                else
                {
                    if (ClsPro.ActualizaInformacion(Info, ""))
                    {
                        MessageBox.Show("Producto actualizado con exito");
                        
                        getInfoProductos();
                        if (idUnida == "1") { this.tabControl1.SelectedTab = tabPage2; CargaListaMP(); } //si es compuesto desbloqueamos el tab
                        if (idUnida == "2") { EnableTab(tabPage2, false); EnableTab(tabPage3, false); } //si es pieza bloqueamos todo
                        if (idUnida == "3") { this.tabControl1.SelectedTab = tabPage3; } //si es paquete desbloqueamos el tab
                        try
                        {
                            CargaLista();
                        }
                        catch { }
                    }
                    else
                    {
                        MessageBox.Show("Problemas al actualizar el prducto");
                        return;
                    }
                }
            }
        }


        private byte[] GetImagen()
        {
            try
            {
                Image dibujo = new Bitmap( pictureBox_producto.Image);
                ImageConverter converter = new ImageConverter();
                return (byte[])converter.ConvertTo(dibujo, typeof(byte[]));
            }
            catch
            {
                return null;
            }
        }



        /// <summary>
        /// ////////////Composicion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Buscar_Click(object sender, EventArgs e)
        {
            if (idproducto != "")
            {
                /*Formularios.Form_AgregarMateriaPrima frm = new Formularios.Form_AgregarMateriaPrima(idproducto);
                frm.guar/darTempMateria_Prima += new Form1.MessageHandler(guardarTempMateria_Prima);
                frm.ShowDialog();*/
            }
            else
            {
                MessageBox.Show("Es necesario que este Seleccionado un producto");
                return;
            }
        }
        private void guardarTempMateria_Prima()
        {
            string nombreMateriaPrima = "";// fnComposicion.getNombreMatPrima(Classes.Class_Session.MateriaPrima);
            dataGridView_MateriaPrima.Rows.Add("Eliminar", idproducto, Classes.Class_Session.MateriaPrima, nombreMateriaPrima);
        }

        private void CargaListaMP()
        {
            /*if (fnComposicion.existeComposicion(idproducto))
            {
                dataGridView1.Visible = true;
                dataGridView_MateriaPrima.Visible = false;
                button_Buscar.Enabled = false;
                button_AgregarComposicion.Enabled = false;

                label_Composicion.Visible = false;
                string nombreMateriaPrima = "";// fnComposicion.getNombreMatPrima(Classes.Class_Session.MateriaPrima);
                label_Composicion.Text = nombreMateriaPrima;
                dataGridView1.DataSource = null;
                string sql = " select M.iidMateriPrima ID, M.vchCodigo Código, M.vchDescripcion Nombre, R.fCantidad Cantidad, U.vchNombre Tipo, A.vchNombre Almacen  " +
                             " from RelProductoMateriaprima R (NOLOCK), catProductos P (NOLOCK), catMateriaPrima M, catUnidadesMetricas U, catAlmacenes A  " +
                             " where R.iidProducto = P.iidProducto " +
                             " and R.iidMateriPrima = M.iidMateriPrima " +
                             " and R.iidUnidadMetrica = U.iidUnidad " +
                             " and R.iidAlmacen = A.iidAlmacen " +
                             " and R.iidProducto = " + idproducto;

                SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
                DataSet dstConsulta = new DataSet();
                try
                {
                    areas.Fill(dstConsulta, "Datos");
                    dataGridView1.DataSource = dstConsulta.Tables[0];

                    dataGridView1.Columns["ID"].Width = 80;
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["Codigo"].Width = 150;
                    dataGridView1.Columns["Codigo"].ReadOnly = true;
                    dataGridView1.Columns["Nombre"].Width = 200;
                    dataGridView1.Columns["Nombre"].ReadOnly = true;
                    dataGridView1.Columns["Cantidad"].Width = 100;
                    dataGridView1.Columns["Cantidad"].ReadOnly = true;
                    dataGridView1.Columns["Tipo"].Width = 100;
                    dataGridView1.Columns["Tipo"].ReadOnly = true;
                    dataGridView1.Columns["Almacen"].Width = 200;
                    dataGridView1.Columns["Almacen"].ReadOnly = true;
                }
                catch
                {
                }
                bs.DataSource = dataGridView1.DataSource;
            }
            else
            {
                dataGridView_MateriaPrima.Enabled = true;
                dataGridView1.Visible = false;
                dataGridView_MateriaPrima.Visible = true;
                button_Buscar.Enabled = true;
                button_AgregarComposicion.Enabled = true;
            }*/
        }

        
        private void comboBox_Unidad_SelectedValueChanged(object sender, EventArgs e)
        {
            label_Leyenda.Visible = true;
            if (comboBox_Unidad.SelectedValue.ToString() == "0") { label_Almacen.Visible = false; comboBox_Almacen.Visible = false; label_Stock.Visible = false; textBox_Stock.Visible = false; textBox_Costo.Text = ""; /*textBox_Costo.ReadOnly = true;*/ label_Leyenda.Text = ""; ocultarElementos(); checkBox_Paquete.Visible = false; checkBox_Paquete.Checked = false; }
            if (comboBox_Unidad.SelectedValue.ToString() == "1") { label_Almacen.Visible = false; comboBox_Almacen.Visible = false; label_Stock.Visible = false; textBox_Stock.Visible = false; textBox_Costo.Text = ""; /*textBox_Costo.ReadOnly = true;*/ label_Leyenda.Text = "Platillo o Bebida compuesta por diferente materia prima."; ocultarElementos(); checkBox_Paquete.Checked = false; checkBox_Paquete.Visible = false; }
            if (comboBox_Unidad.SelectedValue.ToString() == "2") { label_Almacen.Visible = true; comboBox_Almacen.Visible = true; label_Stock.Visible = true; textBox_Stock.Visible = true; /*textBox_Costo.ReadOnly = false;*/ label_Leyenda.Text = "Pieza."; ocultarElementos(); checkBox_Paquete.Visible = false; checkBox_Paquete.Checked = false; }
            if (comboBox_Unidad.SelectedValue.ToString() == "3") {
                textBox_Costo.Text = "";
                checkBox_Paquete.Visible = true;
                //textBox_Costo.ReadOnly = true;
                label_Maximo.Visible = true;
                textBox_Maximo.Visible = true;
                label_Stock.Visible = false;
                textBox_Stock.Visible = false;
                label_Almacen.Visible = false; 
                comboBox_Almacen.Visible = false;
            }
        }
        private void ocultarElementos()
        {
            label_Activo.Visible = false;
            label_Vence.Visible = false;
            dateTimePicker_fin.Visible = false;
            dateTimePicker_inicio.Visible = false;
            label_Maximo.Visible = false;
            textBox_Maximo.Visible = false;
        }

        private void button_AgregarComposicion_Click(object sender, EventArgs e)
        {            
            //-------------------------- Guardar la composicion del platillo o bebida -------------------------------
            DialogResult resultado;
            resultado = MessageBox.Show(@"Esta seguro de que son estos elementos, ya no podras agregar mas", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (DialogResult.OK == resultado)
            {                
                try
                {
                    foreach (DataGridViewRow row in dataGridView_MateriaPrima.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            idAlmacenMP = row.Cells[5].Value.ToString();

                            DataTable Info = new DataTable();
                            DataRow Drw;

                            Info.Columns.Add("idProducto", System.Type.GetType("System.String"));
                            Info.Columns.Add("fCantidad", System.Type.GetType("System.String"));
                            Info.Columns.Add("vchTipo", System.Type.GetType("System.String"));
                            Info.Columns.Add("idMateriaPrima", System.Type.GetType("System.String"));

                            Drw = Info.NewRow();
                            Drw["idProducto"] = row.Cells[1].Value.ToString();
                            Drw["fCantidad"] = row.Cells[6].Value.ToString();
                            Drw["vchTipo"] = row.Cells[4].Value.ToString();
                            Drw["idMateriaPrima"] = row.Cells[2].Value.ToString();
                            Info.Rows.Add(Drw);

                            //if (fnComposicion.GuardarRelProductoMateriaPrima(Info))
                            if(1==1)
                            {                                
                                try
                                {
                                    string PrecioCompra = "";// fnComposicion.getPrecioCompra(row.Cells[2].Value.ToString());
                                    string UnidadProductoCompra = "";// fnComposicion.getUnidadProductoCompra(row.Cells[2].Value.ToString());
                                    if (UnidadProductoCompra == "3" || UnidadProductoCompra == "5")
                                    {
                                        totalCantidad = Convert.ToDouble(PrecioCompra) * Convert.ToDouble(row.Cells[6].Value);
                                    }
                                    else
                                    {
                                        if (UnidadProductoCompra == "1" || UnidadProductoCompra == "6")
                                        {
                                            double precioPorPieza = Convert.ToDouble(PrecioCompra) / 1000;
                                            totalCantidad = precioPorPieza * Convert.ToDouble(row.Cells[6].Value);
                                        }
                                        if (UnidadProductoCompra == "2")
                                        {
                                            double precioPorPieza = Convert.ToDouble(PrecioCompra) / 29.574;
                                            totalCantidad = precioPorPieza * Convert.ToDouble(row.Cells[6].Value);
                                        }
                                    }

                                    /*if (fnComposicion.InsertNuevoCostoCompuesto(totalCantidad, row.Cells[1].Value.ToString()))
                                    {
                                        Classes.Class_Session.MateriaPrima = "";
                                        textBox_Cantidad.Text = "";
                                        CargaListaMP();
                                    }
                                    else { }*/
                                }
                                catch
                                { }
                            }
                            else
                            {
                                MessageBox.Show("Problema al Guardar");
                            }
                        }
                    }
                    dataGridView_MateriaPrima.Visible = false;
                    dataGridView1.Visible = true;
                    getInfoProductos();
                    CargaListaMP();
                }
                catch
                {
                }
            }

        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    dataGridView_MateriaPrima.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch { }
        }



        //--------------------------------------------- Formar Paquete ------------------------------------------------*/

        private void button_BuscarProductos_Click(object sender, EventArgs e)
        {
            string idPaquete = idproducto;
            if (idPaquete != "")
            {
                Formularios.Form_AgregarProducto frm = new Formularios.Form_AgregarProducto(idPaquete);
                frm.guardarProductosPaquete_Temp += new Form1.MessageHandler(guardarProductosPaquete_Temp);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Es necesario que este Seleccionado un Paquete");
                return;
            }
        }
        private void guardarProductosPaquete_Temp()
        {
            string nombreProducto = fnPaquete.getNombreProducto(Classes.Class_Session.producto);
            dataGridView4.Rows.Add("Eliminar",idproducto, Classes.Class_Session.producto, nombreProducto);            
        }
        private void CargaListaPaquete()
        {
           /*if (fnComposicion.existePaquete(idproducto))
            {
                dataGridView2.Visible = true;
                dataGridView4.Visible = false;
                button_BuscarProductos.Enabled = false;
                button_AgregarPaquete.Enabled = false;

                label_Producto.Visible = false;
                string nombreMateriaPrima = fnPaquete.getNombreProducto(Classes.Class_Session.producto);
                label_Producto.Text = nombreMateriaPrima;
                dataGridView2.DataSource = null;
                string sql = " select P.iidProducto ID, P.vchDescripcion Nombre, R.fCantidad Cantidad, U.vchNombre Unidad" +
                             " from RelPaqueteProducto R (NOLOCK), catProductos P (NOLOCK), catUnidadesProductos U " +
                             " where R.iidProducto = P.iidProducto " +
                             " and P.iidUnidad = U.iidUnidad " +
                             " and R.iidPaquete = " + idproducto;
                SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
                DataSet dstConsulta = new DataSet();
                try
                {
                    areas.Fill(dstConsulta, "Datos");
                    dataGridView2.DataSource = dstConsulta.Tables[0];

                    dataGridView2.Columns["ID"].Width = 40;
                    dataGridView2.Columns["ID"].Visible = false;
                    dataGridView2.Columns["Nombre"].Width = 100;
                    dataGridView2.Columns["Nombre"].ReadOnly = true;
                    dataGridView2.Columns["Cantidad"].Width = 50;
                    dataGridView2.Columns["Cantidad"].ReadOnly = true;
                    dataGridView2.Columns["Unidad"].Width = 80;
                    dataGridView2.Columns["Unidad"].ReadOnly = true;
                }
                catch
                {
                }
                bs.DataSource = dataGridView2.DataSource;
            }
            else
            {
                dataGridView4.Enabled = true;
                dataGridView2.Visible = false;
                dataGridView4.Visible = true;
                button_BuscarProductos.Enabled = true;
                button_AgregarPaquete.Enabled = true;
            }*/
        }

        private void button_AgregarPaquete_Click(object sender, EventArgs e)
        {
            DialogResult resultado;
            resultado = MessageBox.Show(@"Esta seguro de que son estos productos, ya no podras agregar mas", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (DialogResult.OK == resultado)
            {
                foreach (DataGridViewRow row in dataGridView4.Rows)
                {
                    if (!row.IsNewRow)
                    {       
                        int? fcantida = Convert.ToInt32(row.Cells[5].Value);
                        int? idAlmacenVal = Convert.ToInt32(row.Cells[4].Value);
                        if (fcantida == null || fcantida==0) { MessageBox.Show("Favor de ingresar una cantidad"); return; }
                        if (idAlmacenVal == null || idAlmacenVal == 0) { MessageBox.Show("Favor de seleccionar un almacen"); return; }
                        if (!fnPaquete.esplatillo(row.Cells[2].Value.ToString()))
                        {
                            /*if (fnPaquete.existeMinimoenunAlmacen(row.Cells[2].Value.ToString()))
                            {
                                if (!fnPaquete.existeenAlmacen(row.Cells[2].Value.ToString(), row.Cells[4].Value.ToString()))
                                {
                                    string nombreProducto = fnPaquete.getNombreProducto(row.Cells[2].Value.ToString());
                                    string nombreAlmacen = fnComposicion.getNombreAlmacen(row.Cells[4].Value.ToString());
                                    MessageBox.Show("No existe el producto " + nombreProducto + " en el almacen " + nombreAlmacen); return;
                                }
                                else
                                {
                                    idAlmacen = row.Cells[4].Value.ToString();
                                }
                            }
                            else { 
                                 */ idAlmacen = row.Cells[4].Value.ToString(); //}
                        }
                        else { idAlmacen = row.Cells[4].Value.ToString(); }                        

                        DataTable Info = new DataTable();
                        DataRow Drw;

                        Info.Columns.Add("idPaquete", System.Type.GetType("System.String"));
                        Info.Columns.Add("fCantidad", System.Type.GetType("System.String"));
                        Info.Columns.Add("idProducto", System.Type.GetType("System.String"));
                        Info.Columns.Add("idAlmacen", System.Type.GetType("System.String"));

                        Drw = Info.NewRow();
                        Drw["idPaquete"] = row.Cells[1].Value.ToString();
                        Drw["fCantidad"] = row.Cells[5].Value.ToString();
                        Drw["idProducto"] = row.Cells[2].Value.ToString();
                        Drw["idAlmacen"] = idAlmacen;
                        Info.Rows.Add(Drw);

                        if (fnPaquete.GuardarRelPaqueteProducto(Info))
                        {
                            try
                            {
                                string fPrecio = fnPaquete.getPrecioProducto(row.Cells[2].Value.ToString());
                                double totalCosto = Convert.ToDouble(fPrecio) * Convert.ToDouble(row.Cells[5].Value.ToString());
                                if (fnPaquete.InsertNuevoCosto(totalCosto, row.Cells[1].Value.ToString()))
                                {
                                    label_Producto.Visible = false;
                                    getInfoProductos();
                                    CargaListaPaquete();
                                    Classes.Class_Session.producto = "";
                                    label_Producto.Text = "";
                                }
                                else { }
                            }
                            catch{ }
                        }
                        else
                        {
                            MessageBox.Show("Problema al Guardar");
                        }
                    }
                }
                dataGridView4.Visible = false;
                dataGridView2.Visible = true;
                getInfoProductos();
                CargaListaPaquete();
            }

           
        }

        private void checkBox_Paquete_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Paquete.Checked == true)
            {
                label_Leyenda.Text = "Paquete que se compone de diferentes productos.";
                label_Leyenda.Visible = true;
                label_Activo.Visible = true;
                label_Vence.Visible = true;
                dateTimePicker_fin.Visible = true;
                dateTimePicker_inicio.Visible = true;
            }
            else
            {
                ocultarElementos();
            }
        }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    dataGridView4.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch { }
        }
        private void textBox_Maximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool punto_decimales = false;
            int cantidad_decimales = 0;

            for (int i = 0; i < textBox_Precio.Text.Length; i++)
            {
                if (textBox_Precio.Text[i] == '.')
                    punto_decimales = false;

                if (punto_decimales && cantidad_decimales++ >= 2)
                {
                    e.Handled = false;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (punto_decimales) ? false : false;
            else
                e.Handled = true;
        }



        private void textBox_Costo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool punto_decimales = false;
            int cantidad_decimales = 0;

            for (int i = 0; i < textBox_Costo.Text.Length; i++)
            {
                if (textBox_Costo.Text[i] == '.')
                    punto_decimales = false;

                if (punto_decimales && cantidad_decimales++ >= 2)
                {
                    e.Handled = false;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (punto_decimales) ? false : false;
            else
                e.Handled = true;
        }
        private void button_Add_Categorias_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Mercancia.Form_Categorias form = new Mercancia.Form_Categorias("");
            form.ShowDialog();
            //REcargamos
            LlenadoCategorias();
        }

        
    }
}


