using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Catalogos.Proveedores
{
    class Class_Proveedores
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Class_Logs ClsLog = new Class_Logs();


        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = " SELECT iidProveedor, vchRazonSocial ,vchNombreComercial ,vhcRFC, " +
            " vchObservaciones ,vchDomicilio ,vchNumExt ,vchNumInt ,vchColonia, " +
            " vchLocalidad ,vchMunicipio ,vchCP ,iidPais ,iidEstado ,vchTelefono, " +
            " vchCorreo ,vchPagina , iidUsuario, iidEmpresa,iidEstatus ,dfechIn ,dFechaUp  " +
            " FROM catProveedores  (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public bool inserta_proveedor(DataTable info)
        {
            DataRow Row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catProveedores (vchRazonSocial ,vchNombreComercial ,vhcRFC " +
                         " ,vchObservaciones ,vchDomicilio ,vchNumExt ,vchNumInt ,vchColonia " + 
                         " ,vchLocalidad ,vchMunicipio ,vchCP ,iidPais ,iidEstado ,vchTelefono " +
                         " ,vchCorreo ,vchPagina , iidUsuario, iidEmpresa,iidEstatus ,dfechIn ,dFechaUp)  " +
                         " VALUES (@razon, @nombre, @rfc, " +
                         " @observaciones, @domicilio, @exterior, @interior, @colonia, " +
                         " @localidad, @municipio, @cp, @idpais, @idestado, @telefono, " +
                         " @correo, @pagina, @iidUsuario, @iidEmpresa, 1, GETDATE(), GETDATE())";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@razon", SqlDbType.Text);
            cmd.Parameters.Add("@nombre", SqlDbType.Text);
            cmd.Parameters.Add("@rfc", SqlDbType.Text);
            cmd.Parameters.Add("@observaciones", SqlDbType.Text);
            cmd.Parameters.Add("@domicilio", SqlDbType.Text);
            cmd.Parameters.Add("@exterior", SqlDbType.Text);
            cmd.Parameters.Add("@interior", SqlDbType.Text);
            cmd.Parameters.Add("@colonia", SqlDbType.Text);
            cmd.Parameters.Add("@localidad", SqlDbType.Text);
            cmd.Parameters.Add("@municipio", SqlDbType.Text);
            cmd.Parameters.Add("@cp", SqlDbType.Text);
            cmd.Parameters.Add("@idpais", SqlDbType.Int);
            cmd.Parameters.Add("@idestado", SqlDbType.Int);
            cmd.Parameters.Add("@telefono", SqlDbType.Text);
            cmd.Parameters.Add("@correo", SqlDbType.Text);
            cmd.Parameters.Add("@pagina", SqlDbType.Text);
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int);

            ///
            cmd.Parameters["@razon"].Value = Row["razon"].ToString();
            cmd.Parameters["@nombre"].Value = Row["nombre"].ToString();
            cmd.Parameters["@rfc"].Value = Row["rfc"].ToString();
            cmd.Parameters["@observaciones"].Value = Row["observaciones"].ToString();
            cmd.Parameters["@domicilio"].Value = Row["domicilio"].ToString();
            cmd.Parameters["@exterior"].Value = Row["exterior"].ToString();
            cmd.Parameters["@interior"].Value = Row["interior"].ToString();
            cmd.Parameters["@colonia"].Value = Row["colonia"].ToString();
            cmd.Parameters["@localidad"].Value = Row["localidad"].ToString();
            cmd.Parameters["@municipio"].Value = Row["municipio"].ToString();
            cmd.Parameters["@cp"].Value = Row["cp"].ToString();
            cmd.Parameters["@idpais"].Value = Row["idpais"].ToString();
            cmd.Parameters["@idestado"].Value = Row["idestado"].ToString();
            cmd.Parameters["@telefono"].Value = Row["telefono"].ToString();
            cmd.Parameters["@correo"].Value = Row["correo"].ToString();
            cmd.Parameters["@pagina"].Value = Row["pagina"].ToString();
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@iidEmpresa"].Value = Classes.Class_Session.IDEMPRESA;

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
                row_Excepcion["vchLugar"] = "Class_Proveedores";
                row_Excepcion["vchAccion"] = "funcion (inserta_proveedor)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public bool actualiza_proveedor(DataTable info)
        {
            DataRow Row = info.Rows[0];

            string idproveedor = Row["idproveedor"].ToString();
            string razon = Row["razon"].ToString();
            string nombre = Row["nombre"].ToString();
            string rfc = Row["rfc"].ToString();
            string observaciones = Row["observaciones"].ToString();
            string domicilio = Row["domicilio"].ToString();
            string exterior = Row["exterior"].ToString();
            string interior = Row["interior"].ToString();
            string colonia = Row["colonia"].ToString();
            string localidad = Row["localidad"].ToString();
            string municipio = Row["municipio"].ToString();
            string cp = Row["cp"].ToString();
            string idpais = Row["idpais"].ToString();
            string idestado = Row["idestado"].ToString();
            string telefono = Row["telefono"].ToString();
            string correo = Row["correo"].ToString();
            string pagina = Row["pagina"].ToString();
            string Idusuario = Classes.Class_Session.Idusuario.ToString();
            string IdEmpresa = Classes.Class_Session.IDEMPRESA.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catProveedores SET vchRazonSocial = '" + razon + "', vchNombreComercial  = '" + nombre + "', vhcRFC  = '" + rfc + "', vchObservaciones  = '" + observaciones + "', " +
                " vchDomicilio  = '" + domicilio + "', vchNumExt  = '" + exterior + "', vchNumInt  = '" + interior + "', vchColonia  = '" + colonia + "', vchLocalidad  = '" + localidad + "', vchMunicipio  = '" + municipio + "', " +
                " vchCP  = '" + cp + "', iidPais  = " + idpais + ", iidEstado  = " + idestado + " , vchTelefono  = '" + telefono + "' , vchCorreo  = '" + correo + "', vchPagina  = '" + pagina + "', " +
                " iidUsuario  = " + Idusuario + " , iidEmpresa  = " + IdEmpresa + ", iidEstatus  = 1, dFechaUp  = GETDATE() " +
            " WHERE iidProveedor = " + idproveedor +"";

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
                row_Excepcion["vchLugar"] = "Class_Proveedores";
                row_Excepcion["vchAccion"] = "funcion (inserta_proveedor)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public bool borrar_proveedor(string id) 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "UPDATE catProveedores SET iidEstatus = 2 WHERE iidProveedor = " + id;

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
                row_Excepcion["vchLugar"] = "Class_proveedores";
                row_Excepcion["vchAccion"] = "funcion (borrar_proveedor)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public DataTable get_proveedores(string id) 
        {
            string sql = " SELECT iidProveedor, vchRazonSocial ,vchNombreComercial ,vhcRFC " + 
                         " ,vchObservaciones ,vchDomicilio ,vchNumExt ,vchNumInt ,vchColonia " + 
                         " ,vchLocalidad ,vchMunicipio ,vchCP ,iidPais ,iidEstado ,vchTelefono " + 
                         " ,vchCorreo ,vchPagina ,iidEstatus ,dfechIn ,dFechaUp " +                           
                         " FROM catProveedores " +
                         " WHERE iidEstatus = 1 " +
                         " AND iidProveedor = " + id;

            return Conexion.Consultasql(sql);
        }

        public DataTable get_proveedores_x_razon(string razon)
        {
            string sql = " SELECT iidProveedor, vchRazonSocial ,vchNombreComercial ,vhcRFC " +
                         " ,vchObservaciones ,vchDomicilio ,vchNumExt ,vchNumInt ,vchColonia " +
                         " ,vchLocalidad ,vchMunicipio ,vchCP ,iidPais ,iidEstado ,vchTelefono " +
                         " ,vchCorreo ,vchPagina ,iidEstatus ,dfechIn ,dFechaUp " +
                         " FROM catProveedores " +
                         " WHERE iidEstatus = 1 " +
                         " AND vchRazonSocial = '" + razon + "' ";

            return Conexion.Consultasql(sql);
        }

        public bool existe_proveedores(string razon)
        {
            string sql = " SELECT iidProveedor " +
                         " FROM catProveedores " +
                         " WHERE iidEstatus = 1 " +
                         " AND vchRazonSocial = " + razon;

            int numero =  Conexion.NumeroFilas(sql);

            if (numero == 0)
            { 
                return false;
            }
            else
            {
                return true;
            }
        }        

        /**********************************RelTipoProveedor*************************************/

        public bool inserta_rel_tipos_proveedores(string idtipoproveedor, string idproveedor)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO RelTipoProveedores(iidTipoProveedor, iidProveedor, iidUsuario, iidEmpresa,dfechaIn, dfechaUp) " +
                         " VALUES (@idtipoproveedor,@idproveedor,@iidUsuario,@iidEmpresa,GETDATE(), GETDATE())";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idproveedor", SqlDbType.Int);
            cmd.Parameters.Add("@idtipoproveedor", SqlDbType.Int);
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int);

            cmd.Parameters["@idproveedor"].Value = idproveedor;
            cmd.Parameters["@idtipoproveedor"].Value = idtipoproveedor;
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@iidEmpresa"].Value = Classes.Class_Session.IDEMPRESA;

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
                row_Excepcion["vchLugar"] = "Class_Proveedores";
                row_Excepcion["vchAccion"] = "funcion (inserta_proveedor)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public DataTable obten_nombre_tipo_x_id(string id)
        {
            string sql = " SELECT vchNombre " +
                         " FROM RelTipoProveedores R " +
                         " INNER JOIN catTipoProveedores T ON T.iidTipoProveedor = R.iidTipoProveedor " +
                         " INNER JOIN catProveedores P ON P.iidProveedor = R.iidProveedor " +
                         " AND R.iidProveedor = " + id;

                return Conexion.Consultasql(sql);
        }

        public bool borrar_rel_x_id(string id)
        {
            string sql = " DELETE FROM RelTipoProveedores WHERE iidProveedor = " + id;

            return Conexion.InsertaSql(sql);
        }

        /**********************************Tipos Proveedor**************************************/

        public bool inserta_tipo_proveedor(DataTable info)
        {
            DataRow Row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catTipoProveedores (iidUsuario, iidEmpresa, vchNombre, vchDescripcion, iidEstatus, dfechaIn, dfechaUp) " +
                         " VALUES (@iidUsuario,@iidEmpresa,@vchNombre,@vchDescripcion,1,GETDATE(), GETDATE()) ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int);
            cmd.Parameters.Add("@vchNombre", SqlDbType.Text);
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text);

            ///
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@iidEmpresa"].Value = Classes.Class_Session.IDEMPRESA;
            cmd.Parameters["@vchNombre"].Value = Row["Nombre"].ToString();
            cmd.Parameters["@vchDescripcion"].Value = Row["Descripcion"].ToString();

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
                row_Excepcion["vchLugar"] = "Class_TipoProveedor";
                row_Excepcion["vchAccion"] = "funcion (inserta_TipoProveedor)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public bool borrar_tipo_proveedor(string idTipo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catTipoProveedores SET iidEstatus = 2 WHERE iidTipoProveedor = " + idTipo;

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

        public bool actualiza_tipo_proveedor(DataTable info)
        {
            DataRow Row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catTipoProveedores SET vchNombre = @vchNombre, vchDescripcion = @vchDescripcion, dfechaUp = GETDATE() WHERE iidTipoProveedor = @idTipo";

            cmd.CommandText = sql;

            cmd.Parameters.Add("@idTipo", SqlDbType.Int);
            cmd.Parameters.Add("@vchNombre", SqlDbType.Text);
            cmd.Parameters.Add("@vchDescripcion", SqlDbType.Text);

            cmd.Parameters["@idTipo"].Value = Row["idTipo"].ToString();
            cmd.Parameters["@vchNombre"].Value = Row["Nombre"].ToString();
            cmd.Parameters["@vchDescripcion"].Value = Row["Descripcion"].ToString();

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

        public string obtener_tipo_proveedor_x_nombre(string nombre)
        {
            DataTable dt = new DataTable();
            string sql = " SELECT iidTipoProveedor " +
                         " FROM catTipoProveedores " +
                         " WHERE iidEstatus = 1 " +
                         " AND vchNombre = '" + nombre + "' ";
            try
            {

                dt = Conexion.Consultasql(sql);
                DataRow row = dt.Rows[0];
                return row["iidTipoProveedor"].ToString();

            }
            catch
            {
                return "";
            }
        }

        public DataTable obtener_tipo_proveedor_x_id(string idTipo)
        {
            string sql = " SELECT iidTipoProveedor, " +
                         " vchNombre, vchDescripcion " +
                         " FROM catTipoProveedores " +
                         " WHERE iidEstatus = 1 " +
                         " AND iidTipoProveedor = " + idTipo;
            
           return Conexion.Consultasql(sql);
               
        }
        
        public DataTable obtener_tipo_proveedor()
        {
            string sql = " SELECT iidTipoProveedor, " +
                         " vchNombre, vchDescripcion " +
                         " FROM catTipoProveedores " +
                         " WHERE iidEstatus = 1 ";

            return Conexion.Consultasql(sql);
        }

        public DataTable getTipoProveedorAll()
        {

            string sql = " SELECT 0 AS id, 'Seleccionar' AS nombre " +
                         " UNION ALL " +
                         " SELECT iidTipoProveedor AS id, vchNombre AS nombre " +
                         " FROM catTipoProveedores " +
                         " WHERE iidEstatus = 1 ";

            return Conexion.Consultasql(sql);
        }
    }
}
