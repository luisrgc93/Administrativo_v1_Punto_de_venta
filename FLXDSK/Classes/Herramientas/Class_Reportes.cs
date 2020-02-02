using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FLXDSK.Classes.Herramientas
{
    class Class_Reportes
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Estatus ClsEstatus = new Class_Estatus();

        public DataTable getInfoForReporteNivelEstudios(string idEmpresa, string filtro)
        {
            string idEstatusActivo = ClsEstatus.getIdByName("Activo", "personal");
            string sql = "select P.iidPersonal id, DATEDIFF(yy,P.dFechaNacimiento,GETDATE()) AS edad, DATEDIFF(yy,P.dFechaingreso,GETDATE()) AS antiguedad, P.vchNombres+' '+P.vchApPaterno+' '+P.vchApMaterno nombre,  G.vchGrado grado, Pu.vchPuesto puesto, " +
                         " D.vchNombre departamento,A.vchDescripcion adscripcion from catPersonal P " +
                         " inner join catPuestos Pu on Pu.iidPuesto=P.iidPuesto " +
                         " inner join catGrados G on G.iidGrado = P.iidGrado " +
                         " inner join CatDepartamento D on D.iidDepartamento= P.iidDepartamento " +
                         " inner join CatAdscripcion A on A.iidAdscripcion= P.iidAdscripcion " +
                         " inner join catRelEstudioPersonal Re on Re.iidPersona=P.iidPersonal " +
                         " inner join catEstudios E on E.iidEstudio=Re.iidEstudio " +
                         " WHERE P.iidEstatus = " + idEstatusActivo +
                         
                         " and P.iidEmpresa=" + idEmpresa + " " + filtro;
            return Conexion.Consultasql(sql);
        }

    }
}
