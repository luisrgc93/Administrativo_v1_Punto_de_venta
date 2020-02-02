using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Facturas
{
    class Class_TmpFac
    {

        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = " SELECT iidProducto, Codigo, Unidad, Producto, Precio, Cantidad, Importe, vchClave, vchCodigoSat, Iva, Base " +
            " FROM tmpCarritoFactura (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public bool Truncate()
        {
            string sql = " TRUNCATE TABLE tmpCarritoFactura  ";
            return Conexion.InsertaSql(sql);
        }
        public bool InsertaInformacion(string idProducto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            
            string sql = "INSERT INTO tmpCarritoFactura (iidProducto, siIVa, Codigo, Unidad, Producto, Cantidad,Precio,Importe, Iva, Base, vchCodigoSat, vchClave) " +
            " SELECT P.iidProducto, P.siIva, P.vchCodigo, P.vchUnidad, P.vchDescripcion,  " +
	            " 1 cantidad,    " +
	            " CASE P.siIVA WHEN 0 THEN P.fPrecio ELSE ROUND((P.fPrecio/1.16),6) END Precio, " +
	            " CASE P.siIVA WHEN 0 THEN P.fPrecio ELSE ROUND((P.fPrecio/1.16),6) END Importe, " +
	            " CASE P.siIVA WHEN 0 THEN 0 ELSE ROUND(ROUND((P.fPrecio/1.16),6)*0.16, 6 ) END Iva, " +
	            " CASE P.siIVA WHEN 0 THEN 0 ELSE ROUND((P.fPrecio/1.16),6) END Base, " +
	            " P.vchCodigoSat, U.vchClave " +
            " FROM CatProductos P (NOLOCK), int_satUnidadMedida U (NOLOCK) " +
            " WHERE P.iidUnidadMedida = U.iidUnidadMedida " +
            " AND P.iidProducto =  " + idProducto;
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
        public bool ActualizaCantidad(string idProducto, double Cantidad)
        {
            string sql = "UPDATE tmpCarritoFactura SET  Cantidad = " + Cantidad + ", " +
                " Importe = ROUND( (Precio * " + Cantidad + ") ,6), " +
                " Iva = (CASE siIVA WHEN 0 THEN 0 ELSE ROUND(ROUND(( Precio * " + Cantidad + "),6)*0.16, 6 ) END ), " +
                " Base = (CASE siIVA WHEN 0 THEN 0 ELSE ROUND((Precio * " + Cantidad + "),6) END ) " +
            " WHERE iidProducto = " + idProducto;
            return Conexion.InsertaSql(sql);
        }


    }
}
