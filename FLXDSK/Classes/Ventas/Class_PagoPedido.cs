using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Ventas
{
    class Class_PagoPedido
    {
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();

        public bool InsertaInformacionbyValor(string iidPedido, string iidFormaPago, double fmonto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string sql = " INSERT INTO CatPagosVentas " +
                         " (iidPedido, iidFormaPago, dfechaPago, fmonto, vchComentario,dfechaIn,iidUsuario,iidEstatus,vchTipoTarjeta) " +
                         " VALUES " +
                         " (@iidPedido, @iidFormaPago, GETDATE(), @fmonto, '', GETDATE(), " + usuariolog + ", 1, '')";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidPedido", SqlDbType.Int).Value = iidPedido;
            cmd.Parameters.Add("@iidFormaPago", SqlDbType.Int).Value = iidFormaPago;
            cmd.Parameters.Add("@fmonto", SqlDbType.Float).Value = fmonto;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }

        }
        public bool InsertaInformacion(DataTable Info)
        {
            DataRow row = Info.Rows[0];
            string venta = row["venta"].ToString();
            string iidFormaPago = row["iidFormaPago"].ToString();
            string monto = row["monto"].ToString();
            string comentario = row["comentario"].ToString();
            string tarjeta = row["tarjeta"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string sql = " INSERT INTO CatPagosVentas " +
                         " ([iidPedido], iidFormaPago,[dfechaPago],[fmonto],[vchComentario],[dfechaIn],[iidUsuario],[iidEstatus],[vchTipoTarjeta]) " +
                         " VALUES " +
                         " (@venta, @iidFormaPago, GETDATE(), @monto, @comentario, GETDATE(), " + usuariolog + ", 1, '" + tarjeta + "')";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@venta", SqlDbType.Int).Value = venta;
            cmd.Parameters.Add("@iidFormaPago", SqlDbType.Int).Value = iidFormaPago;
            cmd.Parameters.Add("@monto", SqlDbType.Float).Value = monto;
            cmd.Parameters.Add("@comentario", SqlDbType.VarChar).Value = comentario;
            cmd.Parameters.Add("@tarjeta", SqlDbType.VarChar).Value = tarjeta;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return false;
            }

        }


        public bool updatePagado(string idVenta, string pagado)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string sql = " update catPedidos set siPagado = @pagado, dfechaUp = GETDATE() WHERE iidPedido = @venta";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@venta", SqlDbType.Int).Value = idVenta;
            cmd.Parameters.Add("@pagado", SqlDbType.SmallInt).Value = pagado;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                return false;
            }

        }
        public bool deletePago(string idPago)
        {
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string sql = " UPDATE CatPagosVentas SET iidEstatus=2, dfechaUp=GETDATE() , iidUsuario=" + usuariolog + "  WHERE iidPago=" + idPago;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /*public bool isCorrectoNumPedido(string numPedido)
        {
            string sql = "SELECT SiPagado FROM catCuenta (NOLOCK) where iidDetallePedido = " + numPedido + " AND SiPagado = 0 ";
            int numero = conx.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else
                return false;
        }*/

        /*public string getNombreAreaMesa(string idPedido)
        {
            string sql = " select A.vchNombre + ' - ' + M.vchDescripcion Nombre from catPedidos P, catMesas M, catAreas A " +
                         " where P.iidPedido = " + idPedido + " and P.iidMesa = M.iidMesa and M.iidArea = A.iidArea";
            DataTable dt = new DataTable();
            dt = conx.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["Nombre"].ToString();
            }
            catch
            {
                return "";
            }
        }*/

        public bool PedidotieneDescuento(string numPedido)
        {
            string sql = "SELECT iidPedido FROM catPedidos (NOLOCK) WHERE iidPedido = " + numPedido + " AND fDescuento > 0 ";
            int numero = conx.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else 
                return false;
        }

        public bool descuentaDeExistencia(string idMateriaPrima, string fCantidad, string idAlmacen)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();
            string sql = "update catExistenciasMateriaPrima set fCantidad = fCantidad - " + fCantidad + ", dfechaUp = getdate() where iidMateriPrima = " + idMateriaPrima + " and iidAlmacen = " + idAlmacen;
            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            { return false; }
        }


        public bool updateTotal(string idPedido, string fPropina, string total)
        {
            if (fPropina == "") { fPropina = "0"; }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();
            string sql = "update catPedidos set fPropina = " + fPropina + ", fTotal = " + total + " where iidPedido = " + idPedido;
            cmd.CommandText = sql;
            
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            { return false; }
        }

        public string getPropinaPedido(string idPedido)
        {
            string sql = " select fPropina from catPedidos where iidPedido = " + idPedido;
            DataTable dt = new DataTable();
            dt = conx.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["fPropina"].ToString();
            }
            catch
            {
                return "";
            }
        }

        public DataTable getIdProductos(string idPedido)
        {
            string sql = "select iidProducto, fCantidad from catDetallePedido P where iidPedido = " + idPedido;
            return conx.Consultasql(sql);
        }

        public DataTable idMateriaPrimaCantidad(string idProducto)
        {
            string sql = "select iidMateriPrima, fCantidad, iidAlmacen from RelProductoMateriaprima where iidProducto = " + idProducto;
            return conx.Consultasql(sql);
        }

        public DataTable getInfobyCuenta(string idPedido)
        {
            string sql = " select distinct A.vchNombre area, M.vchDescripcion mesa, C.fSubtotal, C.fDescuento, C.fTotal, " +
                         " Convert(varchar(13),GETDATE(),103) fecha, Convert(varchar(13),GETDATE(),108) hora, ps.iidPersonal, " +
                         " ps.vchNombres + ' ' + ps.vchApellidoPat + ' ' + ps.vchApellidoMat as Nombre, C.iidMetodopago, C.fPropina Propina  " +
                         " from catDetallePedido P, catMesas M, catAreas A, catPedidos C, CatPersonal ps  "+
                         " where P.iidPedido = " + idPedido +
                         " and C.iidMesa = M.iidMesa  "+
                         " and P.iidPedido = C.iidPedido"+
                         " and C.iidPersonal = ps.iidPersonal  " +
                         " and M.iidArea = A.iidArea";
            return conx.Consultasql(sql);
        }

        public DataTable getInfobyCuentaDescuento(string idPedido)
        {
            string sql = " select distinct A.vchNombre area, M.vchDescripcion mesa, C.fSubtotal, C.fTotal, " +
                         " Convert(varchar(13),GETDATE(),100) fecha, Convert(varchar(13),GETDATE(),108) hora, ps.iidPersonal,  " +
                         " ps.vchNombres + ' ' + ps.vchApellidoPat + ' ' + ps.vchApellidoMat as Nombre, " +
                         " C.fDescuento descuento, C.iidMetodopago, C.fPropina Propina    " +
                         " from catDetallePedido P, catMesas M, catAreas A, catPedidos C, CatPersonal ps    " +
                         " where C.iidPedido = " + idPedido +
                         " and C.iidMesa = M.iidMesa  " +
                         " and P.iidPedido = C.iidPedido  " +
                         " and C.iidPersonal = ps.iidPersonal  " +
                         " and M.iidArea = A.iidArea  " +
                         " and C.fDescuento != 0";
            return conx.Consultasql(sql);
        }

        public bool insertPagoPedido(DataTable info, string numPedido)
        {
            DataRow row = info.Rows[0];
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string sql = " update catPedidos set siPagado = 1, iidEstatus = 1, iidMetodopago = @Pagado, dfechaUp = getdate() where iidPedido = " + numPedido;
            

            cmd.CommandText = sql;
            cmd.Parameters.Add("@Pagado", SqlDbType.Int).Value = row["Pagado"].ToString();
            
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool seComponedeMateriaPrima(string idProducto)
        {
            string sql = "select iidProducto from RelProductoMateriaprima where iidProducto = " + idProducto + " and iidUnidadMetrica != 7";
            int numero = conx.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else
                return false;
        }

        public bool descuentaExistenciaProducto(string idProducto, string fCantidad, string idAlmacen)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();
            string sql = "update catExistencias set fCantidad = fCantidad - " + fCantidad + ", dfechaUp = getdate() where iidProducto = " + idProducto + " and iidAlmacen = " + idAlmacen;
            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            { return false; }
        }

        public bool descuentaExistenciaProducto2(string idProducto, string fCantidad)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();
            string sql = "update catExistencias set fCantidad = fCantidad - " + fCantidad + ", dfechaUp = getdate() where iidProducto = " + idProducto;
            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            { return false; }
        }

        public DataTable getInfoMensajes()
        {
            string sql = " select vchConfiguracion from CatParametrosConfig where vchTipo in( 'Ticket Msg L1','Ticket Msg L2','Ticket Msg L3')";
            return conx.Consultasql(sql);
        }

        public DataTable getInfoPedido(string idpedido)
        {
            string sql = "SELECT P.iidPedido, convert(varchar(10),P.dfechaIn,103)fecha, convert(varchar(5),P.dfechaIn,108)hora, P.iidMesa, P.iidEstatus, iNumPersonas, " +
                        "     P.fSubtotal, P.fDescuento, P.fPropina, P.fTotal,  " +
                           "     P.siPagado, P.iidMetodoPago, P.siFacturado, P.siSeparado, " +
                           "     P.iidCupon, P.vchObservacion, " +
                           "     P.iidPersonal, " +
                           "     E.vchNombres, E.vchApellidoPat, E.vchApellidoMat, " +
                           "     M.vchDescripcion mesa, A.vchNombre area " +
                        " FROM catPedidos (NOLOCK) P, catPersonal E (NOLOCK), catMesas M(NOLOCK), catAreas A(NOLOCK) " +
                        " WHERE P.iidPersonal = E.iidPersonal " +
                        " AND M.iidMesa = P.iidMesa " +
                        " AND A.iidArea = M.iidArea " +
                        " AND iidPedido = " + idpedido;
            return conx.Consultasql(sql);
        }

        public DataTable getListaDetallePedido(string idpedido)
        {
            string sql = "select iidDetallePedido, P.vchCodigo, P.vchDescripcion, " +
                        "     D.fCantidad, D.fPrecio, D.fImporte " +
                        " FROM catDetallePedido D (NOLOCK), catProductos P (NOLOCK) " +
                        " WHERE iidPedido =  " + idpedido +
                        " AND P.iidProducto = D.iidProducto " +
                        " order by iidDetallePedido desc ";
            return conx.Consultasql(sql);
        }

        public DataTable getMontoAgrupado(string sicomida, string pedido)
        {
            if (sicomida == "") sicomida = "0";
            string sql = "SELECT SUM(fimporte)total, SUM(fCantidad)cantidad " +
                            " FROM catDetallePedido D (NOLOCK), catProductos (NOLOCK) P " +
                            " WHERE D.iidPedido =  " + pedido +
                            " AND P.iidProducto = D.iidProducto " +
                            " AND P.siComida =  " + sicomida;
            return conx.Consultasql(sql);
        }
    }
}
