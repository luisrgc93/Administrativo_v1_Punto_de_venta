using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes
{
    class Class_ParametrosGenerales
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaconfiguraciones()
        {
            string sql = "select iidConfiguracion, vchTipo, vchConfiguracion from catParametrosConfig (NOLOCK)";
            return Conexion.Consultasql(sql);
        }
        public string getValueConfigByID(string id)
        {
            string sql = "select vchConfiguracion from catParametrosConfig where iidConfiguracion ='" + id + "'";
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["vchConfiguracion"].ToString();
            }
            catch
            {
                return "";
            }
        }
        public bool ActualizaConfiguracion(string id, string valor)
        {
            string sql = "UPDATE catParametrosConfig SET vchConfiguracion = '" + valor + "', dfechaUp = getdate() where iidConfiguracion='" + id + "'";
            return Conexion.InsertaSql(sql);
        }
        public string getValue(string tipo)
        {
            string sql = "select vchConfiguracion from CatParametrosConfig (NOLOCK) where vchTipo = '" + tipo + "'";
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["vchConfiguracion"].ToString();
            }
            else return "";
        }
    }
}
