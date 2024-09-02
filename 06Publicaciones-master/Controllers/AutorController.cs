using System;
using System.Collections.Generic;
using System.Windows.Forms;
using _06Publicaciones.config;

namespace _06Publicaciones.Controllers
{
    public class AutorController
    {
        // Método para insertar un autor
        public Autor InsertarAutor(Autor autor)
        {
             return Autor.Insertar(autor);
        }

        // Método para actualizar un autor
        public string ActualizarAutor(Autor autor)
        {
               return Autor.Actualizar(autor);               
        }

        // Método para eliminar un autor
        public string EliminarAutor(string idAutor)
        {
                return Autor.Eliminar(idAutor);
        }

        // Método para obtener un autor por ID
        public Autor ObtenerAutorPorId(string idAutor)
        {
                return Autor.ObtenerPorId(idAutor);
        }

        // Método para obtener todos los autores (esto requiere que se agregue un método en la clase Autor)
        public List<Autor> ObtenerTodosLosAutores()
        {
                return Autor.ObtenerTodos();
        }
    }
}
