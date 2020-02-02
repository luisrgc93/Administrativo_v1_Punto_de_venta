using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Catalogos.Mercancia
{
    public partial class Form_MateriaPrima : Form
    {
        string idPassText = "";


        Classes.Catalogos.Mercancia.Class_Materia_Prima ClsMateriaPrima = new Classes.Catalogos.Mercancia.Class_Materia_Prima();
        Classes.Catalogos.Mercancia.Class_Materia_Prima_Categoria ClsCategoriaMatPrima = new Classes.Catalogos.Mercancia.Class_Materia_Prima_Categoria();
        Classes.Internos.Class_UnidadesMetricas ClsUnidadMetrica = new Classes.Internos.Class_UnidadesMetricas();

        public event Form1.MessageHandler CargaLista;



        public Form_MateriaPrima(string id)
        {
            InitializeComponent();
            idPassText = id;
        }

        private void LlenadoCategorias()
        {
            DataTable dtInfo = ClsCategoriaMatPrima.getListaWhere(" WHERE iidEstatus = 1 ORDER BY vchDescripcion ASC ");
            comboBox_Categoria.DataSource = dtInfo;
            comboBox_Categoria.DisplayMember = "vchDescripcion";
            comboBox_Categoria.ValueMember = "iidCategoriaMateriPrima";
        }
        public void LlenadoUnidades()
        {
            DataTable dtInfo = ClsUnidadMetrica.getListaWhere(" WHERE iidEstatus = 1 ");
            comboBox_UnidadMetrica.DataSource = dtInfo;
            comboBox_UnidadMetrica.DisplayMember = "vchNombre";
            comboBox_UnidadMetrica.ValueMember = "iidUnidad";
        }
        public void getInfoId()
        {
            DataTable dtInfo = ClsMateriaPrima.getListaWhere(" WHERE iidMateriPrima = " + idPassText);
            if (dtInfo.Rows.Count == 0)
            {
                MessageBox.Show("Informacion No encontrada");
                this.Close();
                return;
            }

            if (dtInfo.Rows[0]["siInventariar"].ToString() == "1")
                checkBox_Inventariar.Checked = true;

            textBox_Codigo.Text = dtInfo.Rows[0]["vchCodigo"].ToString();
            textBox_Descripcion.Text = dtInfo.Rows[0]["vchDescripcion"].ToString();
            textBox_Costo.Text = dtInfo.Rows[0]["fCosto"].ToString();
            textBox_CostoProm.Text = dtInfo.Rows[0]["fCostoPromedio"].ToString();
            textBox_Stock.Text = dtInfo.Rows[0]["fStockMinimo"].ToString();
            textBox_Contenido.Text = dtInfo.Rows[0]["fContenido"].ToString();

            try
            {
                comboBox_Categoria.SelectedValue = dtInfo.Rows[0]["iidCategoriaMateriPrima"].ToString();
            }
            catch{}
            try
            {
                comboBox_UnidadMetrica.SelectedValue = dtInfo.Rows[0]["iidUnidad"].ToString();
            }
            catch{}
            comboBox_UnidadMetrica.Enabled = false;
        }
        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_MateriaPrima_Load(object sender, EventArgs e)
        {
            LlenadoUnidades();
            LlenadoCategorias();

            if (idPassText != "")
                getInfoId();
        }

        

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            string IdCategoria = "";
            string IdUnidad = "";
            double fCosto = 0;
            int IStock = 0;
            double contenido = 0;
            string siInventariar = "0";
            try
            {
                IdCategoria = comboBox_Categoria.SelectedValue.ToString();
            }
            catch { }
            try
            {
                IdUnidad = comboBox_UnidadMetrica.SelectedValue.ToString();
            }
            catch { }
            

            if (IdCategoria == "")
            { 
                MessageBox.Show("Favor de seleccionar una categoría"); 
                return; 
            }
            if (IdUnidad == "")
            {
                MessageBox.Show("Favor de seleccionar una Unidad");
                return;
            }

            if (textBox_Descripcion.Text.Trim() == "" || textBox_Costo.Text.Trim() == "") 
            { 
                MessageBox.Show("Llenar los campos requeridos"); 
                return; 
            }
            try
            {
                fCosto = Convert.ToDouble(textBox_Costo.Text);
            }
            catch
            {
                MessageBox.Show("El costo solo debe de contener numeros.");
                return;
            }

            try
            {
                if(textBox_Stock.Text.Trim() !="")
                    IStock = Convert.ToInt32(textBox_Stock.Text.Trim());
            }
            catch
            {
                MessageBox.Show("El stock deve ser numerico.");
                return;
            }

            try
            {
                if (textBox_Contenido.Text.Trim() != "")
                    contenido = Convert.ToInt32(textBox_Contenido.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Ingresa el contenido del producto ejemplo: si contiene 1 litro/kilo = 1000 ");
                return;
            }

            if (checkBox_Inventariar.Checked)
                siInventariar = "1";
            

            if (idPassText == "")
            {
                if (textBox_Codigo.Text.Trim() != "")
                {
                    DataTable dtExisCodigo = ClsMateriaPrima.getListaWhere(" WHERE vchCodigo= '" + textBox_Codigo.Text.Trim() + "' AND iidEstatus = 1 ");
                    if (dtExisCodigo.Rows.Count > 0)
                    {
                        MessageBox.Show("Este código ya existe, elegir otro"); 
                        return; 
                    }
                }

                DataTable dtExis = ClsMateriaPrima.getListaWhere(" WHERE vchDescripcion= '" + textBox_Descripcion.Text.Trim() + "' AND iidEstatus = 1 ");
                if (dtExis.Rows.Count > 0)
                {
                    MessageBox.Show("Este Nombre ya existe, elegir otro");
                    return;
                }

                if (ClsMateriaPrima.InsertaInformacion(siInventariar, textBox_Codigo.Text.Trim(), textBox_Descripcion.Text.Trim(), fCosto, IStock, IdCategoria, IdUnidad,contenido))
                {
                    MessageBox.Show("Guardada con exito.");
                    try
                    {
                        CargaLista();
                    }
                    catch { }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problema al Guardar, contacte al Administrador");
                    return;
                }
            }
            else
            {
                if (textBox_Codigo.Text.Trim() != "")
                {
                    DataTable dtExisCodigo = ClsMateriaPrima.getListaWhere(" WHERE vchCodigo= '" + textBox_Codigo.Text.Trim() + "' AND iidEstatus = 1 AND iidMateriPrima <> "+idPassText);
                    if (dtExisCodigo.Rows.Count > 0)
                    {
                        MessageBox.Show("Este código ya existe, elegir otro");
                        return;
                    }
                }

                DataTable dtExis = ClsMateriaPrima.getListaWhere(" WHERE vchDescripcion= '" + textBox_Descripcion.Text.Trim() + "' AND iidEstatus = 1 AND iidMateriPrima <> " + idPassText);
                if (dtExis.Rows.Count > 0)
                {
                    MessageBox.Show("Este Nombre ya existe, elegir otro");
                    return;
                }

                if (ClsMateriaPrima.ActualizaInformacion(siInventariar,textBox_Codigo.Text.Trim(), textBox_Descripcion.Text.Trim(), fCosto, IStock, IdCategoria, IdUnidad , idPassText,contenido))
                {
                    MessageBox.Show("Actualizada con exito.");
                    try
                    {
                        CargaLista();
                    }
                    catch { }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problema al Guardar, contacte al Administrador");
                    return;
                }

            }
        }

        private void button_AddCatMatPrima_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Mercancia.Form_Categoria_MateriaPrima FormCat = new Form_Categoria_MateriaPrima("");
            FormCat.ShowDialog();

            LlenadoCategorias();
        }
    }
}
