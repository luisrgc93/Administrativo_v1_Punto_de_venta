using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace FLXDSK.Classes.Catalogos
{
    class Class_Movimientos
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Existencias.Class_Existencias ClsExt = new Existencias.Class_Existencias();

        public DataTable getAlmacenesAll()
        {
            string sql = " SELECT 0 AS id, 'Seleccionar' AS nombre " +
                         " UNION ALL " +
                         " SELECT iidAlmacen AS id, vchNombre AS nombre " +
                         " FROM catAlmacenes " +
                         " WHERE iidEstatus = 1 ";

            return Conexion.Consultasql(sql);            
        }

        public DataTable obtener_movimiento(string idmovimiento)
        {
            string sql = " SELECT iidAlmacenDestino, iidAlmacenOrigen, siTerminado, " +
                         " CONVERT(VARCHAR(10),dfechaIn,103) AS dfechaIn " +
                         " FROM catMovimientos " +
                         " WHERE iidMovimiento =  " + idmovimiento;

            return Conexion.Consultasql(sql);
        }

        public bool inserta_movimiento(string origen, string destino)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catMovimientos(iidAlmacenOrigen, iidAlmacenDestino, iidEstatus, siTerminado, dfechaIn, dFechaUp) VALUES (" + origen + "," + destino + ",1,0,GETDATE(),GETDATE())";

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

        public bool inserta_detalle_movimiento(DataTable info)
        {
            DataRow Row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO RelAlmacenMovimiento(iidMovimiento, iTipo_Producto, iidProducto, iCantidad, iidUnidad, dfechaIn, dFechaUp) " +
                         " VALUES (@idmovimiento, @idtipo, @idproducto, @cantidad, @idunidad, GETDATE(), GETDATE())";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idmovimiento", SqlDbType.Int);
            cmd.Parameters.Add("@idtipo", SqlDbType.Int);
            cmd.Parameters.Add("@idproducto", SqlDbType.Int);
            cmd.Parameters.Add("@cantidad", SqlDbType.Float);
            cmd.Parameters.Add("@idunidad", SqlDbType.Int);

            ///
            cmd.Parameters["@idmovimiento"].Value = Row["idmovimiento"].ToString();
            cmd.Parameters["@idtipo"].Value = Row["idtipo"].ToString();
            cmd.Parameters["@idproducto"].Value = Row["idproducto"].ToString();
            cmd.Parameters["@cantidad"].Value = Row["cantidad"].ToString();
            cmd.Parameters["@idunidad"].Value = Row["idunidad"].ToString();

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

        public bool borrar_movimiento(string idmovimiento)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catMovimientos SET iidEstatus = 2, dFechaUp = GETDATE() WHERE iidMovimiento = " + idmovimiento;

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

        public bool terminar_movimiento(string idmovimiento)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catMovimientos SET siTerminado = 1, dFechaUp = GETDATE() WHERE iidMovimiento = " + idmovimiento;

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

        public bool movimiento_terminado(string idmovimiento)
        {
            string sql = " SELECT iidMovimiento FROM catMovimientos WHERE siTerminado = 1 AND iidMovimiento = " + idmovimiento;

            int numero = Conexion.NumeroFilas(sql);

            if (numero == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string ultimo_movimiento() 
        { 
            DataTable dt = new DataTable();
            string sql = " SELECT TOP 1 iidMovimiento FROM catMovimientos WHERE iidEstatus = 1 ORDER BY dfechaIn DESC ";
            try
            {

                dt = Conexion.Consultasql(sql);
                DataRow row = dt.Rows[0];
                return row["iidMovimiento"].ToString();

            }
            catch
            {
                return "";
            }
        }

        public bool restar_movimiento(DataTable info)
        {
            DataRow Row = info.Rows[0];

            string mover = Row["idtipo"].ToString();
            string idalmacen = Row["idalmacen"].ToString();
            string idproducto = Row["idproducto"].ToString();
            string cantidad = Row["cantidad"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "";
            if (ClsExt.existe_producto(idproducto, idalmacen, mover))
            {
                if (mover == "1")
                {
                    sql = " UPDATE catExistenciasMateriaPrima SET fCantidad = @cantidad, dfechaup = GETDATE() WHERE iidMateriPrima = @idproducto AND iidAlmacen = @idalmacenes ";
                }
                else
                {
                    sql = " UPDATE catExistencias SET fCantidad = @cantidad, dfechaup = GETDATE() WHERE iidProducto = @idproducto AND iidAlmacen = @idalmacenes ";
                }         
            }

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idalmacenes", SqlDbType.Int);
            cmd.Parameters.Add("@idproducto", SqlDbType.Int);
            cmd.Parameters.Add("@cantidad", SqlDbType.Float);

            ///
            cmd.Parameters["@idalmacenes"].Value = idalmacen;
            cmd.Parameters["@idproducto"].Value = idproducto;
            cmd.Parameters["@cantidad"].Value = cantidad;

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

        public bool sumar_movimiento(DataTable info)
        {
            DataRow Row = info.Rows[0];

            string mover = Row["idtipo"].ToString();
            string idalmacen = Row["idalmacen"].ToString();
            string idproducto = Row["idproducto"].ToString();
            string cantidad = Row["cantidad"].ToString();
            string idunidad = Row["idunidad"].ToString();
            string fContenidoXPieza = Row["fContenidoXPieza"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "";
            if (ClsExt.existe_producto(idproducto, idalmacen, mover))
            {
                if (mover == "1")
                {
                    sql = " UPDATE catExistenciasMateriaPrima SET fCantidad = @cantidad, fContenidoXPieza = @fContenidoXPieza, dfechaup = GETDATE() WHERE iidMateriPrima = @idproducto AND iidAlmacen = @idalmacenes ";
                }
                else
                {
                    sql = " UPDATE catExistencias SET fCantidad = @cantidad, dfechaup = GETDATE() WHERE iidProducto = @idproducto AND iidAlmacen = @idalmacenes ";
                }
            }
            else
            {
                if (mover == "1")
                {
                    sql = " INSERT INTO catExistenciasMateriaPrima (iidMateriPrima,iidAlmacen,fCantidad,iidUnidadMetrica,fContenidoXPieza,dfechain, dfechaup) " +
                             " VALUES (@idproducto,@idalmacenes,@cantidad,@idunidad,@fContenidoXPieza,GETDATE(),GETDATE())";
                }
                else
                {
                    sql = " INSERT INTO catExistencias (iidProducto,iidAlmacen,fCantidad,iidUnidadMetrica,dfechain, dfechaup) " +
                             " VALUES (@idproducto,@idalmacenes,@cantidad,@idunidad,GETDATE(),GETDATE())";
                }
            }

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idalmacenes", SqlDbType.Int);
            cmd.Parameters.Add("@idproducto", SqlDbType.Int);
            cmd.Parameters.Add("@cantidad", SqlDbType.Float);
            cmd.Parameters.Add("@idunidad", SqlDbType.Int);

            cmd.Parameters["@idalmacenes"].Value = idalmacen;
            cmd.Parameters["@idproducto"].Value = idproducto;
            cmd.Parameters["@cantidad"].Value = cantidad;
            cmd.Parameters["@idunidad"].Value = idunidad;
            if (fContenidoXPieza != "")
            {
                cmd.Parameters.Add("@fContenidoXPieza", SqlDbType.Float);
                cmd.Parameters["@fContenidoXPieza"].Value = fContenidoXPieza;
            }


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


        public bool existe_producto_almacen(string producto, string almacen, string mover)
        {
            string sql = "";

            if (mover == "1")
            {
                sql = "SELECT iidMateriPrima FROM catExistenciasMateriaPrima WHERE iidAlmacen = " + almacen + " AND iidMateriPrima = " + producto;
            }
            else
            {
                sql = " SELECT iidProducto FROM catExistencias WHERE iidAlmacen = " + almacen + " AND iidProducto = " + producto;
            }

            int numero = Conexion.NumeroFilas(sql);

            if (numero == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
