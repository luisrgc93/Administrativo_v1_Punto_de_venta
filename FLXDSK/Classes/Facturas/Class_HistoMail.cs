using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FLXDSK.Classes.Facturas
{
    class Class_HistoMail
    {
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();

        public DataTable getInfoHist(string idEmp, string uuid)
        {
            string sql = " SELECT top 1 vchCorreo, vchAsunto, vchMensaje  from HistEnvioMail (NOLOCK) " +
                         " WHERE vchuuid='" + uuid + "' and iidEmpresa='" + idEmp + "'" +
                         " ORDER BY dfechaEnvio DESC ";
            return conx.Consultasql(sql);
        }


        public bool InsertHist(DataTable Info)
        {

            DataRow row = Info.Rows[0];
            string correo = row["correo"].ToString();
            string asunto = row["asunto"].ToString();
            string mensaje = row["mensaje"].ToString();
            string uuid = row["uuid"].ToString();
            string empresa = row["empresa"].ToString();
            string tipo = "5";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string sql = "INSERT INTO HistEnvioMail (iidEmpresa, dfechaEnvio, vchCorreo, vchuuid, " +
                         " vchMensaje,vchAsunto,iidTipoCfdi,iidusuario,dfechain, dfechaup)" +
                         " values " +
                         " ( @empresa, GETDATE(),@correo ,@uuid,@mensaje, @asunto," +
                         " @tipo, @usuario, GETDATE(), GETDATE() )";
            cmd.CommandText = sql;

            cmd.Parameters.Add("@empresa", SqlDbType.Int);
            cmd.Parameters.Add("@correo", SqlDbType.Char);
            cmd.Parameters.Add("@uuid", SqlDbType.Char);
            cmd.Parameters.Add("@mensaje", SqlDbType.Char);
            cmd.Parameters.Add("@asunto", SqlDbType.Char);
            cmd.Parameters.Add("@tipo", SqlDbType.Int);
            cmd.Parameters.Add("@usuario", SqlDbType.Char);

            cmd.Parameters["@empresa"].Value = empresa;
            cmd.Parameters["@correo"].Value = correo;
            cmd.Parameters["@uuid"].Value = uuid;
            cmd.Parameters["@mensaje"].Value = mensaje;
            cmd.Parameters["@asunto"].Value = asunto;
            cmd.Parameters["@tipo"].Value = tipo;
            cmd.Parameters["@usuario"].Value = usuariolog;
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
