using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FLXDSK.Classes.Configuracion
{
    class Class_CategoriaImpresoras
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = "SELECT vchImpresora, iidCategoria, dfechaIn, iidUsuario " +
            " FROM RelImpresion (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public bool InsertaRegistro(string vchImpresora, string iidCategoria)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "INSERT INTO  RelImpresion (vchImpresora, iidCategoria, dfechaIn, iidUsuario) " +
            " VALUES (@vchImpresora, @iidCategoria, GETDATE(), " + Class_Session.Idusuario + " )";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchImpresora", SqlDbType.Text);
            cmd.Parameters.Add("@iidCategoria", SqlDbType.Int);
            cmd.Parameters["@vchImpresora"].Value = vchImpresora;
            cmd.Parameters["@iidCategoria"].Value = iidCategoria;
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
        public bool BorrarCategoria(string vchNombre, string iidCategoria)
        {
            string sql = "DELETE FROM RelImpresion WHERE vchImpresora = '" + vchNombre + "' AND  iidCategoria = " + iidCategoria;
            return Conexion.InsertaSql(sql);
        }

    }
}
