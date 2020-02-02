using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FLXDSK.Classes.Configuracion
{
    class Class_Impresoras
    {

        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = "SELECT vchImpresora, vchPrinterUSB, dfechaIn, dfechaUp, iidUsuario " +
            " FROM catImpresoras (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public bool InsertaRegistro(string vchNombre, string vchImpresora)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "INSERT INTO  catImpresoras (vchImpresora, vchPrinterUSB, dfechaIn, dfechaUp, iidUsuario) "+
            " VALUES (@vchImpresora, @vchPrinterUSB, GETDATE(), GETDATE(), " + Class_Session.Idusuario + " )";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchImpresora", SqlDbType.Text);
            cmd.Parameters.Add("@vchPrinterUSB", SqlDbType.Text);
            cmd.Parameters["@vchImpresora"].Value = vchNombre;
            cmd.Parameters["@vchPrinterUSB"].Value = vchImpresora;
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
        public bool ActualizaRegistro(string vchNombreNew,string vchNombreOld, string vchImpresora)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "UPDATE  catImpresoras  SET vchImpresora = @vchNombreNew, vchPrinterUSB = @vchPrinterUSB,  " +
            " dfechaUp = GETDATE(), iidUsuario = " + Class_Session.Idusuario + " " +
            " WHERE vchImpresora = @vchNombreOld  ";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchNombreOld", SqlDbType.Char);
            cmd.Parameters.Add("@vchNombreNew", SqlDbType.Char);
            cmd.Parameters.Add("@vchPrinterUSB", SqlDbType.Char);
            cmd.Parameters["@vchNombreNew"].Value = vchNombreNew;
            cmd.Parameters["@vchNombreOld"].Value = vchNombreOld;
            cmd.Parameters["@vchPrinterUSB"].Value = vchImpresora;

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
        public bool BorrarImpresora(string vchNombre)
        {
            string sql = "DELETE FROM RelImpresion WHERE vchImpresora = '" + vchNombre + "' ";
            if(Conexion.InsertaSql(sql))
            {
                sql = "DELETE FROM catImpresoras WHERE vchImpresora = '" + vchNombre + "' ";
                Conexion.InsertaSql(sql);
            }
            return false;
        }
    }
}
