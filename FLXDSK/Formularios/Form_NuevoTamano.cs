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
    public partial class Form_NuevoTamano : Form
    {
        public event Form1.MessageHandler llenarCombo;
        public event Form1.MessageHandler CargaAreas;
        Classes.Class_Tamanos fnTamanos = new Classes.Class_Tamanos();
        Classes.Catalogos.Local.Class_Mesas fnMesas = new Classes.Catalogos.Local.Class_Mesas();

        string iidMesa = "";
        string iidTamano = "";

        public Form_NuevoTamano(string idMesa, string idTamano)
        {
            InitializeComponent();
            iidMesa = idMesa;
            iidTamano = idTamano;
        }
        
        private void button_Aceptar_Click(object sender, EventArgs e)
        {
            if (textBox_TamanoX.Text == "" || textBox_TamanoY.Text == "" || textBox_Nombre.Text == "") { MessageBox.Show("Favor de llenar todos los campos."); return; }

            if (iidMesa == "")
            {
                if (fnTamanos.InsertNuevoTamano(textBox_TamanoX.Text, textBox_TamanoY.Text, textBox_Nombre.Text))
                {
                    llenarCombo();
                    this.Close();
                }
            }
            else
            {
                if (fnTamanos.ActualizaTamano(textBox_TamanoX.Text, textBox_TamanoY.Text, textBox_Nombre.Text, iidTamano))
                {
                    if (fnMesas.nuevoTamano(iidMesa, textBox_TamanoX.Text, textBox_TamanoY.Text))
                    {
                        llenarCombo();
                        this.Close();
                    }
                }
            
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox_TamanoX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool punto_decimales = false;
            int cantidad_decimales = 0;

            for (int i = 0; i < textBox_TamanoX.Text.Length; i++)
            {
                if (textBox_TamanoX.Text[i] == '.')
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

        private void textBox_TamanoY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool punto_decimales = false;
            int cantidad_decimales = 0;

            for (int i = 0; i < textBox_TamanoY.Text.Length; i++)
            {
                if (textBox_TamanoY.Text[i] == '.')
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

        private void Form_NuevoTamano_Load(object sender, EventArgs e)
        {
            if (iidMesa != "")
            {
                string tamanoX = fnMesas.getTamanoXMesa(Convert.ToInt32(iidMesa));
                string tamanoY = fnMesas.getTamanoYMesa(Convert.ToInt32(iidMesa));
                string nombre = fnMesas.getnombreTamanoMesa(tamanoX, tamanoY);

                textBox_TamanoX.Text = tamanoX;
                textBox_TamanoY.Text = tamanoY;
                textBox_Nombre.Text = nombre;
            }
        }
    }
}
