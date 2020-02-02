using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.Nomina
{
    class Class_TipoJornada
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        public DataTable GetListaSeleccion()
        {
            DataTable dt = new DataTable();
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre UNION ALL " +
                " SELECT iidTipoJornada as id, vchDescripcion as nombre	 FROM  CatTipoJornada (NOLOCK)   WHERE iidEstatus = 1 ";
            dt = Conexion.Consultasql(sql);
            return dt;
        }
        public DataTable GetLista()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT iidTipoJornada as id, vchDescripcion as nombre FROM  CatTipoJornada (NOLOCK)   WHERE iidEstatus = 1 ";
            dt = Conexion.Consultasql(sql);
            return dt;
        }
        public DataTable getId(string id)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT iidTipoJornada as id, vchDescripcion as nombre FROM  CatTipoJornada (NOLOCK)   WHERE iidEstatus = 1 AND iidTipoJornada = '" + id + "'";
            dt = Conexion.Consultasql(sql);
            return dt;
        }
        public string getNameTipoJoranada(string id) {
            string sql = "SELECT vchDescripcion FROM CatTipoJornada (NOLOCK) WHERE  iidTipoJornada  = " + id;
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
