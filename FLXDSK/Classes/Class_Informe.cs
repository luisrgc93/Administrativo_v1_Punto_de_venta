using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes
{
    class Class_Informe
    {
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();
        public bool ExistenInformes()
        {
            string sql = "SELECT * FROM catLogServicioTim (NOLOCK) ";
            int numero = conx.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else return false;
        }
        public DataTable EnviaInforme()
        {
            string sql = "SELECT iidServicio, CONVERT(VARCHAR(20),dfecha,126)dfecha, vchXlm, vchMesajeResp FROM catLogServicioTim (NOLOCK) ";
            return conx.Consultasql(sql);
        }

        public bool EliminaLineaInforme(string id)
        {
            string sql = "DELETE FROM catLogServicioTim WHERE iidServicio = " + id;
            return conx.InsertaSql(sql);
        }
    }
}
