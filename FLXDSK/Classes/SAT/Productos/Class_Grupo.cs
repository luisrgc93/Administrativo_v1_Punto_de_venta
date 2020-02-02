using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.SAT.Productos
{
    class Class_Grupo
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT vchCodigoGrupo, vchCodigoDivision, vchClaveGrupo, vchNombre " +
            " FROM int_satProductosGrupo (NOLOCK) " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }
    }
}
