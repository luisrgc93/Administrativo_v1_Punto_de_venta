using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Listas.Inventarios
{
    public partial class Form_List_Ajustes : Form
    {
        string TipoMov = "";

        BindingSource bs = new BindingSource();


        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Inventarios.Class_ExiMovimientoMatPrima ClsExiMov = new Classes.Inventarios.Class_ExiMovimientoMatPrima();
        Classes.Inventarios.Class_ExistenciaMP ClsExistencia = new Classes.Inventarios.Class_ExistenciaMP();

        public Form_List_Ajustes(string tipo)
        {
            InitializeComponent();
            TipoMov = tipo;
        }

        private void Form_List_Ajustes_Load(object sender, EventArgs e)
        {
             CargaLista();
        }
        public void CargaLista()
        {
            string sql = "SELECT M.iidMovimiento Folio, M.iidAlmacen, CONVERT(varchar(10),M.dfechaUp,103)Actualizado, " +
                " M.vchTipo Tipo, A.vchNombre Almacen, " +
                " CASE M.iidEstatus WHEN 0 THEN 'PENDIENTE' WHEN 1 THEN 'PROCESADO' END Estatus, M.vchComentario Comentario " +
            " FROM exiMovimientoMateriaPrima (NOLOCK) M, catAlmacenes A (NOLOCK) " +
            " WHERE M.iidAlmacen = A.iidAlmacen " +
            " AND M.iidEstatus <> 2 " +
            " AND M.vchTipo = '" + TipoMov + "' " +
            " ORDER BY M.iidMovimiento desc ";

            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView_Lista.DataSource = dstConsulta.Tables[0];

                dataGridView_Lista.Columns["Folio"].Width = 80;
                dataGridView_Lista.Columns["Folio"].ReadOnly = true;
                dataGridView_Lista.Columns["iidAlmacen"].Visible = false;
                dataGridView_Lista.Columns["Almacen"].Width = 100;
                dataGridView_Lista.Columns["Almacen"].ReadOnly = true;
                dataGridView_Lista.Columns["Actualizado"].Width = 100;
                dataGridView_Lista.Columns["Actualizado"].ReadOnly = true;
                dataGridView_Lista.Columns["Tipo"].Width = 100;
                dataGridView_Lista.Columns["Tipo"].ReadOnly = true;
                dataGridView_Lista.Columns["Comentario"].Width = 200;
                dataGridView_Lista.Columns["Comentario"].ReadOnly = true;
                dataGridView_Lista.Columns["Estatus"].Width = 100;
                dataGridView_Lista.Columns["Estatus"].ReadOnly = true;

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
            { }
            bs.DataSource = dataGridView_Lista.DataSource;
        }
        private void textBox_Buscar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Folio+' '+Estatus+' '+Comentario LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView_Lista.DataSource = bs;
        }

        private void toolStripButton_Add_Click(object sender, EventArgs e)
        {
            Formularios.Inventarios.Form_Ajuste Form = new Formularios.Inventarios.Form_Ajuste("", TipoMov);
            Form.CargaLista += new Form1.MessageHandler(CargaLista);
            Form.Show();
        }

        private void toolStripButton_Procesar_Click(object sender, EventArgs e)
        {
            string IdRegistro = "";
            string Estatus = "";
            string iidAlmacen = "";
            string Tipo = "";
            int contador = 0;
            dataGridView_Lista.EndEdit();
            foreach (DataGridViewRow registro in dataGridView_Lista.Rows)
            {
                try
                {
                    if ((Boolean)registro.Cells["Seleccionar"].Value == true)
                    {
                        contador++;
                        IdRegistro = registro.Cells["Folio"].Value.ToString();
                        Estatus = registro.Cells["Estatus"].Value.ToString();
                        iidAlmacen = registro.Cells["iidAlmacen"].Value.ToString();
                        Tipo = registro.Cells["Tipo"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }

            if (Estatus == "PROCESADO")
            {
                MessageBox.Show("El Movimiento ya se encuentra Procesado");
                return;
            }


            if (Tipo == "Ajuste")
            {
                DialogResult resultado = MessageBox.Show(@"Esta seguro de Procesar el Movimiento", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult.OK == resultado)
                {
                    //BorraAlmacen
                    ClsExistencia.CleanOnlyProducts(IdRegistro, TipoMov, iidAlmacen);

                    if (ClsExiMov.ProcesaMovimiento(IdRegistro, TipoMov, iidAlmacen))
                    {
                        MessageBox.Show("Procesado Correctamente.");
                        CargaLista();
                        return;
                    }
                    {
                        MessageBox.Show("Problema al Procesar, Contacte al Administrador.");
                        return;
                    }
                }
            }
            else
            {
                //Inicial
                DialogResult resultado = MessageBox.Show(@"Esta seguro de Procesar el Movimiento, será BORRADO TODO EL ALMACEN", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult.OK == resultado)
                {
                    //BorraAlmacen
                    ClsExistencia.CleanAlmacen(iidAlmacen);

                    if (ClsExiMov.ProcesaMovimiento(IdRegistro, TipoMov, iidAlmacen))
                    {
                        MessageBox.Show("Procesado Correctamente.");
                        CargaLista();
                        return;
                    }
                    {
                        MessageBox.Show("Problema al Procesar, Contacte al Administrador.");
                        return;
                    }
                }
            }
        }

        private void toolStripButton_Borrar_Click(object sender, EventArgs e)
        {
            string IdRegistro = "";
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
                        IdRegistro = registro.Cells["Folio"].Value.ToString();
                        Estatus = registro.Cells["Estatus"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }
            
            if (Estatus =="PROCESADO")
            {
                MessageBox.Show("No puedes eliminar un movimiento ya procesado.");
                return;
            }


            DialogResult resultado = MessageBox.Show(@"Esta seguro de eliminar este registro", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (DialogResult.OK == resultado)
            {
                if(ClsExiMov.Eliminar(IdRegistro,TipoMov))
                {
                    MessageBox.Show("Eliminado Correctamente.");
                    CargaLista();
                    return;
                }
                else
                {
                    MessageBox.Show("Problema al Eliminar.");
                    return;
                }
            }
        }

        private void toolStripButton_Edit_Click(object sender, EventArgs e)
        {
            string IdRegistro = "";
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
                        IdRegistro = registro.Cells["Folio"].Value.ToString();
                        Estatus = registro.Cells["Estatus"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }

            if (Estatus == "PROCESADO")
            {
                MessageBox.Show("No puedes Editar un movimiento ya procesado.");
                return;
            }

            Formularios.Inventarios.Form_Ajuste Form = new Formularios.Inventarios.Form_Ajuste(IdRegistro, TipoMov);
            Form.CargaLista += new Form1.MessageHandler(CargaLista);
            Form.ShowDialog();
        }
        private void toolStripButton_PDF_Click(object sender, EventArgs e)
        {
            string IdRegistro = "";
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
                        IdRegistro = registro.Cells["Folio"].Value.ToString();
                        Estatus = registro.Cells["Estatus"].Value.ToString();
                    }
                }
                catch { }
            }

            if (contador != 1)
            {
                MessageBox.Show("Debe seleccionar solo un registro.");
                return;
            }

            Reportes.Existencias.Form_Reporte_Ajustes Form = new Reportes.Existencias.Form_Reporte_Ajustes(IdRegistro, TipoMov);
            Form.ShowDialog();
        }
        private void toolStripButton_Salir_Click(object sender, EventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }

        private void dataGridView_Lista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView_Lista.Rows[e.RowIndex];
                string Folio = row.Cells["Folio"].Value.ToString();

                Formularios.Inventarios.Form_Ajuste frm = new Formularios.Inventarios.Form_Ajuste(Folio,TipoMov);
                frm.CargaLista += new Form1.MessageHandler(CargaLista);
                frm.ShowDialog();
            }
        }

        private void textBox_Buscar_TextChanged_1(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" Folio+' '+Comentario LIKE '%{0}%'", textBox_Buscar.Text);
            dataGridView_Lista.DataSource = bs;
        }

        

        

        
    }
}
