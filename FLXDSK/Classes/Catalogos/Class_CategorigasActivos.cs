using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Catalogos
{
    class Class_CategorigasActivos
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        public bool Guardar(string descripcion) {
            

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catTiposActivos (dfechaIn, dfechaup, vchDescripcion, iidEstatus, iidUsuario) " +
                         " VALUES (GETDATE(), GETDATE(), @vchDescripcion, 1, @iidUsuario )";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text);
            ///
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@vchDescripcion"].Value = descripcion.Trim();
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
        public bool Actualiza(string descripcion, string id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE  catTiposActivos  SET dfechaup =  getdate(), vchDescripcion = @vchDescripcion, iidUsuario = @iidUsuario  WHERE iidTipoActivo = " + id;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text);
            ///
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@vchDescripcion"].Value = descripcion.Trim();
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
        public DataTable getTipos() {
            string sql = "SELECT iidTipoActivo id, vchDescripcion nombre  FROM catTiposActivos (NOLOCK) WHERE iidEstatus = 1 ";
            return Conexion.Consultasql(sql);
        }
        public DataTable getInfoById(string id)
        {
            string sql = "SELECT iidTipoActivo, vchDescripcion, dfechaIn, dfechaup, iidUsuario, iidEstatus  FROM catTiposActivos (NOLOCK) WHERE iidTipoActivo =  " + id;
            return Conexion.Consultasql(sql);
        }
        public bool ExisteDescripcion(string text) {
            string sql = "SELECT iidTipoActivo  FROM catTiposActivos (NOLOCK) WHERE vchDescripcion = '"+text+"' AND iidEstatus = 1  ";
            int numero = Conexion.NumeroFilas(sql);
            if (numero == 0) return false; else return true;
        }
        public bool BorrarRegistro(string id) {
            string sql = "UPDATE catTiposActivos SET iidEstatus = 2  WHERE iidTipoActivo =  "+id;
            return Conexion.InsertaSql(sql);
        }
    }
}
