using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Catalogos
{
    class Class_Paquete
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public string getIdPaquete()
        {
            string sql = "select top 1 iidProducto from catProductos where iidUnidad = 3 order by dfechain desc";
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["iidProducto"].ToString();
            }
            catch
            {
                return "";
            }
        }

        public bool existeProductoenPaquete(string idProducto, string idPaquete)
        {
            string sql = "select * from RelPaqueteProducto where iidProducto = " + idProducto + " and iidPaquete = " + idPaquete;
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else
                return false;
        }

        public bool aunNoCaducaPaquete(string idPaquete)
        {
            string sql = "select * from catProductos where iidProducto = " + idPaquete + " and dfechaVence > getdate()";
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else
                return false;
        }

        public bool esunPlatillo(string idPaquete)
        {
            string sql = "select * from catProductos where iidProducto = " + idPaquete + " and iidUnidad = 1";
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else
                return false;
        }

        public bool esPaquete(string idProducto)
        {
            string sql = "select * from catProductos where iidProducto = " + idProducto + " and iidUnidad = 3";
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else
                return false;
        }
        public bool esplatillo(string idProducto)
        {
            string sql = "select * from catProductos where iidProducto = " + idProducto + " and iidUnidad = 1";
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else
                return false;
        }

        public bool existeenAlmacen(string idProducto, string idAlmacen)
        {
            string sql = "select * from catExistencias where iidProducto = " + idProducto + " and iidAlmacen = " + idAlmacen;
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else
                return false;
        }

        public bool existeMinimoenunAlmacen(string idProducto)
        {
            string sql = "select top 1 iidAlmacen from catExistencias where iidProducto = " + idProducto;
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else
                return false;
        }

        public string getNombreProducto(string idProducto)
        {
            string sql = "select vchDescripcion from catProductos where iidProducto = " + idProducto;
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["vchDescripcion"].ToString();
            }
            catch
            {
                return "";
            }
        }

        public bool GuardarRelPaqueteProducto(DataTable Info)
        {
            DataRow Row = Info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " insert into RelPaqueteProducto values (@idPaquete,@idProducto,1,getdate(),getdate(),@fCantidad,@idAlmacen)";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idPaquete", SqlDbType.Int);
            cmd.Parameters.Add("@fCantidad", SqlDbType.Int);
            cmd.Parameters.Add("@idProducto", SqlDbType.Int);
            cmd.Parameters.Add("@idAlmacen", SqlDbType.Int);

            ///
            cmd.Parameters["@idPaquete"].Value = Row["idPaquete"].ToString();
            cmd.Parameters["@fCantidad"].Value = Row["fCantidad"].ToString();
            cmd.Parameters["@idProducto"].Value = Row["idProducto"].ToString();
            cmd.Parameters["@idAlmacen"].Value = Row["idAlmacen"].ToString();

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

        public DataTable getIdProductos(string idPedido)
        {
            string sql = "select iidProducto, fCantidad, iidAlmacen from RelPaqueteProducto P where iidPaquete = " + idPedido;
            return Conexion.Consultasql(sql);
        }

        public string getidAlmacen(string idProducto)
        {
            string sql = "select iidAlmacen from catProductos P where iidProducto = " + idProducto;
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["iidAlmacen"].ToString();
            }
            catch
            {
                return "";
            }
        }
        public string getPrecioProducto(string idProducto)
        {
            string sql = "select fCosto from catProductos where iidProducto = " + idProducto;
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["fCosto"].ToString();
            }
            catch
            {
                return "";
            }
        }

        public bool InsertNuevoCosto(double costo, string idproducto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "update catProductos set fCosto = fCosto +" + costo + " where iidProducto = " + idproducto;
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

        public bool existeProductoenPaqueteconAlmacen(string idPaquete, string idProducto, string idAlmacen)
        {
            string sql = "select * from RelPaqueteProducto where iidProducto = " + idProducto + " and iidPaquete = " + idPaquete + " and iidAlmacen = " + idAlmacen;
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else
                return false;
        }
    }
}
