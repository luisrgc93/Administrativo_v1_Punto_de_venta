using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aejw.Network;
using System.Configuration;
using System.IO;

namespace FLXDSK.Formularios.Catalogos.Mercancia
{
    public partial class Form_Categorias : Form
    {
        string idcategoria = "";
        string imagenName = "";
        string rutaOriginal = "";
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Catalogos.Mercancia.Class_Categorias ClsCat = new Classes.Catalogos.Mercancia.Class_Categorias();
        public event Form1.MessageHandler Lista_Categoria;

        public Form_Categorias(string temp)
        {
            InitializeComponent();
            idcategoria = temp;
        }
        
        private void button_Guardar_Click(object sender, EventArgs e)
        {
            string nombre = textBox_Nombre.Text;
            string descripcion = textBox_Descripcion.Text;

            if (nombre == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }


           

            if (idcategoria == "")
            {
                if (!ClsCat.existe_categoria(textBox_Nombre.Text))
                {

                    DataTable Info = new DataTable();
                    DataRow row;
                    
                    Info.Columns.Add("idCategoria", System.Type.GetType("System.String"));
                    Info.Columns.Add("Nombre", System.Type.GetType("System.String"));
                    Info.Columns.Add("Descripcion", System.Type.GetType("System.String"));
                    Info.Columns.Add("imagen", System.Type.GetType("System.Byte[]"));

                    row = Info.NewRow();
                    row["idCategoria"] = "";
                    row["Nombre"] = textBox_Nombre.Text;
                    row["Descripcion"] = textBox_Descripcion.Text;
                    row["imagen"] = GetImagen();
                    Info.Rows.Add(row);

                    if (ClsCat.inserta_categoria(Info))
                    {
                        MessageBox.Show("Categoria guardada exitosamente");
                        try
                        {
                            try
                            {
                                Lista_Categoria();
                            }
                            catch { }
                            this.Close();
                        }
                        catch
                        {
                        }
                    }
                    else
                    {
                        MessageBox.Show("Probleamas al guardar. Intente mas tarde");
                    }
                }
                else
                {
                    MessageBox.Show("El nombre para la categoria que desea registrar ya existe");
                    return;
                }
            }
            else
            {


                DataTable Info = new DataTable();
                DataRow row;
                Info.Columns.Add("idCategoria", System.Type.GetType("System.String"));
                Info.Columns.Add("Nombre", System.Type.GetType("System.String"));
                Info.Columns.Add("Descripcion", System.Type.GetType("System.String"));
                Info.Columns.Add("imagen", System.Type.GetType("System.Byte[]"));

                row = Info.NewRow();
                row["idCategoria"] = idcategoria;
                row["Nombre"] = textBox_Nombre.Text;
                row["Descripcion"] = textBox_Descripcion.Text;
                row["imagen"] = GetImagen();
                Info.Rows.Add(row);

                if (ClsCat.actualiza_categoria(Info))
                {
                    MessageBox.Show("Categoria actualizada exitosamente");
                    try
                    {
                        try
                        {
                            Lista_Categoria();
                        }
                        catch { }
                        this.Close();
                    }
                    catch
                    {
                    }
                }
                else
                {
                    MessageBox.Show("Probleamas al actualizar. Intente mas tarde");
                }
            }
        }

        private byte[] GetImagen()
        {
            try
            {
                Image dibujo = new Bitmap(pictureBox_categoria.Image);
                ImageConverter converter = new ImageConverter();
                return (byte[])converter.ConvertTo(dibujo, typeof(byte[]));
            }
            catch
            {
                return null;
            }
        }

        private void Form_Categorias_Load(object sender, EventArgs e)
        {

            if (idcategoria != "")
            {
                DataTable Tabla_categoria = ClsCat.obtener_categoria(idcategoria);

                DataRow row = Tabla_categoria.Rows[0];
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
                        pictureBox_categoria.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox_categoria.Image = new System.Drawing.Bitmap(b);
                    }
                }
                catch
                {
                }

            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_categoria_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox_categoria.Image = Image.FromFile(dialog.FileName);
                rutaOriginal = dialog.FileName;
                imagenName = Path.GetFileName(dialog.FileName);
            }
        }

    }
}
