using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLMVC.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult GetAll()
        {
            ML.Result resultDep = BL.Departamento.DepartamentoGetAll();

            ML.Producto producto = new ML.Producto();
            producto.Departamento = new ML.Departamento();

            ML.Result result = BL.Producto.GetAll(producto);


            if (resultDep.Correct && result.Correct)
            {
                producto.Productos = result.Objects;
                producto.Departamento.Departamentos = resultDep.Objects;
            }

            return View(producto);
        }
    }
}