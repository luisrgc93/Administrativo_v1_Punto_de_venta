using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Herramientas
{
    class Class_Roles
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        string idusuario = Classes.Class_Session.Idusuario.ToString();

        public DataTable getUsuariosAll()
        {
            string sql = " SELECT 0 AS id , 'Seleccionar' AS nombre " +
                         " UNION ALL " +
                         " SELECT iidUsuario AS id, vchUsuario AS nombre FROM catUsuarios ";
            
            return Conexion.Consultasql(sql);
        }

        public DataTable getOpcionesAll()
        {
            string sql = " SELECT 0 AS id, 'Seleccionar' AS nombre " +
                         " UNION ALL " +
                         " SELECT iidRol AS id, vchNombre AS nombre FROM catRoles ";
            
            return Conexion.Consultasql(sql);
        }

        public bool InsertaRol(string nombre)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO catRoles (dFechaIn, dFechaUp, vchNombre, iidUsuario, iidEstatus) " +
                         " VALUES (GETDATE(), GETDATE(),'" + nombre + "', " + idusuario + ", 1) ";

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

        public bool InsertaRelUsuarioOpcion(string idOpcion, string idusuario, string idrol)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO RelRolesAccesos (iidRol, dFechaIn, iidUsuario, iidOpcion) " +
                         " VALUES (" + idrol + ",GETDATE()," + idusuario + "," + idOpcion + ")";

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

        public bool DeleteRelUsuarioOpcion(string idrol) 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "DELETE FROM RelRolesAccesos WHERE iidRol = " + idrol;

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

        public bool UpdateRol(string idrol, string nombre)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE catRoles SET dFechaUp = GETDATE(), vchNombre = '" + nombre +"', iidUsuario = " + idusuario +" WHERE iidRol = " + idrol;

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

        public bool DeleteRol(string idrol)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE catRoles SET dFechaUp = GETDATE(), iidEstatus = 2 WHERE iidRol = " + idrol;

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

        public bool ExisteNombre(string nombre)
        {
            string sql = " SELECT vchNombre FROM catRoles (NOLOCK) WHERE vchNombre = '" + nombre + "'";

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

        public DataTable getRol(string idrol)
        {

            string sql = " SELECT vchNombre " +
                         " FROM catRoles (NOLOCK) " +
                         " WHERE iidEstatus = 1" +
                         " AND iidRol = " + idrol; 

            return Conexion.Consultasql(sql);
        }

        public bool ExisteOpcionSeleccionada(string idopcion, string idrol)
        {
            string sql = "SELECT iidRol, iidUsuario FROM RelRolesAccesos (NOLOCK) " +
                         " WHERE iidOpcion = " + idopcion +
                         " AND iidRol = " + idrol;

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

        public string getUltimoidGuardado(string nombreRol)
        {
            string sql = "SELECT iidRol FROM catRoles (NOLOCK) WHERE vchNombre = '" + nombreRol + "'";
            DataTable Dt = new DataTable();
            Dt = Conexion.Consultasql(sql);
            DataRow row = Dt.Rows[0];
            return row["iidRol"].ToString();
        }
    }
}
