using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Catalogos.Local
{
    class Class_Areas
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();
        
        public bool inserta_area(DataTable info)
        {
            DataRow Row = info.Rows[0];

            Byte[] dibujoByteArray = null;
            try
            {
                dibujoByteArray = (byte[])(info.Rows[0]["imagen"]);
            }
            catch
            { };


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catAreas (iidEmpresa, dFechaIn, dFechaUp, vchNombre, vchDescripcion, iidEstatus, iidUsuario, SiEnviado, vchRuta, IFileImagen) " +
                         " VALUES (@iidEmpresa, GETDATE(), GETDATE(), @vchNombre, @vchDescripcion, 1, @iidUsuario, 0, '', @IFileImagen)";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int);
            cmd.Parameters.Add("@vchNombre", SqlDbType.Text);
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text);
            cmd.Parameters.Add("@IFileImagen", SqlDbType.Image);

            ///
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@iidEmpresa"].Value = Classes.Class_Session.IDEMPRESA;
            cmd.Parameters["@vchNombre"].Value = Row["Nombre"].ToString();
            cmd.Parameters["@vchDescripcion"].Value = Row["Descripcion"].ToString();
            if (dibujoByteArray == null)
                cmd.Parameters["@IFileImagen"].Value = DBNull.Value;
            else
                cmd.Parameters["@IFileImagen"].Value = dibujoByteArray;

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
                row_Excepcion["vchAccion"] = "funcion (inserta_area)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false; 
            }
        }

        public bool borrar_area(string idarea)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catAreas SET iidEstatus = 2, dFechaUp = GETDATE() WHERE iidArea = " + idarea;

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

        public bool actualiza_area(DataTable info)
        {
            DataRow Row = info.Rows[0];

            Byte[] dibujoByteArray = null;
            try
            {
                dibujoByteArray = (byte[])(info.Rows[0]["imagen"]);
            }
            catch{ };

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catAreas SET iidEmpresa = @iidEmpresa, " +
                " dFechaUp = GETDATE(), vchNombre = @vchNombre, vchDescripcion = @vchDescripcion , IFileImagen = @IFileImagen " +
            " WHERE iidArea = @idArea";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int);
            cmd.Parameters.Add("@idArea", SqlDbType.Int);
            cmd.Parameters.Add("@vchNombre", SqlDbType.Text);
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text);
            cmd.Parameters.Add("@IFileImagen", SqlDbType.Image);
            cmd.Parameters["@iidEmpresa"].Value = Classes.Class_Session.IDEMPRESA;
            cmd.Parameters["@idArea"].Value = Row["idArea"].ToString();
            cmd.Parameters["@vchNombre"].Value = Row["Nombre"].ToString();
            cmd.Parameters["@vchDescripcion"].Value = Row["Descripcion"].ToString();
            if (dibujoByteArray == null)
                cmd.Parameters["@IFileImagen"].Value = DBNull.Value;
            else
                cmd.Parameters["@IFileImagen"].Value = dibujoByteArray;
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
                row_Excepcion["vchAccion"] = "funcion (inserta_area)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public bool existe_area(string nombre)
        {
            string sql = "SELECT iidArea FROM catAreas WHERE vchNombre = '" + nombre + "' AND iidEstatus = 1 " ;

            int numero = Conexion.NumeroFilas(sql);
            if(numero != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable obtener_area(string idarea)
        {

            string sql = " SELECT vchNombre, vchDescripcion, IFileImagen " +
                         " FROM catAreas " +
                         " WHERE iidEstatus = 1 AND iidArea =  " + idarea;

            return Conexion.Consultasql(sql);
        }

        public DataTable getAreaAll()
        {

            string sql = " SELECT 0 as id, 'Todas' as nombre  " +
                         " UNION ALL" +
                         " SELECT iidArea as id, vchNombre as nombre  " +
                         " FROM catAreas " +
                         " WHERE iidEstatus = 1 ";

            return Conexion.Consultasql(sql);
        }
        public bool restaurarPosicionMesas(int idArea)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "update catMesas set iPosicionX = '', iPosicionY='', iTamanoX = '', iTamanoY = '' where iidArea = " + idArea;

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
        public DataTable getTamanossAll()
        {
            string sql = " SELECT 0 AS id, 'Seleccionar' AS nombre " +
                         " UNION ALL " +
                         " SELECT iidTamano AS id, vchDescripcion AS nombre " +
                         " FROM catTamanoMesas ";

            return Conexion.Consultasql(sql);
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
        public string getTamanoX(string idTamano)
        {
            string sql = "select iTamanoX from catTamanoMesas where iidTamano =  " + idTamano;
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["iTamanoX"].ToString();
            }
            catch
            {
                return "";
            }
        }
        public string getTamanoY(string idTamano)
        {
            string sql = "select iTamanoY from catTamanoMesas where iidTamano =  " + idTamano;
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["iTamanoY"].ToString();
            }
            catch
            {
                return "";
            }
        }
    }
}
