using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes
{
    class Class_DetalleRequisiciones
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();


        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = " SELECT iidDetReq, iidReq, dfechaIn, dfechaUp, iidMateriPrima, iCantidad " +
            " FROM catDetalleRequisicion (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public DataTable getLista(string filtro)
        {
            string sql = " SELECT D.iidDetReq, D.iidReq, D.dfechaIn, D.dfechaUp, D.iidMateriPrima, D.iCantidad, " +
                " C.vchDescripcion Categoria, " +
                " M.vchCodigo, M.vchDescripcion, " +
	            " U.vchNombre Medida " +
            " FROM catDetalleRequisicion D, catMateriaPrima M (NOLOCK), catUnidadesMetricas U (NOLOCK), catCategoriasMateriaPrima C (NOLOCK) " +
            " WHERE D.iidMateriPrima = M.iidMateriPrima " +
            " AND M.iidunidad = U.iidUnidad " + 
            " AND M.iidCategoriaMateriPrima = C.iidCategoriaMateriPrima " +
            " " + filtro;
            return Conexion.Consultasql(sql);
        }

    }
}
