using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.Cortes
{
    class Class_ProcesoCorte
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();


        public DataTable getMontosIniciales()
        {
            string sql = " SELECT fMontoInicial, (vchNombres+' '+vchApellidoPat+' '+vchApellidoMat) nombre ,  dFechaApertura" +
            " FROM catAperturass a, catPersonal p" +
            " WHERE siAbierta=1   and a.iidPersonal= p.iidPersonal   ";
          //  " AND convert(date ,dFechaApertura)= convert(date ,getdate())";
            return Conexion.Consultasql(sql);
        }


        public DataTable getInfoPedidos()
        {
            string sql = "SELECT P.iidPedido, P.iNumPersonas, P.fTotalEntrega " +
            " FROM catPedidos (NOLOCK) P   " +
            " WHERE P.iidEstatus = 1   " +
            " AND P.siPagado = 1 " +
            " AND P.iidCorte = 0 ";
            return Conexion.Consultasql(sql);
        }
        public DataTable dtInfoPedidoTotales()
        {
            string sql = " SELECT COUNT(*)NumPedidos, AVG(iNumPersonas)PromedioPersonas,  " +
                " AVG(fTotal)PromedioConsumo, " +
	            " SUM(fTotal)VentaTotal, " +
	            " SUM(fDescuento)fDescuento, " +
	            " SUM(fPropina)fPropina, " +
	            " AVG(minutos)minutos  " +
            " FROM(	 " +
	            " SELECT iidPedido, P.iNumPersonas, P.fTotal, P.fDescuento, P.fPropina, DATEDIFF(mi,dfechaIn,dfechaFin)minutos  " +
	            " FROM catPedidos (NOLOCK) P   " +
	            " WHERE P.iidEstatus = 1  " + 
	            " AND P.siPagado = 1  " +
	            " AND P.iidCorte = 0 " +
            " ) AS T1";
            return Conexion.Consultasql(sql);
        }
        public DataTable dtMovimientos()
        {
            string sql = "SELECT SUM(Entrada)Entrada, SUM(Salida)Salida " +
            " FROM( " +
            " SELECT SUM(fMonto)Entrada, 0 Salida from catMovimientoDinero WHERE iidEstatus = 1 AND iidCorte=0 AND siEntrada=1 " +
            " UNION ALL " +
            " SELECT 0 Entrada, SUM(fMonto) Salida from catMovimientoDinero WHERE iidEstatus = 1 AND iidCorte=0 AND siEntrada=0 " +
            " ) as T1";
            return Conexion.Consultasql(sql);
        }


        public DataTable getTotalesFormas()
        {
            string sql = " SELECT G.iidFormaPago, sum(G.fMonto)total " +
            " FROM CatPagosVentas G (NOLOCK), catPedidos (NOLOCK) P  " +
            " WHERE G.iidPedido = P.iidPedido " +
            " AND P.iidEstatus = 1   " +
            " AND G.iidEstatus = 1  " +
            " AND P.siPagado = 1 " +
            " AND P.iidCorte = 0 " +
            " GROUP BY G.iidFormaPago ";
            return Conexion.Consultasql(sql);
        }





        /// <summary>
        /// /////
        /// </summary>
        /// <param name="IdCorte"></param>
        /// <returns></returns>
        public bool SetPedidosCorte(string IdCorte)
        {
            string sql=" UPDATE catPedidos SET  iidCorte = " +IdCorte +
            " WHERE iidEstatus = 1   " +
            " AND siPagado = 1 " +
            " AND iidCorte = 0 ";
            return Conexion.InsertaSql(sql);
        }
        public bool SetMovimientosCorte(string IdCorte)
        {
            string sql = " UPDATE catMovimientoDinero SET  iidCorte = " + IdCorte +
            " WHERE iidEstatus = 1   " +
            " AND iidCorte = 0 ";
            return Conexion.InsertaSql(sql);
        }
    }
}
