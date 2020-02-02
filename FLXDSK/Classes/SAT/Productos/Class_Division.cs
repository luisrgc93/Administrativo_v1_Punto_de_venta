using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.SAT.Productos
{
    class Class_Division
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT vchCodigoDivision, vchTipo, vchClaveDivision, vchNombre " +
            " FROM int_satProductosDivision (NOLOCK) " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }
    }
}
