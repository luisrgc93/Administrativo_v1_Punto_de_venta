using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

using System.Text.RegularExpressions;namespace FLXDSK.Classes
{
    class Class_Clientes
    {
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();
        Class_Validaciones ClsValida = new Class_Validaciones();


        public bool validarCorreoNOexista(string correo, string idcliente)
        {
            string sql = "";
            if(idcliente=="")
                sql = "select iidCliente from catClientes where vchCorreo = '" + correo + "' AND iidEstatus = 1 ";
            else
                sql = "select iidCliente from catClientes where vchCorreo = '" + correo + "' AND iidcliente not in (" + idcliente + ") AND iidEstatus = 1  "; 


            int numero = conx.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else
                return false;
        }

        public bool InsertaInformacion(DataTable Info)
        {
            DataRow row = Info.Rows[0];
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            string alias = row["alias"].ToString();
            string razon = row["razon"].ToString();
            string rfc = row["rfc"].ToString();
            string calle = row["calle"].ToString();
            string tipo = row["tipo"].ToString();
            string numext = row["numext"].ToString();
            string numint = row["numint"].ToString();
            string colonia = row["colonia"].ToString();
            string localidad = row["localidad"].ToString();
            string cp = row["cp"].ToString();
            string municipio = row["municipio"].ToString();
            string pais = row["pais"].ToString();
            string estado = row["estado"].ToString();
            string correo = row["correo"].ToString();
            string telefono = row["telefono"].ToString();
            string contacto = row["contacto"].ToString();
            string activo = "1";
            string usuariolog = Classes.Class_Session.Idusuario.ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();
            string sql = " INSERT INTO catClientes " +
                         " (iidEmpresa, vchAlias, vchTipo, vchRFC, vchRazon, vchCalle, vchNumExt, vchNumInt, " +
                         " vchColonia, vchLocalidad, vchMunIcipio, iidEstado,vchCorreo, vchTelefono, vchCP,  " +
                         " vchNombreContacto, dFechaIn, dFechaUp, iidEstatus, iidUsuario, SiEnviado, iidPais)  " +
                         " VALUES  " +
                         " (@empresa,@vchalias, '', @vchrfc, @vchrazon, @vchdomicilio, @vchnumext, @vchnumint, " +
                         " @vchcolonia, @vchlocalidad, @vchmunicipio, @iidestado, @vchcorreo, @vchtelefono, @vchcp, " +
                         " @chnombrecontacto, GETDATE(), GETDATE(),1, @iidUsuario, 0, @iidpais) ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@empresa", SqlDbType.Int);
            cmd.Parameters.Add("@vchalias", SqlDbType.Text);
            cmd.Parameters.Add("@vchtipo", SqlDbType.Text);
            cmd.Parameters.Add("@vchrfc", SqlDbType.Text);
            cmd.Parameters.Add("@vchrazon", SqlDbType.Text);
            cmd.Parameters.Add("@vchdomicilio", SqlDbType.Text);
            cmd.Parameters.Add("@vchnumext", SqlDbType.Text);
            cmd.Parameters.Add("@vchnumint", SqlDbType.Text);
            cmd.Parameters.Add("@vchcolonia", SqlDbType.Text);
            cmd.Parameters.Add("@vchlocalidad", SqlDbType.Text);
            cmd.Parameters.Add("@vchmunicipio", SqlDbType.Text);
            cmd.Parameters.Add("@iidpais", SqlDbType.Int);
            cmd.Parameters.Add("@iidestado", SqlDbType.Int);
            cmd.Parameters.Add("@vchcorreo", SqlDbType.Text);
            cmd.Parameters.Add("@vchtelefono", SqlDbType.Text);
            cmd.Parameters.Add("@vchcp", SqlDbType.Text);
            cmd.Parameters.Add("@chnombrecontacto", SqlDbType.Text);
            cmd.Parameters.Add("@siactivo", SqlDbType.SmallInt);
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters["@empresa"].Value = empresa;
            cmd.Parameters["@vchalias"].Value = alias;
            cmd.Parameters["@vchtipo"].Value = tipo;
            cmd.Parameters["@vchrfc"].Value = rfc;
            cmd.Parameters["@vchrazon"].Value = razon;
            cmd.Parameters["@vchdomicilio"].Value = calle;
            cmd.Parameters["@vchnumext"].Value = numext;
            cmd.Parameters["@vchnumint"].Value = numint;
            cmd.Parameters["@vchcolonia"].Value = colonia;
            cmd.Parameters["@vchlocalidad"].Value = localidad;
            cmd.Parameters["@vchmunicipio"].Value = municipio;
            cmd.Parameters["@iidpais"].Value = pais;
            cmd.Parameters["@iidestado"].Value = estado;
            cmd.Parameters["@vchcorreo"].Value = correo;
            cmd.Parameters["@vchtelefono"].Value = telefono;
            cmd.Parameters["@vchcp"].Value = cp;
            cmd.Parameters["@chnombrecontacto"].Value = contacto;
            cmd.Parameters["@siactivo"].Value = activo;
            cmd.Parameters["@iidUsuario"].Value = usuariolog;

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
                row_Excepcion["vchLugar"] = "Class_Clientes";
                row_Excepcion["vchAccion"] = "Guardar Cliente";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public bool ActualizaInformacion(DataTable Info, string id)
        {
            DataRow row = Info.Rows[0];
           
            string empresa = row["empresa"].ToString();
            string alias = row["alias"].ToString();
            string razon = row["razon"].ToString();
            string rfc = row["rfc"].ToString();
            string calle = row["calle"].ToString();
            string tipo = row["tipo"].ToString();
            string numext = row["numext"].ToString();
            string numint = row["numint"].ToString();
            string colonia = row["colonia"].ToString();
            string localidad = row["localidad"].ToString();
            string cp = row["cp"].ToString();
            string municipio = row["municipio"].ToString();
            string estado = row["estado"].ToString();
            string pais = row["pais"].ToString();
            string correo = row["correo"].ToString();
            string telefono = row["telefono"].ToString();
            string contacto = row["contacto"].ToString();

            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string sql = " UPDATE catClientes SET " +
                " iidEmpresa = @idempresa, vchAlias = @vchalias, vchTipo = @vchtipo, vchRFC = @vchrfc, vchRazon = @vchrazon, vchCalle = @vchdomicilio, vchNumExt = @vchnumext, " +
                " vchNumInt = @vchnumint, vchColonia =@vchcolonia, vchLocalidad = @vchlocalidad, vchMunicipio = @vchmunicipio, " +
                " iidEstado = @iidestado, iidPais = @iidPais, vchCorreo =  @vchcorreo, vchTelefono = @vchtelefono, vchCP = @vchcp, " +
                " vchNombreContacto = @chnombrecontacto,  dfechaup = GETDATE(), iidUsuario = @iidUsuario " +
            " WHERE iidcliente =  " + id;

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idempresa", SqlDbType.Int);
            cmd.Parameters.Add("@vchalias", SqlDbType.Text);
            cmd.Parameters.Add("@vchtipo", SqlDbType.Text);
            cmd.Parameters.Add("@vchrfc", SqlDbType.Text);
            cmd.Parameters.Add("@vchrazon", SqlDbType.Text);
            cmd.Parameters.Add("@vchdomicilio", SqlDbType.Text);
            cmd.Parameters.Add("@vchnumext", SqlDbType.Text);
            cmd.Parameters.Add("@vchnumint", SqlDbType.Text);
            cmd.Parameters.Add("@vchcolonia", SqlDbType.Text);
            cmd.Parameters.Add("@vchlocalidad", SqlDbType.Text);
            cmd.Parameters.Add("@vchmunicipio", SqlDbType.Text);
            cmd.Parameters.Add("@iidestado", SqlDbType.Int);
            cmd.Parameters.Add("@iidPais", SqlDbType.Int);
            cmd.Parameters.Add("@vchcorreo", SqlDbType.Text);
            cmd.Parameters.Add("@vchtelefono", SqlDbType.Text);
            cmd.Parameters.Add("@vchcp", SqlDbType.Text);
            cmd.Parameters.Add("@chnombrecontacto", SqlDbType.Text);
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);

            cmd.Parameters["@idempresa"].Value = empresa;
            cmd.Parameters["@vchalias"].Value = alias;
            cmd.Parameters["@vchtipo"].Value = tipo;
            cmd.Parameters["@vchrfc"].Value = rfc;
            cmd.Parameters["@vchrazon"].Value = razon;
            cmd.Parameters["@vchdomicilio"].Value = calle;
            cmd.Parameters["@vchnumext"].Value = numext;
            cmd.Parameters["@vchnumint"].Value = numint;
            cmd.Parameters["@vchcolonia"].Value = colonia;
            cmd.Parameters["@vchlocalidad"].Value = localidad;
            cmd.Parameters["@vchmunicipio"].Value = municipio;
            cmd.Parameters["@iidestado"].Value = estado;
            cmd.Parameters["@iidPais"].Value = pais;
            cmd.Parameters["@vchcorreo"].Value = correo;
            cmd.Parameters["@vchtelefono"].Value = telefono;
            cmd.Parameters["@vchcp"].Value = cp;
            cmd.Parameters["@chnombrecontacto"].Value = contacto;
            cmd.Parameters["@iidUsuario"].Value = usuariolog;
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
                row_Excepcion["vchLugar"] = "Class_Clientes";
                row_Excepcion["vchAccion"] = "Actualizar Cliente";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public DataTable getClientes(string filtro)
        {
            string sql = " SELECT C.iidCliente, vchAlias, vchTipo, vchRFC, vchRazon,  " +
                "vchCalle, vchNumExt, vchNumInt, vchColonia, vchLocalidad,  " +
                "vchMunicipio, C.iidEstado, vchCorreo, vchTelefono, vchCP, vchNombreContacto,  " +
                "C.dfechain, C.dfechaup, C.iidEstatus, C.iidusuario, vchestado  " +
            "FROM catClientes C (NOLOCK), catestados E (NOLOCK)  " +
            "WHERE C.iidestado = E.iidestado  " + filtro;
            return conx.Consultasql(sql);
        }

        public DataTable getClientesRep(string filtro)
        {
            string sql = "SELECT C.vchAlias, C.vchTipo, C.vchRFC, C.vchRazon, C.vchCalle, C.vchNumExt, " +
                        " C.vchNumInt, C.vchColonia, C.vchLocalidad, C.vchMunicipio, " +
                                 " C.iidEstado, C.vchCorreo, C.vchTelefono, C.vchCP, C.vchNombreContacto, " +
                                 " C.dfechain, C.dfechaup, C.iidEstatus, C.iidUsuario " +
            " FROM catClientes C (NOLOCK), int_satEstados E (NOLOCK) " +
            " WHERE E.iidestado = C.iidEstado " + filtro;
            return conx.Consultasql(sql);
        }

        public DataTable getInfoByID(string id)
        {
            string sql = " " +
                " SELECT C.iidCliente , C.iidEmpresa, C.vchAlias, C.vchRFC, C.vchRazon, " +
                    " C.vchCalle, C.vchNumExt, C.vchNumInt, C.vchColonia, C.vchTipo, " +
                    " C.vchLocalidad, C.vchMunicipio, C.iidEstado, C.vchCorreo, " +
                    " C.vchTelefono, C.vchCP, C.vchNombreContacto, C.dfechain, C.dfechaup, " +
                    " C.iidEstatus, C.iidUsuario, C.SiEnviado, " +
                    " E.vchNombre vchEstado, P.iidPais, " +
                    " P.vchNombre vchPais" +
                " FROM catClientes C (NOLOCK), int_satEstados E (NOLOCK), int_satPaises P (NOLOCK) " +
                " WHERE E.iidEstado = C.iidEstado " +
                " AND E.iidPais = P.iidPais " +
                " AND iidCliente= " + id;

            return conx.Consultasql(sql);
        }

        public bool deleteCliente(string id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conx.ConexionSQL();

            string sql = "UPDATE catClientes SET iidEstatus=2 " +
                         "WHERE iidCliente=" + id;
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
                row_Excepcion["vchLugar"] = "Class_Clientes";
                row_Excepcion["vchAccion"] = "Borrar Cliente (cambiar estatus a 2)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public bool deleteId(string id)
        {
            string sql = "DELETE FROM catClientes  where iidCliente= " + id;
            return conx.InsertaSql(sql);
        }

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
                            case "textBox_alias":
                                if (string.IsNullOrEmpty(control.Text))
                                {
                                    cadena += "* Alias del Cliente" + Environment.NewLine;
                                    errores++;
                                }
                                break;
                            case "textBox_razon":
                                if (string.IsNullOrEmpty(control.Text))
                                {
                                    cadena += "* Razon" + Environment.NewLine;
                                    errores++;
                                }
                                break;
                            case "textBox_rfc":
                                if (string.IsNullOrEmpty(control.Text))
                                {
                                    cadena += "* RFC" + Environment.NewLine;
                                    errores++;
                                }
                                else
                                {
                                    if (!isRFC(control.Text))
                                    {
                                        cadena += "* RFC Incorrecto " + Environment.NewLine;
                                        errores++;
                                    }
                                }
                                break;
                            case "textBox_correo":
                                if (string.IsNullOrEmpty(control.Text))
                                {
                                }
                                else
                                {
                                    if (!ClsValida.validarEmail(control.Text))
                                    {
                                        cadena += "* Correo Incorrecto " + Environment.NewLine;
                                        errores++;
                                    }
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
        }

        public static bool isRFC(string tsInputRFC)
        {
            string lsPatron = @"^[A-ZÑ&]{3,4}[0-9]{2}[0-1][0-9][0-3][0-9][A-Z,0-9][A-Z,0-9][0-9A]$";
            Regex loRE = new Regex(lsPatron);
            if (loRE.IsMatch(tsInputRFC.ToUpper()))
                return true;
            else
                return false;
        }

        public bool validarEmail(string email)
        {
            string expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                { return true; }
                else
                { return false; }
            }
            else
            { return false; }
        }

       /* public bool existeCliente(string RFC) 
        {
        
        }*/
    }
}
