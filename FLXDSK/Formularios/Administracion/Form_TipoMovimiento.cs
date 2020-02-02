using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios.Administracion
{
    public partial class Form_TipoMovimiento : Form
    {
        public event Form1.MessageHandler CargarLista;

        Classes.Configuracion.Class_TipoMovimiento ClsTipoMovimiento = new Classes.Configuracion.Class_TipoMovimiento();

        string PassText = "";

        public Form_TipoMovimiento(string id)
        {
            PassText = id;
            InitializeComponent();
        }
        private void CargaTipos()
        {
            DataTable dtTipo = new DataTable();
            DataRow row;

            dtTipo.Columns.Add("tipo", System.Type.GetType("System.String"));
            dtTipo.Columns.Add("valor", System.Type.GetType("System.String"));
            dtTipo.Columns.Add("descripcion", System.Type.GetType("System.String"));

            row = dtTipo.NewRow();
            row["tipo"] = "ENTRADA";
            row["valor"] = "1";
            dtTipo.Rows.Add(row);

            row = dtTipo.NewRow();
            row["tipo"] = "SALIDA";
            row["valor"] = "0";
            dtTipo.Rows.Add(row);

            comboBox_Tipo.DataSource = dtTipo;
            comboBox_Tipo.DisplayMember = "tipo";
            comboBox_Tipo.ValueMember = "valor";
        }
        private void Form_TipoMovimiento_Load(object sender, EventArgs e)
        {
            CargaTipos();

            if (PassText != "")
            {
                CargaInfoId();
            }

        }
        private void CargaInfoId()
        {
            DataTable dtInfo = ClsTipoMovimiento.getListaWhere(" WHERE iidTipoMovimiento = " + PassText);
            if (dtInfo.Rows.Count == 0) 
            {
                MessageBox.Show("Informacion incorrecta");
                this.Close();
                return;
            }
            textBox_vchNombre.Text = dtInfo.Rows[0]["vchNombre"].ToString();
            try
            {
                comboBox_Tipo.SelectedValue = dtInfo.Rows[0]["siEntrada"].ToString();
            }
            catch { }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            if (textBox_vchNombre.Text.Trim() == "")
            {
                MessageBox.Show("Nombre Requerido");
                return;
            }
            string IdTipo = "";
            try {
                IdTipo = comboBox_Tipo.SelectedValue.ToString();
            }
            catch { }
            if (IdTipo == "")
            {
                MessageBox.Show("Tipo de Movimiento Requerido");
                return;
            }

            if (PassText == "")
            {
                DataTable dtExis = ClsTipoMovimiento.getListaWhere(" WHERE vchNombre ='" + textBox_vchNombre.Text.Trim() + "' AND iidEstatus = 1 ");
                if (dtExis.Rows.Count > 0)
                {
                    MessageBox.Show("Nombre Ingresado ya existe, elige otro");
                    return;
                }

                if (ClsTipoMovimiento.InsertaRegistro(textBox_vchNombre.Text.Trim(), IdTipo))
                {
                    MessageBox.Show("Guardado correctamente");
                    this.Close();
                    try {
                        CargarLista();
                    }catch{}
                    return;
                }
                else
                {
                    MessageBox.Show("Problema al almacenar, contacte al administrador");
                    return;
                }
            }
            else
            {
                DataTable dtExis = ClsTipoMovimiento.getListaWhere(" WHERE vchNombre ='" + textBox_vchNombre.Text.Trim() + "' AND iidEstatus = 1 AND  iidTipoMovimiento <> " + PassText);
                if (dtExis.Rows.Count > 0)
                {
                    MessageBox.Show("Nombre Ingresado ya existe, elige otro");
                    return;
                }

                if (ClsTipoMovimiento.ActualizaRegistro(textBox_vchNombre.Text.Trim(), IdTipo, PassText))
                {
                    MessageBox.Show("Guardado correctamente");
                    this.Close();
                    try
                    {
                        CargarLista();
                    }
                    catch { }
                    return;
                }
                else
                {
                    MessageBox.Show("Problema al almacenar, contacte al administrador");
                    return;
                }
            }
        }

    }
}
