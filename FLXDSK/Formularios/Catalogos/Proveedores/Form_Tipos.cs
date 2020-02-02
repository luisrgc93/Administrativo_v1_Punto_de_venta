using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Catalogos.Proveedores
{
    public partial class Form_Tipos : Form
    {
        string idtipo = "";
        Classes.Catalogos.Proveedores.Class_Proveedores ClsProv = new Classes.Catalogos.Proveedores.Class_Proveedores();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();

        public event Form1.MessageHandler Lista_Tipos;
        public Form_Tipos(string temp)
        {
            InitializeComponent();
            idtipo = temp;
        }

        private void Form_Tipos_Load(object sender, EventArgs e)
        {
            if (idtipo != "")
            {
                DataTable Tabla_area = ClsProv.obtener_tipo_proveedor_x_id(idtipo);

                DataRow row = Tabla_area.Rows[0];
                string Nombre = row["vchNombre"].ToString();
                string descripcion = row["vchDescripcion"].ToString();

                textBox_Nombre.Text = Nombre;
                textBox_Descripcion.Text = descripcion;
            }
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

            Info.Columns.Add("idTipo", System.Type.GetType("System.String"));
            Info.Columns.Add("Nombre", System.Type.GetType("System.String"));
            Info.Columns.Add("Descripcion", System.Type.GetType("System.String"));

            row = Info.NewRow();
            row["idTipo"] = idtipo;
            row["Nombre"] = textBox_Nombre.Text;
            row["Descripcion"] = textBox_Descripcion.Text;
            Info.Rows.Add(row);

            if (idtipo == "")
            {                
                if (ClsProv.inserta_tipo_proveedor(Info))
                {
                    MessageBox.Show("Tipo guardada exitosamente");
                    try
                    {
                        Lista_Tipos();
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
                if (ClsProv.actualiza_tipo_proveedor(Info))
                {
                    MessageBox.Show("Tipo actualizada exitosamente");
                    try
                    {
                        Lista_Tipos();
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
    }
}
