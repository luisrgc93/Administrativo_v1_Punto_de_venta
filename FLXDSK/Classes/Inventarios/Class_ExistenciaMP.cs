using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Inventarios
{
    class Class_ExistenciaMP
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = " SELECT iidMateriPrima, iidAlmacen, fCantidad, iidUnidadMetrica, dfechaIn, dfechaUp, fContenidoXPieza  " +
            " FROM catExistenciasMateriaPrima (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }

        public bool CleanAlmacen(string iidAlmacen)
        {
            string sql = " DELETE FROM catExistenciasMateriaPrima WHERE iidAlmacen = " + iidAlmacen;
            return Conexion.InsertaSql(sql);
        }
        public bool CleanOnlyProducts(string iidMovimiento, string vchTipo, string iidAlmacen)
        {
            string sql = " UPDATE catExistenciasMateriaPrima SET fCantidad = 0 "+
                " FROM catExistenciasMateriaPrima E, exiDetMovimientoMateriaPrima D " +
                " WHERE E.iidMateriPrima = D.iidMateriPrima " +
                " AND D.iidMovimiento = " + iidMovimiento +
                " AND D.vchTipo = '" + vchTipo + "' " +
                " AND E.iidAlmacen =  " + iidAlmacen;
            return Conexion.InsertaSql(sql);
        }
        
        public bool InsertaInformacion(string iidMateriPrima, string iidAlmacen, string fCantidad, string iidUnidadMetrica, string fContenidoXPieza)
        {
            DataTable dtExis = getListaWhere(" WHERE iidMateriPrima = " + iidMateriPrima + " AND iidAlmacen = " + iidAlmacen);
            if (dtExis.Rows.Count > 0)
                return ActualizaInformacion(iidMateriPrima, iidAlmacen, fCantidad);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO catExistenciasMateriaPrima (iidMateriPrima, iidAlmacen, fCantidad, iidUnidadMetrica, dfechaIn, dfechaUp, fContenidoXPieza ) " +
            " VALUES (@iidMateriPrima, @iidAlmacen, @fCantidad, @iidUnidadMetrica, GETDATE(), GETDATE(), @fContenidoXPieza )";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidMateriPrima", SqlDbType.Int).Value = iidMateriPrima;
            cmd.Parameters.Add("@iidAlmacen", SqlDbType.Int).Value = iidAlmacen;
            cmd.Parameters.Add("@fCantidad", SqlDbType.Float).Value = fCantidad;
            cmd.Parameters.Add("@iidUnidadMetrica", SqlDbType.Int).Value = iidUnidadMetrica;
            cmd.Parameters.Add("@fContenidoXPieza", SqlDbType.Float).Value = fContenidoXPieza;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                ClsLog.InsertaInformacion(exp.Message.ToString(), "ExistenciaMP.Insertar");
                return false;
            }
        }

        public bool ActualizaInformacion(string iidMateriPrima, string iidAlmacen, string fCantidad)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE catExistenciasMateriaPrima SET  dfechaUp = GETDATE(), fCantidad = fCantidad + @fCantidad " +
            " WHERE iidMateriPrima = " + iidMateriPrima + " AND iidAlmacen = " + iidAlmacen;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@fCantidad", SqlDbType.Float).Value = fCantidad;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                ClsLog.InsertaInformacion(exp.Message.ToString(), "ExistenciaMP.Actualizar");
                return false;
            }
        }
        public bool ActualizaRestandoInformacion(string iidMateriPrima, string iidAlmacen, string fCantidad)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE catExistenciasMateriaPrima SET  dfechaUp = GETDATE(), fCantidad = fCantidad - @fCantidad " +
            " WHERE iidMateriPrima = " + iidMateriPrima + " AND iidAlmacen = " + iidAlmacen;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@fCantidad", SqlDbType.Float).Value = fCantidad;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                ClsLog.InsertaInformacion(exp.Message.ToString(), "ExistenciaMP.Actualizar");
                return false;
            }
        }
    }
}
