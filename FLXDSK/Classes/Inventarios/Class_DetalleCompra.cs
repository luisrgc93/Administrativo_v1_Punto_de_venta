using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FLXDSK.Classes.Inventarios
{
    class Class_DetalleCompra
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT iidCompra, iidMateriPrima, fCosto, dfechaIn, fCantidad, fImporte FROM catDetalleCompra " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }
        public DataTable getLista(string filtro)
        {
            string sql = " SELECT D.iidCompra, D.iidMateriPrima,  vchCodigo, vchDescripcion, M.fContenido, " +
                  " CASE " +
                     " WHEN U.vchAbreviacion = 'Kg' THEN D.fCantidad/1000 " +
                     " WHEN U.vchAbreviacion = 'Lt' THEN D.fCantidad/1000 " +
                     " ELSE D.fCantidad " +
                  " END fCantidad, D.fCantidad fCantidadMinima, U.iEquivalencia, " +
                  " D.fCosto, D.fImporte, M.iidUnidad, U.vchAbreviacion, U.vchNombre Medida , fContenido " +
             " FROM catMateriaPrima M (NOLOCK),  catUnidadesMetricas U (NOLOCK), catDetalleCompra (NOLOCK) D  " +
             " WHERE D.iidMateriPrima = M.iidMateriPrima  " +
             " AND U.iidUnidad = M.iidUnidad " + filtro;
            return Conexion.Consultasql(sql);
        }
        public bool InsertaInformacion(string iidCompra, string iidMateriPrima, double fCosto, double fCantidad, double fImporte)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catDetalleCompra " +
            " ( iidCompra, iidMateriPrima, fCosto, dfechaIn, fCantidad, fImporte) " +
            " VALUES( " +
            " @iidCompra, @iidMateriPrima, @fCosto, GETDATE(), @fCantidad, @fImporte) ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidCompra", SqlDbType.Int);
            cmd.Parameters.Add("@iidMateriPrima", SqlDbType.Int);
            cmd.Parameters.Add("@fCosto", SqlDbType.Float);
            cmd.Parameters.Add("@fCantidad", SqlDbType.Float);
            cmd.Parameters.Add("@fImporte", SqlDbType.Float);

            cmd.Parameters["@iidCompra"].Value = iidCompra;
            cmd.Parameters["@iidMateriPrima"].Value = iidMateriPrima;
            cmd.Parameters["@fCosto"].Value = fCosto;
            cmd.Parameters["@fCantidad"].Value = fCantidad;
            cmd.Parameters["@fImporte"].Value = fImporte;

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
        public bool ClearDetalle(string IdCompra)
        {
            string sql = "DELETE FROM catDetalleCompra WHERE iidCompra = " + IdCompra;
            return Conexion.InsertaSql(sql);
        }
    }
}
