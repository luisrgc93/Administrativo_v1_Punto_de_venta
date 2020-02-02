using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Formularios.Facturacion
{
    public partial class Form_FacTicket : Form
    {
        /*/// <temporales>*/
        double Subtotal = 0;
        double IVA = 0;
        double Total = 0;
        DataTable dtInfoFac;
        string idTickest = "";


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


        public event Form1.MessageHandler CargaListaAllFac;
        wFlexor.ServiceTimbrado WFlexSer = new wFlexor.ServiceTimbrado();


        public Form_FacTicket(string idTis)
        {
            InitializeComponent();
            idTickest = idTis;
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

            DataTable dtSer = ClsSer.getListaWhere(" WHERE iidEstatus = 1  AND iidEmpresa = " + Classes.Class_Session.IDEMPRESA.ToString());
            comboBox_Serie.DataSource = dtSer;
            comboBox_Serie.DisplayMember = "vchNombre";
            comboBox_Serie.ValueMember = "iidSerie";
        }

        private void Form_FacTicket_Load(object sender, EventArgs e)
        {
            if (idTickest == "")
            {
                MessageBox.Show("No se encontro tickets seleccionados");
                this.Close();
                return;
            }

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
            LlenaDetalleProductos();
        }
        private void LlenaDetalleProductos()
        {
            string sql = " " +
            " SELECT Fecha, Producto, Precio, Volumen, Importe, Codigo, Unidad,  " +
                    " idProducto, iidVenta, vchClave, vchCodigoSat, " +
                    " ROUND(Monto - Importe,6) as Iva, " +
                    " ROUND( ((ROUND(Monto - Importe,6) *100)/16),6) Base, MontoIeps " +
            " FROM ( " +
                    " SELECT CONVERT(varchar(10),V.dfechaIn,103)Fecha, P.vchDescripcion Producto, " +
                         " ROUND( ROUND(((V.fprecio - fIeps)/ 1.16),6) + fIeps , 6 ) Precio, " +
                         " ROUND( (V.fmonto/V.fprecio) , 6) Volumen,   " +
                         " ROUND(     " +
                            " ROUND( ROUND(((V.fprecio - fIeps)/ 1.16),6) + fIeps , 6 ) *  " +
                            " ROUND( (V.fmonto/V.fprecio) , 6) " +
                            " , 6 ) Importe, V.fmonto Monto, " +
                         " ROUND( fIeps * (V.fmonto/V.fprecio) , 6 ) MontoIeps,  " +
                         " P.vchCodigo Codigo, P.vchUnidad Unidad, P.iidProducto idProducto, V.iidVenta, P.vchClave, P.vchCodigoSat   " +
                     " FROM catVentasMonitoreo V, catProductos P   " +
                     " WHERE V.iidProducto = P.iidProducto  " +
                     " AND V.iidVenta in (" + idTickest + "0) " +
            " )AS t2  ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            areas.Fill(dstConsulta, "Datos");
            dataGridView_Lista.DataSource = dstConsulta.Tables[0];

            dataGridView_Lista.Columns["Fecha"].Width = 80;
            dataGridView_Lista.Columns["Producto"].Width = 300;
            dataGridView_Lista.Columns["Precio"].Width = 80;
            dataGridView_Lista.Columns["Volumen"].Width = 80;
            dataGridView_Lista.Columns["Importe"].Width = 90;
            dataGridView_Lista.Columns["Iva"].Width = 1;
            dataGridView_Lista.Columns["Iva"].Visible = false;
            dataGridView_Lista.Columns["MontoIeps"].Width = 1;
            dataGridView_Lista.Columns["MontoIeps"].Visible = false;
            dataGridView_Lista.Columns["Codigo"].Width = 1;
            dataGridView_Lista.Columns["Codigo"].Visible = false;
            dataGridView_Lista.Columns["Unidad"].Width = 1;
            dataGridView_Lista.Columns["Unidad"].Visible = false;
            dataGridView_Lista.Columns["idProducto"].Width = 1;
            dataGridView_Lista.Columns["idProducto"].Visible = false;
            dataGridView_Lista.Columns["iidVenta"].Width = 1;
            dataGridView_Lista.Columns["iidVenta"].Visible = false;
            dataGridView_Lista.Columns["vchClave"].Visible = false;
            dataGridView_Lista.Columns["vchCodigoSat"].Visible = false;
            dataGridView_Lista.Columns["Base"].Visible = false;
            
        }

    }
}
