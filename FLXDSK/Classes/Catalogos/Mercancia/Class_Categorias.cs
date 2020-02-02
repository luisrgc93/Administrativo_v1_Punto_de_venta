using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Catalogos.Mercancia
{
    class Class_Categorias
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();

        public string getIdSiguiente() {
            string sql = "SELECT top 1 iidCategoria + 1 siguiente from catCategorias order by iidCategoria desc ";
            DataTable dt = new DataTable();
            if (dt.Rows.Count == 0)
            {
                return "1";
            }
            else {
                return dt.Rows[0]["siguiente"].ToString();
            }
        }
        public bool inserta_categoria(DataTable info)
        {
            DataRow Row = info.Rows[0];

            Byte[] dibujoByteArray = null;
            try
            {
                dibujoByteArray = (byte[])(info.Rows[0]["imagen"]);
            }
            catch{ };
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO catCategorias (iidEmpresa, dFechaIn, dFechaUp, vchNombre, vchDescripcion, iidEstatus, iidUsuario, SiEnviado, vchRutaImg, IFileImagen) " +
                         " VALUES (@iidEmpresa, GETDATE(), GETDATE(), @vchNombre, @vchDescripcion, 1, @iidUsuario, 0, '', @IFileImagen)";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int);
            cmd.Parameters.Add("@vchNombre", SqlDbType.Text);
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text);
            cmd.Parameters.Add("@IFileImagen", SqlDbType.Image);
            ///
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@iidEmpresa"].Value = Classes.Class_Session.IDEMPRESA;
            cmd.Parameters["@vchNombre"].Value = Row["Nombre"].ToString();
            cmd.Parameters["@vchDescripcion"].Value = Row["Descripcion"].ToString();
            if (dibujoByteArray == null)
                cmd.Parameters["@IFileImagen"].Value = DBNull.Value;
            else
                cmd.Parameters["@IFileImagen"].Value = dibujoByteArray;

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

        public bool borrar_categoria(string idCategoria)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catCategorias SET iidEstatus = 2, dFechaUp = GETDATE() WHERE iidCategoria = " + idCategoria;

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
                row_Excepcion["vchAccion"] = "funcion (borrar_area)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public bool actualiza_categoria(DataTable info)
        {
            DataRow Row = info.Rows[0];
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            Byte[] dibujoByteArray = null;
            try
            {
                dibujoByteArray = (byte[])(info.Rows[0]["imagen"]);
            }
            catch { };


            string sql = " UPDATE catCategorias SET iidEmpresa = @iidEmpresa, dFechaUp = GETDATE(), " +
            " vchNombre = @vchNombre, vchDescripcion = @vchDescripcion, IFileImagen = @IFileImagen " +
            " WHERE iidCategoria = @iidCategoria ";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int);
            cmd.Parameters.Add("@iidCategoria", SqlDbType.Int);
            cmd.Parameters.Add("@vchNombre", SqlDbType.Text);
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text);
            cmd.Parameters.Add("@IFileImagen", SqlDbType.Image);

            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@iidEmpresa"].Value = Classes.Class_Session.IDEMPRESA;
            cmd.Parameters["@iidCategoria"].Value = Row["idCategoria"].ToString();
            cmd.Parameters["@vchNombre"].Value = Row["Nombre"].ToString();
            cmd.Parameters["@vchDescripcion"].Value = Row["Descripcion"].ToString();
            if (dibujoByteArray == null)
                cmd.Parameters["@IFileImagen"].Value = DBNull.Value;
            else
                cmd.Parameters["@IFileImagen"].Value = dibujoByteArray;

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

        public bool existe_categoria(string nombre)
        {
            string sql = "SELECT iidCategoria FROM catCategorias WHERE vchNombre = '" + nombre + "' AND iidEstatus = 1 ";

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

        public DataTable obtener_categoria(string idarea)
        {

            string sql = " SELECT vchNombre, vchDescripcion, vchRutaImg, IFileImagen" +
                         " FROM catCategorias (NOLOCK) " +
                         " WHERE iidCategoria =  " + idarea + " order by dfechain desc";    

            return Conexion.Consultasql(sql);
        }

        public DataTable getCategoriasAll()
        { 
            string sql = " SELECT 0 AS id, 'Seleccionar' AS nombre " +
                         " UNION ALL " +
                         " SELECT iidCategoria AS id, vchNombre AS nombre " +
                         " FROM catCategorias " +
                         " WHERE iidEstatus = 1";
            
            return Conexion.Consultasql(sql);
        }

        public DataTable getAlmacenProducto(string idProducto)
        {
            string sql = " SELECT 0 AS id, 'Seleccionar' AS nombre " +
                         " UNION ALL " +
                         " select E.iidAlmacen AS id, A.vchNombre AS nombre from catExistencias E, catAlmacenes A where E.iidProducto = " + idProducto + " and E.iidAlmacen = A.iidAlmacen";

            return Conexion.Consultasql(sql);
        }

        public DataTable getAlmacenProductoMateriaPrima()
        {
            string sql = " select distinct A.iidAlmacen AS id, A.vchNombre AS nombre from catAlmacenes A where iidEstatus = 1";

            return Conexion.Consultasql(sql);
        }
    }
}
