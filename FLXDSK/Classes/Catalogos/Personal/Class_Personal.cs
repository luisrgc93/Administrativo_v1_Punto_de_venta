using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FLXDSK.Classes.Catalogos.Personal
{
    class Class_Personal
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();


        public DataTable getListaWhere(string FiltroWhere)
        {
            string sql = " SELECT iidPersonal, iidEmpresa,iidPuesto,dfechaIn,dfechaUp,iidUsuario,vchCorreo,vchCodigo, " +
                " dfechaIngreso,dfechaNacimiento,vchNombres,vchApellidoPat,vchApellidoMat, " +
                " vchNombres + ' ' + vchApellidoPat + ' ' + vchApellidoMat NombreCompleto,  " +
                " vchDomicilio, vchNumExt,vchNumInt,vchColonia,vchLocalidad,vchMunicipio,iidEstado,vchCp,iidPais,vchTelefono,vchCelular, " +
                " vchEstadoCivil,vchSexo,vchCURP,vchRfc,iidRegimen,iidRiesgo,iidEstatus, iidTipoContrato, iidTipoJornada, iidPeriodicidad, vchObservacion, vchCtaPago, vchclave" +
            " FROM CatPersonal (NOLOCK) "+ FiltroWhere;
            return Conexion.Consultasql(sql);
        }
        public DataTable getLista(string filtro)
        {
            string sql = " " +
            " SELECT P.iidPersonal, P.iidEmpresa, P.iidPuesto, P.dfechaIn, P.dfechaUp, P.iidUsuario, P.vchCorreo, P.vchCodigo, " +
                " P.dfechaIngreso, P.dfechaNacimiento, P.vchNombres, P.vchApellidoPat,P.vchApellidoMat,  " +
                " P.vchNombres + ' ' + P.vchApellidoPat + ' ' + P.vchApellidoMat NombreCompleto,  " +
                " P.vchDomicilio, P.vchNumExt, P.vchNumInt, P.vchColonia, P.vchLocalidad, P.vchMunicipio, P.iidEstado, P.vchCp, P.iidPais, P.vchTelefono, P.vchCelular,  " +
                " P.vchEstadoCivil, P.vchSexo, P.vchCURP, P.vchRfc, P.iidRegimen, P.iidRiesgo, P.iidEstatus, P.iidTipoContrato,  " +
                " P.iidTipoJornada, P.iidPeriodicidad, P.vchObservacion, P.vchCtaPago, P.vchclave, " +
                " U.vchNombre Puesto, U.fPropina " +
            " FROM CatPersonal P (NOLOCK), catPuestos U (NOLOCK) " +
            " WHERE P.iidPuesto = U.iidPuesto " +
            " AND P.iidEstatus = 1 " +filtro;
            return Conexion.Consultasql(sql);
        }


        public bool inserta_personal(DataTable info)
        {
            DataRow row = info.Rows[0];            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO CatPersonal (iidEmpresa,iidPuesto,dfechaIn,dfechaUp,iidUsuario,vchCorreo,vchCodigo, " +
                         " dfechaIngreso,dfechaNacimiento,vchNombres,vchApellidoPat,vchApellidoMat,vchDomicilio, " +
                         " vchNumExt,vchNumInt,vchColonia,vchLocalidad,vchMunicipio,iidEstado,vchCp,iidPais,vchTelefono,vchCelular, " +
                         " vchEstadoCivil,vchSexo,vchCURP,vchRfc,iidRegimen,iidRiesgo,iidEstatus, iidTipoContrato, iidTipoJornada, iidPeriodicidad, vchObservacion, vchCtaPago, vchclave, vchUsuario) " +
                         " VALUES " +
                         " (@idempresa,@idpuesto,GETDATE(),GETDATE(),@idusuario,@correo,@clave, " +
                         " GETDATE(),GETDATE(),@Nombre,@paterno,@materno,@calle, " +
                         " @exteriro,@interior,@colonia,@localidad,@municipio,@idestado,@cp,1,@telefono,'', " +
                         " @civil,@sexo,@curp,@rfc,@idRegimen,@idTipoRiesgo,1,@idTipoContrato,@idTipoJornada,@idPeriocidadPago,@observacion,@ctaPago, @vchclave, @vchUsuario) ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@Nombre", SqlDbType.Text).Value = row["Nombre"].ToString();
            cmd.Parameters.Add("@paterno", SqlDbType.Text).Value = row["paterno"].ToString();
            cmd.Parameters.Add("@materno", SqlDbType.Text).Value = row["materno"].ToString();
            cmd.Parameters.Add("@curp", SqlDbType.Text).Value = row["curp"].ToString();
            cmd.Parameters.Add("@rfc", SqlDbType.Text).Value = row["rfc"].ToString();
            cmd.Parameters.Add("@nacimiento", SqlDbType.DateTime).Value = row["nacimiento"].ToString();
            cmd.Parameters.Add("@sexo", SqlDbType.Text).Value = row["sexo"].ToString();
            cmd.Parameters.Add("@civil", SqlDbType.Text).Value = row["civil"].ToString();
            cmd.Parameters.Add("@calle", SqlDbType.Text).Value = row["calle"].ToString();
            cmd.Parameters.Add("@exteriro", SqlDbType.Text).Value = row["exteriro"].ToString();
            cmd.Parameters.Add("@interior", SqlDbType.Text).Value = row["interior"].ToString();
            cmd.Parameters.Add("@colonia", SqlDbType.Text).Value = row["colonia"].ToString();
            cmd.Parameters.Add("@municipio", SqlDbType.Text).Value = row["municipio"].ToString();
            cmd.Parameters.Add("@localidad", SqlDbType.Text).Value = row["localidad"].ToString();
            cmd.Parameters.Add("@cp", SqlDbType.Text).Value = row["cp"].ToString();
            cmd.Parameters.Add("@idestado", SqlDbType.Int).Value = row["idestado"].ToString();
            cmd.Parameters.Add("@telefono", SqlDbType.Text).Value = row["telefono"].ToString();
            cmd.Parameters.Add("@correo", SqlDbType.Text).Value = row["correo"].ToString();
            cmd.Parameters.Add("@ingreso", SqlDbType.DateTime).Value = row["ingreso"].ToString();
            cmd.Parameters.Add("@idpuesto", SqlDbType.Int).Value = row["idpuesto"].ToString();
            cmd.Parameters.Add("@clave", SqlDbType.Text).Value = row["clave"].ToString();
            cmd.Parameters.Add("@idempresa", SqlDbType.Int).Value = Class_Session.IDEMPRESA.ToString();
            cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = Class_Session.Idusuario.ToString();
            cmd.Parameters.Add("@idRegimen", SqlDbType.Int).Value = row["idRegimen"].ToString();
            cmd.Parameters.Add("@idTipoRiesgo", SqlDbType.Int).Value = row["idTipoRiesgo"].ToString();
            cmd.Parameters.Add("@idTipoContrato", SqlDbType.Int).Value = row["idTipoContrato"].ToString();
            cmd.Parameters.Add("@idTipoJornada", SqlDbType.Int).Value = row["idTipoJornada"].ToString();
            cmd.Parameters.Add("@idPeriocidadPago", SqlDbType.Int).Value = row["idPeriocidadPago"].ToString();
            cmd.Parameters.Add("@observacion", SqlDbType.Text).Value = row["observacion"].ToString();
            cmd.Parameters.Add("@ctaPago", SqlDbType.Text).Value = row["ctaPago"].ToString();
            cmd.Parameters.Add("@vchclave", SqlDbType.Text).Value = row["vchclave"].ToString();
            cmd.Parameters.Add("@vchUsuario", SqlDbType.Text).Value = row["vchUsuario"].ToString();

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                DataTable Info_Excepcion = new DataTable();
                DataRow row_Excepcion;

                Info_Excepcion.Columns.Add("vchExcepcion", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchLugar", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchAccion", System.Type.GetType("System.String"));

                row_Excepcion = Info_Excepcion.NewRow();
                row_Excepcion["vchExcepcion"] = exp;
                row_Excepcion["vchLugar"] = "Class_Areas";
                row_Excepcion["vchAccion"] = "funcion (inserta_area)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public bool borrar_personal(string idpersonal)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catPersonal SET iidEstatus = 2, dFechaUp = GETDATE() WHERE iidPersonal = " + idpersonal;

            cmd.CommandText = sql;

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                DataTable Info_Excepcion = new DataTable();
                DataRow row_Excepcion;

                Info_Excepcion.Columns.Add("vchExcepcion", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchLugar", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchAccion", System.Type.GetType("System.String"));

                row_Excepcion = Info_Excepcion.NewRow();
                row_Excepcion["vchExcepcion"] = exp;
                row_Excepcion["vchLugar"] = "Class_Personal";
                row_Excepcion["vchAccion"] = "funcion (borrar_personal)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public bool actualiza_personal(DataTable info)
        {
            DataRow row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE CatPersonal " +
                         " SET  iidEmpresa = @idempresa, iidPuesto = @idpuesto, dfechaUp = GETDATE(), iidUsuario = @idempresa, vchCorreo = @correo " +
                         " , vchCodigo = @clave, dfechaIngreso = @ingreso, dfechaNacimiento = @nacimiento, vchNombres = @Nombre " +
                         " , vchApellidoPat = @paterno, vchApellidoMat = @materno, vchDomicilio = @calle, vchNumExt = @exteriro, vchNumInt = @interior " +
                         " , vchColonia = @colonia, vchLocalidad = @localidad, vchMunicipio = @municipio, iidEstado = @idestado, vchCp = @cp, vchClave = @vchclave " +
                         " , vchTelefono = @telefono, vchEstadoCivil = @civil, vchSexo = @sexo, vchCURP = @curp, vchRfc = @rfc, iidRegimen = @idRegimen, iidRiesgo = @idTipoRiesgo, iidTipoContrato = @idTipoContrato, iidTipoJornada = @idTipoJornada, iidPeriodicidad = @idPeriocidadPago, vchObservacion = @observacion, vchCtaPago = @ctaPago" +
                         " WHERE iidPersonal = @idpersonal";
            
            cmd.CommandText = sql;
            cmd.Parameters.Add("@idpersonal", SqlDbType.Int).Value = row["idpersonal"].ToString();
            cmd.Parameters.Add("@Nombre", SqlDbType.Text).Value = row["Nombre"].ToString();
            cmd.Parameters.Add("@paterno", SqlDbType.Text).Value = row["paterno"].ToString();
            cmd.Parameters.Add("@materno", SqlDbType.Text).Value = row["materno"].ToString();
            cmd.Parameters.Add("@curp", SqlDbType.Text).Value = row["curp"].ToString();
            cmd.Parameters.Add("@rfc", SqlDbType.Text).Value = row["rfc"].ToString();
            cmd.Parameters.Add("@nacimiento", SqlDbType.DateTime).Value = row["nacimiento"].ToString();
            cmd.Parameters.Add("@sexo", SqlDbType.Text).Value = row["sexo"].ToString();
            cmd.Parameters.Add("@civil", SqlDbType.Text).Value = row["civil"].ToString();
            cmd.Parameters.Add("@calle", SqlDbType.Text).Value = row["calle"].ToString();
            cmd.Parameters.Add("@exteriro", SqlDbType.Text).Value = row["exteriro"].ToString();
            cmd.Parameters.Add("@interior", SqlDbType.Text).Value = row["interior"].ToString();
            cmd.Parameters.Add("@colonia", SqlDbType.Text).Value = row["colonia"].ToString();
            cmd.Parameters.Add("@municipio", SqlDbType.Text).Value = row["municipio"].ToString();
            cmd.Parameters.Add("@localidad", SqlDbType.Text).Value = row["localidad"].ToString();
            cmd.Parameters.Add("@cp", SqlDbType.Text).Value = row["cp"].ToString();
            cmd.Parameters.Add("@idestado", SqlDbType.Int).Value = row["idestado"].ToString();
            cmd.Parameters.Add("@telefono", SqlDbType.Text).Value = row["telefono"].ToString();
            cmd.Parameters.Add("@correo", SqlDbType.Text).Value = row["correo"].ToString();
            cmd.Parameters.Add("@ingreso", SqlDbType.DateTime).Value = row["ingreso"].ToString();
            cmd.Parameters.Add("@idpuesto", SqlDbType.Int).Value = row["idpuesto"].ToString();
            cmd.Parameters.Add("@clave", SqlDbType.Text).Value = row["clave"].ToString();
            cmd.Parameters.Add("@idempresa", SqlDbType.Int).Value = Class_Session.IDEMPRESA.ToString();
            cmd.Parameters.Add("@idusuario", SqlDbType.Int).Value = Class_Session.Idusuario.ToString();
            cmd.Parameters.Add("@idRegimen", SqlDbType.Int).Value = row["idRegimen"].ToString();
            cmd.Parameters.Add("@idTipoRiesgo", SqlDbType.Int).Value = row["idTipoRiesgo"].ToString();
            cmd.Parameters.Add("@idTipoContrato", SqlDbType.Int).Value = row["idTipoContrato"].ToString();
            cmd.Parameters.Add("@idTipoJornada", SqlDbType.Int).Value = row["idTipoJornada"].ToString();
            cmd.Parameters.Add("@idPeriocidadPago", SqlDbType.Int).Value = row["idPeriocidadPago"].ToString();
            cmd.Parameters.Add("@observacion", SqlDbType.Text).Value = row["observacion"].ToString();
            cmd.Parameters.Add("@ctaPago", SqlDbType.Text).Value = row["ctaPago"].ToString();
            cmd.Parameters.Add("@vchclave", SqlDbType.Text).Value = row["vchclave"].ToString();
            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception exp)
            {
                DataTable Info_Excepcion = new DataTable();
                DataRow row_Excepcion;

                Info_Excepcion.Columns.Add("vchExcepcion", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchLugar", System.Type.GetType("System.String"));
                Info_Excepcion.Columns.Add("vchAccion", System.Type.GetType("System.String"));

                row_Excepcion = Info_Excepcion.NewRow();
                row_Excepcion["vchExcepcion"] = exp;
                row_Excepcion["vchLugar"] = "Class_Areas";
                row_Excepcion["vchAccion"] = "funcion (inserta_area)";
                Info_Excepcion.Rows.Add(row_Excepcion);

                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                return false;
            }
        }

        public bool existe_curp(string curp)
        {
            string sql = "SELECT iidPersonal FROM catPersonal WHERE vchCURP = '" + curp + "' ";

            int numero = Conexion.NumeroFilas(sql);
            if (numero != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable obtener_personal_x_id(string idpersonal)
        {

            string sql = " SELECT  iidPersonal, iidEmpresa, iidPuesto, dfechaIn, dfechaUp, iidUsuario, " +
                         " vchCorreo, vchCodigo, CONVERT(VARCHAR(10),dfechaIngreso,103) AS dfechaIngreso,  " +
                         " CONVERT(VARCHAR(10),dfechaNacimiento,103) AS dfechaNacimiento, vchNombres, vchApellidoPat, " +
                         " vchApellidoMat, vchDomicilio, vchNumExt, vchNumInt, vchColonia, vchLocalidad, " +
                         " vchMunicipio, iidEstado, vchCp, iidPais, vchTelefono, vchCelular, vchEstadoCivil, vchClave, vchUsuario, " +
                         " vchObservacion, vchSexo, vchCURP, vchRfc, iidTipoContrato, iidTipoJornada, iidRiesgo, iidRegimen, iidPeriodicidad, vchCtaPago, vchObservacion " +
                         " FROM  CatPersonal " +
                         " WHERE iidEstatus = 1 " +
                         " AND iidPersonal = " + idpersonal;

            return Conexion.Consultasql(sql);
        }

        public string obtener_id_x_curp(string curp)
        {
            string sql = " SELECT iidPersonal FROM catPersonal WHERE vchCurp = '" + curp + "' " ;
            DataTable dt = new DataTable();
            try
            {

                dt = Conexion.Consultasql(sql);
                DataRow row = dt.Rows[0];
                return row["iidPersonal"].ToString();

            }
            catch
            {
                return "";
            }
        }

        public bool inserta_imagen(DataTable Info, string id)
        {
            DataRow row = Info.Rows[0];
            Byte[] dibujoByteArray = null;
            try
            {
                dibujoByteArray = (byte[])(row["imagen"]);
            }
            catch 
            { };

            string usuario = Convert.ToString(Classes.Class_Session.Idusuario);

            string sql = "";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            if (ExisteImagen(id))
            {
                sql = " UPDATE catImagenPersonal SET imgFoto = @vchImagen WHERE iidPersonal =  " + id;
            }
            else
            {
                sql = " INSERT INTO catImagenPersonal (iidPersonal, imgFoto, dfechaIn, dfechaUp, iidUsuario) " +
                      " VALUES (" + id + ",@vchImagen,GETDATE(), GETDATE()," + usuario + ") ";
            }

            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchImagen", SqlDbType.Image);
            cmd.Parameters["@vchImagen"].Value = dibujoByteArray;


            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ExisteImagen(string id)
        {
            string sql = "SELECT * FROM catImagenPersonal (NOLOCK)  WHERE iidPersonal =  " + id;
            int numero = Conexion.NumeroFilas(sql);
            if (numero == 0)
                return false;
            else
                return true;
        }

        public DataTable GetImagen(string id)
        {
            string sql = " SELECT imgFoto FROM catImagenPersonal (NOLOCK) WHERE iidPersonal = " + id;
            return Conexion.Consultasql(sql);
        }
        public DataTable getMeserosAll()
        {
            string sql = " SELECT 0 as id, 'Seleccionar' as nombre  " +
                         " UNION ALL " +
                         " SELECT iidPersonal as id, vchNombres + ' ' + vchApellidoPat as nombre FROM CatPersonal WHERE iidEstatus = 1";

            return Conexion.Consultasql(sql);
        }
        public DataTable getInfoByID(string id)
        {
            /*string sql = " " +
                " SELECT P.iidPersonal, P.iidEmpresa, P.dfechaIn, P.dfechaUp, P.vchCorreo, " +
                "     P.iidPuesto, P.vchDepartamento, P.vchCodigo,  P.dfechaBaja, P.Siactivo,  " +
                "     Convert(varchar(10),P.dfechaNacimiento,103) dfechaNacimiento, "+
                "     Convert(varchar(10),P.dfechaIngreso,103) dfechaIngreso, " +
                "     P.vchCtaPago,  P.vchNombres, P.vchApellidoPat, P.vchApellidoMat, P.vchDomicilio, " +
	            "     P.vchNumExt, P.vchNumInt, P.vchColonia, P.vchLocalidad, P.vchMunicipio, P.iidEstado, P.vchCp, P.iidPais, " +
	            "     P.vchTelefono, P.vchCelular, P.iHijos, P.vchEstadoCivil, P.vchObservacion, P.vchSexo, " +
	            "     P.vchCURP, P.vchRfc, P.iidRegimen, P.iidRiesgo, P.iidTipoContrato, P.iidTipoJornada, P.iidPeriodicidad, " +
	            "     EDO.vchNombre Estado, " +
	            "     R.vchDescripcion Regimen, " +
	            "     W.vchDescripcion Riesgo, " +
	            "     O.vchDescripcion Periodicidad " +
                " FROM CatPersonal P (NOLOCK), catEstados EDO (NOLOCK), CatRegimenTrabajador R  (NOLOCK), CatRiesgoPuesto W (NOLOCK), CatPeriodicidadPago O (NOLOCK) " +
                " WHERE EDO.iidEstado = P.iidEstado " +
                " AND R.iidRegimen = P.iidRegimen " +
                " AND W.iidRiesgo = P.iidRiesgo " +
                " AND O.iidPeriodicidad = P.iidPeriodicidad " +
                " AND P.iidPersonal =" + id;*/
            string sql = " " +
                " SELECT P.iidPersonal, P.iidEmpresa, P.dfechaIn, P.dfechaUp, P.vchCorreo, " +
                "     P.iidPuesto, P.vchDepartamento, P.vchCodigo,  P.dfechaBaja, P.Siactivo,  " +
                "     Convert(varchar(10),P.dfechaNacimiento,103) dfechaNacimiento," +
                "     Convert(varchar(10),P.dfechaIngreso,103) dfechaIngreso, Convert(varchar(10),P.dfechaIngreso,120) dfechaIngresoNomina, " +
                "     P.vchCtaPago,  P.vchNombres, P.vchApellidoPat, P.vchApellidoMat, P.vchDomicilio, " +
                            "     P.vchNumExt, P.vchNumInt, P.vchColonia, P.vchLocalidad, P.vchMunicipio, P.iidEstado, P.vchCp, P.iidPais, " +
                            "     P.vchTelefono, P.vchCelular, P.iHijos, P.vchEstadoCivil, P.vchObservacion, P.vchSexo, " +
                "     P.vchCURP, P.vchNSS, P.vchRfc, P.iidRegimen, P.iidRiesgo, P.iidTipoContrato, P.iidTipoJornada, P.iidPeriodicidad, " +
                " P.fSalarioBaseCotApor, fSalarioDiarioIntegrado, " +
                            "     EDO.vchNombre Estado, " +
                            "     R.vchDescripcion Regimen, " +
                            "     W.vchDescripcion Riesgo, " +
                            "     O.vchDescripcion Periodicidad " +
                " FROM CatPersonal P (NOLOCK), catEstados EDO (NOLOCK), CatRegimenTrabajador R  (NOLOCK), CatRiesgoPuesto W (NOLOCK), CatPeriodicidadPago O (NOLOCK) " +
                " WHERE EDO.iidEstado = P.iidEstado " +
                " AND R.iidRegimen = P.iidRegimen " +
                " AND W.iidRiesgo = P.iidRiesgo " +
                " AND O.iidPeriodicidad = P.iidPeriodicidad " +
                " AND P.iidPersonal =" + id;

            return Conexion.Consultasql(sql);
        }
    }
}
