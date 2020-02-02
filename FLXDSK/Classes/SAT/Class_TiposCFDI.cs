using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.SAT
{
    class Class_TiposCFDI
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT iidTipoComprobante, vchDescripcion, vchCodigo FROM int_satTipoComprobante (NOLOCK) " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }
        public string GetClave(string id)
        {
            string sql = "SELECT iidTipoComprobante, vchCodigo, vchDescripcion FROM int_satTipoComprobante (NOLOCK) WHERE iidTipoComprobante = " + id;
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count == 0)
                return "";

            return dt.Rows[0]["vchCodigo"].ToString();
        }
        public string getNameByCodigo(string codigo)
        {
            string sql = "SELECT iidTipoComprobante, vchCodigo, vchDescripcion FROM int_satTipoComprobante (NOLOCK) WHERE vchCodigo = '" + codigo + "'";
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count == 0)
                return "";

            return dt.Rows[0]["vchDescripcion"].ToString();
        }
    }
}
