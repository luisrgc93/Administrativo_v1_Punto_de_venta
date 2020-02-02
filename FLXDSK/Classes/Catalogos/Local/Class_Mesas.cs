using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Catalogos.Local
{
    class Class_Mesas
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();

        public bool restaurarPosicionMesas(string idMesa)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "update catMesas set iPosicionX = '', iPosicionY='' where iidMesa = " + idMesa;

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
        public bool insertNuevaCoordenada(int idMesa, int posx, int posy)
        {
            string sql = "update catMesas set iPosicionX = " + posx + " , iPosicionY = " + posy + " where iidMesa = " + idMesa;
            return Conexion.InsertaSql(sql);
        }
        public string getNameByID(string id) {
            string sql = "SELECT vchDescripcion FROM catMesas (NOLOCK) WHERE iidMesa = " + id;
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["vchDescripcion"].ToString();
            }
            else return "";
        }
        public bool nuevoTamano(string idMesa, string idTamanox, string idTamanoY)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "update catMesas set iTamanoX = " + idTamanox + ", iTamanoY =" + idTamanoY + " where iidMesa = " + idMesa;

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
        public string getnombreTamanoMesa(string tamanoX, string tamanoY)/*--*/
        {
            string sql = "SELECT vchDescripcion FROM catTamanoMesas (NOLOCK) WHERE iTamanoX = " + tamanoX + " and iTamanoY = " + tamanoY;
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["vchDescripcion"].ToString();
            }
            else return "";
        }
        public string getTamanoYMesa(int id)/*--*/
        {
            string sql = "SELECT iTamanoY FROM catMesas (NOLOCK) WHERE iidMesa = " + id;
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["iTamanoY"].ToString();
            }
            else return "";
        }
        public string getTamanoXMesa(int id)/*---*/
        {
            string sql = "SELECT iTamanoX FROM catMesas (NOLOCK) WHERE iidMesa = " + id;
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["iTamanoX"].ToString();
            }
            else return "";
        }
        public string getTamano(string tamanoX, string tamanoY)/*---*/
        {
            string sql = "select iidTamano from catTamanoMesas where iTamanoX = " + tamanoX + " and iTamanoY = " + tamanoY;
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["iidTamano"].ToString();
            }
            else return "";
        }

        public DataTable getMesaAllInArea(string idmesa) {
            string sql = "select 0 id, 'Todas' nombre " +
                            " union all " +
                            " select iidMesa id, vchDescripcion nombre " +
                            " from catMesas (NOLOCK) where iidArea = 1 " +
                            " and iidEstatus = 1";
            return Conexion.Consultasql(sql);
        }
        public bool inserta_mesa(DataTable info)
        {
            DataRow Row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catMesas (iidArea, vchDescripcion, dfechaIn, dfechaUp, iidEstatus)  " +
                         " VALUES (@iidArea, @vchDescripcion, GETDATE(), GETDATE(), 1)";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidArea", SqlDbType.Int);
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text);

            cmd.Parameters["@iidArea"].Value = Row["idarea"].ToString();
            cmd.Parameters["@vchDescripcion"].Value = Row["Descripcion"].ToString();

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

        public bool borrar_mesa(string idarea)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catMesas SET iidEstatus = 2, dFechaUp = GETDATE() WHERE iidMesa = " + idarea;

            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                DataTable Info_Excepcion = new DataTable();
                DataRow row_Excepcion;

                Info_Excepcion.Columns.Add("vchExcepcion", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchLugar", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchAccion", System.Type.GetType("System.String"));

                row_Excepcion = Info_Excepcion.NewRow();
                row_Excepcion["vchExcepcion"] = exp;
                row_Excepcion["vchLugar"] = "Class_Areas";
                row_Excepcion["vchAccion"] = "funcion (borrar_area)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public bool actualiza_mesa(DataTable info)
        {
            DataRow Row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catMesas SET iidArea = @idArea, vchDescripcion = @vchDescripcion, dfechaUp = GETDATE() WHERE iidMesa = @iidMesa ";

            cmd.CommandText = sql;

            cmd.Parameters.Add("@idArea", SqlDbType.Int);
            cmd.Parameters.Add("@iidMesa", SqlDbType.Int);
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text);

            cmd.Parameters["@idArea"].Value = Row["idarea"].ToString();
            cmd.Parameters["@iidMesa"].Value = Row["idmesa"].ToString();
            cmd.Parameters["@vchDescripcion"].Value = Row["Descripcion"].ToString();

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                DataTable Info_Excepcion = new DataTable();
                DataRow row_Excepcion;

                Info_Excepcion.Columns.Add("vchExcepcion", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchLugar", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchAccion", System.Type.GetType("System.String"));

                row_Excepcion = Info_Excepcion.NewRow();
                row_Excepcion["vchExcepcion"] = exp;
                row_Excepcion["vchLugar"] = "Class_mesa";
                row_Excepcion["vchAccion"] = "funcion (inserta_mesa)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public bool existe_mesa(string nombre)
        {
            string sql = "SELECT iidArea FROM catAreas WHERE vchNombre = '" + nombre + "' AND iidEstatus = 1 ";

            int numero = Conexion.NumeroFilas(sql);
            if (numero != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable obtener_mesa(string idMesa)
        {

            string sql = " SELECT iidArea, vchDescripcion, iPosicionX, iPosicionY " +
                         " FROM catMesas (NOLOCK) " +
                         " WHERE iidEstatus = 1 AND iidMesa =  " + idMesa;

            return Conexion.Consultasql(sql);
        }

        public DataTable getMesaAll()
        {

            string sql = " SELECT 0 as id, 'Seleccionar' as nombre  " +
                         " UNION ALL " +
                         " SELECT iidMesa as id, vchDescripcion as nombre  " +
                         " FROM catMesas " +
                         " WHERE iidEstatus = 1 ";

            return Conexion.Consultasql(sql);
        }        
    }
}
