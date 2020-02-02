using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Catalogos.Personal
{
    class Class_Puestos
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = "SELECT iidPuesto, vchNombre, iidEstatus, dfechain, dfechaup, iidUsuario, SiEnviado, fPropina, isMesero, siRepartoPropina " +
            " FROM catPuestos (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }

        public double getSumaPorcentajesActuales(string filtro)
        {
            string sql = "SELECT SUM(fPropina)total FROM catPuestos (NOLOCK) WHERE siRepartoPropina = 1 AND iidEstatus = 1 " + filtro;
            DataTable dt =  Conexion.Consultasql(sql);
            if (dt.Rows.Count == 0)
                return 0;

            try
            {
                return Convert.ToDouble(dt.Rows[0]["total"].ToString());
            }
            catch { }
            return 0;
        }
        
        
        public string getName(string nombre)
        {
            string sql = "SELECT iidpuesto FROM catPuestos (NOLOCK) WHERE vchNombre = " + nombre;
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["iidPuesto"].ToString();
            }
            else return "";
        }
        
        public DataTable getPuestoAll()
        {
            DataTable dt = new DataTable();
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre UNION ALL " +
                " SELECT iidPuesto as id, vchNombre as nombre	 FROM  catPuestos (NOLOCK) WHERE iidEstatus = 1 ";
            dt = Conexion.Consultasql(sql);
            return dt;
        }

        public bool GuardarPuesto(string Nombre, double fPropina, string isMesero, string siRepartoPropina)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO catPuestos (iidUsuario,vchNombre, fPropina, dFechaIn, dFechaUp, iidEstatus,  isMesero, siRepartoPropina) " +
                         " VALUES (@iidUsuario,@vchNombre, @fPropina, GETDATE(), GETDATE(), 1, @isMesero, @siRepartoPropina) ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@vchNombre", SqlDbType.Text);
            cmd.Parameters.Add("@fPropina", SqlDbType.Float);
            cmd.Parameters.Add("@isMesero", SqlDbType.SmallInt);
            cmd.Parameters.Add("@siRepartoPropina", SqlDbType.SmallInt);
            ///
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario.ToString();
            cmd.Parameters["@vchNombre"].Value = Nombre;
            cmd.Parameters["@fPropina"].Value = fPropina;
            cmd.Parameters["@isMesero"].Value = isMesero;
            cmd.Parameters["@siRepartoPropina"].Value = siRepartoPropina;
            
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
                row_Excepcion["vchLugar"] = "Class_Puestos";
                row_Excepcion["vchAccion"] = "funcion (inserta_puesto)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }


        public bool ActualizarPueso(string Nombre, double fPropina, string isMesero, string siRepartoPropina, string iidPuesto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE catPuestos SET iidUsuario = @iidUsuario,  vchNombre = @vchNombre, fPropina = @fPropina, dFechaUp = GETDATE() , isMesero = @isMesero , siRepartoPropina = @siRepartoPropina " +
                         " WHERE iidPuesto = " + iidPuesto;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@vchNombre", SqlDbType.Text);
            cmd.Parameters.Add("@fPropina", SqlDbType.Float);
            cmd.Parameters.Add("@isMesero", SqlDbType.SmallInt);
            cmd.Parameters.Add("@siRepartoPropina", SqlDbType.SmallInt);
            ///
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario.ToString();
            cmd.Parameters["@vchNombre"].Value = Nombre;
            cmd.Parameters["@fPropina"].Value = fPropina;
            cmd.Parameters["@isMesero"].Value = isMesero;
            cmd.Parameters["@siRepartoPropina"].Value = siRepartoPropina;
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
                row_Excepcion["vchLugar"] = "Class_Puestos";
                row_Excepcion["vchAccion"] = "funcion (actualiza_puestos)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }
        
        public bool BorrarPuestoXId(string id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "UPDATE catPuestos SET iidEstatus = 2 " +
                         " WHERE iidPuesto = " + id;
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
