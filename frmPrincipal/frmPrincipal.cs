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
using Dominio;


namespace frmPrincipal
{
    public partial class frmPrincipal : Form
    {


            private List<Articulo> lista;
          

            private void cargar()
            {
                ArticuloNegocio producto = new ArticuloNegocio();
                dgvArticulos.DataSource = producto.listar();
                dgvArticulos.Columns[4].Visible = false;

            }

            private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
            {
                try
                {
                    Articulo art = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
                    pbProducto.Load(art.ImageUrl);

                }
                catch (Exception)
                {
                    pbProducto.Load("https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSBWCN9Acq8fXUM4G4e3c9l--1RWCkVX9folw&usqp=CAU");
                }
            }
        

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //frmAlta alta = new frmAlta();
            //alta.ShowDialog();
            //cargar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> Lista_Busqueda;
            try
            {
                if (txtBuscar.Text == "")
                    {
                    Lista_Busqueda = lista;
                }
                else
                {
                Lista_Busqueda = lista.FindAll(k => k.Nombre.ToLower().Contains(txtBuscar.Text.ToLower()) || k.Descripcion.ToLower().Contains(txtBuscar.Text.ToLower()));
                }

                dgvArticulos.DataSource = Lista_Busqueda;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            cargar();
        }
    }
   


    }

