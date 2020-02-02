using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios
{
    public partial class Form_GastosFijos : Form
    {
        string idGasto = "";
        Classes.Class_GastosFijos fnGastosFijos = new Classes.Class_GastosFijos();
        public event Form1.MessageHandler lista_Gastos;

        public Form_GastosFijos(string iidGasto)
        {
            InitializeComponent();
            idGasto = iidGasto;
        }
        private void Form_GastosFijos_Load(object sender, EventArgs e)
        {
            dateTimePicker_inicio.Format = DateTimePickerFormat.Custom;
            dateTimePicker_inicio.CustomFormat = "dd/MM/yyyy";
            dateTimePicker_fin.Format = DateTimePickerFormat.Custom;
            dateTimePicker_fin.CustomFormat = "dd/MM/yyyy";

            label_Mensaje.Visible = true;

            if (idGasto != "")
            {
                llenarDatos();
            }
        }
        public void llenarDatos()
        {
            DataTable datos = new DataTable();
            datos = fnGastosFijos.obtener_datos_xID(idGasto);

            DataRow row = datos.Rows[0];

            textBox_Tipo.Text = row["tipo"].ToString();
            textBox_Monto.Text = row["monto"].ToString();            
            textBox_Descripcion.Text = row["descripcion"].ToString();

            if (row["siMensual"].ToString() == "1") { checkBox_SiMensual.Checked = true; label_Mensaje.Visible = false; }
            else { checkBox_SiMensual.Checked = false; label_Mensaje.Visible = true; }

            DateTime ini = Convert.ToDateTime(row["inicio"].ToString());
            DateTime fin = Convert.ToDateTime(row["fin"].ToString());
            dateTimePicker_fin.Value = fin;
            dateTimePicker_inicio.Value = ini;
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (textBox_Tipo.Text == "0" || textBox_Descripcion.Text == "" || textBox_Monto.Text == "") { MessageBox.Show("Favor de llenar los datos necesarios (*)."); return; }

            string[] varI = dateTimePicker_inicio.Text.Split('/', ' ', ':');
            string inicio = varI[2] + "-" + varI[1] + "-" + varI[0] + "T00:00:00";

            string[] varF = dateTimePicker_fin.Text.Split('/', ' ', ':');
            string final = varF[2] + "-" + varF[1] + "-" + varF[0] + "T23:59:00";

            DateTime ini = Convert.ToDateTime(inicio);
            DateTime fin = Convert.ToDateTime(final);
            DateTime fechaActual = DateTime.Now;

            if (ini > fin)
            {
                MessageBox.Show("La fecha final no pude ser menor a la inicial.");
                return;
            }

            DataTable Info = new DataTable();
            DataRow row;

            Info.Columns.Add("tipo", System.Type.GetType("System.String"));
            Info.Columns.Add("monto", System.Type.GetType("System.String"));
            Info.Columns.Add("descripcion", System.Type.GetType("System.String"));
            Info.Columns.Add("inicio", System.Type.GetType("System.String"));
            Info.Columns.Add("fin", System.Type.GetType("System.String"));
            Info.Columns.Add("idGasto", System.Type.GetType("System.String"));
            Info.Columns.Add("siMensual", System.Type.GetType("System.String"));

            row = Info.NewRow();
            row["idGasto"] = idGasto;
            row["tipo"] = textBox_Tipo.Text;
            row["monto"] = textBox_Monto.Text;
            row["descripcion"] = textBox_Descripcion.Text;
            row["inicio"] = inicio;
            row["fin"] = final;
            if (checkBox_SiMensual.Checked == true) { row["siMensual"] = "1"; }
            else { row["siMensual"] = "0"; }
            
            Info.Rows.Add(row);

            if (idGasto == "")
            {
                if (fnGastosFijos.inserta_pago(Info))
                {
                    MessageBox.Show("pago guardado con exito.");
                    try
                    {
                        lista_Gastos();
                        this.Close();
                    }
                    catch { }                    
                }
                else
                {
                    MessageBox.Show("Problemas al guardar el pago, intente mas tarde.");
                }
            }
            else
            {
                if (fnGastosFijos.actualiza_pago(Info))
                {
                    MessageBox.Show("pago actualizado con exito.");
                    try
                    {
                        lista_Gastos();
                        this.Close();
                    }
                    catch { }                    
                }
                else
                {
                    MessageBox.Show("Problemas al actualizar el pago, intente mas tarde.");
                }
            }
        }

        private void textBox_Monto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool punto_decimales = false;
            int cantidad_decimales = 0;

            for (int i = 0; i < textBox_Monto.Text.Length; i++)
            {
                if (textBox_Monto.Text[i] == '.')
                    punto_decimales = false;

                if (punto_decimales && cantidad_decimales++ >= 2)
                {
                    e.Handled = false;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (punto_decimales) ? false : false;
            else
                e.Handled = true;
        }
        private void checkBox_SiMensual_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_SiMensual.Checked == true) { label_Mensaje.Visible = false; }
            else { label_Mensaje.Visible = true; }
        }
    }
}
