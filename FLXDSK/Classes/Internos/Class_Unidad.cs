using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.Internos
{
    class Class_Unidad
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable GetUnidadesALL()
        {
            DataTable dt = new DataTable();
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre UNION ALL " +
                " SELECT iidUnidad as id, vchNombre as nombre	 FROM  catUnidadesProductos (NOLOCK)  WHERE iidEstatus = 1";
            dt = Conexion.Consultasql(sql);
            return dt;
        }
        public DataTable GetUnidadesSinPieza()
        {
            DataTable dt = new DataTable();
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre UNION ALL " +
                " SELECT iidUnidad as id, vchNombre as nombre	 FROM  catUnidadesProductos (NOLOCK)  WHERE iidEstatus = 1";
            dt = Conexion.Consultasql(sql);
            return dt;
        }
    }
}
