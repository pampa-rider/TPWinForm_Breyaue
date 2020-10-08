using Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;


namespace Prncipal
{
    public partial class frmAlta : Form
    {
        public frmAlta()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAlta_Load(object sender, EventArgs e)
        {
            TipoNegocio tipoNegocio = new TipoNegocio();
            categoria categoria = new categoria();
            cboMarca.DataSource = tipoNegocio.listar();
            cboCategoria.DataSource = categoria.listar();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Articulo nuevo = new Articulo();
            ArticuloNegocio negocio = new ArticuloNegocio();
            categoria cat = new categoria();
            Marca marca = new Marca();

            nuevo.Nombre = txtNombre.Text;
            nuevo.Descripcion = txtDesc.Text;
            nuevo.categoria = (Categoria)cboCategoria.SelectedItem;
            nuevo.marca = (Marca)cboMarca.SelectedItem;
            nuevo.Precio = Convert.ToDecimal(txtPrecio.Text);
            nuevo.ImageUrl = txtUrl.Text;
            negocio.agregar(nuevo);

            Close();


        }
    }
}
