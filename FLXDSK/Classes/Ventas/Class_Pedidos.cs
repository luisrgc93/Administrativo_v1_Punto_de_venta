using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Ventas
{
    class Class_Pedidos
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();



        public DataTable Rep_MeserosEnCortes(string filtro)
        {
            string sql = " SELECT P.iidPersonal, SUM(P.fTotal)fTotal, SUM(P.fPropina) Propina, " +
                " MAX(PE.vchNombres)+' '+MAX(PE.vchApellidoPat)+' '+MAX(PE.vchApellidoMat) Mesero, " +
                " MAX(U.fPropina)Porcentaje "  +
            " FROM catPedidos (NOLOCK) P ,catPersonal PE (NOLOCK), catPuestos U (NOLOCK) " +
            " WHERE P.iidEstatus = 1 " +
            " AND P.iidPersonal = PE.iidPersonal " +
            " AND U.iidPuesto = PE.iidPuesto " +
            " " + filtro  +
            " GROUP BY P.iidPersonal ";
            return Conexion.Consultasql(sql);
        }



        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = " " +
               " SELECT P.iidPedido, CONVERT(varchar(10),P.dfechaIn,103)dfechaIn103, " +
                   " CONVERT(varchar(5),P.dfechaIn,108)dfechaIn108, " +
                   " P.iidMesa, P.iidPersonal, P.siPagado, " +
                   " CASE WHEN P.fSubtotal IS NULL THEN 0 ELSE P.fSubtotal END fSubtotal, " +
                   " CASE WHEN P.fDescuento IS NULL THEN 0 ELSE P.fDescuento END fDescuento, " +
                   " CASE WHEN P.fTotal IS NULL THEN 0 ELSE P.fTotal END fTotal, " +
                   " CASE WHEN P.fPropina IS NULL THEN 0 ELSE P.fPropina END fPropina " +
               " FROM catPedidos (NOLOCK) P " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public DataTable getLista(string filtro)
        {
            string sql = " " +
            " SELECT P.iidPedido, E.vchKey vchkey, E.iidEmpresa ID_EMPRESA, p.fTotalIVA IVA, " +
                " CONVERT(varchar(10),P.dfechaIn,103)dfechaIn103, " +
                " CONVERT(varchar(19),P.dfechaIn,126)dfechaIn126, " +
                " CONVERT(varchar(5),P.dfechaIn,108)dfechaIn108, " +
                " P.iidMesa, P.iidPersonal, P.siPagado, " +
                " CASE WHEN P.fSubtotal IS NULL THEN 0 ELSE P.fSubtotal END fSubtotal, " +
                " CASE WHEN P.fDescuento IS NULL THEN 0 ELSE P.fDescuento END fDescuento, " +
                " CASE WHEN P.fTotal IS NULL THEN 0 ELSE P.fTotal END fTotal, " +
                " CASE WHEN P.fPropina IS NULL THEN 0 ELSE P.fPropina END fPropina, " +
                " M.vchDescripcion Mesa, A.vchNombre Area, " +
                " PE.vchNombres+' '+PE.vchApellidoPat+' '+PE.vchApellidoMat Mesero " +
            " FROM catPedidos (NOLOCK) P, catMesas M (NOLOCK), catAreas A  (NOLOCK), catPersonal PE (NOLOCK), catEmpresas E " +
            " WHERE P.iidEstatus = 1 " +
            " AND P.iidMesa = M.iidMesa " +
            " AND A.iidArea = M.iidArea " +
            " AND P.iidPersonal = PE.iidPersonal " +
            "  " + filtro;
            return Conexion.Consultasql(sql);
        }
        public string getSubMesaId(string idmesa, string idpedido)
        {
            string sql = "SELECT iidPedido FROM catPedidos (NOLOCK) WHERE iidMesa =  " + idmesa + " AND siPagado = 0 ORDER BY iidPedido ASC ";
            DataTable dtListaPedidos = Conexion.Consultasql(sql);
            if (dtListaPedidos.Rows.Count > 1)
            {
                int contador = 0;
                foreach (DataRow Row in dtListaPedidos.Rows)
                {
                    contador++;
                    if (idpedido == Row["iidPedido"].ToString())
                    {
                        return " / " + contador;
                    }
                }
                return "";
            }

            return "";
        }

        public bool CierraVenta(string IdPedido, string fTotalEntrega, string fCambio, double fPropina, double fGanancia)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE catPedidos SET fTotalEntrega = @fTotalEntrega, fCambio = @fCambio, " +
            " siPagado = 1, dfechaUp = GETDATE(), dfechaFin = GETDATE(), fPropina = @fPropina, fGanancia = @fGanancia " +
            " WHERE iidPedido = " + IdPedido;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@fCambio", SqlDbType.Float);
            cmd.Parameters.Add("@fTotalEntrega", SqlDbType.Float);
            cmd.Parameters.Add("@fPropina", SqlDbType.Float);
            cmd.Parameters.Add("@fGanancia", SqlDbType.Float);
            cmd.Parameters["@fCambio"].Value = fCambio;
            cmd.Parameters["@fTotalEntrega"].Value = fTotalEntrega;
            cmd.Parameters["@fPropina"].Value = fPropina;
            cmd.Parameters["@fGanancia"].Value = fGanancia;
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
        public bool ActualizaPropina(string IdPedido, double fPropina)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE catPedidos SET  fPropina = @fPropina " +
            " WHERE iidPedido = " + IdPedido;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@fPropina", SqlDbType.Float);
            cmd.Parameters["@fPropina"].Value = fPropina;
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
    }
}
