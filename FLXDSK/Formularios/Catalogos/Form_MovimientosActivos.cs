using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Catalogos
{
    public partial class Form_MovimientosActivos : Form
    {
        Classes.Inventarios.Class_Almacen ClsAlmacen = new Classes.Inventarios.Class_Almacen();
        Classes.Catalogos.Class_Activos ClsAct = new Classes.Catalogos.Class_Activos();
        public event Form1.MessageHandler cargaListaActivos;
        string idactivo = "";
        string idAlmacenActual = "";
        string idAlmacenDestsino = "";

        public Form_MovimientosActivos(string tmpidactivo)
        {
            InitializeComponent();
            idactivo = tmpidactivo;
        }

        private void Form_MovimientosActivos_Load(object sender, EventArgs e)
        {
            DataTable dtActivo = new DataTable();
            dtActivo = ClsAct.getInfoById(idactivo);
            if (dtActivo.Rows.Count == 0) {
                MessageBox.Show("Informacion incorrecta");
                return;
            }
                
                try
                {
                    label_Producto.Text = dtActivo.Rows[0]["vchDescripcion"].ToString() + "\n\rCANTIDAD: " + dtActivo.Rows[0]["fCantidad"].ToString();

                    idAlmacenActual = dtActivo.Rows[0]["iidAlmacen"].ToString();
                    if (idAlmacenActual != "" && idAlmacenActual != "0") {
                        CargaAlmacenesNoOnlY(idAlmacenActual);
                    }
                }
                catch { 
                    cargaAlmacenes();
                }
                cargaInfoAlmacenActual();
            
        }
        private void cargaInfoAlmacenActual() {
            if (idAlmacenActual != "" && idAlmacenActual != "0")
            {
                DataTable dtAlm = new DataTable();
                dtAlm = ClsAlmacen.get_almacen_x_id(idAlmacenActual);
                if (dtAlm.Rows.Count > 0)
                {
                    label_AlmacenActualTitle.Text = "Almacen Origen ::" + dtAlm.Rows[0]["vchNombre"].ToString() + " ::";
                }
                else
                {
                    label_AlmacenActualTitle.Text = "SIN Almacen Origen ";
                }
            }

        }
        private void CargaAlmacenesNoOnlY(string idAlmacenActual)
        {
            DataTable dt = new DataTable("Metodos");
            dt = ClsAlmacen.getAlmacenesOnlyNot(idAlmacenActual);

            comboBox_Destino.DataSource = dt;
            comboBox_Destino.DisplayMember = "nombre";
            comboBox_Destino.ValueMember = "id";
        }
        private void cargaAlmacenes()
        {
            DataTable dt = new DataTable("Tipos");
            dt = ClsAlmacen.getAlmacenesAll();

            comboBox_Destino.DataSource = dt;
            comboBox_Destino.DisplayMember = "nombre";
            comboBox_Destino.ValueMember = "id";
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_Destino_SelectionChangeCommitted(object sender, EventArgs e)
        {
            idAlmacenDestsino = "";
            try
            {
                idAlmacenDestsino = comboBox_Destino.SelectedValue.ToString();
                if (idAlmacenDestsino != "" && idAlmacenDestsino != "0") {
                    CargaInfoAlmacenDestino(idAlmacenDestsino);
                }
            }
            catch { }
        }
        private void CargaInfoAlmacenDestino(string idAlmacenDestsino)
        {
            DataTable dtAlm = new DataTable();
            dtAlm = ClsAlmacen.get_almacen_x_id(idAlmacenDestsino);
            if (dtAlm.Rows.Count > 0)
            {
                label_Destino.Text = "Destino ::" + dtAlm.Rows[0]["vchNombre"].ToString() + " ::";
            }
            else
            {
                label_Destino.Text = "Selecione ";
            }
        }

        private void button_Mover_Click(object sender, EventArgs e)
        {
            double cantidadPasar = 0;
            try
            {
                cantidadPasar = Convert.ToDouble(textBox_Cantidad.Text);
            }
            catch {                 
            }
            if (cantidadPasar == 0) {
                MessageBox.Show("Es necesario una cantidad");
                textBox_Cantidad.Focus();
                return;
            }
            if (!ClsAct.PuedoPasarCantidad(idactivo, idAlmacenActual, cantidadPasar)) {
                MessageBox.Show("La cantidad es mayor a la que existe");
                textBox_Cantidad.Focus();
                return;
            }

            if (ClsAct.MueveMercancia(idactivo, idAlmacenActual, idAlmacenDestsino, cantidadPasar))
            {
                MessageBox.Show("Movimiento Realizado");
                try
                {
                    cargaListaActivos();
                }
                catch { }
                this.Close();
                return;
            }
            else {
                MessageBox.Show("Problema en el movimiento");
            }
        }
    }
}
