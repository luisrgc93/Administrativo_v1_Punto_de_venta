using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace FLXDSK.Classes.Catalogos
{
    class Class_Eventos
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Class_Logs ClsLog = new Class_Logs();

        public bool borrar_Evento(string idEvento)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            string sql = " UPDATE catEventos SET iidEstatus = 2, dFechaUp = GETDATE() WHERE iidEvento = " + idEvento;

            cmd.CommandText = sql;

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

        public bool inserta_Evento(DataTable info)
        {
            DataRow Row = info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();

            Byte[] dibujoByteArray = null;
            try
            {
                dibujoByteArray = (byte[])(info.Rows[0]["imagen"]);
            }
            catch{ };

            int usuario = Classes.Class_Session.Idusuario;
            string sql = " INSERT INTO  catEventos " +
            " (dfechaIn, dfechaUp, dfechaEventoInicia, dfechaEventoTermina, iidEstatus, vchNombre, vchDescripcion, IFilePromo, iidUsuario) " +
            " values(GETDATE(), GETDATE(), @Inicia, @Termina, 1, @evento, @descripcion, @IFilePromo, '" + usuario + "')";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@Inicia", SqlDbType.DateTime);
            cmd.Parameters.Add("@Termina", SqlDbType.DateTime);
            cmd.Parameters.Add("@evento", SqlDbType.Text);
            cmd.Parameters.Add("@descripcion", SqlDbType.Text);
            cmd.Parameters.Add("@IFilePromo", SqlDbType.Image);
            
            /*----------------------------------------------------------------------*/

            cmd.Parameters["@Inicia"].Value = Row["Inicia"].ToString();
            cmd.Parameters["@Termina"].Value = Row["Termina"].ToString();
            cmd.Parameters["@evento"].Value = Row["evento"].ToString();
            cmd.Parameters["@descripcion"].Value = Row["descripcion"].ToString();
            cmd.Parameters["@IFilePromo"].Value = dibujoByteArray;

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
        public bool actualiza_Evento(DataTable info)
        {
            DataRow Row = info.Rows[0];
            Byte[] dibujoByteArray = null;
            try
            {
                dibujoByteArray = (byte[])(info.Rows[0]["imagen"]);
            }
            catch{ };

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " UPDATE catEventos SET dfechaUp = GETDATE(), dfechaEventoInicia = @Inicia, " +
            " dfechaEventoTermina = @Termina, vchNombre = @evento, vchDescripcion = @descripcion, IFilePromo = @IFilePromo " +
            " WHERE iidEvento = @idEvento ";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@Inicia", SqlDbType.DateTime);
            cmd.Parameters.Add("@Termina", SqlDbType.DateTime);
            cmd.Parameters.Add("@evento", SqlDbType.Text);
            cmd.Parameters.Add("@descripcion", SqlDbType.Text);
            cmd.Parameters.Add("@IFilePromo", SqlDbType.Image);
            cmd.Parameters.Add("@idEvento", SqlDbType.Int);

            ///
            cmd.Parameters["@idEvento"].Value = Row["idEvento"].ToString();
            cmd.Parameters["@evento"].Value = Row["evento"].ToString();
            cmd.Parameters["@descripcion"].Value = Row["descripcion"].ToString();
            cmd.Parameters["@IFilePromo"].Value = dibujoByteArray;
            cmd.Parameters["@Inicia"].Value = Row["Inicia"].ToString();
            cmd.Parameters["@Termina"].Value = Row["Termina"].ToString();

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

        public string getIdProducto()
        {
            string sql = "select top 1 iidEvento from catEventos order by dfechain desc";
            DataTable dt = new DataTable();
            dt = Conexion.Consultasql(sql);
            try
            {
                DataRow Row = dt.Rows[0];
                return Row["iidEvento"].ToString();
            }
            catch
            {
                return "";
            }
        }

        public DataTable obtener_Evento(string idEvento)
        {

            string sql = " " +
            " SELECT dfechaEventoInicia Inicia, dfechaEventoTermina Termina, vchNombre evento, "+
                " vchDescripcion descripcion, vchRutaImagen imagen, IFilePromo " +
            " FROM catEventos " +
            " WHERE iidEstatus = 1 " +
            " AND iidEvento = " + idEvento +
            " ORDER BY dfechaIn DESC ";
            return Conexion.Consultasql(sql);
        }

        public DataTable obtener_CoverEvento(string idEvento)
        {

            string sql = " select top 1 R.dfechaInicia Inicia, R.dfechaTermina Termina, R.fCover Cover, R.vchSexo Sexo, E.vchNombre Nombre " +
                         " from catPrecioEvento R, catEventos E " + 
                         " where R.iidEvento = " + idEvento + 
                         " and R.iidEvento = E.iidEvento " + 
                         " and dfechaTermina > GETDATE()";

            return Conexion.Consultasql(sql);
        }
        public bool EliminaidCobroEvento(string id){
            string sql="DELETE FROM catPrecioEvento WHERE iidPrecioEvento = "+id;
            return Conexion.InsertaSql(sql);
        }
        public bool GuardarRelEventoCover(DataTable Info)
        {
            DataRow Row = Info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " insert into catPrecioEvento (iidEvento, vchSexo, fCover, dfechaInicia, dfechaTermina) values (@idEvento, @sexo, @cover, @Inicia, @Termina)";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idEvento", SqlDbType.Int);
            cmd.Parameters.Add("@sexo", SqlDbType.Text);
            cmd.Parameters.Add("@cover", SqlDbType.Int);
            cmd.Parameters.Add("@Inicia", SqlDbType.DateTime);
            cmd.Parameters.Add("@Termina", SqlDbType.DateTime);

            ///
            cmd.Parameters["@idEvento"].Value = Row["idEvento"].ToString();
            cmd.Parameters["@sexo"].Value = Row["sexo"].ToString();
            cmd.Parameters["@cover"].Value = Row["cover"].ToString();
            cmd.Parameters["@Inicia"].Value = Row["Inicia"].ToString();
            cmd.Parameters["@Termina"].Value = Row["Termina"].ToString();

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

        public bool ahiEventoEnEstaFecha(string fechaInicia, string fechaTermina)
        {
            string sql = "select iidEvento  from catEventos where iidEstatus = 1 and '" + fechaInicia + "' between dfechaEventoInicia and dfechaEventoTermina or '" + fechaTermina + "' between dfechaEventoInicia and dfechaEventoTermina and iidEstatus = 1";
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else return false;
        }

        public bool ahiCoverEnEstaFecha(string idEvento)
        {
            string sql = "select iidPrecioEvento from catPrecioEvento where iidEvento = " + idEvento + " and dfechaTermina > GETDATE()";
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else return false;
        }

        public bool elCoverEsDentrodelasFechasdelEvento(string fechaInicia, string fechaTermina, string idEvento)
        {
            string sql = " select E.iidEvento from catEventos E where E.iidEvento = " + idEvento + 
                         " and '" + fechaInicia + "' between E.dfechaEventoInicia and E.dfechaEventoTermina and '" + fechaTermina + "' between E.dfechaEventoInicia and E.dfechaEventoTermina";
            int numero = Conexion.NumeroFilas(sql);
            if (numero > 0)
                return true;
            else return false;
        }
    }
}
