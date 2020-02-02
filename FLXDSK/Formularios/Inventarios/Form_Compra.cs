using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FLXDSK.Formularios.Inventarios
{
    public partial class Form_Compra : Form
    {
        string IdPasstext = "";
        DataTable dtListaProd = null;
        bool LoadComplete = false;
        string idProvedor = "";
        Classes.Inventarios.Class_Compras ClsCompras = new Classes.Inventarios.Class_Compras();
        Classes.Inventarios.Class_DetalleCompra ClsDetalleCompras = new Classes.Inventarios.Class_DetalleCompra();

        Classes.Catalogos.Mercancia.Class_Materia_Prima ClsMatPrim = new Classes.Catalogos.Mercancia.Class_Materia_Prima();
        Classes.Catalogos.Proveedores.Class_Proveedores ClsProveedor = new Classes.Catalogos.Proveedores.Class_Proveedores();
        

        Classes.SAT.Class_FormasPago ClsFormaPago = new Classes.SAT.Class_FormasPago();
        Classes.SAT.Class_TiposCFDI ClsTipoCFDI = new Classes.SAT.Class_TiposCFDI();
        Classes.Inventarios.Class_Almacen ClsAlmacen = new Classes.Inventarios.Class_Almacen();

        public event Form1.MessageHandler CargaListaAll;

        public Form_Compra(string id)
        {
            InitializeComponent();
            IdPasstext = id;

            dtListaProd = new DataTable();
            dtListaProd.Columns.Add("iidMateriPrima", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("Codigo", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("Cantidad", System.Type.GetType("System.Double"));
            dtListaProd.Columns.Add("Medida", System.Type.GetType("System.String"));
            dtListaProd.Columns.Add("Precio", System.Type.GetType("System.Double"));
            dtListaProd.Columns.Add("Importe", System.Type.GetType("System.Double"));
            dtListaProd.Columns.Add("Contenido", System.Type.GetType("System.Double"));
        }

        private void CargaCombos()
        {
            DataTable dtInfo = ClsFormaPago.getListaWhere(" WHERE iidEstatus = 1 ");
            comboBox_FormaPago.DataSource = dtInfo;
            comboBox_FormaPago.DisplayMember = "vchDescripcion";
            comboBox_FormaPago.ValueMember = "iidFormaPago";

            dtInfo = ClsTipoCFDI.getListaWhere(" WHERE iidEstatus =  0 ");
            comboBox_TipoCfdi.DataSource = dtInfo;
            comboBox_TipoCfdi.DisplayMember = "vchDescripcion";
            comboBox_TipoCfdi.ValueMember = "iidTipoComprobante";

            dtInfo = ClsAlmacen.getListaWhere(" WHERE iidEstatus = 1 ");
            comboBox_Almacen.DataSource = dtInfo;
            comboBox_Almacen.DisplayMember = "vchNombre";
            comboBox_Almacen.ValueMember = "iidAlmacen";
        }

        private void Form_Compra_Load(object sender, EventArgs e)
        {
            CargaCombos();

            if (IdPasstext != "")
                CargaInfoId();


            LoadComplete = true;
        }
        private void CargaInfoId()
        {
            DataTable dtExis = ClsCompras.getListaWhere(" WHERE iidCompra = " + IdPasstext);
            if (dtExis.Rows.Count == 0)
            {
                MessageBox.Show("Informacion no encontrada");
                this.Close();
                return;
            }

            textBox_Serie.Text = dtExis.Rows[0]["vchSerie"].ToString();
            textBox_Folio.Text = dtExis.Rows[0]["iFolio"].ToString();
            textBox_Comentario.Text = dtExis.Rows[0]["vchComentario"].ToString();
            try
            {
                comboBox_TipoCfdi.SelectedValue = dtExis.Rows[0]["iidTipoCfdi"].ToString();
                comboBox_FormaPago.SelectedValue = dtExis.Rows[0]["iidFormaPago"].ToString();
                comboBox_Almacen.SelectedValue = dtExis.Rows[0]["iidAlmacen"].ToString();
                comboBox_Almacen.Enabled = false;
            }
            catch { }

            dateTimePicker_Compra.Text = dtExis.Rows[0]["dfechaCompra103"].ToString();

            if (dtExis.Rows[0]["siPagado"].ToString() == "1")
                checkBox_Pagado.Checked = true;

            idProvedor = dtExis.Rows[0]["iidProveedor"].ToString();
            CargaInfoProveedor(idProvedor);

            //CargaDetalle
            DataTable dtDetalle = ClsDetalleCompras.getLista(" AND  D.iidCompra = " + IdPasstext);
            if (dtDetalle.Rows.Count > 0)
                foreach (DataRow Row in dtDetalle.Rows)
                {
                    string iidMateriPrima = Row["iidMateriPrima"].ToString();
                    double fCantidad = Convert.ToDouble(Row["fCantidad"].ToString());
                    double fCosto = Convert.ToDouble(Row["fCosto"].ToString());
                    string vchCodigo = Row["vchCodigo"].ToString();
                    string vchDescripcion = Row["vchDescripcion"].ToString();
                    string Medida = Row["Medida"].ToString();
                    int contenido = Convert.ToInt32(Row["fContenido"].ToString());


                    AgregaProducto(iidMateriPrima, Medida, fCantidad, vchCodigo, vchDescripcion, fCosto,contenido);
                }
        }



        private void label_SeleccionarProveedor_Click(object sender, EventArgs e)
        {
            Classes.Class_Session.IdBuscador = 0;

            Formularios.Form_Buscar frm = new Form_Buscar("Proveedores");
            frm.ShowDialog();
            if (Classes.Class_Session.IdBuscador != 0)
            {
                CargaInfoProveedor(Classes.Class_Session.IdBuscador.ToString());
            }
        }
        private void CargaInfoProveedor(string id)
        {
            DataTable dtProv = ClsProveedor.getListaWhere(" WHERE iidProveedor = " + id);
            if (dtProv.Rows.Count > 0)
            {
                label_proveedor.Text = dtProv.Rows[0]["vchNombreComercial"].ToString() + "\n\r";
                label_proveedor.Text += dtProv.Rows[0]["vhcRFC"].ToString() + " " + dtProv.Rows[0]["vchRazonSocial"].ToString();
                idProvedor = dtProv.Rows[0]["iidProveedor"].ToString();
            }
        }
        private void textBox_Buscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (textBox_Buscar.Text.Trim() != "")
                    ValidaBuscar();
            }
        }
        private void button_buscar_Click_1(object sender, EventArgs e)
        {
            Classes.Class_Session.IdBuscador = 0;

            herramientas.Form_BuscaProducto FormBProd = new herramientas.Form_BuscaProducto("");
            FormBProd.ShowDialog();

            if (Classes.Class_Session.IdBuscador != 0)
            {
                string IDMateriaSelc = Classes.Class_Session.IdBuscador.ToString();

                DataTable dtInfo = ClsMatPrim.getLista(" AND M.iidMateriPrima =  " + Classes.Class_Session.IdBuscador);
                if (dtInfo.Rows.Count > 0)
                {
                    Classes.Class_Session.fNewExistencia = 0;
                    Classes.Class_Session.NameMedida = "";


                    herramientas.Inventarios.Form_Cantidad FormCant = new herramientas.Inventarios.Form_Cantidad(IDMateriaSelc);
                    FormCant.ShowDialog();

                    if (Classes.Class_Session.fNewExistencia <= 0)
                    {
                        MessageBox.Show("Ingrese una Cantidad");
                        return;
                    }
                    if (Classes.Class_Session.NameMedida == "")
                    {
                        MessageBox.Show("Ingrese una Cantidad");
                        return;
                    }
                    double fCosto = 0;
                    try
                    {
                        fCosto = Convert.ToDouble(dtInfo.Rows[0]["fCosto"].ToString());
                    }
                    catch { }

                    AgregaProducto(dtInfo.Rows[0]["iidMateriPrima"].ToString(), 
                        Classes.Class_Session.NameMedida, 
                        Classes.Class_Session.fNewExistencia, 
                        dtInfo.Rows[0]["vchCodigo"].ToString(), 
                        dtInfo.Rows[0]["vchDescripcion"].ToString(), 
                        fCosto, Convert.ToInt32(dtInfo.Rows[0]["fContenido"].ToString()));

                }
            }
        }
        private void ValidaBuscar()
        {
            string txtBuscar = textBox_Buscar.Text.Trim();

            DataTable dtInfo = ClsMatPrim.getListaWhere(" WHERE vchCodigo + ' ' + vchDescripcion LIKE '%" + txtBuscar.Replace(" ", "%") + "%' ");
            if (dtInfo.Rows.Count == 1)
            {
                string IDMateriaSelc = dtInfo.Rows[0]["iidMateriPrima"].ToString();

                Classes.Class_Session.fNewExistencia = 0;
                Classes.Class_Session.NameMedida = "";

                herramientas.Inventarios.Form_Cantidad Formulario = new herramientas.Inventarios.Form_Cantidad(IDMateriaSelc);
                Formulario.ShowDialog();

                if (Classes.Class_Session.fNewExistencia <= 0)
                {
                    MessageBox.Show("Ingrese una Cantidad");
                    return;
                }
                if (Classes.Class_Session.NameMedida == "")
                {
                    MessageBox.Show("Ingrese una Cantidad");
                    return;
                }

                double fCosto = 0;
                try
                {
                    fCosto = Convert.ToDouble(dtInfo.Rows[0]["fCosto"].ToString());
                }
                catch { }

                AgregaProducto(dtInfo.Rows[0]["iidMateriPrima"].ToString(), Classes.Class_Session.NameMedida, Classes.Class_Session.fNewExistencia, dtInfo.Rows[0]["vchCodigo"].ToString(), dtInfo.Rows[0]["vchDescripcion"].ToString(), fCosto,Convert.ToInt32( dtInfo.Rows[0]["fContenido"].ToString()));

                textBox_Buscar.Text = "";
                textBox_Buscar.Focus();
            }
            else
            {
                Classes.Class_Session.IdBuscador = 0;

                if (dtInfo.Rows.Count > 0)
                {
                    herramientas.Form_BuscaProducto FormBProd = new herramientas.Form_BuscaProducto(txtBuscar);
                    FormBProd.ShowDialog();
                    if (Classes.Class_Session.IdBuscador != 0)
                    {
                        dtInfo = ClsMatPrim.getListaWhere(" WHERE iidMateriPrima =  " + Classes.Class_Session.IdBuscador.ToString());///se obtiene la materia prima
                        if (dtInfo.Rows.Count > 0)
                        {
                            Classes.Class_Session.fNewExistencia = 0;
                            Classes.Class_Session.NameMedida = "";

                            string IDMateriaSelc = dtInfo.Rows[0]["iidMateriPrima"].ToString();

                            herramientas.Inventarios.Form_Cantidad FormCant = new herramientas.Inventarios.Form_Cantidad(IDMateriaSelc);
                            FormCant.ShowDialog();

                            if (Classes.Class_Session.fNewExistencia <= 0)
                            {
                                MessageBox.Show("Ingrese una Cantidad");
                                return;
                            }
                            if (Classes.Class_Session.NameMedida == "")
                            {
                                MessageBox.Show("Ingrese una Cantidad");
                                return;
                            }

                            double fPrecio = 0;
                            try
                            {
                                fPrecio = Convert.ToDouble(dtInfo.Rows[0]["fPrecio"].ToString());
                            }
                            catch { }


                            AgregaProducto(dtInfo.Rows[0]["iidMateriPrima"].ToString(), Classes.Class_Session.NameMedida, Classes.Class_Session.fNewExistencia, dtInfo.Rows[0]["vchCodigo"].ToString(), dtInfo.Rows[0]["vchDescripcion"].ToString(), fPrecio, Convert.ToInt32(dtInfo.Rows[0]["fContenido"].ToString()));

                            textBox_Buscar.Text = "";
                            textBox_Buscar.Focus();
                        }
                    }
                }
                else
                {
                    herramientas.Form_BuscaProducto FormBProd = new herramientas.Form_BuscaProducto("");
                    FormBProd.ShowDialog();

                    if (Classes.Class_Session.IdBuscador != 0)
                    {
                        dtInfo = ClsMatPrim.getListaWhere(" WHERE iidMateriPrima =  " + Classes.Class_Session.IdBuscador.ToString());
                        if (dtInfo.Rows.Count > 0)
                        {
                            Classes.Class_Session.fNewExistencia = 0;
                            Classes.Class_Session.NameMedida = "";
                            string IDMateriaSelc = dtInfo.Rows[0]["iidMateriPrima"].ToString();

                            herramientas.Inventarios.Form_Cantidad FormCant = new herramientas.Inventarios.Form_Cantidad(IDMateriaSelc);
                            FormCant.ShowDialog();

                            if (Classes.Class_Session.fNewExistencia <= 0)
                            {
                                MessageBox.Show("Ingrese una Cantidad");
                                return;
                            }
                            if (Classes.Class_Session.NameMedida == "")
                            {
                                MessageBox.Show("Ingrese una Cantidad");
                                return;
                            }

                            double fPrecio = 0;
                            try
                            {
                                fPrecio = Convert.ToDouble(dtInfo.Rows[0]["fPrecio"].ToString());
                            }
                            catch { }


                            AgregaProducto(dtInfo.Rows[0]["iidMateriPrima"].ToString(), Classes.Class_Session.NameMedida, Classes.Class_Session.fNewExistencia, dtInfo.Rows[0]["vchCodigo"].ToString(), dtInfo.Rows[0]["vchDescripcion"].ToString(), fPrecio, Convert.ToInt32( dtInfo.Rows[0]["fContenido"].ToString()));

                            textBox_Buscar.Text = "";
                            textBox_Buscar.Focus();
                        }
                    }
                }
            }
        }
        private void AgregaProducto(string IdProd, string Medida, double fCantidad, string Codigo, string Producto, double Precio,int contenido)
        {
            //agregar contenido
            double cantidadPrecio = fCantidad;
            if (Medida == "Gramos" || Medida == "Mililitros")
            {
                cantidadPrecio = cantidadPrecio / 1000;
            }
            
            double importe = 0;
            if (Medida=="Pieza")
            {
                double cant = ((cantidadPrecio / contenido) *Precio);
                importe = Math.Round(cant, 2); //cambiar  
            }
           
            
            else if (contenido != 1) {
                double cant=((cantidadPrecio*1000)/contenido);
                importe = Math.Round(cant * Precio, 2); //cambiar
            
            }
            else
            {

                  importe = Math.Round(cantidadPrecio * Precio, 2);
            }


            DataRow Drw = dtListaProd.NewRow();
            Drw["iidMateriPrima"] = IdProd;
            Drw["Codigo"] = Codigo;
            Drw["Descripcion"] = Producto;
            Drw["Cantidad"] = fCantidad;
            Drw["Precio"] = Precio;
            Drw["Importe"] = Math.Round(importe, 2);
            Drw["Medida"] = Medida;
            Drw["Contenido"] = contenido;
            dtListaProd.Rows.Add(Drw);

            CargaCarrito();
        }
        private void CargaCarrito()
        {
            

            dataGridView_Lista.DataSource = dtListaProd;
            try
            {
                dataGridView_Lista.Columns["iidMateriPrima"].Visible = false;
            }
            catch { }

            dataGridView_Lista.Columns["Codigo"].ReadOnly = true;
            dataGridView_Lista.Columns["Descripcion"].ReadOnly = true;
            dataGridView_Lista.Columns["Importe"].ReadOnly = true;
            dataGridView_Lista.Columns["Medida"].ReadOnly = true;

            dataGridView_Lista.Columns["Codigo"].Width = 80;
            dataGridView_Lista.Columns["Descripcion"].Width = 400;
            dataGridView_Lista.Columns["Cantidad"].Width = 60;
            dataGridView_Lista.Columns["Medida"].Width = 50;
            dataGridView_Lista.Columns["Precio"].Width = 60;
            dataGridView_Lista.Columns["Importe"].Width = 90;
            
            RefrescaTotal();
        }
        private void RefrescaTotal()
        {
            double SubTotal= 0;
            foreach (DataGridViewRow row in dataGridView_Lista.Rows)
            {
                SubTotal += Convert.ToDouble(row.Cells["Importe"].Value);
            }
            textBox_Total.Text = SubTotal.ToString();
        }
        private void dataGridView_Lista_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataRow Row in dtListaProd.Rows)
            {
                double Cantidad = Convert.ToDouble(Row["Cantidad"].ToString());
                double Precio = Convert.ToDouble(Row["Precio"].ToString());

                if (Row["Medida"].ToString() == "Mililitros" || Row["Medida"].ToString() == "Gramos")
                    Cantidad = Cantidad / 1000;

                double Importe = Math.Round(Cantidad * Precio, 2);
                Row["Importe"] = Importe;
            }
            CargaCarrito();
            RefrescaTotal();
        }
        private void dataGridView_Lista_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataRow Row in dtListaProd.Rows)
            {
                double Cantidad = Convert.ToDouble(Row["Cantidad"].ToString());
                double Precio = Convert.ToDouble(Row["Precio"].ToString());

                if (Row["Medida"].ToString() == "Mililitros" || Row["Medida"].ToString() == "Gramos")
                    Cantidad = Cantidad / 1000;

                double Importe = Math.Round(Cantidad * Precio, 2);
                Row["Importe"] = Importe;
            }
            CargaCarrito();
            RefrescaTotal();
        }
        private void dataGridView_Lista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_Lista.Rows[e.RowIndex];
                string iidMateriPrima = row.Cells["iidMateriPrima"].Value.ToString();

                DialogResult Reps = MessageBox.Show(@"Esta seguro de eliminar el Registro?", "Confirmar", MessageBoxButtons.YesNo);
                if (Reps == DialogResult.Yes)
                {
                    for (int i = dtListaProd.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = dtListaProd.Rows[i];
                        if (dr["iidMateriPrima"].ToString() == iidMateriPrima)
                            dr.Delete();
                    }

                    CargaCarrito();
                }
            }
        }

        private void comboBox_Almacen_SelectedValueChanged(object sender, EventArgs e)
        {
            if (LoadComplete)
            {
                string valSelec = "";
                try
                {
                    valSelec = comboBox_Almacen.SelectedValue.ToString();
                    comboBox_Almacen.Enabled = false;
                }
                catch { }
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (dtListaProd.Rows.Count == 0)
            {
                MessageBox.Show("Agregue almenos un producto");
                return;
            }

            string IdAlmacen = "";
            string idFormaPago = "";
            string IdTipoCfdi = "";
            string siPagado = "0";
            int iFolio = 0;
            try
            {
                IdAlmacen = comboBox_Almacen.SelectedValue.ToString();
                idFormaPago = comboBox_FormaPago.SelectedValue.ToString();
                IdTipoCfdi = comboBox_TipoCfdi.SelectedValue.ToString();
            }
            catch { }


            if (textBox_Folio.Text.Trim() != "")
            {
                try
                {
                    iFolio = Convert.ToInt32(textBox_Folio.Text.Trim());
                }
                catch {
                    MessageBox.Show("Folio debe ser numerico");
                    return;
                }
            }


            if (idProvedor == "")
            {
                MessageBox.Show("Seleccione un Proveedor");
                return;
            }

            if (IdAlmacen == "" || IdAlmacen == "0")
            {
                MessageBox.Show("Seleccione un almacen");
                return;
            }
            if (idFormaPago == "" || idFormaPago == "0")
            {
                MessageBox.Show("Seleccione la forma de pago");
                return;
            }
            if (IdTipoCfdi == "" || IdTipoCfdi == "0")
            {
                MessageBox.Show("Seleccione el tipo de comprobante");
                return;
            }
            if (checkBox_Pagado.Checked)
                siPagado = "1";

            double Total = 0;
            if (textBox_Total.Text.Trim() != "")
            {
                try
                {
                    Total = Convert.ToDouble(textBox_Total.Text.Trim());
                }
                catch { }
            }

            string[] val = dateTimePicker_Compra.Text.Split('/');
            string FechaCompra = val[2] + "-" + val[1] + "-" + val[0] + "T00:00:00";


            DataTable dtAdd = new DataTable();
            dtAdd.Columns.Add("iidFormaPago", System.Type.GetType("System.String"));
            dtAdd.Columns.Add("iidAlmacen", System.Type.GetType("System.String"));
            dtAdd.Columns.Add("iidTipoCfdi", System.Type.GetType("System.String"));
            dtAdd.Columns.Add("fSubTotal", System.Type.GetType("System.String"));
            dtAdd.Columns.Add("fTotal", System.Type.GetType("System.String"));
            dtAdd.Columns.Add("dfechaCompra", System.Type.GetType("System.String"));
            dtAdd.Columns.Add("siPagado", System.Type.GetType("System.String"));
            dtAdd.Columns.Add("vchComentario", System.Type.GetType("System.String"));
            dtAdd.Columns.Add("iFolio", System.Type.GetType("System.String"));
            dtAdd.Columns.Add("vchSerie", System.Type.GetType("System.String"));
            dtAdd.Columns.Add("iidProveedor", System.Type.GetType("System.String"));


            DataRow Drw = dtAdd.NewRow();
            Drw["iidFormaPago"] = idFormaPago;
            Drw["iidAlmacen"] = IdAlmacen;
            Drw["iidTipoCfdi"] = IdTipoCfdi;
            Drw["fSubTotal"] = Total;
            Drw["fTotal"] = Total;
            Drw["dfechaCompra"] = FechaCompra;
            Drw["siPagado"] = siPagado;
            Drw["vchComentario"] = textBox_Comentario.Text.Trim();
            Drw["iFolio"] = iFolio;
            Drw["vchSerie"] = textBox_Serie.Text.Trim();
            Drw["iidProveedor"] = idProvedor;
            dtAdd.Rows.Add(Drw);

            if (IdPasstext == "")
            {

                if (ClsCompras.InsertaInformacion(dtAdd))
                {
                    string IdCompra = ClsCompras.getIdCrado();
                    if (IdCompra == "")
                    {
                        MessageBox.Show("Problema al obtener el Id de la compra");
                        this.Close();
                        return;
                    }

                    foreach (DataRow Row in dtListaProd.Rows)
                    {
                        double fValorCant = Convert.ToDouble(Row["Cantidad"].ToString());
                        if (Row["Medida"].ToString() == "Kilos")
                            fValorCant = fValorCant * 1000;
                        else
                            if (Row["Medida"].ToString() == "Litros")
                                fValorCant = fValorCant * 1000;

                        double fPrecio = Convert.ToDouble(Row["Precio"].ToString());
                        double fImporte = Convert.ToDouble(Row["Importe"].ToString());

                        ClsDetalleCompras.InsertaInformacion(IdCompra, Row["iidMateriPrima"].ToString(), fPrecio, fValorCant, fImporte);
                    }


                    MessageBox.Show("Guardado Correctamente");
                    this.Close();

                    try
                    {
                        CargaListaAll();
                    }
                    catch { }
                    return;
                }
                else
                {
                    MessageBox.Show("Problema al almacenar, contacte al administrador");
                    return;
                }
            }
            else
            {
                if (ClsCompras.ActualizaInformacion(dtAdd, IdPasstext))
                {
                    //Borramos todos
                    ClsDetalleCompras.ClearDetalle(IdPasstext);

                    foreach (DataRow Row in dtListaProd.Rows)
                    {
                        double fValorCant = Convert.ToDouble(Row["Cantidad"].ToString());
                        if (Row["Medida"].ToString() == "Kilos")
                            fValorCant = fValorCant * 1000;
                        else
                            if (Row["Medida"].ToString() == "Litros")
                                fValorCant = fValorCant * 1000;

                        double fPrecio = Convert.ToDouble(Row["Precio"].ToString());
                        double fImporte = Convert.ToDouble(Row["Importe"].ToString());

                        ClsDetalleCompras.InsertaInformacion(IdPasstext, Row["iidMateriPrima"].ToString(), fPrecio, fValorCant, fImporte);
                    }


                    MessageBox.Show("Guardado Correctamente");
                    this.Close();

                    try
                    {
                        CargaListaAll();
                    }
                    catch { }
                    return;
                }
                else
                {
                    MessageBox.Show("Problema al almacenar, contacte al administrador");
                    return;
                }
            }

        }

        private void button_Crear_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Mercancia.Form_MateriaPrima formMat = new Catalogos.Mercancia.Form_MateriaPrima("");
            formMat.Show();
        }

        private void label_CargaCFDI_Click(object sender, EventArgs e)
        {
            DialogResult Reps = MessageBox.Show(@"Esta seguro de cargar comprobante Fiscal, solo se cargaran productos con codigos existentes en el sistema?", "Confirmar", MessageBoxButtons.YesNo);
            if (Reps == DialogResult.Yes)
            {
                OpenFileDialog theDialog = new OpenFileDialog();
                theDialog.Title = "CFDI ";
                theDialog.Filter = "XML files|*.xml";
                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string filename = theDialog.FileName;
                        string XmlString = File.ReadAllText(filename);

                        Classes.XML.Class_LectorXML ClsXML = new Classes.XML.Class_LectorXML();
                        ClsXML.ExtraXML(XmlString);

                        if (ClsXML.dtProductos == null)
                        {
                            MessageBox.Show("Error: No se encontraron productos ");
                            return;
                        }
                        
                        string NoExisten = "";
                        if(ClsXML.dtProductos.Rows.Count > 0)
                        {
                            foreach (DataRow Row in ClsXML.dtProductos.Rows)
                            {
                                string Codigo = Row["codigo"].ToString();
                                string Descripcion = Row["descripcion"].ToString();
                                double Precio = Convert.ToDouble(Row["precio"].ToString());
                                double Cantidad = Convert.ToDouble(Row["cantidad"].ToString());
                                string MedidaSat = Row["MedidaSAT"].ToString();
                                string CodigoSat = Row["CodigoSAT"].ToString();
                                
                                DataTable dtMatPrima = ClsMatPrim.getLista(" AND M.vchCodigo = '" + Codigo + "' AND M.iidEstatus = 1 ");
                                if (dtMatPrima.Rows.Count > 0)
                                {
                                    string IdProd = dtMatPrima.Rows[0]["iidMateriPrima"].ToString();
                                    string Medida = dtMatPrima.Rows[0]["vchNombre"].ToString();
                                    int contenido = Convert.ToInt32(dtMatPrima.Rows[0]["fContenido"].ToString());

                                    AgregaProducto(IdProd, Medida, Cantidad, Codigo, Descripcion, Precio,contenido);
                                }
                                else
                                {
                                    NoExisten += Codigo + " - " + Descripcion+"\n\r";
                                }
                                
                                //AgregaProducto(string IdProd, string Medida, double fCantidad, string Codigo, string Producto, double Precio)
                            }
                        }

                        if (NoExisten != "")
                        {
                            MessageBox.Show("Existen algunos productos que no estan registrados y no se pueden mostrar:\n\r" + NoExisten);
                        }
                        
                        MessageBox.Show("Proceso Terminado");
                        

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: Problema al Leer el archivo: " + ex.Message);
                    }
                }
            }
        }

        private void label_CreaProveedor_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Proveedores.Form_Proveedores formProv = new Catalogos.Proveedores.Form_Proveedores("");
            formProv.ShowDialog();
        }

        

        
        
        

        

       
        

        


    }
}
