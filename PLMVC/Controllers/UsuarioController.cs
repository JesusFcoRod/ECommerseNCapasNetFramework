using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace PLMVC.Controllers
{
    public class UsuarioController : Controller
    {

        [HttpGet]//Decorador cuya funcion es especificar que accion realizara el metodo
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario(); //instanciamos un nuevo objeto de la clase usuario
            ML.Result result = BL.Usuario.UsuarioGetAll(usuario); //Almacenamos en result la lista de objetos que se obtiene con el medoto GetAll

            usuario.Usuarios = result.Objects;//Almacenamos en la lista creada en usuario los objetos del metodo getAll

            return View(usuario);
        }

        //METODO PARA MOSTRAR EL FORMULARIO DE REGISTRO DE USUASRIO

        [HttpGet]// Siempre que se quiera mostrar una vista s eusa HttpGet
        public ActionResult Form(int? idUsuario)
        {

            ML.Result resultRol = BL.Rol.RolGetAll();//btener la lista de Roles
            ML.Result resultPais = BL.Pais.PaisGetAll();


            ML.Usuario usuario = new ML.Usuario(); //Objeto alumno para enviar a la vista 
            usuario.usuarioRol = new ML.Rol();

            usuario.direccion = new ML.Direccion();
            usuario.direccion.colonia = new ML.Colonia();
            usuario.direccion.colonia.municipio = new ML.Municipio();
            usuario.direccion.colonia.municipio.estado = new ML.Estado();
            usuario.direccion.colonia.municipio.estado.pais = new ML.Pais();


            if (resultRol.Correct && resultPais.Correct)
            {

                usuario.direccion.colonia.municipio.estado.pais.Paises = resultPais.Objects;
                usuario.usuarioRol.Roles = resultRol.Objects;// Asingnar la lista de objects a roles. 
            }
            //Sin importar que se agrege o actualice la lista de roles se debe mostrar y llenar. 

            //EDITAR SIEMPRE Y CUANDO SE TENGA UN VALOR EN ID

            if (idUsuario != null)
            {
                
                usuario.idUsuario = idUsuario.Value;
                ML.Result result = BL.Usuario.UsuarioGetAllById(usuario);

                if (result.Correct)
                {


                    usuario = (ML.Usuario)result.Object;//unboxing

                    usuario.usuarioRol.Roles = resultRol.Objects;

                    usuario.direccion.colonia.municipio.estado.pais.Paises = resultPais.Objects;

                    ML.Result resultEstado = BL.Estado.EstadoGetByIdPais(usuario.direccion.colonia.municipio.estado.pais.idPais);
                    ML.Result resultMunicipio = BL.Municipio.MunicipioGetByIdEstado(usuario.direccion.colonia.municipio.estado.idEstado);
                    ML.Result resultColonia = BL.Colonia.ColoniaGetByIdMunicipio(usuario.direccion.colonia.municipio.idMunicipio);
                    usuario.direccion.colonia.municipio.estado.Estados = resultEstado.Objects;
                    usuario.direccion.colonia.municipio.Municipios = resultMunicipio.Objects;
                    usuario.direccion.colonia.Colonias = resultColonia.Objects;


                    return View(usuario);

                }
                else
                {
                    ViewBag.Message = "Ocurrio algo al consultar la informacion del usuario"+ resultRol.ErrorMessage;
                    return View("Modal");
                }

            }
            else // MOSTRAR FORMULARIO AGREGAR NUEVO USUARIO
            {
                return View(usuario);
            }

        }

        [HttpPost] //Decorador que se utiliza cuando se quiere enviar informacion a la base desde el formulario
        public ActionResult Form(ML.Usuario usuario)
        {
            HttpPostedFileBase file = Request.Files["ImgUsuario"]; //Para poder convertir imagen a arreglo dey bytes

            if (file != null)
            {
                byte[] imagen = ConvertToBytes(file);

                usuario.Imagen = Convert.ToBase64String(imagen);
            }

            ML.Result result = new ML.Result();

            if (usuario.idUsuario > 0)
            {
                //UPDATE
                result = BL.Usuario.UsuarioUpdate(usuario);
                ViewBag.Message = "Se ha actualizado el registro";
            }
            else
            {
                //ADD
                result = BL.Usuario.UsuarioAdd(usuario);
                ViewBag.Message = "Se ha agregadao el nuevo el registro";

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

        public ActionResult Delete(int? idUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.idUsuario= idUsuario.Value;


            ML.Result resultDelete = BL.Usuario.UsuarioDelete(usuario);

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

        [HttpPost]
        public JsonResult EstadoGetByIdPais( int idPais)
        {
            ML.Result result = new ML.Result();

            result = BL.Estado.EstadoGetByIdPais(idPais);

            return Json(result.Objects);
        }

        [HttpPost]
        public JsonResult MunicipioGetByIdEstado(int idEstado)
        {
            ML.Result resultMunicipio = new ML.Result();
            resultMunicipio = BL.Municipio.MunicipioGetByIdEstado(idEstado);

            return Json(resultMunicipio.Objects);
        }

        [HttpPost]
        public JsonResult ColoniaGetByIdMunicipio(int idMunicipio)
        {
            ML.Result resultColonia = new ML.Result();
            resultColonia = BL.Colonia.ColoniaGetByIdMunicipio(idMunicipio);

            return Json(resultColonia.Objects);

        }

        public byte[] ConvertToBytes(HttpPostedFileBase Foto)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Foto.InputStream);
            data = reader.ReadBytes((int)Foto.ContentLength);

            return data;
        }

    }
}