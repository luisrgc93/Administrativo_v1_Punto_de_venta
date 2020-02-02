using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.Nomina
{
    class Class_TipoContrato
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        public DataTable GetListaSeleccion()
        {
            DataTable dt = new DataTable();
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre UNION ALL " +
                " SELECT iidTipoContrato as id, vchDescripcion as nombre	 FROM  CatTipoContrato (NOLOCK)   WHERE iidEstatus = 1 ";
            dt = Conexion.Consultasql(sql);
            return dt;
        }
        public DataTable GetLista()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT iidTipoContrato as id, vchDescripcion as nombre FROM  CatTipoContrato (NOLOCK)   WHERE iidEstatus = 1 ";
            dt = Conexion.Consultasql(sql);
            return dt;
        }
        public DataTable getId(string id)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT iidTipoContrato as id, vchDescripcion as nombre FROM  CatTipoContrato (NOLOCK)   WHERE iidEstatus = 1 AND iidTipoContrato = '" + id + "'";
            dt = Conexion.Consultasql(sql);
            return dt;
        }
        public string getNombre(string id) {
            string sql = "select vchDescripcion FROM CatTipoContrato (NOLOCK)   WHERE  iidTipoContrato="+id;
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
            {
                DataRow Row = dt.Rows[0];
                return Row["vchDescripcion"].ToString();
            }
            else return "";
        }
    }
}
