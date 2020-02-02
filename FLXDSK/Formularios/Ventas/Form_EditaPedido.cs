using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FLXDSK.Formularios.Ventas
{
    public partial class Form_EditaPedido : Form
    {
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Ventas.Class_Pedidos ClsPedidos = new Classes.Ventas.Class_Pedidos();
        Classes.Ventas.Class_DetallePedido ClsDetallePedidos = new Classes.Ventas.Class_DetallePedido();
        

        DataTable dtInfoPedido = null;        
        string IdPedido = "";

        public Form_EditaPedido(string id)
        {
            InitializeComponent();
            IdPedido = id;
        }

        private void Form_EditaPedido_Load(object sender, EventArgs e)
        {
            if (IdPedido == "")
            {
                MessageBox.Show("Informacion incorrecta");
                this.Close();
                return;
            }


            dtInfoPedido = ClsPedidos.getLista(" AND  P.iidPedido = " + IdPedido);
            if (dtInfoPedido.Rows.Count == 0)
            {
                MessageBox.Show("Pedido no encontrado");
                this.Close();
                return;
            }

            label_titulo.Text = "No Pedido: " + IdPedido;
            label_Mesero.Text = dtInfoPedido.Rows[0]["Mesero"].ToString();
            label_AreaMesa.Text = dtInfoPedido.Rows[0]["Area"].ToString()+" / "+dtInfoPedido.Rows[0]["Mesa"].ToString();

            try
            {
                label_Total.Text = string.Format("{0:c}", Convert.ToDouble(dtInfoPedido.Rows[0]["fTotal"].ToString()));
                label_Descuento.Text = string.Format("{0:c}", Convert.ToDouble(dtInfoPedido.Rows[0]["fDescuento"].ToString()));
                label_Subtotal.Text = string.Format("{0:c}", Convert.ToDouble(dtInfoPedido.Rows[0]["fSubtotal"].ToString()));
            }
            catch { }

            CargaDetalle();
        }
        private void CargaDetalle()
        {
            try
            {

           
            string sql = " " +
            " SELECT D.iidProducto, MAX(P.vchDescripcion) Producto, MAX(D.fPrecio)Precio, SUM(D.fCantidad)Cantidad, SUM(D.fImporte)Importe, SUM(D.fCantidad) Existen " +
            " FROM catDetallePedido D (NOLOCK), catProductos P (NOLOCK) " +
            " WHERE D.iidProducto = P.iidProducto " +
            " AND D.iidPedido = " + IdPedido +
            " GROUP BY D.iidProducto " +
            " " ;

            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            areas.Fill(dstConsulta, "Datos");
            dataGridView_Lista.DataSource = dstConsulta.Tables[0];

            //Se define el tamaño de las columnas
            dataGridView_Lista.Columns["iidProducto"].Visible = false;
            dataGridView_Lista.Columns["Producto"].ReadOnly = true;
            dataGridView_Lista.Columns["Precio"].ReadOnly = true;
            dataGridView_Lista.Columns["Cantidad"].Width = 85;
            dataGridView_Lista.Columns["Importe"].ReadOnly = true;
            dataGridView_Lista.Columns["Precio"].DefaultCellStyle.Format = "c";
            dataGridView_Lista.Columns["Importe"].DefaultCellStyle.Format = "c";
            

            //Agregar CheckBox
            DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            checkColumn.Name = "Seleccionar";
            checkColumn.HeaderText = "Seleccionar";
            checkColumn.Width = 70;
            checkColumn.FillWeight = 40;
            
            Boolean existe = false;
            for (Int32 i = 0; i < dataGridView_Lista.Columns.Count; i++)
            {
                DataGridViewColumn icolumna = dataGridView_Lista.Columns[i];
                if (icolumna.Name == "Seleccionar")
                {   
                    icolumna.Width = 70;
                    existe = true;
                }
            }


            return;

            }
            catch (Exception)
            {


            }
        }

        private void dataGridView_Lista_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView_Lista.Rows[e.RowIndex];
            double Precio, Importe = 0;
            int Cantidad, Existen = 0;
            string iidProducto = "";
            try
            {
                Existen = Convert.ToInt32(row.Cells["Existen"].Value);
                Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                Precio = Convert.ToDouble(row.Cells["Precio"].Value);
                iidProducto = row.Cells["iidProducto"].Value.ToString();

                //Importe = Cantidad * Precio;
                //row.Cells["Importe"].Value = Importe.ToString();*/

            }
            catch
            {
                Cantidad = 0;
                row.Cells["Cantidad"].Value = "0";
                row.Cells["Importe"].Value = "0";
            }

            if (Cantidad > Existen)
            {
                //Insertamos
                int Insertar = Cantidad - Existen;
                ClsDetallePedidos.InsertaCantidades(IdPedido, iidProducto, Insertar);
            }
            else
            {
                if (Cantidad < Existen)
                {
                    if(Cantidad== 0)
                    {
                        ClsDetallePedidos.SetCantidadAll0(IdPedido, iidProducto);
                    }
                    else
                    {
                        //Restamos
                        ClsDetallePedidos.RestaCantidades(IdPedido, iidProducto, Cantidad);
                    }
                }
            }

            CalulaTotales();
            CargaDetalle();
        }
        private void CalulaTotales()
        {
            ClsDetallePedidos.RecalculaPedido(IdPedido);

            dtInfoPedido = ClsPedidos.getLista(" AND  P.iidPedido = " + IdPedido);
            if (dtInfoPedido.Rows.Count == 0)
            {
                MessageBox.Show("Pedido no encontrado");
                this.Close();
                return;
            }

            label_Total.Text = string.Format("{0:c}", Convert.ToDouble(dtInfoPedido.Rows[0]["fTotal"].ToString()));
            label_Descuento.Text = string.Format("{0:c}", Convert.ToDouble(dtInfoPedido.Rows[0]["fDescuento"].ToString()));
            label_Subtotal.Text = string.Format("{0:c}", Convert.ToDouble(dtInfoPedido.Rows[0]["fSubtotal"].ToString()));
        }


    }
}
