using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace FLXDSK.Classes.Inventarios
{
    class Class_Traspasos
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();

        public DataTable getListaWhere(string filtroWhere)
        {
            string sql = "SELECT iidFolio, CONVERT(varchar(10),dfechaIn,103)dfechaIn103, dfechaUp, " +
                " dfechaRecepcion, iidAlmacen_Origen, iidAlmacen_Destino, iidUsuario_Origen, iidUsuario_Destino, iidEstatus, siEntregado, vchcomentario " +
            " FROM catTraspasos (NOLOCK) " + filtroWhere;
            return Conexion.Consultasql(sql);
        }
        /*public DataTable getLista(string filtroWhere)
        {
            
            SELECT iidFolio, iidAlmacen_Origen, iidAlmacen_Destino,  iidUsuario_Origen,iidUsuario_Destino,
	            dfechaIn103, dfechaRecepcion103,
	            iidEstatus, siEntregado, vchcomentario, 
	            AlmacenOrigen, UsuarioOrigen
            FROM (
            SELECT T.iidFolio, T.iidAlmacen_Origen, T.iidAlmacen_Destino, T.iidUsuario_Origen, T.iidUsuario_Destino,
	            CONVERT(varchar(10),T.dfechaIn,103)dfechaIn103,
	            CONVERT(varchar(10),T.dfechaRecepcion,103)dfechaRecepcion103,	
	            T.iidEstatus, T.siEntregado, T.vchcomentario, 
	            A.vchNombre AlmacenOrigen, U.vchUsuario UsuarioOrigen
            FROM catTraspasos (NOLOCK)  T, catAlmacenes  A (NOLOCK), catUsuarios U (NOLOCK)
            WHERE T.iidAlmacen_Origen = A.iidAlmacen
            AND T.iidUsuario_Origen = U.iidUsuario

            UNION ALL 

            SELECT T.iidFolio, T.iidAlmacen_Origen, T.iidAlmacen_Destino, T.iidUsuario_Origen, T.iidUsuario_Destino,
	            CONVERT(varchar(10),T.dfechaIn,103)dfechaIn103,
	            CONVERT(varchar(10),T.dfechaRecepcion,103)dfechaRecepcion103,	
	            T.iidEstatus, T.siEntregado, T.vchcomentario, 
	            A.vchNombre AlmacenOrigen, U.vchUsuario UsuarioOrigen
            FROM catTraspasos (NOLOCK)  T, catAlmacenes  A (NOLOCK), catUsuarios U (NOLOCK)
            WHERE T.iidAlmacen_Destino = A.iidAlmacen
            AND T.iidUsuario_Destino = U.iidUsuario

            ) as T1

            string sql = " SELECT T.iidFolio, CONVERT(varchar(10),T.dfechaIn,103)dfechaIn103,  " +
                " T.dfechaRecepcion, T.iidAlmacen_Origen, T.iidAlmacen_Destino, T.iidUsuario_Origen, T.iidUsuario_Destino, T.iidEstatus, T.siEntregado, T.vchcomentario, " +
            " FROM catTraspasos (NOLOCK)  T " + filtroWhere;
            return Conexion.Consultasql(sql);
        }*/

        public bool InsertaInformacion(string idAlm_Origen, string idAlm_Destino, string vchComentario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " INSERT INTO catTraspasos " +
            " (dfechaIn, dfechaUp, dfechaRecepcion, iidAlmacen_Origen, iidAlmacen_Destino, iidUsuario_Origen, iidUsuario_Destino, iidEstatus, siEntregado, vchcomentario ) " +
            " VALUES( " +
            " GETDATE(),GETDATE(), NULL, @iidAlmacen_Origen, @iidAlmacen_Destino, @iidUsuario_Origen, NULL, 0, 0, @vchcomentario) ";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidAlmacen_Origen", SqlDbType.Int);
            cmd.Parameters.Add("@iidAlmacen_Destino", SqlDbType.Int);
            cmd.Parameters.Add("@iidUsuario_Origen", SqlDbType.Int);
            cmd.Parameters.Add("@vchcomentario", SqlDbType.Text);
            ///
            cmd.Parameters["@iidAlmacen_Origen"].Value = idAlm_Origen;
            cmd.Parameters["@iidAlmacen_Destino"].Value = idAlm_Destino;
            cmd.Parameters["@iidUsuario_Origen"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@vchcomentario"].Value = vchComentario;

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
        public bool CambiaEstatusEnviado(string iidFolio)
        {
            string sql = " UPDATE catTraspasos SET dfechaUp = GETDATE(), iidEstatus = 1   WHERE iidFolio = " + iidFolio;
            return Conexion.InsertaSql(sql);
        }
        public bool CambiaEstatusRecibido(string iidFolio)
        {
            string sql = " UPDATE catTraspasos SET dfechaUp = GETDATE(), siEntregado = 1, " +
                " iidUsuario_Destino = " + Classes.Class_Session.Idusuario + ", dfechaRecepcion = GETDATE()  " +
            " WHERE iidFolio = " + iidFolio;
            return Conexion.InsertaSql(sql);
        }
        public bool ActualizaInformacion(string iidFolio, string idAlm_Destino, string vchComentario)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catTraspasos SET dfechaUp = GETDATE(), iidAlmacen_Destino = @iidAlmacen_Destino,  " +
            " iidUsuario_Origen = @iidUsuario_Origen, vchcomentario = @vchcomentario " +
            " WHERE iidFolio = " + iidFolio;
            cmd.CommandText = sql;
            cmd.Parameters.Add("@iidAlmacen_Destino", SqlDbType.Int);
            cmd.Parameters.Add("@iidUsuario_Origen", SqlDbType.Int);
            cmd.Parameters.Add("@vchcomentario", SqlDbType.Text);

            ///
            cmd.Parameters["@iidAlmacen_Destino"].Value = idAlm_Destino;
            cmd.Parameters["@iidUsuario_Origen"].Value = Classes.Class_Session.Idusuario;
            cmd.Parameters["@vchcomentario"].Value = vchComentario;
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
        public bool EliminaRegistro(string folio)
        {
            string sql = "UPDATE catTraspasos SET iidEstatus = 2, dfechaUp = GETDATE() WHERE iidFolio = " + folio;
            return Conexion.InsertaSql(sql);
        }

        public string getIdCrado()
        {
            string sql = "SELECT MAX(iidFolio)iidFolio  FROM catTraspasos (NOLOCK) ";
            DataTable dt = Conexion.Consultasql(sql);
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["iidFolio"].ToString();

            return "0";
        }

    }
}
