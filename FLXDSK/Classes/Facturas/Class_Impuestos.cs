using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.Facturas
{
    class Class_Impuestos
    {
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();

        public DataTable GetImpuestos()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT iidImpuesto as id, vchNombre as nombre FROM  catImpuestos (NOLOCK)  WHERE iidEstatus = 1 ";
            dt = conx.Consultasql(sql);
            return dt;
        }
        public DataTable GetImpuestosALL()
        {
            DataTable dt = new DataTable();
            string sql = " SELECT 0 as id, 'Todos' as nombre UNION ALL " +
                " SELECT iidImpuesto as id, vchNombre as nombre	 FROM  catImpuestos (NOLOCK)  WHERE iidEstatus = 1 ";
            dt = conx.Consultasql(sql);
            return dt;
        }
        public DataTable getImpuesto(string id)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT iidImpuesto, fimpuesto, vchTipo, vchSiglas, SiIVA FROM  catImpuestos (NOLOCK) WHERE iidImpuesto =  " + id;
            dt = conx.Consultasql(sql);
            return dt;
        }
    }
}
