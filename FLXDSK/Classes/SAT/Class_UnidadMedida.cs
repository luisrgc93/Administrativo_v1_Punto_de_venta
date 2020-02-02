using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.SAT
{
    class Class_UnidadMedida
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT iidUnidadMedida,iidEstatus,vchClave,vchNombre,vchDescripcion,vchSimbolo  " +
            " FROM int_satUnidadMedida (NOLOCK) " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }
    }
}
