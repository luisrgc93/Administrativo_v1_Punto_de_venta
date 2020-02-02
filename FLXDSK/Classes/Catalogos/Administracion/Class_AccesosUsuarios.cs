using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Catalogos.Administracion
{
    class Class_AccesosUsuarios
    {
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();

        public DataTable getModulos()
        {
            string sql = "SELECT * FROM [catMenuOpciones]  (NOLOCK) WHERE iidEstatus=1";
            return conx.Consultasql(sql);
        }

        public string getIdModulo(string moduloName)
        {
            string sql = " SELECT TOP 1 * FROM [catMenuOpciones]  (NOLOCK) WHERE vchNombre= '" + moduloName + "' ORDER BY dfechain DESC ";
            DataTable dt = new DataTable();
            dt = conx.Consultasql(sql);
            DataRow Rw = dt.Rows[0];
            return Rw["iidOpcion"].ToString();
        }

        public bool InsertaInformacion(DataTable Info)
        {
            DataRow row = Info.Rows[0];
            string idModulo = row["iidModulo"].ToString();
            string empresa = row["empresa"].ToString();
            string idUsuario = row["usuario"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string sql = "INSERT INTO RelModUsu " +
                " (iidmodulo, iidUsuario, iidEmpresa,dfechain,dfechaup) " +
                " values " +
                " (@modulo, @usuario,@empresa, GETDATE(), GETDATE())";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@modulo", SqlDbType.Int);
            cmd.Parameters.Add("@usuario", SqlDbType.Int);
            cmd.Parameters.Add("@empresa", SqlDbType.Int);

            cmd.Parameters["@modulo"].Value = idModulo;
            cmd.Parameters["@usuario"].Value = idUsuario;
            cmd.Parameters["@empresa"].Value = empresa;

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

        /********************************************************************************************/
        /********************************RELACCUSUARIO**************************************/


        public DataTable getModulosUsuario(string idUsuario, string idEmpresa)
        {
            //string sql = " SELECT * FROM RelModUsu " +
            //           " WHERE iidUsuario='" + idUsuario + "' AND iidEmpresa='" + idEmpresa + "'";
            string sql = "SELECT R.iidmodulo, R.iidUsuario, R.iidEmpresa, M.vchNameToolMenu, " +
                        " M.vchDescripcion, M.vchNombre FROM RelModUsu R  (NOLOCK), [catMenuOpciones] M  (NOLOCK)" +
                       " WHERE iidUsuario='" + idUsuario + "' AND iidEmpresa='" + idEmpresa + "'" +
                       "and R.iidmodulo = M.iidOpcion";
            return conx.Consultasql(sql);
        }

        //Delete relacion usuario-modulo
        public bool deleteRelMod(string idUsuario, string idEmp)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string sql = " DELETE FROM RelModUsu " +
                        " WHERE iidUsuario='" + idUsuario + "' AND iidEmpresa='" + idEmp + "'";
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

        public DataTable gerAccesoModuloUsu(string idUsuario, string idEmp)
        {
            var sql = "SELECT R.iidmodulo, R.iidUsuario, R.iidEmpresa," +
                      " M.vchDescripcion, M.vchNombre, M.vchNameToolMenu " +
                      " FROM RelModUsu R  (NOLOCK), [catMenuOpciones] M  (NOLOCK) " +
                      " WHERE R.iidUsuario=" + idUsuario + "and R.iidEmpresa=" + idEmp +
                      " AND R.iidmodulo=M.iidOpcion ";
            return conx.Consultasql(sql);
        }
        public bool ExisteOpcionMenu(string opcionid, string idusuario, string idEmp)
        {
            if (opcionid == "" || opcionid == "0") return false;
            var sql = "select U.iidUsuario, R.iidRol, A.iidOpcion  " +
                      " FROM catUsuarios U(NOLOCK), catRoles R (NOLOCK), RelRolesAccesos (NOLOCK) A, catMenuOpciones O (NOLOCK) " +
                      " WHERE U.iidRol = U.iidRol " +
                      " AND U.iidRol = A.iidRol " +
                      " AND A.iidRol = R.iidRol " +
                      " AND U.iidUsuario = " + idusuario +
                      " AND O.iidOpcion = A.iidOpcion " +
                      " AND O.vchNameToolMenu='" + opcionid + "'";

            var numero = conx.NumeroFilas(sql);
            return numero != 0;
        }

        public bool ExisteMenuEnLaDb(string nombreMenu, string categoria)
        {
            var sql = "SELECT iidOpcion, vchCategoria, vchNombre, vchNameToolMenu  " +
                      " FROM catMenuOpciones (NOLOCK) " +
                      " WHERE vchNombre =  '" + nombreMenu + "' AND vchCategoria = '"+ categoria +"'";

            var numero = conx.NumeroFilas(sql);
            return numero != 0;
        }

        public bool InsertarMenutoDb(string nombreMenu, string categoria, string toolItem)
        {
            var cmd = new SqlCommand {Connection = conx.ConexionSQL()};
            var sql = "INSERT INTO catMenuOpciones(vchCategoria, vchNombre, vchNameToolMenu, vchDescripcion, iidEstatus, dfechaIn, siEnviado)  " +
                      " VALUES('" + categoria + "','" + nombreMenu + "','" + toolItem + "',' ',1,GETDATE(),0) ";
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
