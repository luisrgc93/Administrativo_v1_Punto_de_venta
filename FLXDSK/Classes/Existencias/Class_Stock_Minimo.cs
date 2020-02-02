using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace FLXDSK.Classes.Existencias
{
    class Class_Stock_Minimo
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable stock_minimo()
        {
            string sql = " SELECT P.vchDescripcion Nombre, P.vchCodigo Codigo, " +
                         " CASE  " +
                         " WHEN U.iidUnidad = 1 AND SUM(E.fCantidad) > 1000 THEN SUM(E.fCantidad) / 1000 " +
                         " WHEN U.iidUnidad = 2 THEN SUM(E.fCantidad) / 29.574 " +
                         " WHEN U.iidUnidad = 3 AND SUM(E.fCantidad) > 1000 THEN SUM(E.fCantidad) / 1000 " +
                         " WHEN U.iidUnidad = 4 THEN SUM(E.fCantidad) / 1 " +
                         " WHEN U.iidUnidad = 5 AND SUM(E.fCantidad) > 1000 THEN SUM(E.fCantidad) / 1000 " +
                         " ELSE SUM(E.fCantidad) / 1000 END AS Cantidad,  " +
                         " CASE  " +
                         " WHEN U.iidUnidad = 1 AND SUM(E.fCantidad) >= 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 1 AND SUM(E.fCantidad) < 1000 THEN 'Mililitros' " +
                         " WHEN U.iidUnidad = 2 THEN 'Onzas' " +
                         " WHEN U.iidUnidad = 3 AND SUM(E.fCantidad) >= 1000 THEN 'Kilos' " +
                         " WHEN U.iidUnidad = 3 AND SUM(E.fCantidad) < 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 4 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 5 AND SUM(E.fCantidad) >= 1000 THEN 'Litros' " +
                         " WHEN U.iidUnidad = 5 AND SUM(E.fCantidad) < 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 6 AND SUM(E.fCantidad) >= 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 6 AND SUM(E.fCantidad) < 1000 THEN 'Gramos' " +
                         " END AS Unidad,  " +
                         " CASE  " +
                         " WHEN U.iidUnidad = 1 AND P.fStockMinimo > 1000 THEN P.fStockMinimo / 1000 " +
                         " WHEN U.iidUnidad = 2 THEN P.fStockMinimo / 29.574 " +
                         " WHEN U.iidUnidad = 3 AND P.fStockMinimo > 1000 THEN P.fStockMinimo / 1000 " +
                         " WHEN U.iidUnidad = 4 THEN P.fStockMinimo / 1 " +
                         " WHEN U.iidUnidad = 5 AND P.fStockMinimo > 1000 THEN P.fStockMinimo / 1000 " +
                         " ELSE P.fStockMinimo / 1000 END AS [Stock Minimo],  " +
                         " CASE  " +
                         " WHEN U.iidUnidad = 1 AND P.fStockMinimo >= 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 1 AND P.fStockMinimo < 1000 THEN 'Mililitros' " +
                         " WHEN U.iidUnidad = 2 THEN 'Onzas' " +
                         " WHEN U.iidUnidad = 3 AND P.fStockMinimo >= 1000 THEN 'Kilos' " +
                         " WHEN U.iidUnidad = 3 AND P.fStockMinimo < 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 4 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 5 AND P.fStockMinimo >= 1000 THEN 'Litros' " +
                         " WHEN U.iidUnidad = 5 AND P.fStockMinimo < 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 6 AND P.fStockMinimo >= 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 6 AND P.fStockMinimo < 1000 THEN 'Gramos' " +
                         " END AS [Unidad Stock] " +
                         " FROM catExistencias E " +
                         " INNER JOIN catProductos P ON E.iidProducto = P.iidProducto " +
                         " INNER JOIN catUnidadesMetricas U ON E.iidUnidadMetrica = U.iidUnidad " +
                         " AND E.fCantidad < P.fStockMinimo " +
                         " GROUP BY P.iidProducto, P.vchDescripcion, P.vchCodigo, U.iidUnidad, U.vchNombre, P.fStockMinimo " +
                         " UNION ALL " +
                         " SELECT M.vchDescripcion Nombre, M.vchCodigo Codigo, " +
                         " CASE  " +
                         " WHEN U.iidUnidad = 1 AND SUM(E.fCantidad) > 1000 THEN SUM(E.fCantidad) / 1000 " +
                         " WHEN U.iidUnidad = 2 THEN SUM(E.fCantidad) / 29.574 " +
                         " WHEN U.iidUnidad = 3 AND SUM(E.fCantidad) > 1000 THEN SUM(E.fCantidad) / 1000 " +
                         " WHEN U.iidUnidad = 4 THEN SUM(E.fCantidad) / 1 " +
                         " WHEN U.iidUnidad = 5 AND SUM(E.fCantidad) > 1000 THEN SUM(E.fCantidad) / 1000 " +
                         " ELSE SUM(E.fCantidad) / 1000 END AS Cantidad,  " +
                         " CASE  " +
                         " WHEN U.iidUnidad = 1 AND SUM(E.fCantidad) >= 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 1 AND SUM(E.fCantidad) < 1000 THEN 'Mililitros' " +
                         " WHEN U.iidUnidad = 2 THEN 'Onzas' " +
                         " WHEN U.iidUnidad = 3 AND SUM(E.fCantidad) >= 1000 THEN 'Kilos' " +
                         " WHEN U.iidUnidad = 3 AND SUM(E.fCantidad) < 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 4 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 5 AND SUM(E.fCantidad) >= 1000 THEN 'Litros' " +
                         " WHEN U.iidUnidad = 5 AND SUM(E.fCantidad) < 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 6 AND SUM(E.fCantidad) >= 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 6 AND SUM(E.fCantidad) < 1000 THEN 'Gramos' " +
                         " END AS Unidad,  " +
                         " CASE  " +
                         " WHEN U.iidUnidad = 1 AND M.fStockMinimo > 1000 THEN M.fStockMinimo / 1000 " +
                         " WHEN U.iidUnidad = 2 THEN M.fStockMinimo / 29.574 " +
                         " WHEN U.iidUnidad = 3 AND M.fStockMinimo > 1000 THEN M.fStockMinimo / 1000 " +
                         " WHEN U.iidUnidad = 4 THEN M.fStockMinimo / 1 " +
                         " WHEN U.iidUnidad = 5 AND M.fStockMinimo > 1000 THEN M.fStockMinimo / 1000 " +
                         " ELSE M.fStockMinimo / 1000 END AS [Stock Minimo],  " +
                         " CASE  " +
                         " WHEN U.iidUnidad = 1 AND M.fStockMinimo >= 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 1 AND M.fStockMinimo < 1000 THEN 'Mililitros' " +
                         " WHEN U.iidUnidad = 2 THEN 'Onzas' " +
                         " WHEN U.iidUnidad = 3 AND M.fStockMinimo >= 1000 THEN 'Kilos' " +
                         " WHEN U.iidUnidad = 3 AND M.fStockMinimo < 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 4 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 5 AND M.fStockMinimo >= 1000 THEN 'Litros' " +
                         " WHEN U.iidUnidad = 5 AND M.fStockMinimo < 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 6 AND M.fStockMinimo >= 1000 THEN U.vchNombre " +
                         " WHEN U.iidUnidad = 6 AND M.fStockMinimo < 1000 THEN 'Gramos' " +
                         " END AS [Unidad Stock] " +
                         " FROM catExistenciasMateriaPrima E " +
                         " INNER JOIN catMateriaPrima M ON E.iidMateriPrima = M.iidMateriPrima " +
                         " INNER JOIN catUnidadesMetricas U ON E.iidUnidadMetrica = U.iidUnidad " +
                         " AND E.fCantidad < M.fStockMinimo " +
                         " GROUP BY M.iidMateriPrima, M.vchDescripcion, M.vchCodigo, U.iidUnidad, U.vchNombre, M.fStockMinimo ";

            return Conexion.Consultasql(sql);
        }
    }
}
