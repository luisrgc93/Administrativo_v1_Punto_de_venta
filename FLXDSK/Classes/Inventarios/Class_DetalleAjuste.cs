using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Inventarios
{
    class Class_DetalleAjuste
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = " SELECT iidMovimiento, vchTipo, iidMateriPrima, fCantidad  " +
            " FROM exiDetMovimientoMateriaPrima (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }

        public DataTable getListaCnExistencia(string filtro, string IdAlmacen)
        {

            string sql = " " +
            " SELECT D.iidMovimiento, D.vchTipo, D.iidMateriPrima, M.fCosto, vchCodigo, vchDescripcion,  " +
	             " CASE  " +
		            " WHEN U.vchAbreviacion = 'Kg' THEN D.fCantidad/1000 " +
		            " WHEN U.vchAbreviacion = 'Lt' THEN D.fCantidad/1000 " +
		            " ELSE D.fCantidad " +
	             " END fCantidad,	 " +
	             " M.iidUnidad, U.vchAbreviacion, U.vchNombre Medida, " +
                 " CASE  " +
		            " WHEN E.fCantidad IS NULL THEN 0  " +
		            " ELSE  " +
			            " CASE  " +
				            " WHEN U.vchAbreviacion = 'Kg' THEN E.fCantidad /1000 " +
				            " WHEN U.vchAbreviacion = 'Lt' THEN E.fCantidad /1000 " +
				            " ELSE E.fCantidad " +
			            " END  " +
	             " END Existencia,  " +
                 " CASE  " +
                    " WHEN U.vchAbreviacion = 'Kg' THEN D.fExistencia /1000 " +
                    " WHEN U.vchAbreviacion = 'Lt' THEN D.fExistencia /1000 " +
                    " ELSE D.fExistencia " +
                 " END  ExistenciaEnAjuste, " +
                 " CASE U.vchNombre " +
		            " WHEN 'Kilos' THEN 'Gramos'  " +
		            " WHEN 'Litros' THEN 'Mililitros' " +
		            " ELSE U.vchNombre  " +
	              " END UnidadMinima " +
            " FROM catMateriaPrima M (NOLOCK),  catUnidadesMetricas U (NOLOCK), exiDetMovimientoMateriaPrima (NOLOCK) D LEFT OUTER JOIN catExistenciasMateriaPrima E (NOLOCK)  " +
                 " ON D.iidMateriPrima = E.iidMateriPrima   " +
                 " AND E.iidAlmacen  = " + IdAlmacen +
            " WHERE D.iidMateriPrima = M.iidMateriPrima  " +
            " AND U.iidUnidad = M.iidUnidad " + filtro;
            return Conexion.Consultasql(sql);
        }

        public DataTable getLista(string filtro)
        {
            string sql = " SELECT D.iidMovimiento, D.vchTipo, D.iidMateriPrima, D.fCantidad, D.fExistencia,  " +
                " M.iidUnidad, U.iEquivalencia, U.vchNombre Medida, M.vchCodigo, M.vchDescripcion " +
            " FROM catMateriaPrima M (NOLOCK), exiDetMovimientoMateriaPrima (NOLOCK) D, catUnidadesMetricas U (NOLOCK) " +
            " WHERE D.iidMateriPrima = M.iidMateriPrima " +
            " AND  M.iidUnidad = U.iidUnidad " + filtro;
            return Conexion.Consultasql(sql);
        }

        public bool ClearMovimiento(string iidMovimiento, string vchTipo)
        {
            string sql = "DELETE FROM exiDetMovimientoMateriaPrima  WHERE iidMovimiento = " + iidMovimiento + " AND vchTipo = '" + vchTipo + "' ";
            return Conexion.InsertaSql(sql);
        }
        public bool InsertaInformacion(string iidMovimiento, string vchTipo, string iidMateriPrima, string fCantidad, string fExistencia)
        {
            DataTable dtExis = getListaWhere(" WHERE iidMovimiento = " + iidMovimiento + " AND vchTipo = '" + vchTipo + "'  AND iidMateriPrima = " + iidMateriPrima);
            if (dtExis.Rows.Count > 0)
                return ActualizaInformacion(iidMovimiento, vchTipo, iidMateriPrima, fCantidad, fExistencia);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO exiDetMovimientoMateriaPrima (iidMovimiento, vchTipo, iidMateriPrima, fCantidad, fExistencia ) " +
            " VALUES (@iidMovimiento, @vchTipo, @iidMateriPrima, @fCantidad, @fExistencia )";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidMovimiento", SqlDbType.Int).Value = iidMovimiento;
            cmd.Parameters.Add("@vchTipo", SqlDbType.Text).Value = vchTipo;
            cmd.Parameters.Add("@iidMateriPrima", SqlDbType.Int).Value = iidMateriPrima;
            cmd.Parameters.Add("@fCantidad", SqlDbType.Float).Value = fCantidad;
            cmd.Parameters.Add("@fExistencia", SqlDbType.Float).Value = fExistencia;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                ClsLog.InsertaInformacion(exp.Message.ToString(), "DetalleAjuste.Insertar");
                return false;
            }
        }
        public bool ActualizaInformacion(string iidMovimiento, string vchTipo, string iidMateriPrima, string fCantidad, string fExistencia)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE exiDetMovimientoMateriaPrima SET fCantidad= fCantidad + @fCantidad, fExistencia = @fExistencia  " +
            " WHERE iidMovimiento = " + iidMovimiento + " AND vchTipo = '" + vchTipo + "'  AND iidMateriPrima = " + iidMateriPrima ;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@fCantidad", SqlDbType.Float).Value = fCantidad;
            cmd.Parameters.Add("@fExistencia", SqlDbType.Float).Value = fExistencia;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                ClsLog.InsertaInformacion(exp.Message.ToString(), "DetalleAjuste.Actualizar");
                return false;
            }
        }
    }
}
