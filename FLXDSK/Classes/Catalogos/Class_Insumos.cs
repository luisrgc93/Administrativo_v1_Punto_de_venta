using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Catalogos
{
    class Class_Insumos
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public bool inserta_insumos(DataTable info)
        {
            DataRow Row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catInsumos(iidTipoInsumo, vchNombre, vchcodigo, fCantidad, fCostoUnitario, iidAlmacen, iidEstatus,dfechaIn,dfechaUp) " +
                         " VALUES (@idcategoria,@nombre,@codigo,@cantidad,@costo,@almacen,1,GETDATE(),GETDATE()) ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idcategoria", SqlDbType.Int);
            cmd.Parameters.Add("@nombre", SqlDbType.Text);
            cmd.Parameters.Add("@costo", SqlDbType.Float);
            cmd.Parameters.Add("@cantidad", SqlDbType.Float);
            cmd.Parameters.Add("@codigo", SqlDbType.Text);
            cmd.Parameters.Add("@almacen", SqlDbType.Int);

            ///
            cmd.Parameters["@idcategoria"].Value = Row["idcategoria"].ToString();
            cmd.Parameters["@nombre"].Value = Row["nombre"].ToString();
            cmd.Parameters["@costo"].Value = Row["costo"].ToString();
            cmd.Parameters["@cantidad"].Value = Row["cantidad"].ToString();
            cmd.Parameters["@codigo"].Value = Row["codigo"].ToString();
            cmd.Parameters["@almacen"].Value = Row["almacen"].ToString();

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

        public bool borrar_insumo(string idinsumo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catInsumos SET iidEstatus = 2, dFechaUp = GETDATE() WHERE iidInsumos = " + idinsumo;

            cmd.CommandText = sql;

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

        public bool actualiza_insumo(DataTable info)
        {
            DataRow Row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catInsumos SET iidTipoInsumo=@idcategoria, vchNombre=@nombre, vchcodigo=@codigo, fCantidad=@cantidad, fCostoUnitario=@costo, iidAlmacen=@almacen ,dfechaUp=GETDATE() WHERE iidInsumos = @idinsumo";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idinsumo", SqlDbType.Int);
            cmd.Parameters.Add("@idcategoria", SqlDbType.Int);
            cmd.Parameters.Add("@nombre", SqlDbType.Text);
            cmd.Parameters.Add("@costo", SqlDbType.Float);
            cmd.Parameters.Add("@cantidad", SqlDbType.Float);
            cmd.Parameters.Add("@codigo", SqlDbType.Text);
            cmd.Parameters.Add("@almacen", SqlDbType.Int);

            ///
            cmd.Parameters["@idinsumo"].Value = Row["idinsumo"].ToString();
            cmd.Parameters["@idcategoria"].Value = Row["idcategoria"].ToString();
            cmd.Parameters["@nombre"].Value = Row["nombre"].ToString();
            cmd.Parameters["@costo"].Value = Row["costo"].ToString();
            cmd.Parameters["@cantidad"].Value = Row["cantidad"].ToString();
            cmd.Parameters["@codigo"].Value = Row["codigo"].ToString();
            cmd.Parameters["@almacen"].Value = Row["almacen"].ToString();

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

        public bool existe_insumo(string nombre)
        {
            string sql = "SELECT iidInsumos FROM catInsumos WHERE vchNombre = '" + nombre + "' and iidEstatus = 1";

            int numero = Conexion.NumeroFilas(sql);
            if (numero != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable obtener_insumos(string idinsumo)
        {

            string sql = " SELECT iidInsumos, iidTipoInsumo, vchCodigo, " +
                         " vchNombre, fCantidad, fCostoUnitario " +
                         " FROM catInsumos " +
                         " WHERE iidEstatus = 1 " +
                         " AND iidInsumos = " + idinsumo;

            return Conexion.Consultasql(sql);
        }

        public DataTable getTipoInsumosAll()
        {

            string sql = " SELECT 0 as id, 'Seleccionar' as nombre  " +
                         " UNION ALL" +
                         " SELECT iidTipoInsumo as id, vchNombre as nombre " +
                         " FROM catTiposInsumos " +
                         " WHERE iidEstatus = 1 ";

            return Conexion.Consultasql(sql);
        }

        /*********************************categorias********************************/

        public bool inserta_tipo_insumos(string nombre, string descripcion)
        {           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catTiposInsumos( vchNombre, vchDescripcion, iidEstatus,dfechaIn,dfechaUp) " +
                         " VALUES ('" + nombre +"','" + descripcion + "',1,GETDATE(),GETDATE()) ";

            cmd.CommandText = sql;
            
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

        public bool borrar_tipo_insumo(string idtipoinsumo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catTiposInsumos SET iidEstatus = 2, dFechaUp = GETDATE() WHERE iidTipoInsumo = " + idtipoinsumo;

            cmd.CommandText = sql;

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

        public bool actualiza_tipo_insumo(string nombre, string descripcion, string idtipoinsumo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catTiposInsumos SET dfechaUp = GETDATE(), vchNombre = '" + nombre + "', vchDescripcion = '" + descripcion + "' WHERE iidTipoInsumo = " + idtipoinsumo;

            cmd.CommandText = sql;

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

        public bool existe_tipo_insumo(string nombre)
        {
            string sql = "SELECT iidTipoInsumo FROM catTiposInsumos WHERE vchNombre = '" + nombre + "' and iidEstatus = 1";

            int numero = Conexion.NumeroFilas(sql);
            if (numero != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable obtener_tipo_insumos(string idtipoinsumo)
        {

            string sql = " SELECT iidTipoInsumo, vchNombre, vchDescripcion " +
                         " FROM catTiposInsumos " +
                         " WHERE iidEstatus = 1 " +
                         " AND iidTipoInsumo = " + idtipoinsumo;

            return Conexion.Consultasql(sql);
        }

        /*****************************compras*************************************/

        public DataTable ultimo_insumos_guardado()
        {

            string sql = " SELECT iidInsumos, iidTipoInsumo, vchCodigo, " +
                         " vchNombre, fCantidad, fCostoUnitario " +
                         " FROM catInsumos " +
                         " WHERE iidEstatus = 1 " +
                         " ORDER BY dFechaIn DESC ";

            return Conexion.Consultasql(sql);
        }
    }
}
