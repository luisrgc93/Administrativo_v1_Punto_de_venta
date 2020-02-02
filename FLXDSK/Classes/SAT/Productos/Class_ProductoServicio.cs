using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.SAT.Productos
{
    class Class_ProductoServicio
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT vchCodigo, vchCodigoDivision, vchCodigoGrupo, vchCodigoClase, "+
                " vchNombre, vchIVA, vchIEPS  " +
            " FROM int_satProductoServicio (NOLOCK) " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }
    }
}
