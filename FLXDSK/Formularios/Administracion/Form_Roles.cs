using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Catalogos
{
    public partial class Form_Roles : Form
    {
        string idrol = "";
        Classes.Herramientas.Class_Roles ClsRol = new Classes.Herramientas.Class_Roles();
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        string idusuario = Classes.Class_Session.Idusuario.ToString();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        public event Form1.MessageHandler CargarListaRoles;

        public Form_Roles(string idtemp)
        {
            idrol = idtemp;
            InitializeComponent();
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            string nombreRol = textBox_Rol.Text;
            if (nombreRol == "")
            {
                MessageBox.Show("Favor de agregar un nombre");
                return;
            }

            if (idrol == "")
            {
                if (!ClsRol.ExisteNombre(nombreRol))
                {
                    if (ClsRol.InsertaRol(nombreRol))
                    {
                        string idrol_ultimoGuardado = ClsRol.getUltimoidGuardado(nombreRol);

                        dataGridView1.EndEdit();
                        foreach (DataGridViewRow registro in dataGridView1.Rows)
                        {
                            try
                            {
                                if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                                {
                                    string idOpcion = registro.Cells["iidOpcion"].Value.ToString();

                                    if (!ClsRol.InsertaRelUsuarioOpcion(idOpcion, idusuario, idrol_ultimoGuardado))
                                    {
                                        MessageBox.Show("Problemas al guardar");
                                        return;
                                    }
                                }
                            }
                            catch { }
                        }

                        MessageBox.Show("Guardado con exito");
                        try
                        {
                            CargarListaRoles();
                        }
                        catch { }
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Problemas al guardar");
                    }
                }
                else
                {
                    MessageBox.Show("El nombre ingresado ya existe, elige otro");
                    return;
                }
            }
            else
            {
                if (ClsRol.UpdateRol(idrol, nombreRol))
                {
                    try
                    {
                        ClsRol.DeleteRelUsuarioOpcion(idrol);
                    }
                    catch { }

                    dataGridView1.EndEdit();
                    foreach (DataGridViewRow registro in dataGridView1.Rows)
                    {
                        try
                        {
                            if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                            {
                                string idOpcion = registro.Cells["iidOpcion"].Value.ToString();

                                if (!ClsRol.InsertaRelUsuarioOpcion(idOpcion, idusuario, idrol))
                                {
                                    MessageBox.Show("Problemas al guardar");
                                    return;
                                }
                            }
                        }
                        catch { }
                    }

                    MessageBox.Show("Actualizado correctamente");
                    try
                    {
                        CargarListaRoles();
                    }
                    catch { }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problemas al actualizar");
                }                
            }
        }

        private void Form_Roles_Load(object sender, EventArgs e)
        {
            llenarGrid();
            if (idrol != "")
            {
                DataTable tablaRol = ClsRol.getRol(idrol);

                DataRow row = tablaRol.Rows[0];
                string Nombre = row["vchNombre"].ToString();

                textBox_Rol.Text = Nombre;
            }
        }

        private void llenarGrid()
        {
            dataGridView1.DataSource = null;
            string sql = "SELECT iidOpcion, vchNombre +' '+vchDescripcion vchNombre  FROM catMenuOpciones (NOLOCK) WHERE iidEstatus = 1 ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];
                //Se define el tamaño de las columnas
                dataGridView1.Columns["iidOpcion"].Width = 50;
                dataGridView1.Columns["iidOpcion"].Visible = false;
                dataGridView1.Columns["vchNombre"].Width = 260;
                dataGridView1.Columns["vchNombre"].ReadOnly = true;

                if (!dataGridView1.Columns.Contains("Seleccionar"))
                {
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "Seleccionar";
                    checkColumn.HeaderText = "Seleccionar";
                    checkColumn.Width = 80;
                    checkColumn.FillWeight = 40;
                    dataGridView1.Columns.Insert(0, checkColumn);
                }
            }
            catch
            {
                MessageBox.Show("No hay Informacion");
            }
            bs.DataSource = dataGridView1.DataSource;

            if (idrol != "")
            {
                obtenerOpciones();
            }
        }

        public void obtenerOpciones()
        {
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    string idOpcion = registro.Cells["iidOpcion"].Value.ToString();

                    if (ClsRol.ExisteOpcionSeleccionada(idOpcion, idrol))
                    {
                        registro.Cells["Seleccionar"].Value = true;
                    }                   
                }
                catch { }
            }
        }
    }
}
