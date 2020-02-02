using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FLXDSK.Classes.Herramientas
{
    class Class_BackUp
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public bool GuardarRegistroBackup(DataTable Info)
        {
            DataRow Row = Info.Rows[0];

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = Conexion.ConexionSQL();
            string sql = " INSERT INTO catBackUp (iidUsuario,iidEmpresa,vchNombre,vchRuta,dFechaIn) " +
                         " VALUES (@idUsuario,@idEmpresa,@Nombre,@Ruta,GETDATE())";

            cmd.CommandText = sql;
            cmd.Parameters.Add("@idUsuario", SqlDbType.Int);
            cmd.Parameters.Add("@idEmpresa", SqlDbType.Int);
            cmd.Parameters.Add("@Nombre", SqlDbType.Text);
            cmd.Parameters.Add("@Ruta", SqlDbType.Text);

            ///
            cmd.Parameters["@idUsuario"].Value = Row["idUsuario"].ToString();
            cmd.Parameters["@idEmpresa"].Value = Row["idEmpresa"].ToString();
            cmd.Parameters["@Nombre"].Value = Row["Nombre"].ToString();
            cmd.Parameters["@Ruta"].Value = Row["Ruta"].ToString();
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
    }
}
