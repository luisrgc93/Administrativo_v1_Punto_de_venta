using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Listas.Catalogos
{
    public partial class Form_ActivosFijos : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Catalogos.Class_Activos ClsAct = new Classes.Catalogos.Class_Activos();
        BindingSource bs = new BindingSource();
        

        public Form_ActivosFijos()
        {
            InitializeComponent();
        }

        private void Form_ActivosFijos_Load(object sender, EventArgs e)
        {
            cargaListaActivos();
        }
        private void cargaListaActivos()
        {
            string sql = " select   A.iidActivo Id, convert(varchar(10),A.dfechaIn,103)Creado, convert(varchar(10),A.dfechaup,103)Modificado,   T.vchDescripcion Categoria, "+
                        "         A.vchDescripcion Activo,  " +
                        "         fCantidad Cantidad, fCostoUnitario PrecioUnitario,  "+
                        "         fCantidad * fCostoUnitario as Total, "+
                        "         L.vchNombre Almacen "+
                        "     FROM catActivos A left outer join catAlmacenes L on A.iidAlmacen = L.iidAlmacen, "+
                        "     catTiposActivos T "+
                        "     WHERE T.iidTipoActivo = A.iidTipoActivo  "+
                        "     AND A.iidEstatus= 1  "+
                        " ORDER BY  A.iidActivo DESC ";
            dataGridView1.DataSource = null;
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["Id"].Width = 80;
                dataGridView1.Columns["Id"].Visible = false;
                dataGridView1.Columns["Creado"].Width = 90;
                dataGridView1.Columns["Creado"].ReadOnly = true;
                dataGridView1.Columns["Modificado"].Width = 90;
                dataGridView1.Columns["Modificado"].ReadOnly = true;
                dataGridView1.Columns["Categoria"].Width = 150;
                dataGridView1.Columns["Categoria"].ReadOnly = true;
                dataGridView1.Columns["Activo"].Width = 250;
                dataGridView1.Columns["Activo"].ReadOnly = true;
                dataGridView1.Columns["Almacen"].Width = 180;
                dataGridView1.Columns["Almacen"].ReadOnly = true;
                dataGridView1.Columns["Cantidad"].Width = 90;
                dataGridView1.Columns["Cantidad"].ReadOnly = true;
                dataGridView1.Columns["PrecioUnitario"].Width = 100;
                dataGridView1.Columns["PrecioUnitario"].ReadOnly = true;
                dataGridView1.Columns["Total"].Width = 120;
                dataGridView1.Columns["Total"].ReadOnly = true;

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
                
            }
            bs.DataSource = dataGridView1.DataSource;
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Form_Activos frm = new Formularios.Catalogos.Form_Activos("");
            frm.cargaListaActivos += new Form1.MessageHandler(cargaListaActivos);
            frm.ShowDialog();
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void toolStripButton_Borrar_Click(object sender, EventArgs e)
        {
            //Valida que haya mas de un registro seleccionado  
            int contador = 0;
            //Finaliza modo de edicion
            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                    }
                }
                catch { }
            }

            if (contador == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un registro.");
                return;
            }

            DialogResult resultado;

            if (contador <= 1)
            {
                resultado = MessageBox.Show(@"Esta seguro de eliminar este registro", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
            else
            {
                resultado = MessageBox.Show(@"Esta seguro de eliminar estos registros", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }


            if (DialogResult.OK == resultado)
            {
                dataGridView1.EndEdit();
                foreach (DataGridViewRow registro in dataGridView1.Rows)
                {
                    try
                    {
                        if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                        {
                            ClsAct.BorrarRegistro(registro.Cells["Id"].Value.ToString());
                        }
                    }
                    catch { }
                }
                MessageBox.Show("Eliminado con exito");
                cargaListaActivos();
            }
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            int contador = 0;

            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                    }
                }
                catch { }
            }

            if (contador == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un registro.");
                return;
            }

            if (contador != 1)
            {
                MessageBox.Show("Solo puede seleccionar un campo para su edicion. ");
            }
            else
            {
                dataGridView1.EndEdit();
                foreach (DataGridViewRow registro in dataGridView1.Rows)
                {
                    try
                    {
                        if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                        {
                            string iid = registro.Cells["Id"].Value.ToString();
                            Formularios.Catalogos.Form_Activos frm = new Formularios.Catalogos.Form_Activos(iid);
                            frm.cargaListaActivos += new Form1.MessageHandler(cargaListaActivos);
                            frm.ShowDialog();
                        }
                    }
                    catch { }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string iiD = row.Cells["Id"].Value.ToString();
                Formularios.Catalogos.Form_Activos frm = new Formularios.Catalogos.Form_Activos(iiD);
                frm.cargaListaActivos += new Form1.MessageHandler(cargaListaActivos);
                frm.ShowDialog();
            }
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Categoria+' '+Activo LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }

        private void toolStripButton_PDF_Click(object sender, EventArgs e)
        {
            toolStripButton_Add.Enabled = false;
            toolStripButton_Borrar.Enabled = false;
            toolStripButton_Edit.Enabled = false;

            splitContainer1.Panel2.Controls.Clear();
            Reportes.Catalogos.Form_Reporte_Activos frmulario = new Reportes.Catalogos.Form_Reporte_Activos();
            frmulario.TopLevel = false;
            frmulario.AutoScroll = true;
            frmulario.FormBorderStyle = FormBorderStyle.None;
            frmulario.WindowState = frmulario.WindowState;
            splitContainer1.Panel2.Controls.Add(frmulario);
            frmulario.Visible = true;
        }

        private void toolStripButton_Movimientos_Click(object sender, EventArgs e)
        {
            int contador = 0;

            dataGridView1.EndEdit();
            foreach (DataGridViewRow registro in dataGridView1.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                    }
                }
                catch { }
            }

            if (contador == 0)
            {
                MessageBox.Show("Debe seleccionar al menos un registro.");
                return;
            }

            if (contador != 1)
            {
                MessageBox.Show("Solo puede seleccionar un campo para su edicion. ");
            }
            else
            {
                dataGridView1.EndEdit();
                foreach (DataGridViewRow registro in dataGridView1.Rows)
                {
                    try
                    {
                        if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                        {
                            string iid = registro.Cells["Id"].Value.ToString();

                            Formularios.Catalogos.Form_MovimientosActivos frm = new Formularios.Catalogos.Form_MovimientosActivos(iid);
                            frm.cargaListaActivos += new Form1.MessageHandler(cargaListaActivos);
                            frm.ShowDialog();
                        }
                    }
                    catch { }
                }
            }
        }
    }
}
