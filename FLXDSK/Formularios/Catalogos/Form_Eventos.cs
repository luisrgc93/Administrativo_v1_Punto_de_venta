using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aejw.Network;
using System.Configuration;
using System.IO;
using System.Data.SqlClient;

namespace FLXDSK.Formularios.Catalogos
{
    public partial class Form_Eventos : Form
    {
        string idEvento = "";
        string imagenName = "";
        string rutaOriginal = "";

        DataTable Info;
        DataTable dt = new DataTable();
        BindingSource bs = new BindingSource();

        Classes.Catalogos.Class_Eventos fnEventos = new Classes.Catalogos.Class_Eventos();
        Conexion.Class_Conexion Conexion = new Conexion.Class_Conexion();

        public event Form1.MessageHandler Lista_Eventos;
        public Form_Eventos(string temp)
        {
            InitializeComponent();
            idEvento = temp;
        }

        public static void EnableTab(TabPage page, bool enable)
        {
            foreach (Control ctl in page.Controls) ctl.Enabled = enable;
        }

        private void Form_Eventos_Load(object sender, EventArgs e)
        {
            dateTimePicker_inicio.Format = DateTimePickerFormat.Custom;
            dateTimePicker_inicio.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker_fin.Format = DateTimePickerFormat.Custom;
            dateTimePicker_fin.CustomFormat = "dd/MM/yyyy HH:mm";

            dateTimePicker_IniciaCover.Format = DateTimePickerFormat.Custom;
            dateTimePicker_IniciaCover.CustomFormat = "dd/MM/yyyy HH:mm";
            dateTimePicker_TerminaCover.Format = DateTimePickerFormat.Custom;
            dateTimePicker_TerminaCover.CustomFormat = "dd/MM/yyyy HH:mm";

            EnableTab(tabPage2, false);
            llenarCombos();

            if (idEvento != "")
            {
                getInfoEvento();
                getCoverEvento();
                EnableTab(tabPage2, true);
            }
        }

        public void llenarCombos()
        {
            DataTable sexo = new DataTable("TablaSexo");
            sexo.Columns.Add("sexo");
            sexo.Columns.Add("idsexo");
            DataRow drsexo;
            drsexo = sexo.NewRow();
            drsexo[1] = "T";
            drsexo[0] = "Ambos";
            sexo.Rows.Add(drsexo);
            drsexo = sexo.NewRow();
            drsexo[1] = "H";
            drsexo[0] = "Hombre";
            sexo.Rows.Add(drsexo);
            drsexo = sexo.NewRow();
            drsexo[1] = "M";
            drsexo[0] = "Mujer";
            sexo.Rows.Add(drsexo);

            comboBox_Sexo.DataSource = sexo;
            comboBox_Sexo.DisplayMember = "sexo";
            comboBox_Sexo.ValueMember = "idsexo";
        }

        private void button_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox_producto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pictureBox_producto.Image = Image.FromFile(dialog.FileName);
                rutaOriginal = dialog.FileName;
                imagenName = Path.GetFileName(dialog.FileName);
            }
        }

        private void button_Guardar_Click(object sender, EventArgs e)
        {
            string evento = textBox_Nombre.Text;
            string descripcion = textBox_Descripcion.Text;

            if (evento == "" || descripcion == "")
            {
                MessageBox.Show("Favor de llenar los campos requeridos (*)");
                return;
            }

            
            if (idEvento == "")
            {
                string[] varI = dateTimePicker_inicio.Text.Split('/', ' ', ':');
                string inicio = varI[2] + "-" + varI[1] + "-" + varI[0] + "T" + varI[3] + ":" + varI[4] + ":00";

                string[] varF = dateTimePicker_fin.Text.Split('/', ' ', ':');
                string final = varF[2] + "-" + varF[1] + "-" + varF[0] + "T" + varF[3] + ":" + varF[4] + ":00";

                DateTime ini = Convert.ToDateTime(inicio);
                DateTime fin = Convert.ToDateTime(final);
                DateTime fechaActual = DateTime.Now;

                if (ini > fin) { MessageBox.Show("La fecha final no pude ser menor a la inicial."); return; }
                if (fnEventos.ahiEventoEnEstaFecha(inicio, final)) { MessageBox.Show("Ya existe evento en estas fechas"); return; }

                Info = new DataTable();
                DataRow row;

                Info.Columns.Add("idEvento", System.Type.GetType("System.String"));
                Info.Columns.Add("evento", System.Type.GetType("System.String"));
                Info.Columns.Add("descripcion", System.Type.GetType("System.String"));
                Info.Columns.Add("Inicia", System.Type.GetType("System.String"));
                Info.Columns.Add("Termina", System.Type.GetType("System.String"));
                Info.Columns.Add("imagen", System.Type.GetType("System.Byte[]"));

                row = Info.NewRow();
                row["idEvento"] = idEvento;
                row["evento"] = evento;
                row["descripcion"] = descripcion;
                row["Inicia"] = inicio;
                row["Termina"] = final;
                row["imagen"] = GetImagen();

                Info.Rows.Add(row);

                if (fnEventos.inserta_Evento(Info))
                {
                    MessageBox.Show("Guardado con exito");
                    idEvento = fnEventos.getIdProducto();
                    //getInfoEvento();
                    EnableTab(tabPage2, true); this.tabControl1.SelectedTab = tabPage2; //Desbloqueamos el tab 2 y posicionamos el focus ahi
                    try
                    {
                        Lista_Eventos();
                    }
                    catch { }
                }
                else
                {
                    MessageBox.Show("Problemas al guardar");
                    return;
                }
            }
            else
            {
                string[] varI = dateTimePicker_inicio.Text.Split('/', ' ', ':');
                string inicio = varI[2] + "-" + varI[1] + "-" + varI[0] + "T" + varI[3] + ":" + varI[4] + ":00";

                string[] varF = dateTimePicker_fin.Text.Split('/', ' ', ':');
                string final = varF[2] + "-" + varF[1] + "-" + varF[0] + "T" + varF[3] + ":" + varF[4] + ":00";

                DateTime ini = Convert.ToDateTime(inicio);
                DateTime fin = Convert.ToDateTime(final);
                DateTime fechaActual = DateTime.Now;

                if (ini > fin) { MessageBox.Show("La fecha final no pude ser menor a la inicial."); return; }
                //if (fnEventos.ahiEventoEnEstaFecha(inicio, final)) { MessageBox.Show("Ya existe evento en estas fechas"); return; }

                Info = new DataTable();
                DataRow row;

                Info.Columns.Add("idEvento", System.Type.GetType("System.String"));
                Info.Columns.Add("evento", System.Type.GetType("System.String"));
                Info.Columns.Add("descripcion", System.Type.GetType("System.String"));
                Info.Columns.Add("Inicia", System.Type.GetType("System.String"));
                Info.Columns.Add("Termina", System.Type.GetType("System.String"));
                Info.Columns.Add("imagen", System.Type.GetType("System.Byte[]"));

                row = Info.NewRow();
                row["idEvento"] = idEvento;
                row["evento"] = evento;
                row["descripcion"] = descripcion;
                row["Inicia"] = inicio;
                row["Termina"] = final;
                row["imagen"] = GetImagen();
                Info.Rows.Add(row);

                if (fnEventos.actualiza_Evento(Info))
                {
                    MessageBox.Show("Evento actualizado con exito");
                    idEvento = fnEventos.getIdProducto();
                    //getInfoEvento();
                    EnableTab(tabPage2, true); this.tabControl1.SelectedTab = tabPage2; //Desbloqueamos el tab 2 y posicionamos el focus ahi
                    
                    try
                    {
                        Lista_Eventos();
                    }
                    catch { }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Problemas al actualizar el Evento");
                    return;
                }
            }
        }
        private byte[] GetImagen()
        {
            try
            {
                Image dibujo = new Bitmap(pictureBox_producto.Image);
                ImageConverter converter = new ImageConverter();
                return (byte[])converter.ConvertTo(dibujo, typeof(byte[]));
            }
            catch
            { 
                return null;
            }
        }
        private void CreateFolder(string ruta)
        {
            bool isExists = System.IO.Directory.Exists(ruta);
            if (!isExists)
                System.IO.Directory.CreateDirectory(ruta);
        }

        public void getInfoEvento()
        {
            DataTable dtEvento = fnEventos.obtener_Evento(idEvento);
            if (dtEvento.Rows.Count == 0)
            {
                MessageBox.Show("Informacion incorrecta");
                this.Close();
                return;
            }

            DataRow row = dtEvento.Rows[0];
            string evento = row["evento"].ToString();
            string descripcion = row["descripcion"].ToString();
            string dfechaActivo = row["Inicia"].ToString();
            string dfechaVence = row["Termina"].ToString();

            textBox_Nombre.Text = evento;
            textBox_Descripcion.Text = descripcion;
            
            if (dfechaActivo != "" && dfechaVence != "")
            {
                DateTime ini = Convert.ToDateTime(dfechaActivo);
                DateTime fin = Convert.ToDateTime(dfechaVence);
                dateTimePicker_fin.Value = fin;
                dateTimePicker_inicio.Value = ini;
            }

            try
            {
                byte[] dibujoByteArray = (byte[])row["IFilePromo"];
                if (dibujoByteArray != null)
                {
                    MemoryStream ms = new MemoryStream();
                    ms.Write(dibujoByteArray, 0, dibujoByteArray.Length);
                    System.Drawing.Bitmap b = new Bitmap(ms);
                    pictureBox_producto.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox_producto.Image = new System.Drawing.Bitmap(b);
                }
            }
            catch
            {
            }
        }

        public void getCoverEvento()
        {
            dataGridView2.DataSource = null;
            string sql = " select iidPrecioEvento ID, E.vchNombre Evento, fCover Cover, "+
                         " case vchSexo when 'H' then 'Hombre' when 'M' then 'Mujer' when 'T' then 'Ambos' end as  Sexo, "+
                         " CONVERT(VARCHAR(10),dfechaInicia,103)+' '+CONVERT(VARCHAR(5),dfechaInicia,108) Inicia, CONVERT(VARCHAR(10),dfechaTermina,103)+' '+CONVERT(VARCHAR(5),dfechaTermina,108) Termina " +
                         " from catPrecioEvento P, catEventos E " +
                         " where P.iidEvento = " + idEvento + " and P.iidEvento = E.iidEvento ";

            SqlDataAdapter areas = new SqlDataAdapter(sql, Conexion.ConexionSQL());
            DataSet dstConsulta = new DataSet();
            try
            {
                areas.Fill(dstConsulta, "Datos");
                dataGridView2.DataSource = dstConsulta.Tables[0];

                dataGridView2.Columns["ID"].Width = 70;
                dataGridView2.Columns["ID"].Visible = false;
                dataGridView2.Columns["Evento"].Width = 150;
                dataGridView2.Columns["Evento"].ReadOnly = true;
                dataGridView2.Columns["Cover"].Width = 120;
                dataGridView2.Columns["Cover"].ReadOnly = true;
                dataGridView2.Columns["Sexo"].Width = 150;
                dataGridView2.Columns["Sexo"].ReadOnly = true;
                dataGridView2.Columns["Inicia"].Width = 150;
                dataGridView2.Columns["Inicia"].ReadOnly = true;
                dataGridView2.Columns["Termina"].Width = 150;
                dataGridView2.Columns["Termina"].ReadOnly = true;
            }
            catch
            {
            }
            bs.DataSource = dataGridView2.DataSource;
        }

        private void button_AgregarCover_Click(object sender, EventArgs e)
        {
            if (textBox_Precio.Text == "") { MessageBox.Show("Favor de llenar los datos necesarios"); return; }

            string[] varI = dateTimePicker_IniciaCover.Text.Split('/', ' ', ':');
            string inicioCover = varI[2] + "-" + varI[1] + "-" + varI[0] + "T" + varI[3] + ":" + varI[4] + ":00";

            string[] varF = dateTimePicker_TerminaCover.Text.Split('/', ' ', ':');
            string finalCover = varF[2] + "-" + varF[1] + "-" + varF[0] + "T" + varF[3] + ":" + varF[4] + ":00";

            DateTime iniCover = Convert.ToDateTime(inicioCover);
            DateTime finCover = Convert.ToDateTime(finalCover);

            if (iniCover > finCover) { MessageBox.Show("La fecha final no pude ser menor a la inicial."); return; }
            //if (fnEventos.ahiCoverEnEstaFecha(idEvento)) { MessageBox.Show("Ya existe Cover en estas fechas"); return; }
            if (!fnEventos.elCoverEsDentrodelasFechasdelEvento(inicioCover, finalCover, idEvento)) { MessageBox.Show("No se puede crear el cover debido a que no es dentro de las fechas del evento"); return; }

            DataTable Info = new DataTable();
            DataRow Drw;

            Info.Columns.Add("idEvento", System.Type.GetType("System.String"));
            Info.Columns.Add("cover", System.Type.GetType("System.String"));
            Info.Columns.Add("sexo", System.Type.GetType("System.String"));
            Info.Columns.Add("Inicia", System.Type.GetType("System.String"));
            Info.Columns.Add("Termina", System.Type.GetType("System.String"));        

            Drw = Info.NewRow();
            Drw["idEvento"] = idEvento;
            Drw["cover"] = textBox_Precio.Text;
            Drw["sexo"] = comboBox_Sexo.SelectedValue.ToString();
            Drw["Inicia"] = inicioCover;
            Drw["Termina"] = finalCover; 
            Info.Rows.Add(Drw);

            if (fnEventos.GuardarRelEventoCover(Info))
            {
                try
                {
                    Classes.Class_Session.MateriaPrima = "";
                    textBox_Precio.Text = "";
                    comboBox_Sexo.SelectedValue = "T";
                    getCoverEvento();
                }
                catch 
                { }
            }
            else
            {
                MessageBox.Show("Problema al Guardar");
            }
        }

        private void textBox_Precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }


            bool punto_decimales = false;
            int cantidad_decimales = 0;

            for (int i = 0; i < textBox_Precio.Text.Length; i++)
            {
                if (textBox_Precio.Text[i] == '.')
                    punto_decimales = false;

                if (punto_decimales && cantidad_decimales++ >= 2)
                {
                    e.Handled = false;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (punto_decimales) ? false : false;
            else
                e.Handled = true;
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                string ID = row.Cells["ID"].Value.ToString();
                if (ID != "")
                {
                    DialogResult dr = MessageBox.Show("Esta usted seguro de eliminar el registro #"+ID, "Confimar Eliminar", MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Information);

                    if (dr == DialogResult.Yes)
                    {
                        if (fnEventos.EliminaidCobroEvento(ID))
                            getCoverEvento();
                        else
                            MessageBox.Show("Problema al elimar el registro");
                    }
                }
            }
        }        
    }
}
