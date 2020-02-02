using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Facturas
{
    class Class_Series
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = " SELECT iidSerie, iidEmpresa, dfechain , dfechaup , vchNombre , vchSerie, iFolio,  " +
            " vchCalle, vchNumExt , vchNumInt, vchColonia, vchCP, vchMunicipio, iidEstado, iidEstatus, iidUsuario " +
            " FROM catSeries (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public bool EliminaRegistro(string id)
        {
            string sql = " UPDATE catSeries SET iidEstatus= 2, dfechaup = GETDATE()  WHERE  iidSerie=" + id;
            return Conexion.InsertaSql(sql);
        }
        
        public bool InsertaInformacion(string Alias,string Ser, string Fol, string Calle, string NumExt, string NumInt, string Col, string Mun, string CP, string Edo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string sql = "INSERT INTO catSeries  " +
                " (iidEmpresa, dfechain , dfechaup , vchNombre , vchSerie, iFolio, SiFrontera, " +
                  " vchCalle, vchNumExt , vchNumInt, vchColonia, vchCP, vchMunicipio, iidEstado, iidEstatus, iidUsuario ) " +
                    " values " +
                " (@empresa, GETDATE(), GETDATE(), @vchnombre,  @vchserie, @ifolio , 0," +
                " @vchcalle, @vchnumext, @vchnumint, @vchcolonia, @vchcp, @vchmunicipio, @iidEstado, 1, @iidUsuario )";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@empresa", SqlDbType.Int);
            cmd.Parameters.Add("@vchnombre", SqlDbType.Char);
            cmd.Parameters.Add("@vchserie", SqlDbType.Char);
            cmd.Parameters.Add("@ifolio", SqlDbType.Int);
            cmd.Parameters.Add("@vchcalle", SqlDbType.Char);
            cmd.Parameters.Add("@vchnumext", SqlDbType.Char);
            cmd.Parameters.Add("@vchnumint", SqlDbType.Char);
            cmd.Parameters.Add("@vchcolonia", SqlDbType.Char);
            cmd.Parameters.Add("@vchcp", SqlDbType.Char);
            cmd.Parameters.Add("@vchmunicipio", SqlDbType.Char);
            cmd.Parameters.Add("@iidEstado", SqlDbType.Int);
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters["@empresa"].Value = Classes.Class_Session.IDEMPRESA.ToString();
            cmd.Parameters["@vchnombre"].Value = Alias;
            cmd.Parameters["@vchserie"].Value = Ser;
            cmd.Parameters["@ifolio"].Value = Fol;
            cmd.Parameters["@vchcalle"].Value = Calle;
            cmd.Parameters["@vchnumext"].Value = NumExt;
            cmd.Parameters["@vchnumint"].Value = NumInt;
            cmd.Parameters["@vchcolonia"].Value = Col;
            cmd.Parameters["@vchcp"].Value = CP;
            cmd.Parameters["@vchmunicipio"].Value = Mun;
            cmd.Parameters["@iidEstado"].Value = Edo;
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario.ToString();
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

        public bool ActualizaInformacion(string Alias, string Ser, string Fol, string Calle, string NumExt, string NumInt, string Col, string Mun, string CP, string Edo, string Id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string sql = "UPDATE catSeries SET " +
                  " dfechaup = GETDATE() , vchNombre = @vchnombre, vchSerie = @vchserie, iFolio = @ifolio, " +
                  " vchCalle = @vchcalle, vchNumExt= @vchnumext , vchNumInt = @vchnumint, vchColonia = @vchcolonia, " +
                  " vchCP = @vchcp, vchMunicipio = @vchmunicipio, iidEstado = @iidEstado,  iidUsuario = '" + usuariolog + "'  " +
                  " WHERE iidSerie = " + Id;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@empresa", SqlDbType.Int);
            cmd.Parameters.Add("@vchnombre", SqlDbType.Char);
            cmd.Parameters.Add("@vchserie", SqlDbType.Char);
            cmd.Parameters.Add("@ifolio", SqlDbType.Int);
            cmd.Parameters.Add("@vchcalle", SqlDbType.Char);
            cmd.Parameters.Add("@vchnumext", SqlDbType.Char);
            cmd.Parameters.Add("@vchnumint", SqlDbType.Char);
            cmd.Parameters.Add("@vchcolonia", SqlDbType.Char);
            cmd.Parameters.Add("@vchcp", SqlDbType.Char);
            cmd.Parameters.Add("@vchmunicipio", SqlDbType.Char);
            cmd.Parameters.Add("@iidEstado", SqlDbType.Int);
            cmd.Parameters.Add("@iidUsuario", SqlDbType.Int);
            cmd.Parameters["@empresa"].Value = Classes.Class_Session.IDEMPRESA.ToString();
            cmd.Parameters["@vchnombre"].Value = Alias;
            cmd.Parameters["@vchserie"].Value = Ser;
            cmd.Parameters["@ifolio"].Value = Fol;
            cmd.Parameters["@vchcalle"].Value = Calle;
            cmd.Parameters["@vchnumext"].Value = NumExt;
            cmd.Parameters["@vchnumint"].Value = NumInt;
            cmd.Parameters["@vchcolonia"].Value = Col;
            cmd.Parameters["@vchcp"].Value = CP;
            cmd.Parameters["@vchmunicipio"].Value = Mun;
            cmd.Parameters["@iidEstado"].Value = Edo;
            cmd.Parameters["@iidUsuario"].Value = Classes.Class_Session.Idusuario.ToString();
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
        /*
         public DataTable getSeries(string empresa)
         {
             string sql = "SELECT *  FROM catSeries (NOLOCK) WHERE iidEstatus = 1 AND iidEmpresa= " + empresa;
             return Conexion.Consultasql(sql);
         }
         public DataTable getInfoByID(string id)
         {
             string sql = " SELECT S.iidSerie, S.iidEmpresa, S.vchNombre, S.vchSerie, S.iFolio, " +
                          " S.vchCalle, S.vchNumExt, S.vchNumInt, S.vchColonia, S.vchLocalidad, S.vchCP, S.vchMunicipio, " +
                          " S.vchCorreo, S.vchTelefono, S.iidEstado, S.iidEstatus, " +
                          " S.dfechain, S.dfechaup, S.iidUsuario, S.SiEnviado, S.SiFiscal, " +
                          " E.vchNombre Estado, P.vchNombre Pais " +
                          " FROM catSeries (NOLOCK)  S, catEstados E, catPaises P " +
                          " where iidSerie = " + id +
                          " AND E.iidEstado = S.iidEstado " +
                          " AND P.iidPais = E.iidPais ";
             return Conexion.Consultasql(sql);
         }
         public bool deleteId(string id)
         {
             string sql = "DELETE FROM catSeries   where iidSerie= " + id;
             return Conexion.InsertaSql(sql);
         }

        

         public DataTable getInfoExpedido(string id)
         {
             string sql = "SELECT S.iidSerie, S.iidEmpresa, S.vchNombre, S.vchSerie, S.iFolio, " +
                 " S.vchCalle, S.vchNumExt, S.vchNumInt, S.vchColonia, " +
                 " S.vchCP, S.vchMunicipio, S.iidEstado, S.SiFrontera, S.iidEstatus, " +
                 " S.dfechain, S.dfechaup, S.iidUsuario, S.SiEnviado, " +
                 " EDO.vchNombre as Estado, P.vchNombre as Pais, " +
                 " S.vchLocalidad, S.vchCorreo, S.vchTelefono " +
                 " FROM catSeries S (NOLOCK), catEstados EDO (NOLOCK), catPaises P (NOLOCK) " +
                 " WHERE S.iidEstado = EDO.iidEstado " +
                 " AND EDO.iidPais = P.iidPais " +
                 " AND S.iidSerie = " + id;
             return Conexion.Consultasql(sql);
         }
         ///////////////validaciones***********************************
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
                             case "textBox_nombre":
                                 if (string.IsNullOrEmpty(control.Text))
                                 {
                                     cadena += "* Alias Sucursal " + Environment.NewLine;
                                     errores++;
                                 }
                                 break;

                             case "textBox_serie":
                                 if (string.IsNullOrEmpty(control.Text))
                                 {
                                     cadena += "* Numero de Serie" + Environment.NewLine;
                                     errores++;
                                 }
                                 break;
                             case "textBox_folio":
                                 if (string.IsNullOrEmpty(control.Text))
                                 {
                                     cadena += "* Numero de Folio " + Environment.NewLine;
                                     errores++;
                                 }
                                 break;
                             case "textBox_calle":
                                 if (string.IsNullOrEmpty(control.Text))
                                 {
                                     cadena += "* Domicilo " + Environment.NewLine;
                                     errores++;
                                 }
                                 break;
                             case "textBox_numext":
                                 if (string.IsNullOrEmpty(control.Text))
                                 {
                                     cadena += "* Numero Exterior" + Environment.NewLine;
                                     errores++;
                                 }
                                 break;
                             case "textBox_municipio":
                                 if (string.IsNullOrEmpty(control.Text))
                                 {
                                     cadena += "* Municipio " + Environment.NewLine;
                                     errores++;
                                 }
                                 break;
                             case "textBox_cp":
                                 if (string.IsNullOrEmpty(control.Text))
                                 {
                                     cadena += "* C.P. " + Environment.NewLine;
                                     errores++;
                                 }
                                 break;
                             case "textBox_colonia":
                                 if (string.IsNullOrEmpty(control.Text))
                                 {
                                     cadena += "* Colonia " + Environment.NewLine;
                                     errores++;
                                 }
                                 break;
                             case "comboBox_estado":
                                 if (string.IsNullOrEmpty(control.Text))
                                 {
                                     cadena += "* Estado " + Environment.NewLine;
                                     errores++;
                                 }
                                 break;
                             case "comboBox_Frontera":
                                 if (string.IsNullOrEmpty(control.Text))
                                 {
                                     cadena += "* Frontera " + Environment.NewLine;
                                     errores++;
                                 }
                                 break;
                             case "comboBox_Fiscal":
                                 if (string.IsNullOrEmpty(control.Text))
                                 {
                                     cadena += "* Fiscal " + Environment.NewLine;
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

         public string getMeSerieChar(string serie)
         {
             string empresa = Classes.Class_Session.IDEMPRESA.ToString();
             DataTable dt = new DataTable();
             string sql = "SELECT iFolio, vchSerie FROM catSeries (NOLOCK) WHERE iidEmpresa = " + empresa + " AND iidSerie = " + serie + " AND iidEstatus = 1 ";
             dt = Conexion.Consultasql(sql);
             DataRow dr = dt.Rows[0];

             return dr["vchSerie"].ToString();
         }

         public DataTable GetSeriesAll(string empresa)
         {
             DataTable dt = new DataTable();
             string sql = "SELECT 0 as id, 'Todos' as nombre UNION ALL  SELECT iidSerie as id, vchNombre as nombre	 FROM  catseries (NOLOCK)   WHERE iidEstatus = 1  and iidempresa=" + empresa;
             dt = Conexion.Consultasql(sql);
             return dt;
         }*/
    }
}
