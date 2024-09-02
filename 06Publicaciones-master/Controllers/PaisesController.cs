using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _06Publicaciones.Models;
using System.Data;
namespace _06Publicaciones.Controllers
{
    class PaisesController
    {
        PaisModel _PaisModel = new PaisModel();

        public DataTable todos() {

            return _PaisModel.todos();
        
        
        }

            }
}
