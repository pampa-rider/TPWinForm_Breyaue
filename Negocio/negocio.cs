using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using System.Data.SqlClient;

namespace Negocio
{
    public class ArticuloNegocio
    {
    public List<Articulo> listar()
    {
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            List<Articulo> lista = new List<Articulo>();

            conexion.ConnectionString = "data source=DESKTOP-PEA82KB\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = "select P.id,P.nombre,P.descripcion,M.Descripcion,T.Descripcion,P.ImagenUrl,P.Precio from ARTICULOS P, MARCAS M, CATEGORIAS T Where P.IdCategoria=T.Id and P.IdMarca=M.Id";
       
            comando.Connection = conexion;

            conexion.Open();
            lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Articulo aux = new Articulo();
                aux.codigo = (int)lector["id"]; ;

                aux.Nombre = lector.GetString(1);
                aux.Descripcion = lector.GetString(2);

                aux.marca = new Marca();
                aux.marca.Descripcion = lector.GetString(3);

                aux.categoria = new Categoria();
                aux.categoria.Descripcion = lector.GetString(4);


                aux.Precio = (decimal)lector["Precio"];
               
                
                aux.ImageUrl = (string)lector["ImagenUrl"];


                lista.Add(aux);
            }
            conexion.Close();
            return lista;
        }
      
    public void agregar(Articulo nuevo)
    {
	    try
	    {

	    }
        catch(Exception)
        {
        throw;
        }

        SqlConnection conexion = new SqlConnection();
        SqlCommand comando = new SqlCommand();
        conexion.ConnectionString ="data source=DESKTOP-PEA82KB\\SQLEXPRESS; initial catalog=CATALOGO_DB; integrated security=sspi";
        comando.CommandType = System.Data.CommandType.Text;
        
        comando.CommandText= "insert into ARTICULOS (Nombre,Descripcion,IdMarca,IdCategoria,ImagenUrl,Precio) values('"+nuevo.Nombre+"','"+nuevo.Descripcion+"','"+nuevo.marca.Id+"','"+nuevo.categoria.Id+"','"+nuevo.ImageUrl+"','"+nuevo.Precio+"')";
        comando.Connection = conexion;
        conexion.Open();
        comando.ExecuteNonQuery();

            



        }
         
    }
}
