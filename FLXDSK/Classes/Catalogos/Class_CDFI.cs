using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace FLXDSK.Classes.Catalogos
{
    class Class_CDFI
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();

        public DataTable getCDFIAll()
        {

            string sql = " SELECT 0 AS id, 'Seleccionar' AS nombre " +
                         " UNION ALL " +
                         " SELECT iidTipoCfdi AS id, vchNombre AS nombre " +
                         " FROM catTipoCFDI " + 
                         " WHERE iidEstatus = 1 ";

            return Conexion.Consultasql(sql);
        }
    }
}
