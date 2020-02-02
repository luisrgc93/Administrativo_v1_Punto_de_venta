using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.Catalogos
{
    class Class_TiposCfdi
    {
        /*Conexion.Class_Conexion conx = new Conexion.Class_Conexion();

        public DataTable GetTiposCfdis()
        {
            string sql = "SELECT * FROM CatTiposCfdi (NOLOCK) WHERE iidEstatus IN (1) ";
            return conx.Consultasql(sql);
        }
        public string GetTipoCfdi(string id)
        {
            string sql = "SELECT vchNombre FROM CatTiposCfdi (NOLOCK) WHERE iidTipoCfdi =  " + id;
            DataTable dt = new DataTable();
            dt = conx.Consultasql(sql);
            DataRow Row = dt.Rows[0];
            return Row["vchNombre"].ToString();
        }

        public DataTable getTiposCfdisAll()
        {
            DataTable dt = new DataTable();
            string sql = " SELECT 0 as id, 'Todos' as nombre UNION ALL " +
                         " SELECT iidTipoCfdi as id, vchNombre as nombre  FROM  CatTiposCfdi (NOLOCK) WHERE iidEstatus = 1  ";
            dt = conx.Consultasql(sql);
            return dt;
        }
        public string getMeTipoComprobante(string tipocfdi)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT vchTipo FROM CatTiposCfdi (NOLOCK) WHERE iidTipoCfdi = " + tipocfdi;
            dt = conx.Consultasql(sql);
            DataRow dr = dt.Rows[0];

            return dr["vchTipo"].ToString();
        }*/
    }
}
