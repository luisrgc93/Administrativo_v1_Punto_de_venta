using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.Nomina
{
    class Class_RegimenEmpleado
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        public DataTable GetListaSeleccion()
        {
            DataTable dt = new DataTable();
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre UNION ALL " +
                " SELECT iidRegimenFiscal as id, vchDescripcion as nombre	 FROM  int_satRegimenFiscal (NOLOCK)   WHERE iidEstatus = 1 ";
            dt = Conexion.Consultasql(sql);
            return dt;
        }
        public DataTable GetLista()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT iidRegimenFiscal as id, vchDescripcion as nombre FROM  int_satRegimenFiscal (NOLOCK)   WHERE iidEstatus = 1 ";
            dt = Conexion.Consultasql(sql);
            return dt;
        }
        public DataTable getId(string id) {
            DataTable dt = new DataTable();
            string sql = "SELECT iidRegimenFiscal as id, vchDescripcion as nombre FROM  int_satRegimenFiscal (NOLOCK)   WHERE iidEstatus = 1 AND iidRegimen = '" + id + "'";
            dt = Conexion.Consultasql(sql);
            return dt;
        }

    }
}
