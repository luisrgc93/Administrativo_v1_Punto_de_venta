using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Inventarios
{
    public partial class Form_Almacenes : Form
    {
        string idAlmacen = "";
        Classes.Class_Limpiar Clean = new Classes.Class_Limpiar();
        Classes.Inventarios.Class_Almacen ClsAlm = new Classes.Inventarios.Class_Almacen();
        Classes.Class_Validaciones ClsVal = new Classes.Class_Validaciones();

        /// SAT
        Classes.SAT.Class_Estados ClsEstados = new Classes.SAT.Class_Estados();

        public event Form1.MessageHandler Lista_Almacenes;

        public Form_Almacenes(string temp)
        {
            InitializeComponent();
            idAlmacen = temp;
        }

        private void Form_Almacenes_Load(object sender, EventArgs e)
        {
            llenarCombos();
            if (idAlmacen != "")
            {
                getInfoID();
                Clean.Editar(this.panel1);
            }
        }

        private void getInfoID()
        {
            DataTable dtresult = new DataTable();
            dtresult = ClsAlm.get_almacen_x_id(idAlmacen);

            DataRow row = dtresult.Rows[0];
            textBox_nombre.Text = row["vchNombre"].ToString();
            textBox_calle.Text = row["vchDomicilio"].ToString();
            textBox_numext.Text = row["vchNumExt"].ToString();
            textBox_numint.Text = row["vchNumInt"].ToString();
            textBox_colonia.Text = row["vchColonia"].ToString();
            textBox_municipio.Text = row["vchMunicipio"].ToString();
            comboBox_estado.SelectedValue = row["iidEstado"].ToString();
            textBox_cp.Text = row["vchCP"].ToString();
            textBox_localidad.Text = row["vchLocalidad"].ToString();
            textBox_correo.Text = row["vchCorreo"].ToString();
            textBox_telefono.Text = row["vchTelefono"].ToString();
            if (row["siPrincipal"].ToString() == "1")
            {
                checkBox_Principal.Checked = true;
            }
            else
            {
                checkBox_Principal.Checked = false;
            }
        }

        public void llenarCombos() 
        {
            DataTable dtEstados = ClsEstados.getListaWhere(" WHERE iidEstatus =  1  ");
            comboBox_estado.DataSource = dtEstados;
            comboBox_estado.DisplayMember = "vchNombre";
            comboBox_estado.ValueMember = "iidEstado";
        }

        private void btn_nuevoCliente_Click(object sender, EventArgs e)
        {
            Clean.Activar(this.panel1);
            Clean.Limpiar(this.panel1);
            idAlmacen = "";
        }

        private void btn_guardarCliente_Click(object sender, EventArgs e)
        {
            string idestado = "";
            if (textBox_nombre.Text == "")
            {
                MessageBox.Show("Favor de llenar los campos Requeridos.");
                return;
            }
            try
            {
                idestado = comboBox_estado.SelectedValue.ToString();
            }
            catch { }

            if (!ClsVal.validarEmail(textBox_correo.Text))
            {
                MessageBox.Show("El correo ingresado no es valido.");
                return;
            }
            if (idestado == "" || idestado == "0") {
                MessageBox.Show("Estado requerido.");
                return;
            }

            DataTable Info = new DataTable();
            DataRow Drw;

            Info.Columns.Add("idalmacen", System.Type.GetType("System.String"));
            Info.Columns.Add("nombre", System.Type.GetType("System.String"));
            Info.Columns.Add("calle", System.Type.GetType("System.String"));
            Info.Columns.Add("numext", System.Type.GetType("System.String"));
            Info.Columns.Add("numint", System.Type.GetType("System.String"));
            Info.Columns.Add("colonia", System.Type.GetType("System.String"));
            Info.Columns.Add("cp", System.Type.GetType("System.String"));
            Info.Columns.Add("municipio", System.Type.GetType("System.String"));
            Info.Columns.Add("estado", System.Type.GetType("System.String"));
            Info.Columns.Add("localidad", System.Type.GetType("System.String"));
            Info.Columns.Add("correo", System.Type.GetType("System.String"));
            Info.Columns.Add("telefono", System.Type.GetType("System.String"));
            Info.Columns.Add("principal", System.Type.GetType("System.String"));

            Drw = Info.NewRow();
            Drw["idalmacen"] = idAlmacen;
            Drw["nombre"] = textBox_nombre.Text;
            Drw["calle"] = textBox_calle.Text;
            Drw["numext"] = textBox_numext.Text;
            Drw["numint"] = textBox_numint.Text;
            Drw["colonia"] = textBox_colonia.Text;
            Drw["cp"] = textBox_cp.Text;
            Drw["municipio"] = textBox_municipio.Text;
            Drw["estado"] = comboBox_estado.SelectedValue.ToString();
            Drw["localidad"] = textBox_localidad.Text;
            Drw["correo"] = textBox_correo.Text;
            Drw["telefono"] = textBox_telefono.Text;
            if (checkBox_Principal.Checked == true)
            {
                Drw["principal"] = 1;
            }
            else
            {
                Drw["principal"] = 0;
            }
            DialogResult resultado;

            if (checkBox_Principal.Checked == true)
            {
                if (ClsAlm.existe_almacen())
                {
                    resultado = MessageBox.Show(@"Ya existe un almacen principal, desea reemplazarlo? ", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    ClsAlm.modifica_almacen_principal();

                    if (DialogResult.OK == resultado)
                    {
                        Info.Rows.Add(Drw);
                        if (idAlmacen == "")
                        {//nuevo
                            if (ClsAlm.inserta_almacen(Info))
                            {
                                checkBox_Principal.Checked = false;
                                MessageBox.Show("Guardado Correctamente");
                                Lista_Almacenes();
                                Clean.Limpiar(this.panel1);
                                Clean.Desactivar(this.panel1);
                                checkBox_Principal.Checked = false;
                            }
                            else
                            {
                                MessageBox.Show("Problema al Guardar");
                            }
                        }
                        else
                        {
                            if (ClsAlm.actualiza_almacen(Info))
                            {
                                checkBox_Principal.Checked = false;
                                MessageBox.Show("Actualizado Correctamente");
                                Lista_Almacenes();
                                Clean.Limpiar(this.panel1);
                                Clean.Desactivar(this.panel1);
                                idAlmacen = "";
                            }
                            else
                            {
                                MessageBox.Show("Problema al Actualizar");
                            }
                        }
                    }
                }
                else
                {
                    Info.Rows.Add(Drw);
                    if (idAlmacen == "")
                    {//nuevo
                        if (ClsAlm.inserta_almacen(Info))
                        {
                            MessageBox.Show("Guardado Correctamente");
                            Lista_Almacenes();
                            Clean.Limpiar(this.panel1);
                            Clean.Desactivar(this.panel1);
                        }
                        else
                        {
                            MessageBox.Show("Problema al Guardar");
                        }
                    }
                    else
                    {
                        if (ClsAlm.actualiza_almacen(Info))
                        {
                            MessageBox.Show("Actualizado Correctamente");
                            Lista_Almacenes();
                            Clean.Limpiar(this.panel1);
                            Clean.Desactivar(this.panel1);
                            idAlmacen = "";
                        }
                        else
                        {
                            MessageBox.Show("Problema al Actualizar");
                        }
                    }
                }
            }
            else
            {
                Info.Rows.Add(Drw);
                if (idAlmacen == "")
                {//nuevo
                    if (ClsAlm.inserta_almacen(Info))
                    {
                        MessageBox.Show("Guardado Correctamente");
                        Lista_Almacenes();
                        Clean.Limpiar(this.panel1);
                        Clean.Desactivar(this.panel1);
                    }
                    else
                    {
                        MessageBox.Show("Problema al Guardar");
                    }
                }
                else
                {
                    if (ClsAlm.actualiza_almacen(Info))
                    {
                        MessageBox.Show("Actualizado Correctamente");
                        Lista_Almacenes();
                        Clean.Limpiar(this.panel1);
                        Clean.Desactivar(this.panel1);
                        idAlmacen = "";
                    }
                    else
                    {
                        MessageBox.Show("Problema al Actualizar");
                    }
                }
            }
        }   
    }
}
