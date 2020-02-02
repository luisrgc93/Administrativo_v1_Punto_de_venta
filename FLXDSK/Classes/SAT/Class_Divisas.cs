using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.SAT
{
    class Class_Divisas
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT iidDivisa, iidEstatus, vchClave, vchNombre FROM int_satDivisas (NOLOCK) " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }
        public string GetClave(string id)
        {
            string sql = "SELECT iidDivisa, iidEstatus, vchClave, vchNombre FROM int_satDivisas (NOLOCK) WHERE iidDivisa = " + id;
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count == 0)
                return "";
            return dt.Rows[0]["vchClave"].ToString();

        }

    }
}
