using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FLXDSK.Classes.Ventas
{
    class Class_MovimiendoDin
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = "SELECT iidMovimiento, dfechaIn, dfechaUp, iidEstatus, iidUsuario, iidTipoMovimiento, iidCorte, fMonto, vchComentario, siEntrada " +
            " FROM catMovimientoDinero (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public bool InsertaInformacion(string iidTipoMovimiento, string fMonto, string vchComentario, string siEntrada)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO catMovimientoDinero (dfechaIn, dfechaUp, iidEstatus, iidUsuario, iidTipoMovimiento, iidCorte, fMonto, vchComentario, siEntrada) " +
            " VALUES (getdate(), getdate(), 1, @iidUsuario, @iidTipoMovimiento, 0, @fMonto, @vchComentario, @siEntrada)";  //iidCorte estaba como 0 y tronaba
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@iidTipoMovimiento", SqlDbType.Int);
            cmd.Parameters.Add("@fMonto", SqlDbType.Float);
            cmd.Parameters.Add("@vchComentario", SqlDbType.Text);
            cmd.Parameters.Add("@siEntrada", SqlDbType.SmallInt);
            ///
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@iidTipoMovimiento"].Value = iidTipoMovimiento;
            cmd.Parameters["@fMonto"].Value = fMonto;
            cmd.Parameters["@vchComentario"].Value = vchComentario;
            cmd.Parameters["@siEntrada"].Value = siEntrada;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch(Exception x)
            {
                return false;
            }
        }
        public bool Borrar(string iidMovimiento)
        {
            string sql = "UPDATE catMovimientoDinero SET  dfechaUp = GETDATE(), iidEstatus = 2, iidUsuario = " + Class_Session.Idusuario + " WHERE iidMovimiento = " + iidMovimiento;
            return Conexion.InsertaSql(sql);
        }
    }
}
