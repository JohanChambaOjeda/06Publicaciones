using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06Publicaciones.Models;
using System.Data;
namespace _06Publicaciones.Controllers
{
    public class CiudadesController
    {
        CiudadesModel _ciudadesModel = new CiudadesModel();

        public DataTable todosconrelacion()
        {
            return _ciudadesModel.todosconrelacion();
        }

        public DataTable ObtenerCiudadPorId(int idCiudad)
        {
            return _ciudadesModel.ObtenerCiudadPorId(idCiudad);
        }

        public bool ActualizarCiudad(int idCiudad, string detalle, int idPais)
        {
            return _ciudadesModel.ActualizarCiudad(idCiudad, detalle, idPais);
        }
    }
}