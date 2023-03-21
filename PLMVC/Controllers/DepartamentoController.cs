using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PLMVC.Controllers
{
    public class DepartamentoController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Departamento departamento = new ML.Departamento();

            //ML.Result result = BL.Departamento.DepartamentoGetAll();

            //------- WCF SERVICE --------------------------------------------------
            DepartamentoService.DepartamentoClient departamentoClient = new DepartamentoService.DepartamentoClient();
            ML.Result result = departamentoClient.GetAll();
            //----------------------------------------------------------------------

            departamento.Departamentos = result.Objects;



            return View(departamento);
        }

        [HttpGet]
        public ActionResult Form(int? idDepartamento)
        {
            ML.Result resultAreas = BL.Area.AreaGetlAll();
            ML.Departamento departamento = new ML.Departamento();
            departamento.Area = new ML.Area();


            if (resultAreas.Correct)
            {
                departamento.Area.Areas = resultAreas.Objects;
            }

            if (idDepartamento != null)
            {
                //departamento.idDepartamento = idDepartamento.Value;

                //ML.Result result = BL.Departamento.DepartamentoGetById(departamento);

                DepartamentoService.IDepartamento departamentoClient = new DepartamentoService.DepartamentoClient();
                ML.Result result = departamentoClient.GetById(idDepartamento.Value);

                if (result.Correct)
                {
                    departamento = (ML.Departamento)result.Object;//unboxing

                    departamento.Area.Areas = resultAreas.Objects;

                    return View(departamento);
                }
                else
                {
                    ViewBag.Message = "Ocurrio algo al consultar la informacion del usuario" + resultAreas.ErrorMessage;
                    return View("Modal");
                }

            }
            else
            {
                return View(departamento);
            }

        }
        [HttpPost]
        public ActionResult Form(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();

            if (departamento.idDepartamento > 0)
            {
                //------------------ UPDATE SIN WCF -------------------------
                //result = BL.Departamento.DepartamentoUpdate(departamento);
                //ViewBag.Message = "Se ha actualizado el registro";
                //return View("Modal");
                //-----------------------------------------------------------

                //------------------ UPDATE WCF -----------------------------
                DepartamentoService.DepartamentoClient departamentoClient = new DepartamentoService.DepartamentoClient();
                result = departamentoClient.Update(departamento);
                ViewBag.Message = "Se ha actualizado el registro";
                //-----------------------------------------------------------
            }
            else
            {
                // ----------------- ADD SIN WCF ----------------------------
                //result = BL.Departamento.DepartamentoAdd(departamento);
                //ViewBag.Message = "Se ha agregadao el nuevo el registro";
                //-----------------------------------------------------------

                //------------------ ADD WCF --------------------------------
                DepartamentoService.DepartamentoClient departamentoClient = new DepartamentoService.DepartamentoClient();
                result = departamentoClient.Add(departamento);
                ViewBag.Message = "Se ha agregadao el nuevo el registro";
                //-----------------------------------------------------------

            }

            if (result.Correct == true)
            {

                return PartialView("Modal");
            }
            else
            {
                return PartialView("Modal");
            }
        }

        [HttpGet]
        public ActionResult Delete(int idDepartamento)
        {
            ML.Departamento departamento = new ML.Departamento();
            departamento.idDepartamento = idDepartamento;

            //ML.Result resultDelete = BL.Departamento.DepartamentoDelete(idDepartamento);

            //--------------------- DELETE WCF -----------------------------------------
            DepartamentoService.DepartamentoClient departamentoClient = new DepartamentoService.DepartamentoClient();
            ML.Result resultDelete = departamentoClient.Delete(idDepartamento);
            //--------------------------------------------------------------------------

            if (resultDelete.Correct == true)
            {
                ViewBag.Message = "Se ha eliminado el registro";
                return PartialView("Modal");
            }
            else
            {
                ViewBag.Message = "No se ha eliminado el registro";
                return PartialView("Modal");
            }

        }
    }
}