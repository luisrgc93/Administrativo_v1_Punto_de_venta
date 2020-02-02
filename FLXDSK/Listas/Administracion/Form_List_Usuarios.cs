using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using FLXDSK.Classes.Catalogos.Administracion;
using FLXDSK.Conexion;
using FLXDSK.Formularios;

namespace FLXDSK.Listas.Administracion
{
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public partial class Form_List_Usuarios : Form
    {
        private readonly Class_Conexion _conexion = new Class_Conexion();
        private readonly Class_Usuarios _clsUsuarios = new Class_Usuarios();

        private readonly BindingSource _bs = new BindingSource();
         
        public Form_List_Usuarios()
        {
            InitializeComponent();
            var largo = Width;
            textBox_Buscar.Location = new Point(largo - 400, 5);
            pictureBox_Serch.Location = new Point(largo - (400 - 175), 3);
        }

        private void Form_List_Usuarios_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 6;
            CargaListaAllUsu();
        }

        private void CargaListaAllUsu()
        {
            const string sql = "SELECT U.iidUsuario Id, U.vchNombre Nombre, " +
                               "R.vchNombre  Rol, U.vchUsuario Usuario, U.vchDomicilio+' Col. '+U.vchColonia Domicilio,  " +
                               " U.vchTelefono Telefono, U.vchCorreo Correo " +
                               " FROM catUsuarios U, catRoles R (NOLOCK) " +
                               " WHERE R.iidRol = U.iidRol " +
                               " AND U.iidEstatus not in (2) " +
                               " ORDER BY U.dfechaup DESC ";

            var areas = new SqlDataAdapter(sql, _conexion.ConexionSQL());
            var dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];
                dataGridView1.Columns["Id"].Width = 80;
                dataGridView1.Columns["Nombre"].Width = 300;
                dataGridView1.Columns["Rol"].Width = 180;
                dataGridView1.Columns["Usuario"].Width = 100;
                dataGridView1.Columns["Domicilio"].Width = 300;
                dataGridView1.Columns["Telefono"].Width = 90;
                dataGridView1.Columns["Correo"].Width = 100;

                if (!dataGridView1.Columns.Contains("Seleccionar"))
                {
                    var checkColumn = new DataGridViewCheckBoxColumn
                    {
                        Name = "Seleccionar",
                        HeaderText = @"Seleccionar",
                        Width = 80,
                        FillWeight = 40
                    };
                    dataGridView1.Columns.Insert(0, checkColumn);
                }
            }
            catch
            {
                throw new NullReferenceException();
            }

            _bs.DataSource = dataGridView1.DataSource;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var frm = new Form_Usuarios("");
            frm.CargaListaAllUsu += CargaListaAllUsu;
            frm.ShowDialog();
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)Parent).Parent).TabPages.Remove((TabPage)Parent);
        }
      
        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            //Valida que no haya mas de un registro seleccionado           
            var contador = 0;
            //Finaliza modo de edicion
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value)
                    {
                        contador++;
                    }
                }
                catch
                {
                    // ignored
                }
            }

            if (contador == 0)
            {
                MessageBox.Show(@"Debe seleccionar al menos un registro.");
                return;
            }

            if (contador > 1)
            {
                MessageBox.Show(@"Para editar solo seleccione un registro.");
            }
            else
            {
                foreach (DataGridViewRow registro in dataGridView1.Rows)
                {
                    try
                    {
                        if ((bool) registro.Cells["Seleccionar"].Value != true) continue;
                        var id = registro.Cells[1].Value.ToString();
                        var frm = new Form_Usuarios(id);
                        frm.CargaListaAllUsu += CargaListaAllUsu;
                        frm.ShowDialog();
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }        
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            var contador = 0;
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((bool)registro.Cells["Seleccionar"].Value)
                    {
                        contador++;
                    }
                }
                catch
                {
                    // ignored
                }
            }

            if (contador == 0)
            {
                MessageBox.Show(@"Debe seleccionar al menos un registro.");
                return;
            }

            var resultado = MessageBox.Show(@"Esta seguro de eliminar usuario(s)", @"Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (DialogResult.OK != resultado) return;
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((bool)registro.Cells["Seleccionar"].Value)
                    {
                        //Elimina Usuarios
                        _clsUsuarios.deleteUsuario(registro.Cells["Id"].Value.ToString());
                    }
                }
                catch
                {
                    // ignored
                }
            }
            MessageBox.Show(@"Usuario(s) Eliminado(s)");
            CargaListaAllUsu();
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Asigna False al valor de los registros en el checkbox
            foreach (DataGridViewRow iRow in dataGridView1.Rows)
            {
                iRow.Cells[0].Value = false;
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dataGridView1.Rows[e.RowIndex];
            var id = row.Cells["Id"].Value.ToString();
            var frm = new Form_Usuarios(id);
            frm.CargaListaAllUsu += CargaListaAllUsu;
            frm.ShowDialog();
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            _bs.Filter = $" Nombre+' '+Puesto+' '+Usuario+' '+Correo LIKE '%{textBox_Buscar.Text}%'";
            dataGridView1.DataSource = _bs;
        }

        
    }
}
