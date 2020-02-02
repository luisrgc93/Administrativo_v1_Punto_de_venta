using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.SAT
{
    class Class_Paises
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT iidPais, vchNombre, vchClave FROM int_satPaises(NOLOCK) " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }
    }
}
