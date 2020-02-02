using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.Inventarios
{
    class Class_ProcesoAjuste
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();


        public DataTable getListaProdExis(string filtro, string idAlmacen)
        {
            string sql = " SELECT M.iidMateriPrima, M.vchCodigo, M.siInventariar, M.vchDescripcion, M.fCosto,  " +
                " CASE WHEN E.fCantidad IS NULL THEN 0 ELSE E.fCantidad END Existencia,  " +
                " CASE U.vchNombre  " +
		              " WHEN 'Kilos' THEN 'Gramos'  " +
		              " WHEN 'Litros' THEN 'Mililitros' " +
                      " ELSE U.vchNombre  " +
	            " END UnidadMinima " +
            " FROM catUnidadesMetricas U (NOLOCK), catMateriaPrima (NOLOCK) M LEFT OUTER JOIN catExistenciasMateriaPrima E (NOLOCK) " +
	            " ON M.iidMateriPrima = E.iidMateriPrima  " +
	            " AND E.iidAlmacen  = " + idAlmacen +
	            " AND M.iidUnidad = E.iidUnidadMetrica  " +
            " WHERE M.iidEstatus = 1  " +
            " AND U.iidUnidad = M.iidUnidad " + 
            "  " + filtro;
            return Conexion.Consultasql(sql);
        }
    }
}
