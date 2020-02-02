using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes
{
    class Class_Reportes
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();


        public DataTable getListaPedidos(string filtro)
        {
            string sql = "SELECT P.iidPedido, CONVERT( varchar(10),P.dfechaIn,103)fecha, " +
                " PE.vchNombres + ' ' + PE.vchApellidoPat + ' ' + PE.vchApellidoMat AS Nombre, " +
	            " M.vchDescripcion Mesa, A.vchNombre Area,  " +
	            " P.fSubtotal, P.fDescuento, P.fTotal,  P.fGanancia, " +
	            " P.iNumPersonas " +
            " FROM catPedidos P, catPersonal PE, catMesas M, catAreas A  " +
            " WHERE P.iidPersonal = PE.iidPersonal " +
            " AND P.iidMesa = M.iidMesa " +
            " AND A.iidArea = M.iidArea " + filtro;
            return Conexion.Consultasql(sql);
        }
        public DataTable getListaDetallePedidos(string Filtro)
        {
            string sql = " " +
            " SELECT  " +
	            " P.iidPedido, MAx(PR.vchDescripcion)vchDescripcion, MAX(vchNombre)Categoria, " +
	            " CASE WHEN MAX(PR.siComida) = '1' THEN 'Comida' ELSE 'Bebida' END tipo, " +
	            " MAX(D.fPrecio)fPrecio, SUM(D.fCantidad)Cantidad,  " +
                    " SUM(D.fDescuento)fDescuento, SUM(D.fImporte)fImporte , sum(D.fCantidad*D.fImporte)total " +
            " FROM catPedidos P, catDetallePedido D, catProductos PR , catCategorias C  " +
            " WHERE D.iidPedido = P.iidPedido " +
            " AND PR.iidProducto = D.iidProducto  " +
            " AND PR.iidCategoria = C.iidCategoria " +
            " AND P.iidEstatus = 1 "+Filtro +
                 " " +
            " GROUP BY P.iidPedido " +
            " ORDER BY P.iidPedido";
            return Conexion.Consultasql(sql);
        }


        /// <summary>
        /// ///////Reportes END Update 
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>










        public DataTable Reporte_Detalle_Movimientos(string filtro)
        {
            string sql = " SELECT  CASE WHEN iTipo_producto = 1 THEN 'Materia Prima' ELSE 'Productos' " +
                         " END AS Tipo, CASE WHEN iTipo_producto = 1 THEN M.vchDescripcion ELSE P.vchDescripcion " +
                         " END AS descripcion,CASE WHEN iTipo_producto = 1 THEN M.vchCodigo ELSE P.vchCodigo " +
                         " END AS codigo, R.iCantidad / U.iEquivalencia Cantidad, " +
                         " U.vchNombre, A1.vchNombre origen, A2.vchNombre destino,  " +
                         " CONVERT(VARCHAR(10),MO.dfechaIn,103) AS fecha, R.iidMovimiento " +
                         " FROM RelAlmacenMovimiento R " +
                         " INNER JOIN catUnidadesMetricas U ON R.iidUnidad = U.iidUnidad " +
                         " INNER JOIN catMateriaPrima M ON R.iidProducto = M.iidMateriPrima " +
                         " INNER JOIN catProductos P ON R.iidProducto = P.iidProducto " +
                         " INNER JOIN catMovimientos MO ON R.iidMovimiento = MO.iidMovimiento " +
                         " INNER JOIN catAlmacenes A1 ON MO.iidAlmacenOrigen = A1.iidAlmacen  " + 
                         " INNER JOIN catAlmacenes A2 ON MO.iidAlmacenDestino = A2.iidAlmacen  " +
                         " AND r.iidMovimiento = " + filtro;

            return Conexion.Consultasql(sql);
        }


        /*------------------------------------------- Reporte de Existencia de Materia Prima -------------------------------------------------------*/
        public DataTable getAlmacenAll()
        {

            string sql = " SELECT 0 as id, 'Seleccionar' as nombre  " +
                         " UNION ALL " +
                         " SELECT iidAlmacen as id, vchNombre as nombre  " +
                         " FROM catAlmacenes " +
                         " WHERE iidEstatus = 1 ";

            return Conexion.Consultasql(sql);
        }

        public DataTable getCategoriaAll()
        {
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre  " +
                         " UNION ALL " +
                         " SELECT iidCategoriaMateriPrima as id, vchDescripcion as nombre  " +
                         " FROM catCategoriasMateriaPrima " +
                         " WHERE iidEstatus = 1 ";

            return Conexion.Consultasql(sql);
        }

        public DataTable getTipoAll()
        {
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre  " +
                         " UNION ALL " +
                         " SELECT iidUnidad as id, vchNombre as nombre  " +
                         " FROM catUnidadesMetricas " +
                         " WHERE iidEstatus = 1 ";

            return Conexion.Consultasql(sql);
        }

        public DataTable Reporte_Existencia(string filtro)
        {

            string sql = " select E.iidMateriPrima id, E.fCantidad cantidad, A.vchNombre almacen, U.vchNombre unidad, M.vchDescripcion materia_prima, C.vchDescripcion categoria " +
                         " from catExistenciasMateriaPrima E " +
                         " INNER JOIN catAlmacenes A ON A.iidAlmacen = E.iidAlmacen " +
                         " INNER JOIN catUnidadesMetricas U ON U.iidUnidad = E.iidUnidadMetrica " +
                         " INNER JOIN catMateriaPrima M ON M.iidMateriPrima = E.iidMateriPrima " + filtro +
                         " INNER JOIN catCategoriasMateriaPrima C ON C.iidCategoriaMateriPrima = M.iidCategoriaMateriPrima";

            return Conexion.Consultasql(sql);
        }

        /*------------------------------------------- Reporte de Cupones ya caducados o usados -------------------------------------------------------*/
        public DataTable Reporte_Cupones()
        {

            string sql = " select C.iidCupon id, CONVERT(VARCHAR(10),C.dfechain,103) fecha_Insercción, CONVERT(VARCHAR(10),C.dfechaVence,103) fecha_Vencimiento, C.vchCodigo Código, C.fdescuento descuento, P.fDescuento cantDesc " +
                         " from catCuponDescuento C" + 
                         " LEFT JOIN catPedidos P ON P.iidCupon = C.iidCupon " +
                         " where C.SiUtilizado != 0 or CONVERT(VARCHAR(10),C.dfechaVence,103) < GETDATE()";
            return Conexion.Consultasql(sql);
        }

        

        /*------------------------------------------- Reporte de Tiempos -------------------------------------------------------*/
        public DataTable Reporte_Tiempos(string filtro, string filtro2)
        {
            string sql = " select P.iidPedido id, DATEDIFF(HOUR,CONVERT(VARCHAR(10),P.dfechaIn,103),CONVERT(VARCHAR(10),P.dfechaUp,103)) tiempo, P.fTotal total, P.iNumPersonas cantPersonas, M.vchDescripcion mesa, A.vchNombre area, P.fDescuento descuento, P.fSubtotal subtotal " +
                         " from catPedidos P" +
                         " INNER JOIN catMesas M ON P.iidMesa = M.iidMesa" +
                         " INNER JOIN catAreas A ON A.iidArea = M.iidArea" +
                         " where P.SiPagado = 1" + filtro + filtro2;

            return Conexion.Consultasql(sql);
        }

        /*------------------------------------------- Reporte de Eventos -------------------------------------------------------*/

        public DataTable getEventosAll()
        {
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre  " +
                         " UNION ALL " +
                         " SELECT iidEvento as id, vchNombre as nombre FROM catEventos WHERE iidEstatus = 1";

            return Conexion.Consultasql(sql);
        }

        public DataTable Reporte_Eventos(string filtro, string filtro2)
        {
            string sql = " select distinct E.iidEvento ID, E.vchNombre Evento, E.vchDescripcion Descripcion, SUM(PC.iNumHombres) Cantidad_Hombres, SUM(PC.iNumMujeres) Cantidad_Mujeres, SUM(PC.fMontoPago) Ganancias " +
                            " from catEventos E " +
                            " LEFT JOIN catPagosCover PC ON PC.iidEvento = E.iidEvento " +
                            " where E.iidEstatus = 1 " + filtro +
                            " GROUP BY E.iidEvento, E.vchNombre, E.vchDescripcion " + filtro2;

            return Conexion.Consultasql(sql);
        }

        /*------------------------------------------- Reporte de Requisicion -------------------------------------------------------*/

        public DataTable getPersonalAll()
        {
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre  " +
                         " UNION ALL " +
                         " SELECT iidPersonal as id, vchNombres + ' ' + vchApellidoPat as nombre FROM CatPersonal WHERE iidEstatus = 1";

            return Conexion.Consultasql(sql);
        }

        public DataTable getCategoriaMPAll()
        {

            string sql = " SELECT 0 as id, 'Seleccionar' as nombre  " +
                         " UNION ALL " +
                         " SELECT iidCategoriaMateriPrima as id, vchDescripcion as nombre FROM catCategoriasMateriaPrima WHERE iidEstatus = 1";

            return Conexion.Consultasql(sql);
        }

        public DataTable Reporte_Requisicion(string filtro, string filtro2)
        {
            string sql = " select CONVERT(VARCHAR(10),R.dfechaIn,103) Fecha, P.vchNombres + ' ' + P.vchApellidoPat + ' ' + P.vchApellidoMat Personal, R.fCostoTotal Costo, R.vchComentario Comentario, M.vchDescripcion Materia_Prima, CM.vchDescripcion Categoria, D.iCantidad Cantidad " +
                         " from catRequisicion R " +
                         " LEFT JOIN CatPersonal P ON P.iidPersonal = R.iidPersonal " +
                         " INNER JOIN catDetalleRequisicion D ON R.iidReq = D.iidReq " +
                         " LEFT JOIN catMateriaPrima M ON D.iidMateriPrima = M.iidMateriPrima " +
                         " LEFT JOIN catCategoriasMateriaPrima CM ON CM.iidCategoriaMateriPrima = M.iidCategoriaMateriPrima " +
                         " where R.iidReq = D.iidReq " + filtro + filtro2 +
                         " and R.SiTerminado = 1";

            return Conexion.Consultasql(sql);
        }

        /*------------------------------------------- Reporte de Costeo -------------------------------------------------------*/

        public DataTable getTipoProductoAll()
        {
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre  " +
                         " UNION ALL " +
                         " SELECT iidUnidad as id, vchNombre as nombre FROM catUnidadesProductos WHERE iidEstatus = 1";

            return Conexion.Consultasql(sql);
        }

        public DataTable Reporte_Costeo(string filtro, string filtro2)
        {
            string sql = " select C.vchNombre Categoria, P.vchCodigo Codigo, P.vchDescripcion Producto, U.vchNombre Tipo, P.fCosto Costo, P.fPrecio Precio_Venta, (P.fPrecio-P.fCosto) Ganancias " + 
                         " from catProductos P " +
                         " LEFT JOIN catCategorias C ON C.iidCategoria = P.iidCategoria " +
                         " INNER JOIN catUnidadesProductos U ON U.iidUnidad = P.iidUnidad " +
                         " where P.iidEstatus = 1" + filtro + filtro2;

            return Conexion.Consultasql(sql);
        }
        public DataTable Reporte_Productos(string filtro)
        {
            string sql = " " + 
            " SELECT C.vchNombre Categoria, P.vchCodigo, " +
                " P.vchDescripcion, U.vchNombre vchUnidad, " + 
	            " P.fPrecio " + 
            " FROM catProductos P, catCategorias C, catUnidadesProductos U  " + 
            " WHERE P.iidCategoria = C.iidCategoria  " + 
            " AND U.iidUnidad=P.iidUnidad  " +
            " AND P.iidEstatus = 1 " + filtro +
            " ";
            return Conexion.Consultasql(sql);
        }
         public DataTable Reporte_Proveedores()
        {

            string sql = " select P.iidProveedor id, P.vchRazonSocial razon, P.vhcRFC rfc, P.vchCorreo correo, P.vchPagina pagina "+
                         " from catProveedores P where P.iidEstatus=1 order by id desc";

            return Conexion.Consultasql(sql);
        }
         public DataTable Reporte_Existencias(string filtro)
         {
             string sql = " SELECT  E.iidMateriPrima  id, P.vchDescripcion, P.vchCodigo, A.vchNombre, " +
                          " A.vchNombre,  E.fCantidad [cantidad sin Convertir], U.vchNombre [unidad Real], U.iidUnidad, " +
                          " CASE " +
                          " WHEN U.iidUnidad = 1 AND E.fCantidad > 1000 THEN E.fCantidad " +
                          " WHEN U.iidUnidad = 2 THEN E.fCantidad " +
                          " WHEN U.iidUnidad = 3 AND E.fCantidad > 1000 THEN E.fCantidad / 1000 " +
                          " WHEN U.iidUnidad = 4 THEN E.fCantidad " +
                          " WHEN U.iidUnidad = 5 AND E.fCantidad > 1000 THEN E.fCantidad " +
                          " ELSE E.fCantidad / 1000 END AS Cantidad, E.fContenidoXPieza," +
                          " CASE " +
                          " WHEN U.iidUnidad = 1 AND E.fCantidad >= 1000 THEN 'Botellas' " +
                          " WHEN U.iidUnidad = 1 AND E.fCantidad < 1000 THEN 'Mililitros' " +
                          " WHEN U.iidUnidad = 2 THEN 'Botellas' " +
                          " WHEN U.iidUnidad = 3 AND E.fCantidad >= 1000 THEN 'Kilos' " +
                          " WHEN U.iidUnidad = 3 AND E.fCantidad < 1000 THEN U.vchNombre " +
                          " WHEN U.iidUnidad = 4 THEN U.vchNombre " +
                          " WHEN U.iidUnidad = 5 AND E.fCantidad >= 1000 THEN 'Botellas' " +
                          " WHEN U.iidUnidad = 5 AND E.fCantidad < 1000 THEN U.vchNombre " +
                          " WHEN U.iidUnidad = 6 AND E.fCantidad >= 1000 THEN U.vchNombre " +
                          " WHEN U.iidUnidad = 6 AND E.fCantidad < 1000 THEN 'Gramos' " +
                          " END AS Unidad " +
                          " FROM catExistenciasMateriaPrima E " +
                          " INNER JOIN catMateriaPrima P ON E.iidMateriPrima = P.iidMateriPrima " +
                          " INNER JOIN catAlmacenes A ON E.iidAlmacen = A.iidAlmacen " +
                          " INNER JOIN catUnidadesMetricas U ON E.iidUnidadMetrica = U.iidUnidad " + filtro +
                          " UNION ALL " +
                          " SELECT  P.iidProducto  id, P.vchDescripcion, P.vchCodigo, A.vchNombre, " +
                          " A.vchNombre,  E.fCantidad [cantidad sin Convertir], U.vchNombre [unidad Real], U.iidUnidad, " +
                          " CASE " +
                          " WHEN U.iidUnidad = 1 AND E.fCantidad > 1000 THEN E.fCantidad / 1000 " +
                          " WHEN U.iidUnidad = 2 THEN E.fCantidad / 29.574 " +
                          " WHEN U.iidUnidad = 3 AND E.fCantidad > 1000 THEN E.fCantidad / 1000 " +
                          " WHEN U.iidUnidad = 4 THEN E.fCantidad / 1 " +
                          " WHEN U.iidUnidad = 5 AND E.fCantidad > 1000 THEN E.fCantidad / 1000 " +
                          " ELSE E.fCantidad / 1000 END AS Cantidad, 0 AS fContenidoXPieza," +
                          " CASE " +
                          " WHEN U.iidUnidad = 1 AND E.fCantidad >= 1000 THEN U.vchNombre " +
                          " WHEN U.iidUnidad = 1 AND E.fCantidad < 1000 THEN 'Mililitros' " +
                          " WHEN U.iidUnidad = 2 THEN 'Onzas' " +
                          " WHEN U.iidUnidad = 3 AND E.fCantidad >= 1000 THEN 'Kilos' " +
                          " WHEN U.iidUnidad = 3 AND E.fCantidad < 1000 THEN U.vchNombre " +
                          " WHEN U.iidUnidad = 4 THEN U.vchNombre " +
                          " WHEN U.iidUnidad = 5 AND E.fCantidad >= 1000 THEN 'Litros' " +
                          " WHEN U.iidUnidad = 5 AND E.fCantidad < 1000 THEN U.vchNombre " +
                          " WHEN U.iidUnidad = 6 AND E.fCantidad >= 1000 THEN U.vchNombre " +
                          " WHEN U.iidUnidad = 6 AND E.fCantidad < 1000 THEN 'Gramos' " +
                          " END AS Unidad " +
                          " FROM catExistencias E " +
                          " INNER JOIN catProductos P ON E.iidProducto = P.iidProducto " +
                          " INNER JOIN catAlmacenes A ON E.iidAlmacen = A.iidAlmacen " +
                          " INNER JOIN catUnidadesMetricas U ON E.iidUnidadMetrica = U.iidUnidad " + filtro;

             return Conexion.Consultasql(sql);
         }
         public DataTable Reporte_Facturas(string filtro)
         {
             string sql = " SELECT CONVERT(VARCHAR(10), M.dfechaTimbrado,103) AS timbrado, " +
                          " T.vchNombre CDFI, MP.vchNombre metodo, M.iFolio, M.vchSerie, " +
                          " CASE WHEN M.SiCancelado = 1 THEN 'Cancelada' ELSE 'Vigente' END AS cancelado, " +
                          " CASE WHEN M.iidBanco = 0 THEN 'Sin banco registrado' ELSE B.vchNombreCorto END AS banco, " +
                          " D.vchNombre divisa, C.vchRazon cliente, M.fsubtotal, M.fdescuento, " +
                          " M.fiva, M.ftotal, M.vchComentario " +
                          " FROM MovFacturas M " +
                          " LEFT JOIN CatTiposCfdi T ON M.iidTipoCfdi = T.iidTipoCfdi " +
                          " INNER JOIN catMetodosPago MP ON M.iidMetodopago = MP.iidMetodopago " +
                          " LEFT JOIN catDivisas D ON M.iidDivisa = D.iidDivisa " +
                          " LEFT JOIN CatBancos B ON M.iidBanco = B.iidBanco " +
                          " LEFT JOIN catFormasPago F ON M.iidFormaPago = F.iidFormaPago " +
                          " INNER JOIN catClientes C ON M.iidCliente = C.iidCliente " +
                          " WHERE M.SiCompletado = 1 " + filtro;

             return Conexion.Consultasql(sql);
         }

         

         public DataTable Reporte_Productividad(string filtro, string filtro2)
         {
             string sql = "select M.vchNombres + ' ' + M.vchApellidoPat + ' ' + M.vchApellidoMat Nombre , COUNT(P.iidMesa) Cantidad_Mesas, SUM(P.iNumPersonas) Cantidad_Personas, SUM(P.fTotal) Total_Ganancias, SUM(P.fPropina) Cantidad_Propinas " +
                          " from catPedidos P, CatPersonal M " +
                          " where SiPagado = 1 " +
                          " and P.iidPersonal = M.iidPersonal " + filtro + filtro2 +
                          " group by M.vchNombres + ' ' + M.vchApellidoPat + ' ' + M.vchApellidoMat";

             return Conexion.Consultasql(sql);
         }
         public DataTable Reporte_Cupones(string filtro)
         {

             string sql = " select C.iidCupon id, CONVERT(VARCHAR(10),C.dfechain,103) fecha_Insercción, CONVERT(VARCHAR(10),C.dfechaVence,103) fecha_Vencimiento, C.vchCodigo Código, C.fdescuento descuento, case C.SiUtilizado when '0' then 'NO' when '1' then 'SI' end Utilizado, P.fDescuento cantDesc " +
                          " from catCuponDescuento C" +
                          " LEFT JOIN catPedidos P ON P.iidCupon = C.iidCupon " +
                          " where P.SiPagado=1 and C.SiUtilizado != 0 or CONVERT(VARCHAR(10),C.dfechaVence,103) < GETDATE()" + filtro;
             return Conexion.Consultasql(sql);
         }
         public DataTable Reporte_Cortes(string filtro)
         {

           //string sql = " select iidCorte ID, fVentaTotal VentaTotal, fMontoEfectivo MontoEfectivo, fMontoTC MontoTC, fMontoOtros MontoOtros, cast(round(fGanancia,2) as numeric(10,2)) Ganancias, cast(round(fDescuentoTotal,2) as numeric(10,2)) TotalDescuento, cast(round(fPropinas,2) as numeric(10,2)) Propinas " +
           //               " from catCortes C" +
           //               " where iidEstatus = 1 " + filtro;

             string sql = "select fMontoInicial inicial, iidCorte ID, fVentaTotal VentaTotal, fVentaEfectivo MontoEfectivo, fVentaCreditoTC MontoTC, ( fVentaDebito + fVentaVales + fVentaCheque)  MontoOtros, cast(round(fTotalFinal,2) as numeric(10,2)) Ganancias, cast(round(fTotalDescuentos,2) " +
                            "as numeric(10,2)) TotalDescuento, cast(round( fPropinaTotal ,2) as numeric(10,2)) Propinas, fMontoInicial inicial " +
                            "from catCortes C where  "+filtro;
             return Conexion.Consultasql(sql);
         }

    }
}
