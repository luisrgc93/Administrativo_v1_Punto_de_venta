using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Inventarios
{
    class Class_DetalleTraspasos
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();


        public bool ClearMovimiento(string Id)
        {
            string sql = "DELETE FROM DetalleTraspaso WHERE iidFolio = " + Id;
            return Conexion.InsertaSql(sql);
        }
        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = "SELECT iidFolio, iidMateriPrima, fCantidad_Enviada, fCantidad_Recibida " +
            " FROM DetalleTraspaso (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public DataTable getLista(string filtro)
        {
            string sql = " " +
            " SELECT D.iidFolio, D.iidMateriPrima, D.fCantidad_Enviada, D.fCantidad_Recibida, " +
                " U.vchNombre Medida, " +
                " CASE " +
                     " WHEN U.vchAbreviacion = 'Kg' THEN D.fCantidad_Enviada/1000  " +
                     " WHEN U.vchAbreviacion = 'Lt' THEN D.fCantidad_Enviada/1000  " +
                     " ELSE D.fCantidad_Enviada " +
                " END fCantidad_Enviada_Group," +
                " M.vchCodigo, M.vchDescripcion, M.fCosto, M.iidUnidad, M.siInventariar " +
            " FROM DetalleTraspaso (NOLOCK) D, catMateriaPrima M (NOLOCK), catUnidadesMetricas U (NOLOCK) " + 
            " WHERE D.iidMateriPrima = M.iidMateriPrima  " +
            " AND U.iidUnidad = M.iidUnidad   " +
            " " + filtro;
            return Conexion.Consultasql(sql);
        }
        public DataTable getListaExistencias(string filtro, string iidAlmacen)
        {
            string sql = " " +
            " SELECT D.iidFolio, D.iidMateriPrima, D.fCantidad_Enviada, D.fCantidad_Recibida, " +
                " CASE " +
                     " WHEN U.vchAbreviacion = 'Kg' THEN D.fCantidad_Enviada/1000  " +
                     " WHEN U.vchAbreviacion = 'Lt' THEN D.fCantidad_Enviada/1000  " +
                     " ELSE D.fCantidad_Enviada " +
                " END Envia," +
                " M.vchCodigo, M.vchDescripcion, M.fCosto, M.iidUnidad, M.siInventariar, " +
                " U.vchNombre Medida, " +
                " E.fCantidad Existencia, " +
                " CASE " +
                      " WHEN U.vchAbreviacion = 'Kg' " +
                            " THEN  CASE WHEN E.fCantidad IS NULL THEN 0 WHEN E.fCantidad = 0 THEN 0 ELSE E.fCantidad/1000 END " +
                      " WHEN U.vchAbreviacion = 'Lt' " +
                            " THEN CASE WHEN E.fCantidad IS NULL THEN 0 WHEN E.fCantidad = 0 THEN 0 ELSE E.fCantidad/1000 END  " +
                   " ELSE E.fCantidad " +
                " END ExistenciaGroup, " +
                " CASE U.vchNombre  " +
                    " WHEN 'Kilos' THEN 'Gramos'  " +
		            " WHEN 'Litros' THEN 'Mililitros' " +
		            " ELSE U.vchNombre " +
	            " END UnidadMinima " + 
            " FROM DetalleTraspaso (NOLOCK) D, catUnidadesMetricas U (NOLOCK), catMateriaPrima M (NOLOCK) LEFT OUTER JOIN catExistenciasMateriaPrima E (NOLOCK) ON M.iidMateriPrima = E.iidMateriPrima  AND E.iidAlmacen = " + iidAlmacen + " " +
            " WHERE D.iidMateriPrima = M.iidMateriPrima  " +
            " AND U.iidUnidad = M.iidUnidad   " +
            " " + filtro;
            return Conexion.Consultasql(sql);
        }
        public DataTable ProcesoGeneraTrasPaso(string filtro, string iidAlmacen)
        {
            string sql = " " +
            " SELECT M.iidMateriPrima, M.vchCodigo, M.vchDescripcion, M.fCosto, M.iidUnidad, M.siInventariar, " +
                " E.fCantidad Existencia, " +
                " CASE " +
                      " WHEN U.vchAbreviacion = 'Kg' " +
                            " THEN  CASE WHEN E.fCantidad IS NULL THEN 0 WHEN E.fCantidad = 0 THEN 0 ELSE E.fCantidad/1000 END " +
                      " WHEN U.vchAbreviacion = 'Lt' " +
                            " THEN CASE WHEN E.fCantidad IS NULL THEN 0 WHEN E.fCantidad = 0 THEN 0 ELSE E.fCantidad/1000 END  " +
                   " ELSE E.fCantidad " +
                " END ExistenciaGroup, " +
                " CASE U.vchNombre " +
		            " WHEN 'Kilos' THEN 'Gramos'  " +
		            " WHEN 'Litros' THEN 'Mililitros' " +
                    " ELSE U.vchNombre " +
	            " END UnidadMinima " + 
            " FROM catUnidadesMetricas U (NOLOCK), catMateriaPrima M (NOLOCK) LEFT OUTER JOIN catExistenciasMateriaPrima E (NOLOCK) ON M.iidMateriPrima = E.iidMateriPrima  AND E.iidAlmacen = " + iidAlmacen + " " +
            " WHERE U.iidUnidad = M.iidUnidad  " +
            " AND M.iidEstatus = 1    " +
            " " + filtro;
            return Conexion.Consultasql(sql);
        }



        public bool InsertaInformacion(string iidFolio, string iidMateriPrima, string Envia)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO DetalleTraspaso " +
            " (iidFolio, iidMateriPrima, fCantidad_Enviada, fCantidad_Recibida ) " +
            " VALUES( " +
            " @iidFolio, @iidMateriPrima, @fCantidad_Enviada, @fCantidad_Recibida ) ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidFolio", SqlDbType.Int);
            cmd.Parameters.Add("@iidMateriPrima", SqlDbType.Int);
            cmd.Parameters.Add("@fCantidad_Enviada", SqlDbType.Float);
            cmd.Parameters.Add("@fCantidad_Recibida", SqlDbType.Float);
            ///
            cmd.Parameters["@iidFolio"].Value = iidFolio;
            cmd.Parameters["@iidMateriPrima"].Value = iidMateriPrima;
            cmd.Parameters["@fCantidad_Enviada"].Value = Envia;
            cmd.Parameters["@fCantidad_Recibida"].Value = "0"; 

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
