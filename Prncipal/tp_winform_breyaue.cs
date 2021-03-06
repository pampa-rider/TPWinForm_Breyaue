﻿using System;
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

namespace Prncipal
{
    public partial class tp_winform_breyaue : Form
    {

        private List<Articulo> lista;

        public tp_winform_breyaue()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
        }


        private void cargar()
        {
            ArticuloNegocio producto = new ArticuloNegocio();
            lista = producto.listar();
            dgvArticulos.DataSource = lista;
            dgvArticulos.Columns[4].Visible = false;
            dgvArticulos.Columns[0].Visible = false;
            dgvArticulos.Columns[1].Visible = false;
            dgvArticulos.Columns[3].Visible = false;
            dgvArticulos.Columns[6].Visible = false;

        }

        private void cmdAlta_Click(object sender, EventArgs e)
        {

            frmAlta alta = new frmAlta();
            alta.ShowDialog();
            cargar();

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



        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Articulo art;
            art = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;

            frmAlta mod = new frmAlta(art);
            mod.ShowDialog();
            cargar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();



            const string message = "Esta Seguro que quiere eliminar el registro?";
            const string caption = "Eliminar Registro";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                negocio.eliminar(((Articulo)dgvArticulos.CurrentRow.DataBoundItem).id);
                cargar();

            }




        }

        private void txtBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (txtBusqueda.Text == "")
            {
                dgvArticulos.DataSource = lista;
            }
            else
            {

                List<Articulo> Lista_Busqueda = lista.FindAll
                (
                k => k.Nombre.ToLower().Contains(txtBusqueda.Text.ToLower())
                || k.Descripcion.ToLower().Contains(txtBusqueda.Text.ToLower())
                || k.codigo.ToLower().Contains(txtBusqueda.Text.ToLower())
                || k.categoria.Descripcion.ToLower().Contains(txtBusqueda.Text.ToLower())
                || k.marca.Descripcion.ToLower().Contains(txtBusqueda.Text.ToLower())
                );

                dgvArticulos.DataSource = Lista_Busqueda;

            }


        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
