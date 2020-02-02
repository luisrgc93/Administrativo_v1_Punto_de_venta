using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Listas.Ventas
{
    public partial class Form_List_MovimientoDin : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Ventas.Class_MovimiendoDin ClsMovDin = new Classes.Ventas.Class_MovimiendoDin();

        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();


        public Form_List_MovimientoDin()
        {
            InitializeComponent();
        }

        private void Form_List_MovimientoDin_Load(object sender, EventArgs e)
        {
            CargarLista();
        }
        public void CargarLista()
        {

            string sql = " SELECT S.iidMovimiento, S.iidTipoMovimiento, CONVERT(VARCHAR(10), S.dfechaIn, 103) AS Creado,  " +
                " CASE S.siEntrada WHEN 1 THEN 'ENTRADA' ELSE 'SALIDA' END Tipo, " +
                " CASE S.iidCorte WHEN 0 THEN 'PENDIENTE' ELSE 'PROCESADO' END Estatus, " +
                " T.vchNombre Nombre, " +
	            " S.fMonto Monto, S.vchComentario Motivo	 " +
            " FROM catMovimientoDinero S  (NOLOCK),  CatTipoMovimiento T (NOLOCK) " +
            " WHERE T.iidTipoMovimiento = S.iidTipoMovimiento " +
            " AND S.iidEstatus = 1 " +
            " ORDER BY T.dfechaIn desc ";
            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Lista.DataSource = dstConsulta.Tables[0];

                //Se define el tamaño de las columnas
                dataGridView_Lista.Columns["iidMovimiento"].Visible = false;
                dataGridView_Lista.Columns["iidTipoMovimiento"].Visible = false;
                dataGridView_Lista.Columns["Creado"].ReadOnly = true;
                dataGridView_Lista.Columns["Tipo"].ReadOnly = true;
                dataGridView_Lista.Columns["Estatus"].ReadOnly = true;
                dataGridView_Lista.Columns["Nombre"].ReadOnly = true;
                dataGridView_Lista.Columns["Monto"].ReadOnly = true;
                dataGridView_Lista.Columns["Monto"].DefaultCellStyle.Format = "c";
                dataGridView_Lista.Columns["Motivo"].ReadOnly = true;

                if (!dataGridView_Lista.Columns.Contains("Seleccionar"))
                {
                    DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                    checkColumn.Name = "Seleccionar";
                    checkColumn.HeaderText = "Seleccionar";
                    checkColumn.Width = 80;
                    checkColumn.FillWeight = 40;
                    dataGridView_Lista.Columns.Insert(0, checkColumn);
                }


            }
            catch
            {
                MessageBox.Show("No hay Informacion");
            }
            bs.DataSource = dataGridView_Lista.DataSource;
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Ventas.Form_AgregarGasto frm = new Formularios.Ventas.Form_AgregarGasto();
            frm.CargarLista += new Form1.MessageHandler(CargarLista);
            frm.ShowDialog();
        }

        private void toolStripButton_Borrar_Click(object sender, EventArgs e)
        {
            string IdBorrar = "";
            string Estatus = "";
            int contador = 0;
            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdBorrar = registro.Cells["iidMovimiento"].Value.ToString();
                        Estatus = registro.Cells["Estatus"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar al solo un registro.");
                return;
            }
            if (Estatus != "PENDIENTE")
            {
                MessageBox.Show("No se pueden eliminar Movimientos ya procesados con el corte");
                return;
            }

            DialogResult resultado = MessageBox.Show(@"Esta seguro de eliminar este registro", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == resultado)
            {
                if (ClsMovDin.Borrar(IdBorrar))
                {
                    MessageBox.Show("Eliminado con exito");
                    CargarLista();
                }
                else
                {
                    MessageBox.Show("Problema al eliminar");
                }
            }
        }

        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

    }
}
