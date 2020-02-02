using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes
{
    class Class_GastosFijos
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public bool borrar_Gasto(string idGasto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "update catGastosFijos set iidEstatus = 2 where iidGasto =  " + idGasto;
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

        public DataTable obtener_datos_xID(string idGasto)
        {

            string sql = " select vchTipo tipo, vchDescripcion descripcion, fMonto monto, dFechaInicio inicio, dFechaFin fin, siMensual " +
                         " from catGastosFijos (NOLOCK) " +
                         " where iidGasto = " + idGasto ;

            return Conexion.Consultasql(sql);
        }

        public bool inserta_pago(DataTable info)
        {
            DataRow Row = info.Rows[0];
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " insert into catGastosFijos (dfechaIn, dfechaUp, iidEstatus, iidUsuario, vchTipo, vchDescripcion, fMonto, dFechaInicio, dFechaFin, siMensual) " +
                         " values (getdate(), getdate(), 1,@iidusuario,@tipo,@descripcion,@monto,@inicio,@fin,@siMensual)";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidusuario", SqlDbType.Int);
            cmd.Parameters.Add("@tipo", SqlDbType.Text);
            cmd.Parameters.Add("@inicio", SqlDbType.DateTime);
            cmd.Parameters.Add("@fin", SqlDbType.DateTime);
            cmd.Parameters.Add("@monto", SqlDbType.Float);
            cmd.Parameters.Add("@descripcion", SqlDbType.Text);
            cmd.Parameters.Add("@siMensual", SqlDbType.Int);
            ///
            cmd.Parameters["@iidusuario"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@tipo"].Value = Row["tipo"].ToString();
            cmd.Parameters["@inicio"].Value = Row["inicio"].ToString();
            cmd.Parameters["@fin"].Value = Row["fin"].ToString();
            cmd.Parameters["@monto"].Value = Row["monto"].ToString();
            cmd.Parameters["@descripcion"].Value = Row["descripcion"].ToString();
            cmd.Parameters["@siMensual"].Value = Row["siMensual"].ToString();

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

        public bool actualiza_pago(DataTable info)
        {
            DataRow Row = info.Rows[0];
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " update catGastosFijos " + 
                         " set dfechaUp = GETDATE(), " +
                         " iidUsuario = @iidusuario, " +
                         " vchTipo = @tipo," +
                         " vchDescripcion = @descripcion, " +
                         " fMonto = @monto, " +
                         " dFechaInicio = @inicio," +
                         " dFechaFin = @fin," +
                         " siMensual = @siMensual " +
                         " where iidGasto = @iidGasto";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidusuario", SqlDbType.Int);
            cmd.Parameters.Add("@inicio", SqlDbType.DateTime);
            cmd.Parameters.Add("@fin", SqlDbType.DateTime);
            cmd.Parameters.Add("@monto", SqlDbType.Float);
            cmd.Parameters.Add("@descripcion", SqlDbType.Text);
            cmd.Parameters.Add("@tipo", SqlDbType.Text);
            cmd.Parameters.Add("@iidGasto", SqlDbType.Int);
            cmd.Parameters.Add("@siMensual", SqlDbType.Int);
            ///
            cmd.Parameters["@iidusuario"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@inicio"].Value = Row["inicio"].ToString();
            cmd.Parameters["@fin"].Value = Row["fin"].ToString();
            cmd.Parameters["@monto"].Value = Row["monto"].ToString();
            cmd.Parameters["@descripcion"].Value = Row["descripcion"].ToString();
            cmd.Parameters["@tipo"].Value = Row["tipo"].ToString();
            cmd.Parameters["@iidGasto"].Value = Row["idGasto"].ToString();
            cmd.Parameters["@siMensual"].Value = Row["siMensual"].ToString();

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
