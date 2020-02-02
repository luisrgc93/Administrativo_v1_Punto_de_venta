using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Nomina
{
    class Class_ImagenPersonal
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        public bool ExisteImagen(string persona)
        {
            string sql = "SELECT iidPersonal FROM catIMagenPersona (NOLOCK)  WHERE iidPersonal =  " + persona;
            int numero = Conexion.NumeroFilas(sql);
            if (numero == 0)
                return false;
            else
                return true;
        }
        public DataTable GerImagen(string id)
        {
            string sql = "SELECT vchImagen FROM catIMagenPersona (NOLOCK) WHERE iidPersonal =  " + id;
            return Conexion.Consultasql(sql);
        }
        public bool ActualizaImagen(Byte[] dibujoByteArray, string id)
        {

            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);

            string sql = "";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            if (ExisteImagen(id))
            {
                sql = " UPDATE catIMagenPersona SET " +
                      " vchImagen = @vchImagen, dfechaup = GETDATE(), iidUsuario = " + usuariolog + " " +
                                     " WHERE iidPersonal =  " + id;
            }
            else
            {
                sql = " INSERT INTO  catIMagenPersona (iidPersonal, vchImagen, dfechain, dfechaup, iidUsuario) " +
                      " VALUES (" + id + ", @vchImagen, getdate(), getdate(), " + usuariolog + ")";
            }

            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchImagen", SqlDbType.Image);
            cmd.Parameters["@vchImagen"].Value = dibujoByteArray;

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
