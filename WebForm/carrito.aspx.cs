using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForm
{
    public partial class carrito : System.Web.UI.Page
    {

        public Articulo buscado;
        public List<Articulo> lista_carrito;
        int id_aux;
        int extra;
        Carro Carrin;


        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}