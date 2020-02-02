using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.Nomina
{
    class Class_Nomina
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        /////insertanto nomina
        public string InsertaNominaExcel(string idSerie, string idCripto, int numeroEmpleados, double montoNEto, double montoDeducciones, double montoPercepciones, string iniciopago, string finpago, string fechapago, string CodBank, string idMetodoPago, string Periodicidad, string nombre)
        {
            string idempresa = Classes.Class_Session.IDEMPRESA.ToString();
            string usuario = Classes.Class_Session.Idusuario.ToString();
            if (idCripto == "") idCripto = "0";
            string sql = "INSERT INTO CatNominas " +
                " (dfechaIn, iidUsuario, iidEmpresa, iidCripto, iidSerie, iNumEmpleados, " +
                " dfechaInicia,dfechaTermina, dfechaPago,vchBanco,iidMetodoPago, iidPeriodicidad, vchNombre,  " +
                " fMontoTotal, fMontoPercepciones, fMontoDeduciones, SiCompletado) " +
                " VALUES ( getdate(), '" + usuario + "', '" + idempresa + "', '" + idCripto + "','" + idSerie + "', '" + numeroEmpleados + "',  " +
                " '" + iniciopago + "', '" + finpago + "', '" + fechapago + "', '" + CodBank + "', '" + idMetodoPago + "',  '" + Periodicidad + "', '" + nombre + "', " +
                " '" + montoNEto + "','" + montoPercepciones + "','" + montoDeducciones + "', 0) " +
                " ";
            bool resp = Conexion.InsertaSql(sql);
            if (resp)
            {
                sql = "SELECT TOP 1 iidNomina FROM CatNominas (NOLOCK) WHERE  iidUsuario = '" + usuario + "' AND iidEmpresa = " + idempresa + " AND SiCompletado = 0 ORDER BY  iidNomina DESC ";
                DataTable dt = new DataTable();
                dt = Conexion.Consultasql(sql);
                if (dt.Rows.Count > 0)
                {
                    return dt.Rows[0]["iidNomina"].ToString();
                }
                else return "";
            }
            else return "";
        }
        public DataTable getInfoNomina(string idNomina)
        {
            string idempresa = Classes.Class_Session.IDEMPRESA.ToString();
            string sql = " " +
                " SELECT iidNomina, vchNombre, iidPeriodicidad, dfechaIn, iidUsuario,  " +
                "    iidEmpresa, iidCripto, iidSerie, iidMetodoPago, vchBanco,  " +
                "    dfechaInicia, dfechaTermina, dfechaPago,   " +
                "    fMontoTotal, fMontoPercepciones, fMontoDeduciones, iNumEmpleados " +
                " FROM catNominas N (NOLOCK) " +
                " WHERE iidNomina  = " + idNomina +
                " AND SiCompletado = 1 " +
                " AND iidEmpresa =  " + idempresa +
                " ";
            return Conexion.Consultasql(sql);
        }

        public bool UpdateCompletNomina(string idNomina)
        {
            double deducciones = 0;
            double percepcione = 0;
            double total = 0;
            //Obtener Montos de los Generados
            string sql = " "+
            " select SUM(fDeducciones)Deducciones, SUM(fPercepciones)Percepciones, (SUM(fPercepciones) - SUM(fDeducciones)) total  " +
            " from catDetalleNomina where iidnomina= "+ idNomina + 
            " AND SiCompletado = 1 ";
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    deducciones = Convert.ToDouble(dt.Rows[0]["Deducciones"].ToString());
                    percepcione = Convert.ToDouble(dt.Rows[0]["Percepciones"].ToString());
                    total = Convert.ToDouble(dt.Rows[0]["total"].ToString());
                }
                catch { }
            }

            sql = " UPDATE catNominas SET SiCompletado = 1, "+
                "   " +
                " fMontoTotal= '" + total + "', fMontoPercepciones= '" + percepcione + "', fMontoDeduciones='" + deducciones + "'  " +
                " WHERE iidNomina  = " + idNomina;
            return Conexion.InsertaSql(sql);
        }
        public int getDiasPagados(string FI, string FF) {
            string sql = "select DATEDIFF(DAY,'" + FI + "','" + FF + "')dias";
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
            {
                try
                {
                    return Convert.ToInt32(dt.Rows[0]["dias"].ToString());
                }
                catch { return 0;  }
            }
            else return 0;
        }
    }
}
