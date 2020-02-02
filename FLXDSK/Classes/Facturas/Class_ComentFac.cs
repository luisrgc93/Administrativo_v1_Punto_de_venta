using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Facturas
{
    class Class_ComentFac
    {
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();

        public bool InsertaInformacion(String Comentario, string uuid)
        {

            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();
            string sql = "INSERT INTO catComentFacturas " +
                " (vchuuid, vchComentario, dfechain, dfechaup, iidEstatus, iidUsuario)" +
                " VALUES " +
                " (@uuid, @comentario, GETDATE(), GETDATE(), 1, @iidUsuario)";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@comentario", SqlDbType.NText);
            cmd.Parameters.Add("@uuid", SqlDbType.Text);
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters["@comentario"].Value = Comentario;
            cmd.Parameters["@uuid"].Value = uuid;
            cmd.Parameters["@iidUsuario"].Value = usuariolog;

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
        public bool ActualizaInformacion(String Comentario, string uuid)
        {

            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string sql = "UPDATE catComentFacturas SET" +
                " vchuuid = @uuid, vchComentario = @comentario, dfechaup = GETDATE(), iidUsuario = @iidUsuario " +
                                 " WHERE vchuuid =  '" + uuid + "'";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@comentario", SqlDbType.NText);
            cmd.Parameters.Add("@uuid", SqlDbType.Text);
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters["@comentario"].Value = Comentario;
            cmd.Parameters["@uuid"].Value = uuid;
            cmd.Parameters["@iidUsuario"].Value = usuariolog;
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
        public bool ExisteCreado(string uuid)
        {
            string sql = "SELECT  vchuuid FROM catComentFacturas (NOLOCK) WHERE vchuuid =  '" + uuid + "'";
            int num = conx.NumeroFilas(sql);
            if (num == 0)
                return false;
            else
                return true;
        }
        public DataTable getInfo(string uuid)
        {
            string sql = "SELECT * FROM catComentFacturas (NOLOCK) WHERE vchuuid =  '" + uuid + "'";
            return conx.Consultasql(sql);
        }
        public String gerMeComent(string uuid)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM catComentFacturas  (NOLOCK) WHERE vchuuid =  '" + uuid + "'";
            dt = conx.Consultasql(sql);
            String texto = "";
            try
            {
                DataRow Dwr = dt.Rows[0];
                texto = Dwr["vchComentario"].ToString();
            }
            catch
            { }

            return texto;
        }
    }
}
