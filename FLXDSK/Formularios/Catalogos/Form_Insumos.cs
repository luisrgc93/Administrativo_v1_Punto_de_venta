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
    public partial class Form_Insumos : Form
    {
        string idInsumos = "";
        string accion = "";
        Classes.Catalogos.Class_Insumos ClsIns = new Classes.Catalogos.Class_Insumos();
        Classes.Inventarios.Class_Almacen ClsAlm = new Classes.Inventarios.Class_Almacen();

        public event Form1.MessageHandler Lista_Insumos;

        public Form_Insumos(string temp,string accion)
        {
            InitializeComponent();
            idInsumos = temp;
            this.accion = accion;
        }

        private void Form_Insumos_Load(object sender, EventArgs e)
        {
            llenar_combo();
            if (idInsumos != "")
            {
                obtener_info();
            }
        }

        private void obtener_info()
        {
            DataTable datos = new DataTable();
            datos = ClsIns.obtener_insumos(idInsumos);

            DataRow row = datos.Rows[0];

            comboBox_Categoria.SelectedValue = row["iidTipoInsumo"].ToString();
            textBox_Codigo.Text = row["vchCodigo"].ToString();
            textBox_Nombre.Text = row["vchNombre"].ToString();
            textBox_cantidad.Text = row["fCantidad"].ToString();
            textBox_Costo.Text = row["fCostoUnitario"].ToString();
        }

        private void llenar_combo()
        {
            DataTable insumos = new DataTable();
            insumos = ClsIns.getTipoInsumosAll();

            comboBox_Categoria.DataSource = insumos;
            comboBox_Categoria.DisplayMember = "nombre";
            comboBox_Categoria.ValueMember = "id";
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            string idcategora = comboBox_Categoria.SelectedValue.ToString();
            string nombre = textBox_Nombre.Text;
            string codigo = textBox_Codigo.Text;
            double costo = 0;
            double cantidad = 0;

            if (idcategora == "" || nombre == "" || codigo == "" || idcategora == "0")
            {
                MessageBox.Show("Llenar los campos requeridos");
                return;
            }

            try
            {
                costo = Convert.ToDouble(textBox_Costo.Text);
            }
            catch
            {
                costo = 0;
            }

             try
            {
                cantidad = Convert.ToDouble(textBox_cantidad.Text);
            }
            catch
            {
                cantidad = 0;
            }
                        
            string almacen = ClsAlm.id_almacen_principal();

            DataTable Info = new DataTable();
            DataRow row;

            Info.Columns.Add("idinsumo", System.Type.GetType("System.String"));
            Info.Columns.Add("idcategoria", System.Type.GetType("System.String"));
            Info.Columns.Add("nombre", System.Type.GetType("System.String"));
            Info.Columns.Add("costo", System.Type.GetType("System.String"));
            Info.Columns.Add("cantidad", System.Type.GetType("System.String"));
            Info.Columns.Add("codigo", System.Type.GetType("System.String"));
            Info.Columns.Add("almacen", System.Type.GetType("System.String"));

            row = Info.NewRow();
            row["idinsumo"] = idInsumos;
            row["idcategoria"] = idcategora;
            row["nombre"] = nombre;
            row["costo"] = costo;
            row["cantidad"] = cantidad;
            row["codigo"] = codigo;
            row["almacen"] = almacen;
            Info.Rows.Add(row);

            if (idInsumos == "")
            {
                if (!ClsIns.existe_insumo(textBox_Nombre.Text))
                {
                    if (ClsIns.inserta_insumos(Info))
                    {
                        MessageBox.Show("Insumo guardado exitosamente", "Exito");
                        try
                        {
                            if (accion == "")
                            {
                                Lista_Insumos();
                            }
                            this.Close();
                        }
                        catch
                        { }
                    }
                    else
                    {
                        MessageBox.Show("Probleamas al guardar. Intente mas tarde", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("El nombre para el area que desea registrar ya existe", "Error");
                    return;
                }
            }
            else
            {
                if (ClsIns.actualiza_insumo(Info))
                {
                    MessageBox.Show("Insumo actualizado exitosamente","Exito");
                    try
                    {
                        if (accion == "")
                        {
                            Lista_Insumos();
                        }
                        this.Close();
                    }  
                    catch
                    { }
                }
                else
                {
                    MessageBox.Show("Probleamas al actualizar. Intente mas tarde","Error");
                }
            }

        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
