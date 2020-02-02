using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Configuracion
{
    class Class_TipoMovimiento
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = "SELECT iidTipoMovimiento, dfechaIn, dfechaUp, iidEstatus, iidUsuario, vchNombre, siEntrada " +
            " FROM CatTipoMovimiento (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public bool InsertaRegistro(string vchNombre, string siEntrada)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "INSERT INTO  CatTipoMovimiento (dfechaIn, dfechaUp, iidEstatus, iidUsuario, vchNombre, siEntrada) " +
            " VALUES (GETDATE(), GETDATE(), 1,  " + Class_Session.Idusuario + ", @vchNombre, @siEntrada )";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchNombre", SqlDbType.Text);
            cmd.Parameters.Add("@siEntrada", SqlDbType.SmallInt);
            cmd.Parameters["@vchNombre"].Value = vchNombre;
            cmd.Parameters["@siEntrada"].Value = siEntrada;
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
        public bool ActualizaRegistro(string vchNombre, string siEntrada, string iidTipoMovimiento)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "UPDATE  CatTipoMovimiento  SET vchNombre = @vchNombre, siEntrada = @siEntrada,  " +
            " dfechaUp = GETDATE(), iidUsuario = " + Class_Session.Idusuario + " " +
            " WHERE iidTipoMovimiento = @iidTipoMovimiento  ";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchNombre", SqlDbType.Text);
            cmd.Parameters.Add("@siEntrada", SqlDbType.SmallInt);
            cmd.Parameters.Add("@iidTipoMovimiento", SqlDbType.Int);
            cmd.Parameters["@vchNombre"].Value = vchNombre;
            cmd.Parameters["@siEntrada"].Value = siEntrada;
            cmd.Parameters["@iidTipoMovimiento"].Value = iidTipoMovimiento;

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
        public bool Borrar(string iidTipoMovimiento)
        {
            string sql = "UPDATE CatTipoMovimiento SET  dfechaUp = GETDATE(), iidEstatus = 2, iidUsuario = " + Class_Session.Idusuario + " WHERE iidTipoMovimiento = "+iidTipoMovimiento;
            return Conexion.InsertaSql(sql);
        }
    }
}
