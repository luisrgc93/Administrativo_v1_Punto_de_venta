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
    public partial class Form_Movimientos : Form
    {
        string idproducto = "";
        string idMovimiento = "";
        string unidad_calculos = "";
        string conversion_textBox_cantidad = "";
        string fContenidoXPieza = "";
        string unidad_real = "";
        bool botella = false;
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        Classes.Catalogos.Class_Movimientos ClsMov = new Classes.Catalogos.Class_Movimientos();
        Classes.Catalogos.Mercancia.Class_Materia_Prima ClsMat = new Classes.Catalogos.Mercancia.Class_Materia_Prima();
        Classes.Catalogos.Mercancia.Class_Productos ClsPro = new Classes.Catalogos.Mercancia.Class_Productos();
        Classes.Internos.Class_UnidadesMetricas ClsUnidadMedida = new Classes.Internos.Class_UnidadesMetricas();

        public event Form1.MessageHandler Lista_Movimientos_Principal;
        BindingSource bs = new BindingSource();

        public Form_Movimientos(string idmovimiento)
        {
            InitializeComponent();
            this.idMovimiento = idmovimiento;
        }

        private void Form_Movimientos_Load(object sender, EventArgs e)
        {
            Lista_Movimientos();
            llenar_combos();

            if (idMovimiento != "")
            {
                cargar_datos();
            }
        }

        public void cargar_datos()
        {
            if (idMovimiento != "")
            {
                if(ClsMov.movimiento_terminado(idMovimiento))
                {
                    button_terminar.Enabled = false;
                }
            }

            Lista_Movimientos();

            DataTable movimiento = new DataTable();
            movimiento = ClsMov.obtener_movimiento(idMovimiento);

            DataRow row = movimiento.Rows[0];

            comboBox_origen.SelectedValue = row["iidAlmacenOrigen"].ToString();
            comboBox_destino.SelectedValue = row["iidAlmacenDestino"].ToString();
            comboBox_destino.Enabled = false;
            comboBox_origen.Enabled = false;
        }

        public void llenar_combos()
        {
            DataTable almacenDestino = new DataTable();
            almacenDestino = ClsMov.getAlmacenesAll();

            comboBox_destino.DataSource = almacenDestino;
            comboBox_destino.DisplayMember = "nombre";
            comboBox_destino.ValueMember = "id";

            DataTable almacenOrigen = new DataTable();
            almacenOrigen = ClsMov.getAlmacenesAll();

            comboBox_origen.DataSource = almacenOrigen;
            comboBox_origen.DisplayMember = "nombre";
            comboBox_origen.ValueMember = "id";

            DataTable dtUnidades = ClsUnidadMedida.getListaWhere(" WHERE iidEstatus = 1 ");
            comboBox_unidades.DataSource = dtUnidades;
            comboBox_unidades.DisplayMember = "vchNombre";
            comboBox_unidades.ValueMember = "iidUnidad";

            DataTable tipo = new DataTable("TablaTipo");
            tipo.Columns.Add("tipo");
            tipo.Columns.Add("idtipo");
            DataRow drtipo;
            drtipo = tipo.NewRow();
            drtipo[1] = "0";
            drtipo[0] = "Seleccionar";
            tipo.Rows.Add(drtipo);
            drtipo = tipo.NewRow();
            drtipo[1] = "1";
            drtipo[0] = "Materia Prima";
            tipo.Rows.Add(drtipo);
            drtipo = tipo.NewRow();
            drtipo[1] = "2";
            drtipo[0] = "Productos";
            tipo.Rows.Add(drtipo);

            comboBox_tipo_producto.DataSource = tipo;
            comboBox_tipo_producto.DisplayMember = "tipo";
            comboBox_tipo_producto.ValueMember = "idtipo";
        }

        private void Lista_Movimientos() 
        {
            if (idMovimiento != "")
            {
                string empresa = Classes.Class_Session.IDEMPRESA.ToString();
                dataGridView1.DataSource = null;
                string sql = " SELECT M.iidMovimiento, A1.vchNombre AS [Almacen de Origen], " +
                             " A2.vchNombre AS [Almacen de Destino],  " +
                             " CASE  " +
                             " WHEN R.iTipo_producto = 1 THEN 'Materia Prima'  " +
                             " END AS [Descontado de], MP.vchDescripcion Producto,  " +
                             "                              	CASE   " +
		                             " WHEN U.iidUnidad = 1 AND R.iCantidad >= 1000 THEN R.iCantidad / 1000  " +
		                             " WHEN U.iidUnidad = 1 AND R.iCantidad < 1000 THEN R.iCantidad  " +
		                             " WHEN U.iidUnidad = 2 AND R.iCantidad >= 1000 THEN R.iCantidad / 29.574  " +
		                             " WHEN U.iidUnidad = 2 AND R.iCantidad < 1000 THEN R.iCantidad  " +
		                             " WHEN U.iidUnidad = 3 AND R.iCantidad >= 1000 THEN R.iCantidad / 1000  " +
		                             " WHEN U.iidUnidad = 3 AND R.iCantidad < 1000 THEN R.iCantidad  " +
		                             " WHEN U.iidUnidad = 5 AND R.iCantidad >= 1000 THEN R.iCantidad / 1000  " +
		                             " WHEN U.iidUnidad = 5 AND R.iCantidad < 1000 THEN R.iCantidad  " +
		                             " WHEN U.iidUnidad = 6 AND R.iCantidad >= 1 THEN R.iCantidad   " +
		                             " WHEN U.iidUnidad = 6 AND R.iCantidad < 1 THEN R.iCantidad   " +
	                             " END AS [Cantidad Requerida],  " +
	                             " CASE   " +
		                             " WHEN U.iidUnidad = 1 AND R.iCantidad >= 1000 THEN 'Litros'  " +
		                             " WHEN U.iidUnidad = 1 AND R.iCantidad < 1000 THEN 'Mililitros'  " +
		                             " WHEN U.iidUnidad = 2 AND R.iCantidad >= 1000 THEN 'Onzas'  " +
		                             " WHEN U.iidUnidad = 2 AND R.iCantidad < 1000 THEN 'Onzas'  " +
		                             " WHEN U.iidUnidad = 3 AND R.iCantidad >= 1000 THEN 'Kilos'  " +
		                             " WHEN U.iidUnidad = 3 AND R.iCantidad < 1000 THEN 'Gramos'  " +
		                             " WHEN U.iidUnidad = 5 AND R.iCantidad >= 1000 THEN 'Litros'  " +
		                             " WHEN U.iidUnidad = 5 AND R.iCantidad < 1000 THEN 'Mililitros'  " +
		                             " WHEN U.iidUnidad = 6 AND R.iCantidad >= 1 THEN 'Kilos'  " +
		                             " WHEN U.iidUnidad = 6 AND R.iCantidad < 1 THEN 'Gramos' 	  " +
                                 " END AS [Tipo de Unidad]	  " +
                             " FROM catMovimientos M  " +
                             " INNER JOIN RelAlmacenMovimiento R ON M.iidMovimiento = R.iidMovimiento  " +
                             " INNER JOIN catAlmacenes A1 ON M.iidAlmacenOrigen = A1.iidAlmacen  " +
                             " INNER JOIN catAlmacenes A2 ON M.iidAlmacenDestino = A2.iidAlmacen  " +
                             " INNER JOIN catMateriaPrima MP ON R.iidProducto = MP.iidMateriPrima  " +
                             " INNER JOIN catUnidadesMetricas U ON R.iidUnidad = U.iidUnidad  " +
                             " AND M.iidEstatus = 1  " +
                             " AND M.iidMovimiento =  " + idMovimiento +
                             " AND R.iTipo_producto = 1  " +
                             " UNION ALL  " +
                             " SELECT M.iidMovimiento, A1.vchNombre AS [Almacen de Origen],  " +
                             " A2.vchNombre AS [Almacen de Destino],  " +
                             " CASE  " +
                             " WHEN R.iTipo_producto = 2 THEN 'Productos'  " +
                             " END AS [Descontado de], MP.vchDescripcion Producto,  " +
                             " R.iCantidad [Cantidad Requerida], U.vchNombre [Tipo de Unidad]  " +
                             " FROM catMovimientos M  " +
                             " iNNER JOIN RelAlmacenMovimiento R ON M.iidMovimiento = R.iidMovimiento  " +
                             " INNER JOIN catAlmacenes A1 ON M.iidAlmacenOrigen = A1.iidAlmacen  " +
                             " INNER JOIN catAlmacenes A2 ON M.iidAlmacenDestino = A2.iidAlmacen  " +
                             " INNER JOIN catProductos MP ON R.iidProducto = MP.iidProducto  " +
                             " INNER JOIN catUnidadesMetricas U ON R.iidUnidad = U.iidUnidad  " +
                             " AND M.iidEstatus = 1  " +
                             " AND M.iidMovimiento =  " + idMovimiento +
                             " AND R.iTipo_producto = 2  ";

                SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
                DataSet dstConsulta = new DataSet();
                try
                {
                    areas.Fill(dstConsulta, "Datos");
                    dataGridView1.DataSource = dstConsulta.Tables[0];

                    dataGridView1.Columns["iidMovimiento"].Visible = false;
                    dataGridView1.Columns["Almacen de Origen"].Width = 120;
                    dataGridView1.Columns["Almacen de Origen"].ReadOnly = true;
                    dataGridView1.Columns["Almacen de Destino"].Width = 120;
                    dataGridView1.Columns["Almacen de Destino"].ReadOnly = true;
                    dataGridView1.Columns["Descontado de"].Width = 120;
                    dataGridView1.Columns["Descontado de"].ReadOnly = true;
                    dataGridView1.Columns["Producto"].Width = 120;
                    dataGridView1.Columns["Producto"].ReadOnly = true;
                    dataGridView1.Columns["Cantidad Requerida"].Width = 120;
                    dataGridView1.Columns["Cantidad Requerida"].ReadOnly = true;
                    dataGridView1.Columns["Tipo de Unidad"].Width = 120;
                    dataGridView1.Columns["Tipo de Unidad"].ReadOnly = true;
                }
                catch
                {

                }
                bs.DataSource = dataGridView1.DataSource;
            }
        }

        private void button_buscar_Click(object sender, EventArgs e)
        {
            string almacen = comboBox_origen.SelectedValue.ToString();

            if (almacen == "0")
            {
                MessageBox.Show("Debe de seleccionar el almacen de origen.");
                return;
            }

            if (comboBox_tipo_producto.SelectedValue.ToString() != "0")
            {
                if (comboBox_tipo_producto.SelectedValue.ToString() == "1")
                {
                    Formularios.Form_Buscar_mov frm = new Form_Buscar_mov("Existencias Materia Prima",almacen);
                    frm.ShowDialog();
                    string id = Classes.Class_Session.idbuscador.ToString();
                    if (ClsMov.existe_producto_almacen(id, almacen, "1"))
                    {
                        idproducto = id;
                    }

                    label_modelo.Text = "";
                    DataTable productos = new DataTable();
                    //productos = ClsMat.obtener_materia_prima(idproducto);

                    if (productos.Rows.Count != 0)
                    {
                        DataRow prod = productos.Rows[0];
                        label_modelo.Text = prod["vchCodigo"].ToString() + " - " + prod["vchDescripcion"].ToString();
                        this.textBox_cantidad.Focus();

                        DataTable tipo = new DataTable();
                        tipo = null;// ClsMat.obtener_existencia_materia_prima(idproducto, almacen);
                        
                        DataRow Rows = tipo.Rows[0];

                        DataTable dtUnidades = ClsUnidadMedida.getListaWhere(" WHERE iidUnidad = " + Rows["iidUnidadMetrica"].ToString());
                        DataRow row = dtUnidades.Rows[0];

                        if (Rows["iidUnidadMetrica"].ToString() == "1" || Rows["iidUnidadMetrica"].ToString() == "2" || Rows["iidUnidadMetrica"].ToString() == "5")
                        {
                            unidad_real = Rows["iidUnidadMetrica"].ToString();
                            unidad_calculos = row["iEquivalencia"].ToString();
                            string abreviatura = "Botellas";
                            fContenidoXPieza = Rows["fContenidoXPieza"].ToString();
                            double cantidad_texto = Convert.ToDouble(Rows["fCantidad"]) / Convert.ToDouble(fContenidoXPieza);
                            conversion_textBox_cantidad = (Convert.ToDouble(Rows["fCantidad"]) / Convert.ToDouble(unidad_calculos)).ToString();
                            textBox_cantidad.Text = cantidad_texto.ToString() + " " + abreviatura;
                            botella = true;
                            comboBox_unidades.SelectedValue = "4";
                            comboBox_unidades.Enabled = false;
                        }
                        else
                        {
                            fContenidoXPieza = Rows["fContenidoXPieza"].ToString();
                            unidad_calculos = row["iEquivalencia"].ToString();
                            string abreviatura = row["vchAbreviacion"].ToString();
                            if (Convert.ToDouble(Rows["fCantidad"]) >= 1000)
                            {
                                double cantidad = Convert.ToDouble(Rows["fCantidad"])/1000;
                                textBox_cantidad.Text = cantidad.ToString() + " " + "Kl";
                            }
                            else
                            {
                                double cantidad = Convert.ToDouble(Rows["fCantidad"]) / Convert.ToDouble(unidad_calculos);
                                textBox_cantidad.Text = cantidad.ToString() + " " + abreviatura;
                            }
                        }
                    }
                }
                else
                {
                    Formularios.Form_Buscar_mov frm = new Form_Buscar_mov("Existencias Productos",almacen);
                    frm.ShowDialog();
                    string id = Classes.Class_Session.idbuscador.ToString();
                    if (ClsMov.existe_producto_almacen(id, almacen, "2"))
                    {
                        idproducto = id;
                    }
                    idproducto = id;

                    label_modelo.Text = "";
                    DataTable productos = new DataTable();
                    //productos = ClsMat.obtener_producto(idproducto);

                    if (productos.Rows.Count != 0)
                    {
                        DataRow prod = productos.Rows[0];
                        label_modelo.Text = prod["vchCodigo"].ToString() + " - " + prod["vchDescripcion"].ToString();
                        this.textBox_cantidad.Focus();

                        DataTable tipo = new DataTable();
                        //tipo = ClsMat.obtener_existencia_producto(idproducto, almacen);

                        try
                        {
                            DataRow Rows = tipo.Rows[0];
                            double cantidad = Convert.ToDouble(Rows["fCantidad"]);
                            if (cantidad > 0)
                            {
                                textBox_cantidad.Text = Rows["fCantidad"].ToString();
                            }
                            else
                            {
                                textBox_cantidad.Text = "0";
                            }
                        }
                        catch
                        {
                            textBox_cantidad.Text = "0";
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar a donde se descontaran los productos");
                return;
            }
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            if (idMovimiento != "")
            {
                if(ClsMov.movimiento_terminado(idMovimiento))
                {
                    MessageBox.Show("Este movimiento ya a sido terminado, es imposible editarlo.");
                    return;
                }
            }

            string origen = comboBox_origen.SelectedValue.ToString();
            string destino = comboBox_destino.SelectedValue.ToString();
            string idtipo = comboBox_tipo_producto.SelectedValue.ToString();
            string cantidad = "";

            if (botella == true)
            {
                cantidad = (Convert.ToDouble(textBox_requerido.Text) * Convert.ToDouble(fContenidoXPieza)).ToString();
            }
            else
            {
                cantidad = textBox_requerido.Text;
            }

            if (origen == destino)
            {
                MessageBox.Show("El almacen de origen y el de destino no pueden ser los mismos.");
                return;
            }

            if (textBox_cantidad.Text == "" || textBox_requerido.Text == "")
            {
                MessageBox.Show("Llenar todos los campos.");
                return;
            }

            if (comboBox_unidades.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Seleccionar el tipo de unidad");
                return;
            }

            if (textBox_requerido.Text == "0" || textBox_requerido.Text == "")
            {
                MessageBox.Show("El producto solicitado no cuenta con existencias disponibles.");
                return;
            }

            DataTable unidades_combo = new DataTable();
            //unidades_combo = ClsUni.obtener_unidades(comboBox_unidades.SelectedValue.ToString());

            DataRow UniRow = unidades_combo.Rows[0];

            double equivalencia = Convert.ToDouble(UniRow["iEquivalencia"]);
            double requerido = 0;

            string cantidad_existente = "";
            if (botella == false)
            {
                //if(
                string[] var = textBox_cantidad.Text.Split(' ');
                cantidad_existente = var[0];

                int varibles = var.Count();
                if (varibles > 1)
                {
                    if (var[1].ToString() == "Gr")
                    {
                        requerido = equivalencia * Convert.ToDouble(textBox_requerido.Text);
                    }
                    else
                    {
                        requerido = Convert.ToDouble(textBox_requerido.Text);
                    }
                }
                else
                {
                    requerido = Convert.ToDouble(textBox_requerido.Text);
                }
            }
            else
            {
                cantidad_existente = conversion_textBox_cantidad;
                requerido = equivalencia * (Convert.ToDouble(textBox_requerido.Text) * Convert.ToDouble(fContenidoXPieza));
            }

            if (unidad_calculos != "")
            {
                cantidad_existente = (Convert.ToDouble(unidad_calculos) * Convert.ToDouble(cantidad_existente)).ToString();
            }

            if (Convert.ToDouble(requerido) > Convert.ToDouble(cantidad_existente))
            {
                MessageBox.Show("Imposible cumplir la solicitud ya que la cantidad solcitada es mayor a la cantidad existente en almacen.");
                return;
            }

            DataTable tipo = new DataTable();
            /*if (idtipo == "1")
            {
                tipo = ClsMat.obtener_existencia_materia_prima(idproducto, origen);
            }
            else
            {
                tipo = ClsMat.obtener_existencia_producto(idproducto, origen);
            }*/

            DataRow Rows = tipo.Rows[0];
            
            string unidad = comboBox_unidades.SelectedValue.ToString();
            string idunidad = Rows["iidUnidadMetrica"].ToString();
            string existencias = Rows["fCantidad"].ToString();

            DataTable unidades = new DataTable();
            //unidades = ClsUni.obtener_unidades(Rows["iidUnidadMetrica"].ToString());

            DataRow row = unidades.Rows[0];

            //double cantidad_requerida = Convert.ToDouble(cantidad) * Convert.ToDouble(unidad);

            if (comboBox_destino.SelectedValue.ToString() == "0" || comboBox_unidades.SelectedValue.ToString() == "0" || comboBox_origen.SelectedValue.ToString() == "0" || comboBox_tipo_producto.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Seleccionar todas las opciones");
                return;
            }

            if (idproducto == "")
            {
                MessageBox.Show("Debe de seleccionar algun producto.");
                return;
            }

            DialogResult resultado;

            resultado = MessageBox.Show(@"Al agregar un movimiento no se podra revertir, esta seguro continuar?", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (DialogResult.OK == resultado)
            {
                if (idMovimiento == "")
                {
                    if (ClsMov.inserta_movimiento(origen, destino))
                    {
                        idMovimiento = ClsMov.ultimo_movimiento();
                        DataTable movimientos = new DataTable();
                        DataRow Movrow;

                        movimientos.Columns.Add("idmovimiento", System.Type.GetType("System.String"));
                        movimientos.Columns.Add("idtipo", System.Type.GetType("System.String"));
                        movimientos.Columns.Add("idproducto", System.Type.GetType("System.String"));
                        movimientos.Columns.Add("cantidad", System.Type.GetType("System.String"));
                        movimientos.Columns.Add("idunidad", System.Type.GetType("System.String"));

                        //Guardar Detalle Compra
                        Movrow = movimientos.NewRow();
                        Movrow["idmovimiento"] = idMovimiento;
                        Movrow["idtipo"] = idtipo;
                        Movrow["idproducto"] = idproducto;
                        Movrow["cantidad"] = cantidad;
                        Movrow["idunidad"] = idunidad;
                        movimientos.Rows.Add(Movrow);

                        ClsMov.inserta_detalle_movimiento(movimientos);
                        if (botella == false)
                        {
                            restar_existencias(idtipo, unidad);
                            agregar_existencias(idtipo, unidad);
                        }
                        else
                        {
                            restar_existencias(idtipo, unidad_real);
                            agregar_existencias(idtipo, unidad_real);
                        }
                        Lista_Movimientos();
                        Lista_Movimientos_Principal();
                        limpiar_controles();
                        MessageBox.Show("Movimiento guardo con exito.");
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Problemas al insertar el movimiento, intente mas tarde.");
                        return;
                    }
                }
                else
                {
                    DataTable movimientos = new DataTable();
                    DataRow Movrow;

                    movimientos.Columns.Add("idmovimiento", System.Type.GetType("System.String"));
                    movimientos.Columns.Add("idtipo", System.Type.GetType("System.String"));
                    movimientos.Columns.Add("idproducto", System.Type.GetType("System.String"));
                    movimientos.Columns.Add("cantidad", System.Type.GetType("System.String"));
                    movimientos.Columns.Add("idunidad", System.Type.GetType("System.String"));

                    //Guardar Detalle Compra
                    Movrow = movimientos.NewRow();
                    Movrow["idmovimiento"] = idMovimiento;
                    Movrow["idtipo"] = idtipo;
                    Movrow["idproducto"] = idproducto;
                    Movrow["cantidad"] = cantidad;
                    Movrow["idunidad"] = idunidad;
                    movimientos.Rows.Add(Movrow);

                    ClsMov.inserta_detalle_movimiento(movimientos);
                    if (botella == false)
                    {
                        restar_existencias(idtipo, unidad);
                        agregar_existencias(idtipo, unidad);
                    }
                    else
                    {
                        restar_existencias(idtipo, unidad_real);
                        agregar_existencias(idtipo, unidad_real);
                    }
                    Lista_Movimientos();
                    limpiar_controles();
                    MessageBox.Show("Movimiento guardo con exito.");
                    comboBox_unidades.Enabled = true;
                    return;
                }
            }
        }

        public void limpiar_controles()
        {
            comboBox_destino.Enabled = false;
            comboBox_origen.Enabled = false;
            comboBox_tipo_producto.SelectedValue = "0";
            comboBox_unidades.SelectedValue = "0";
            textBox_cantidad.Text = "";
            textBox_requerido.Text = "";
            idproducto = "";
            label_modelo.Text = "";
            fContenidoXPieza = "1";
            botella = false;
        }

        private void button_terminar_Click(object sender, EventArgs e)
        {
            DialogResult resultado;

            resultado = MessageBox.Show(@"Una ves terminado el movimiento no podra editarlo, Desea Continuar?.", "Confirmar!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (DialogResult.OK == resultado)
            {
                ClsMov.terminar_movimiento(idMovimiento);
                Lista_Movimientos_Principal();
                this.Close();
            }
        }

        public void restar_existencias(string tipo, string unidad) 
        {
            DataTable unidades = new DataTable();
            //unidades = ClsUni.obtener_unidades(unidad);

            DataRow UniRow = unidades.Rows[0];

            double equivalencia = Convert.ToDouble(UniRow["iEquivalencia"]);

            string almacen = comboBox_origen.SelectedValue.ToString();
            double requerido = 0;
            if (botella == false)
            {
                requerido = equivalencia * Convert.ToDouble(textBox_requerido.Text);
            }
            else
            {
                if (equivalencia == 29.574)
                {
                    requerido = (Convert.ToDouble(textBox_requerido.Text) * Convert.ToDouble(fContenidoXPieza));
                }
                else
                {
                    if (equivalencia != 1000)
                    {
                        requerido = equivalencia * (Convert.ToDouble(textBox_requerido.Text) * Convert.ToDouble(fContenidoXPieza));
                    }
                    else
                    {
                        requerido = equivalencia * Convert.ToDouble(textBox_requerido.Text);
                    }
                }
            }

            DataTable restar = new DataTable();
            /*if (tipo == "1")
            {
                restar = ClsMat.obtener_existencia_materia_prima(idproducto, almacen);
            }
            else
            {
                restar = ClsMat.obtener_existencia_producto(idproducto,almacen);
            }*/

            DataRow row = restar.Rows[0];
            double existencias = Convert.ToDouble(row["fCantidad"]);

            DataTable existentes = new DataTable();
            DataRow Extrow;

            existentes.Columns.Add("idalmacen", System.Type.GetType("System.String"));
            existentes.Columns.Add("idtipo", System.Type.GetType("System.String"));
            existentes.Columns.Add("idproducto", System.Type.GetType("System.String"));
            existentes.Columns.Add("cantidad", System.Type.GetType("System.String"));

            Extrow = existentes.NewRow();
            Extrow["idalmacen"] = comboBox_origen.SelectedValue.ToString();
            Extrow["idtipo"] = tipo;
            Extrow["idproducto"] = idproducto;
            Extrow["cantidad"] = (existencias - requerido).ToString();
            existentes.Rows.Add(Extrow);

            ClsMov.restar_movimiento(existentes);
        }

        public void agregar_existencias(string tipo, string unidad)
        {
            DataTable unidades = new DataTable();
            //unidades = ClsUni.obtener_unidades(unidad);

            DataRow UniRow = unidades.Rows[0];

            double equivalencia = Convert.ToDouble(UniRow["iEquivalencia"]);
            double requerido = 0;
            /*if (botella == false)
            {
                requerido = equivalencia * Convert.ToDouble(textBox_requerido.Text);
            }
            else
            {
                requerido = equivalencia * (Convert.ToDouble(textBox_requerido.Text) * Convert.ToDouble(fContenidoXPieza));
            }*/

            if (botella == false)
            {
                requerido = equivalencia * Convert.ToDouble(textBox_requerido.Text);
            }
            else
            {
                if (equivalencia == 29.574)
                {
                    requerido = (Convert.ToDouble(textBox_requerido.Text) * Convert.ToDouble(fContenidoXPieza));
                }
                else
                {
                    if (equivalencia != 1000)
                    {
                        requerido = equivalencia * (Convert.ToDouble(textBox_requerido.Text) * Convert.ToDouble(fContenidoXPieza));
                    }
                    else
                    {
                        requerido = equivalencia * Convert.ToDouble(textBox_requerido.Text);
                    }
                }
            }

            string almacen = comboBox_destino.SelectedValue.ToString();
            DataTable agregar = new DataTable();
            /*if (tipo == "1")
            {
                agregar = ClsMat.obtener_existencia_materia_prima(idproducto, almacen);
            }
            else
            {
                agregar = ClsMat.obtener_existencia_producto(idproducto, almacen);
            }*/

            double existencias = 0;
            string idunidad = "";

            if (agregar.Rows.Count != 0)
            {
                DataRow row = agregar.Rows[0];

                existencias = Convert.ToDouble(row["fCantidad"]);
                idunidad = row["iidUnidadMetrica"].ToString();

                /*if (existencias < 0)
                {
                    existencias = 0;
                }*/
            }
            else
            {
                idunidad = unidad;

                /*if (existencias < 0)
                {
                    existencias = 0;
                }*/
            }

            DataTable existentes = new DataTable();
            DataRow Extrow;

            existentes.Columns.Add("idalmacen", System.Type.GetType("System.String"));
            existentes.Columns.Add("idtipo", System.Type.GetType("System.String"));
            existentes.Columns.Add("idproducto", System.Type.GetType("System.String"));
            existentes.Columns.Add("cantidad", System.Type.GetType("System.String"));
            existentes.Columns.Add("idunidad", System.Type.GetType("System.String"));
            existentes.Columns.Add("fContenidoXPieza", System.Type.GetType("System.String"));

            Extrow = existentes.NewRow();
            Extrow["idalmacen"] = comboBox_destino.SelectedValue.ToString();
            Extrow["idtipo"] = tipo;
            Extrow["idproducto"] = idproducto;
            Extrow["cantidad"] = (existencias + requerido).ToString();
            Extrow["idunidad"] = idunidad;
            Extrow["fContenidoXPieza"] = fContenidoXPieza;
            existentes.Rows.Add(Extrow);

            ClsMov.sumar_movimiento(existentes);
        }

        private void comboBox_tipo_producto_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox_tipo_producto.SelectedValue.ToString() == "2")
            {
                comboBox_unidades.Enabled = false;
                comboBox_unidades.SelectedValue = "4";
            }
            else
            { 
                comboBox_unidades.Enabled=true;
                comboBox_unidades.SelectedValue = "0";
            }
        }
    }
}
