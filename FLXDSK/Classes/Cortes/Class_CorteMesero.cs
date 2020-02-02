using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FLXDSK.Classes.Cortes
{
    class Class_CorteMesero
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaMeserosPendientes()
        {
            string sql = "SELECT '0' Id, 'Seleccionar' Nombre " +
            " UNION ALL " +
            " SELECT PE.iidPersonal, MAX(PE.vchNombres) + ' ' + MAX(PE.vchApellidoPat) + ' ' + MAX(PE.vchApellidoMat) as Nombre " +
            " FROM catPedidos (NOLOCK) P, catPersonal  PE (NOLOCK) " +
            " WHERE P.iidPersonal = PE.iidPersonal  " +
            " AND P.iidEstatus = 1 " +
            " AND P.siPagado = 1 " +
            " AND P.iidCorteMesero = 0 " +
            " GROUP BY PE.iidPersonal ";
            return Conexion.Consultasql(sql);
        }
        public bool InsertaInformacion(string iidPersonal, double fPorcentajeProObjetivo, double fPorcentCorresponde)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);

            string sql = "INSERT INTO catCortesMeseros (iidPersonal, iidEstatus, iidUsuario, dfechaIn, fVentaTotal, fPropinaObjetivo, fPropinaReal, fPropinaCorresponde, fPromedioPersonas, iNumPedidos) " +
            " SELECT P.iidPersonal, 1, @iidUsuario, GETDATE(), SUM(P.fTotal),  ROUND((" + fPorcentajeProObjetivo + " * SUM(P.fTotal))/100,2) , SUM(P.fPropina),   ROUND((" + fPorcentCorresponde + " * SUM(P.fPropina))/100,2),  AVG(iNumPersonas), COUNT(*) " +
            " FROM catPedidos (NOLOCK) P " +
            " WHERE P.iidEstatus = 1 " +
            " AND P.iidCorteMesero =  0 " +
            " AND P.iidPersonal =  " + iidPersonal  +
            " GROUP BY P.iidPersonal ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int).Value = usuariolog;
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
        public bool ProcesaCortesMesero(string IdCorteMesero)
        {
            string sql = "UPDATE catPedidos SET iidCorteMesero = " + IdCorteMesero + " WHERE iidEstatus = 1 AND iidCorteMesero = 0 ";
            return Conexion.InsertaSql(sql);
        }

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = "SELECT iidCorteMesero, iidPersonal, iidEstatus, iidUsuario, CONVERT(varchar(10),dfechaIn,103)dfechaIn103, " +
            " CONVERT(varchar(5),dfechaIn,108) dfechaIn108, " +
            " fVentaTotal, fPropinaObjetivo, fPropinaReal, fPropinaCorresponde, fPromedioPersonas, iNumPedidos " +
            " FROM catCortesMeseros (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public string getIdCorteCreado()
        {
            string sql = " SELECT MAX(iidCorteMesero) folio FROM catCortesMeseros (NOLOCK) " ;
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count == 0)
                return "0";

            return dt.Rows[0]["folio"].ToString();
        }
    }
}
