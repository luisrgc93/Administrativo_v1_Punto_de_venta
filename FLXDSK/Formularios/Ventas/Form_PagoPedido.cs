using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Formularios.Ventas
{
    public partial class Form_PagoPedido : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Ventas.Class_Pedidos ClsPedido = new Classes.Ventas.Class_Pedidos();
        Classes.Ventas.Class_PagoPedido fnPago = new Classes.Ventas.Class_PagoPedido();
        Classes.Catalogos.Class_Paquete fnPaquete = new Classes.Catalogos.Class_Paquete();

        Classes.SAT.Class_FormasPago ClsFormaPago = new Classes.SAT.Class_FormasPago();

        BindingSource bs = new BindingSource();

        string numPedido = "";
        string total = "";
        string Propina = "";
        float totalPago = 0;
        float restante = 0F;
        float sumaPagos = 0F;
        string nombreTarjeta = "";

        public event Form1.MessageHandler lista_pedidos;
        public Form_PagoPedido(string idPedido)
        {
            InitializeComponent();
            numPedido = idPedido;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void llenarCombo()
        {
            DataTable dtInfo = ClsFormaPago.getListaWhere(" WHERE iidEstatus = 1 ");
            comboBox_FormaPago.DataSource = dtInfo;
            comboBox_FormaPago.DisplayMember = "vchDescripcion";
            comboBox_FormaPago.ValueMember = "iidFormaPago";
        }

        private void Form_PagoPedido_Load(object sender, EventArgs e)
        {
            if (numPedido == "")
            {
                MessageBox.Show("Error al obtener la informacion");
                this.Close();
                return;
            }


            DataTable dtPedido =  ClsPedido.getLista(" AND P.iidPedido = " + numPedido);
            if (dtPedido.Rows.Count == 0)
            {
                MessageBox.Show("Pedido no encontado");
                this.Close();
                return;
            }

            llenarCombo();

            label_AreaMesa.Text = dtPedido.Rows[0]["Area"].ToString()+" / "+dtPedido.Rows[0]["Mesa"].ToString();
            label_Numpedido.Text = numPedido;
            label_idMesero.Text = dtPedido.Rows[0]["iidPersonal"].ToString();
            label_nombre.Text = dtPedido.Rows[0]["Mesero"].ToString();

            textBox_Subtotal.Text = string.Format("{0:c}", Convert.ToDouble(dtPedido.Rows[0]["fSubtotal"].ToString()));
            textBox_Descuento.Text = string.Format("{0:c}", Convert.ToDouble(dtPedido.Rows[0]["fDescuento"].ToString()));
            textBox_Propina.Text = "0";

            
            checar();                                
            CargaListaPagos();
            setMontos();
            
        }

        private void CargaListaPagos()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            string sql = " SELECT V.iidPago IdPago , CONVERT(varchar(20),V.dfechaPago,103) Fecha, M.vchDescripcion Forma_Pago,V.vchComentario Comentario, V.fmonto Monto " +
                         " FROM CatPagosVentas V (NOLOCK), int_satFormaPago F (NOLOCK) " +
                         " WHERE F.iidFormaPago = V.iidFormaPago " +
                         " AND V.iidPedido=" + numPedido + " AND V.iidEstatus = 1 ORDER BY Fecha DESC ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet ds = new DataSet();
            try
            {
                areas.Fill(ds, "Datos");
                dataGridView1.DataSource = ds.Tables[0];
                //Se define tamaño de columnas     
                dataGridView1.Columns["IdPago"].Visible = false;
                dataGridView1.Columns["Fecha"].Width = 80;
                dataGridView1.Columns["Metodo"].Width = 130;
                dataGridView1.Columns["Comentario"].Width = 300;
                dataGridView1.Columns["Monto"].Width = 100;
                dataGridView1.Columns["Fecha"].ReadOnly = true;
                dataGridView1.Columns["Forma_Pago"].ReadOnly = true;
                dataGridView1.Columns["Comentario"].ReadOnly = true;
                dataGridView1.Columns["Monto"].ReadOnly = true;

                if (!dataGridView1.Columns.Contains("Accion"))
                {
                    DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                    buttonColumn.Name = "Accion";
                    buttonColumn.HeaderText = "Accion";
                    buttonColumn.Width = 60;
                    buttonColumn.FillWeight = 40;
                    buttonColumn.Text = "Eliminar";
                    buttonColumn.UseColumnTextForButtonValue = true;
                    dataGridView1.Columns.Insert(0, buttonColumn);
                }
            }
            catch
            {
                MessageBox.Show("No hay Información");
            }
            bs.DataSource = dataGridView1.DataSource;
        }
        public void checar()
        {
            if (!fnPago.PedidotieneDescuento(numPedido))
            {                
                DataTable dtVenta = fnPago.getInfobyCuenta(numPedido);
                if (dtVenta.Rows.Count == 0)
                {
                    MessageBox.Show("Problema al obtenr la informacion de la venta");
                    return;
                }
             
                DataRow RowVenta = dtVenta.Rows[0];
                
                string subtotal = RowVenta["fSubtotal"].ToString();
                total = RowVenta["fTotal"].ToString();
                string descuento = RowVenta["fDescuento"].ToString();
                Propina = RowVenta["Propina"].ToString();

                if (descuento == "") { descuento = "0"; }

                float.TryParse(RowVenta["fTotal"].ToString(), out this.totalPago);
                this.totalPago = (float)(Math.Round((double)this.totalPago, 2));
                label_total.Text = totalPago.ToString();

                textBox_Descuento.Text = " $ " + descuento;
                textBox_Subtotal.Text = " $ " + subtotal;
                textBox_Propina.Text = Propina;
                textBox_monto.Text = RowVenta["fTotal"].ToString();
            }
            else
            {
                DataTable dtVenta = fnPago.getInfobyCuentaDescuento(numPedido);
                if (dtVenta.Rows.Count == 0)
                {
                    MessageBox.Show("Problema al obtenr la informacion de la venta");
                    return;
                }
             
                DataRow RowVenta = dtVenta.Rows[0];
                
                string subtotal = RowVenta["fSubtotal"].ToString();
                total = RowVenta["fTotal"].ToString();
                string desc = RowVenta["descuento"].ToString();
                Propina = RowVenta["Propina"].ToString();

                textBox_Subtotal.Text = " $ " + subtotal;
                textBox_Descuento.Text = " $ " + desc;
                textBox_Propina.Text = Propina;

                float.TryParse(RowVenta["fTotal"].ToString(), out this.totalPago);
                this.totalPago = (float)(Math.Round((double)this.totalPago, 2));
                label_total.Text = totalPago.ToString();
            }
        }

       
        private void button_agregarPago_Click(object sender, EventArgs e)
        {
            
            if (textBox_monto.Text == "" || textBox_monto.Text == "0") { MessageBox.Show("Favor de ingresar cantidad"); return; }

            string idFormaPago = "";
            try
            {
                idFormaPago = comboBox_FormaPago.SelectedValue.ToString();
            }
            catch { }

            if (idFormaPago == "")
            {
                MessageBox.Show("Favor de seleccionar un metodo de pago"); return; 
            }


            if (validarPartida(panel_pago))
            {
                textBox_Propina.ReadOnly = true;
                float monto = 0;
                float.TryParse(textBox_monto.Text, out monto);
                if (!(monto > this.restante))
                {
                    DataTable Info = new DataTable();
                    DataRow Drw;

                    Info.Columns.Add("venta", System.Type.GetType("System.String"));
                    Info.Columns.Add("iidFormaPago", System.Type.GetType("System.String"));
                    Info.Columns.Add("monto", System.Type.GetType("System.String"));
                    Info.Columns.Add("comentario", System.Type.GetType("System.String"));
                    Info.Columns.Add("tarjeta", System.Type.GetType("System.String"));

                    Drw = Info.NewRow();
                    Drw["venta"] = numPedido;
                    Drw["iidFormaPago"] = idFormaPago;
                    Drw["monto"] = monto.ToString();
                    Drw["comentario"] = textBox_comentario.Text;
                    Drw["tarjeta"] = textBox_TarjetaCredito.Text.Trim();
                    Info.Rows.Add(Drw);

                    if (fnPago.InsertaInformacion(Info))
                    {
                        MessageBox.Show("Pago agregado correctamente");
                        CargaListaPagos();
                        setMontos();
                        textBox_monto.Text = "";
                        textBox_comentario.Text = "";
                        ///////////
                        terminar();

                    }
                    else
                    {
                        MessageBox.Show("Problema al guardar el pago");
                    }
                }
                else
                {
                    MessageBox.Show("El monto es mayor a lo que se debe de la Compra");
                    textBox_monto.Focus();
                }
            }
        }

        public bool validarPartida(Panel text)
        {
            Boolean activo = false;
            String cadena = "Ingrese los siguientes campos:" + Environment.NewLine;
            int errores = 0;

            foreach (Control control in text.Controls)
            {
                //identificamos el Componente
                string nombre = control.Name;
                switch (nombre)
                {
                    case "textBox_monto":
                        if (string.IsNullOrEmpty(control.Text))
                        {
                            cadena += "* Monto" + Environment.NewLine;
                            errores++;
                        }
                        else
                        {
                            if (!isFloatNumber(control.Text))
                            {
                                cadena += "* Monto: solo numeros por favor" + Environment.NewLine;
                                errores++;
                            }
                        }
                        break;
                    case "dateTimePicker_fecha":
                        if (string.IsNullOrEmpty(control.Text))
                        {
                            cadena += "* Fecha de Pago " + Environment.NewLine;
                            errores++;
                        }
                        break;
                }
            }

            if (errores != 0)
            {
                MessageBox.Show(cadena);
            }
            else
            {
                activo = true;
            }
            return activo;
        }
        public bool isFloatNumber(string _numberText)
        {
            float Result = 0;
            bool numberResult = false;
            if (float.TryParse(_numberText, out Result))
            {
                numberResult = true;
            }
            return numberResult;
        }
        
        public void terminar()
        {
            if (this.restante <= 0)
            {
                if (fnPago.updatePagado(numPedido, "1"))
                {
                    DataTable IdProductos = new DataTable();
                    IdProductos = fnPago.getIdProductos(numPedido);

                    foreach (DataRow rows in IdProductos.Rows)
                    {
                        string idProducto = rows["iidProducto"].ToString();
                        string cantidadVenta = rows["fCantidad"].ToString();

                        //Preguntamos si es un paquete, platillo o pieza
                        if (fnPaquete.esPaquete(idProducto))
                        {
                            DataTable idProductosdePaquete = new DataTable();
                            idProductosdePaquete = fnPaquete.getIdProductos(idProducto);

                            //Recorremos que productos vienen en el paquete
                            foreach (DataRow rowsPaquete in idProductosdePaquete.Rows)
                            {
                                string idProductodePaquete = rowsPaquete["iidProducto"].ToString();
                                string cantidadVentadePaquete = rowsPaquete["fCantidad"].ToString();
                                string idAlmacen = rowsPaquete["iidAlmacen"].ToString();

                                //Si el producto es compuesto se restara a materia prima
                                if (fnPago.seComponedeMateriaPrima(idProductodePaquete))
                                {
                                    DataTable InfoMateriaPrima = new DataTable();
                                    InfoMateriaPrima = fnPago.idMateriaPrimaCantidad(idProductodePaquete);

                                    foreach (DataRow rowInfo in InfoMateriaPrima.Rows)
                                    {
                                        string idMateriaPrima = rowInfo["iidMateriPrima"].ToString();
                                        string cantidad = rowInfo["fCantidad"].ToString();
                                        string idAlmacenMP = rowInfo["iidAlmacen"].ToString();

                                        int CantTotal = Convert.ToInt32(cantidadVentadePaquete) * Convert.ToInt32(cantidad);
                                        string cantidadTotal = CantTotal.ToString();

                                        fnPago.descuentaDeExistencia(idMateriaPrima, cantidadTotal, idAlmacenMP);
                                    }
                                }
                                else
                                {
                                    //Si es pieza se restara a existencia
                                    fnPago.descuentaExistenciaProducto(idProductodePaquete, cantidadVentadePaquete, idAlmacen);
                                }
                            }
                        }
                        else
                        {
                            //Si es platillo o pieza preguntaremos si se compone de materia prima
                            if (fnPago.seComponedeMateriaPrima(idProducto))
                            {
                                DataTable InfoMateriaPrima = new DataTable();
                                InfoMateriaPrima = fnPago.idMateriaPrimaCantidad(idProducto);

                                foreach (DataRow rowInfo in InfoMateriaPrima.Rows)
                                {
                                    string idMateriaPrima = rowInfo["iidMateriPrima"].ToString();
                                    string cantidad = rowInfo["fCantidad"].ToString();
                                    string idAlmacen = rowInfo["iidAlmacen"].ToString();

                                    int CantTotal = Convert.ToInt32(cantidadVenta) * Convert.ToInt32(cantidad);
                                    string cantidadTotal = CantTotal.ToString();

                                    fnPago.descuentaDeExistencia(idMateriaPrima, cantidadTotal, idAlmacen);
                                }
                            }
                            else
                            {
                                string iidAlmacen = fnPaquete.getidAlmacen(idProducto);
                                fnPago.descuentaExistenciaProducto(idProducto, cantidadVenta, iidAlmacen);
                            }
                        }
                    }

                    DialogResult dialogResult = MessageBox.Show(@"La venta se ha pagado completamente ¿deseas cerrarla? ya no se podra modificar", "Confirmacion", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBox.Show("Cerrada correctamente");
                        lista_pedidos();
                        this.Close(); 
                    }
                }
                else
                {
                    MessageBox.Show("Problema al marcar como pagada la venta");
                }
            }
        }

        private void setMontos()
        {
            this.restante = 0;
            this.sumaPagos = 0;

            if (dataGridView1.Rows.Count > 0)
            {
                foreach (DataGridViewRow registro in dataGridView1.Rows)
                {
                    float monto = 0;
                    float.TryParse(registro.Cells["Monto"].Value.ToString(), out monto);
                    this.sumaPagos += monto;
                }
            }
            this.restante = this.totalPago - this.sumaPagos;
            this.restante = (float)(Math.Round((double)this.restante, 2));
            this.sumaPagos = (float)(Math.Round((double)this.sumaPagos, 2));

            label_restante.Text = restante.ToString();
            label_pagos.Text = this.sumaPagos.ToString();
        }

        private void button_Terminar_Click(object sender, EventArgs e)
        {
            terminar();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    DialogResult dialogResult = MessageBox.Show(@"¿Estas seguro de eliminar este pago ? ", "Confirmacion", MessageBoxButtons.YesNoCancel);
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (this.restante == 0)
                        {
                            fnPago.updatePagado(numPedido, "0");
                        }
                        string idPago = dataGridView1.Rows[e.RowIndex].Cells["IdPago"].Value.ToString();
                        if (fnPago.deletePago(idPago))
                        {
                            CargaListaPagos();
                            setMontos();
                        }
                        else
                        {
                            MessageBox.Show("Error al borrar el pago");
                        }
                    }
                }
            }
            catch { }
        }

        private void textBox_Propina_TextChanged(object sender, EventArgs e)
        {
            /*string propinaDefault = fnPago.getPropinaPedido(numPedido);
            string propina = textBox_Propina.Text;
            if (propina == "" || propina=="0")
            {
                double totalSinPropina = Convert.ToDouble(total) - Convert.ToDouble(propinaDefault);
                if (fnPago.updateTotal(numPedido, propina, totalSinPropina.ToString()))
                {
                    checar();
                    lista_pedidos();
                    setMontos();
                }
            }
            else
            {
                double totalconPropina = Convert.ToDouble(total) - Convert.ToDouble(propinaDefault);
                double totalPropina = totalconPropina + Convert.ToDouble(propina);

                if (fnPago.updateTotal(numPedido, propina, totalPropina.ToString()))
                {
                    checar();
                    lista_pedidos();
                    setMontos();
                }
            }*/
        }
        private void textBox_Propina_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (Char.IsDigit(e.KeyChar)) { e.Handled = false; }
            else
            {
                if (Char.IsControl(e.KeyChar)) { e.Handled = false; }
                else
                {
                    e.Handled = true;
                }
            }*/
        }

        private void comboBox_MetodoPago_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox_FormaPago.SelectedValue.ToString() == "4" || comboBox_FormaPago.SelectedValue.ToString() == "3" || comboBox_FormaPago.SelectedValue.ToString() == "18" || comboBox_FormaPago.SelectedValue.ToString() == "19")
                textBox_TarjetaCredito.ReadOnly = false;
            else
                textBox_TarjetaCredito.ReadOnly = true;
        }
    }
}