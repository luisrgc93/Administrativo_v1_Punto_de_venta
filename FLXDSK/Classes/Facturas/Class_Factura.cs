using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Facturas
{
    class Class_Factura
    {
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = " " +
                    " SELECT iidFactura, iidEmpresa, dfechain, dfechaTimbrado, " +
                    "  dfechaup, vchVersion, vchuuid, iidTipoCfdi, " +
                    "  iidMetodopago, iidFormaPago, iidEstatus, iidDivisa, " +
                    "  vchNumCta, iidSerie, vchSerie, iFolio, iidCliente, fsubtotal, " +
                    "  fdescuento, fiva, fretencion, ftotal, vchComentario, vchCfd, " +
                    "  vchCfdi,  SiCompletado, iidDiseno, iidUsuario, SiEnviado " +
                    " FROM MovFacturas V (NOLOCK) " + filtroWhere;
            return conx.Consultasql(sql);
        }
        public DataTable getInfoByID(string id)
        {
            string sql = " " +
                    " SELECT iidFactura, iidEmpresa, dfechain, dfechaTimbrado, " +
                    "  dfechaup, vchVersion, vchuuid, iidTipoCfdi, " +
                    "  iidMetodopago, iidFormaPago, iidEstatus, iidDivisa, " +
                    "  vchNumCta, iidSerie, vchSerie, iFolio, iidCliente, fsubtotal, " +
                    "  fdescuento, fiva, fretencion, ftotal, vchComentario, vchCfd, " +
                    "  vchCfdi,  SiCompletado, iidDiseno, iidUsuario, SiEnviado " +
                    " FROM MovFacturas V (NOLOCK) " +
                    " WHERE SiCompletado = 1 " +
                    " ANd iidFactura = " + id;
            return conx.Consultasql(sql);
        }
        public DataTable getInfoByUUID(string id)
        {
            string sql = " " +
                    " SELECT iidFactura, iidEmpresa, dfechain, dfechaTimbrado, " +
                    "  dfechaup, vchVersion, vchuuid,  iidTipoCfdi, " +
                    "  iidMetodopago, iidFormaPago, iidEstatus, iidDivisa,  " +
                    "  vchNumCta, iidSerie, vchSerie, iFolio, iidCliente, fsubtotal, " +
                    "  fdescuento, fiva, fretencion, ftotal, vchComentario, vchCfd, " +
                    "  vchCfdi,  SiCompletado, iidDiseno, iidUsuario, SiEnviado, " +
                    " CONVERT(VARCHAR(11), dfechaTimbrado, 102)fechaTimForName,  " +
                    " CONVERT(VARCHAR(11), dfechaTimbrado, 106) AS fechaTimb, " +
                    " CONVERT (char(10), dfechaTimbrado, 108) as horaTimb" +
                    " FROM MovFacturas V (NOLOCK) " +
                    " WHERE SiCompletado = 1 " +
                    " ANd vchuuid = '" + id + "'";
            return conx.Consultasql(sql);
        }
        public string GetNamePdf(string uuid)
        {
            string sql = "select C.vchRFC,CONVERT(VARCHAR(11), V.dfechaTimbrado, 102)dfechaTimbrado,V.iFolio,V.vchSerie " +
                         " from MovFacturas V (NOLOCK), catClientes C (NOLOCK) " +
                         " where vchuuid='" + uuid + "' " +
                         " AND C.iidCliente = V.iidCliente";
            DataTable dt = conx.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                string rfc = Row["vchRFC"].ToString();
                string fechatim = Row["dfechaTimbrado"].ToString();
                string folio = Row["iFolio"].ToString();
                string serie = Row["vchSerie"].ToString();
                return rfc + "_" + fechatim.Replace(".", "") + "_" + serie + folio;
            }
            catch
            {
                return "";
            }
        }
        public bool ActualizaDisenoFac(string uuid, string iidDiseno)
        {
            string sql = "UPDATE MovFacturas set iidDiseno =" + iidDiseno + " where vchuuid = '" + uuid + "' ";
            return conx.InsertaSql(sql);
        }
        public bool CancelaFac(string uuid)
        {
            string sql = "UPDATE MovFacturas set SiCancelado=1 where vchuuid = '" + uuid + "' ";
            return conx.InsertaSql(sql);
        }
        public string getFecha()
        {
            string sql = " SELECT CONVERT(VARCHAR(19),dateadd(minute,-3,getdate()),126)  fecha ";
            DataTable dt = new DataTable();
            dt = conx.Consultasql(sql);
            DataRow dr = dt.Rows[0];
            return dr["fecha"].ToString();
        }
        public int getFolio(string serie)
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            DataTable dt = new DataTable();
            string sql = "SELECT iFolio, vchSerie FROM catSeries (NOLOCK) WHERE iidEmpresa = " + empresa + " AND iidSerie = " + serie + " AND iidEstatus = 1 ";
            dt = conx.Consultasql(sql);
            DataRow dr = dt.Rows[0];

            int folioSer = Convert.ToInt32(dr["iFolio"].ToString());
            string vchSerie = dr["vchSerie"].ToString();
            ///
            sql = "SELECT top 1 iFolio + 1 as iFolio  FROM MovFacturas (NOLOCK) WHERE SiCompletado = 1 AND iidEmpresa = " + empresa + " AND vchSerie = '" + vchSerie + "' ORDER BY iFolio DESC ";
            dt = conx.Consultasql(sql);
            int folioVen = 0;
            try
            {
                DataRow drt = dt.Rows[0];
                folioVen = Convert.ToInt32(drt["iFolio"].ToString());
            }
            catch
            {
            }
            if (folioSer > folioVen)
                return folioSer;
            else
                return folioVen;

        }

        public bool InsertaDb(double subtotal, double total, double iva, double retencion, string vchSerie, int folio, string xmlstring, string fecha,  DataTable dtInfoFac)
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);

            string idSerie = dtInfoFac.Rows[0]["idSerie"].ToString();
            string idDivisa = dtInfoFac.Rows[0]["idDivisa"].ToString();
            string idMetodo = dtInfoFac.Rows[0]["idMetodo"].ToString();
            string idForma = dtInfoFac.Rows[0]["idForma"].ToString();
            string idCfdi = dtInfoFac.Rows[0]["idCfdi"].ToString();
            string idCliente = dtInfoFac.Rows[0]["idCliente"].ToString();
            string comentario = dtInfoFac.Rows[0]["comentario"].ToString();
            
            

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();
            string sql = "INSERT INTO MovFacturas " +
                " (iidEmpresa, dfechain, dfechaup, vchVersion, iidTipoCfdi, " +
                " iidMetodopago, iidFormaPago, iidEstatus, iidDivisa, iidBanco, vchNumCta, iidSerie, " +
                " vchSerie, iFolio, iidCliente, SiCancelado, " +
                " fsubtotal, fdescuento, fiva, fretencion, ftotal, " +
                " vchComentario, vchCfd,  SiCompletado, iidDiseno, iidUsuario, SiEnviado ) " +
                " VALUES ( " +
                " " + empresa + ", @fecha, GETDATE(), '3.2',  '" + idCfdi + "', " +
                " " + idMetodo + ", " + idForma + ", 1, " + idDivisa + ",'0', '', '" + idSerie + "', " +
                " '" + vchSerie + "', '" + folio + "', '" + idCliente + "',  0, " +
                " '" + subtotal + "', 0, '" + iva + "', '" + retencion + "', '" + total + "', " +
                " '" + comentario + "', @xmlstring, 0, 1, " + usuariolog + ", 0) ";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@xmlstring", SqlDbType.Text);
            cmd.Parameters.Add("@fecha", SqlDbType.DateTime);
            cmd.Parameters["@xmlstring"].Value = xmlstring;
            cmd.Parameters["@fecha"].Value = fecha;
            try
            {
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception exp)
            {
                ClsLog.InsertaInformacion(exp.ToString(), "Insertar XMl en base de datos");
                return false;
            }

        }
        public string getIdFactura()
        {
            string sql = "SELECT MAX(iidFactura)iidFactura FROM MovFacturas (NOLOCK)  ";
            DataTable dt = conx.Consultasql(sql);
            if (dt.Rows.Count == 0)
                return "0";

            return dt.Rows[0]["iidFactura"].ToString();
        }
        public bool InsertaDetalleCar(string IdFactura, string IdPedido)
        {
            string sql = " " +
            " INSERT INTO detFacturas (iidPedido, iidFactura, iidProducto,  " +
                " vchCodigo, vchUnidad, vchDescripcion, fprecio, fdescuento, icantidad,  " +
                " fIva, fImporte, dfechain, dfechaup, SiEnviado) " +
                " " +
            " SELECT " + IdPedido + " IdPedido, " + IdFactura + " IdFactura, iidProducto, " +
                " Codigo, Unidad, Producto, Precio, 0 Descuento, Cantidad, " +
                " Iva, Importe, GETDATE(),  GETDATE(), 0 " +
            " FROM tmpCarritoFactura (NOLOCK)";
            return conx.InsertaSql(sql);
        }

        public bool InsertaDbTimbre(string CFDI, string UUID, string FechaTimbrado, string IdFactura)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string sql = "UPDATE MovFacturas SET " +
                " SiCompletado = 1, vchCfdi = @CFDI, dfechaTimbrado = @FechaTimbrado, vchuuid = @UUID " +
                " WHERE iidFactura =  " + IdFactura;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@CFDI", SqlDbType.NText);
            cmd.Parameters.Add("@UUID", SqlDbType.Text);
            cmd.Parameters.Add("@FechaTimbrado", SqlDbType.DateTime);
            cmd.Parameters["@CFDI"].Value = CFDI;
            cmd.Parameters["@UUID"].Value = UUID;
            cmd.Parameters["@FechaTimbrado"].Value = FechaTimbrado;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
               ClsLog.InsertaInformacion(exp.ToString(), "update cfdi xml ");
                return false;
            }
        }
    }
}
