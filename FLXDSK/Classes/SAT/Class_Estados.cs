using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.SAT
{
    class Class_Estados
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT iidEstado, iidPais, vchNombre, vchClave, vchIso FROM int_satEstados (NOLOCK) " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }
    }
}
