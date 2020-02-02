using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Management;

namespace FLXDSK.Classes.Catalogos.Administracion
{
    class Class_Accesos
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public bool SoyAdministrador()
        {
            string sql = "SELECT iidUsuario FROM catUsuarios (NOLOCK) WHERE iidRol = 1 AND  iidUsuario = " + Class_Session.Idusuario;
            int numero = Conexion.NumeroFilas(sql);
            if (numero == 0)
            {
                return false;
            }
            else
                return true;
        }
        public DataTable getAccesosEmpresa(int idUsuario)
        {
            var sql = "SELECT iidAccesos FROM AccesoEmpresa  (NOLOCK) WHERE iidUsuario = " + idUsuario;
            var dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count <= 0) return null;
            var rw = dt.Rows[0];
            var ids = rw["iidAccesos"].ToString();

            sql = " SELECT C.iidEmpresa id, vchAlias+' '+vchRazon Alias   " +
                  " FROM catEmpresas C  (NOLOCK), int_satEstados E  (NOLOCK)  " +
                  " WHERE C.iidestado = E.iidestado  " +
                  " AND C.iidEmpresa in ( " + ids + " ) ";
            return Conexion.Consultasql(sql);
        }

        //-----------------------------------funciones para la validacion del web service------------------------------------------------
        public DataTable getKeyEmpresa()
        {
            string sql = " SELECT top 1 C.vchKey FROM catEmpresas C  (NOLOCK) ";
            return Conexion.Consultasql(sql);
        }

        public DataTable getIdVersionPrograma()
        {
            string sql = " SELECT TOP 1 iidProgramaNube, iidVersionNube " +
                         " FROM CatVersionesSoftWare " +
                         " ORDER BY dfechaIn DESC ";

            return Conexion.Consultasql(sql);
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
        public DataTable isPcRequiereActualizaciones()
        {
            string pcSerial = getMotherBoardID();
            if (pcSerial == "") pcSerial = Environment.MachineName;

            string sql = "SELECT vchPC FROM CatUsoSoftware (NOLOCK)  WHERE vchPC='" + pcSerial + "'  ";
            int numero = Conexion.NumeroFilas(sql);
            if (numero == 0)
            {
                sql = " " +
                    " INSERT INTO CatUsoSoftware (dfechaIn,dfechaUp,vchPC,iidProgramaNube,iidVersionNube,vchPrograma,vchVersion,vchDescripcion,iidUsuario) " +
                    " select top 1 GETDATE(),GETDATE(), '" + pcSerial + "', iidProgramaNube,iidVersionNube,vchPrograma,vchVersion,vchDescripcion ,iidUsuario " +
                    " from CatVersionesSoftWare (NOLOCK) order by iidVersion  ASC " +
                    " ";
                bool resp = Conexion.InsertaSql(sql);
            }
            //Vemos si ESE PC requiere ACtualizacion
            sql = "SELECT TOP 1 iidProgramaNube, iidVersionNube  FROM CatUsoSoftware (NOLOCK) " +
                " WHERE vchPC='" + pcSerial + "'  ORDER BY dfechaIn DESC ";
            return Conexion.Consultasql(sql);
        }
        public String getMotherBoardID()
        {
            String serial = "";
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard");
                ManagementObjectCollection moc = mos.Get();

                foreach (ManagementObject mo in moc)
                {
                    serial = mo["SerialNumber"].ToString();
                }
                return serial;
            }
            catch (Exception) { return serial; }
        }
        public bool ExisteVersionInserta(string idPrograma, string versionquees, string descripion, string versionstring)
        {
            string usuario = Classes.Class_Session.Idusuario.ToString();
            string pcSerial = getMotherBoardID();
            if (pcSerial == "") pcSerial = Environment.MachineName;
            string sql = "SELECT vchPrograma FROM CatUsoSoftware (nolock) WHERE iidProgramaNube = '" + idPrograma + "' and iidVersionNube = '" + versionquees + "' AND vchPC='" + pcSerial + "' ";
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count == 0)
            {
                sql = "SELECT vchPrograma FROM CatVersionesSoftWare (nolock) WHERE iidProgramaNube = '" + idPrograma + "'";
                dt = Conexion.Consultasql(sql);
                if (dt.Rows.Count > 0)
                {
                    string nombreprograma = dt.Rows[0]["vchPrograma"].ToString();
                    sql = " " +
                        " INSERT INTO CatUsoSoftware (dfechaIn,dfechaUp,vchPC,iidProgramaNube,iidVersionNube,vchPrograma,vchVersion,vchDescripcion,iidUsuario) " +
                        " values( GETDATE(),GETDATE(), '" + pcSerial + "', " + idPrograma + "," + versionquees + ",'" + nombreprograma + "','" + versionstring + "','" + descripion + "' , " + usuario + " ) " +
                        " ";
                    bool resp = Conexion.InsertaSql(sql);
                    return resp;
                }
                else return true;
            }
            else return true;
        }
    }
}
