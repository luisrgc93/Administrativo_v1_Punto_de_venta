using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.SAT
{
    class Class_TipoUso
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT iidTipoUsoCFDI, vchDescripcion, vchClave FROM int_satTipoUsoCFDI (NOLOCK) " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }
        public string getName(string codigo)
        {
            string sql = "SELECT iidTipoUsoCFDI, vchDescripcion, vchClave FROM int_satTipoUsoCFDI (NOLOCK) WHERE vchClave = '" + codigo + "'";
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count == 0)
                return "";

            return dt.Rows[0]["vchDescripcion"].ToString();
        }
    }
}
