using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FLXDSK.Formularios
{
    public partial class Form_editarSaldoInicial : Form
    {

        string id = "";
        string observacion = "";
        float monto=0;
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public Form_editarSaldoInicial(string Id, string empleado)
        {
            
            InitializeComponent();

            id = Id;
            txtEmpleado.Text = empleado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                observacion = txtObservacion.Text;
                monto = float.Parse(txtMonto.Text);
            }
            catch (Exception)
            {
                 MessageBox.Show(@"Ha ocurrido un error, verifique los datos", "Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Error);
                 return;
                 
            }
     
            string sql="UPDATE catAperturass SET fMontoInicial = "+monto+" , vchObservacion='"+observacion+"' where iidApertura="+id; 
            if (!Conexion.InsertaSql(sql))
            {
                MessageBox.Show(@"Ha ocurrido un error", "Mensaje", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_editarSaldoInicial_Load(object sender, EventArgs e)
        {

        }
    }
}
