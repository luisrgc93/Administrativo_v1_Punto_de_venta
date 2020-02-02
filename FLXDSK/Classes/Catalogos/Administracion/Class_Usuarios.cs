using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Catalogos.Administracion
{
    class Class_Usuarios
    {
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();

        public bool InsertaInformacion(DataTable Info)
        {
            DataRow row = Info.Rows[0];
            string puesto = row["puesto"].ToString();
            string usuario = row["usuario"].ToString();
            string clave = row["clave"].ToString();
            string nombre = row["nombre"].ToString();
            string calle = row["calle"].ToString();            
            string colonia = row["colonia"].ToString();
            string estado = row["estado"].ToString();
            string cp = row["cp"].ToString();
            string municipio = row["municipio"].ToString();
            string correo = row["correo"].ToString();
            string telefono = row["telefono"].ToString();
            string idsEmpresas = row["idsEmpresas"].ToString();
            string idRol = row["idRol"].ToString();
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();
            string sql = "INSERT INTO catUsuarios " +
                " (iidPuesto, vchUsuario, vchClave, vchCorreo,vchNombre, vchDomicilio, vchColonia, iidEstado, vchCP, vchTelefono, vchCiudad, " +
                                 " iidEstatus, dfechain, dfechaup, iidUsuariolog, SiEnviado, iidRol )" +
                                 " VALUES " +
                " (@puesto, @usuario, @clave, @correo, @nombre, @domicilio, @colonia, @estado, @cp, @telefono, @ciudad, " +
                " 1,  GETDATE(), GETDATE(),  @usuariolog, 0, @idRol )";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@puesto", SqlDbType.Int);
            cmd.Parameters.Add("@usuario", SqlDbType.Text);
            cmd.Parameters.Add("@clave", SqlDbType.Text);
            cmd.Parameters.Add("@correo", SqlDbType.Text);
            cmd.Parameters.Add("@nombre", SqlDbType.Text);
            cmd.Parameters.Add("@domicilio", SqlDbType.Text);
            cmd.Parameters.Add("@colonia", SqlDbType.Text);
            cmd.Parameters.Add("@estado", SqlDbType.Int);
            cmd.Parameters.Add("@cp", SqlDbType.Text);
            cmd.Parameters.Add("@telefono", SqlDbType.Text);
            cmd.Parameters.Add("@ciudad", SqlDbType.Text);
            cmd.Parameters.Add("@usuariolog", SqlDbType.Int);
            cmd.Parameters.Add("@idRol", SqlDbType.Int);
            cmd.Parameters["@puesto"].Value = puesto;
            cmd.Parameters["@usuario"].Value = usuario;
            cmd.Parameters["@clave"].Value = clave;
            cmd.Parameters["@correo"].Value = correo;
            cmd.Parameters["@nombre"].Value = nombre;
            cmd.Parameters["@domicilio"].Value = calle;
            cmd.Parameters["@colonia"].Value = colonia;
            cmd.Parameters["@estado"].Value = estado;
            cmd.Parameters["@cp"].Value = cp;
            cmd.Parameters["@telefono"].Value = telefono;
            cmd.Parameters["@ciudad"].Value = municipio;            
            cmd.Parameters["@usuariolog"].Value = usuariolog;
            cmd.Parameters["@idRol"].Value = idRol;
            try
            {
                cmd.ExecuteNonQuery();
                string idusuario = getIDUsuarioInsertado(usuario);
                InsertaAccesosUsuario(idusuario, idsEmpresas);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public string getIDUsuarioInsertado(string usuarioName) {
            string sql = " SELECT top 1  iidUsuario FROM catUsuarios (NOLOCK)  WHERE vchUsuario = '" + usuarioName + "' order by dfechain DESC  ";
            DataTable dt = new DataTable();
            dt = conx.Consultasql(sql);
            DataRow Rw = dt.Rows[0];
            return Rw["iidUsuario"].ToString();
        }
        public bool InsertaAccesosUsuario(string usuario, string acceso) {
            if (acceso != "")
            {
                string sql = "";
                if (ExisteAccesoEmpresa(usuario))
                    sql = " UPDATE AccesoEmpresa SET  iidAccesos = '" + acceso + "' WHERE iidUsuario = '" + usuario + "' ";
                else
                    sql = " INSERT INTO AccesoEmpresa (iidUsuario, iidAccesos,dfechain, dfechaup,iidUsuarioLog,SiEnviado )VALUES(" + usuario + ",'" + acceso + "',GETDATE(),GETDATE(),1,0) ";

                return conx.InsertaSql(sql);
            }
            else return true;

        }
        public bool ExisteAccesoEmpresa(string usuario) {
            string sql = "SELECT iidUsuario FROM AccesoEmpresa (NOLOCK) WHERE iidUsuario = '" + usuario + "' ";
            int numero = conx.NumeroFilas(sql);
            if (numero == 0) return false;
            else return true;
        }
        public bool ActualizaInformacion(DataTable Info, string id)
        {
            DataRow row = Info.Rows[0];
            string puesto = row["puesto"].ToString();
            string usuario = row["usuario"].ToString();
            string clave = row["clave"].ToString();
            string nombre = row["nombre"].ToString();
            string calle = row["calle"].ToString();
            string colonia = row["colonia"].ToString();
            string estado = row["estado"].ToString();
            string cp = row["cp"].ToString();
            string municipio = row["municipio"].ToString();
            string correo = row["correo"].ToString();
            string telefono = row["telefono"].ToString();
            string idsEmpresas = row["idsEmpresas"].ToString();
            string idRol = row["idRol"].ToString();
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string sql = "UPDATE catUsuarios SET " +
                " iidPuesto = @puesto, vchUsuario =@usuario, vchClave =  @clave, vchCorreo = @correo, vchNombre=@nombre, "+
                " vchDomicilio=@domicilio, vchColonia=@colonia, iidEstado=@estado, vchCP=@cp, vchTelefono=@telefono, vchCiudad=@ciudad, " +
                                 " dfechaup = getdate(), iidUsuariolog = @usuariolog, SiEnviado = 0, iidRol = @idRol  " +
                                 " WHERE iidUsuario =  " + id;

            cmd.CommandText = sql;
            cmd.Parameters.Add("@puesto", SqlDbType.Int);
            cmd.Parameters.Add("@usuario", SqlDbType.Text);
            cmd.Parameters.Add("@clave", SqlDbType.Text);
            cmd.Parameters.Add("@correo", SqlDbType.Text);
            cmd.Parameters.Add("@nombre", SqlDbType.Text);
            cmd.Parameters.Add("@domicilio", SqlDbType.Text);
            cmd.Parameters.Add("@colonia", SqlDbType.Text);
            cmd.Parameters.Add("@estado", SqlDbType.Int);
            cmd.Parameters.Add("@cp", SqlDbType.Text);
            cmd.Parameters.Add("@telefono", SqlDbType.Text);
            cmd.Parameters.Add("@ciudad", SqlDbType.Text);
            cmd.Parameters.Add("@usuariolog", SqlDbType.Int);
            cmd.Parameters.Add("@idRol", SqlDbType.Int);
            cmd.Parameters["@puesto"].Value = puesto;
            cmd.Parameters["@usuario"].Value = usuario;
            cmd.Parameters["@clave"].Value = clave;
            cmd.Parameters["@correo"].Value = correo;
            cmd.Parameters["@nombre"].Value = nombre;
            cmd.Parameters["@domicilio"].Value = calle;
            cmd.Parameters["@colonia"].Value = colonia;
            cmd.Parameters["@estado"].Value = estado;
            cmd.Parameters["@cp"].Value = cp;
            cmd.Parameters["@telefono"].Value = telefono;
            cmd.Parameters["@ciudad"].Value = municipio;
            cmd.Parameters["@usuariolog"].Value = usuariolog;
            cmd.Parameters["@idRol"].Value = idRol;
            try
            {
                cmd.ExecuteNonQuery();
                InsertaAccesosUsuario(id, idsEmpresas);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ExisteUnoUsuario(string usuario)
        {
            string sql = "SELECT iidUsuario FROM catUsuarios (NOLOCK) WHERE vchUsuario = '" + usuario + "' AND iidEstatus in(0,1) ";
           int numero = conx.NumeroFilas(sql);
           if (numero == 0)
           {
               return false;
           }
           else {
               return true;
           }
        }
        public bool ExisteDosUsuario(string usuario,string id)
        {
            string sql = "SELECT iidUsuario FROM catUsuarios (NOLOCK) WHERE vchUsuario = '" + usuario + "' AND iidUsuario <>" + id + "  AND iidEstatus in(0,1) ";
            int numero = conx.NumeroFilas(sql);
            if (numero == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public DataTable getUsuarios(string filtro)
        {
            string sql = "SELECT U.iidUsuario, U.vchUsuario, U.vchClave, U.vchCorreo, U.vchNombre,  " +
                        " U.vchDomiclio, U.vchColonia, U.vchCP, U.vchTelefono,  " +
                        " U.vchMunicipio, I.iidEstado, U.vchCorreo, U.vchTelefono, U.vchCP,  " +
                        " U.vchCiudad, U.iidEstatus, U.dfechain, U.dfechaup, E.vchestado, P.vchNombre as Puesto  " +
                        "FROM catUsuarios U (NOLOCK), catestados E (NOLOCK), catPuestos P (NOLOCK)  " +
                        "WHERE U.iidestado = E.iidestado AND P.iidPuesto = U.iidPuesto   " + filtro;
            return conx.Consultasql(sql);
        }

        public DataTable getUsuarios()
        {
            string sql = "SELECT iidUsuario, iidPuesto,vchUsuario,vchClave,vchNombre,vchDomicilio,vchColonia, "+
                         " iidEstado,vchCP,vchTelefono,vchCiudad, iidEstatus " +
                         " FROM catusuarios (NOLOCK) " +
                         " WHERE iidEstatus=1";
            return conx.Consultasql(sql);
        }

        public DataTable getInfoByID(string id)
        {
            string sql = " " +
                " SELECT * " +
                " FROM catUsuarios U (NOLOCK) " +
                " WHERE iidUsuario = " + id;
            return conx.Consultasql(sql);
        }
        public string getAccesosUsuario(string usuario){
            string sql = " SELECT iidAccesos FROM AccesoEmpresa (NOLOCK) WHERE iidUsuario = '" + usuario + "'   ";
            DataTable dtInf = new DataTable();
            dtInf = conx.Consultasql(sql);
            string accesos = "";
            try
            {
                DataRow Drw = dtInf.Rows[0];
                accesos = Drw["iidAccesos"].ToString();
            }catch
            {}
            return accesos;
        }
        public string getNameUsuarioId(string usuario)
        {
            string sql = " SELECT vchUsuario FROM catUsuarios (NOLOCK) WHERE iidUsuario = '" + usuario + "'   ";
            DataTable dtInf = new DataTable();
            dtInf = conx.Consultasql(sql);
            if(dtInf.Rows.Count  > 0){
                return dtInf.Rows[0]["vchUsuario"].ToString();
            }else { return ""; }
        }
        public bool deleteId(string id)
        {
            string sql = "DELETE FROM catUsuarios   where iidUsuario = " + id;
            return conx.InsertaSql(sql);
        }

        public bool deleteUsuario(string id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string sql = " UPDATE catUsuarios SET iidEstatus=2 " +
                         " WHERE iidUsuario=" + id;
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

        //Validamos que se hayan ingresado los datos
        public bool validar(Control text)
        {
            Boolean activo = false;
            String cadena = "Ingrese los siguientes campos:" + Environment.NewLine;
            int errores = 0;

            foreach (Control ctrl in text.Controls)
            {
                if (ctrl is Panel)
                {
                    foreach (Control control in ((Panel)ctrl).Controls)
                    {
                        //identificamos el Componente
                        string nombre = control.Name;
                        switch (nombre)
                        {
                            case "textBox_Nombre":
                                if (string.IsNullOrEmpty(control.Text))
                                {
                                    cadena += "* Nombre requerido " + Environment.NewLine;
                                    errores++;
                                }
                                break;
                            case "textBox_Usuario":
                                if (string.IsNullOrEmpty(control.Text))
                                {
                                    cadena += "* Usuario" + Environment.NewLine;
                                    errores++;
                                }
                                break;

                            case "textBox_Clave1":
                                if (string.IsNullOrEmpty(control.Text))
                                {
                                    cadena += "* Clave" + Environment.NewLine;
                                    errores++;
                                }
                                break;
                            case "textBox_Clave2":
                                if (string.IsNullOrEmpty(control.Text))
                                {
                                    cadena += "* Clave 2" + Environment.NewLine;
                                    errores++;
                                }
                                break;
                           
                        }
                    }
                }
            }

            if (errores != 0)
            {
                MessageBox.Show(cadena);
            }
            else
            {
                activo = true;
            }


            return activo;
        }//-->
    }
}
