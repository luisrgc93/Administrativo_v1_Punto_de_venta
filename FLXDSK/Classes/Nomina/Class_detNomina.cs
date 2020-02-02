using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace FLXDSK.Classes.Nomina
{
    class Class_detNomina
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();

        public bool InsertaDetalleNominaExcel(DataTable dtListaPersonal, string idNomina)
        {
            //LimpiamosTable
            string sql = "TRUNCATE TABLE catTmpInfoPersonalNominaExcel ";
            bool resp = Conexion.InsertaSql(sql);
            if (!resp) return false;

            string diaspago = "0";
            string fechaInicio = "";
            string fechafin = "";
            string fechapago = "";
            string banco = "";
            string metodopago = "";
            string idsEmpleados = null; 
            //insertamo Todos en la temporal
            foreach (DataRow Row in dtListaPersonal.Rows)
            {
                fechaInicio = Row["iniciopago"].ToString();
                fechafin = Row["finpago"].ToString();
                fechapago = Row["fechapago"].ToString();
                banco = Row["banco"].ToString();
                metodopago = Row["formapago"].ToString();
                diaspago = Row["diaspago"].ToString();
                if (diaspago == "") diaspago = "0";

                idsEmpleados = idsEmpleados+"," + Row["idempleado"].ToString();

                sql = "INSERT INTO  catTmpInfoPersonalNominaExcel  " +
                    " (dfechaIn, vchCURP, iidMetodoPago, vchBanco, " +
                    " dfechaInicia, dfechaTermina, dfechaPago, " +
                    " fdiasPago,vchRegPatronal,vchExpedido,vchRegimenEmpresa )values " +
                    " (getdate(),'" + Row["CURP"].ToString() + "','" + Row["formapago"].ToString() + "','" + Row["banco"].ToString() + "', " +
                    " '" + Row["iniciopago"].ToString() + "','" + Row["finpago"].ToString() + "','" + Row["fechapago"].ToString() + "', " +
                    " " + diaspago + ", '" + Row["regpatronal"].ToString() + "','" + Row["expedido"].ToString() + "','" + Row["regimenfiscal"].ToString() + "') ";
                try
                {
                    bool respIn = Conexion.InsertaSql(sql);
                    if (!respIn)
                        ClsLog.InsertaInformacion(sql, "CRITICO No se inserto en la temporal por algun dato erroneo que no se valido. BOOL insert");

                }
                catch (Exception expt)
                {
                    ClsLog.InsertaInformacion(expt.ToString(), "CRITICO No se inserto en la temporal por algun dato erroneo que no se valido.");
                }
            }
            ////Insertamos en la otra tabla
            string idempresa = Classes.Class_Session.IDEMPRESA.ToString();
            string usuario = Classes.Class_Session.Idusuario.ToString();

            sql = " " +
                   " INSERT INTO catDetalleNomina  " +
                    "(iidNomina, iidEmpresa, iidPersonal, dfechaEmision, SiEnviado, iCancelado, " +
                    "    vchVersion, fDeducciones, fISR, fPercepciones, fMontoTotal, SiCompletado, " +
                    "    iidMetodoPago, vchBanco, dfechaInicia, dfechaTermina, dfechaPago, fdiasPago, " +
                    "    vchRegPatronal, vchExpedido, vchRegimenEmpresa ) " +
                    "         " +
                    " SELECT '" + idNomina + "' idNomina, E.iidEmpresa , P.iidPersonal, " +
                    "     getdate(),0, 0, '1.1', Deduciones, ISR, Percepciones, total, 0, " +
	                "     1 MetodoPago, '"+banco+"'BAnco, '"+fechaInicio+"','"+fechafin+"','"+fechapago+"', " +
                    "     " + diaspago + " diasPago, E.vchRegistroPatronal, E.vchMunicipio+ ', '+ EDO.vchNombre Expedido, E.vchRegimen " +
                    " FROM( " +
                    "      " +
                    "     SELECT iidPersonal, SUM(Deduciones) Deduciones, SUM(Percepciones) Percepciones, SUM(Percepciones) - SUM(Deduciones)  total, SUM(ISR) ISR " +
	                "     FROM( " +
                    "         select P.iidPersonal, (P.fMontoG + P.fMontoE) as Deduciones, 0 Percepciones, 0 ISR " +
		            "         from catPagoNomina P, catConfiguracionNombreNom C " +
		            "         WHERE P.iidPercepcion = 0 " +
		            "         AND P.iidDeduccion = C.iidConfigurador " +
                    "         AND C.iidEstatus = 1 "+
		            "         UNION ALL " +
		            "         select P.iidPersonal,  0 Deduciones, (P.fMontoG + P.fMontoE) Percepciones, 0 ISR " +
		            "         from catPagoNomina P, catConfiguracionNombreNom C " +
		            "         WHERE P.iidDeduccion = 0 " +
		            "         AND P.iidPercepcion = C.iidConfigurador " +
                    "         AND C.iidEstatus = 1 " +
                    "         UNION ALL " +
                    "         select P.iidPersonal, 0 Deduciones, 0 Percepciones,  (P.fMontoG + P.fMontoE) ISR" +
                    "         from catPagoNomina P, catConfiguracionNombreNom C " +
                    "         WHERE P.iidPercepcion = 0 " +
                    "         AND P.iidDeduccion = C.iidConfigurador " +
                    "         AND C.iidEstatus = 1 " +
                    "         AND C.iid = 2 " +
	                "     ) AS T1 " +
	                "     group by iidPersonal " +
                    " ) AS T1, catPersonal P, catEmpresas E, catEstados EDO " +
                    " WHERE T1.iidPersonal  = P.iidPersonal " +
                    " AND P.iidEmpresa = E.iidEmpresa " +
                    " AND EDO.iidEstado = E.iidEstado "+
                    " AND P.iidPersonal in (0" + idsEmpleados + ") " +
                    " AND E.iidEmpresa =  " + idempresa+
                    " ";
            bool respIns = Conexion.InsertaSql(sql);
            if (!respIns)
                ClsLog.InsertaInformacion(sql, "CRITICO No se inserto en la temporal por algun dato erroneo que no se valido. BOOL insert");

            return true;
        }
        public DataTable GetListaDetalleNomina(string idNomina, string filtro)
        {
            string sql = " " +
                " select iidNomina, iidEmpresa, iidPersonal, " +
                "     dfechaTimbrado, dfechaEmision, SiEnviado, iCancelado, iFolio, vchSerie " +
                "     vchUUID, vchVersion, fDeducciones, fISR, fPercepciones, fMontoTotal, " +
                "     SiCompletado, iidMetodoPago, vchBanco, Convert(varchar(10),dfechaInicia,102)dfechaInicia, Convert(varchar(10),dfechaTermina,102)dfechaTermina, " +
                "     Convert(varchar(10),dfechaPago,102) dfechaPago, fdiasPago, vchRegPatronal, vchExpedido,  " +
                "     vchRegimenEmpresa, vchCfdi, iidDiseno, vchComentario, vchMnsError " +
                " from catDetalleNomina D (NOLOCK) " +
                " WHERE iidNomina = " + idNomina +
                " " + filtro;
            return Conexion.Consultasql(sql);
        }
        public bool ExisteAlmenosUnoGenerado(string idnomina) {
            string sql = "SELECT iidNomina FROM catDetalleNomina WHERE  iidNomina="+idnomina+" AND SiCompletado = 1 ";
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0) return true; else return false;
        }
        public DataTable getInfo(string UUID, string idNomina) {
            string sql = "select iidNomina, iidEmpresa, iidPersonal, dfechaTimbrado, convert(varchar(10),dfechaTimbrado,103)fechaF, " +
                    "     iCancelado, iFolio, vchSerie,  vchUUID, " +
	                "     fDeducciones, fPercepciones, fMontoTotal, "+
	                "     dfechaInicia, dfechaTermina, dfechaPago, fdiasPago, "+
	                "     vchCfdi, vchBanco "+
                    " FROM catDetalleNomina (NOLOCK) "+
                    " WHERE iidNomina =  "+idNomina +
                    " AND vchUUID = '" + UUID + "' " +
                    " AND SiCompletado = 1 ";
            return Conexion.Consultasql(sql);
        }
        public DataTable getInfoLista(string UUIDS, string idNomina)
        {
            string sql = "select iidNomina, iidEmpresa, iidPersonal, dfechaTimbrado, " +
                      "     iCancelado, iFolio, vchSerie,  vchUUID, " +
                      "     fDeducciones, fPercepciones, fMontoTotal, " +
                      "     dfechaInicia, dfechaTermina, dfechaPago, fdiasPago, " +
                      "     vchCfdi, vchBanco " +
                      " FROM catDetalleNomina (NOLOCK) " +
                      " WHERE iidNomina =  " + idNomina +
                      " AND vchUUID in ('' '" + UUIDS + "') " +
                      " AND SiCompletado = 1 ";
            return Conexion.Consultasql(sql);
        }
        public string GetNamePdf(string UUID, string idNomina) {
            string sql = "SELECT P.vchRFC, CONVERT(VARCHAR(11), V.dfechaTimbrado, 102)dfechaTimbrado,V.iFolio,V.vchSerie  " +
                        " FROM catDetalleNomina V (NOLOCK), CatPersonal P (NOLOCK)  " +
                        " WHERE vchuuid = '" + UUID + "'  " +
                        " AND iidNomina =  " + idNomina + 
                        " AND P.iidPersonal = V.iidPersonal ";
            DataTable dt = Conexion.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                string rfc = Row["vchRFC"].ToString();
                string fechatim = Row["dfechaTimbrado"].ToString();
                string folio = Row["iFolio"].ToString();
                string serie = Row["vchSerie"].ToString();
                return rfc + "_" + fechatim.Replace(".", "") + "_" + serie + folio;
            }
            catch
            {
                return "";
            }
        }
        public bool CancelaFac(string uuid)
        {
            string sql = "UPDATE catDetalleNomina set iCancelado=1 where vchUUID = '" + uuid + "' ";
            return Conexion.InsertaSql(sql);
        }
        public string getRFCEmitioFacByID(string uuid)
        {
            string sql = "select P.vchRfc " +
                        " from catDetalleNomina (NOLOCK)D, CatPersonal P (NOLOCK) " +
                        " where vchUUID='" + uuid + "' " +
                        " AND P.iidPersonal = D.iidPersonal";
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["vchRfc"].ToString();
            }
            else return "";
        }
    }
}
