using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Catalogos
{
    public partial class Form_Clientes : Form
    {
        
        Classes.Class_Clientes ClsCli = new Classes.Class_Clientes();
        Classes.Class_Limpiar Clean = new Classes.Class_Limpiar();
        Classes.Class_Logs ClsLog = new Classes.Class_Logs();

        //SAT
        Classes.SAT.Class_Paises ClsPaises = new Classes.SAT.Class_Paises();
        Classes.SAT.Class_Estados ClsEstados = new Classes.SAT.Class_Estados();

        public event Form1.MessageHandler Lista_Clientes;

        string idcliente = "";

        public Form_Clientes(string temp)
        {
            InitializeComponent();
            idcliente = temp;
        }

        public void llenarCombo()
        {
            DataTable dt_Pais = ClsPaises.getListaWhere(" WHERE iidEstatus = 1 ");
            comboBox_Pais.DataSource = dt_Pais;
            comboBox_Pais.DisplayMember = "vchNombre";
            comboBox_Pais.ValueMember = "iidPais";

            DataTable dt_Estado = ClsEstados.getListaWhere(" WHERE iidEstatus = 1 ");

            comboBox_estado.DataSource = dt_Estado;
            comboBox_estado.DisplayMember = "vchNombre";
            comboBox_estado.ValueMember = "iidEstado";
        }

        private void btn_guardarCliente_Click_1(object sender, EventArgs e)
        {
            if (ClsCli.validar(this))//validamos que igresen datos Necessarios
            {
                string idpais = "";
                string idestado = "";
                try
                {
                    idpais = comboBox_Pais.SelectedValue.ToString();
                }
                catch
                { }

                try
                {
                    idestado = comboBox_estado.SelectedValue.ToString();
                }
                catch { }

                if (idpais == "" || idpais == "0")
                {
                    MessageBox.Show("Debe de seleccionar un pais");
                    return;
                }
                if (idestado == "" || idestado == "0")
                {
                    MessageBox.Show("Debe de seleccionar un estado");
                    return;
                }

                if (ClsCli.validarCorreoNOexista(textBox_correo.Text, idcliente))
                { 
                    MessageBox.Show("El correo ya existe. Intente con uno diferente"); 
                    return; 
                }
                
                    DataTable Info = new DataTable();
                    DataRow Drw;

                    Info.Columns.Add("empresa", System.Type.GetType("System.String"));
                    Info.Columns.Add("alias", System.Type.GetType("System.String"));
                    Info.Columns.Add("razon", System.Type.GetType("System.String"));
                    Info.Columns.Add("rfc", System.Type.GetType("System.String"));
                    Info.Columns.Add("tipo", System.Type.GetType("System.String"));
                    Info.Columns.Add("calle", System.Type.GetType("System.String"));
                    Info.Columns.Add("numext", System.Type.GetType("System.String"));
                    Info.Columns.Add("numint", System.Type.GetType("System.String"));
                    Info.Columns.Add("colonia", System.Type.GetType("System.String"));
                    Info.Columns.Add("localidad", System.Type.GetType("System.String"));
                    Info.Columns.Add("cp", System.Type.GetType("System.String"));
                    Info.Columns.Add("municipio", System.Type.GetType("System.String"));
                    Info.Columns.Add("estado", System.Type.GetType("System.String"));
                    Info.Columns.Add("pais", System.Type.GetType("System.String"));
                    Info.Columns.Add("correo", System.Type.GetType("System.String"));
                    Info.Columns.Add("telefono", System.Type.GetType("System.String"));
                    Info.Columns.Add("contacto", System.Type.GetType("System.String"));

                    Drw = Info.NewRow();
                    Drw["empresa"] = Classes.Class_Session.IDEMPRESA.ToString();
                    Drw["alias"] = textBox_alias.Text;
                    Drw["razon"] = textBox_razon.Text;
                    Drw["rfc"] = textBox_rfc.Text.ToUpper();
                    Drw["tipo"] = "";
                    Drw["calle"] = textBox_calle.Text;
                    Drw["numext"] = textBox_numext.Text;
                    Drw["numint"] = textBox_numint.Text;
                    Drw["colonia"] = textBox_colonia.Text;
                    Drw["localidad"] = textBox_localidad.Text;
                    Drw["cp"] = textBox_cp.Text;
                    Drw["municipio"] = textBox_municipio.Text;
                    Drw["estado"] = idestado;
                    Drw["pais"] = idpais;
                    Drw["correo"] = textBox_correo.Text;
                    Drw["telefono"] = textBox_telefono.Text;
                    Drw["contacto"] = textBox_contacto.Text;
                    Info.Rows.Add(Drw);

                    if (idcliente == "")
                    {

                        if (ClsCli.InsertaInformacion(Info))
                        {
                            MessageBox.Show("Guardado Correctamente");
                            this.Close();
                            try
                            {
                                Lista_Clientes();
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
                            Clean.Desactivar(this);
                        }
                        else
                        {
                            MessageBox.Show("Problema al Guardar");
                        }
                    }
                    else
                    {
                        if (ClsCli.ActualizaInformacion(Info, idcliente))
                        {
                            MessageBox.Show("Actualizado Correctamente");
                            try
                            {
                                Lista_Clientes();
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
                                row_Excepcion["vchAccion"] = "Cargar lista_cliente(), al actualizar un cliente";
                                Info_Excepcion.Rows.Add(row_Excepcion);

                                ClsLog.INSERTA_EXCEPCION(Info_Excepcion);
                            }

                            Clean.Limpiar(this.panel1);
                            Clean.Desactivar(this.panel1);
                            idcliente = "";
                        }
                        else
                        {
                            MessageBox.Show("Problema al Actualizar");
                        }
                    }
                
            }
        }

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            Clean.Activar(this.panel1);
            Clean.Limpiar(this.panel1);
            idcliente = "";
        }

        private void getInfoID()
        {
            DataTable dtCliente = ClsCli.getInfoByID(idcliente);
            DataRow row = dtCliente.Rows[0];

            
            try
            {
                comboBox_Pais.SelectedValue = row["iidPais"].ToString();
            }
            catch
            {}
            try
            {
                comboBox_estado.SelectedValue = row["iidEstado"].ToString();
            }
            catch { }
            textBox_alias.Text = row["vchAlias"].ToString();
            textBox_rfc.Text = row["vchRFC"].ToString();
            textBox_razon.Text = row["vchRazon"].ToString();
            textBox_calle.Text = row["vchCalle"].ToString();
            textBox_numext.Text = row["vchNumExt"].ToString();
            textBox_numint.Text = row["vchNumInt"].ToString();
            textBox_colonia.Text = row["vchColonia"].ToString();
            textBox_localidad.Text = row["vchLocalidad"].ToString();
            textBox_municipio.Text = row["vchMunicipio"].ToString();
            textBox_correo.Text = row["vchCorreo"].ToString();
            textBox_telefono.Text = row["vchTelefono"].ToString();
            textBox_contacto.Text = row["vchNombreContacto"].ToString();
            textBox_cp.Text = row["vchCP"].ToString();

        }

        private void Form_Clientes_Load(object sender, EventArgs e)
        {
            llenarCombo();
            if (idcliente != "")
            {
                getInfoID();
            }
        }
        
    }
}
