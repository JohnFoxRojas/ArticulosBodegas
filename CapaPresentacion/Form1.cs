using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDato;
using CapaNeg;



namespace CapaPresentacion
{
    

    public partial class Form1 : Form
    {
        CProductos cpDT = new CProductos();
        CN_Producto objetoCN = new CN_Producto();
        categoriaCMB ctp = new categoriaCMB();
        nombresBodegas nBod = new nombresBodegas();
        Boolean editar = false;


        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            btnActGD.Visible = false;
            lsbBodegas.Visible = false;
            lblConsulta.Visible = false;
            lsbBodegas.Enabled = false;
            btnGuardar.Enabled = false;
            MostrarProductos();
            cmbBodega.DataSource = ctp.cargarCombo();
            cmbBodega.DisplayMember = "Nombre_Bodega";
            cmbBodega.ValueMember = "idCodigoBodega";
            cmbBodega.Text = "Seleccionar Bodega";
            
        }
        
        private void MostrarProductos()
        {
            CN_Producto objeto = new CN_Producto();
            dataGridView1.DataSource = objeto.MostrarProd();
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (editar == false)
            {
                try
                {   
                        
                     
                   objetoCN.InsertarArt(txtDescripcion.Text, dtFecha.Text, txtValor.Text, txtStock.Text, Convert.ToInt32(cmbBodega.SelectedValue));
                   MessageBox.Show("Guardado correctamente");
                   MostrarProductos();

                   limpiarForm();
                            
                        
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se guardo correctamente por:" + ex);
                }
            }
            if (editar == true)
            {
                try
                {
                    string codigo = dataGridView1.CurrentRow.Cells["idCodigo"].Value.ToString();
                    objetoCN.actualizarArt(txtDescripcion.Text, dtFecha.Text, txtValor.Text, txtStock.Text, Convert.ToInt32(cmbBodega.SelectedValue), codigo);
                    MessageBox.Show("Articulo Actualizo correctamente");
                    MostrarProductos();
                    editar = false;
                    limpiarForm();
                    btnActGD.Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se Actualizo correctamente por:" + ex);
                    btnActGD.Visible = false;
                }
            }

        }

        private void txtActualizar_Click(object sender, EventArgs e)
        {
            
            if (dataGridView1.SelectedRows.Count > 0)
            {
                
                editar = true;

                
                txtDescripcion.Text = dataGridView1.CurrentRow.Cells["Descripcion"].Value.ToString();
                dtFecha.Text = dataGridView1.CurrentRow.Cells["Fecha_Ingreso"].Value.ToString();
                txtValor.Text = dataGridView1.CurrentRow.Cells["Valor"].Value.ToString();
                txtStock.Text = dataGridView1.CurrentRow.Cells["StockMinimo"].Value.ToString();
                cmbBodega.SelectedValue = dataGridView1.CurrentRow.Cells["Codigo_Bodega"].Value.ToString();
                string codigo = dataGridView1.CurrentRow.Cells["idCodigo"].Value.ToString();

            }
            else
            {
                MessageBox.Show("Seleccione una fila Completa");
            }
            
        }
        private void limpiarForm()
        {
            
            txtDescripcion.Clear();
            txtValor.Clear();
            txtStock.Clear();
            cmbBodega.Text = "Seleccionar Bodega";
            textBox1.Clear();
            lblConsulta.Visible = false;
            lsbBodegas.Visible = false;

        }
        private void validarCombo()
        {

        }
        private void validarCampos()
        {
            var vr = 
                     !string.IsNullOrEmpty(txtDescripcion.Text) &&
                     !string.IsNullOrEmpty(dtFecha.Text) &&
                     !string.IsNullOrEmpty(txtValor.Text) &&
                     !string.IsNullOrEmpty(txtStock.Text) &&
                     cmbBodega.Text != ("Seleccionar Bodega");

            btnGuardar.Enabled = vr;
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                if (MessageBox.Show("¿Estás seguro que quieres eliminar esto?", "Confirmar eliminación", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {

                    string codigo = dataGridView1.CurrentRow.Cells["idCodigo"].Value.ToString();

                    objetoCN.eliminarArt(codigo);
                    limpiarForm();
                    MessageBox.Show("Eliminado Correctamente");

                    MostrarProductos();
                    btnActGD.Visible = false;
                }
                else
                {
                    MostrarProductos();
                }
                }
                else
                {
                    MessageBox.Show("Seleccione una fila");
             }
            
          
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void cmbBodega_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void dtFecha_ValueChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void txtStock_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            //(dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("idCliente = '{0}'",textBox1.Text);
        }
       

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try {
                
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("idCodigo = '{0}'", textBox1.Text);
                string codBod = dataGridView1.CurrentRow.Cells["Codigo_Bodega"].Value.ToString();
                lsbBodegas.DataSource = nBod.cargarNombreBodega();
                lsbBodegas.DisplayMember = "Nombre_Bodega";
                lsbBodegas.ValueMember = "idCodigoBodega";
                lsbBodegas.Text = (lsbBodegas.DataSource as DataTable).DefaultView.RowFilter = string.Format("idCodigoBodega = '{0}'", codBod);
                                                 
                lsbBodegas.Visible = true;
                lblConsulta.Visible = true;
                btnActGD.Visible = true;
            }
            catch (System.Data.EvaluateException)
            {
               
                MessageBox.Show("DEBE INGRESAR UN CODIGO");
                MostrarProductos();
            }
            catch (System.NullReferenceException)
            {

                MessageBox.Show("CODIGO INGRESADO NO EXISTE");
                MostrarProductos();
            }

        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar))&&(e.KeyChar!=(char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void btnActGD_Click(object sender, EventArgs e)
        {
            MostrarProductos();
            btnActGD.Visible = false;
            limpiarForm();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
