using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FLXDSK.Listas.Catalogos
{
    public partial class Form_List_Movimientos : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        BindingSource bs = new BindingSource();

        public Form_List_Movimientos()
        {
            InitializeComponent();
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Catalogos.Form_Movimientos frm = new Formularios.Catalogos.Form_Movimientos("");
            frm.Lista_Movimientos_Principal += new Form1.MessageHandler(Lista_Movimientos_Principal);
            frm.Show();
        }

        private void Lista_Movimientos_Principal()
        {
            string empresa = Classes.Class_Session.IDEMPRESA.ToString();
            dataGridView1.DataSource = null;
            string sql = " SELECT M.iidMovimiento Folio, A1.vchNombre AS [Almacen de Origen], " +
                         " A2.vchNombre AS [Almacen de Destino], " +
                         " CASE WHEN siTerminado = 1 THEN 'Termina' ELSE 'Pendiente' END AS Estatus, " +
                         " CONVERT(VARCHAR(10),M.dfechaIn,103) AS [Fecha de Movimiento] " +
                         " FROM catMovimientos M " +
                         " INNER JOIN catAlmacenes A1 ON M.iidAlmacenOrigen = A1.iidAlmacen " +
                         " INNER JOIN catAlmacenes A2 ON M.iidAlmacenDestino = A2.iidAlmacen " +
                         " AND M.iidEstatus = 1 " +
                         " ORDER BY M.dfechaIn DESC ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView1.DataSource = dstConsulta.Tables[0];

                dataGridView1.Columns["Folio"].Width = 200;
                dataGridView1.Columns["Folio"].ReadOnly = true;
                dataGridView1.Columns["Almacen de Origen"].Width = 200;
                dataGridView1.Columns["Almacen de Origen"].ReadOnly = true;
                dataGridView1.Columns["Almacen de Destino"].Width = 200;
                dataGridView1.Columns["Almacen de Destino"].ReadOnly = true;
                dataGridView1.Columns["Estatus"].Width = 200;
                dataGridView1.Columns["Estatus"].ReadOnly = true;
                dataGridView1.Columns["Fecha de Movimiento"].Width = 200;
                dataGridView1.Columns["Fecha de Movimiento"].ReadOnly = true;

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

        private void Form_List_Movimientos_Load(object sender, EventArgs e)
        {
            Lista_Movimientos_Principal();
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void toolStripButton_Editar_Click(object sender, EventArgs e)
        {
            //Valida que no haya mas de un registro seleccionado           
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

            if (contador > 1)
            {
                MessageBox.Show("Para editar solo seleccione un registro.");
                return;
            }
            else
            {

                foreach (DataGridViewRow registro in dataGridView1.Rows)
                {
                    try
                    {
                        if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                        {
                            string idmovimiento = registro.Cells["Folio"].Value.ToString();
                            Formularios.Catalogos.Form_Movimientos frm = new Formularios.Catalogos.Form_Movimientos(idmovimiento);
                            frm.Lista_Movimientos_Principal += new Form1.MessageHandler(Lista_Movimientos_Principal);
                            frm.Show();
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        private void toolStripButton_Detalle_Click(object sender, EventArgs e)
        {
            //Valida que no haya mas de un registro seleccionado           
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

            if (contador > 1)
            {
                MessageBox.Show("Para editar solo seleccione un registro.");
                return;
            }
            else
            {

                foreach (DataGridViewRow registro in dataGridView1.Rows)
                {
                    try
                    {
                        if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                        {
                            string idmovimiento = registro.Cells["Folio"].Value.ToString();
                            Reportes.Catalogos.Reporte_Detalle_Movimientos frm = new Reportes.Catalogos.Reporte_Detalle_Movimientos(idmovimiento);                            
                            frm.Show();
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Folio+' '+[Almacen de Origen]+' '+[Almacen de Destino]+' '+Estatus+' '+[Fecha de Movimiento] LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView1.DataSource = bs;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string idmovimiento = row.Cells["Folio"].Value.ToString();
                Formularios.Catalogos.Form_Movimientos frm = new Formularios.Catalogos.Form_Movimientos(idmovimiento);
                frm.Lista_Movimientos_Principal += new Form1.MessageHandler(Lista_Movimientos_Principal);
                frm.ShowDialog();
            }
        }
    }
}
