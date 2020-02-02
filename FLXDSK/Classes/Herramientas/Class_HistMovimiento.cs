using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FLXDSK.Classes.Herramientas
{
    class Class_HistMovimiento
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();

        public bool InsertaMovimiento(string iidPersona, string FI, string FF, string deja, string lugar)
        {
            string userlgo = Classes.Class_Session.Idusuario.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "INSERT INTO catHistoricoEstatusPersonal (dfechaIn,iidUsuario,iidPersonal, " +
            " dfechaInicia, dfechaTermina, vchTitulo, vchDeja )" +
                " values (getdate(), @usuario, @personal, " +
            " @FI, @FF, @titulo, @Deja )";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@usuario", SqlDbType.Int);
            cmd.Parameters.Add("@personal", SqlDbType.Int);
            cmd.Parameters.Add("@FI", SqlDbType.DateTime);
            cmd.Parameters.Add("@FF", SqlDbType.DateTime);
            cmd.Parameters.Add("@titulo", SqlDbType.Text);
            cmd.Parameters.Add("@Deja", SqlDbType.Text);
            cmd.Parameters["@usuario"].Value = userlgo;
            cmd.Parameters["@personal"].Value = iidPersona;
            cmd.Parameters["@FI"].Value = FI;
            cmd.Parameters["@FF"].Value = FF;
            cmd.Parameters["@titulo"].Value = lugar;
            cmd.Parameters["@Deja"].Value = deja;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                //ClsLog.InsertaInformacion(exp.ToString(), "Hist Movimiento");
                return false;
            }
        }
        public string getFechaInicio(string idpersona, string lugar) {
            string sql = "SELECT top 1 CONVERT(varchar(19), dfechaTermina, 126) dfechaTermina FROM catHistoricoEstatusPersonal (NOLOK) WHERE vchTitulo='" + lugar + "' AND iidPersonal = " + idpersona + " ORDER BY iidHistorico DESC ";
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["dfechaTermina"].ToString();
            }
            else {
                sql = "select CONVERT(varchar(19), GETDATE(), 126) fechIn ";
                dt = Conexion.Consultasql(sql);
                return dt.Rows[0]["fechIn"].ToString();
            }
        }

        public string getFechaInicioById(string idPersona)
        {
            string sql = "SELECT top 1 CONVERT(varchar(19), dfechaTermina, 126) dfechaTermina FROM catHistoricoEstatusPersonal WHERE iidPersonal=" + idPersona + " ORDER BY iidHistorico DESC";
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["dfechaTermina"].ToString();
            }
            else
            {
                sql = "select CONVERT(varchar(19), GETDATE(), 126) fechIn ";
                dt = Conexion.Consultasql(sql);
                return dt.Rows[0]["fechIn"].ToString();
            }
        }

    }
}
