using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Catalogos.Mercancia
{
    class Class_Productos
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = "SELECT IFileImagen, " +
                " iidEmpresa, iidcategoria, vchcodigo, vchdescripcion, iidUnidad, fprecio, siIVA, vchUnidad, " +
                " iiddivisa,iidestatus, sienviado, dfechain, dfechaup, iidusuario, fCosto, iNumMesasPermitidas, siComida, fStockMinimo, iidAlmacen, " +
                " vchCodigoSat,  iidUnidadMedida, isCombo, " +
                " siPromo, siCostoCalculado, CONVERT(varchar(10),dfechaActivo,103) dfechaActivo103, CONVERT(varchar(10),dfechaVence,103)dfechaVence103 " + 
            " FROM catProductos (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }

        public DataTable isCombo(string idpedido)
        {
            string sql = "SELECT isCombo " +
            " FROM catProductos (NOLOCK) where iidProducto=" + idpedido;
            return Conexion.Consultasql(sql);
        }
        public DataTable getLista(string filtro)
        {
            string sql = "SELECT P.IFileImagen, " +
                " P.iidEmpresa, P.iidcategoria, P.vchcodigo, P.vchdescripcion, P.iidUnidad, P.fprecio, P.siIVA, P.vchUnidad, " +
                " P.iiddivisa, P.iidestatus, P.sienviado, P.dfechain, P.dfechaup, P.iidusuario, P.fCosto, P.iNumMesasPermitidas, P.siComida, P.fStockMinimo, P.iidAlmacen, " +
                " P.siPromo, CONVERT(varchar(10),P.dfechaActivo,103) dfechaActivo103, CONVERT(varchar(10),P.dfechaVence,103)dfechaVence103 " +
            " FROM catProductos (NOLOCK) P " +
            " WHERE " + filtro;
            return Conexion.Consultasql(sql);
        }

        public DataTable getListacombo(string filtro)
        {
            string sql = "SELECT iidCategoriaMateriPrima, vchDescripcion " +
          "  FROM catCategoriasMateriaPrima (NOLOCK) WHERE" +
            "  iidCategoriaMateriPrima=" + filtro;
            return Conexion.Consultasql(sql);
        }

        public DataTable getListaProductodef(string iidMateriaP)
        {
            string sql = "SELECT iidCategoriaMateriPrima, vchDescripcion, fcosto " +
          "  FROM catMateriaPrima (NOLOCK) WHERE" +
            "  iidMateriPrima=" + iidMateriaP;
           
            return Conexion.Consultasql(sql);
        }




        public bool EliminaRegistro(string idProducto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE catProductos SET iidEstatus = 2, dfechaUp = GETDATE() WHERE iidProducto = " + idProducto;
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
        public bool InsertaInformacion(DataTable info)
        {
            DataRow Row = info.Rows[0];
            Byte[] dibujoByteArray = null;
            try
            {
                dibujoByteArray = (byte[])(info.Rows[0]["IFileImagen"]);
            }
            catch{ };

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            

            string sql = "  INSERT INTO catProductos  " +
            " (iidEmpresa, siComida, fStockMinimo, vchRutaImg, vchUnidad, sienviado, iidEstatus, dfechaIn, dfechaUp,  " +
            " iidCategoria, iidAlmacen, vchCodigo, vchDescripcion, iidUnidad, fPrecio, fCosto, siIVA,  " +
            " iidDivisa, iidUsuario,  IFileImagen, vchCodigoSat,  iidUnidadMedida, siPromo ,siCostoCalculado, isCombo  ) " +
            " VALUES " +
            " (" + Classes.Class_Session.IDEMPRESA + ", @siComida, 0, '', '',  0,1,GETDATE(), GETDATE(), " +
            " @iidCategoria, @iidAlmacen, @vchCodigo, @vchDescripcion, @iidUnidad, @fPrecio, @fCosto, @siIVA, " +
            " @iidDivisa, @iidUsuario, @IFileImagen, @vchCodigoSat,  @iidUnidadMedida, @siPromo, @siCostoCalculado, @isCombo)";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidCategoria", SqlDbType.Int);
            cmd.Parameters.Add("@iidAlmacen", SqlDbType.Int);
            cmd.Parameters.Add("@vchCodigo", SqlDbType.Text);
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text);
            cmd.Parameters.Add("@iidUnidad", SqlDbType.Int);
            cmd.Parameters.Add("@fPrecio", SqlDbType.Float);
            cmd.Parameters.Add("@fCosto", SqlDbType.Float);
            cmd.Parameters.Add("@siIVA", SqlDbType.SmallInt);
            cmd.Parameters.Add("@siComida", SqlDbType.SmallInt);

            cmd.Parameters.Add("@iidDivisa", SqlDbType.Int);
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            //cmd.Parameters.Add("@iNumMesasPermitidas", SqlDbType.Int);
            cmd.Parameters.Add("@IFileImagen", SqlDbType.Image);
            cmd.Parameters.Add("@vchCodigoSat", SqlDbType.Text);
            cmd.Parameters.Add("@iidUnidadMedida", SqlDbType.Int);
            cmd.Parameters.Add("@siPromo", SqlDbType.SmallInt);
            //cmd.Parameters.Add("@dfechaActivo", SqlDbType.DateTime);
            //cmd.Parameters.Add("@dfechaVence", SqlDbType.DateTime);
            cmd.Parameters.Add("@siCostoCalculado", SqlDbType.SmallInt);
            cmd.Parameters.Add("@isCombo", SqlDbType.SmallInt);


            cmd.Parameters["@isCombo"].Value = Row["isCombo"].ToString();
            cmd.Parameters["@iidCategoria"].Value = Row["iidCategoria"].ToString();
            cmd.Parameters["@iidAlmacen"].Value = Row["iidAlmacen"].ToString();
            cmd.Parameters["@vchCodigo"].Value = Row["vchCodigo"].ToString();
            cmd.Parameters["@vchDescripcion"].Value = Row["vchDescripcion"].ToString();
            cmd.Parameters["@iidUnidad"].Value = Row["iidUnidad"].ToString();
            cmd.Parameters["@fPrecio"].Value = Convert.ToDouble(Row["fPrecio"]);
            cmd.Parameters["@fCosto"].Value = Row["fCosto"].ToString();
            cmd.Parameters["@siIVA"].Value = Row["siIVA"].ToString();
            cmd.Parameters["@siComida"].Value = Row["siComida"].ToString();

            cmd.Parameters["@iidDivisa"].Value = Row["iidDivisa"].ToString(); 
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario;
            //cmd.Parameters["@iNumMesasPermitidas"].Value = Row["iNumMesasPermitidas"].ToString();
            if (dibujoByteArray == null)
                cmd.Parameters["@IFileImagen"].Value = DBNull.Value;
            else
                cmd.Parameters["@IFileImagen"].Value = dibujoByteArray;

            cmd.Parameters["@vchCodigoSat"].Value = Row["vchCodigoSat"].ToString();
            cmd.Parameters["@iidUnidadMedida"].Value = Row["iidUnidadMedida"].ToString();
            cmd.Parameters["@siCostoCalculado"].Value = Row["siCostoCalculado"].ToString();

            if (Row["siPromo"].ToString() == "0")
            {
                cmd.Parameters["@siPromo"].Value = Row["siPromo"].ToString();
                //cmd.Parameters["@dfechaActivo"].Value = DBNull.Value;
                //cmd.Parameters["@dfechaVence"].Value = DBNull.Value;
            }
            else
            {
                cmd.Parameters["@siPromo"].Value = Row["siPromo"].ToString();
                //cmd.Parameters["@dfechaActivo"].Value = Row["dfechaActivo"].ToString();
                //cmd.Parameters["@dfechaVence"].Value = Row["dfechaVence"].ToString();
            }

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

        public bool ActualizaInformacion(DataTable info, string iidProducto)
        {
            DataRow Row = info.Rows[0];
            Byte[] dibujoByteArray = null;
            try
            {
                dibujoByteArray = (byte[])(info.Rows[0]["IFileImagen"]);
            }
            catch { };

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catProductos SET dfechaUp = GETDATE(), iidUsuario = @iidUsuario,  " +
                " iidCategoria=@iidCategoria, iidAlmacen=@iidAlmacen, vchCodigo=@vchCodigo, vchDescripcion=@vchDescripcion, " +
                " fPrecio=@fPrecio, fCosto=@fCosto, siIVA=@siIVA, siComida = @siComida,   " +
                " IFileImagen=@IFileImagen, " +
                " vchCodigoSat=@vchCodigoSat,  iidUnidadMedida=@iidUnidadMedida, siCostoCalculado = @siCostoCalculado , iscombo=@isCombo" +
            " WHERE iidProducto = " + iidProducto;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidCategoria", SqlDbType.Int);
            cmd.Parameters.Add("@iidAlmacen", SqlDbType.Int);
            cmd.Parameters.Add("@vchCodigo", SqlDbType.Text);
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text);
            cmd.Parameters.Add("@iidUnidad", SqlDbType.Int);
            cmd.Parameters.Add("@fPrecio", SqlDbType.Float);
            cmd.Parameters.Add("@fCosto", SqlDbType.Float);
            cmd.Parameters.Add("@siIVA", SqlDbType.SmallInt);
            cmd.Parameters.Add("@siComida", SqlDbType.SmallInt);
            cmd.Parameters.Add("@isCombo", SqlDbType.SmallInt);

            cmd.Parameters.Add("@iidDivisa", SqlDbType.Int);
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            //cmd.Parameters.Add("@iNumMesasPermitidas", SqlDbType.Int);
            cmd.Parameters.Add("@IFileImagen", SqlDbType.Image);
            cmd.Parameters.Add("@vchCodigoSat", SqlDbType.Text);
            cmd.Parameters.Add("@iidUnidadMedida", SqlDbType.Int);
            cmd.Parameters.Add("@siCostoCalculado", SqlDbType.SmallInt);

            cmd.Parameters["@iidCategoria"].Value = Row["iidCategoria"].ToString();
            cmd.Parameters["@iidAlmacen"].Value = Row["iidAlmacen"].ToString();
            cmd.Parameters["@vchCodigo"].Value = Row["vchCodigo"].ToString();
            cmd.Parameters["@vchDescripcion"].Value = Row["vchDescripcion"].ToString();
            cmd.Parameters["@iidUnidad"].Value = Row["iidUnidad"].ToString();
            cmd.Parameters["@fPrecio"].Value = Convert.ToDouble(Row["fPrecio"]);
            cmd.Parameters["@fCosto"].Value = Row["fCosto"].ToString();
            cmd.Parameters["@siIVA"].Value = Row["siIVA"].ToString();
            cmd.Parameters["@siComida"].Value = Row["siComida"].ToString();
            cmd.Parameters["@siCostoCalculado"].Value = Row["siCostoCalculado"].ToString();
            cmd.Parameters["@isCombo"].Value = Row["isCombo"].ToString();

            cmd.Parameters["@iidDivisa"].Value = Row["iidDivisa"].ToString();
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario;
            //cmd.Parameters["@iNumMesasPermitidas"].Value = Row["iNumMesasPermitidas"].ToString();
            if (dibujoByteArray == null)
                cmd.Parameters["@IFileImagen"].Value = DBNull.Value;
            else
                cmd.Parameters["@IFileImagen"].Value = dibujoByteArray;

            cmd.Parameters["@vchCodigoSat"].Value = Row["vchCodigoSat"].ToString();
            cmd.Parameters["@iidUnidadMedida"].Value = Row["iidUnidadMedida"].ToString();
            
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
















        /*public DataTable obtener_producto(string producto)
        {
            string sql = " SELECT P.vchCodigo, P.vchDescripcion, " +
                " P.iidUnidad, P.vchUnidad, P.fPrecio, P.iidCategoria, P.vchUnidad, " +
                " P.iidDivisa, P.iidImpuesto, P.iidProducto, P.vchRutaImg, P.dfechaActivo, P.dfechaVence, P.fCosto, P.IFileImagen, " +
                " I.vchNombre Impuesto, I.fImpuesto, I.vchTipo, I.vchSiglas, iNumMesasPermitidas, iidPuerto puerto, siComida, fStockMinimo, iidAlmacen   " +
            " FROM catProductos (NOLOCK) P, catImpuestos I (NOLOCK) " +
            " WHERE P.iidImpuesto = I.iidImpuesto " +
            " AND iidProducto = " + producto +
            "  ";

            return Conexion.Consultasql(sql);
        }

        public bool existe_codigo(string codigo)
        {
            string sql = " SELECT iidProducto " +
                         " FROM catProductos " +
                         " WHERE vchCodigo = '" + codigo +"'";

            int numero = Conexion.NumeroFilas(sql);

            if (numero != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */
        public string getIdProductoCreado()
        {
            string sql = "SELECT MAX(iidProducto)iidProducto FROM catProductos (NOLOCK) ";
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["iidProducto"].ToString();
            }
            catch
            {
                return "0";
            }
        }

        public bool borrar_ComposicionMateriaPrima(string idMP, string idPedido)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "delete from RelProductoMateriaprima where iidMateriPrima = " + idMP + " and iidProducto = " + idPedido;
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
    }
}
