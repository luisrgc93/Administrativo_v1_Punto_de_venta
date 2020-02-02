using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FLXDSK.Formularios.Catalogos.Personal
{
    public partial class Form_Puestos : Form
    {
        string IdPasTex = "";
        Classes.Catalogos.Personal.Class_Puestos ClsPue = new Classes.Catalogos.Personal.Class_Puestos();
        public event Form1.MessageHandler CargaListaPuesto;

        public Form_Puestos(string idtemp)
        {
            InitializeComponent();
            IdPasTex = idtemp;
        }

        private void Form_Puestos_Load(object sender, EventArgs e)
        {
            if (IdPasTex == "")
            {
                DataTable dtExisMesero = ClsPue.getListaWhere(" WHERE isMesero = 1 ");
                if (dtExisMesero.Rows.Count > 0)
                    checkBox_IsMesero.Visible = false;
            }
            else
            {
                DataTable dtExisMesero = ClsPue.getListaWhere(" WHERE isMesero = 1 AND iidPuesto <> "+ IdPasTex);
                if (dtExisMesero.Rows.Count > 0)
                    checkBox_IsMesero.Visible = false;



                DataTable dtInfo = ClsPue.getListaWhere(" WHERE iidPuesto = " + IdPasTex);
                if (dtInfo.Rows.Count == 0)
                {
                    MessageBox.Show("Informacion no encontrada");
                    this.Close();
                    return;
                }



                textBox_Propina.Text = dtInfo.Rows[0]["fPropina"].ToString();
                textBox_Nombre.Text = dtInfo.Rows[0]["vchNombre"].ToString();
                if (dtInfo.Rows[0]["isMesero"].ToString() == "1")
                    checkBox_IsMesero.Checked = true;
                else
                    checkBox_IsMesero.Checked = false;

                if (dtInfo.Rows[0]["siRepartoPropina"].ToString() == "1")
                {
                    checkBox_RepartirPropina.Checked = true;
                    label_siDarPropina.Visible = true;
                    textBox_Propina.Visible = true;
                }
                else
                {
                    checkBox_RepartirPropina.Checked = false;
                    label_siDarPropina.Visible = false;
                    textBox_Propina.Visible = false;
                }

            }
        }
        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (textBox_Nombre.Text == "")
            {
                MessageBox.Show("Ingresar los campos requeridos");
                return;
            }
            double Propina = 0;
            if (textBox_Propina.Text.Trim() != "")
            {
                try
                {
                   Propina = Convert.ToDouble(textBox_Propina.Text.Trim());
                }
                catch { }
            }
            string isMesero = "0";
            if (checkBox_IsMesero.Checked)
                isMesero = "1";

            string siRepatirProp = "0";
            if (checkBox_RepartirPropina.Checked)
                siRepatirProp = "1";


            

            if (IdPasTex == "")
            {
                if (siRepatirProp == "1")
                {
                    double Tiene = ClsPue.getSumaPorcentajesActuales(" ");
                    if ((Tiene + Propina) > 100)
                    {
                        MessageBox.Show("El porcentaje de reparto de propinas supera el 100%, ingrese otro porcentaje mas bajo, actualmente se tiene guardado %" + Tiene);
                        return;
                    }

                    if (Propina <= 0)
                    {
                        MessageBox.Show("Ingrese el porcentaje de reparto");
                        return;
                    }
                }


                if (ClsPue.GuardarPuesto(textBox_Nombre.Text.Trim(), Propina, isMesero, siRepatirProp))
                {
                    MessageBox.Show("Guardado Correctamente");
                    try
                    {
                        CargaListaPuesto();
                        this.Close();
                    }
                    catch{ }
                }
                else
                {
                    MessageBox.Show("Problema al Guardar");
                }
            }
            else
            {
                if (siRepatirProp == "1")
                {
                    double Tiene = ClsPue.getSumaPorcentajesActuales(" AND iidPuesto <> "+IdPasTex);
                    if ((Tiene + Propina) > 100)
                    {
                        MessageBox.Show("El porcentaje de reparto de propinas supera el 100%, ingrese otro porcentaje mas bajo, actualmente se tiene guardado %" + Tiene);
                        return;
                    }

                    if (Propina <= 0)
                    {
                        MessageBox.Show("Ingrese el porcentaje de reparto");
                        return;
                    }
                }


                if (ClsPue.ActualizarPueso(textBox_Nombre.Text.Trim(), Propina, isMesero, siRepatirProp, IdPasTex))
                {
                    MessageBox.Show("Actualizado Correctamente");
                    try
                    {
                        CargaListaPuesto();
                        this.Close();
                    }
                    catch 
                   { }
                }
                else
                {
                    MessageBox.Show("Problema al Actualizar");
                }
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox_RepartirPropina_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_RepartirPropina.Checked)
            {
                label_siDarPropina.Visible = true;
                textBox_Propina.Visible = true;
            }
            else
            {
                label_siDarPropina.Visible = false;
                textBox_Propina.Visible = false;
                textBox_Propina.Text = "";
            }
        }

        
    }
}
