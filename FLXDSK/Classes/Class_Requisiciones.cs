using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes
{
    class Class_Requisiciones
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();


        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = "SELECT iidReq, dfechaIn, dfechaUp, iidPersonal, fCostoTotal, vchComentario, iidEstatus, siTerminado " +
            " FROM catRequisicion (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        public DataTable getLista(string filtro)
        {
            string sql = "SELECT iidReq ID, CONVERT(varchar(10),R.dfechaIn,103)Creado, R.iidPersonal, " +
                " P.vchNombres + ' ' + P.vchApellidoPat + ' ' + P.vchApellidoMat Nombre, " +
	            " R.vchComentario, " +
	            " CASE R.iidEstatus WHEN 0 THEN 'SIN REVISAR' ELSE 'REVISADO' END Estatus " +
            " FROM catRequisicion (NOLOCK) R, catPersonal P (NOLOCK) " +
            " WHERE R.iidPersonal = P.iidPersonal " + filtro;
            return Conexion.Consultasql(sql);
        }

    }
}
