using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Catalogos.Mercancia
{
    class Class_Materia_Prima_Categoria
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLos = new Classes.Class_Logs();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = "SELECT iidCategoriaMateriPrima, dfechaIn, dfechaUp, iidUsuario, vchCodigo, vchDescripcion, iidEstatus " +
            " FROM catCategoriasMateriaPrima (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public bool Eliminar(string Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "UPDATE catCategoriasMateriaPrima SET iidEstatus = 2, dFechaUp = GETDATE() WHERE iidCategoriaMateriPrima = " + Id;
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

        public bool InsertaInformacion(string vchCodigo, string vchDescripcion)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO catCategoriasMateriaPrima (dfechaIn, dfechaUp, iidUsuario, vchCodigo, vchDescripcion, iidEstatus) " +
            " VALUES (GETDATE(), GETDATE(), @iidUsuario, @vchCodigo, @vchDescripcion, 1)";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchCodigo", SqlDbType.Text).Value = vchCodigo;
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text).Value = vchDescripcion;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int).Value = Class_Session.Idusuario.ToString();
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                ClsLos.InsertaInformacion(exp.Message.ToString(), "Materia_Prima_Categoria.Insertar");
                return false;
            }
        }

        public bool ActualizaInformacion(string vchCodigo, string vchDescripcion, string Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE catCategoriasMateriaPrima SET vchCodigo = @vchCodigo, vchDescripcion = @vchDescripcion, dfechaUp = GETDATE(), iidUsuario = @iidUsuario " +
            " WHERE iidCategoriaMateriPrima = " + Id;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchCodigo", SqlDbType.Text).Value = vchCodigo;
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text).Value = vchDescripcion;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int).Value = Class_Session.Idusuario.ToString();
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                ClsLos.InsertaInformacion(exp.Message.ToString(), "Materia_Prima_Categoria.Actualizar");
                return false;
            }
        }
    }
}
