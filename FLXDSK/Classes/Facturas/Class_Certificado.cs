using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Facturas
{
    class Class_Certificado
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();


        public DataTable getListaWhere(string filtroWhere)
        {
            string sql="SELECT dfechain,dfechaup, iidEmpresa, vchrutacer,vchrutakey,vchpass, fileCer, fileKey, vchnumcertificado,vchtextcer,iidUsuario, vchPasPc,vchUserPc " +
                " FROM criptoempresa  "+filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public bool InsertaInformacion(DataTable Info, string idempresa)
        {

            DataRow row = Info.Rows[0];
            string NumCertificado = row["vchnumcertificado"].ToString();
            string key = row["vchrutakey"].ToString();
            string pass = row["vchpass"].ToString();
            string cer = row["vchrutacer"].ToString();
            string cerText = row["vchtextcer"].ToString();
            string vchPasPc = row["vchPasPc"].ToString();
            string vchUsrPc = row["vchUsrPc"].ToString();

            byte[] fileCer = (byte[])(row["fileCer"]);
            byte[] fileKey = (byte[])(row["fileKey"]);
            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string sql = "";


            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            DataTable dtExis = getListaWhere(" WHERE iidEmpresa = " + Classes.Class_Session.IDEMPRESA.ToString());
            if (dtExis.Rows.Count > 0)
            {
                sql = " UPDATE  criptoempresa  SET    dfechaup = getdate(), SiEnviado = 0, " +
                        " fileCer = @fileCer, fileKey = @fileKey, " +
                        " vchrutacer = '" + cer + "', vchrutakey = '" + key + "', vchpass = '" + pass + "', " +
                        " vchnumcertificado = '" + NumCertificado + "', vchtextcer = '" + cerText + "'  WHERE iidempresa = " + idempresa;
            }
            else
            {
                sql = " INSERT INTO criptoempresa (dfechain,dfechaup, iidEmpresa, vchrutacer,vchrutakey,vchpass, fileCer, fileKey, vchnumcertificado,vchtextcer,iidUsuario, vchPasPc,vchUserPc ) " +
                                       " VALUES(getdate(),getdate(), '" + idempresa + "', '" + cer + "','" + key + "','" + pass + "',@fileCer,@fileKey,'" + NumCertificado + "','" + cerText + "','" + usuariolog + "','" + vchPasPc + "','" + vchUsrPc + "') ";
            }

            cmd.CommandText = sql;
            cmd.Parameters.Add("@fileCer", SqlDbType.Image);
            cmd.Parameters.Add("@fileKey", SqlDbType.Image);
            cmd.Parameters["@fileCer"].Value = fileCer;
            cmd.Parameters["@fileKey"].Value = fileKey;

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
