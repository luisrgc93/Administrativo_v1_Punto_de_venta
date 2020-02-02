using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes
{
    class Class_Login
    {
        Conexion.Class_Conexion conx = new Conexion.Class_Conexion();

        public int EsPrimerUsuario() 
        {
            string sql = "SELECT Count(*) FROM catusuarios";
            DataTable dt = new DataTable();
            dt = conx.Consultasql(sql);
            if(dt.Rows.Count == 0)
            {
                return 0;
            }
            
            return 1;
            
        }
        public int getIDLogin(string usuario, string clave/*, string puesto*/)
        {
            var sql = "SELECT iidusuario FROM catusuarios (NOLOCK) WHERE vchUsuario= '" + usuario + "' AND vchClave = '" + clave + "' AND iidEstatus =1 "; /*+ "' AND iidPuesto  = '" + puesto "'*/
          //  sql = "select * from catusuarios";
          var dt = conx.Consultasql(sql);

            var idusuario = 0;
            try
            {
                var row = dt.Rows[0];
                idusuario = Convert.ToInt32(row["iidusuario"].ToString());
            }
            catch
            {
                // ignored
            }

            return idusuario;

        }
        public bool InsertaSession()
        {
            var usuario = Classes.Class_Session.Idusuario.ToString();
            var sql = "INSERT INTO HistSession (dfechain, dfechaup, iidUsuario, SiEnviado) VALUES (getdate(),getdate(),'" + usuario + "',0) ";
            return conx.InsertaSql(sql);
        }
    }
}
