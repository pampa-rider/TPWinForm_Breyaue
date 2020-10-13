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
       private  Articulo articulo = null;


        public frmAlta()
        {
            InitializeComponent();
        }

        public frmAlta(Articulo art)
        {
            InitializeComponent();
            articulo = art;
        }


        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            
            if (articulo == null)
            articulo = new Articulo();
                        
            Categoria cat = new Categoria();
            Marca marca = new Marca();

            articulo.Nombre = txtNombre.Text;
            articulo.Descripcion = txtDesc.Text;
            articulo.categoria = (Categoria)cboCategoria.SelectedItem;
            articulo.marca = (Marca)cboMarca.SelectedItem;
            articulo.Precio = Convert.ToDecimal(txtPrecio.Text);
            articulo.ImageUrl = txtUrl.Text;

            if (articulo.codigo == 0)
                negocio.agregar(articulo);
            else
                negocio.modificar(articulo);
            MessageBox.Show("Operacion realizada exitosamente", "Exito");
            Close();
        }

        private void frmAlta_Load(object sender, EventArgs e)
        {
            TipoNegocio tipoNegocio = new TipoNegocio();
            categoriaNegocio catnegocio = new categoriaNegocio();
            Categoria Cat = new Categoria();
           
            cboMarca.DataSource = tipoNegocio.listar();
            cboMarca.ValueMember = "Id";
            cboMarca.DisplayMember = "Descripcion";
            cboMarca.SelectedIndex = -1;

            cboCategoria.DataSource = catnegocio.listar();
            cboCategoria.ValueMember = "Id";
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.SelectedIndex = -1;

            if (articulo != null)
            {
                txtNombre.Text = articulo.Nombre;
                txtDesc.Text = articulo.Descripcion;
                cboCategoria.SelectedIndex = articulo.categoria.Id;
                cboMarca.SelectedIndex = articulo.marca.Id;
                txtPrecio.Text = Convert.ToString(articulo.Precio);
                txtUrl.Text = articulo.ImageUrl;
                Text = "Modificar Articulo";
           }





        }
    }
}
