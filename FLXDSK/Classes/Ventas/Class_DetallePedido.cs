using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.Ventas
{
    class Class_DetallePedido
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getDetallePedido(string pedido)
        {
            string sql = " " +
            " SELECT P.iidProducto, P.vchDescripcion, " +
                " MAX(D.fPrecio)fPrecio, SUM(D.fCantidad)fCantidad, " +
                " CASE WHEN SUM(D.fImporte) IS NULL THEN 0 ELSE SUM(D.fImporte) END  fImporte, " +
                " SUM(D.fImporte) - (SUM(D.fCantidad) * MAX(P.fCosto)) fGanancia  " +
            " FROM catDetallePedido D (NOLOCK), catProductos P (NOLOCK)  " +
            " WHERE D.iidProducto = P.iidProducto  " +
            " AND D.iidPedido = " + pedido +
            " GROUP BY P.iidProducto, P.vchDescripcion ";
            return Conexion.Consultasql(sql);
        }

        public DataTable getDetalleJsonAutoFactura(string idPedido)
        {
            string sql = " " +
            " SELECT  " +
                " P.vchCodigo vchCodigoProducto, " +
                " P.vchDescripcion Descripcion, " +
                " D.fPrecio fPrecio, " +
                " 'PIEZA' Unidad, " +
                " D.fCantidad Cantidad, " +
                //" D.fImporte Importe, " +
                " CASE P.SiIVA WHEN 1 THEN ROUND(D.fImporte/1.16,6) ELSE D.fImporte END Importe, " +
	            " CASE P.SiIVA WHEN 1 THEN ROUND(D.fImporte/1.16,6)*0.16 ELSE 0 END IVA, " +
                " P.vchCodigoSat CveCodigo, " +
                " P.SiIVA, " +
                " M.vchClave CveMedida, " +
                " 0 Descuento, " +
                " D.fImporte Total " +
                "  " +
            " FROM catDetallePedido D (NOLOCK), catProductos P (NOLOCK), int_satUnidadMedida M (NOLOCK) " +
            " WHERE D.iidProducto = P.iidProducto " +
            " AND P.iidUnidadMedida = M.iidUnidadMedida " +
            " AND D.iidPedido = " + idPedido;

            return Conexion.Consultasql(sql);
        }









        public bool SetCantidadAll0(string IdPedido, string iidProducto)
        {
            string sql = " UPDATE catDetallePedido SET fCantidad = 0 " +
                   " WHERE iidPedido = " + IdPedido +
                   " AND iidProducto = " + iidProducto;
            return Conexion.InsertaSql(sql);
        }
        public bool InsertaCantidades(string IdPedido, string iidProducto, int Insertar)
        {
            for (int i = 1; i <= Insertar; i++)
            {
                string sql = " INSERT INTO catDetallePedido (iidPedido, iidProducto, fPrecio, fDescuento, fCantidad, fImporte, dfechaIn, vchComentario, siImpreso ) " +
                " SELECT TOP 1 iidPedido, iidProducto, fPrecio, fDescuento, fCantidad, fImporte, GETDATE() dfechaIn, NULL vchComentario, 1 siImpreso " +
                " FROM catDetallePedido  " +
                " WHERE iidPedido = " + IdPedido +
                " AND iidProducto = " + iidProducto;
                Conexion.InsertaSql(sql);
            }
            return true;
        }
        public bool RestaCantidades(string IdPedido, string iidProducto, int Cantidad)
        {
            string sql = " DELETE FROM catDetallePedido " +
            " WHERE iidDetallePedido NOT IN  " +
                " ( SELECT TOP " + Cantidad + " iidDetallePedido FROM catDetallePedido  " +
                    " WHERE iidPedido =  " + IdPedido +
		            " AND iidProducto = " + iidProducto+ " ORDER BY iidDetallePedido DESC  ) ";
            return Conexion.InsertaSql(sql);
        }
        public bool RecalculaPedido(string iidPedido)
        {
            string sql = "DELETE FROM catDetallePedido WHERE fCantidad <= 0 AND iidPedido = " + iidPedido;
            if (!Conexion.InsertaSql(sql))
                return false;

            //ActualizamosMonto subTotal pedido
            string sqlUp = " UPDATE catpedidos SET fSubtotal = ( SELECT SUM(fimporte) FROM catDetallePedido (NOLOCK) WHERE iidPedido = " + iidPedido + " )  WHERE iidPedido =  " + iidPedido;
            Conexion.InsertaSql(sqlUp);

            //Actualizamos DEscuento
            string sqlDes = " " +
            " IF (SELECT iidCupon FROM catpedidos P (NOLOCK) WHERE iidPedido =  " + iidPedido + "  AND (iidCupon = 0 OR iidCupon is null) ) IS NULL " +
                " UPDATE catPedidos SET fDescuento = 0 WHERE iidPedido = " + iidPedido +" " + 
            " ELSE " +
	            " UPDATE catPedidos SET  fDescuento = CASE WHEN ((P.Fsubtotal *  C.fdescuento)/100) IS NULL THEN 0 ELSE ((P.Fsubtotal *  C.fdescuento)/100)END " +
	            " FROM catpedidos P (NOLOCK), catCuponDescuento C (NOLOCK)  " +
	            " WHERE  P.iidCupon = C.iidCupon " +
	            " AND iidPedido = " + iidPedido;
            Conexion.InsertaSql(sqlDes);

            //actualizmos TOTAL
            string sqlTotal = "update catpedidos SET fTotal  = (fSubtotal - fDescuento) WHERE iidpedido = " + iidPedido;
            return Conexion.InsertaSql(sqlTotal);
        }

        //////////////////////
    }
}
