using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;

namespace FLXDSK.Conexion
{
    class Class_Conexion
    {

        Classes.Herramientas.Class_Encript ClsEncrip = new Classes.Herramientas.Class_Encript();

        public bool TestConexion()
        {
            string server = ConfigurationManager.AppSettings["server"];
            string usuario = ConfigurationManager.AppSettings["usuario_DB"];
            string db = ConfigurationManager.AppSettings["DB"];
            string pas = ConfigurationManager.AppSettings["clave_DB"];
            SqlConnection cnn = null;
            string conSQL = "";
            if (usuario == "")
            {
                conSQL = "Data Source=" + server
                                + ";Initial Catalog=" + db;

            }
            else
            {
                conSQL = "Data Source=" + server
                                + ";Initial Catalog=" + db
                                + ";Persist Security Info=False;User ID=" + usuario
                                + ";Password=" + pas;
            }

            cnn = new SqlConnection(conSQL);
            try
            {
                cnn.Open();
                cnn.Close();
                return true;
            }
            catch (Exception exp)
            {
                this.InsertaRegistroLog(exp.ToString(), conSQL);
                return false;
            }
        }
        public string EjecutaQueryIni(string Query)
        {
            string server = ConfigurationManager.AppSettings["server"];
            string usuario = ClsEncrip.DecryptString(ConfigurationManager.AppSettings["usuario_DB"]);
            string db = "master";
            string pas = ClsEncrip.DecryptString(ConfigurationManager.AppSettings["clave_DB"]);
            SqlConnection cnn = null;
            string conSQL = "Data Source=" + server
                                + ";Initial Catalog=" + db
                                + ";Persist Security Info=False;User ID=" + usuario
                                + ";Password=" + pas;

            cnn = new SqlConnection(conSQL);
            try
            {
                cnn.Open();
                string QueryComando = "";
                try
                {
                    //get the script
                    string scriptText = Query;
                    
                    //split the script on "GO" commands
                    string[] splitter = new string[] { "\r\nGO\r\n" };
                    string[] commandTexts = scriptText.Split(splitter,
                      StringSplitOptions.RemoveEmptyEntries);
                    foreach (string commandText in commandTexts)
                    {
                        try
                        {
                            QueryComando = commandText;
                            //execute commandText
                            SqlCommand comando = new SqlCommand(commandText, cnn);
                            comando.CommandType = CommandType.Text;
                            comando.ExecuteNonQuery();
                        }
                        catch (Exception expr) {
                            ///creamos un log de errores
                            this.InsertaRegistroLog(expr.ToString(), QueryComando);
                            return expr.ToString();
                        }
                    }
                    return "La base de datos fue creada con exito.";
                }
                catch (Exception expr) 
                {
                    
                    cnn.Close();
                    this.InsertaRegistroLog(expr.ToString(),QueryComando);
                    return expr.ToString();
                }
                
            }
            catch (Exception exp)
            {
                return exp.ToString();
            }
        }
        public SqlConnection ConexionSQL()
        {
            string server = ConfigurationManager.AppSettings["server"];
            string usuario = ConfigurationManager.AppSettings["usuario_DB"];
            string db = ConfigurationManager.AppSettings["DB"];
            string pas = ConfigurationManager.AppSettings["clave_DB"];
            SqlConnection cnn = null;
            string conSQL = "";
            if (usuario == "")
            {
                conSQL = "Data Source=" + server
                                + ";Initial Catalog=" + db
                                + ";Persist Security Info=False";

            }
            else
            {
                conSQL = "Data Source=" + server
                                + ";Initial Catalog=" + db
                                + ";Persist Security Info=False;User ID=" + usuario
                                + ";Password=" + pas;
            }
            cnn = new SqlConnection(conSQL);
            try
            {
                cnn.Open();
            }
            catch (Exception exp)
            {
                this.InsertaRegistroLog(exp.ToString(), conSQL);
            }
            return cnn;

        }

        public DataTable Consultasql(string query)
        {
            SqlConnection cnn = ConexionSQL();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand commando = new SqlCommand(query, cnn);
            commando.CommandTimeout = 5 * 60;
            adapter.SelectCommand = commando;
            try
            {
                adapter.Fill(dt);
            }
            catch (Exception exp)
            {
                Classes.Class_Logs ClsLog = new Classes.Class_Logs();
                this.InsertaInformacion(exp.ToString(), "consulta");
            }
            cnn.Close();
            return dt;
        }

        public int NumeroFilas(string query)
        {
            SqlConnection cnn = ConexionSQL();

            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            SqlCommand commando = new SqlCommand(query, cnn);
            commando.CommandTimeout = 5 * 60;
            adapter.SelectCommand = commando;

            adapter.Fill(dt);
            cnn.Close();
            int numero = dt.Rows.Count;

            return numero;
        }

        public bool InsertaSql(string Query)
        {
            SqlConnection cnn = ConexionSQL();
            try
            {
                SqlCommand comando = new SqlCommand(Query, cnn);
                comando.ExecuteNonQuery();
            }
            catch(Exception exp) 
            {
                this.InsertaInformacion(exp.ToString(), "inserta");
                return false;
            }
            cnn.Close();
            return true;


        }
        public static void Closeconection(SqlConnection cnn)
        {
            cnn.Close();
        }



        /////////////////LOG LOCAL
        public bool InsertaInformacion(string vchXml, string msg)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = this.ConexionSQL();

            string usuariolog = Convert.ToString(Classes.Class_Session.Idusuario);
            string sql = "INSERT INTO catLogServicioTim  " +
                " (dfecha, vchXlm , vchMesajeResp) " +
                    " values " +
                " (GETDATE(),  @vchXlm, @vchMesajeResp)";
            cmd.CommandText = sql;
            cmd.Parameters.Add("@vchXlm", SqlDbType.NText);
            cmd.Parameters.Add("@vchMesajeResp", SqlDbType.Char);
            cmd.Parameters["@vchXlm"].Value = vchXml;
            cmd.Parameters["@vchMesajeResp"].Value = msg;
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
        ///////////////////////////////////////////////////////log tem
        public void InsertaRegistroLog(string respuesta, string consulta)
        {
            CreaDirectorios("C:/temp/");
            string archivoLog = "C:/temp/iflex.log";
            InsertaLog(" " + respuesta + " \r\n " + consulta, archivoLog);
        }
        public static void InsertaLog(string msg, string FILE_NAME)
        {
            try
            {
                if (!File.Exists(FILE_NAME))
                {
                    StreamWriter sw = File.CreateText(FILE_NAME);
                    sw.WriteLine("------------------www.flexor.mx -------------------");
                    sw.Close();
                }
                File.AppendAllText(FILE_NAME, DateTime.Now.ToString() + "\r\n" + msg);
            }
            catch { }
        }
        private static void CreaDirectorios(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                //byte[] salt1 = new byte[16];//Create a 32 byte salt
                //Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, salt1, 10000);
                

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}
