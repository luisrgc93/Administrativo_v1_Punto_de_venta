using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Cortes
{
    class Class_DetalleCorteMesero
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = "SELECT iidCorteMesero, iidPuesto, fPropinaObtenida FROM  DetCortesMeseros (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public DataTable getLista(string filtro)
        {
            string sql = "SELECT D.iidCorteMesero, D.iidPuesto, D.fPropinaObtenida, P.vchNombre " +
            " FROM  DetCortesMeseros (NOLOCK) D, catPuestos P (NOLOCK) " +
            " WHERE D.iidPuesto = P.iidPuesto " + filtro;
            return Conexion.Consultasql(sql);
        }

        public bool InsertaInformacion(string iidCorteMesero, string iidPuesto, double fPropinaObtenida)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string sql = "INSERT INTO DetCortesMeseros (iidCorteMesero, iidPuesto, fPropinaObtenida) " +
            " VALUES (@iidCorteMesero, @iidPuesto, @fPropinaObtenida) ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidCorteMesero", SqlDbType.Int).Value = iidCorteMesero;
            cmd.Parameters.Add("@iidPuesto", SqlDbType.Int).Value = iidPuesto;
            cmd.Parameters.Add("@fPropinaObtenida", SqlDbType.Float).Value = fPropinaObtenida;
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
