using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.SAT
{
    class Class_TipoRelacion
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT iidTipoRelacion, vchCodigo, vchDescripcion FROM int_satTipoRelacionCFDI (NOLOCK) " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }
        public DataTable getListaCombo(string filtro)
        {
            string sql = "SELECT '0' iidTipoRelacion, ''vchCodigo, '' vchDescripcion " +
                " UNION ALL  " +
                " SELECT iidTipoRelacion, vchCodigo, vchDescripcion FROM int_satTipoRelacionCFDI (NOLOCK) " + filtro;
            return Conexion.Consultasql(sql);
        }
        public string getNamebyCode(string codigo)
        {
            string sql = "SELECT iidTipoRelacion, vchCodigo, vchDescripcion FROM int_satTipoRelacionCFDI (NOLOCK) WHERE vchCodigo = '" + codigo + "'";
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count == 0)
                return "";

            return dt.Rows[0]["vchDescripcion"].ToString();
        }


    }
}
