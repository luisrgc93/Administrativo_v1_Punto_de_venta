using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Classes.Existencias
{
    class Class_Existencias
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public bool inserta_detalle_compra(DataTable info)
        {
            DataRow Row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catDetalleCompra (iidCompra, iidProducto, iidAlmacen, iCantidad, fCosto, dfechaIn, dfechaUp) " +
                         " VALUES(@idcompra,@idproducto,@idalmacen,@cantidad,@costo,GETDATE(),GETDATE()) ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idcompra", SqlDbType.Int);
            cmd.Parameters.Add("@idproducto", SqlDbType.Int);
            cmd.Parameters.Add("@idalmacen", SqlDbType.Int);
            cmd.Parameters.Add("@cantidad", SqlDbType.Float);
            cmd.Parameters.Add("@costo", SqlDbType.Float);

            cmd.Parameters["@idproveedor"].Value = Row["idproveedor"].ToString();
            cmd.Parameters["@idmetodopago"].Value = Row["idmetodopago"].ToString();
            cmd.Parameters["@idcfdi"].Value = Row["idcfdi"].ToString();
            cmd.Parameters["@iva"].Value = Row["iva"].ToString();
            cmd.Parameters["@subtotal"].Value = Row["subtotal"].ToString();
            cmd.Parameters["@total"].Value = Row["total"].ToString();
            cmd.Parameters["@fechaCompra"].Value = Row["fechaCompra"].ToString();
            cmd.Parameters["@comentarios"].Value = Row["comentarios"].ToString();

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

        public string obtener_existencia_producto(string idproducto, string idalmacen, string mover)
        {
            DataTable dt = new DataTable();
            string sql = "";
            if (mover == "1")
            {
                sql = " SELECT fCantidad FROM catExistenciasMateriaPrima WHERE iidMateriPrima = " + idproducto + " AND iidAlmacen = " + idalmacen;
            }
            else
            {
                sql = " SELECT fCantidad FROM catExistencias WHERE iidProducto = " + idproducto + " AND iidAlmacen = " + idalmacen;
            }

            try
            {

                dt = Conexion.Consultasql(sql);
                DataRow row = dt.Rows[0];
                return row["fCantidad"].ToString();

            }
            catch
            {
                return "";
            }
        }

        public bool existe_producto(string idproducto, string idalmacen, string mover)
        {
            string sql = "";
            if (mover == "1")
            {
                sql = " SELECT iidMateriPrima FROM catExistenciasMateriaPrima WHERE iidMateriPrima = " + idproducto + " AND iidAlmacen = " + idalmacen;
            }
            else
            {
                sql = " SELECT iidProducto FROM catExistencias WHERE iidProducto = " + idproducto + " AND iidAlmacen = " + idalmacen;
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

        public bool actualiza_existencia(DataTable info)
        {
            DataRow Row = info.Rows[0];

            string mover = Row["mover"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "";
            if (mover == "1")
            {
                sql = " UPDATE catExistenciasMateriaPrima SET fCantidad = @cantidad, iidUnidadMetrica = @idunidad, fContenidoXPieza = @contenidoXpieza, dfechaup = GETDATE() WHERE iidMateriPrima = @idproducto AND iidAlmacen = @idalmacenes ";
            }
            else
            {
                sql = " UPDATE catExistencias SET fCantidad = @cantidad, iidUnidadMetrica = @idunidad, dfechaup = GETDATE() WHERE iidProducto = @idproducto AND iidAlmacen = @idalmacenes ";
            }

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idproducto", SqlDbType.Int);
            cmd.Parameters.Add("@idalmacenes", SqlDbType.Int);
            cmd.Parameters.Add("@idunidad", SqlDbType.Int);
            cmd.Parameters.Add("@cantidad", SqlDbType.Float);

            cmd.Parameters["@idproducto"].Value = Row["idproducto"].ToString();
            cmd.Parameters["@idalmacenes"].Value = Row["idalmacenes"].ToString();
            cmd.Parameters["@idunidad"].Value = Row["idunidad"].ToString();
            cmd.Parameters["@cantidad"].Value = Row["cantidad"].ToString();
            if (Row["contenidoXpieza"].ToString() != "")
            {
                cmd.Parameters.Add("@contenidoXpieza", SqlDbType.Float);
                cmd.Parameters["@contenidoXpieza"].Value = Row["contenidoXpieza"].ToString();
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


        public bool inserta_existencia(DataTable info)
        {
            DataRow Row = info.Rows[0];

            string mover = Row["mover"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "";
            if (mover == "1")
            {
                sql = " INSERT INTO catExistenciasMateriaPrima (iidMateriPrima,iidAlmacen,fCantidad,iidUnidadMetrica,fContenidoXPieza,dfechain, dfechaup) " +
                         " VALUES (@idproducto,@idalmacenes,@cantidad,@idunidad,@contenidoXpieza,GETDATE(),GETDATE())";
            }
            else
            {
                sql = " INSERT INTO catExistencias (iidProducto,iidAlmacen,fCantidad,iidUnidadMetrica,dfechain, dfechaup) " +
                         " VALUES (@idproducto,@idalmacenes,@cantidad,@idunidad,GETDATE(),GETDATE())";
            }

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idproducto", SqlDbType.Int);
            cmd.Parameters.Add("@idalmacenes", SqlDbType.Int);
            cmd.Parameters.Add("@idunidad", SqlDbType.Int);
            cmd.Parameters.Add("@cantidad", SqlDbType.Float);

            cmd.Parameters["@idproducto"].Value = Row["idproducto"].ToString();
            cmd.Parameters["@idalmacenes"].Value = Row["idalmacenes"].ToString();
            cmd.Parameters["@idunidad"].Value = Row["idunidad"].ToString();
            cmd.Parameters["@cantidad"].Value = Row["cantidad"].ToString();
            if (Row["contenidoXpieza"].ToString() != "")
            {
                cmd.Parameters.Add("@contenidoXpieza", SqlDbType.Float);
                cmd.Parameters["@contenidoXpieza"].Value = Row["contenidoXpieza"].ToString();
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

    }
}
