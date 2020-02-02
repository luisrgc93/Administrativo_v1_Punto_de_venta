using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes
{
    class Class_ConfigNomina
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public bool existeRegistroPercepcion(DataTable Info)
        {
            DataRow row = Info.Rows[0];            
            string idPercepciones = row["idPercepcion"].ToString();           
            string iidPersonal = row["usuario"].ToString();

            string sql = "select iidPercepcion from catPagoNomina where iidPersonal =" + iidPersonal + " and iidPercepcion =" + idPercepciones;
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0) return true; else return false;
        }
        public bool ActualizaInformacionPercepcion(DataTable Info)
        {
            DataRow row = Info.Rows[0];
            string iidEmpresa = Classes.Class_Session.IDEMPRESA.ToString();
            string idPercepciones = row["idPercepcion"].ToString();
            int idDeducciones = 0;
            string montoE = row["fmontoE"].ToString();
            string montoGrava = row["fmontoG"].ToString();
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string iidPersonal = row["usuario"].ToString();

            if (montoE == "") { montoE = "0"; }
            if (montoGrava == "") { montoGrava = "0"; }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql2 = "update catPagoNomina set fMontoG += @montoGrava, fMontoE += @montoE, dfechaUp = GETDATE(), iidUsuario = @usuariolog where iidPersonal =" + iidPersonal + " and iidPercepcion =" + idPercepciones;
            cmd.CommandText = sql2;
            //cmd.Parameters.Add("@dfechaIn", SqlDbType.Int);
            cmd.Parameters.Add("@iidPersonal", SqlDbType.Int).Value = iidPersonal;
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int).Value = iidEmpresa;
            cmd.Parameters.Add("@idPercepcion", SqlDbType.Int).Value = idPercepciones;
            cmd.Parameters.Add("@idDeduccion", SqlDbType.Int).Value = idDeducciones;
            cmd.Parameters.Add("@montoGrava", SqlDbType.Float).Value = montoGrava;
            cmd.Parameters.Add("@montoE", SqlDbType.Float).Value = montoE;
            cmd.Parameters.Add("@usuariolog", SqlDbType.Int).Value = usuariolog;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            //return true;            
        }
        public bool InsertaInformacionPercepcion(DataTable Info)
        {
            DataRow row = Info.Rows[0];
            string iidEmpresa = Classes.Class_Session.IDEMPRESA.ToString();
            string idPercepciones = row["idPercepcion"].ToString();
            int idDeducciones = 0;
            string montoE = row["fmontoE"].ToString();
            string montoGrava = row["fmontoG"].ToString();
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string iidPersonal = row["usuario"].ToString();

            if (montoE == "") { montoE = "0"; }
            if (montoGrava == "") { montoGrava = "0"; }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql2 = "INSERT INTO catPagoNomina " +
                " (iidPersonal, iidEmpresa, iidPercepcion, iidDeduccion, fMontoG, fMontoE, dfechaIn, dfechaUp, iidUsuario)" +
                                 " VALUES " +
                                 " (@iidPersonal, @iidEmpresa, @idPercepcion, @idDeduccion, @montoGrava, @montoE, GETDATE(), GETDATE(), @usuariolog)";            
            cmd.CommandText = sql2;
            //cmd.Parameters.Add("@dfechaIn", SqlDbType.Int);
            cmd.Parameters.Add("@iidPersonal", SqlDbType.Int).Value = iidPersonal;
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int).Value = iidEmpresa;
            cmd.Parameters.Add("@idPercepcion", SqlDbType.Int).Value = idPercepciones;
            cmd.Parameters.Add("@idDeduccion", SqlDbType.Int).Value = idDeducciones;
            cmd.Parameters.Add("@montoGrava", SqlDbType.Float).Value = montoGrava;
            cmd.Parameters.Add("@montoE", SqlDbType.Float).Value = montoE;
            cmd.Parameters.Add("@usuariolog", SqlDbType.Int).Value = usuariolog;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            //return true;            
        }

        public bool existeRegistroDeduccion(DataTable Info)
        {
            DataRow row = Info.Rows[0];
            string idDeducciones = row["idDeduccion"].ToString();
            string iidPersonal = row["usuario"].ToString();

            string sql = "select iidDeduccion from catPagoNomina where iidPersonal =" + iidPersonal + " and iidDeduccion =" + idDeducciones;
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0) return true; else return false;
        }
        public bool ActualizaInformacionDeduccion(DataTable Info)
        {
            DataRow row = Info.Rows[0];
            string iidEmpresa = Classes.Class_Session.IDEMPRESA.ToString();
            string idDeducciones = row["idDeduccion"].ToString();
            int idPercepciones = 0;
            string montoE = row["fmontoE"].ToString();
            string montoGrava = row["fmontoG"].ToString();
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string iidPersonal = row["usuario"].ToString();

            if (montoE == "") { montoE = "0"; }
            if (montoGrava == "") { montoGrava = "0"; }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "update catPagoNomina set fMontoG += @montoGrava, fMontoE += @montoE, dfechaUp = GETDATE(), iidUsuario = @usuariolog where iidPersonal =" + iidPersonal + " and iidDeduccion =" + idDeducciones;
            cmd.CommandText = sql;
            //cmd.Parameters.Add("@dfechaIn", SqlDbType.Int);
            cmd.Parameters.Add("@iidPersonal", SqlDbType.Int).Value = iidPersonal;
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int).Value = iidEmpresa;
            cmd.Parameters.Add("@idPercepcion", SqlDbType.Int).Value = idPercepciones;
            cmd.Parameters.Add("@idDeduccion", SqlDbType.Int).Value = idDeducciones;
            cmd.Parameters.Add("@montoGrava", SqlDbType.Float).Value = montoGrava;
            cmd.Parameters.Add("@montoE", SqlDbType.Float).Value = montoE;
            cmd.Parameters.Add("@usuariolog", SqlDbType.Int).Value = usuariolog;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            //return true;            
        }
        public bool InsertaInformacionDeduccion(DataTable Info)
        {
            DataRow row = Info.Rows[0];
            string iidEmpresa = Classes.Class_Session.IDEMPRESA.ToString();
            string idDeducciones = row["idDeduccion"].ToString();
            int idPercepciones = 0;
            string montoE = row["fmontoE"].ToString();
            string montoGrava = row["fmontoG"].ToString();
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string iidPersonal = row["usuario"].ToString();

            if (montoE == "") { montoE = "0"; }
            if (montoGrava == "") { montoGrava = "0"; }

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "INSERT INTO catPagoNomina " +
                " (iidPersonal, iidEmpresa, iidPercepcion, iidDeduccion, fMontoG, fMontoE, dfechaIn, dfechaUp, iidUsuario)" +
                                 " VALUES " +
                                 " (@iidPersonal, @iidEmpresa, @idPercepcion, @idDeduccion, @montoGrava, @montoE, GETDATE(), GETDATE(), @usuariolog)";
            cmd.CommandText = sql;
            //cmd.Parameters.Add("@dfechaIn", SqlDbType.Int);
            cmd.Parameters.Add("@iidPersonal", SqlDbType.Int).Value = iidPersonal;
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int).Value = iidEmpresa;
            cmd.Parameters.Add("@idPercepcion", SqlDbType.Int).Value = idPercepciones;
            cmd.Parameters.Add("@idDeduccion", SqlDbType.Int).Value = idDeducciones;
            cmd.Parameters.Add("@montoGrava", SqlDbType.Float).Value = montoGrava;
            cmd.Parameters.Add("@montoE", SqlDbType.Float).Value = montoE;
            cmd.Parameters.Add("@usuariolog", SqlDbType.Int).Value = usuariolog;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            //return true;
        }

        public DataTable GetPercepciones()
        {
            DataTable dt = new DataTable();
            string sql = "select iidPerecepcion as id, vchDescripcion as nombre from CatPercepciones where iidEstatus = 1";
            dt = Conexion.Consultasql(sql);
            return dt;
        }

        public DataTable GetDeducciones()
        {
            DataTable dt = new DataTable();
            string sql = "select iidDeducciones as id, vchDescripcion as nombre from CatDeducciones where iidEstatus = 1";
            dt = Conexion.Consultasql(sql);
            return dt;
        }

        public bool InsertaInformacion(DataTable Info)
        {
            DataRow row = Info.Rows[0];
            string iidEmpresa = Classes.Class_Session.IDEMPRESA.ToString();
            string nombre = row["Nombre"].ToString();            
            string relacion = row["Relacion"].ToString();
            string tipo = "";
            if (row["Tipo"].ToString() == "Percepciones") { tipo = "PERCEPCION"; } else { tipo = "DEDUCCION"; }
            string grava = row["Grava"].ToString();
            string siGrava = "";
            if (grava == "SI") {  siGrava = "1"; } else {  siGrava = "0"; }
            string activo = "1";
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = "INSERT INTO catConfiguracionNombreNom " +
                " (iidEmpresa,dfechaIn,dfechaUp,iidUsuario,vchTipo,iid,vchNombre,siGrava,iidEstatus)" +
                                 " VALUES " +
                                 " (@iidEmpresa, GETDATE(), GETDATE(), @usuariolog, @tipo, @relacion, @nombre, @siGrava, @activo)";
            cmd.CommandText = sql;
            //cmd.Parameters.Add("@dfechaIn", SqlDbType.Int);
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int).Value = iidEmpresa;
            cmd.Parameters.Add("@usuariolog", SqlDbType.Int).Value = usuariolog;
            cmd.Parameters.Add("@tipo", SqlDbType.Text).Value = tipo;
            cmd.Parameters.Add("@relacion", SqlDbType.Int).Value = relacion;
            cmd.Parameters.Add("@nombre", SqlDbType.Text).Value = nombre;
            cmd.Parameters.Add("@siGrava", SqlDbType.Int).Value = siGrava;
            cmd.Parameters.Add("@activo", SqlDbType.Int).Value = activo;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            //return true;
        }
        public bool ActualizaInformacion(DataTable Info, string id)
        {
            string activo = "1";
            DataRow Row = Info.Rows[0];
            string nombre = Row["Nombre"].ToString();
            string relacion = Row["Relacion"].ToString();
            string grava = Row["Grava"].ToString();
            string tipo = "";
            if (Row["Tipo"].ToString() == "Percepciones") { tipo = "PERCEPCION"; } else { tipo = "DEDUCCION"; }
            string siGrava = "";
            if (grava == "SI") {  siGrava = "1"; } else {  siGrava = "0"; }
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string iidEmpresa = Classes.Class_Session.IDEMPRESA.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "update catConfiguracionNombreNom set iidEmpresa = @iidEmpresa, dfechaUp = GETDATE(), iidUsuario = @usuariolog , vchTipo = @tipo, iid = @relacion, vchNombre = @nombre, siGrava = @siGrava, iidEstatus = @activo where iidConfigurador  =" + id;            
            cmd.CommandText = sql;
            
            cmd.Parameters.Add("@iidEmpresa", SqlDbType.Int).Value = iidEmpresa;
            cmd.Parameters.Add("@usuariolog", SqlDbType.Int).Value = usuariolog;
            cmd.Parameters.Add("@nombre", SqlDbType.Text).Value = nombre;
            cmd.Parameters.Add("@tipo", SqlDbType.Text).Value = tipo;
            cmd.Parameters.Add("@relacion", SqlDbType.Int).Value = relacion;
            cmd.Parameters.Add("@siGrava", SqlDbType.Int).Value = siGrava;
            cmd.Parameters.Add("@activo", SqlDbType.Int).Value = activo;
            
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

        public DataTable getInfoByID(string id)
        {
            string sql = "SELECT iid, vchTipo, vchNombre, siGrava FROM catConfiguracionNombreNom WHERE iidConfigurador ="+id;
            return Conexion.Consultasql(sql);
        }        

        public bool delete(string id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "update catConfiguracionNombreNom set iidEstatus = 2 where iidConfigurador ="+ id;
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

        public bool deletePercepcionPagoNomina(string idPersona, string idPercepcion)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "delete from catPagoNomina where iidPersonal="+idPersona+" and iidPercepcion="+idPercepcion;
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

        public bool deleteDeduccionPagoNomina(string idPersona, string idDeduccion)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = "delete from catPagoNomina where iidPersonal="+idPersona+" and iidDeduccion="+idDeduccion;
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
