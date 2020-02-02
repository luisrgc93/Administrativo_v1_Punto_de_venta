using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Catalogos
{
    class Class_Coordenadas
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public bool inserta_zona(DataTable info)
        {
            DataRow Row = info.Rows[0];

            string descripcion = Row["zona"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catTaxi(vchDescripcion,iidEstatus,dfechaIn,dfechaUp) VALUES('"+ descripcion +"',1,GETDATE(),GETDATE())";

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

        public bool inserta_tarifa(DataTable info, string idzona)
        {
            DataRow Row = info.Rows[0];

            string tipo = Row["servicio"].ToString();
            string precio = Row["tarifa"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catPreciosTaxi(iidTaxi,vchTipo,fPrecio,dfechaIn,dfechaUp) VALUES(" + idzona + ",'" + tipo + "'," + precio + ",GETDATE(),GETDATE()) ";

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

        public bool inserta_coordenadas(DataTable info,string idzona)
        {
            DataRow Row = info.Rows[0];
            string latitud = Row["latitud"].ToString();
            string longitud = Row["longitud"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catPuntosServicioTaxi(iidTaxi,vchLg,vchLt) VALUES(" + idzona + ",'" + longitud + "','" + latitud + "') ";

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

        public bool actualiza_zona(DataTable info,string idzona)
        {
            DataRow Row = info.Rows[0];
            string descripcion = Row["zona"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catTaxi SET vchDescripcion = '" + descripcion + "',dfechaUp = GETDATE() WHERE iidTaxi = " + idzona;

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

        public bool actualiza_tarifa(DataTable info,string idtarifa,string idzona)
        {
            DataRow Row = info.Rows[0];
            string tipo = Row["servicio"].ToString();
            string precio = Row["tarifa"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catPreciosTaxi SET iidTaxi = "+ idzona +",vchTipo = '"+ tipo +"',fPrecio = "+ precio +",dfechaUp  = GETDATE() WHERE iidPrecioTaxi = " + idtarifa;

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

        public string ultimo_id_guardado()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT iidTaxi FROM catTaxi ORDER BY dfechaIn DESC ";
            try
            {

                dt = Conexion.Consultasql(sql);
                DataRow row = dt.Rows[0];
                return row["iidTaxi"].ToString();

            }
            catch
            {
                return "";
            }
        }

        public string ultimo_idprecio_guardado()
        {
            DataTable dt = new DataTable();
            string sql = " SELECT iidPrecioTaxi FROM catPreciosTaxi ORDER BY dfechain DESC ";
            try
            {

                dt = Conexion.Consultasql(sql);
                DataRow row = dt.Rows[0];
                return row["iidPrecioTaxi"].ToString();

            }
            catch
            {
                return "";
            }
        }

        public DataTable obtener_zona(string idzona)
        {
            string sql = " SELECT iidTaxi, vchDescripcion, " +
                         " dfechaIn, dfechaUp " +
                         " FROM catTaxi " +
                         " WHERE iidEstatus = 1 " +
                         " AND iidTaxi = " + idzona;

            return Conexion.Consultasql(sql);
        }

        public DataTable obtener_tarifa(string idzona, string idtarifa)
        {
            string sql = " SELECT iidTaxi, iidPrecioTaxi, " +
                         " vchTipo, fPrecio, dfechaIn, dfechaUp " +
                         " FROM catPreciosTaxi " +
                         " WHERE iidTaxi = " + idzona +
                         " AND iidPrecioTaxi = " + idtarifa;

            return Conexion.Consultasql(sql);
        }

        public bool borrar_zona(string idzona)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catTaxi SET iidEstatus = 2 WHERE iidTaxi = " + idzona;

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

        public bool borrar_coordenadas(string idpunto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "  DELETE FROM catPuntosServicioTaxi WHERE iidPuntosTaxi = " + idpunto;

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
    }
}
