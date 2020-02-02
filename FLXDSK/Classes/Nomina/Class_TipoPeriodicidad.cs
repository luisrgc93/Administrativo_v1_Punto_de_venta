using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.Nomina
{
    class Class_TipoPeriodicidad
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        public DataTable GetListaSeleccion()
        {
            DataTable dt = new DataTable();
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre UNION ALL " +
                " SELECT iidPeriodicidad as id, vchDescripcion as nombre	 FROM  CatPeriodicidadPago (NOLOCK)   WHERE iidEstatus = 1 ";
            dt = Conexion.Consultasql(sql);
            return dt;
        }
        public DataTable GetLista()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT iidPeriodicidad as id, vchDescripcion as nombre FROM  CatPeriodicidadPago (NOLOCK)   WHERE iidEstatus = 1 ";
            dt = Conexion.Consultasql(sql);
            return dt;
        }
        public DataTable getId(string id)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT iidPeriodicidad as id, vchDescripcion as nombre FROM  CatPeriodicidadPago (NOLOCK)   WHERE iidEstatus = 1 AND iidPeriodicidad = '" + id + "'";
            dt = Conexion.Consultasql(sql);
            return dt;
        }
    }
}
