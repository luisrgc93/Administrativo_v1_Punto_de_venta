using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Facturacion
{
    public partial class Form_Series : Form
    {
        public event Form1.MessageHandler CargaLista;

        string idPassText = "";
        Classes.Facturas.Class_Series ClsSeries = new Classes.Facturas.Class_Series();
        Classes.SAT.Class_Estados ClsEstados = new Classes.SAT.Class_Estados();


        public Form_Series(string id)
        {
            InitializeComponent();
            idPassText = id;
        }
        private void CargaEstados()
        {
            DataTable dtEstados = ClsEstados.getListaWhere(" WHERE iidEstatus = 1 ");
            comboBox_Estado.DataSource = dtEstados;
            comboBox_Estado.DisplayMember = "vchNombre";
            comboBox_Estado.ValueMember = "iidEstado";
        }


        private void Form_Series_Load(object sender, EventArgs e)
        {
            CargaEstados();

            if (idPassText != "")
                CargaInfoById();
            
        }
        private void CargaInfoById()
        {
            DataTable dtInfo = ClsSeries.getListaWhere(" WHERE iidSerie = " + idPassText);
            if (dtInfo.Rows.Count == 0)
            {
                MessageBox.Show("Informacion no  encontrada");
                this.Close();
                return;
            }


            textBox_Alias.Text = dtInfo.Rows[0]["vchNombre"].ToString();
            textBox_Serie.Text = dtInfo.Rows[0]["vchSerie"].ToString();
            textBox_Folio.Text = dtInfo.Rows[0]["iFolio"].ToString();

            textBox_Calle.Text = dtInfo.Rows[0]["vchCalle"].ToString();
            textBox_NumExt.Text = dtInfo.Rows[0]["vchNumExt"].ToString();
            textBox_NumInt.Text = dtInfo.Rows[0]["vchNumInt"].ToString();
            textBox_Colonia.Text = dtInfo.Rows[0]["vchColonia"].ToString();
            textBox_Municipio.Text = dtInfo.Rows[0]["vchMunicipio"].ToString();
            textBox_CP.Text= dtInfo.Rows[0]["vchCP"].ToString();
            try
            {
                comboBox_Estado.SelectedValue = dtInfo.Rows[0]["iidEstado"].ToString();
            }catch{}

        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            string Edo = "";
            try
            {
                Edo = comboBox_Estado.SelectedValue.ToString();
            }
            catch { }

            if (textBox_Alias.Text.Trim() == "")
            {
                MessageBox.Show("Alias Requerido");
                return;
            }
            if (textBox_Serie.Text.Trim() == "")
            {
                MessageBox.Show("Serie Requerido");
                return;
            }
            if (textBox_Folio.Text.Trim() == "")
            {
                MessageBox.Show("Folio Requerido");
                return;
            }
            if (textBox_CP.Text.Trim() == "")
            {
                MessageBox.Show("C.P. Requerido");
                return;
            }
            if(Edo=="" || Edo=="0")
            {
                MessageBox.Show("Estado Requerido");
                return;
            }

            try
            {
                Convert.ToInt32(textBox_Folio.Text.Trim());
            }
            catch 
            {
                MessageBox.Show("Folio debe ser numerico");
                return;
            }

            string Alias =textBox_Alias.Text.Trim();
            string Ser =textBox_Serie.Text.Trim();
            string Fol =textBox_Folio.Text.Trim();

            string Calle =textBox_Calle.Text.Trim();
            string NumExt =textBox_NumExt.Text.Trim();
            string NumIn =textBox_NumInt.Text.Trim();
            string Col =textBox_Colonia.Text.Trim();
            string Mun =textBox_Municipio.Text.Trim();
            string CP =textBox_CP.Text.Trim();
            

            if (idPassText == "")
            {
                DataTable dtExis = ClsSeries.getListaWhere(" WHERE iidEstatus = 1 AND vchSerie ='" + Ser + "' ");
                if (dtExis.Rows.Count > 0)
                {
                    MessageBox.Show("La serie " + Ser + ", ya existe utilize otra");
                    return;
                }
                dtExis = ClsSeries.getListaWhere(" WHERE iidEstatus = 1 AND vchAlias ='" + Alias + "' ");
                if (dtExis.Rows.Count > 0)
                {
                    MessageBox.Show("El Alias " + Alias + ", ya existe utilize otra");
                    return;
                }

                if (ClsSeries.InsertaInformacion(Alias, Ser, Fol, Calle, NumExt, NumIn, Col, Mun, CP, Edo))
                {
                    MessageBox.Show("Guardado correctamente");
                    try
                    {
                        CargaLista();
                    }
                    catch { }
                    this.Close();
                    return;
                }
                MessageBox.Show("Problema la guardar, contacte al administrador");
            }
            else
            {
                DataTable dtExis = ClsSeries.getListaWhere(" WHERE iidEstatus = 1 AND vchSerie ='" + Ser + "' AND iidSerie <> "+ idPassText);
                if (dtExis.Rows.Count > 0)
                {
                    MessageBox.Show("La serie " + Ser + ", ya existe utilize otra");
                    return;
                }
                dtExis = ClsSeries.getListaWhere(" WHERE iidEstatus = 1 AND vchAlias ='" + Alias + "' " + "' AND iidSerie <> " + idPassText);
                if (dtExis.Rows.Count > 0)
                {
                    MessageBox.Show("El Alias " + Alias + ", ya existe utilize otra");
                    return;
                }

                if (ClsSeries.ActualizaInformacion(Alias, Ser, Fol, Calle, NumExt, NumIn, Col, Mun, CP, Edo, idPassText))
                {
                    MessageBox.Show("Guardado correctamente");
                    try
                    {
                        CargaLista();
                    }
                    catch { }
                    this.Close();
                    return;
                }
                MessageBox.Show("Problema la guardar, contacte al administrador");
            }

        }
    }
}
