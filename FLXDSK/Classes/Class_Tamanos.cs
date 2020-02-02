using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace FLXDSK.Classes
{
    class Class_Tamanos
    {
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();

        public bool InsertNuevoTamano(string idTamanox, string idTamanoY, string nombre)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string sql = "insert into catTamanoMesas (vchDescripcion, dfechain, iTamanoX, iTamanoY) values ('" + nombre + "', GETDATE(), " + idTamanox + ", " + idTamanoY + ")";

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

        public bool ActualizaTamano(string idTamanox, string idTamanoY, string nombre, string iidTamano)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string sql = "update catTamanoMesas set vchDescripcion = '" + nombre + "', iTamanoX = " + idTamanox + ", iTamanoY = " + idTamanoY + " where iidTamano = " + iidTamano;

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
