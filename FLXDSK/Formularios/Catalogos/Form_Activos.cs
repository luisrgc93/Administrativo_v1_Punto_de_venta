using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Catalogos
{
    public partial class Form_Activos : Form
    {
        Classes.Catalogos.Class_CategorigasActivos ClsCatAct = new Classes.Catalogos.Class_CategorigasActivos();
        Classes.Catalogos.Class_Activos ClsActivos = new Classes.Catalogos.Class_Activos();
        Classes.Inventarios.Class_Almacen ClsAlmacen = new Classes.Inventarios.Class_Almacen();
        public event Form1.MessageHandler cargaListaActivos;
        string iidActivo = "";

        public Form_Activos(string idtmp)
        {
            InitializeComponent();
            iidActivo = idtmp;
        }

        private void Form_Activos_Load(object sender, EventArgs e)
        {
            cargaCategorias();
            cargaAlmacenes();
            if (iidActivo != "") {
                cargaInfoByID();
            }
        }
        private void cargaCategorias() {
            DataTable dt = new DataTable("Tipos");
            dt = ClsCatAct.getTipos();

            comboBox_Categorias.DataSource = dt;
            comboBox_Categorias.DisplayMember = "nombre";
            comboBox_Categorias.ValueMember = "id";
        }
        private void cargaAlmacenes()
        {
            DataTable dt = new DataTable("Tipos");
            dt = ClsAlmacen.getAlmacenesAll();

            comboBox_Almacen.DataSource = dt;
            comboBox_Almacen.DisplayMember = "nombre";
            comboBox_Almacen.ValueMember = "id";
        }

        private void button_Agregar_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Form_CategoriasActivos formActCat = new Form_CategoriasActivos("");
            formActCat.ShowDialog();
            cargaCategorias();
        }
        private void cargaInfoByID() {
            DataTable dtInfo = new DataTable();
            dtInfo = ClsActivos.getInfoById(iidActivo);
            if (dtInfo.Rows.Count > 0) {
                try{
                    comboBox_Categorias.SelectedValue = dtInfo.Rows[0]["iidTipoActivo"].ToString();
                }catch{}
                try
                {
                    comboBox_Almacen.SelectedValue = dtInfo.Rows[0]["iidAlmacen"].ToString();
                }
                catch { }
                
                textBox_Cantidad.Text = dtInfo.Rows[0]["fCantidad"].ToString();
                textBox_Descripcion.Text = dtInfo.Rows[0]["vchDescripcion"].ToString();
                textBox_Precio.Text = dtInfo.Rows[0]["fCostoUnitario"].ToString();
                
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (textBox_Descripcion.Text == "") {
                MessageBox.Show("La descripción es necesaria");
                return;
            }
            string idalmacen = "";
            string idCategoria = "";
            double cantidad = 0;
            double precio = 0;
            try
            {
                idCategoria = comboBox_Categorias.SelectedValue.ToString();
            }
            catch { }
            try
            {
                idalmacen = comboBox_Almacen.SelectedValue.ToString();
            }
            catch { }
            if (idCategoria == "")
            {
                MessageBox.Show("La categoría es necesaria");
                return;
            }
            if (textBox_Cantidad.Text.Trim() != "") {
                try
                {
                    cantidad  =Convert.ToDouble(textBox_Cantidad.Text.Trim());
                }
                catch {
                    MessageBox.Show("La cantidad es incorrecta");
                    return;
                }
            }
            if (textBox_Precio.Text.Trim() != "")
            {
                try
                {
                    precio = Convert.ToDouble(textBox_Precio.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("La cantidad es incorrecta");
                    return;
                }
            }
            
            if (iidActivo == "")
            {
                if (ClsActivos.ExisteCategoriaText(textBox_Descripcion.Text.Trim(), idalmacen))
                {
                    MessageBox.Show("La descripción ya existe, elije otra");
                    return;
                }
                if (ClsActivos.Guardar(textBox_Descripcion.Text, cantidad.ToString(), precio.ToString(), idCategoria, idalmacen))
                {
                    MessageBox.Show("Guardado");
                    try
                    {
                        cargaListaActivos();
                    }
                    catch { }
                    this.Close();
                }
            }
            else {
                if (ClsActivos.Actializa(textBox_Descripcion.Text, cantidad.ToString(), precio.ToString(), idCategoria, idalmacen, iidActivo))
                {
                    MessageBox.Show("Actualizado");
                    try
                    {
                        cargaListaActivos();
                    }
                    catch { }
                    this.Close();
                }
            }
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
