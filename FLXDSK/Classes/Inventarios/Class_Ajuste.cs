using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FLXDSK.Classes.Inventarios
{
    class Class_Ajuste
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = " SELECT iidMovimiento, dfechaIn, dfechaUp, iidUsuario, vchTipo, iidAlmacen, vchComentario, iNumRegistros, iidEstatus  " +
            " FROM exiMovimientoMateriaPrima (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }

        public bool Eliminar(string Id, string vchTipo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "UPDATE exiMovimientoMateriaPrima SET iidEstatus = 2, dFechaUp = GETDATE() WHERE iidMovimiento = " + Id + " AND vchTipo = '" + vchTipo + "' ";
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
        public string getIdNext(string vchTipo)
        {
            string sql = " SELECT CASE WHEN MAX(iidMovimiento) IS NULL THEN 1 ELSE MAX(iidMovimiento)+1 END  iidMovimiento FROM exiMovimientoMateriaPrima (NOLOCK) WHERE vchTipo = '" + vchTipo + "' ";
            DataTable dtInfo = Conexion.Consultasql(sql);
            if (dtInfo.Rows.Count == 0)
                return "0";

            return dtInfo.Rows[0]["iidMovimiento"].ToString();
        }

        public bool InsertaInformacion(string iidMovimiento, string vchTipo, string iidAlmacen, string vchComentario, int iNumRegistros)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO exiMovimientoMateriaPrima (iidMovimiento, dfechaIn, dfechaUp, iidUsuario, iidAlmacen, vchTipo, vchComentario, iNumRegistros, iidEstatus ) " +
            " VALUES (@iidMovimiento, GETDATE(), GETDATE(), @iidUsuario, @iidAlmacen, @vchTipo, @vchComentario, @iNumRegistros, 0 )";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidMovimiento", SqlDbType.Int).Value = iidMovimiento;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int).Value = Class_Session.Idusuario.ToString();
            cmd.Parameters.Add("@vchTipo", SqlDbType.Text).Value = vchTipo;
            cmd.Parameters.Add("@iidAlmacen", SqlDbType.Int).Value = iidAlmacen;
            cmd.Parameters.Add("@vchComentario", SqlDbType.Text).Value = vchComentario;
            cmd.Parameters.Add("@iNumRegistros", SqlDbType.Int).Value = iNumRegistros;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                ClsLog.InsertaInformacion(exp.Message.ToString(), "Ajuste.Insertar");
                return false;
            }
        }

        public bool ActualizaInformacion(string iidMovimiento, string vchTipo, string vchComentario, int iNumRegistros)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE exiMovimientoMateriaPrima SET dfechaUp = GETDATE(), iidUsuario=@iidUsuario, vchComentario=@vchComentario, iNumRegistros=@iNumRegistros " +
            " WHERE iidMovimiento = " + iidMovimiento + " AND vchTipo = '" + vchTipo + "'";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int).Value = Class_Session.Idusuario.ToString();
            cmd.Parameters.Add("@vchComentario", SqlDbType.Text).Value = vchComentario;
            cmd.Parameters.Add("@iNumRegistros", SqlDbType.Int).Value = iNumRegistros;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                ClsLog.InsertaInformacion(exp.Message.ToString(), "Ajuste.Actualizar");
                return false;
            }
        }
    }
}
