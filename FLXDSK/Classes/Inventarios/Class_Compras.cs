using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Inventarios
{
    class Class_Compras
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();

        Class_DetalleCompra ClsDetCompra = new Class_DetalleCompra();
        Classes.Inventarios.Class_ExistenciaMP ClsExistencia = new Class_ExistenciaMP();
        Classes.Catalogos.Mercancia.Class_Materia_Prima ClsMatPrima = new Classes.Catalogos.Mercancia.Class_Materia_Prima();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = " SELECT iidProveedor ,iidFormaPago ,iidTipoCfdi, iidAlmacen, " +
            " CONVERT(varchar(10),dfechaCompra,103)dfechaCompra103, " + 
            " iidEmpresa ,iidUsuarion ,fiva ,fsubTotal ,fTotal ,dfechaCompra ,siPagos,  " +
            " siPagado ,vchComentario ,iidEstatus ,dfechaIn ,dfechaUp, siTerminada, iFolio, vchSerie " +
            " FROM catCompras  (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public DataTable getLista(string filtro)
        {
            string sql = " " +
            " SELECT C.iidCompra , C.iidProveedor , C.iidFormaPago , C.iidTipoCfdi, C.iidAlmacen, " +
	             " CONVERT(varchar(10),C.dfechaCompra,103)dfechaCompra103, " +
	             " C.iidEmpresa , C.iidUsuarion , C.fiva , C.fsubTotal , C.fTotal , C.dfechaCompra ,C.siPagos, " +
	             " C.siPagado , C.vchComentario , C.iidEstatus , C.dfechaIn ,  C.siTerminada, C.iFolio, C.vchSerie, " +
	             " P.vhcRFC, P.vchRazonSocial, P.vchNombreComercial, " +
	             " P.vchDomicilio, P.vchNumExt, P.vchNumInt, P.vchColonia, P.vchMunicipio, P.vchTelefono, P.vchCorreo,  " +
	             " F.vchDescripcion FormaPago, " +
	             " T.vchDescripcion TipoCDFI, " +
                 " U.vchUsuario, A.vchNombre Almacen " +
            " FROM catCompras  (NOLOCK) C, catProveedores P (NOLOCK), int_satFormaPago F (NOLOCK), int_satTipoComprobante T (NOLOCK), catUsuarios U (NOLOCK), catAlmacenes A (NOLOCK) " +
            " WHERE C.iidProveedor = P.iidProveedor " +
            " AND C.iidFormaPago = F.iidFormaPago " +
            " AND C.iidTipoCfdi = T.iidTipoComprobante "  + 
            " AND C.iidUsuarion = U.iidUsuario "+
            " AND C.iidAlmacen = A.iidAlmacen " + filtro;
            return Conexion.Consultasql(sql);
        }

        public bool InsertaInformacion(DataTable info)
        {
            DataRow Row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catCompras " +
            " (iidProveedor, iidAlmacen, iidFormaPago ,iidTipoCfdi, iidEmpresa ,iidUsuarion ,fIVA ,fSubTotal ,fTotal ,dfechaCompra , " +
            " siPagado ,vchComentario ,iidEstatus ,dfechaIn ,dfechaUp, siTerminada, iFolio, vchSerie, siPagos  ) " +
            " VALUES( " +
            " @iidProveedor, @iidAlmacen, @iidFormaPago, @iidTipoCfdi, @iidEmpresa, @iidUsuarion, 0, @fSubTotal, @fTotal, @dfechaCompra, " +
            " @siPagado, @vchComentario, 1, GETDATE(),GETDATE(), 0 , @iFolio, @vchSerie, 0) ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidProveedor", SqlDbType.Int);
            cmd.Parameters.Add("@iidAlmacen", SqlDbType.Int);
            cmd.Parameters.Add("@iidFormaPago", SqlDbType.Int);
            cmd.Parameters.Add("@iidTipoCfdi", SqlDbType.Int);
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int);
            cmd.Parameters.Add("@iidUsuarion", SqlDbType.Int);
            cmd.Parameters.Add("@fSubTotal", SqlDbType.Float);
            cmd.Parameters.Add("@fTotal", SqlDbType.Float);
            cmd.Parameters.Add("@dfechaCompra", SqlDbType.DateTime);
            cmd.Parameters.Add("@siPagado", SqlDbType.SmallInt);
            cmd.Parameters.Add("@vchComentario", SqlDbType.Text);
            cmd.Parameters.Add("@iFolio", SqlDbType.Int);
            cmd.Parameters.Add("@vchSerie", SqlDbType.Text);

            ///
            cmd.Parameters["@iidProveedor"].Value = Row["iidProveedor"].ToString();
            cmd.Parameters["@iidAlmacen"].Value = Row["iidAlmacen"].ToString();
            cmd.Parameters["@iidFormaPago"].Value = Row["iidFormaPago"].ToString();
            cmd.Parameters["@iidTipoCfdi"].Value = Row["iidTipoCfdi"].ToString();
            cmd.Parameters["@iidEmpresa"].Value = Classes.Class_Session.IDEMPRESA;
            cmd.Parameters["@iidUsuarion"].Value = Classes.Class_Session.Idusuario;

            cmd.Parameters["@fSubTotal"].Value = Row["fSubTotal"].ToString();
            cmd.Parameters["@fTotal"].Value = Row["fTotal"].ToString();
            cmd.Parameters["@dfechaCompra"].Value = Row["dfechaCompra"].ToString();
            cmd.Parameters["@siPagado"].Value = Row["siPagado"].ToString();
            cmd.Parameters["@vchComentario"].Value = Row["vchComentario"].ToString();
            cmd.Parameters["@iFolio"].Value = Row["iFolio"].ToString();
            cmd.Parameters["@vchSerie"].Value = Row["vchSerie"].ToString();


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
        public bool ActualizaInformacion(DataTable info, string Id)
        {
            DataRow Row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catCompras SET iidProveedor = @iidProveedor, iidFormaPago = @iidFormaPago, iidTipoCfdi = @iidTipoCfdi, " +
            " iidUsuarion = @iidUsuarion, fSubTotal = @fSubTotal, fTotal = @fTotal, dfechaCompra = @dfechaCompra, siPagado = @siPagado, " +
            " vchComentario = @vchComentario, dfechaUp = GETDATE(), iFolio =@iFolio,  vchSerie =@vchSerie   " +
            " WHERE iidCompra = " + Id;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidProveedor", SqlDbType.Int);
            cmd.Parameters.Add("@iidFormaPago", SqlDbType.Int);
            cmd.Parameters.Add("@iidTipoCfdi", SqlDbType.Int);
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int);
            cmd.Parameters.Add("@iidUsuarion", SqlDbType.Int);
            cmd.Parameters.Add("@fSubTotal", SqlDbType.Float);
            cmd.Parameters.Add("@fTotal", SqlDbType.Float);
            cmd.Parameters.Add("@dfechaCompra", SqlDbType.DateTime);
            cmd.Parameters.Add("@siPagado", SqlDbType.Int);
            cmd.Parameters.Add("@vchComentario", SqlDbType.Text);
            cmd.Parameters.Add("@iFolio", SqlDbType.Int);
            cmd.Parameters.Add("@vchSerie", SqlDbType.Text);

            ///
            cmd.Parameters["@iidProveedor"].Value = Row["iidProveedor"].ToString();
            cmd.Parameters["@iidFormaPago"].Value = Row["iidFormaPago"].ToString();
            cmd.Parameters["@iidTipoCfdi"].Value = Row["iidTipoCfdi"].ToString();
            cmd.Parameters["@iidEmpresa"].Value = Classes.Class_Session.IDEMPRESA;
            cmd.Parameters["@iidUsuarion"].Value = Classes.Class_Session.Idusuario;

            cmd.Parameters["@fSubTotal"].Value = Row["fSubTotal"].ToString();
            cmd.Parameters["@fTotal"].Value = Row["fTotal"].ToString();
            cmd.Parameters["@dfechaCompra"].Value = Row["dfechaCompra"].ToString();
            cmd.Parameters["@siPagado"].Value = Row["siPagado"].ToString();
            cmd.Parameters["@vchComentario"].Value = Row["vchComentario"].ToString();
            cmd.Parameters["@iFolio"].Value = Row["iFolio"].ToString();
            cmd.Parameters["@vchSerie"].Value = Row["vchSerie"].ToString();

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

        public bool EliminaRegistro(string idcompra)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE catCompras SET iidEstatus = 2, dfechaUp = GETDATE() WHERE  iidCompra = " + idcompra;
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


        public string getIdCrado()
        {
            string sql = "SELECT MAX(iidCompra)iidCompra  FROM catCompras (NOLOCK) ";
            DataTable dt = Conexion.Consultasql(sql);
            if(dt.Rows.Count > 0)
                return dt.Rows[0]["iidCompra"].ToString();

            return "0";
        }






        public bool ProcesaCompra(string iidCompra, string iidAlmacen)
        {
            string sql = " UPDATE catCompras SET siTerminada = 1, dfechaUp = GETDATE(), iidUsuarion = " + Class_Session.Idusuario.ToString() + " " +
              " WHERE iidCompra = " + iidCompra;
            if (!Conexion.InsertaSql(sql))
                return false;


            DataTable dtalle = ClsDetCompra.getLista(" AND D.iidCompra = " + iidCompra);
            foreach (DataRow Row in dtalle.Rows)
            {
                ///Metemos a Existencias
                if (!ClsExistencia.InsertaInformacion(Row["iidMateriPrima"].ToString(), iidAlmacen, Row["fCantidadMinima"].ToString(), Row["iidUnidad"].ToString(), Row["iEquivalencia"].ToString()))
                    ClsLog.InsertaInformacion("Com iidMateriPrima: " + Row["iidMateriPrima"].ToString() + " iidAlmacen: " + iidAlmacen + " fCantidad:" + Row["fCantidad"].ToString() + " iidUnidad:" + Row["iidUnidad"].ToString() + " iEquivalencia:" + Row["iEquivalencia"].ToString(), "Problema Al inventariar ajuste");
                

                //Procesamos el Precio
                ClsMatPrima.ActualizaPrecio(Row["iidMateriPrima"].ToString(), Row["fCosto"].ToString());
            }
            return true;
        }




        /*
        public bool inserta_detalle_compra(DataTable info)
        {
            DataRow Row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catDetalleCompra (iidCompra, iidProducto, iidAlmacen, iCantidad, fCosto, iTipoProducto, iidUnidad,dFechaIn, dFechaUp) " +
                         " VALUES(@idcompra,@idproducto,@idalmacen,@cantidad,@costo,@idmover,@unidad,GETDATE(), GETDATE()) ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idcompra", SqlDbType.Int);
            cmd.Parameters.Add("@idproducto", SqlDbType.Int);
            cmd.Parameters.Add("@idalmacen", SqlDbType.Int);
            cmd.Parameters.Add("@cantidad", SqlDbType.Float);
            cmd.Parameters.Add("@costo", SqlDbType.Float);
            cmd.Parameters.Add("@idmover", SqlDbType.Int);
            cmd.Parameters.Add("@unidad", SqlDbType.Int);

            cmd.Parameters["@idcompra"].Value = Row["idcompra"].ToString();
            cmd.Parameters["@idproducto"].Value = Row["idproducto"].ToString();
            cmd.Parameters["@idalmacen"].Value = Row["idalmacenes"].ToString();
            cmd.Parameters["@cantidad"].Value = Row["cantidad"].ToString();
            cmd.Parameters["@costo"].Value = Row["costo"].ToString();
            cmd.Parameters["@idmover"].Value = Row["idmover"].ToString();
            cmd.Parameters["@unidad"].Value = Row["unidad"].ToString();

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                DataTable Info_Excepcion = new DataTable();
                DataRow row_Excepcion;

                Info_Excepcion.Columns.Add("vchExcepcion", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchLugar", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchAccion", System.Type.GetType("System.String"));

                row_Excepcion = Info_Excepcion.NewRow();
                row_Excepcion["vchExcepcion"] = exp;
                row_Excepcion["vchLugar"] = "Class_Areas";
                row_Excepcion["vchAccion"] = "funcion (inserta_area)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public bool actualiza_detalle_compra(DataTable info)
        {
            DataRow Row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catDetalleCompra SET iidCompra = @idcompra, iidProducto = @idproducto, iidAlmacen = @idalmacen, iCantidad = @cantidad, fCosto = @costo, iTipoProducto = @idmover, iidUnidad = @unidad" +
                         " WHERE iidCompra = @idcompra AND iidProducto = @idproducto AND iTipoProducto = @idmover";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idcompra", SqlDbType.Int);
            cmd.Parameters.Add("@idproducto", SqlDbType.Int);
            cmd.Parameters.Add("@idalmacen", SqlDbType.Int);
            cmd.Parameters.Add("@cantidad", SqlDbType.Float);
            cmd.Parameters.Add("@costo", SqlDbType.Float);
            cmd.Parameters.Add("@idmover", SqlDbType.Int);
            cmd.Parameters.Add("@unidad", SqlDbType.Int);

            cmd.Parameters["@idcompra"].Value = Row["idcompra"].ToString();
            cmd.Parameters["@idproducto"].Value = Row["idproducto"].ToString();
            cmd.Parameters["@idalmacen"].Value = Row["idalmacenes"].ToString();
            cmd.Parameters["@cantidad"].Value = Row["cantidad"].ToString();
            cmd.Parameters["@costo"].Value = Row["costo"].ToString();
            cmd.Parameters["@idmover"].Value = Row["idmover"].ToString();
            cmd.Parameters["@unidad"].Value = Row["unidad"].ToString();

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public bool existe_detalle_compra(string idcompra, string idproducto, string mover)
        {
            string sql = " SELECT iidCompra FROM catDetalleCompra WHERE iidCompra = " + idcompra + " AND iidProducto = " + idproducto + " AND iTipoProducto = " + mover;

            int numero = Conexion.NumeroFilas(sql);

            if (numero == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        */

        public bool terminar_compra(string idcompra)
        {           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catCompras SET siTerminada = 1 WHERE iidCompra = " + idcompra;

            cmd.CommandText = sql;            

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                DataTable Info_Excepcion = new DataTable();
                DataRow row_Excepcion;

                Info_Excepcion.Columns.Add("vchExcepcion", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchLugar", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchAccion", System.Type.GetType("System.String"));

                row_Excepcion = Info_Excepcion.NewRow();
                row_Excepcion["vchExcepcion"] = exp;
                row_Excepcion["vchLugar"] = "Class_Areas";
                row_Excepcion["vchAccion"] = "funcion (inserta_area)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public bool SetCompraPagada(string idcompra)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE catCompras SET siPagado = 1, siTerminada = 1 WHERE iidCompra = " + idcompra;
            cmd.CommandText = sql;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                DataTable Info_Excepcion = new DataTable();
                DataRow row_Excepcion;

                Info_Excepcion.Columns.Add("vchExcepcion", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchLugar", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchAccion", System.Type.GetType("System.String"));

                row_Excepcion = Info_Excepcion.NewRow();
                row_Excepcion["vchExcepcion"] = exp;
                row_Excepcion["vchLugar"] = "Class_Areas";
                row_Excepcion["vchAccion"] = "funcion (inserta_area)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }


        
        
        
        
        /******************************Compras Temporal*********************************************/
        /*
        public bool borrar_detalle_compra_temporal(string idcompra)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " DELETE FROM catCompras_Temporal " +
                         " WHERE iidCompra = " + idcompra;

            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }
        
        public bool inserta_compra_temporal(DataTable info, string idcompra)
        {
            DataRow Row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catCompras_Temporal(iidCompra, iidProducto, iidUnidad, vchCodigo, vchDescripcion, " +
                         " vchUnidad, fCosto, fCantidad, fImporte, vchMover,iidMover,fContenido, dfechaIn, dFechaUp)  " +
                         " VALUES(" + idcompra + ",@idproducto,@idunidad, @codigo, @descripcion, " +
                         " @unidad,@costo,@cantidad,@importe,@mover,@idmover,@contenido,GETDATE(),GETDATE()) ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idproducto", SqlDbType.Int);
            cmd.Parameters.Add("@cantidad", SqlDbType.Float);
            cmd.Parameters.Add("@costo", SqlDbType.Float);
            cmd.Parameters.Add("@idunidad", SqlDbType.Int);
            cmd.Parameters.Add("@mover", SqlDbType.Text);
            cmd.Parameters.Add("@contenido", SqlDbType.Float);
            cmd.Parameters.Add("@importe", SqlDbType.Float);
            cmd.Parameters.Add("@codigo", SqlDbType.Text);
            cmd.Parameters.Add("@descripcion", SqlDbType.Text);
            cmd.Parameters.Add("@unidad", SqlDbType.Text);
            cmd.Parameters.Add("@idmover", SqlDbType.Int);

            cmd.Parameters["@idproducto"].Value = Row["idproducto"].ToString();
            cmd.Parameters["@cantidad"].Value = Row["cantidad"].ToString();
            cmd.Parameters["@costo"].Value = Row["costo"].ToString();
            cmd.Parameters["@idunidad"].Value = Row["idunidad"].ToString();
            cmd.Parameters["@mover"].Value = Row["mover"].ToString();
            cmd.Parameters["@contenido"].Value = Row["contenido"].ToString();
            cmd.Parameters["@importe"].Value = Row["importe"].ToString();
            cmd.Parameters["@codigo"].Value = Row["codigo"].ToString();
            cmd.Parameters["@descripcion"].Value = Row["descripcion"].ToString();
            cmd.Parameters["@unidad"].Value = Row["unidad"].ToString();
            cmd.Parameters["@idmover"].Value = Row["idmover"].ToString();

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }

        public DataTable obtener_compra_temporal(string idcompra)
        { 
            string sql = " SELECT iidCompra, iidProducto, iidUnidad, " +
                         " vchDescripcion, vchCodigo, vchUnidad, fCosto, " +
                         " fCantidad, fImporte, vchMover, " +
                         " iidMover,fContenido " +
                         " FROM catCompras_Temporal " +
                         " WHERE iidCompra = " + idcompra;

            return Conexion.Consultasql(sql);
        }

        public string registros_temporal(string idcompra)
        {
            string sql = " SELECT iidCompra FROM catCompras_temporal WHERE iidCompra = " + idcompra;
            try
            {
                int numero = Conexion.NumeroFilas(sql);
                return numero.ToString(); ;

            }
            catch (Exception Exp)
            {
                return "0";
            }
        }
        */

    }
}
