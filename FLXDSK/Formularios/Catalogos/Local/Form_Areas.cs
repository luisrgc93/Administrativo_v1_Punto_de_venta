using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using aejw.Network;
using System.Configuration;
using System.Security.Cryptography;

namespace FLXDSK.Formularios.Catalogos.Local
{
    public partial class Form_Areas : Form
    {
        string idarea = "";
        string imagenName = "";
        string rutaOriginal = "";
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        Classes.Catalogos.Local.Class_Areas ClsAre = new Classes.Catalogos.Local.Class_Areas();
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        public event Form1.MessageHandler Lista_Areas;

        public Form_Areas(string temp)
        {           
            InitializeComponent();
            idarea = temp;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            string nombre = textBox_Nombre.Text;
            string descripcion = textBox_Descripcion.Text;

            if (nombre == "" || descripcion == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }


            DataTable Info = new DataTable();
            DataRow row;

            Info.Columns.Add("idArea", System.Type.GetType("System.String"));
            Info.Columns.Add("Nombre", System.Type.GetType("System.String"));
            Info.Columns.Add("Descripcion", System.Type.GetType("System.String"));
            Info.Columns.Add("imagen", System.Type.GetType("System.Byte[]"));

            row = Info.NewRow();
            row["idArea"] = idarea;
            row["Nombre"] = textBox_Nombre.Text;
            row["Descripcion"] = textBox_Descripcion.Text;
            row["imagen"] = GetImagen();
            Info.Rows.Add(row);

            if(idarea == "")
            {
                if (!ClsAre.existe_area(textBox_Nombre.Text))
                {
                    if (ClsAre.inserta_area(Info))
                    {
                        MessageBox.Show("Area guardada exitosamente");
                        try
                        {
                            Lista_Areas();
                            this.Close();
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
                            row_Excepcion["vchLugar"] = "Form_Areas";
                            row_Excepcion["vchAccion"] = "Cargar lista_areas(), al insertar area nueva";
                            Info_Excepcion.Rows.Add(row_Excepcion);

                            ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Probleamas al guardar. Intente mas tarde");
                    }
                }
                else
                {
                    MessageBox.Show("El nombre para el area que desea registrar ya existe");
                    return;
                }
            }
            else
            {
                if (ClsAre.actualiza_area(Info))
                {
                    MessageBox.Show("Area actualizada exitosamente");
                    try
                    {
                        Lista_Areas();
                        this.Close();
                    }
                    catch (Exception exc)
                    {
                        DataTable Info_Excepcion = new DataTable();
                        DataRow row_Excepcion;

                        Info_Excepcion.Columns.Add("vchExcepcion", System.Type.GetType("System.String"));
                        Info_Excepcion.Columns.Add("vchLugar", System.Type.GetType("System.String"));
                        Info_Excepcion.Columns.Add("vchAccion", System.Type.GetType("System.String"));

                        row_Excepcion = Info_Excepcion.NewRow();
                        row_Excepcion["vchExcepcion"] = exc;
                        row_Excepcion["vchLugar"] = "Form_Areas";
                        row_Excepcion["vchAccion"] = "Cargar lista_areas(), al actualizar area";
                        Info_Excepcion.Rows.Add(row_Excepcion);

                        ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                    }
                }
                else
                {
                    MessageBox.Show("Probleamas al actualizar. Intente mas tarde");
                }
            }
        }

        private void Form_Areas_Load(object sender, EventArgs e)
        {
            if (idarea != "")
            {
                DataTable Tabla_area = ClsAre.obtener_area(idarea);

                DataRow row = Tabla_area.Rows[0];
                string Nombre = row["vchNombre"].ToString();
                string descripcion = row["vchDescripcion"].ToString();

                textBox_Nombre.Text = Nombre;
                textBox_Descripcion.Text = descripcion;
                try
                {
                    byte[] dibujoByteArray = (byte[])row["IFileImagen"];
                    if (dibujoByteArray != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        ms.Write(dibujoByteArray, 0, dibujoByteArray.Length);
                        System.Drawing.Bitmap b = new Bitmap(ms);
                        pictureBox_Areas.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox_Areas.Image = new System.Drawing.Bitmap(b);
                    }
                }
                catch
                {
                }

            }
        }
        private byte[] GetImagen()
        {
            try
            {
                Image dibujo = new Bitmap(pictureBox_Areas.Image);
                ImageConverter converter = new ImageConverter();
                return (byte[])converter.ConvertTo(dibujo, typeof(byte[]));
            }
            catch
            {
                return null;
            }
        }
        private void pictureBox_Areas_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox_Areas.Image = Image.FromFile(dialog.FileName);
                rutaOriginal = dialog.FileName;
                imagenName = Path.GetFileName(dialog.FileName);

            }
        }

    }
}
