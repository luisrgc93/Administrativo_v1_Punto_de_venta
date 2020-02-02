using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FLXDSK.Classes
{
    class Class_MateriaPrima
    {
        /*
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();


        //------------------------------------------------------------- Categoría de Materias Primas ------------------------------------------------------------------------------------------
        

        public DataTable obtener_categoria_xID(string idCategoria)
        {

            string sql = " select vchCodigo, vchDescripcion from catCategoriasMateriaPrima where iidCategoriaMateriPrima = " + idCategoria;
            return conx.Consultasql(sql);
        }

        //------------------------------------------------------------- Materias Primas ------------------------------------------------------------------------------------------
        public bool borrar_MateriaPrima(string idMateriaPrima)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

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
            cmd.Connection = conx.ConexionSQL();

            string sql = " insert into catMateriaPrima (iidCategoriaMateriPrima, dfechaIn, dfechaUp, iidUsuario, vchCodigo, vchDescripcion, fCosto, fStockMinimo, iidEstatus, iidUnidadStock) " +
                         " values (@idCategoria, getdate(), getdate(), @idusuario, @Código, @Nombre, @Costo, @stock, 1, @unidad)";


            cmd.CommandText = sql;
            cmd.Parameters.Add("@Código", SqlDbType.Text).Value = row["Código"].ToString();
            cmd.Parameters.Add("@Nombre", SqlDbType.Text).Value = row["Nombre"].ToString();
            cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = Class_Session.Idusuario.ToString();
            cmd.Parameters.Add("@Costo", SqlDbType.Float).Value = row["Costo"].ToString();
            cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = row["idCategoria"].ToString();
            cmd.Parameters.Add("@stock", SqlDbType.Int).Value = row["stock"].ToString();
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
            cmd.Connection = conx.ConexionSQL();

            string sql = " update catMateriaPrima set dfechaUp = getdate(), iidCategoriaMateriPrima = @idCategoria, vchCodigo = @Código, vchDescripcion = @Nombre, fCosto = @Costo, fStockMinimo = @stock, iidUnidadStock = @unidad where iidMateriPrima = @idMateriaPrima";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@Código", SqlDbType.Text).Value = row["Código"].ToString();
            cmd.Parameters.Add("@Nombre", SqlDbType.Text).Value = row["Nombre"].ToString();
            cmd.Parameters.Add("@Costo", SqlDbType.Float).Value = row["Costo"].ToString();
            cmd.Parameters.Add("@idCategoria", SqlDbType.Int).Value = row["idCategoria"].ToString();
            cmd.Parameters.Add("@idMateriaPrima", SqlDbType.Int).Value = row["idMateriaPrima"].ToString();
            cmd.Parameters.Add("@stock", SqlDbType.Int).Value = row["stock"].ToString();
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
            return conx.Consultasql(sql);
        }
        
        public DataTable GetCategorias()
        {
            DataTable dt = new DataTable();
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre UNION ALL "+
                         " SELECT iidCategoriaMateriPrima as id, vchDescripcion as nombre	 FROM  catCategoriasMateriaPrima (NOLOCK)   WHERE iidEstatus = 1";
            dt = conx.Consultasql(sql);
            return dt;
        }
        public DataTable GetAlmacenes()
        {
            DataTable dt = new DataTable();
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre UNION ALL " +
                         " SELECT iidAlmacen as id, vchNombre as nombre	 FROM  catAlmacenes (NOLOCK)   WHERE iidEstatus = 1";
            dt = conx.Consultasql(sql);
            return dt;
        }

        public bool existeCodigo(string codigo)
        {
            string sql = "select * from catMateriaPrima where vchCodigo = '" + codigo + "'";
            int numero = conx.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else
                return false;
        }
        public bool existeMP(string producto)
        {
            string sql = "select * from catMateriaPrima where vchDescripcion = '" + producto + "'";
            int numero = conx.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else
                return false;
        }

        public string getIDMP()
        {
            string sql = "select top 1 iidMateriPrima from catMateriaPrima order by dfechain desc";
            DataTable dt = new DataTable();
            dt = conx.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["iidMateriPrima"].ToString();
            }
            catch
            {
                return "";
            }
        }*/
    }
}
