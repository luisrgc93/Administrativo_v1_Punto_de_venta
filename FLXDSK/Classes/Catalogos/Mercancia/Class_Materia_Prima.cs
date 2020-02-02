using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace FLXDSK.Classes.Catalogos.Mercancia
{
    class Class_Materia_Prima
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = " SELECT iidMateriPrima, iidCategoriaMateriPrima, siInventariar, dfechaIn, dfechaUp, iidUsuario, vchCodigo , fContenido,  " +
                " vchDescripcion, fCosto, iidEstatus, fStockMinimo, iidUnidad, fCostoPromedio , fContenido" +
            " FROM catMateriaPrima (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public DataTable getLista(string filtro)
        {
            string sql = " SELECT M.iidMateriPrima, M.iidCategoriaMateriPrima, M.siInventariar, M.dfechaIn, M.dfechaUp, M.iidUsuario, M.vchCodigo, M.fContenido,  " +
                " M.vchDescripcion, M.fCosto, M.iidEstatus, M.fStockMinimo, M.iidUnidad, M.fCostoPromedio,  fContenido, " +
                " U.vchAbreviacion, U.vchNombre " +
            " FROM catMateriaPrima (NOLOCK) M , catUnidadesMetricas (NOLOCK) U " +
            " WHERE M.iidUnidad = U.iidUnidad " + 
            " " + filtro;
            return Conexion.Consultasql(sql);
        }
        public DataTable getListaConExistencia(string filtroWhere)
        {
            string sql = " SELECT iidMateriPrima, iidCategoriaMateriPrima, siInventariar, dfechaIn, dfechaUp, iidUsuario, vchCodigo,  " +
                " vchDescripcion, fCosto, iidEstatus, fStockMinimo, iidUnidad, fCostoPromedio " +
            " FROM catMateriaPrima (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }

        public bool Eliminar(string Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "UPDATE catMateriaPrima SET iidEstatus = 2, dFechaUp = GETDATE() WHERE iidMateriPrima = " + Id;
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

        //metodo old
        public bool InsertaInformacion(string siInventariar, string vchCodigo, string vchDescripcion, double fCosto, int fStockMinimo, string iidCategoriaMateriPrima, string iidUnidad)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO catMateriaPrima (iidCategoriaMateriPrima, siInventariar, dfechaIn, dfechaUp, iidUsuario, vchCodigo, " +
            " vchDescripcion, fCosto, iidEstatus, fStockMinimo, iidUnidad, fCostoPromedio ) " +
            " VALUES (@iidCategoriaMateriPrima, @siInventariar, GETDATE(), GETDATE(), @iidUsuario, @vchCodigo, " +
            " @vchDescripcion, @fCosto, 1, @fStockMinimo, @iidUnidad, @fCostoPromedio )";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchCodigo", SqlDbType.Text).Value = vchCodigo;
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text).Value = vchDescripcion;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int).Value = Class_Session.Idusuario.ToString();
            cmd.Parameters.Add("@iidUnidad", SqlDbType.Int).Value = iidUnidad;
            cmd.Parameters.Add("@siInventariar", SqlDbType.SmallInt).Value = siInventariar;
            cmd.Parameters.Add("@iidCategoriaMateriPrima", SqlDbType.Int).Value = iidCategoriaMateriPrima;
            cmd.Parameters.Add("@fCosto", SqlDbType.Int).Value = fCosto;
            cmd.Parameters.Add("@fStockMinimo", SqlDbType.Int).Value = fStockMinimo;
            cmd.Parameters.Add("@fCostoPromedio", SqlDbType.Int).Value = fCosto;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                ClsLog.InsertaInformacion(exp.Message.ToString(), "Materia_Prima.Insertar");
                return false;
            }
        }

        public bool InsertaInformacion(string siInventariar, string vchCodigo, string vchDescripcion, double fCosto, int fStockMinimo, string iidCategoriaMateriPrima, string iidUnidad, double fContenido)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO catMateriaPrima (iidCategoriaMateriPrima, siInventariar, dfechaIn, dfechaUp, iidUsuario, vchCodigo, " +
            " vchDescripcion, fCosto, iidEstatus, fStockMinimo, iidUnidad, fCostoPromedio, fContenido ) " +
            " VALUES (@iidCategoriaMateriPrima, @siInventariar, GETDATE(), GETDATE(), @iidUsuario, @vchCodigo, " +
            " @vchDescripcion, @fCosto, 1, @fStockMinimo, @iidUnidad, @fCostoPromedio, @fContenido )";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchCodigo", SqlDbType.Text).Value = vchCodigo;
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text).Value = vchDescripcion;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int).Value = Class_Session.Idusuario.ToString();
            cmd.Parameters.Add("@iidUnidad", SqlDbType.Int).Value = iidUnidad;
            cmd.Parameters.Add("@siInventariar", SqlDbType.SmallInt).Value = siInventariar;
            cmd.Parameters.Add("@iidCategoriaMateriPrima", SqlDbType.Int).Value = iidCategoriaMateriPrima;
            cmd.Parameters.Add("@fCosto", SqlDbType.Float).Value = fCosto;
            cmd.Parameters.Add("@fStockMinimo", SqlDbType.Int).Value = fStockMinimo;
            cmd.Parameters.Add("@fCostoPromedio", SqlDbType.Float).Value = fCosto;
            cmd.Parameters.Add("@fContenido", SqlDbType.Float).Value = fContenido;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                ClsLog.InsertaInformacion(exp.Message.ToString(), "Materia_Prima.Insertar");
                return false;
            }
        }

        //metodo old
        public bool ActualizaInformacion(string siInventariar, string vchCodigo, string vchDescripcion, double fCosto, int fStockMinimo, string iidCategoriaMateriPrima, string iidUnidad, string Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE catMateriaPrima SET vchCodigo = @vchCodigo, vchDescripcion = @vchDescripcion, dfechaUp = GETDATE(), iidUsuario = @iidUsuario, " +
            " iidCategoriaMateriPrima = @iidCategoriaMateriPrima, fCosto=@fCosto, fStockMinimo=@fStockMinimo, iidUnidad=@iidUnidad, siInventariar = @siInventariar " +
            " WHERE iidMateriPrima = " + Id;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchCodigo", SqlDbType.Text).Value = vchCodigo;
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text).Value = vchDescripcion;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int).Value = Class_Session.Idusuario.ToString();
            cmd.Parameters.Add("@iidUnidad", SqlDbType.Int).Value = iidUnidad;
            cmd.Parameters.Add("@siInventariar", SqlDbType.SmallInt).Value = siInventariar;
            cmd.Parameters.Add("@iidCategoriaMateriPrima", SqlDbType.Int).Value = iidCategoriaMateriPrima;
            cmd.Parameters.Add("@fCosto", SqlDbType.Int).Value = fCosto;
            cmd.Parameters.Add("@fStockMinimo", SqlDbType.Int).Value = fStockMinimo;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                ClsLog.InsertaInformacion(exp.Message.ToString(), "Materia_Prima.Actualizar");
                return false;
            }
        }


        public bool ActualizaInformacion(string siInventariar, string vchCodigo, string vchDescripcion, double fCosto, int fStockMinimo, string iidCategoriaMateriPrima, string iidUnidad, string Id, double fContenido)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE catMateriaPrima SET vchCodigo = @vchCodigo, vchDescripcion = @vchDescripcion, dfechaUp = GETDATE(), iidUsuario = @iidUsuario, " +
            " iidCategoriaMateriPrima = @iidCategoriaMateriPrima, fCosto=@fCosto, fStockMinimo=@fStockMinimo, iidUnidad=@iidUnidad, siInventariar = @siInventariar, fContenido = @fContenido " +
            " WHERE iidMateriPrima = " + Id;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchCodigo", SqlDbType.Text).Value = vchCodigo;
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text).Value = vchDescripcion;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int).Value = Class_Session.Idusuario.ToString();
            cmd.Parameters.Add("@iidUnidad", SqlDbType.Int).Value = iidUnidad;
            cmd.Parameters.Add("@siInventariar", SqlDbType.SmallInt).Value = siInventariar;
            cmd.Parameters.Add("@iidCategoriaMateriPrima", SqlDbType.Int).Value = iidCategoriaMateriPrima;
            cmd.Parameters.Add("@fCosto", SqlDbType.Float).Value = fCosto;
            cmd.Parameters.Add("@fStockMinimo", SqlDbType.Int).Value = fStockMinimo;
            cmd.Parameters.Add("@fContenido", SqlDbType.Float).Value = fContenido;
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                ClsLog.InsertaInformacion(exp.Message.ToString(), "Materia_Prima.Actualizar");
                return false;
            }
        }


        public bool ActualizaPrecio(string iidMateriPrima, string fCosto)
        {
            string sql = " UPDATE catMateriaPrima SET  dfechaUp = GETDATE(), iidUsuario = " + Class_Session.Idusuario.ToString() + ", fCosto= " + fCosto + "  WHERE iidMateriPrima = " + iidMateriPrima;
            return Conexion.InsertaSql(sql);
        }
        /*public DataTable obtener_materia_prima(string producto)
        {
            string sql = " SELECT iidMateriPrima, iidCategoriaMateriPrima, " +
                         " vchCodigo, vchDescripcion, fCosto " +
                         " FROM catMateriaPrima " +
                         " WHERE iidEstatus = 1 " +
                         " AND iidMateriPrima = " + producto +
                         " ORDER BY dFechaIn DESC ";

            return Conexion.Consultasql(sql);
        }

        public DataTable obtener_producto(string producto)
        {
            string sql = " SELECT iidProducto, vchCodigo, vchDescripcion, " +
                         " iidUnidad, fPrecio " +
                         " FROM catProductos " +
                         " WHERE iidEstatus = 1  " +
                         " AND iidProducto = " + producto +
                         " ORDER BY dFechaIn DESC ";

            return Conexion.Consultasql(sql);
        }

        public DataTable ultimo_materia_guardado()
        {
            string sql = " SELECT TOP 1 iidMateriPrima, iidCategoriaMateriPrima, " +
                         " vchCodigo, vchDescripcion, fCosto " +
                         " FROM catMateriaPrima " +
                         " WHERE iidEstatus = 1 " +
                         " ORDER BY dFechaIn DESC ";
            return Conexion.Consultasql(sql);
        }

        public DataTable ultimo_producto_guardado()
        {
            string sql = " SELECT iidProducto, vchCodigo, " +
                         " vchDescripcion, fPrecio " +
                         " FROM catProductos " +
                         " WHERE iidEstatus = 1  " +
                         " ORDER BY dFechaIn DESC ";

            return Conexion.Consultasql(sql);
        }

        //------------------------------------------------------------- Categoría de Materias Primas ------------------------------------------------------------------------------------------
        public bool borrar_CategoriaMateriaPrima(string idCategoriaMP)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "UPDATE catCategoriasMateriaPrima SET iidEstatus = 2, dFechaUp = GETDATE() WHERE iidCategoriaMateriPrima = " + idCategoriaMP;

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

        public bool inserta_Categoria(DataTable info)
        {
            DataRow row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " insert into catMateriaPrima (iidCategoriaMateriPrima, dfechaIn, dfechaUp, iidUsuario, vchCodigo, vchDescripcion, fCosto, fStockMinimo, iidEstatus, iidUnidadStock) " +
                         " values (@idCategoria, getdate(), getdate(), @idusuario, @Código, @Nombre, @Costo, @stock, 1, @unidad)";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@Código", SqlDbType.Text).Value = row["Código"].ToString();
            cmd.Parameters.Add("@Categoría", SqlDbType.Text).Value = row["Categoría"].ToString();
            cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = Class_Session.Idusuario.ToString();
            cmd.Parameters.Add("@unidad", SqlDbType.Int).Value = row["unidad"].ToString();
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

        public bool actualiza_categoria(DataTable info)
        {
            DataRow row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " update catMateriaPrima set dfechaUp = getdate(), iidCategoriaMateriPrima = @idCategoria, vchCodigo = @Código, vchDescripcion = @Nombre, fCosto = @Costo, fStockMinimo = @stock, iidUnidadStock = @unidad where iidMateriPrima = @idMateriaPrima";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@Código", SqlDbType.Text).Value = row["Código"].ToString();
            cmd.Parameters.Add("@Categoría", SqlDbType.Text).Value = row["Categoría"].ToString();
            cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = row["idCategoria"].ToString();
            cmd.Parameters.Add("@unidad", SqlDbType.Int).Value = row["unidad"].ToString();
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

        public DataTable obtener_categoria_xID(string idCategoria)
        {

            string sql = " select vchCodigo, vchDescripcion from catCategoriasMateriaPrima where iidCategoriaMateriPrima = " + idCategoria;
            return Conexion.Consultasql(sql);
        }

        ///------------------------------------------------------------- Materias Primas ------------------------------------------------------------------------------------------
        public bool borrar_MateriaPrima(string idMateriaPrima)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "UPDATE catMateriaPrima SET iidEstatus = 2, dFechaUp = GETDATE() WHERE iidMateriPrima = " + idMateriaPrima;

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

        public bool inserta_MateriaPrima(DataTable info)
        {
            DataRow row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " insert into catMateriaPrima (iidCategoriaMateriPrima, dfechaIn, dfechaUp, iidUsuario, vchCodigo, vchDescripcion, fCosto, fStockMinimo, iidEstatus, iidUnidadStock) " +
                         " values (@idCategoria, getdate(), getdate(), @idusuario, @Código, @Nombre, @Costo, @stock, 1, @unidad)";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@Código", SqlDbType.Text).Value = row["Código"].ToString();
            cmd.Parameters.Add("@Nombre", SqlDbType.Text).Value = row["Nombre"].ToString();
            cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = Convert.ToInt32(Class_Session.Idusuario);
            cmd.Parameters.Add("@Costo", SqlDbType.Float).Value = row["Costo"].ToString();
            cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = row["idCategoria"].ToString();
            cmd.Parameters.Add("@stock", SqlDbType.Float).Value = row["stock"].ToString();
            cmd.Parameters.Add("@unidad", SqlDbType.Int).Value = row["unidad"].ToString();

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

        public bool actualiza_MateriaPrima(DataTable info)
        {
            DataRow row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " update catMateriaPrima set dfechaUp = getdate(), iidCategoriaMateriPrima = @idCategoria, vchCodigo = @Código, vchDescripcion = @Nombre, fCosto = @Costo, fStockMinimo = @stock, iidUnidadStock = @unidad where iidMateriPrima = @idMateriaPrima";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@Código", SqlDbType.Text).Value = row["Código"].ToString();
            cmd.Parameters.Add("@Nombre", SqlDbType.Text).Value = row["Nombre"].ToString();
            cmd.Parameters.Add("@Costo", SqlDbType.Float).Value = row["Costo"].ToString();
            cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = row["idCategoria"].ToString();
            cmd.Parameters.Add("@idMateriaPrima", SqlDbType.Int).Value = row["idMateriaPrima"].ToString();
            cmd.Parameters.Add("@stock", SqlDbType.Float).Value = row["stock"].ToString();
            cmd.Parameters.Add("@unidad", SqlDbType.Int).Value = row["unidad"].ToString();

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

        public DataTable obtener_MateriaPrima_xID(string idMateriaPrima)
        {

            string sql = "select vchCodigo, vchDescripcion, fCosto, iidCategoriaMateriPrima from catMateriaPrima where iidMateriPrima = " + idMateriaPrima;
            return Conexion.Consultasql(sql);
        }

        public DataTable GetCategorias()
        {
            DataTable dt = new DataTable();
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre UNION ALL " +
                         " SELECT iidCategoriaMateriPrima as id, vchDescripcion as nombre	 FROM  catCategoriasMateriaPrima (NOLOCK)   WHERE iidEstatus = 1";
            dt = Conexion.Consultasql(sql);
            return dt;
        }

        ///------------------------------------------------------------- Materias Primas ------------------------------------------------------------------------------------------
        public DataTable obtener_existencia_producto(string producto, string almacen)
        {
            string sql = " SELECT iidProducto, iidAlmacen, fCantidad, iidUnidadMetrica " +
                         " FROM catExistencias " +
                         " WHERE iidProducto = " + producto +
                         " AND iidAlmacen = " + almacen; 

            return Conexion.Consultasql(sql);
        }

        public DataTable obtener_existencia_materia_prima(string producto, string almacen)
        {
            string sql = " SELECT iidMateriPrima, iidAlmacen, fCantidad, iidUnidadMetrica, fContenidoXPieza " +
                         " FROM catExistenciasMateriaPrima" +
                         " WHERE iidMateriPrima = " + producto + 
                         " AND iidAlmacen = " + almacen;

            return Conexion.Consultasql(sql);
        }
        */
    }
}
