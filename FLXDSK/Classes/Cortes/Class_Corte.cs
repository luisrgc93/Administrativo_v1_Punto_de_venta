using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Cortes
{
    class Class_Corte
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();


        public double fVentaTotal = 0;

        public double fMontoInicial = 0;

        public double fMontoSalidaDinero = 0;
        public double fMontoEntradaDinero = 0;
        public double fTotalFinal = 0;
        public double fTotalEntregado = 0;


        public double fVentaEfectivo = 0;
        public double fVentaCreditoTC = 0;
        public double fVentaDebito = 0;
        public double fVentaVales = 0;
        public double fVentaCheque = 0;
        public double fVentaOtro = 0;

        public double fEntregaEfectivo = 0;
        public double fEntregaCreditoTC= 0;
        public double fEntregaDebito = 0;
        public double fEntregaVales = 0;
        public double fEntregaCheque = 0;
        public double fEntregaOtro = 0;
        public double fEntregaInicial = 0;

        public double fTotalDescuentos = 0;
        public double fPropinaTotal = 0;
        public double fUtilidadVrsCosto = 0;

        public int iPersonas = 0;
        public double fPromedioPersonas = 0;
        public double fMinPromedioEstancia = 0;

        public int iNumPedidos = 0;
        public double fPromedioConsumo = 0;

        public bool cerrarCaja()
        {
            string sql="UPDATE catAperturass SET dFechaCierre=GETDATE(), siAbierta=0 WHERE siabierta=1";

            return Conexion.InsertaSql(sql);
        }


        public bool InsertaInformacion()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string sql = "INSERT INTO catCortes ( dfechaIn, dfechaUp, iidUsuario, fVentaTotal, " +
            " fMontoSalidaDinero, fMontoEntradaDinero, fTotalFinal, fTotalEntregado, " +
            " fVentaEfectivo, fVentaCreditoTC, fVentaDebito, fVentaVales, fVentaCheque, fVentaOtro, " +
            " fEntregaEfectivo, fEntregaCreditoTC, fEntregaDebito, fEntregaVales, fEntregaCheque, fEntregaOtro, "+
            " fTotalDescuentos, fPropinaTotal, fUtilidadVrsCosto, " +
            " iPersonas, fPromedioPersonas, fMinPromedioEstancia, " +
            " iNumPedidos, fPromedioConsumo, fMontoInicial) " +
            " VALUES ( GETDATE(), GETDATE(), @iidUsuario, @fVentaTotal, " +
            " @fMontoSalidaDinero, @fMontoEntradaDinero, @fTotalFinal, @fTotalEntregado, " +
            " @fVentaEfectivo, @fVentaCreditoTC, @fVentaDebito, @fVentaVales, @fVentaCheque, @fVentaOtro, " +
            " @fEntregaEfectivo, @fEntregaCreditoTC, @fEntregaDebito, @fEntregaVales, @fEntregaCheque, @fEntregaOtro, " +
            " @fTotalDescuentos, @fPropinaTotal, @fUtilidadVrsCosto, " +
            " @iPersonas, @fPromedioPersonas, @fMinPromedioEstancia, " +
            " @iNumPedidos, @fPromedioConsumo, @fMontoInicial) ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int).Value = Class_Session.Idusuario.ToString();
            cmd.Parameters.Add("@fVentaTotal", SqlDbType.Float).Value = fVentaTotal;

            cmd.Parameters.Add("@fMontoSalidaDinero", SqlDbType.Float).Value = fMontoSalidaDinero;
            cmd.Parameters.Add("@fMontoEntradaDinero", SqlDbType.Float).Value = fMontoEntradaDinero;
            cmd.Parameters.Add("@fTotalFinal", SqlDbType.Float).Value = fTotalFinal;
            cmd.Parameters.Add("@fTotalEntregado", SqlDbType.Float).Value = fTotalEntregado;

            cmd.Parameters.Add("@fVentaEfectivo", SqlDbType.Float).Value = fVentaEfectivo;
            cmd.Parameters.Add("@fVentaCreditoTC", SqlDbType.Float).Value = fVentaCreditoTC;
            cmd.Parameters.Add("@fVentaDebito", SqlDbType.Float).Value = fVentaDebito;
            cmd.Parameters.Add("@fVentaVales", SqlDbType.Float).Value = fVentaVales;
            cmd.Parameters.Add("@fVentaCheque", SqlDbType.Float).Value = fVentaCheque;
            cmd.Parameters.Add("@fVentaOtro", SqlDbType.Float).Value = fVentaOtro;

            cmd.Parameters.Add("@fEntregaEfectivo", SqlDbType.Float).Value = fEntregaEfectivo;
            cmd.Parameters.Add("@fEntregaCreditoTC", SqlDbType.Float).Value = fEntregaCreditoTC;
            cmd.Parameters.Add("@fEntregaDebito", SqlDbType.Float).Value = fEntregaDebito;
            cmd.Parameters.Add("@fEntregaVales", SqlDbType.Float).Value = fEntregaVales;
            cmd.Parameters.Add("@fEntregaCheque", SqlDbType.Float).Value = fEntregaCheque;
            cmd.Parameters.Add("@fEntregaOtro", SqlDbType.Float).Value = fEntregaOtro;

            cmd.Parameters.Add("@fTotalDescuentos", SqlDbType.Float).Value = fTotalDescuentos;
            cmd.Parameters.Add("@fPropinaTotal", SqlDbType.Float).Value = fPropinaTotal;
            cmd.Parameters.Add("@fUtilidadVrsCosto", SqlDbType.Float).Value = fUtilidadVrsCosto;

            cmd.Parameters.Add("@iPersonas", SqlDbType.Float).Value = iPersonas;
            cmd.Parameters.Add("@fPromedioPersonas", SqlDbType.Float).Value = fPromedioPersonas;
            cmd.Parameters.Add("@fMinPromedioEstancia", SqlDbType.Float).Value = fMinPromedioEstancia;

            cmd.Parameters.Add("@iNumPedidos", SqlDbType.Int).Value = iNumPedidos;
            cmd.Parameters.Add("@fPromedioConsumo", SqlDbType.Float).Value = fPromedioConsumo;

            cmd.Parameters.Add("@fMontoInicial", SqlDbType.Float).Value = fMontoInicial;

      

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }




        public string getIdCreado()
        {
            DataTable dtInfo = Conexion.Consultasql("SELECT MAX(iidCorte)iidCorte FROM catCortes (NOLOCK) ");
            if (dtInfo.Rows.Count > 0)
            {
                return dtInfo.Rows[0]["iidCorte"].ToString();
            }
            return "";
        }
        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT  CONVERT(varchar(10),dfechaIn,103)dfechaIn103, CONVERT(varchar(5),dfechaIn,108)dfechaIn108,  " +
            " dfechaUp, iidUsuario, fVentaTotal, " +
            " fMontoSalidaDinero, fMontoEntradaDinero, fTotalFinal, fTotalEntregado, " +
            " fVentaEfectivo, fVentaCreditoTC, fVentaDebito, fVentaVales, fVentaCheque, fVentaOtro, " +
            " fEntregaEfectivo, fEntregaCreditoTC, fEntregaDebito, fEntregaVales, fEntregaCheque, fEntregaOtro, " +
            " fTotalDescuentos, fPropinaTotal, fUtilidadVrsCosto, " +
            " iPersonas, fPromedioPersonas, fMinPromedioEstancia, " +
            " iNumPedidos, fPromedioConsumo, fMontoInicial " +
            " FROM catCortes (NOLOCK) " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }
        public DataTable getLista(string Filtro)
        {
            string sql = "SELECT  CONVERT(varchar(10),dfechaIn,103)dfechaIn103, CONVERT(varchar(5),dfechaIn,108)dfechaIn108,  " +
            " dfechaUp, iidUsuario, fVentaTotal, " +
            " fMontoSalidaDinero, fMontoEntradaDinero, fTotalFinal, fTotalEntregado, " +
            " fVentaEfectivo, fVentaCreditoTC, fVentaDebito, fVentaVales, fVentaCheque, fVentaOtro, " +
            " fEntregaEfectivo, fEntregaCreditoTC, fEntregaDebito, fEntregaVales, fEntregaCheque, fEntregaOtro, " +
            " fTotalDescuentos, fPropinaTotal, fUtilidadVrsCosto, " +
            " iPersonas, fPromedioPersonas, fMinPromedioEstancia, " +
            " iNumPedidos, fPromedioConsumo " +
            " FROM catCortes (NOLOCK) C " + 
            " WHERE 1 = 1 "  + 
            " " +Filtro;
            return Conexion.Consultasql(sql);
        }
        /*
        public string getVentas() 
        {
            DataTable dt = new DataTable();
            string sql = " select distinct isnull(SUM(P.fTotal),0) Total " +
                         " from catPedidos P " +
                         " where P.SiPagado = 1 " +
                         " and P.iidCorte = 0";
            try
            {

                dt = Conexion.Consultasql(sql);
                DataRow row = dt.Rows[0];
                return row["Total"].ToString();

            }
            catch
            {
                return "0";
            }
        }
        public string getDescuento()
        {
            DataTable dt = new DataTable();
            string sql = " select distinct isnull(SUM(P.fDescuento),0) Total_Descuento " +
                         " from catPedidos P " +
                         " where P.SiPagado = 1 " +
                         " and P.iidCorte = 0 ";
            try
            {

                dt = Conexion.Consultasql(sql);
                DataRow row = dt.Rows[0];
                return row["Total_Descuento"].ToString();

            }
            catch (Exception Exp)
            {
                return "0";
            }
        }
        public string getPropinas()
        {
            DataTable dt = new DataTable();
            string sql = " select distinct isnull(SUM(P.fPropina),0) Total_Propinas " +
                         " from catPedidos P " +
                         " where P.SiPagado = 1 " +
                         " and P.iidCorte = 0 ";
            try
            {

                dt = Conexion.Consultasql(sql);
                DataRow row = dt.Rows[0];
                return row["Total_Propinas"].ToString();

            }
            catch (Exception Exp)
            {
                return "0";
            }
        }
        public string getCantidadPersonas()
        {
            DataTable dt = new DataTable();
            string sql = " select distinct isnull(SUM(P.iNumPersonas),0) cant_Personas " +
                         " from catPedidos P " +
                         " where P.SiPagado = 1 " +
                         " and P.iidCorte = 0 ";
            try
            {

                dt = Conexion.Consultasql(sql);
                DataRow row = dt.Rows[0];
                return row["cant_Personas"].ToString();

            }
            catch (Exception Exp)
            {
                return "0";
            }
        }
        
        public DataTable getDtByDivisaAndMetodoPago(string metodoPago)
        {
            string sql = "select ISNULL(SUM(V.fmonto),0) suma from CatPagosVentas V, catPedidos P where V.iidPedido = P.iidPedido and P.iidCorte = 0 and V.iidMetodoPago in (" + metodoPago + ") and P.SiPagado = 1";
            return Conexion.Consultasql(sql);
        }

        public DataTable getIdsVentaForCorte()
        {
            string sql = "select iidPedido id from catPedidos where SiPagado=1 and iidCorte = 0";
            return Conexion.Consultasql(sql);
        }
        public DataTable getIdsProductos(string idPedido)
        {
            string sql = "select iidProducto id, fCantidad cantidad from catDetallePedido where iidPedido = " + idPedido;
            return Conexion.Consultasql(sql);
        }
        public DataTable getPrecioProductos(string idProducto)
        {
            string sql = "select fCosto costo from catProductos where iidProducto = " + idProducto;
            return Conexion.Consultasql(sql);
        }
        

        public bool insertaIdVentaCorte(string idVenta, string idCorte)
        {
            string sql = " update catPedidos set iidCorte=" + idCorte + " where iidPedido=" + idVenta;
            return Conexion.InsertaSql(sql);
        }
        

        public DataTable getInfoCorte(string idCorte)
        {
            string sql = " select C.iidCorte, CONVERT(VARCHAR(10),C.dfechaIn,103) fecha, convert(varchar(5),C.dfechaIn,108) hora, C.fVentaTotal, C.fMontoEfectivo, C.fMontoTC, C.fMontoOtros, " +
                         "        C.fGanancia, C.fPropinas, C.fMontoEntregado, U.vchNombre, C.fDescuentoTotal " +
                         " from catCortes C, catUsuarios U " +
                         " where iidCorte = " + idCorte + " and C.iidUsuario = U.iidUsuario";
            return Conexion.Consultasql(sql);
        }*/
    }
}
