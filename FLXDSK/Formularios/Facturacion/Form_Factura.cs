using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using System.Data.SqlClient;

namespace FLXDSK.Formularios.Facturacion
{
    public partial class Form_Factura : Form
    {
        
        /*/// <temporales>*/
        double Subtotal =0;
        double IVA = 0;
        double Total = 0;
        DataTable dtInfoFac;
       

        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Facturas.Class_XML genXml = new Classes.Facturas.Class_XML();
        Classes.Facturas.Class_TmpFac ClsTempCar = new Classes.Facturas.Class_TmpFac();


        Classes.Class_Logs Logs = new Classes.Class_Logs();
        Classes.Class_Empresa ClsEmp = new Classes.Class_Empresa();
        Classes.Class_Clientes ClsCli = new Classes.Class_Clientes();
        Classes.Catalogos.Mercancia.Class_Productos ClsProducto = new Classes.Catalogos.Mercancia.Class_Productos();
        Classes.Facturas.Class_Factura ClsFac = new Classes.Facturas.Class_Factura();


        
        
        /// SAT
        Classes.SAT.Class_TiposCFDI ClsTpCfdi = new Classes.SAT.Class_TiposCFDI();
        Classes.SAT.Class_TipoUso ClsUso = new Classes.SAT.Class_TipoUso();
        Classes.SAT.Class_Divisas ClsDiv = new Classes.SAT.Class_Divisas();
        Classes.SAT.Class_MetodoPago ClsMetodoPago = new Classes.SAT.Class_MetodoPago();
        Classes.SAT.Class_FormasPago ClsFormaPago = new Classes.SAT.Class_FormasPago();

        Classes.Facturas.Class_Series ClsSer = new Classes.Facturas.Class_Series();
        Classes.Facturas.Class_Certificado ClsCer = new Classes.Facturas.Class_Certificado();
        
        

        //string xml = Cls
       

        //Se declara un evento de tipo MessageHandler
        public event Form1.MessageHandler CargaListaAllFac;


        wFlexor.ServiceTimbrado WFlexSer = new wFlexor.ServiceTimbrado();

        public Form_Factura()
        {
            InitializeComponent();
        }

        private void LlenadocomboBox()
        {
            DataTable dtTipoCFDI = ClsTpCfdi.getListaWhere(" WHERE iidEstatus = 1 ");
            comboBox_TipoCFDI.DataSource = dtTipoCFDI;
            comboBox_TipoCFDI.DisplayMember = "vchDescripcion";
            comboBox_TipoCFDI.ValueMember = "iidTipoComprobante";

            DataTable dtUso = ClsUso.getListaWhere(" WHERE iidEstatus = 1 ");
            comboBox_Uso.DataSource = dtUso;
            comboBox_Uso.DisplayMember = "vchDescripcion";
            comboBox_Uso.ValueMember = "iidTipoUsoCFDI";

            DataTable dtMetodoPago = ClsMetodoPago.getListaWhere(" WHERE iidEstatus = 1 ");
            comboBox_MetodoPago.DataSource = dtMetodoPago;
            comboBox_MetodoPago.DisplayMember = "CodigoNombre";
            comboBox_MetodoPago.ValueMember = "iidMetodoPago";

            DataTable dtFormaPago = ClsFormaPago.getListaWhere(" WHERE iidEstatus = 1 ");
            comboBox_FormaPago.DataSource = dtFormaPago;
            comboBox_FormaPago.DisplayMember = "vchDescripcion";
            comboBox_FormaPago.ValueMember = "iidFormaPago";
       
            DataTable dtDivisas = ClsDiv.getListaWhere(" WHERE iidEstatus =  1 ");
            comboBox_Moneda.DataSource = dtDivisas;
            comboBox_Moneda.DisplayMember = "vchNombre";
            comboBox_Moneda.ValueMember = "iidDivisa";
        
            DataTable dtSer = ClsSer.getListaWhere(" WHERE iidEstatus = 1  AND iidEmpresa = "+Classes.Class_Session.IDEMPRESA.ToString());
            comboBox_Serie.DataSource = dtSer;
            comboBox_Serie.DisplayMember = "vchNombre";
            comboBox_Serie.ValueMember = "iidSerie";
        }
        private void Form_Factura_Load(object sender, EventArgs e)
        {
            ClsTempCar.Truncate();

            ////Cestificados
            genXml.dtCripto = ClsCer.getListaWhere(" WHERE iidEmpresa = " + Classes.Class_Session.IDEMPRESA.ToString() + " ORDER BY dfechain DESC ");
            if (genXml.dtCripto == null)
            {
                MessageBox.Show("La empresa no cuenta con un certificado cargado.");
                this.Close();
                return;                
            }
            if (genXml.dtCripto.Rows.Count == 0)
            {
                MessageBox.Show("La empresa no cuenta con un certificado cargado.");
                this.Close();
                return;
            }

            
            //ImfoEmpresa
            genXml.dtEmpresa = ClsEmp.GetInfoById(Classes.Class_Session.IDEMPRESA.ToString());
            if (genXml.dtEmpresa == null)
            {
                MessageBox.Show("La empresa no fue encontrada");
                this.Close();
                return;
            }
            if (genXml.dtCripto.Rows.Count == 0)
            {
                MessageBox.Show("La empresa no fue encontrada");
                this.Close();
                return;
            }

            label_RFC_Emisor.Text = genXml.dtEmpresa.Rows[0]["vchRFC"].ToString();
            label_RazonEmisor.Text = genXml.dtEmpresa.Rows[0]["vchRazon"].ToString();
            

            LlenadocomboBox();
        }
        private void getInfoCliente(string idCliente)
        {
            genXml.dtCliente = ClsCli.getInfoByID(idCliente);
            if (genXml.dtCliente == null)
            {
                MessageBox.Show("El cliente no fue encontrado");
                this.Close();
                return;
            }
            if (genXml.dtCliente.Rows.Count == 0)
            {
                MessageBox.Show("El cliente no fue encontrado");
                this.Close();
                return;
            }

            label_rfc.Text = genXml.dtCliente.Rows[0]["vchRFC"].ToString();
            label_razon.Text = genXml.dtCliente.Rows[0]["vchRazon"].ToString();
        }
        private void button_SelectCliente_Click(object sender, EventArgs e)
        {
            Classes.Class_Session.IdBuscador = 0;
            Formularios.Catalogos.Form_Buscar formBuscar = new Catalogos.Form_Buscar("Clientes");
            formBuscar.ShowDialog();
            if (Classes.Class_Session.IdBuscador != 0 && Classes.Class_Session.IdBuscador != null)
            {
                getInfoCliente(Classes.Class_Session.IdBuscador.ToString());
            }
        }

        private void button_AddProducto_Click(object sender, EventArgs e)
        {
            Classes.Class_Session.IdBuscador = 0;

            Formularios.Catalogos.Form_Buscar formBuscar = new Catalogos.Form_Buscar("Productos");
            formBuscar.ShowDialog();

            if (Classes.Class_Session.IdBuscador != 0)
                insertaProducto(Classes.Class_Session.IdBuscador);
            
        }
        private void insertaProducto(int iidProducto)
        {
            DataTable dtExis = ClsTempCar.getListaWhere(" WHERE iidProducto = " + iidProducto);
            if (dtExis.Rows.Count == 0)
            {
                if (!ClsTempCar.InsertaInformacion(iidProducto.ToString()))
                {
                    MessageBox.Show("Problema al agregar el producto, contacte al administrador");
                    return;
                }
            }
            else
            {
                double CantidadActual = 1;
                try
                {
                    CantidadActual = Convert.ToDouble(dtExis.Rows[0]["Cantidad"].ToString());
                }
                catch { }

                if (!ClsTempCar.ActualizaCantidad(iidProducto.ToString(), CantidadActual))
                {
                    MessageBox.Show("Problema al actualizar el producto, contacte al administrador");
                    return;
                }
            }
            CargaCarrito();
        }
        private void CargaCarrito()
        {
            dataGridView_Lista.DataSource = null;
            string sql = " SELECT iidProducto, Codigo, Producto, Precio, Cantidad, Importe, Iva " +
            " FROM tmpCarritoFactura (NOLOCK) ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Lista.DataSource = dstConsulta.Tables[0];

                dataGridView_Lista.Columns["iidProducto"].Visible = false;
                dataGridView_Lista.Columns["Iva"].Visible = false;
                dataGridView_Lista.Columns["Codigo"].ReadOnly = true;
                dataGridView_Lista.Columns["Producto"].ReadOnly = true;
                dataGridView_Lista.Columns["Precio"].ReadOnly = true;
                dataGridView_Lista.Columns["Cantidad"].Width = 70;
                dataGridView_Lista.Columns["Importe"].ReadOnly = true;

                dataGridView_Lista.Columns["Codigo"].Width = 100;
                dataGridView_Lista.Columns["Precio"].Width = 90;
                dataGridView_Lista.Columns["Importe"].Width = 100;

            }
            catch { }
            ShowTotales();
        }
        private void ShowTotales()
        {
            Subtotal = 0;
            IVA = 0;
            Total = 0;

            if (dataGridView_Lista.Rows.Count > 0)
            {

                foreach (DataGridViewRow row in dataGridView_Lista.Rows)
                {
                    double _Sub = 0;
                    double _Iva = 0;
                    double.TryParse(row.Cells["Importe"].Value.ToString(), out _Sub);
                    double.TryParse(row.Cells["Iva"].Value.ToString(), out _Iva);
                    Subtotal += _Sub;
                    IVA += _Iva;
                }
            }
            Total = Subtotal + IVA;
            label_Subtotal.Text = string.Format("{0:c}", Subtotal);
            label_IVA.Text = string.Format("{0:c}", IVA);
            label_total.Text = string.Format("{0:c}", Total);
        }
        

       
        

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

         
           
            if (dataGridView_Lista.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView_Lista.Rows)
                {
                    float traslado_importe;
                        float cantidadTmp = 0;
                        float precioTmp = 0;
                        float tasa_trasladoTmp = 0;
                        float.TryParse(row.Cells["Cantidad"].Value.ToString(), out cantidadTmp);
                        float.TryParse(row.Cells["Precio"].Value.ToString(), out precioTmp);
                        float.TryParse(row.Cells["tasa_trsalado"].Value.ToString(), out tasa_trasladoTmp);


                        row.Cells["Importe"].Value = (cantidadTmp) * precioTmp;
                        if (tasa_trasladoTmp > 0)
                        {

                            traslado_importe = (cantidadTmp * precioTmp) * (tasa_trasladoTmp / 100);
                            row.Cells["traslado_importe"].Value = traslado_importe;
                        }
                   
                }

                
                if (Subtotal > 0)
                {
                    
                }
            }   }
             catch (Exception)
            {

                MessageBox.Show(@"ALgo salió mal.", "error",MessageBoxButtons.OK);
            }
        }

        private bool ValidaFactura()
        {

            if (genXml.dtCliente == null)
            {
                MessageBox.Show("Selecciona un Cliente");
                button_Generar.Enabled = true;
                return false;
            }
            if (genXml.dtCliente.Rows.Count  == 0)
            {
                MessageBox.Show("Selecciona un Cliente");
                button_Generar.Enabled = true;
                return false;
            }

            ///Tipo
            genXml.IdTipoCfdi = "";
            try
            {
                genXml.IdTipoCfdi = comboBox_TipoCFDI.SelectedValue.ToString();
                DataTable dtTipoComp = ClsTpCfdi.getListaWhere(" WHERE iidTipoComprobante = " + genXml.IdTipoCfdi);
                if (dtTipoComp.Rows.Count > 0)
                    genXml.CveTipoCfdi = dtTipoComp.Rows[0]["vchCodigo"].ToString();
            }
            catch
            {
            }
            if (genXml.IdTipoCfdi == "")
            {
                MessageBox.Show("seleccione el tipo de comprobante");
                button_Generar.Enabled = true;
                return false;
            }

            ///Serie
            genXml.idSerie = "";
            try
            {
                genXml.idSerie = comboBox_Serie.SelectedValue.ToString();
            }
            catch { }
            if (genXml.idSerie == "")
            {
                MessageBox.Show("seleccione una serie");
                button_Generar.Enabled = true;
                return false;
            }
            genXml.dtSeries = ClsSer.getListaWhere(" WHERE iidSerie = " + genXml.idSerie);

            if (genXml.dtSeries.Rows.Count <= 0)
            {
                MessageBox.Show("seleccione una serie correcta");
                button_Generar.Enabled = true;
                return false;
            }
            if (genXml.dtSeries.Rows[0]["vchcp"].ToString().Trim() == "")
            {
                MessageBox.Show("Es necesario poner un Codigo Postal a la serie seleccionada");
                button_Generar.Enabled = true;
                return false;
            }


            //Divisa
            genXml.IdDivisa = "";
            try
            {
                genXml.IdDivisa = comboBox_Moneda.SelectedValue.ToString();
                DataTable dtTipoDiv = ClsDiv.getListaWhere(" WHERE iidDivisa = " + genXml.IdDivisa);
                if (dtTipoDiv.Rows.Count > 0)
                    genXml.CveMoneda = dtTipoDiv.Rows[0]["vchClave"].ToString();
            }
            catch
            {
            }
            if (genXml.IdDivisa == "")
            {
                MessageBox.Show("seleccione la moneda");
                button_Generar.Enabled = true;
                return false;
            }

            //Metodo
            genXml.idMetodo = "";
            try
            {
                genXml.idMetodo = comboBox_MetodoPago.SelectedValue.ToString();
                DataTable dtMetodo = ClsMetodoPago.getListaWhere(" WHERE iidMetodoPago = " + genXml.idMetodo);
                if (dtMetodo.Rows.Count > 0)
                    genXml.CveMetodo = dtMetodo.Rows[0]["vchCodigoMetodoPago"].ToString();
            }
            catch
            {
            }
            if (genXml.idMetodo == "")
            {
                MessageBox.Show("seleccione el metodo de pago");
                button_Generar.Enabled = true;
                return false;
            }

            ///Forma
            genXml.idForma = "";
            try
            {
                genXml.idForma = comboBox_FormaPago.SelectedValue.ToString();
                DataTable dtForma = ClsFormaPago.getListaWhere(" WHERE iidFormaPago = " + genXml.idForma);
                if (dtForma.Rows.Count > 0)
                    genXml.CveForma = dtForma.Rows[0]["vchCodigoFormaPago"].ToString();
            }
            catch
            {
            }
            if (genXml.idForma == "")
            {
                MessageBox.Show("seleccione la forma de pago");
                button_Generar.Enabled = true;
                return false;
            }

            ///Uso
            genXml.CveUso = "";
            try
            {
                string IdUso = comboBox_Uso.SelectedValue.ToString();
                if (IdUso == "" || IdUso == "0")
                {
                    MessageBox.Show("seleccione el uso del CFDI");
                    button_Generar.Enabled = true;
                    return false;
                }

                DataTable dtUso = ClsUso.getListaWhere(" WHERE iidTipoUsoCFDI = " + IdUso);
                if (dtUso.Rows.Count > 0)
                    genXml.CveUso = dtUso.Rows[0]["vchClave"].ToString();
            }
            catch
            {
            }
            if (genXml.CveUso == "")
            {
                MessageBox.Show("seleccione el uso del comprobante");
                button_Generar.Enabled = true;
                return false;
            }



            return true;
        }

        private void button_Generar_Click(object sender, EventArgs e)
        {
            if(dataGridView_Lista.Rows.Count == 0)
            {
                MessageBox.Show("Agregue almenos un producto");
                return;
            }

            if(!ValidaFactura())
                return;

            BeginFacturacion();
        }


            
        private void BeginFacturacion()
        {
            bool SiProduccion = true;
            string UserPax = genXml.dtCripto.Rows[0]["vchUserPc"].ToString();
            string ClavePx = genXml.dtCripto.Rows[0]["vchPasPc"].ToString();
            string IdAcceso = genXml.dtEmpresa.Rows[0]["vchKeyTimbrado"].ToString();
            string NoPdf = "1";
            string serializado = "";

            try
            {
                if (ConfigurationManager.AppSettings["SiProduccion"] == "0")
                    SiProduccion = false;
            }
            catch { }

            button_Generar.Enabled = false;

            if (!genXml.genXML(Subtotal, Total, IVA, textBox_Comentario.Text.Trim()))
            {
                MessageBox.Show("Problema al generar el XML.");
                button_Generar.Enabled = true;
                Logs.InsertaInformacion("Problema al generar el XML.", "");
            }

            string respuesta = "";
            string Xmlgenerado = genXml.xmlgenerado;
            string IdFactura = ClsFac.getIdFactura();

            ClsFac.InsertaDetalleCar(IdFactura, "0");

               
            
            bool procesado = true;
            try
            {
                if (SiProduccion)
                    respuesta = WFlexSer.ControlMonitoreoV33(Xmlgenerado, IdAcceso, 1, NoPdf, UserPax, ClavePx, serializado);
                else
                    respuesta = WFlexSer.ControlMonitoreoV33(Xmlgenerado, "FE769509-E8F0-459F-9D61-93284C9816PT", 0, NoPdf, UserPax, ClavePx, serializado);
                  

            }
            catch (Exception ep)
            {
                procesado = false;
                Logs.InsertaInformacion("Problema al consumir fac:" + respuesta, ep.ToString());
                button_Generar.Enabled = true;
                return;
            }
            if (procesado == false)
            {
                MessageBox.Show("Problema al sellar");
                button_Generar.Enabled = true;
                return;
            }
            
            XmlDocument xml = new XmlDocument();

            try
            {
                xml.LoadXml(respuesta);
                string UUID = "";
                string fechaTimbre = "";
                XmlNodeList elemList = xml.GetElementsByTagName("tfd:TimbreFiscalDigital");
                for (int i = 0; i < elemList.Count; i++)
                {
                    fechaTimbre = elemList[i].Attributes["FechaTimbrado"].Value;
                    UUID = elemList[i].Attributes["UUID"].Value;
                }
                //guardamos
                if (ClsFac.InsertaDbTimbre(respuesta, UUID.ToUpper(), fechaTimbre, IdFactura))
                {
                    MessageBox.Show("Creado correctamente");
                    try
                    {
                        CargaListaAllFac();
                    }
                    catch { }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problema al almacentar, favor de reportarlo. Error:" + UUID);
                    button_Generar.Enabled = true;
                    Logs.InsertaInformacion("Problema al almacentar, favor de reportarlo:", UUID);
                }

            }
            catch
            {
                button_Generar.Enabled = true;
                Logs.InsertaInformacion(Xmlgenerado, respuesta);
                MessageBox.Show("Problema al Timbrar la Factura: " + respuesta);
            }

            
            

            button_Generar.Enabled = true;
        }
    }
}
