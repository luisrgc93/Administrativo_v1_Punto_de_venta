using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Catalogos.Local
{
    public partial class Form_Mesas : Form
    {
        string idmesa = "";
        Classes.Catalogos.Local.Class_Areas ClsAre = new Classes.Catalogos.Local.Class_Areas();
        Classes.Catalogos.Local.Class_Mesas ClsMes = new Classes.Catalogos.Local.Class_Mesas();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();

        public event Form1.MessageHandler Lista_Mesas;

        public Form_Mesas(string temp)
        {
            InitializeComponent();
            idmesa = temp;
        }

        private void Form_Mesas_Load(object sender, EventArgs e)
        {
            llenarCombo();

            if (idmesa != "")
            {
                llenarCampos();
            }
        }

        public void llenarCombo()
        {
            DataTable area = new DataTable();
            area = ClsAre.getAreaAll();

            comboBox_area.DataSource = area;
            comboBox_area.DisplayMember = "nombre";
            comboBox_area.ValueMember = "id";
        }

        public void llenarCampos()
        {
            DataTable mesa = new DataTable();
            mesa = ClsMes.obtener_mesa(idmesa);

            DataRow row = mesa.Rows[0];

            comboBox_area.SelectedValue = row["iidArea"].ToString();
            textBox_Descripcion.Text = row["vchDescripcion"].ToString();

            if (row["iPosicionX"].ToString() != "" && row["iPosicionX"].ToString() != "0" )
            {
                label3.Visible = true;
                button_Restaurar.Visible = true;
            }
            else {
                label3.Visible = false;
                button_Restaurar.Visible = false;
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (textBox_Descripcion.Text == "")
            {
                MessageBox.Show("Favor de llenar todos los campos");
                return;
            }

            if (comboBox_area.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Favor de seleccionar un area");
                return;
            }

            DataTable Info = new DataTable();
            DataRow row;

            Info.Columns.Add("idmesa", System.Type.GetType("System.String"));
            Info.Columns.Add("idarea", System.Type.GetType("System.String"));
            Info.Columns.Add("Descripcion", System.Type.GetType("System.String"));

            row = Info.NewRow();
            row["idmesa"] = idmesa;
            row["idarea"] = comboBox_area.SelectedValue.ToString();
            row["Descripcion"] = textBox_Descripcion.Text;
            Info.Rows.Add(row);

            if (idmesa == "")
            {
                    if (ClsMes.inserta_mesa(Info))
                    {
                        MessageBox.Show("Area guardada exitosamente");
                        try
                        {
                            Lista_Mesas();
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
                            row_Excepcion["vchLugar"] = "Form_Mesas";
                            row_Excepcion["vchAccion"] = "Cargar lista_mesas(), al insertar mesa nueva";
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
                if (ClsMes.actualiza_mesa(Info))
                {
                    MessageBox.Show("Area actualizada exitosamente");
                    try
                    {
                        Lista_Mesas();
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

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Restaurar_Click(object sender, EventArgs e)
        {
            if (ClsMes.restaurarPosicionMesas(idmesa))
            {
                MessageBox.Show("Restaurado con exito");
                this.Close();
            }
            else
            {
                MessageBox.Show("Problema al resutaurar posicion de la mesa"); return;
            }
        }
    }
}
