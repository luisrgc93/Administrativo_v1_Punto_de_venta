using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace FLXDSK.Classes.Herramientas
{
    

    class Class_HostMails
    {

        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable GetInfoHostEnvio()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT top 1 vchHost as host, vchPort as puerto, "+
                " vchUsuario usuario, vchClave clave FROM  catConfigMail (NOLOCK)  " +
                " WHERE vchTipo = 'envio' order by dfechain desc ";
            dt = Conexion.Consultasql(sql);
            return dt;
        }
        public DataTable GetInfoHostRecepcion()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT top 1 vchHost as host, vchPort as puerto, " +
                " vchUsuario usuario, vchClave clave FROM  catConfigMail (NOLOCK)  " +
                " WHERE vchTipo = 'recepcion' ";
            dt = Conexion.Consultasql(sql);
            return dt;
        }
        public bool GuardaHOstEnvio(string host, string puerto, string usuario, string clave) {
            if (existeConfig("envio"))
            {
                string sql = "UPDATE catConfigMail  SET  vchHost='" + host + "', vchPort = '" + puerto + "', " +
                      " vchUsuario  = '" + usuario + "', vchClave = '" + clave + "' ," +
                      " dfechaup = GETDATE() " +
                      " WHERE  vchTipo = 'envio' ";
                return Conexion.InsertaSql(sql);
            }
            else
            {
                string sql = "INSERT INTO catConfigMail (vchTipo, vchHost, vchPort, vchUsuario, vchClave ," +
                    " dfechain, dfechaup, SiEnviado ) " +
                    " VALUES ('envio','" + host + "','" + puerto + "','" + usuario + "','" + clave + "', " +
                    " getdate(), getdate(), 0 ) ";
                return Conexion.InsertaSql(sql);
            }
        }
        public bool GuardaHOstRecepcion(string host, string puerto, string usuario, string clave)
        {
            if (existeConfig("recepcion"))
            {
                string sql = "UPDATE catConfigMail  SET  vchHost='" + host + "', vchPort = '" + puerto + "', "+
                      " vchUsuario  = '" + usuario + "', vchClave = '" + clave + "' ," +
                      " dfechaup = GETDATE() " +
                      " WHERE  vchTipo = 'recepcion' ";
                return Conexion.InsertaSql(sql);
            }
            else
            {
                string sql = "INSERT INTO catConfigMail (vchTipo, vchHost, vchPort, vchUsuario, vchClave ," +
                    " dfechain, dfechaup, SiEnviado ) " +
                    " VALUES ('recepcion','" + host + "','" + puerto + "','" + usuario + "','" + clave + "', " +
                    " getdate(), getdate(), 0 ) ";
                return Conexion.InsertaSql(sql);
            }
        }
        public bool existeConfig(string tipo) {
            string sql = "select vchTipo from catConfigMail (nolock) where vchTipo = '"+tipo+"' ";
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0) return true;
            else return false;
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
    }
}
