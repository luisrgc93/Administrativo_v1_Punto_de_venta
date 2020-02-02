using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace FLXDSK.Classes.Internos
{
    class Class_UnidadesMetricas
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public DataTable getListaWhere(string Filtrowhere)
        {
            string sql = "SELECT iidUnidad, vchNombre, vchAbreviacion, vchPar, iidEstatus, dfechaIn, dfechaUp, iEquivalencia FROM catUnidadesMetricas (NOLOCK) " + Filtrowhere;
            return Conexion.Consultasql(sql);
        }
    }
}
