using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes
{
    class Class_Logs
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public bool INSERTA_EXCEPCION(DataTable excepcion)
        {
            DataRow Row = excepcion.Rows[0];
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO Excepciones_log (vchExcepcion, vchLugar, vchAccion, iidUsuario, iidEmpresa, dFechaIn) " +
                         " VALUES (@vchExcepcion,@vchLugar,@vchAccion,@iidUsuario,@iidEmpresa,GETDATE()) ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int);
            cmd.Parameters.Add("@vchExcepcion", SqlDbType.Text);
            cmd.Parameters.Add("@vchLugar", SqlDbType.Text);
            cmd.Parameters.Add("@vchAccion", SqlDbType.Text);

            ///
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@iidEmpresa"].Value = Classes.Class_Session.IDEMPRESA;
            cmd.Parameters["@vchExcepcion"].Value = Row["vchExcepcion"].ToString();
            cmd.Parameters["@vchLugar"].Value = Row["vchLugar"].ToString();
            cmd.Parameters["@vchAccion"].Value = Row["vchAccion"].ToString();

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

        public bool InsertaInformacion(string vchXml, string msg)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string sql = "INSERT INTO catLogServicioTim  " +
                " (dfecha, vchXlm , vchMesajeResp) " +
                    " values " +
                " (GETDATE(),  @vchXlm, @vchMesajeResp)";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchXlm", SqlDbType.NText);
            cmd.Parameters.Add("@vchMesajeResp", SqlDbType.Char);
            cmd.Parameters["@vchXlm"].Value = vchXml;
            cmd.Parameters["@vchMesajeResp"].Value = msg;
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
