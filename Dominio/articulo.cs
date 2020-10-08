using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Dominio
{
    public class Articulo
    {
        public int codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public string ImageUrl{ get; set; }

        public Marca marca { get; set; }

        public Categoria categoria { get; set; }
       
    }


}
