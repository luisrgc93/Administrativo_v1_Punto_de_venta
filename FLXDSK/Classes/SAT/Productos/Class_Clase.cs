using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.SAT.Productos
{
    class Class_Clase
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT vchCodigoClase, vchCodigoDivision, vchCodigoGrupo, vchClaveClase, vchNombre " +
            " FROM int_satProductosClase (NOLOCK) " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }
    }
}
