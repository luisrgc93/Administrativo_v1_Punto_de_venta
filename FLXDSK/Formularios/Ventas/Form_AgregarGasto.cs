using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Ventas
{
    public partial class Form_AgregarGasto : Form
    {
        Classes.Ventas.Class_MovimiendoDin ClsMovimiento = new Classes.Ventas.Class_MovimiendoDin();
        Classes.Configuracion.Class_TipoMovimiento ClsTipoMov = new Classes.Configuracion.Class_TipoMovimiento();
        public event Form1.MessageHandler CargarLista;


        public Form_AgregarGasto()
        {
            InitializeComponent();
        }
        public void CartaTiposMotivos()
        {
            DataTable dtTipo = null;
            if (radioButton_Entrada.Checked)
                dtTipo = ClsTipoMov.getListaWhere(" WHERE iidEstatus = 1 AND siEntrada = 1");
            else
                dtTipo = ClsTipoMov.getListaWhere(" WHERE iidEstatus = 1 AND siEntrada = 0");

            comboBox_Motivo.DataSource = dtTipo;
            comboBox_Motivo.DisplayMember = "vchNombre";
            comboBox_Motivo.ValueMember = "iidTipoMovimiento";
        }
        private void Form_AgregarGasto_Load(object sender, EventArgs e)
        {
            CartaTiposMotivos();
        }
        
        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button_Guardar_Click(object sender, EventArgs e)
        {
            string siEntrada = "0";
            if(radioButton_Entrada.Checked)
                siEntrada = "1";

            string iidTipoMovimiento = "";
            try
            {
                iidTipoMovimiento = comboBox_Motivo.SelectedValue.ToString();
            }
            catch { }
            if (iidTipoMovimiento == "")
            {
                MessageBox.Show("Favor de seleccionar el tipo de motivo"); 
                return;
            }

            double Monto = 0;
            try
            {
                Monto = Convert.ToDouble(textBox_Monto.Text);
            }
            catch {
                MessageBox.Show("Monto ingresado incorrecto");
                return;
            }
            if (Monto <= 0)
            {
                MessageBox.Show("Monto ingresado debe ser mayor a cero");
                return;
            }
            if (ClsMovimiento.InsertaInformacion(iidTipoMovimiento, Monto.ToString(), textBox_Descripcion.Text.Trim(), siEntrada))
            {
                MessageBox.Show("pago guardado con exito.");
                try
                {
                    CargarLista();
                        
                }
                catch { }
                this.Close();
            }
            else
            {
                MessageBox.Show("Problemas al guardar el pago, intente mas tarde.");
            }
        }

        private void radioButton_Entrada_CheckedChanged(object sender, EventArgs e)
        {
            CartaTiposMotivos();
        }
    }
}
