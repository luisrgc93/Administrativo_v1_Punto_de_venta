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
    public partial class Form_Usuarios : Form
    {
        string passedInText = "";
        Classes.Class_Limpiar Clean = new Classes.Class_Limpiar();
        Classes.Catalogos.Administracion.Class_Usuarios ClsUsu = new Classes.Catalogos.Administracion.Class_Usuarios();
        Classes.Catalogos.Personal.Class_Puestos ClsPue = new Classes.Catalogos.Personal.Class_Puestos();
        Classes.Class_Empresa ClsEmp = new Classes.Class_Empresa();
        Classes.Catalogos.Administracion.Class_Roles ClsRol = new Classes.Catalogos.Administracion.Class_Roles();
        
        /// SAT
        Classes.SAT.Class_Estados ClsEstados = new Classes.SAT.Class_Estados();
        
        public event Form1.MessageHandler CargaListaAllUsu;

        public Form_Usuarios(string id)
        {
            InitializeComponent();
            this.passedInText = id;
        }

        private void Form_Usuarios_Load(object sender, EventArgs e)
        {
            Clean.Activar(this.panel1);
            LlenadoEstados();
            LlenadoPuestos();
            LlenadoRoles();
            LlenadoListaEmpresas();
            if (passedInText != "")
            {
                if (passedInText == "Primer Ingreso")
                {
                    label_puesto.Visible = false;
                    label_ga.Visible = false;
                    comboBox_Puesto.Visible = false;
                    comboBox_Rol.Visible = false;
                    label_select_empresa.Visible = false;
                    listBox_Empresas.Visible = false;
                    btn_nuevoCliente.Enabled = false;
                    MessageBox.Show("Puedes llenar todos los campos si lo deseas, solo recuerda que los que contienen un '*' son obligatorios");
                }
                else
                {
                    getInfoID(passedInText);
                    Clean.Editar(this.panel1);
                }
                
            }
        }
        private void LlenadoRoles()
        {
            DataTable dt = new DataTable("Estados");
            dt = ClsRol.getOpcionesAll();

            comboBox_Rol.DataSource = dt;
            comboBox_Rol.DisplayMember = "nombre";
            comboBox_Rol.ValueMember = "id";
        }
        private void LlenadoListaEmpresas()
        {
            DataTable dtListEmpresas = new DataTable();
            dtListEmpresas = ClsEmp.GetEmpresas("");
            listBox_Empresas.DataSource = dtListEmpresas;
            listBox_Empresas.DisplayMember = "Alias";
            listBox_Empresas.ValueMember = "id";
         
        }
        private void LlenadoEstados()
        {
            DataTable dtEstados = ClsEstados.getListaWhere(" WHERE iidEstatus =  1  ");
            comboBox_Estado.DataSource = dtEstados;
            comboBox_Estado.DisplayMember = "vchNombre";
            comboBox_Estado.ValueMember = "iidEstado";
        }
        private void LlenadoPuestos()
        {
            DataTable dt = new DataTable("Puestos");
            dt = ClsPue.getPuestoAll();

            comboBox_Puesto.DataSource = dt;
            comboBox_Puesto.DisplayMember = "nombre";
            comboBox_Puesto.ValueMember = "id";
        }
        private void btn_nuevoCliente_Click(object sender, EventArgs e)
        {
            Clean.Activar(this.panel1);
            Clean.Limpiar(this.panel1);
            passedInText = "";
        }

        private void getInfoID(string id) {
            DataTable dtresult = new DataTable();
            dtresult = ClsUsu.getInfoByID(id);

            DataRow row = dtresult.Rows[0];
            comboBox_Puesto.SelectedValue = row["iidPuesto"].ToString();
            textBox_Nombre.Text = row["vchNombre"].ToString();
            comboBox_Estado.SelectedValue = row["iidEstado"].ToString();
            textBox_Correo.Text = row["vchCorreo"].ToString();
            textBox_Clave1.Text = row["vchClave"].ToString();
            textBox_Clave2.Text = row["vchClave"].ToString();
            textBox_Domicilio.Text = row["vchDomicilio"].ToString();
            textBox_Colonia.Text = row["vchColonia"].ToString();
            textBox_Telefono.Text = row["vchTelefono"].ToString();
            textBox_CP.Text = row["vchCP"].ToString();
            textBox_Usuario.Text = row["vchUsuario"].ToString();
            textBox_Ciudad.Text = row["vchCiudad"].ToString();
            comboBox_Rol.SelectedValue = row["iidRol"].ToString();

            ///acesos empresa
            string idaccesoEmp = ClsUsu.getAccesosUsuario(id);            
           try
            {
                //string[] words = idaccesoEmp.expl
                string[] words = idaccesoEmp.Split(new string[] { "," }, StringSplitOptions.None);
                foreach (string word in words)
                {
                    if (word != "")
                    {
                        int item = Convert.ToInt32(word);
                        listBox_Empresas.SelectedValue = item;
                    }
                }
                
            }catch{
            }
        }

        private void btn_guardarCliente_Click(object sender, EventArgs e)
        {
            bool correctoSelec = true;
            string idrol = "";
            string puesto = "";
            string estado = "";
            try
            {
                puesto = comboBox_Puesto.SelectedValue.ToString();
                estado = comboBox_Estado.SelectedValue.ToString();
                idrol = comboBox_Rol.SelectedValue.ToString();
            }
            catch
            {
            }
            string idsEmpresas = "";
            if (passedInText != "Primer Ingreso")
            {
                

                foreach (DataRowView objDataRowView in listBox_Empresas.SelectedItems)
                {
                    if ((objDataRowView["id"].ToString() != "") && (objDataRowView["id"].ToString() != "0"))
                    {
                        idsEmpresas = idsEmpresas + objDataRowView["id"].ToString() + ",";
                    }
                }

                idsEmpresas = idsEmpresas.TrimEnd(',');
                if (idsEmpresas == "")
                {
                    MessageBox.Show("Debe seleccionar al menos una empresa.");
                    return;
                }
            }

            if (ClsUsu.validar(this))//validamos que igresen datos Necessarios
            {
                
                if (passedInText != "Primer Ingreso")
                {
                    if (puesto == "" || puesto == "0")
                    {
                        MessageBox.Show("Seleccione un puesto");
                        return;
                    }
                    if (idrol == "" || idrol == "0")
                    {
                        MessageBox.Show("Seleccione un Grupo de Acceso");
                        return;
                    }
                }
               
                if (estado == "" || estado == "0")
                {
                    MessageBox.Show("Seleccione un Estado");
                    return;
                }

                //claves iguales
                if (textBox_Clave1.Text != textBox_Clave2.Text)
                {
                    MessageBox.Show("La clave es diferente. Seleccione claves iguales.");
                }
                else
                {
                        if(passedInText == "Primer Ingreso")
                        {
                            puesto = "1";
                            idrol = "1";
                            idsEmpresas = "1";
                        }
                        DataTable Info = new DataTable();
                        DataRow Drw;

                        Info.Columns.Add("puesto", System.Type.GetType("System.String"));
                        Info.Columns.Add("usuario", System.Type.GetType("System.String"));
                        Info.Columns.Add("clave", System.Type.GetType("System.String"));
                        Info.Columns.Add("nombre", System.Type.GetType("System.String"));
                        Info.Columns.Add("calle", System.Type.GetType("System.String"));
                        Info.Columns.Add("colonia", System.Type.GetType("System.String"));
                        Info.Columns.Add("estado", System.Type.GetType("System.String"));
                        Info.Columns.Add("cp", System.Type.GetType("System.String"));
                        Info.Columns.Add("municipio", System.Type.GetType("System.String"));
                        Info.Columns.Add("correo", System.Type.GetType("System.String"));
                        Info.Columns.Add("telefono", System.Type.GetType("System.String"));
                        Info.Columns.Add("idsEmpresas", System.Type.GetType("System.String"));
                        Info.Columns.Add("idRol", System.Type.GetType("System.String"));
                        Drw = Info.NewRow();
                        Drw["puesto"] = puesto;
                        Drw["usuario"] = textBox_Usuario.Text;
                        Drw["clave"] = textBox_Clave1.Text;
                        Drw["nombre"] = textBox_Nombre.Text;
                        Drw["calle"] = textBox_Domicilio.Text;
                        Drw["colonia"] = textBox_Colonia.Text;
                        Drw["estado"] = comboBox_Estado.SelectedValue.ToString();
                        Drw["cp"] = textBox_CP.Text;
                        Drw["colonia"] = textBox_Colonia.Text;
                        Drw["municipio"] = textBox_Ciudad.Text;
                        Drw["correo"] = textBox_Correo.Text;
                        Drw["telefono"] = textBox_Telefono.Text;
                        Drw["idsEmpresas"] = idsEmpresas;
                        Drw["idRol"] = idrol;      
                        Info.Rows.Add(Drw);

                        if (passedInText == "" || passedInText == "Primer Ingreso")
                        {
                            
                            if(ClsUsu.ExisteUnoUsuario(textBox_Usuario.Text))
                            {
                                MessageBox.Show("El usuario ya existe, elije otro");
                                return;
                            }

                            if (ClsUsu.InsertaInformacion(Info))
                            {
                                MessageBox.Show("Guardado Correctamente");

                                string idUsuario = ClsUsu.getIDUsuarioInsertado(textBox_Usuario.Text);
                                // CargaListaAllUsu();
                                // Clean.Limpiar(this);
                                        
                                //Clean.Desactivar(this);
                                Clean.Limpiar(this.panel1);
                                Clean.Desactivar(this.panel1);

                                try
                                {
                                    //Mostrar Ventanaa de Accesos
                                    CargaListaAllUsu();
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
                            if (ClsUsu.ExisteDosUsuario(textBox_Usuario.Text,passedInText))
                            {
                                MessageBox.Show("El usuario ya existe, elije otro");
                                return;
                            }
                            
                            if (ClsUsu.ActualizaInformacion(Info, passedInText))
                            {
                                MessageBox.Show("Actualizado Correctamente");
                                
                                Clean.Limpiar(this.panel1);
                                Clean.Desactivar(this.panel1);
                                passedInText = "";

                                try
                                {
                                    CargaListaAllUsu();
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
            }
        }

        
    }
}


