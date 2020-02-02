using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Catalogos
{
    class Class_Activos
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        public bool Guardar(string descripcion, string cantidad, string precio, string tipo, string idAlmacen)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catActivos (iidTipoActivo, dfechaIn, dfechaup, vchDescripcion, fCantidad, fCostoUnitario, iidEstatus, iidUsuario, iidAlmacen) " +
                         " VALUES ( @idTipo, GETDATE(), GETDATE(), @vchDescripcion, @cantidad, @precio, 1, @iidUsuario, @idalmacen )";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idTipo", SqlDbType.Int);
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text);
            cmd.Parameters.Add("@cantidad", SqlDbType.Int);
            cmd.Parameters.Add("@precio", SqlDbType.Float);
            cmd.Parameters.Add("@idalmacen", SqlDbType.Int);
            ///
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@idTipo"].Value = tipo;
            cmd.Parameters["@vchDescripcion"].Value = descripcion.Trim();
            cmd.Parameters["@cantidad"].Value = cantidad;
            cmd.Parameters["@precio"].Value = precio;
            cmd.Parameters["@idalmacen"].Value = idAlmacen;
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
        public bool Actializa(string descripcion, string cantidad, string precio, string tipo, string idalmacen, string id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catActivos set iidTipoActivo = @idTipo, dfechaup = GETDATE(), " +
                         " vchDescripcion = @vchDescripcion , fCantidad = @cantidad, fCostoUnitario =@precio,  iidUsuario = @iidUsuario, iidAlmacen = @idalmacen " +
                         " WHERE iidActivo = "+id;

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idTipo", SqlDbType.Int);
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text);
            cmd.Parameters.Add("@cantidad", SqlDbType.Int);
            cmd.Parameters.Add("@precio", SqlDbType.Float);
            cmd.Parameters.Add("@idalmacen", SqlDbType.Int);
            ///
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@idTipo"].Value = tipo;
            cmd.Parameters["@vchDescripcion"].Value = descripcion.Trim();
            cmd.Parameters["@cantidad"].Value = cantidad;
            cmd.Parameters["@precio"].Value = precio;
            cmd.Parameters["@idalmacen"].Value = idalmacen;
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
        public DataTable getInfoById(string id) {
            string sql = "SELECT  iidActivo, iidTipoActivo, dfechaIn, dfechaup, vchDescripcion, iidAlmacen,  " +
                " fCantidad, fCostoUnitario, iidEstatus, iidUsuario, fCantidad * fCostoUnitario as importe " +
                " FROM catActivos (NOLOCK) " +
                " WHERE iidActivo = " + id;
            return Conexion.Consultasql(sql);
        }
        public bool ExisteCategoriaText(string text, string idalmacen) {

            string sql = "select iidActivo FROM catActivos (NOLOCK) WHERE iidEstatus = 1 AND vchDEscripcion= '" + text + "' AND iidAlmacen = '" + idalmacen + "' ";
            int numero = Conexion.NumeroFilas(sql);
            if (numero == 0) return false; else return true;
        }
        public bool BorrarRegistro(string id) {
            string sql = "UPDATE  catActivos SET iidEstatus = 2 WHERE  iidActivo = " + id;
            return Conexion.InsertaSql(sql);
        }
        public DataTable Reporte_Activos() {
            string sql = " select   A.iidActivo Id, convert(varchar(10),A.dfechaIn,103)Creado, convert(varchar(10),A.dfechaup,103)Modificado,   T.vchDescripcion Categoria, " +
                        "         A.vchDescripcion Activo,  " +
                        "         fCantidad Cantidad, fCostoUnitario PrecioUnitario,  " +
                        "         fCantidad * fCostoUnitario as Total, " +
                        "         L.vchNombre Almacen " +
                        "     FROM catActivos A left outer join catAlmacenes L on A.iidAlmacen = L.iidAlmacen, " +
                        "     catTiposActivos T " +
                        "     WHERE T.iidTipoActivo = A.iidTipoActivo  " +
                        "     AND A.iidEstatus= 1  " +
                        " ORDER BY  A.iidActivo DESC ";
            return Conexion.Consultasql(sql);
        }
        public bool PuedoPasarCantidad(string activo, string almacen, double cantidad) {
            string sql = "select fCantidad from catActivos (NOLOCK) WHERE iidAlmacen = '" + almacen + "' AND iidActivo =  " + activo;
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    double cantidExiste = Convert.ToDouble(dt.Rows[0]["fCantidad"].ToString());
                    if (cantidExiste >= cantidad)
                        return true;
                    else return false;
                }
                catch {
                    return false;
                }
            }
            else return false;
        }
        public bool MueveMercancia(string idactivo,string idAlmacenActual, string idAlmacenDestsino, double cantidadPasar)
        {
            string idusuario = Class_Session.Idusuario.ToString();
            string sql = "SELECT iidAlmacen FROM catActivos (NOLOCK) WHERE iidAlmacen = '" + idAlmacenDestsino + "' AND iidActivo =  " + idactivo;
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0)
            {
                //Actualizamos
                sql = "update catActivos set fCantidad = fCantidad + " + cantidadPasar + " " +
                    " WHERE iidAlmacen = " + idAlmacenDestsino + " AND iidActivo =  " + idactivo;
                bool resp = Conexion.InsertaSql(sql);
                if (resp)
                {
                    sql = "update catActivos set fCantidad = fCantidad - " + cantidadPasar + " " +
                  " WHERE iidAlmacen = " + idAlmacenActual + " AND iidActivo =  " + idactivo;
                    if (Conexion.InsertaSql(sql))
                        return true;
                    else
                        return false;
                }
                else return false;
            }
            else {
                ///No existe en ese almacen insertamos
                sql = "insert into catActivos " +
                    " SELECT iidTipoActivo,GETDATE(),GETDATE(),vchDescripcion,'" + cantidadPasar + "', fcostoUnitario, iidEstatus, '" + idusuario + "', '" + idAlmacenDestsino + "' " +
                    " FROM catActivos (NOLOCK) " +
                    " WHERE iidAlmacen = " + idAlmacenActual + " AND iidActivo =  " + idactivo;
                bool resp = Conexion.InsertaSql(sql);
                if (resp)
                {
                    sql = "update catActivos set fCantidad = fCantidad - " + cantidadPasar + " "+
                    " WHERE iidAlmacen = " + idAlmacenActual + " AND iidActivo =  " + idactivo;
                    if (Conexion.InsertaSql(sql))
                        return true;
                    else
                        return false;
                }
                else return false;
            }
        }
    }
}
