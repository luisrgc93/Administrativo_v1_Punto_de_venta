using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Data.SqlClient;

namespace FLXDSK.Formularios.SAT
{
    public partial class Form_BuscaCodigoProd : Form
    {
        bool siLoadCompleted = false;
        System.Timers.Timer Timer_Load = null;

        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();
        BindingSource bs = new BindingSource();


        Classes.SAT.Productos.Class_Division ClsDivision = new Classes.SAT.Productos.Class_Division();
        Classes.SAT.Productos.Class_Grupo ClsGrupo = new Classes.SAT.Productos.Class_Grupo();
        Classes.SAT.Productos.Class_Clase ClsClase = new Classes.SAT.Productos.Class_Clase();
        Classes.SAT.Productos.Class_ProductoServicio ClsProdSer = new Classes.SAT.Productos.Class_ProductoServicio();


        public Form_BuscaCodigoProd()
        {
            InitializeComponent();
        }

        private void CargaDivision()
        {
            DataTable dt = ClsDivision.getListaWhere(" WHERE iidEstatus = 1 ORDER BY vchNombre ASC ");
            
            DataRow drIni;
            drIni = dt.NewRow();
            drIni["vchCodigoDivision"] = "";
            drIni["vchTipo"] = "";
            drIni["vchClaveDivision"] = "";
            drIni["vchNombre"] = "Seleccionar";
            dt.Rows.InsertAt(drIni, 0);

            
            comboBox_Division.DataSource = dt;
            comboBox_Division.DisplayMember = "vchNombre";
            comboBox_Division.ValueMember = "vchCodigoDivision";
        }

        
        ///Grupo        
        void fnCargaGrupos(object source, ElapsedEventArgs e)
        {
            if (this.InvokeRequired)
                Invoke(new MethodInvoker(CargaGrupos));
        }
        private void CargaGrupos()
        {
            string codDivision = "";
            try
            {
                codDivision = comboBox_Division.SelectedValue.ToString();
            }
            catch { }
            if (codDivision == "" || siLoadCompleted == false)
            {
                DataTable dt = new DataTable("TablaTipos");
                dt.Columns.Add("vchCodigoGrupo");
                dt.Columns.Add("vchNombre");
                DataRow dr;
                dr = dt.NewRow();
                dr[0] = "";
                dr[1] = "Seleccionar";
                dt.Rows.Add(dr);

                comboBox_Grupo.DataSource = dt;
                comboBox_Grupo.DisplayMember = "vchNombre";
                comboBox_Grupo.ValueMember = "vchCodigoGrupo";
            }
            else
            {
                DataTable dt = ClsGrupo.getListaWhere(" WHERE iidEstatus = 1 AND vchCodigoDivision = '" + codDivision + "' ORDER BY vchNombre ASC ");

                DataRow drIni;
                drIni = dt.NewRow();
                drIni["vchCodigoGrupo"] = "";
                drIni["vchCodigoDivision"] = "";
                drIni["vchClaveGrupo"] = "";
                drIni["vchNombre"] = "Seleccionar";
                dt.Rows.InsertAt(drIni, 0);

                
                comboBox_Grupo.DataSource = dt;
                comboBox_Grupo.DisplayMember = "vchNombre";
                comboBox_Grupo.ValueMember = "vchCodigoGrupo";
            }
            pictureBox_Load.Visible = false;
        }

        ///Clase
        void fnCargaClase(object source, ElapsedEventArgs e)
        {
            if (this.InvokeRequired)
                Invoke(new MethodInvoker(CargaClase));
        }
        private void CargaClase()
        {
            string codDivision = "";
            string codGrupo = "";
            try
            {
                codDivision = comboBox_Division.SelectedValue.ToString();
                codGrupo = comboBox_Grupo.SelectedValue.ToString();
            }
            catch { }
            if (codDivision == "" || codGrupo == "" || siLoadCompleted == false)
            {
                DataTable dt = new DataTable("TablaTipos");
                dt.Columns.Add("vchCodigoClase");
                dt.Columns.Add("vchNombre");
                DataRow dr;
                dr = dt.NewRow();
                dr[0] = "";
                dr[1] = "Seleccionar";
                dt.Rows.Add(dr);

                comboBox_Clase.DataSource = dt;
                comboBox_Clase.DisplayMember = "vchNombre";
                comboBox_Clase.ValueMember = "vchCodigoClase";
            }
            else
            {
                DataTable dt = ClsClase.getListaWhere(" WHERE iidEstatus = 1 AND vchCodigoDivision = '" + codDivision + "' AND vchCodigoGrupo = '" + codGrupo + "' ORDER BY vchNombre ASC ");

                DataRow drIni;
                drIni = dt.NewRow();
                drIni["vchCodigoClase"] = "";
                drIni["vchCodigoDivision"] = "";
                drIni["vchCodigoGrupo"] = "";
                drIni["vchClaveClase"] = "";
                drIni["vchNombre"] = "Seleccionar";
                dt.Rows.InsertAt(drIni, 0);


                
                comboBox_Clase.DataSource = dt;
                comboBox_Clase.DisplayMember = "vchNombre";
                comboBox_Clase.ValueMember = "vchCodigoClase";
            }
            pictureBox_Load.Visible = false;
        }

        ///ProdServ
        void fnCargaProdServ(object source, ElapsedEventArgs e)
        {
            if (this.InvokeRequired)
                Invoke(new MethodInvoker(CargaProdServ));
        }
        private void CargaProdServ()
        {
            string Filtro = "";

            string CodDivision = "";
            string CodGrupo = "";
            string CodClase = "";
            try
            {
                CodDivision = comboBox_Division.SelectedValue.ToString();
                CodGrupo = comboBox_Grupo.SelectedValue.ToString();
                CodClase = comboBox_Clase.SelectedValue.ToString();
            }
            catch { }
            if (CodDivision == "" || CodGrupo == "" || CodClase == "")
            {
                dataGridView_Lista.DataSource = null;
                return;
            }

            Filtro += " AND vchCodigoDivision = '" + CodDivision + "' ";
            Filtro += " AND vchCodigoGrupo = '" + CodGrupo + "' ";
            Filtro += " AND vchCodigoClase = '" + CodClase + "' ";

            string sql = "SELECT vchCodigo CODIGO,  vchNombre NOMBRE " +
            " FROM int_satProductoServicio (NOLOCK) WHERE iidEstatus =  1 " + Filtro;

            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet ds = new DataSet();
            try
            {
                areas.Fill(ds, "Datos");
                dataGridView_Lista.DataSource = ds.Tables[0];
                bs.DataSource = dataGridView_Lista.DataSource;

                //Se define tamaño de columnas     
                dataGridView_Lista.Columns["CODIGO"].Visible = false;
                dataGridView_Lista.Columns["NOMBRE"].ReadOnly = true;
            }
            catch
            {

            }
            pictureBox_Load.Visible = false;
        }


        private void comboBox_Division_SelectedValueChanged(object sender, EventArgs e)
        {
            if (siLoadCompleted)
            {
                pictureBox_Load.Visible = true;
                Timer_Load = new System.Timers.Timer();
                Timer_Load.Interval = 100;
                Timer_Load.Elapsed += fnCargaGrupos;
                Timer_Load.AutoReset = false;
                Timer_Load.Enabled = true;
            }
        }

        private void comboBox_Grupo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (siLoadCompleted)
            {
                pictureBox_Load.Visible = true;
                Timer_Load = new System.Timers.Timer();
                Timer_Load.Interval = 100;
                Timer_Load.Elapsed += fnCargaClase;
                Timer_Load.AutoReset = false;
                Timer_Load.Enabled = true;
            }
        }

        private void comboBox_Clase_SelectedValueChanged(object sender, EventArgs e)
        {
            if (siLoadCompleted)
            {
                pictureBox_Load.Visible = true;
                Timer_Load = new System.Timers.Timer();
                Timer_Load.Interval = 100;
                Timer_Load.Elapsed += fnCargaProdServ;
                Timer_Load.AutoReset = false;
                Timer_Load.Enabled = true;
            }
        }

        private void Form_BuscaCodigoProd_Load(object sender, EventArgs e)
        {
            CargaDivision();
            siLoadCompleted = true;
        }

        private void textBox_Filtro_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = string.Format(" NOMBRE LIKE '%{0}%'", textBox_Filtro.Text);
            dataGridView_Lista.DataSource = bs;
        }

        private void dataGridView_Lista_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewSelectedCellCollection col = this.dataGridView_Lista.SelectedCells;
                if (col[0].Value.ToString() != "")
                {
                    Classes.Class_Session.Idtmp = col[0].Value.ToString();
                    this.Close();
                }
            }
            catch { }
        }

        private void textBox_Filtro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (textBox_Filtro.Text.Trim() != "")
                {
                    string sql = "SELECT vchCodigo CODIGO,  vchNombre NOMBRE " +
                    " FROM int_satProductoServicio (NOLOCK) WHERE iidEstatus =  1  AND vchCodigo +' '+vchNombre LIKE '%" + textBox_Filtro.Text.Trim() + "%'";

                    SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
                    DataSet ds = new DataSet();
                    try
                    {
                        areas.Fill(ds, "Datos");
                        dataGridView_Lista.DataSource = ds.Tables[0];
                        bs.DataSource = dataGridView_Lista.DataSource;

                        //Se define tamaño de columnas     
                        dataGridView_Lista.Columns["CODIGO"].Visible = false;
                        dataGridView_Lista.Columns["NOMBRE"].ReadOnly = true;
                    }
                    catch
                    {

                    }
                }
            }
        }

        
    }
}
