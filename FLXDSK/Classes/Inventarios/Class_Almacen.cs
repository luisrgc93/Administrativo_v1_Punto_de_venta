using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Inventarios
{
    class Class_Almacen
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = "SELECT iidAlmacen, iidEmpresa, dfechain , dfechaup , vchNombre , " +
            " vchDomicilio, vchNumExt , vchNumInt, vchColonia, vchCP, vchMunicipio, iidEstado, iidEstatus, iidUsuario, " +
            " vchLocalidad, vchCorreo, vchTelefono, siPrincipal " +
            " FROM  catAlmacenes (NOLOCK) " + FiltroWhere;
            return Conexion.Consultasql(sql);
        }


        public bool inserta_almacen(DataTable Info)
        {
            DataRow row = Info.Rows[0];
            string nombre = row["nombre"].ToString();
            string calle = row["calle"].ToString();
            string numext = row["numext"].ToString();
            string numint = row["numint"].ToString();
            string colonia = row["colonia"].ToString();
            string cp = row["cp"].ToString();
            string municipio = row["municipio"].ToString();
            string estado = row["estado"].ToString();
            string localidad = row["localidad"].ToString();
            string correo = row["correo"].ToString();
            string telefono = row["telefono"].ToString();
            string principal = row["principal"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string usuariolog = Convert.ToString(Class_Session.Idusuario);
            string sql = " INSERT INTO catAlmacenes  " +
                         " (iidEmpresa, dfechain , dfechaup , vchNombre , " +
                         " vchDomicilio, vchNumExt , vchNumInt, vchColonia, vchCP, vchMunicipio, iidEstado, iidEstatus, iidUsuario, " +
                         " vchLocalidad, vchCorreo, vchTelefono, siPrincipal) " +
                         " values " +
                         " (@idempresa, GETDATE(), GETDATE(), @vchnombre, " +
                         " @vchcalle, @vchnumext, @vchnumint, @vchcolonia, @vchcp, @vchmunicipio, @iidEstado, 1," + usuariolog + ", " +
                         " @localidad, @correo, @telefono, @principal)";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idempresa", SqlDbType.Int);
            cmd.Parameters.Add("@vchnombre", SqlDbType.Text);
            cmd.Parameters.Add("@vchcalle", SqlDbType.Text);
            cmd.Parameters.Add("@vchnumext", SqlDbType.Text);
            cmd.Parameters.Add("@vchnumint", SqlDbType.Text);
            cmd.Parameters.Add("@vchcolonia", SqlDbType.Text);
            cmd.Parameters.Add("@vchcp", SqlDbType.Text);
            cmd.Parameters.Add("@vchmunicipio", SqlDbType.Text);
            cmd.Parameters.Add("@iidEstado", SqlDbType.Int);
            cmd.Parameters.Add("@localidad", SqlDbType.Text);
            cmd.Parameters.Add("@correo", SqlDbType.Text);
            cmd.Parameters.Add("@telefono", SqlDbType.Text);
            cmd.Parameters.Add("@principal", SqlDbType.Int);
            cmd.Parameters["@idempresa"].Value = Class_Session.IDEMPRESA.ToString();
            cmd.Parameters["@vchcalle"].Value = calle;
            cmd.Parameters["@vchnombre"].Value = nombre;
            cmd.Parameters["@vchnumext"].Value = numext;
            cmd.Parameters["@vchnumint"].Value = numint;
            cmd.Parameters["@vchcolonia"].Value = colonia;
            cmd.Parameters["@vchcp"].Value = cp;
            cmd.Parameters["@vchmunicipio"].Value = municipio;
            cmd.Parameters["@iidEstado"].Value = estado;
            cmd.Parameters["@localidad"].Value = localidad;
            cmd.Parameters["@correo"].Value = correo;
            cmd.Parameters["@telefono"].Value = telefono;
            cmd.Parameters["@principal"].Value = principal;
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

        public bool actualiza_almacen(DataTable Info)
        {
            DataRow row = Info.Rows[0];
            string idalmacen = row["idalmacen"].ToString();
            string nombre = row["nombre"].ToString();
            string calle = row["calle"].ToString();
            string numext = row["numext"].ToString();
            string numint = row["numint"].ToString();
            string colonia = row["colonia"].ToString();
            string cp = row["cp"].ToString();
            string municipio = row["municipio"].ToString();
            string estado = row["estado"].ToString();
            string localidad = row["localidad"].ToString();
            string correo = row["correo"].ToString();
            string telefono = row["telefono"].ToString();
            string principal = row["principal"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string usuario = Convert.ToString(Class_Session.Idusuario);
            string sql = "UPDATE catAlmacenes SET " +
                         " iidEmpresa = @empresa, dfechaup = GETDATE() , vchNombre = @vchnombre, " +
                         " vchDomicilio = @vchcalle, vchNumExt= @vchnumext , vchNumInt = @vchnumint, vchColonia = @vchcolonia, " +
                         " vchCP = @vchcp, vchMunicipio = @vchmunicipio, iidEstado = @iidEstado,  iidUsuario = " + usuario + ", " +
                         " vchLocalidad = @localidad, vchCorreo = @correo, vchTelefono = @telefono, siPrincipal = @principal " +
                         " WHERE iidAlmacen = " + idalmacen;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@idalmacen", SqlDbType.Int);
            cmd.Parameters.Add("@empresa", SqlDbType.Int);
            cmd.Parameters.Add("@vchnombre", SqlDbType.Char);
            cmd.Parameters.Add("@vchcalle", SqlDbType.Char);
            cmd.Parameters.Add("@vchnumext", SqlDbType.Char);
            cmd.Parameters.Add("@vchnumint", SqlDbType.Char);
            cmd.Parameters.Add("@vchcolonia", SqlDbType.Char);
            cmd.Parameters.Add("@vchcp", SqlDbType.Char);
            cmd.Parameters.Add("@vchmunicipio", SqlDbType.Char);
            cmd.Parameters.Add("@iidEstado", SqlDbType.Int);
            cmd.Parameters.Add("@localidad", SqlDbType.Char);
            cmd.Parameters.Add("@correo", SqlDbType.Char);
            cmd.Parameters.Add("@telefono", SqlDbType.Char);
            cmd.Parameters.Add("@principal", SqlDbType.Int);
            cmd.Parameters["@idalmacen"].Value = idalmacen;
            cmd.Parameters["@empresa"].Value = Class_Session.IDEMPRESA.ToString();
            cmd.Parameters["@vchnombre"].Value = nombre;
            cmd.Parameters["@vchcalle"].Value = calle;
            cmd.Parameters["@vchnumext"].Value = numext;
            cmd.Parameters["@vchnumint"].Value = numint;
            cmd.Parameters["@vchcolonia"].Value = colonia;
            cmd.Parameters["@vchcp"].Value = cp;
            cmd.Parameters["@vchmunicipio"].Value = municipio;
            cmd.Parameters["@iidEstado"].Value = estado;
            cmd.Parameters["@localidad"].Value = localidad;
            cmd.Parameters["@correo"].Value = correo;
            cmd.Parameters["@telefono"].Value = telefono;
            cmd.Parameters["@principal"].Value = principal;
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

        public DataTable get_almacen_x_id(string id)
        {
            string sql = " SELECT S.iidAlmacen, S.iidEmpresa, S.vchNombre, S.vchDomicilio, " +
                         " S.vchNumExt, S.vchNumInt, S.vchColonia, S.vchLocalidad,  " +
                         " S.vchCP, S.vchMunicipio, S.vchCorreo, S.vchTelefono,  " +
                         " S.iidEstado, S.iidEstatus, S.dfechain, S.dfechaup, S.siPrincipal, " +
                         " S.iidUsuario, E.vchNombre Estado, P.vchNombre Pais  " +
                         " FROM catAlmacenes (NOLOCK)  S, catEstados E, catPaises P " + 
                         " where iidAlmacen =  " + id +
                         " AND E.iidEstado = S.iidEstado " + 
                         " AND P.iidPais = E.iidPais ";
            return Conexion.Consultasql(sql);
        }

        public bool borrar_almacen(string id)
        {
            string sql = " update catAlmacenes set iidEstatus= 2" +
                         " WHERE  iidAlmacen =" + id;
            return Conexion.InsertaSql(sql);
        }

        public DataTable getAlmacenesOnlyNot(string id) {
            string sql = " SELECT 0 AS id, 'Seleccionar' AS nombre " +
                        " UNION ALL " +
                        " SELECT iidAlmacen AS id, vchNombre AS nombre " +
                        " FROM catAlmacenes " +
                        " WHERE iidEstatus = 1 " +
                        " AND iidAlmacen not in (" + id + ") ";
            return Conexion.Consultasql(sql);
        }
        public DataTable getAlmacenesAll()
        {

            string sql = " SELECT 0 AS id, 'Seleccionar' AS nombre " +
                         " UNION ALL " +
                         " SELECT iidAlmacen AS id, vchNombre AS nombre " +
                         " FROM catAlmacenes " +
                         " WHERE iidEstatus = 1 ";

            return Conexion.Consultasql(sql);
        }

        public bool existe_almacen()
        {
            string sql = "SELECT iidAlmacen FROM catAlmacenes WHERE siPrincipal = 1";

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

        public bool modifica_almacen_principal()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catAlmacenes SET siPrincipal = 0 ";

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

        public string id_almacen_principal() 
        {
            DataTable dt = new DataTable();
            string sql = "SELECT TOP 1 iidAlmacen FROM catAlmacenes WHERE siPrincipal = 1 ";
            try
            {

                dt = Conexion.Consultasql(sql);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return row["iidAlmacen"].ToString();
                }
                else {
                    return "";
                }

            }
            catch
            {
                return "";
            }
        }
    }
}
