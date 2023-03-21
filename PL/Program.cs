using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        static void Main(string[] args)
        {

            int op;

            do
            {
                Console.WriteLine("SELECCIONE UNA OPCION: ");
                Console.WriteLine("1.- INSERTAR USUARIO");
                Console.WriteLine("2.- ACTUALIZAR USUARIO");
                Console.WriteLine("3.- ELIMINAR USUARIO");
                Console.WriteLine("4.- MOSTRAR USUARIOS ");
                Console.WriteLine("5.- MOSTRAR UN USUARIO ");
                Console.WriteLine("6.- ADD DEPARTAMENTO");
                Console.WriteLine("7.- UPDATE DEPARTAMENTO");
                Console.WriteLine("8.- DELETE DEPARTAMENTO");
                Console.WriteLine("9.- SUMA CON SOAP SERVICE");
                Console.WriteLine("10.- RESTA CON SOAP SERVICE");
                Console.WriteLine("11.- MULTIPLICACION CON SOAP SERVICE");
                Console.WriteLine("12.- DIVICION CON SOAP SERVICE");
                Console.WriteLine("13.- GET ALL DEPARATAMENTO WCF");
                Console.WriteLine("14.- ADD DEPARATAMENTO WCF");
                Console.WriteLine("15.- UPDATE DEPARATAMENTO WCF");
                Console.WriteLine("16.- DELETE DEPARATAMENTO WCF");
                op = int.Parse(Console.ReadLine());


                switch (op)
                {
                    //NUEVOS METODOS PARA USUARIO CON ENTITY
                    case 1:
                        ML.Usuario usuarioAdd = new ML.Usuario();

                        Console.WriteLine("Ingrese el UserName: ");
                        usuarioAdd.userName = Console.ReadLine();

                        Console.WriteLine("Ingrese el Nombre: ");
                        usuarioAdd.nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese el Apellido Paterno: ");
                        usuarioAdd.apellidoPaterno = Console.ReadLine();

                        Console.WriteLine("Ingrese el Apellido Materno: ");
                        usuarioAdd.apellidoMaterno = Console.ReadLine();

                        Console.WriteLine("Ingrese el Email: ");
                        usuarioAdd.email = Console.ReadLine();

                        Console.WriteLine("Ingrese el Password: ");
                        usuarioAdd.password = Console.ReadLine();

                        Console.WriteLine("Ingrese la fecha de nacimiento: ");
                        usuarioAdd.fechaNacimiento = Console.ReadLine();

                        Console.WriteLine("Ingrese el Sexo: ");
                        usuarioAdd.sexo = Console.ReadLine();

                        Console.WriteLine("Ingrese el Telefono: ");
                        usuarioAdd.telefono = Console.ReadLine();

                        Console.WriteLine("Ingrese el Celular: ");
                        usuarioAdd.celular = Console.ReadLine();

                        Console.WriteLine("Ingrese el CURP: ");
                        usuarioAdd.curp = Console.ReadLine();

                        usuarioAdd.usuarioRol = new ML.Rol();

                        Console.WriteLine("Ingrese el idRol: ");
                        usuarioAdd.usuarioRol.idRol = int.Parse(Console.ReadLine());

                        ML.Result result = BL.Usuario.UsuarioAdd(usuarioAdd);

                        if (result.Correct == true)
                        {
                            Console.WriteLine("Se ha insertado el registro");
                        }
                        else
                        {
                            Console.WriteLine("No se ha podido insertar el registro debido a: " + result.ErrorMessage);
                        }
                        Console.ReadKey();

                        break;

                    case 2:
                        ML.Usuario usuarioUpdate = new ML.Usuario();

                        Console.WriteLine("Ingrese el id del usuario a modificar: ");
                        usuarioUpdate.idUsuario = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el UserName: ");
                        usuarioUpdate.userName = Console.ReadLine();

                        Console.WriteLine("Ingrese el Nombre: ");
                        usuarioUpdate.nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese el Apellido Paterno: ");
                        usuarioUpdate.apellidoPaterno = Console.ReadLine();

                        Console.WriteLine("Ingrese el Apellido Materno: ");
                        usuarioUpdate.apellidoMaterno = Console.ReadLine();

                        Console.WriteLine("Ingrese el Email: ");
                        usuarioUpdate.email = Console.ReadLine();

                        Console.WriteLine("Ingrese el Password: ");
                        usuarioUpdate.password = Console.ReadLine();

                        Console.WriteLine("Ingrese la fecha de nacimiento: ");
                        usuarioUpdate.fechaNacimiento = Console.ReadLine();

                        Console.WriteLine("Ingrese el Sexo: ");
                        usuarioUpdate.sexo = Console.ReadLine();

                        Console.WriteLine("Ingrese el Telefono: ");
                        usuarioUpdate.telefono = Console.ReadLine();

                        Console.WriteLine("Ingrese el Celular: ");
                        usuarioUpdate.celular = Console.ReadLine();

                        Console.WriteLine("Ingrese el CURP: ");
                        usuarioUpdate.curp = Console.ReadLine();

                        usuarioUpdate.usuarioRol = new ML.Rol();

                        Console.WriteLine("Ingrese el idRol: ");
                        usuarioUpdate.usuarioRol.idRol = int.Parse(Console.ReadLine());

                        ML.Result resultUpdate = BL.Usuario.UsuarioUpdate(usuarioUpdate);

                        if (resultUpdate.Correct == true)
                        {
                            Console.WriteLine("Se ha modificado el registro");
                        }
                        else
                        {
                            Console.WriteLine("No se ha podido modificar el registro debido a: " + resultUpdate.ErrorMessage);
                        }
                        Console.ReadKey();
                        break;

                    case 3:
                        ML.Usuario usuarioDelete = new ML.Usuario();

                        Console.WriteLine("Ingrese el id del usuario a eliminar: ");
                        usuarioDelete.idUsuario = int.Parse(Console.ReadLine());

                        ML.Result resultDeleteUs = BL.Usuario.UsuarioDelete(usuarioDelete);

                        if (resultDeleteUs.Correct == true)
                        {
                            Console.WriteLine("Se ha eliminado el registro");
                        }
                        else
                        {
                            Console.WriteLine("No se ha podido eliminar el registro debido a: " + resultDeleteUs.ErrorMessage);
                        }
                        Console.ReadKey();

                        break;

                    case 4:
                        ML.Usuario usuario = new ML.Usuario();
                        ML.Result resultGetAll = BL.Usuario.UsuarioGetAll(usuario);

                        foreach (ML.Usuario usuarioGetAll in resultGetAll.Objects)
                        {
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("ID USUARIO: " + usuarioGetAll.idUsuario);
                            Console.WriteLine("USERNAME: " + usuarioGetAll.userName);
                            Console.WriteLine("NOMBRE: " + usuarioGetAll.nombre);
                            Console.WriteLine("APELLIDO PATERNO: " + usuarioGetAll.apellidoPaterno);
                            Console.WriteLine("APELLIDO MATERNO: " + usuarioGetAll.apellidoMaterno);
                            Console.WriteLine("EMAIL: " + usuarioGetAll.email);
                            Console.WriteLine("PASSWORD: " + usuarioGetAll.password);
                            Console.WriteLine("FECHA DE NACIMIENTO: " + usuarioGetAll.fechaNacimiento);
                            Console.WriteLine("SEXO: " + usuarioGetAll.sexo);
                            Console.WriteLine("TELEFONO: " + usuarioGetAll.telefono);
                            Console.WriteLine("CELULAR: " + usuarioGetAll.celular);
                            Console.WriteLine("CURP: " + usuarioGetAll.curp);
                            Console.WriteLine("ID ROL: " + usuarioGetAll.usuarioRol.idRol);
                            Console.WriteLine("ROL: " + usuarioGetAll.usuarioRol.descripcion);
                            Console.WriteLine("-------------------------------------------");
                        }
                        Console.ReadKey();
                        break;

                    case 5:

                        ML.Usuario usuarioGetId = new ML.Usuario();

                        Console.WriteLine("Ingrese el ID del usuario a mostrar: ");
                        usuarioGetId.idUsuario = int.Parse(Console.ReadLine());

                        ML.Result resultGetID = BL.Usuario.UsuarioGetAllById(usuarioGetId);

                        //Unboxing
                        usuarioGetId = (ML.Usuario)resultGetID.Object;

                        Console.WriteLine("-----------------------------------------");
                        Console.WriteLine("ID USUARIO: " + usuarioGetId.idUsuario);
                        Console.WriteLine("USERNAME: " + usuarioGetId.userName);
                        Console.WriteLine("NOMBRE: " + usuarioGetId.nombre);
                        Console.WriteLine("APELLIDO PATERNO: " + usuarioGetId.apellidoPaterno);
                        Console.WriteLine("APELLIDO MATERNO: " + usuarioGetId.apellidoMaterno);
                        Console.WriteLine("EMAIL: " + usuarioGetId.email);
                        Console.WriteLine("PASSWORD: " + usuarioGetId.password);
                        Console.WriteLine("FECHA DE NACIMIENTO: " + usuarioGetId.fechaNacimiento);
                        Console.WriteLine("SEXO: " + usuarioGetId.sexo);
                        Console.WriteLine("TELEFONO: " + usuarioGetId.telefono);
                        Console.WriteLine("CELULAR: " + usuarioGetId.celular);
                        Console.WriteLine("CURP: " + usuarioGetId.curp);
                        Console.WriteLine("ID ROL: " + usuarioGetId.usuarioRol.idRol);
                        Console.WriteLine("ROL: " + usuarioGetId.usuarioRol.descripcion);
                        Console.WriteLine("-------------------------------------------");

                        break;


                    //case 4:// GET ALL INNER JOIN 
                    //    ML.Result result4 = BL.Usuario.usuarioGetAllInnerJoin();
                    //    foreach (ML.Usuario usuario in result4.Objects)
                    //    {
                    //        Console.WriteLine("---------------------------------------");
                    //        Console.WriteLine("ID: " + usuario.idUsuario);
                    //        Console.WriteLine("RFC: " + usuario.rfc);
                    //        Console.WriteLine("Nombre Usuario: " + usuario.nombre);
                    //        Console.WriteLine("Apellido Paterno: " + usuario.apellidoPaterno);
                    //        Console.WriteLine("Apellido Materno: " + usuario.apellidoMaterno);
                    //        Console.WriteLine("Fecha de Nacimiento: " + usuario.fechaNacimiento);
                    //        Console.WriteLine("Genero: " + usuario.genero);
                    //        Console.WriteLine("Salario: " + usuario.salario);
                    //        Console.WriteLine("Asegurado: " + usuario.asegurado);
                    //        Console.WriteLine("Id Rol: " + usuario.usuarioRol.idRol);
                    //        Console.WriteLine("Nombre Rol: " + usuario.usuarioRol.descripcion);
                    //        Console.WriteLine("----------------------------------------");
                    //    }
                    //    Console.ReadKey();
                    //    break;

                    //case 5:// GET BY ID INNER JOIN
                    //    ML.Usuario usuarioET = new ML.Usuario();
                    //    Console.WriteLine("Ingrese el ID del usuario a mostrar: ");
                    //    usuarioET.idUsuario = int.Parse(Console.ReadLine());
                    //    ML.Result result5 = BL.Usuario.GetByIdInnerJoin(usuarioET);

                    //    //Unboxing
                    //    usuarioET = (ML.Usuario)result5.Object;

                    //    Console.WriteLine("---------------------------------------");
                    //    Console.WriteLine("ID: " + usuarioET.idUsuario);
                    //    Console.WriteLine("RFC: " + usuarioET.rfc);
                    //    Console.WriteLine("Nombre Usuario: " + usuarioET.nombre);
                    //    Console.WriteLine("Apellido Paterno: " + usuarioET.apellidoPaterno);
                    //    Console.WriteLine("Apellido Materno: " + usuarioET.apellidoMaterno);
                    //    Console.WriteLine("Fecha de Nacimiento: " + usuarioET.fechaNacimiento);
                    //    Console.WriteLine("Genero: " + usuarioET.genero);
                    //    Console.WriteLine("Salario: " + usuarioET.salario);
                    //    Console.WriteLine("Asegurado: " + usuarioET.asegurado);

                    //    Console.WriteLine("Id Rol: " + usuarioET.usuarioRol.idRol);
                    //    Console.WriteLine("Id Rol: " + usuarioET.usuarioRol.descripcion);
                    //    Console.WriteLine("----------------------------------------");
                    //    Console.ReadKey();
                    //    break;

                    //case 6://GET ALL CON RIGHT JOIN 
                    //    ML.Result result6 = BL.Usuario.usuarioGetAllInnerJoin();

                    //    foreach (ML.Usuario usuario in result6.Objects)
                    //    {
                    //        Console.WriteLine("---------------------------------------");
                    //        Console.WriteLine("ID: " + usuario.idUsuario);
                    //        Console.WriteLine("RFC: " + usuario.rfc);
                    //        Console.WriteLine("Nombre Usuario: " + usuario.nombre);
                    //        Console.WriteLine("Apellido Paterno: " + usuario.apellidoPaterno);
                    //        Console.WriteLine("Apellido Materno: " + usuario.apellidoMaterno);
                    //        Console.WriteLine("Salario: " + usuario.salario);
                    //        Console.WriteLine("Asegurado: " + usuario.asegurado);
                    //        Console.WriteLine("Id Rol: " + usuario.usuarioRol.idRol);
                    //        Console.WriteLine("Nombre Rol: " + usuario.usuarioRol.descripcion);
                    //        Console.WriteLine("----------------------------------------");
                    //    }
                    //    Console.ReadKey();
                    //    break;



                    case 6: // DEPARTAMENTO

                        ML.Departamento Departamento = new ML.Departamento();

                        Console.WriteLine("Ingrese el Nombre del departamento: ");
                        Departamento.nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese el id del Area: ");
                        Departamento.Area = new ML.Area();
                        Departamento.Area.idArea = int.Parse(Console.ReadLine());

                        ML.Result resultDep = BL.Departamento.DepartamentoAdd(Departamento);

                        if (resultDep.Correct == true)
                        {
                            Console.WriteLine("Se ha agregado el registro");
                        }
                        else
                        {
                            Console.WriteLine("No se ha podido agregar el registro debido a: " + resultDep.ErrorMessage);
                        }
                        Console.ReadKey();
                        break;

                    case 7:

                        ML.Departamento DepartamentoUpdate = new ML.Departamento();

                        Console.WriteLine("Ingrese el id del Departamento a actualizar");
                        DepartamentoUpdate.idDepartamento = int.Parse(Console.ReadLine());
                        ;
                        Console.WriteLine("Ingrese el Nombre del departamento: ");
                        DepartamentoUpdate.nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese el id del Area: ");
                        DepartamentoUpdate.Area = new ML.Area();
                        DepartamentoUpdate.Area.idArea = int.Parse(Console.ReadLine());

                        ML.Result resultUpdateDep = BL.Departamento.DepartamentoUpdate(DepartamentoUpdate);

                        if (resultUpdateDep.Correct == true)
                        {
                            Console.WriteLine("Se ha actualizado el registro");
                        }
                        else
                        {
                            Console.WriteLine("No se ha podido actualizar el registro debido a: " + resultUpdateDep.ErrorMessage);
                        }
                        Console.ReadKey();
                        break;

                    case 8:
                        ML.Departamento DepartamentoDelete = new ML.Departamento();
                        int idDepartamento;
                        Console.WriteLine("Ingrese el id del departamento a eliminar: ");
                        DepartamentoDelete.idDepartamento = int.Parse(Console.ReadLine());

                        idDepartamento = DepartamentoDelete.idDepartamento;

                        ML.Result resultDelete = BL.Departamento.DepartamentoDelete(idDepartamento);

                        if (resultDelete.Correct == true)
                        {
                            Console.WriteLine("Se ha eliminado el registro");
                        }
                        else
                        {
                            Console.WriteLine("No se ha podido eliminar el registro debido a: " + resultDelete.ErrorMessage);
                        }
                        Console.ReadKey();
                        break;

                    case 9:
                        Console.WriteLine("Ingrese el numero 1: ");
                        int a = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el numero 2: ");
                        int b = int.Parse(Console.ReadLine());

                        OperacionesService.IOperaciones operaciones = new OperacionesService.OperacionesClient();
                        var resultado = operaciones.SumarNumeros(a, b);


                        Console.WriteLine("El resultado de la suma es: " + resultado);

                        break;

                    case 10:
                        Console.WriteLine("Ingrese el numero 1: ");
                        int c = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el numero 2: ");
                        int d = int.Parse(Console.ReadLine());

                        OperacionesService.IOperaciones operacionesResta = new OperacionesService.OperacionesClient();
                        var resultadoResta = operacionesResta.RestarNumeros(c, d);


                        Console.WriteLine("El resultado de la resta es: " + resultadoResta);

                        break;

                    case 11:
                        Console.WriteLine("Ingrese el numero 1: ");
                        int e = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el numero 2: ");
                        int f = int.Parse(Console.ReadLine());

                        OperacionesService.IOperaciones operacionesMult = new OperacionesService.OperacionesClient();
                        var resultadoMult = operacionesMult.MultiplicarNumeros(e, f);


                        Console.WriteLine("El resultado de multiplicar es: " + resultadoMult);

                        break;

                    case 12:
                        Console.WriteLine("Ingrese el numero 1: ");
                        int x = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el numero 2: ");
                        int y = int.Parse(Console.ReadLine());

                        OperacionesService.IOperaciones operacionesDiv = new OperacionesService.OperacionesClient();
                        var resultadoDiv = operacionesDiv.DividirNumeros(x, y);


                        Console.WriteLine("El resultado de la divicion es: " + resultadoDiv);

                        break;

                    case 13:
                        ML.Result resultDepAll = new ML.Result();
                        DepartamentoService.IDepartamento departamentoService = new DepartamentoService.DepartamentoClient();
                        resultDepAll = departamentoService.GetAll();

                        foreach (ML.Departamento departamentoAll in resultDepAll.Objects)
                        {
                            Console.WriteLine("-----------------------------------------");
                            Console.WriteLine("DEPARTAMENTO: " + departamentoAll.nombre);
                            Console.WriteLine("AREA: " + departamentoAll.Area.nombre);
                            Console.WriteLine("-------------------------------------------");
                        }
                        break;

                    case 14:
                        ML.Result resultAdd = new ML.Result();
                        ML.Departamento departamento = new ML.Departamento();

                        Console.WriteLine("Ingrese el nombre del departamento: ");
                        departamento.nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese el id del Area: ");
                        departamento.Area = new ML.Area();
                        departamento.Area.idArea = int.Parse(Console.ReadLine());

                        DepartamentoService.IDepartamento departamentoServiceAdd = new DepartamentoService.DepartamentoClient();
                        resultAdd = departamentoServiceAdd.Add(departamento);

                        if (resultAdd.Correct)
                        {
                            Console.WriteLine("El Departamento se agrego correctamente a la base de datos ");
                        }
                        else
                        {
                            Console.WriteLine("Ocurrio un error al intenter registrar el Departamento " + resultAdd.ErrorMessage);
                        }
                        break;

                    case 15:
                        ML.Result resultUpp = new ML.Result();
                        ML.Departamento departamentoUpp = new ML.Departamento();

                        Console.WriteLine("Ingrese el id del Departamento: ");
                        departamentoUpp.idDepartamento = int.Parse(Console.ReadLine());

                        Console.WriteLine("Ingrese el nombre del departamento: ");
                        departamentoUpp.nombre = Console.ReadLine();

                        Console.WriteLine("Ingrese el id del Area: ");
                        departamentoUpp.Area = new ML.Area();
                        departamentoUpp.Area.idArea = int.Parse(Console.ReadLine());

                        DepartamentoService.IDepartamento departamentoServiceUpp = new DepartamentoService.DepartamentoClient();
                        resultUpp = departamentoServiceUpp.Update(departamentoUpp);

                        if (resultUpp.Correct)
                        {
                            Console.WriteLine("El Departamento se actualizo correctamente ");
                        }
                        else
                        {
                            Console.WriteLine("Ocurrio un error al intenter actualizar el Departamento " + resultUpp.ErrorMessage);
                        }
                        break;

                    case 16:
                        ML.Result resultDeleteDep = new ML.Result();
                        Console.WriteLine("Ingrese el id Del Departamento a Eliminar: ");
                        int idDepartamentoWCF = int.Parse(Console.ReadLine());

                        DepartamentoService.IDepartamento departamentoServiceDel = new DepartamentoService.DepartamentoClient();
                        resultDeleteDep = departamentoServiceDel.Delete(idDepartamentoWCF);

                        if (resultDeleteDep.Correct)
                        {
                            Console.WriteLine("El Departamento se elimino correctamente ");
                        }
                        else
                        {
                            Console.WriteLine("Ocurrio un error al intenter eliminar el Departamento " + resultDeleteDep.ErrorMessage);
                        }
                        break;
                    case 17:

                        break;

                        // METODOS LINQ

                        //case 8:   
                        //    ML.Usuario usuarioLQ2 = new ML.Usuario();

                        //    Console.WriteLine("Ingrese el ID del usuario a modificar: ");
                        //    usuarioLQ2.idUsuario = int.Parse(Console.ReadLine());

                        //    Console.WriteLine("Ingrese el RFC: ");
                        //    usuarioLQ2.rfc = Console.ReadLine();

                        //    Console.WriteLine("Ingrese el Nombre: ");
                        //    usuarioLQ2.nombre = Console.ReadLine();

                        //    Console.WriteLine("Ingrese el Apellido paterno: ");
                        //    usuarioLQ2.apellidoPaterno = Console.ReadLine();

                        //    Console.WriteLine("Ingrese el Apellido materno: ");
                        //    usuarioLQ2.apellidoMaterno = Console.ReadLine();

                        //    Console.WriteLine("Ingrese la Fecha de Nacimiento: ");
                        //    usuarioLQ2.fechaNacimiento = DateTime.Parse(Console.ReadLine());

                        //    Console.WriteLine("Ingrese el Genero: ");
                        //    usuarioLQ2.genero = char.Parse(Console.ReadLine());

                        //    Console.WriteLine("Ingrese el Salario: ");
                        //    usuarioLQ2.salario = float.Parse(Console.ReadLine());

                        //    Console.WriteLine("Ingrese si esat asegurado: ");
                        //    usuarioLQ2.asegurado = bool.Parse(Console.ReadLine());

                        //    Console.WriteLine("Ingrese el id del rol: ");
                        //    usuarioLQ2.usuarioRol = new ML.Rol();
                        //    usuarioLQ2.usuarioRol.idRol = int.Parse(Console.ReadLine());

                        //    ML.Result resultLQ2 = BL.Usuario.updateLINQ(usuarioLQ2);

                        //    if (resultLQ2.Correct == true)
                        //    {
                        //        Console.WriteLine("Se ha actualizado el registro");
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("No se ha podido actualizar el registro debido a: " + resultLQ2.ErrorMessage);
                        //    }
                        //    Console.ReadKey();
                        //    break;

                        //case 9:

                        //    ML.Usuario usuarioLQ3 = new ML.Usuario();

                        //    Console.WriteLine("Ingrese el ID del usuario a eliminar: ");
                        //    usuarioLQ3.idUsuario = int.Parse(Console.ReadLine());

                        //    ML.Result resultLQ3 = BL.Usuario.deleteLINQ(usuarioLQ3);

                        //    if (resultLQ3.Correct == true)
                        //    {
                        //        Console.WriteLine("Se ha eliminado el registro");
                        //    }
                        //    else
                        //    {
                        //        Console.WriteLine("No se ha podido eliminar el registro debido a: " + resultLQ3.ErrorMessage);
                        //    }
                        //    Console.ReadKey();

                        //    break;

                        //case 10:

                        //    ML.Result resultLQ4 = BL.Usuario.usuarioGetAllLINQ();

                        //    foreach (ML.Usuario usuario in resultLQ4.Objects)
                        //    {
                        //        Console.WriteLine("---------------------------------------");
                        //        Console.WriteLine("ID: " + usuario.idUsuario);
                        //        Console.WriteLine("RFC: " + usuario.rfc);
                        //        Console.WriteLine("Nombre Usuario: " + usuario.nombre);
                        //        Console.WriteLine("Apellido Paterno: " + usuario.apellidoPaterno);
                        //        Console.WriteLine("Apellido Materno: " + usuario.apellidoMaterno);
                        //        Console.WriteLine("Salario: " + usuario.salario);
                        //        Console.WriteLine("Asegurado: " + usuario.asegurado);
                        //        Console.WriteLine("Id Rol: " + usuario.usuarioRol.idRol);
                        //        Console.WriteLine("Nombre Rol: " + usuario.usuarioRol.descripcion);
                        //        Console.WriteLine("----------------------------------------");
                        //    }
                        //    Console.ReadKey();
                        //    break;

                        //case 11:

                        //    ML.Usuario usuarioLQ11 = new ML.Usuario();

                        //    Console.WriteLine("Ingrese el ID del usuario a mostrar: ");
                        //    usuarioLQ11.idUsuario = int.Parse(Console.ReadLine());

                        //    ML.Result resultLQ5 = BL.Usuario.usuarioGetByIdLINQ(usuarioLQ11);

                        //    //Unboxing
                        //    usuarioLQ11 = (ML.Usuario)resultLQ5.Object;

                        //    Console.WriteLine("---------------------------------------");
                        //    Console.WriteLine("ID: " + usuarioLQ11.idUsuario);
                        //    Console.WriteLine("RFC: " + usuarioLQ11.rfc);
                        //    Console.WriteLine("Nombre Usuario: " + usuarioLQ11.nombre);
                        //    Console.WriteLine("Apellido Paterno: " + usuarioLQ11.apellidoPaterno);
                        //    Console.WriteLine("Apellido Materno: " + usuarioLQ11.apellidoMaterno);
                        //    Console.WriteLine("Fecha de Nacimiento: " + usuarioLQ11.fechaNacimiento);
                        //    Console.WriteLine("Genero: " + usuarioLQ11.genero);
                        //    Console.WriteLine("Salario: " + usuarioLQ11.salario);
                        //    Console.WriteLine("Asegurado: " + usuarioLQ11.asegurado);

                        //    Console.WriteLine("Id Rol: " + usuarioLQ11.usuarioRol.idRol);
                        //    Console.WriteLine("Id Rol: " + usuarioLQ11.usuarioRol.descripcion);
                        //    Console.WriteLine("----------------------------------------");
                        //    Console.ReadKey();

                        //    break;



                }
            } while (op <= 12);
        }
    }
}
