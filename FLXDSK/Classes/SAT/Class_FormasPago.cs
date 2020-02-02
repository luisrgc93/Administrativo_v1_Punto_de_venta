using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.SAT
{
    class Class_FormasPago
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT iidFormaPago, vchCodigoFormaPago, vchDescripcion FROM int_satFormaPago (NOLOCK) " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }
        public string GetClave(string id)
        {
            string sql = "SELECT iidFormaPago, vchCodigoFormaPago, vchDescripcion FROM int_satFormaPago (NOLOCK) WHERE iidFormaPago = " + id;
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count == 0)
                return "";

            return dt.Rows[0]["vchCodigoFormaPago"].ToString();
        }
        public string getNameByCodigo(string codigo)
        {
            string sql = "SELECT iidFormaPago, vchCodigoFormaPago, vchDescripcion FROM int_satFormaPago (NOLOCK) WHERE vchCodigoFormaPago = '" + codigo + "'";
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count == 0)
                return "";

            return dt.Rows[0]["vchDescripcion"].ToString();
        }


    }
}
