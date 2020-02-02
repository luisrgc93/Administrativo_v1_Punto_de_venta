using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes
{
    class Class_Estatus
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();
        public bool InsertaOpciones(DataTable Info)
        {
            DataRow row = Info.Rows[0];
            string tipolugar = row["tipolugar"].ToString();
            string opciones = row["opciones"].ToString();
            string descripcion = row["descripcion"].ToString();
            // if (limite == "") limite = "0";
            string usuario = Convert.ToString(Classes.Class_Session.Idusuario);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "INSERT INTO catEstatus " +
                " ( vchEstatus,iidUsuario,vchDescripcion,vchTipolugar)" +
                                 " VALUES " +
                                 " (@vchestatus,@iidusuario,@vchdescripcion,@vchtipolugar)";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchestatus", SqlDbType.Text);
            cmd.Parameters.Add("@iidusuario", SqlDbType.Int);
            cmd.Parameters.Add("@vchdescripcion", SqlDbType.Text);
            cmd.Parameters.Add("@vchtipolugar", SqlDbType.Text);
            cmd.Parameters["@vchstatus"].Value = opciones;
            cmd.Parameters["@iidusuario"].Value = usuario;
            cmd.Parameters["@vchdescripcion"].Value = descripcion;
            cmd.Parameters["@vchtipolugar"].Value = tipolugar;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                MessageBox.Show("Aqui falla" + exp.ToString());
                //ClsLog.InsertaInformacion("Solicitud licencias", exp.ToString());
                return false;
            }
        }

        public DataTable getOpcionesbyTipo(string tipolugar)
        {
            string sql = "SELECT vchEstatus FROM catEstatus where vchTipoLugar='" + tipolugar + "' ";
            return Conexion.Consultasql(sql);
        }
        public string getIdByName(string nombre, string tipolugar)
        {
            string sql = "SELECT iidEstatus FROM catEstatus (NOLOCK) where vchTipoLugar='" + tipolugar + "' AND vchEstatus = '" + nombre + "'  ";
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["iidEstatus"].ToString();
            else
                return "";
        }
    }
}
