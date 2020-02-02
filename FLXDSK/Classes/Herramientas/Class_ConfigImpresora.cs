using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Herramientas
{
    class Class_ConfigImpresora
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        public bool InsertaConfigPort(string idname, string direccionRed, string port, string baud, string stop, string party, string data, string hands, string rsts, string SiVersionNew)
        {
            int usuario = Classes.Class_Session.Idusuario;
            string sql = "insert into catImpresorasConfig " +
                " (vchDeviceUso, vchDireccionRed, vchPortName, iBaudRate, " +
                " StopBits, Parity, DataBits, siNewVersion, " +
                " Handshake, RtsEnable, dfechaIn, " +
                " dfechaUp, siEnviado, iidUsuario, iidEstatus) values ( " +
                " '" + idname + "','" + direccionRed + "','" + port + "','" + baud + "', " +
                " '" + stop + "','" + party + "','" + data + "','" + SiVersionNew + "', " +
                " '" + hands + "','" + rsts + "', getdate(), " +
                " getdate(),'0', '" + usuario + "', '1'" +
                " )";
            return Conexion.InsertaSql(sql);
        }
        public bool exisIdNamePortconf(string nameid)
        {
            string sql = "select * from catImpresorasConfig where vchDeviceUso = '" + nameid + "' ";
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0) return true; else return false;
        }
        public DataTable getInfoSerialPort(string idImpresora)
        {
            string sql = "SELECT * FROM  catImpresorasConfig where iidPuerto = '" + idImpresora + "' ";
            return Conexion.Consultasql(sql);
        }
        public bool ActualizaConfigPort(string idname, string direccionRed, string port, string baud, string stop, string party, string data, string hands, string rsts, string SiVersionNew)
        {
            int usuario = Classes.Class_Session.Idusuario;
            string sql = "UPDATE catImpresorasConfig set " +
            "  vchPortName = '" + port + "', iBaudRate = '" + baud + "', " +
                " StopBits = '" + stop + "', Parity='" + party + "', DataBits ='" + data + "', " +
                " Handshake = '" + hands + "', RtsEnable = '" + rsts + "',  " +
                " siNewVersion = '" + SiVersionNew + "' " +
                " , dfechaUp = getdate(), iidEstatus = 1, vchDireccionRed = '" + direccionRed + "', siEnviado = 0, iidUsuario = '" + usuario + "' " +
                " where vchDeviceUso = '" + idname + "' ";
            return Conexion.InsertaSql(sql);
        }

        public bool borrar_Impresora(string idImpresora)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catImpresorasConfig SET iidEstatus = 2, dFechaUp = GETDATE() WHERE iidPuerto = " + idImpresora;

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
