using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Existencias
{
    class Class_Abonos
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();

        public bool InsertaInformacion(string iidCompra, string fAbono, string iidFormaPago)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO catAbonos(iidCompra, dfechaAbono, fAbono, dFechaUp,iidEstatus, iidFormaPago) " +
            " VALUES(" + iidCompra + ",GETDATE()," + fAbono + ",GETDATE(),1," + iidFormaPago + ") ";
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                DataTable Info_Excepcion = new DataTable();
                DataRow row_Excepcion;

                Info_Excepcion.Columns.Add("vchExcepcion", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchLugar", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchAccion", System.Type.GetType("System.String"));

                row_Excepcion = Info_Excepcion.NewRow();
                row_Excepcion["vchExcepcion"] = exp;
                row_Excepcion["vchLugar"] = "Class_Areas";
                row_Excepcion["vchAccion"] = "funcion (inserta_area)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public bool borrar_abono(string idcompra, string idabono)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catAbonos SET iidEstatus = 2, dfechaUp = GETDATE() WHERE iidAbono = " + idabono + " AND iidCompra = " + idcompra;

            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                DataTable Info_Excepcion = new DataTable();
                DataRow row_Excepcion;

                Info_Excepcion.Columns.Add("vchExcepcion", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchLugar", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchAccion", System.Type.GetType("System.String"));

                row_Excepcion = Info_Excepcion.NewRow();
                row_Excepcion["vchExcepcion"] = exp;
                row_Excepcion["vchLugar"] = "Class_Areas";
                row_Excepcion["vchAccion"] = "funcion (borrar_area)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public string obtener_total_abonado(string idcompra)
        {
            DataTable dt = new DataTable();
            string sql = " SELECT SUM(iAbono) AS Total " +
                         " FROM catAbonos " +
                         " WHERE iidCompra = " + idcompra + 
                         " AND iidEstatus = 1";
            try
            {

                dt = Conexion.Consultasql(sql);
                DataRow row = dt.Rows[0];
                return row["Total"].ToString();

            }
            catch
            {
                return "";
            }
        }

        public DataTable getLista(string filtro)
        {
            string sql = " " +
            " SELECT A.iidAbono, C.vchSerie+'-'+CAST(C.iFolio as varchar(10))Folio, " +
                " CONVERT(VARCHAR(10),A.dfechaAbono,103) AS dfechaAbono103,  " +
	            " F.vchDescripcion, " +
	            " A.fAbono  " +
            " FROM catCompras C (NOLOCK), catAbonos A (NOLOCK), int_satFormaPago F (NOLOCK) " +
            " WHERE A.iidCompra = C.iidCompra  " +
            " AND A.iidFormaPago = F.iidFormaPago  " +
            " AND A.iidEstatus = 1 " + filtro;
            return Conexion.Consultasql(sql);
        }
    }
}
