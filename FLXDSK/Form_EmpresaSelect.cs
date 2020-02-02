using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FLXDSK.Formularios.Administracion;

namespace FLXDSK
{
    public partial class Form_EmpresaSelect : Form
    {
      public event Form1.MessageHandler cerrarTabsDis;
      public event Form1.MessageHandler cargarAccesosUsuaruios;
      public event Form1.MessageHandler inhabilitarMenu;


      Classes.Class_Empresa ClsEmp = new Classes.Class_Empresa();
      Classes.Catalogos.Administracion.Class_Accesos ClsAcc = new Classes.Catalogos.Administracion.Class_Accesos();

        int idUsuarioLogueado =0;

        public Form_EmpresaSelect(int idUsu)
        {
            idUsuarioLogueado = idUsu;
            InitializeComponent();
        }

        

        private void button_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_Ingresar_Click(object sender, EventArgs e)
        {
            string empresa;
            try { 
               empresa = comboBox_Empresa.SelectedValue.ToString();
            }catch
            {
                MessageBox.Show("Seleccione una Empresa");
                return;
            }
          
            if (empresa == "0")
            {
                MessageBox.Show("Seleccione una Empresa");
            }
            else {
                try
                {

                    Classes.Class_Session.IDEMPRESA = Convert.ToInt32(empresa);
                    
                    DataTable dtEmpresa = ClsEmp.GetInfoById(Classes.Class_Session.IDEMPRESA.ToString());
                    if (dtEmpresa.Rows.Count == 0)
                    {
                        MessageBox.Show("Empresa no encontrada");
                    
                       // this.Refresh();
                        
                    }


                    Classes.Class_Session.SessAlias = dtEmpresa.Rows[0]["vchAlias"].ToString();
                    Classes.Class_Session.RFC_Empresa = dtEmpresa.Rows[0]["vchRFC"].ToString();
                    Classes.Class_Session.vchKeyTimbrado = dtEmpresa.Rows[0]["vchKeyTimbrado"].ToString();
                    
                    try
                    {                     
                      cerrarTabsDis();
                        // Cargar Accesos Usuarios
                      inhabilitarMenu();
                      cargarAccesosUsuaruios();
                    }
                    catch
                    {
                        ////ClsLog.InsertaInformacion("Selecion empresa: no se pudo serrar tab ó inavilitar menu o cargar accesos", exp.ToString());
                    }
                // cargarAccesosUsuaruios();
                 this.Close();
                 

                }catch
                {
                    MessageBox.Show("Seleccione una Empresa Correcta");
                }
            }
        }
        private void LlenadoEmpresas()
        {
            var dt = ClsAcc.getAccesosEmpresa(idUsuarioLogueado);
            if(dt.Rows.Count > 0)
            {
                comboBox_Empresa.DataSource = dt;
                comboBox_Empresa.DisplayMember = "Alias";
                comboBox_Empresa.ValueMember = "id";
            }
            else
            {
                if (Classes.Class_Session.siPrimeroIngreso != "SI") return;
                MessageBox.Show("Ahora registra tu empresa, para poder continuar");
                var frm = new Form_Empresas("", true);
                frm.ShowDialog();
                if (!Classes.Class_Session.SiRegistroEmpresa) return;
                LlenadoEmpresas();
                Classes.Class_Session.SiRegistroEmpresa = false;
                Classes.Class_Session.siPrimeroIngreso = "NO";
            }
        }

        private void Form_EmpresaSelect_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            LlenadoEmpresas();
            button_Ingresar.Focus();
        }
    }
}
