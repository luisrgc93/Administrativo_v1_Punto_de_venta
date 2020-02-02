using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Catalogos.Proveedores
{
    public partial class Form_Proveedores : Form
    {
        string idProveedor = "";
        string mensaje = "";

        Classes.Class_Limpiar Clean = new Classes.Class_Limpiar();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();
        Classes.Class_Validaciones ClsVal = new Classes.Class_Validaciones();
        Classes.Catalogos.Proveedores.Class_Proveedores ClsPro = new Classes.Catalogos.Proveedores.Class_Proveedores();

        /// SAT
        Classes.SAT.Class_Estados ClsEstados = new Classes.SAT.Class_Estados();
        Classes.SAT.Class_Paises ClsPaises = new Classes.SAT.Class_Paises();

        public event Form1.MessageHandler Lista_Proveedores;

        public Form_Proveedores(string temp)
        {
            InitializeComponent();
            idProveedor = temp;
        }

        private void Form_Proveedores_Load(object sender, EventArgs e)
        {
            llenarCombos();
            tipoProveedor();

            if (idProveedor != "")
                cargarCampos();
            
        }

        public void llenarCombos() 
        {
            DataTable dtEstados = ClsEstados.getListaWhere(" WHERE iidEstatus =  1  ");
            comboBox_estado.DataSource = dtEstados;
            comboBox_estado.DisplayMember = "vchNombre";
            comboBox_estado.ValueMember = "iidEstado";

            DataTable dtPaises = ClsPaises.getListaWhere(" WHERE iidEstatus =  1  ");
            comboBox_Pais.DataSource = dtPaises;
            comboBox_Pais.DisplayMember = "vchNombre";
            comboBox_Pais.ValueMember = "iidPais";
        }

        public bool validarCampos()
        {
            if (textBox_alias.Text.Trim() == "" || textBox_razon.Text == "" )
            {
                mensaje += "- Algun campo requeridos esta vacio. \r\n";
            }


            if (textBox_correo.Text.Trim() != "")
            {
                if (!ClsVal.validarEmail(textBox_correo.Text))
                {
                    mensaje += "El correo ingresado no es valido. \r\n";
                }
            }

            if (textBox_rfc.Text.Trim() != "")
            {
                if (!ClsVal.isRFC(textBox_rfc.Text))
                {
                    mensaje += "El RFC ingresado no es valido. \r\n";
                }
            }

            if (mensaje == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void cargarCampos()
        {
            try
            {
                DataTable proveedores = new DataTable();
                proveedores = ClsPro.get_proveedores(idProveedor);

                DataRow row = proveedores.Rows[0];
            
                textBox_alias.Text = row["vchNombreComercial"].ToString();
                textBox_calle.Text = row["vchDomicilio"].ToString();
                textBox_colonia.Text = row["vchColonia"].ToString();
                textBox_correo.Text = row["vchCorreo"].ToString();
                textBox_cp.Text = row["vchCP"].ToString();
                textBox_localidad.Text = row["vchLocalidad"].ToString();
                textBox_municipio.Text = row["vchMunicipio"].ToString();
                textBox_numext.Text = row["vchNumExt"].ToString();
                textBox_numint.Text = row["vchNumInt"].ToString();
                textBox_observaciones.Text = row["vchObservaciones"].ToString();
                textBox_pagina.Text = row["vchPagina"].ToString();
                textBox_razon.Text = row["vchRazonSocial"].ToString();
                textBox_rfc.Text = row["vhcRFC"].ToString();
                textBox_telefono.Text = row["vchTelefono"].ToString();
                try
                {
                    comboBox_estado.SelectedValue = row["iidEstado"].ToString();
                }
                catch { }
                try
                {
                    comboBox_Pais.SelectedValue = row["iidPais"].ToString();
                }
                catch { }
            }
            catch
            {
                MessageBox.Show("No Existen registros actualmente.");
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            string idestado="";
            string idpais = "";
            mensaje = "";

            try
            {
                idpais = comboBox_Pais.SelectedValue.ToString();
            }
            catch
            {}
            try
            {
                idestado = comboBox_estado.SelectedValue.ToString();
            }
            catch
            { }


            if (idestado == "" || idestado == "0")
            {
                MessageBox.Show("Estado es requerido");
                return;
            }
            if (idpais == "" || idpais == "0")
            {
                MessageBox.Show("Pais es requerido");
                return;
            }
            if (!validarCampos())
            {
                MessageBox.Show(mensaje);
                return;
            }

            DataTable Info = new DataTable();
            DataRow Drw;

            Info.Columns.Add("idproveedor", System.Type.GetType("System.String"));
            Info.Columns.Add("razon", System.Type.GetType("System.String"));
            Info.Columns.Add("nombre", System.Type.GetType("System.String"));
            Info.Columns.Add("rfc", System.Type.GetType("System.String"));
            Info.Columns.Add("observaciones", System.Type.GetType("System.String"));
            Info.Columns.Add("domicilio", System.Type.GetType("System.String"));
            Info.Columns.Add("exterior", System.Type.GetType("System.String"));
            Info.Columns.Add("interior", System.Type.GetType("System.String"));
            Info.Columns.Add("colonia", System.Type.GetType("System.String"));
            Info.Columns.Add("localidad", System.Type.GetType("System.String"));
            Info.Columns.Add("municipio", System.Type.GetType("System.String"));
            Info.Columns.Add("cp", System.Type.GetType("System.String"));
            Info.Columns.Add("idestado", System.Type.GetType("System.String"));
            Info.Columns.Add("idpais", System.Type.GetType("System.String"));
            Info.Columns.Add("pais", System.Type.GetType("System.String"));
            Info.Columns.Add("telefono", System.Type.GetType("System.String"));
            Info.Columns.Add("correo", System.Type.GetType("System.String"));
            Info.Columns.Add("pagina", System.Type.GetType("System.String"));

            Drw = Info.NewRow();
            Drw["idproveedor"] = idProveedor;
            Drw["razon"] = textBox_razon.Text;
            Drw["nombre"] = textBox_alias.Text;
            Drw["rfc"] = textBox_rfc.Text;
            Drw["observaciones"] = textBox_observaciones.Text;
            Drw["domicilio"] = textBox_calle.Text;
            Drw["exterior"] = textBox_numext.Text;
            Drw["interior"] = textBox_numint.Text;
            Drw["colonia"] = textBox_colonia.Text;
            Drw["localidad"] = textBox_localidad.Text;
            Drw["municipio"] = textBox_municipio.Text;
            Drw["cp"] = textBox_cp.Text;
            Drw["idestado"] = idestado;
            Drw["idpais"] = idpais;
            Drw["telefono"] = textBox_telefono.Text;
            Drw["correo"] = textBox_correo.Text;
            Drw["pagina"] = textBox_pagina.Text;
            Info.Rows.Add(Drw);

            if (idProveedor == "")
            {
                if (ClsPro.inserta_proveedor(Info))
                {
                    DataTable razonS = new DataTable();
                    razonS = ClsPro.get_proveedores_x_razon(textBox_razon.Text);

                    DataRow rows = razonS.Rows[0];

                    string razonSocial = rows["vchRazonSocial"].ToString();
                    string id = rows["iidProveedor"].ToString();

                    foreach (string itemCheck in checkedListBox_tipos.CheckedItems)
                    {
                        string tipo = itemCheck.ToString();

                        string idtipoproveedor = ClsPro.obtener_tipo_proveedor_x_nombre(tipo);

                        try
                        {
                            ClsPro.inserta_rel_tipos_proveedores(idtipoproveedor, id);
                        }
                        catch { }
                    }

                    MessageBox.Show("Guardado Correctamente");
                    try
                    {
                        Lista_Proveedores();
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
                        row_Excepcion["vchLugar"] = "Form_Clientes";
                        row_Excepcion["vchAccion"] = "Cargar lista_Clientes(), al insertar Cliente nuevo";
                        Info_Excepcion.Rows.Add(row_Excepcion);

                        ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                    }
                    Clean.Limpiar(this);
                    comboBox_estado.SelectedValue = "0";
                    comboBox_Pais.SelectedValue = "0";
                    try
                    {
                        Lista_Proveedores();
                    }
                    catch { }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problema al Guardar");
                }
            }
            else
            {
                if (ClsPro.actualiza_proveedor(Info))
                {
                    if (ClsPro.borrar_rel_x_id(idProveedor))
                    {
                        DataTable razonS = new DataTable();
                        razonS = ClsPro.get_proveedores_x_razon(textBox_razon.Text);

                        DataRow rows = razonS.Rows[0];

                        foreach (string itemCheck in checkedListBox_tipos.CheckedItems)
                        {
                            string tipo = itemCheck.ToString();

                            string idtipoproveedor = ClsPro.obtener_tipo_proveedor_x_nombre(tipo);

                            try
                            {
                                ClsPro.inserta_rel_tipos_proveedores(idtipoproveedor, idProveedor);
                            }
                            catch { }
                        }
                    }

                    MessageBox.Show("Actualizado Correctamente");
                    try
                    {
                        //Lista_Clientes();
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
                        row_Excepcion["vchLugar"] = "Form_Proveedor";
                        row_Excepcion["vchAccion"] = "Cargar lista_proveedor(), al actualizar un provvedor";
                        Info_Excepcion.Rows.Add(row_Excepcion);

                        ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                    }

                    idProveedor = "";
                    try
                    {
                        Lista_Proveedores();
                    }
                    catch { }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problema al Actualizar");
                }
            }
        }

        public void tipoProveedor()
        {
            //Limpiar el checklist
            for (int i = 0; i < checkedListBox_tipos.Items.Count; i++)
            {
                checkedListBox_tipos.SetItemChecked(i, false);
            }

            //Lleno checklist
            DataTable tipos = new DataTable();
            tipos = ClsPro.obtener_tipo_proveedor();

            if (tipos.Rows.Count > 0)
            {
                DataRow row = tipos.Rows[0];
                foreach (DataRow rows in tipos.Rows)
                {
                    checkedListBox_tipos.Items.Add(rows["vchNombre"].ToString());
                }
            }

            if (idProveedor != "")
            {
                DataTable llenarchecklist = new DataTable();
                llenarchecklist = ClsPro.obten_nombre_tipo_x_id(idProveedor);

                if (llenarchecklist.Rows.Count > 0)
                {
                    DataRow row = llenarchecklist.Rows[0];
                    foreach (DataRow rows in llenarchecklist.Rows)
                    {
                        string nombre = rows["vchNombre"].ToString();
                        //Recorro el checkedListBox  para activar los asignados al usuario
                        for (int i = 0; i < checkedListBox_tipos.Items.Count; i++)
                        {
                            if (checkedListBox_tipos.Items[i].ToString() == nombre)
                            {
                                checkedListBox_tipos.SetItemChecked(i, true);
                            }
                        }
                    }
                }
            }
        }


        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            Clean.Limpiar(this.panel1);
        }

        private void textBox_calle_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_telefono_TextChanged(object sender, EventArgs e)
        {
            
        }

    }
}
