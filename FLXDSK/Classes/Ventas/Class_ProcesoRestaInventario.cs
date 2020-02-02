using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.Ventas
{
    class Class_ProcesoRestaInventario
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Inventarios.Class_ExistenciaMP ClsExiMP = new Inventarios.Class_ExistenciaMP();
        //Classes.Ventas.Class_DetallePedido ClsDetPedido = new Classes.Ventas.Class_DetallePedido();

        public void RestaExisteciaVenta(string idPedido)
        {
            string sql = " " +
            " SELECT D.iidProducto, D.fCantidad, R.iidMateriPrima, R.fCantidad, " +
                " P.iidAlmacen, " +
                " (D.fCantidad * R.fCantidad)CatidadTotal " +
            " FROM catDetallePedido D (NOLOCK), catProductos P(NOLOCK), RelProductoMateriaprima  R (NOLOCK), catMateriaPrima M (NOLOCK) " +
            " WHERE D.iidProducto = R.iidProducto " +
            " AND D.iidProducto = P.iidProducto " +
            " AND D.iidPedido = " + idPedido +
            " AND M.iidMateriPrima =  R.iidMateriPrima " +
            " AND M.siInventariar = 1 ";
            DataTable dtRestar = Conexion.Consultasql(sql);
            if (dtRestar.Rows.Count > 0)
            {
                foreach (DataRow Row in dtRestar.Rows)
                {
                    string idAlmacen = Row["iidAlmacen"].ToString();
                    string iidMateriPrima = Row["iidMateriPrima"].ToString();
                    string CatidadTotal = Row["CatidadTotal"].ToString();

                    ClsExiMP.ActualizaRestandoInformacion(iidMateriPrima, idAlmacen, CatidadTotal);
                }
            }
        }
    }
}
