using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.SAT
{
    class Class_MetodoPago
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT iidMetodoPago, vchCodigoMetodoPago, vchDescripcion,  vchCodigoMetodoPago + '-' +vchDescripcion as CodigoNombre FROM int_satMetodoPago (NOLOCK) " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }
        public string GetClave(string id)
        {
            string sql = "SELECT iidMetodoPago, vchCodigoMetodoPago, vchDescripcion FROM int_satMetodoPago (NOLOCK) WHERE iidMetodoPago = " + id;
            DataTable dt =  Conexion.Consultasql(sql);
            if (dt.Rows.Count == 0)
                return "";

            return dt.Rows[0]["vchCodigoMetodoPago"].ToString();
        }
        public string getNameByCodigo(string codigo)
        {
            string sql = "SELECT iidMetodoPago, vchCodigoMetodoPago, vchDescripcion FROM int_satMetodoPago (NOLOCK) WHERE vchCodigoMetodoPago = '" + codigo + "'";
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count == 0)
                return "";

            return dt.Rows[0]["vchDescripcion"].ToString();
        }

    }
}
