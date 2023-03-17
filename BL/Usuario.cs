using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Contexts;
using ML;
using System.Security.Cryptography;
using DL;
using System.Data.Entity.Core.Common.CommandTrees;

namespace BL
{
    //Colocar el nombre completo de los metodos como : AnadirRegistro, EliminarRegistro, etc. 
    // Procurar usar la notacion Upper y Lower cuando se necesite. 
    public class Usuario
    {
        //METODOS PARA NUEVA TABLA USUARIO

        public static ML.Result UsuarioAdd(ML.Usuario usuario)
        {
            ML.Result resultAdd = new ML.Result();

            try
            {
                using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
                {
                    var query = contex.UsuarioAdd(usuario.userName, usuario.nombre, usuario.apellidoPaterno, usuario.apellidoMaterno,
                        usuario.email, usuario.password, usuario.fechaNacimiento, usuario.sexo.ToString(), usuario.telefono, usuario.celular,
                        usuario.curp, usuario.usuarioRol.idRol,usuario.Imagen,usuario.direccion.calle,usuario.direccion.numeroInterio,usuario.direccion.numeroExterior,
                        usuario.direccion.colonia.idColonia);

                    if (query > 0)
                    {
                        resultAdd.Correct = true;
                    }
                    else
                    {
                        resultAdd.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                resultAdd.Ex = ex;
                resultAdd.Correct = false;
                resultAdd.ErrorMessage = ex.Message;
            }
            return resultAdd;
        }

        public static ML.Result UsuarioUpdate(ML.Usuario usuario)
        {
            ML.Result resultUpdate = new Result();
            try
            {
                using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
                {
                    var query = contex.UsuarioUpdate(usuario.userName, usuario.nombre, usuario.apellidoPaterno, usuario.apellidoMaterno,
                        usuario.email, usuario.password, usuario.fechaNacimiento, usuario.sexo.ToString(), usuario.telefono, usuario.celular, usuario.curp,
                        usuario.usuarioRol.idRol, usuario.idUsuario,usuario.Imagen,usuario.direccion.calle,usuario.direccion.numeroInterio, 
                        usuario.direccion.numeroExterior, usuario.direccion.colonia.idColonia);

                    if (query > 0)
                    {
                        resultUpdate.Correct = true;
                    }
                    else
                    {
                        resultUpdate.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                resultUpdate.Ex = ex;
                resultUpdate.Correct = false;
                resultUpdate.ErrorMessage = ex.Message;
            }
            return resultUpdate;
        }

        public static ML.Result UsuarioDelete(ML.Usuario usuario)
        {
            ML.Result resultDelete = new ML.Result();

            try
            {
                using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
                {
                    var query = contex.UsuarioUDelete(usuario.idUsuario);


                    if (query > 0)
                    {
                        resultDelete.Correct = true;
                    }
                    else
                    {
                        resultDelete.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                resultDelete.Ex = ex;
                resultDelete.Correct = false;
                resultDelete.ErrorMessage = ex.Message;
            }
            return resultDelete;
        }

        public static ML.Result UsuarioGetAll(ML.Usuario usuarioP)
        {
            ML.Result resultGetlALL = new ML.Result();

            try
            {
                using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
                {
                    var query = contex.UsuarioGetAll(usuarioP.nombre, usuarioP.apellidoPaterno, usuarioP.apellidoMaterno).ToList();

                    resultGetlALL.Objects = new List<object>();

                    foreach (var objetoUsuario in query)
                    {
                        ML.Usuario usuario = new ML.Usuario();
                        usuario.idUsuario = int.Parse(objetoUsuario.idUsuario.ToString());
                        usuario.userName = objetoUsuario.Username;

                        usuario.nombreCompleto = objetoUsuario.Nombre + " " +
                                                 objetoUsuario.ApellidoPaterno + " " + 
                                                 objetoUsuario.ApellidoMaterno;

                        usuario.email = objetoUsuario.Email;
                        usuario.password = objetoUsuario.Password;
                        usuario.fechaNacimiento = objetoUsuario.FechaNacimiento.ToString("dd-MM-yyyy");
                        usuario.sexo = objetoUsuario.Sexo;
                        usuario.curp = objetoUsuario.CURP;

                        usuario.contacto = " Telefono: " + objetoUsuario.Telefono +
                                           " Celular: " + objetoUsuario.Celular;


                        usuario.usuarioRol = new ML.Rol();
                        usuario.usuarioRol.idRol = int.Parse(objetoUsuario.idRol.ToString());
                        usuario.usuarioRol.descripcion = objetoUsuario.NombreRol;

                        usuario.direccionCompleta = "Calle: "       + objetoUsuario.Calle           + 
                                                    "No.Exterior: " + objetoUsuario.NumeroExterior  +
                                                    "No.Interior: " + objetoUsuario.NumeroInterior  + 
                                                    "Colonia: "     + objetoUsuario.nombreColonia   +
                                                    "Municipio: "   + objetoUsuario.nombreMunicipio + 
                                                    "Estado: "      + objetoUsuario.nombreEstado    +
                                                    "Pais: "        + objetoUsuario.nombrePais;

                        usuario.Imagen = objetoUsuario.Imagen;


                        resultGetlALL.Objects.Add(usuario);
                    }
                    resultGetlALL.Correct = true;

                }

            }
            catch (Exception ex)
            {
                resultGetlALL.Ex = ex;
                resultGetlALL.Correct = false;
                resultGetlALL.ErrorMessage = ex.Message;
            }
            return resultGetlALL;
        }

        public static ML.Result UsuarioGetAllById(ML.Usuario usuario)
        {
            ML.Result resultById = new ML.Result();
            try
            {
                using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
                {
                    var query = contex.UsuarioGetById(usuario.idUsuario).FirstOrDefault();

                    ML.Usuario usuarioGetId = new ML.Usuario();

                    usuarioGetId.idUsuario = query.idUsuario;
                    usuarioGetId.userName = query.UserName;
                    usuarioGetId.nombre = query.Nombre;
                    usuarioGetId.apellidoPaterno = query.ApellidoPaterno;
                    usuarioGetId.apellidoMaterno = query.ApellidoMaterno;
                    usuarioGetId.email = query.Email;
                    usuarioGetId.password = query.Password;
                    usuarioGetId.fechaNacimiento = query.FechaNacimiento.ToString("dd-MM-yyyy");
                    usuarioGetId.sexo = query.Sexo;
                    usuarioGetId.telefono = query.Telefono;
                    usuarioGetId.celular = query.Celular;
                    usuarioGetId.curp = query.CURP;
                    usuarioGetId.Imagen= query.Imagen;

                    usuarioGetId.usuarioRol = new ML.Rol();
                    usuarioGetId.usuarioRol.idRol = int.Parse(query.idRol.ToString());
                    usuarioGetId.usuarioRol.descripcion = query.NombreRol;

                    usuarioGetId.direccion = new ML.Direccion();
                    usuarioGetId.direccion.calle = query.Calle;
                    usuarioGetId.direccion.numeroExterior = query.NumeroExterior;
                    usuarioGetId.direccion.numeroInterio = query.NumeroInterior;

                    usuarioGetId.direccion.colonia = new ML.Colonia();
                    usuarioGetId.direccion.colonia.idColonia = query.idColonia;

                    usuarioGetId.direccion.colonia.municipio = new ML.Municipio();
                    usuarioGetId.direccion.colonia.municipio.idMunicipio = query.idMunicipio;

                    usuarioGetId.direccion.colonia.municipio.estado = new ML.Estado();
                    usuarioGetId.direccion.colonia.municipio.estado.idEstado = query.idEstado;

                    usuarioGetId.direccion.colonia.municipio.estado.pais = new ML.Pais();
                    usuarioGetId.direccion.colonia.municipio.estado.pais.idPais = query.idPais;

                    //Boxing: Guardar el modelo o tipo de dato en un object
                    resultById.Object = usuarioGetId;

                    resultById.Correct = true;
                }
            }
            catch (Exception ex)
            {
                resultById.Ex = ex;
                resultById.Correct = false;
                resultById.ErrorMessage = ex.Message;
            }
            return resultById;

        }




















        //------------------------------------------------------------------------------------------------------------

        //CODIGOS DE APOYO 

        //ADD
        //public static ML.Result Add(ML.Usuario usr)
        //{
        //    ML.Result result = new ML.Result();//instancia de clase result

        //    //try catch se usa para manejar excepciones
        //    try
        //    {//todo lo que se va validar

        //        using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            //Consulta
        //            var cmd = new SqlCommand("INSERT INTO usuario(RFC, nombre, apelliidoP, apellidoM,fechaNac, genero, salario, asegurado) VALUES (@rfc,@nombre,@apellidoP,@apellidoM,@fechaNac,@genero,@salario,@asegurado)", contex);
        //            cmd.Parameters.AddWithValue("@rfc", usr.rfc);
        //            cmd.Parameters.AddWithValue("@nombre", usr.nombre);
        //            cmd.Parameters.AddWithValue("@apellidoP", usr.apellidoPaterno);
        //            cmd.Parameters.AddWithValue("@apellidoM", usr.apellidoMaterno);
        //            cmd.Parameters.AddWithValue("@fechaNac", usr.fechaNacimiento);
        //            cmd.Parameters.AddWithValue("@genero", usr.genero);
        //            cmd.Parameters.AddWithValue("@salario", usr.salario);
        //            cmd.Parameters.AddWithValue("@asegurado", usr.asegurado);
        //            contex.Open();
        //            cmd.ExecuteNonQuery();

        //        }

        //    }
        //    catch (Exception ex)
        //    {//si algo sale mal haz esto
        //        Console.WriteLine(ex.GetType().FullName);
        //        Console.WriteLine(ex.Message);
        //    }
        //    return result;

        //}

        //public static ML.Result Add2(ML.Usuario usr)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            //string Query = "INSERT INTO usuario(RFC, nombre, apelliidoP, apellidoM,fechaNac, genero, salario, asegurado) VALUES (@rfc,@nombre,@apellidoP,@apellidoM,@fechaNac,@genero,@salario,@asegurado)";
        //            string Query = "UsuarioAdd";//STORED PROCEDURE
        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.Connection = contex;//Cadena de conexion
        //                cmd.CommandText = Query;//Consulta
        //                cmd.CommandType = CommandType.StoredProcedure;//STORE PROCEDURE

        //                SqlParameter[] parameters = new SqlParameter[8];//Arreglo o listado de datos

        //                parameters[0] = new SqlParameter("@rfc", System.Data.SqlDbType.VarChar);
        //                parameters[0].Value = usr.rfc;

        //                parameters[1] = new SqlParameter("@nombre", System.Data.SqlDbType.VarChar);
        //                parameters[1].Value = usr.nombre;

        //                parameters[2] = new SqlParameter("@apellidoP", System.Data.SqlDbType.VarChar);
        //                parameters[2].Value = usr.apellidoPaterno;

        //                parameters[3] = new SqlParameter("@apellidoM", System.Data.SqlDbType.VarChar);
        //                parameters[3].Value = usr.apellidoMaterno;

        //                parameters[4] = new SqlParameter("@fechaNac", System.Data.SqlDbType.Date);
        //                parameters[4].Value = usr.fechaNacimiento;

        //                parameters[5] = new SqlParameter("@genero", System.Data.SqlDbType.Char);
        //                parameters[5].Value = usr.genero;

        //                parameters[6] = new SqlParameter("@salario", System.Data.SqlDbType.Float);
        //                parameters[6].Value = usr.salario;

        //                parameters[7] = new SqlParameter("@asegurado", System.Data.SqlDbType.Bit);
        //                parameters[7].Value = usr.asegurado;

        //                cmd.Parameters.AddRange(parameters);
        //                cmd.Connection.Open();

        //                int rowsAffected = cmd.ExecuteNonQuery();

        //                if (rowsAffected > 0)
        //                {
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //        result.Correct = false;
        //    }
        //    return result;
        //}

        //public static ML.Result usuarioAddEF(ML.Usuario usrEntity)
        //{
        //    ML.Result resultEntity = new ML.Result();

        //    try
        //    {
        //        using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
        //        {
        //            var query = contex.UsuarioAdd(usrEntity.rfc, usrEntity.nombre, usrEntity.apellidoPaterno, usrEntity.apellidoMaterno, usrEntity.fechaNacimiento,
        //                usrEntity.genero.ToString(), usrEntity.salario, usrEntity.asegurado, usrEntity.usuarioRol.idRol);

        //            if (query > 0)
        //            {
        //                resultEntity.Correct = true;
        //            }
        //            else
        //            {
        //                resultEntity.Correct = false;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        resultEntity.ErrorMessage = ex.Message;
        //        resultEntity.Ex = ex;
        //        resultEntity.Correct = false;
        //    }
        //    return resultEntity;


        //}
        // UPDATE
        //public static ML.Result Upp(ML.Usuario usr2)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            var cmd = new SqlCommand("UPDATE usuario SET RFC=@rfc, nombre=@nombre, apelliidoP=@apellidoP, apellidoM=@apellidoM, fechaNac=@fechaNac, genero=@genero, salario=@salario, asegurado=@asegurado WHERE id_usuario=@idUsuario", conn);
        //            cmd.Parameters.AddWithValue("@idUsuario", usr2.idUsuario);
        //            cmd.Parameters.AddWithValue("@rfc", usr2.rfc);
        //            cmd.Parameters.AddWithValue("@nombre", usr2.nombre);
        //            cmd.Parameters.AddWithValue("@apellidoP", usr2.apellidoPaterno);
        //            cmd.Parameters.AddWithValue("@apellidoM", usr2.apellidoMaterno);
        //            cmd.Parameters.AddWithValue("@fechaNac", usr2.fechaNacimiento);
        //            cmd.Parameters.AddWithValue("@genero", usr2.genero);
        //            cmd.Parameters.AddWithValue("@salario", usr2.salario);
        //            cmd.Parameters.AddWithValue("@asegurado", usr2.asegurado);
        //            conn.Open();
        //            cmd.ExecuteNonQuery();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.GetType().FullName);
        //        Console.WriteLine(ex.Message);
        //    }
        //    return result;
        //}

        //public static ML.Result Upp2(ML.Usuario usr2)
        //{
        //    ML.Result result2 = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            //string Query = "UPDATE usuario SET RFC=@rfc, nombre=@nombre, apelliidoP=@apellidoP, apellidoM=@apellidoM, fechaNac=@fechaNac, genero=@genero, salario=@salario, asegurado=@asegurado WHERE id_usuario=@idUsuario";
        //            string Query = "UsuarioUpdate";


        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.Connection = contex;//Cadena de conexion
        //                cmd.CommandText = Query;//Consulta
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                SqlParameter[] parameters = new SqlParameter[9];//Arreglo o listado de datos

        //                parameters[0] = new SqlParameter("@idUsuario", System.Data.SqlDbType.Int);
        //                parameters[0].Value = usr2.idUsuario;

        //                parameters[1] = new SqlParameter("@rfc", System.Data.SqlDbType.VarChar);
        //                parameters[1].Value = usr2.rfc;

        //                parameters[2] = new SqlParameter("@nombre", System.Data.SqlDbType.VarChar);
        //                parameters[2].Value = usr2.nombre;

        //                parameters[3] = new SqlParameter("@apellidoP", System.Data.SqlDbType.VarChar);
        //                parameters[3].Value = usr2.apellidoPaterno;

        //                parameters[4] = new SqlParameter("@apellidoM", System.Data.SqlDbType.VarChar);
        //                parameters[4].Value = usr2.apellidoMaterno;

        //                parameters[5] = new SqlParameter("@fechaNac", System.Data.SqlDbType.Date);
        //                parameters[5].Value = usr2.fechaNacimiento;

        //                parameters[6] = new SqlParameter("@genero", System.Data.SqlDbType.Char);
        //                parameters[6].Value = usr2.genero;

        //                parameters[7] = new SqlParameter("@salario", System.Data.SqlDbType.Float);
        //                parameters[7].Value = usr2.salario;

        //                parameters[8] = new SqlParameter("@asegurado", System.Data.SqlDbType.Bit);
        //                parameters[8].Value = usr2.asegurado;

        //                cmd.Parameters.AddRange(parameters);
        //                cmd.Connection.Open();

        //                int rowsAffected = cmd.ExecuteNonQuery();

        //                if (rowsAffected > 0)
        //                {
        //                    result2.Correct = true;
        //                }
        //                else
        //                {
        //                    result2.Correct = false;
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result2.ErrorMessage = ex.Message;
        //        result2.Ex = ex;
        //        result2.Correct = false;
        //    }
        //    return result2;
        //}

        //public static ML.Result usuarioUpdateEF(ML.Usuario usrEntity2)
        //{
        //    ML.Result resultEntity2 = new ML.Result();

        //    try
        //    {
        //        using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
        //        {
        //            var query = contex.UsuarioUpdate(usrEntity2.rfc, usrEntity2.nombre, usrEntity2.apellidoPaterno,
        //                usrEntity2.apellidoMaterno, usrEntity2.fechaNacimiento, usrEntity2.genero.ToString(),
        //                usrEntity2.salario, usrEntity2.asegurado, usrEntity2.idUsuario, usrEntity2.usuarioRol.idRol);

        //            if (query > 0)
        //            {
        //                resultEntity2.Correct = true;
        //            }
        //            else
        //            {
        //                resultEntity2.Correct = false;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        resultEntity2.ErrorMessage = ex.Message;
        //        resultEntity2.Ex = ex;
        //        resultEntity2.Correct = false;
        //    }
        //    return resultEntity2;
        //}
        //DELETE
        //public static ML.Result Del(ML.Usuario usr3)
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            var cmd = new SqlCommand("DELETE FROM usuario WHERE id_usuario=@idUsuario", conn);
        //            cmd.Parameters.AddWithValue("@idUsuario", usr3.idUsuario);
        //            conn.Open();
        //            cmd.ExecuteNonQuery();

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.GetType().FullName);
        //        Console.WriteLine(ex.Message);
        //    }
        //    return result;
        //}

        //public static ML.Result Del2(ML.Usuario usr3)
        //{
        //    ML.Result result3 = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            //string Query = "DELETE FROM usuario WHERE id_usuario=@idUsuario";
        //            string Query = "UsuarioUDelete";

        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.Connection = contex;//Cadena de conexion
        //                cmd.CommandText = Query;//Consulta
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                SqlParameter[] parameters = new SqlParameter[1];//Arreglo o listado de datos

        //                parameters[0] = new SqlParameter("@idUsuario", System.Data.SqlDbType.Int);
        //                parameters[0].Value = usr3.idUsuario;

        //                cmd.Parameters.AddRange(parameters);
        //                cmd.Connection.Open();

        //                int rowsAffected = cmd.ExecuteNonQuery();

        //                if (rowsAffected > 0)
        //                {
        //                    result3.Correct = true;
        //                }
        //                else
        //                {
        //                    result3.Correct = false;
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result3.ErrorMessage = ex.Message;
        //        result3.Ex = ex;
        //        result3.Correct = false;
        //    }
        //    return result3;
        //}

        //public static ML.Result usuarioDeleteEF(ML.Usuario usuarioEntity3)
        //{
        //    ML.Result resultEntity3 = new ML.Result();

        //    try
        //    {
        //        using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
        //        {
        //            var query = contex.UsuarioUDelete(usuarioEntity3.idUsuario);

        //            if (query > 0)
        //            {
        //                resultEntity3.Correct = true;
        //            }
        //            else
        //            {
        //                resultEntity3.Correct = false;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        resultEntity3.ErrorMessage = ex.Message;
        //        resultEntity3.Ex = ex;
        //        resultEntity3.Correct = false;
        //    }
        //    return resultEntity3;

        //}

        //OBTENER TODOS LO REGISTROS DE UNA TABLA (GET ALL Y GET-BY-ID)

        //public static ML.Result GetAll()
        //{
        //    ML.Result result4 = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            //var query = "SELECT id_usuario, RFC, nombre, apelliidoP, apellidoM,fechaNac, genero, salario, asegurado FROM usuario ";
        //            var query = "UsuarioGetAll";

        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.Connection = contex;
        //                cmd.CommandText = query;
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                //Creacion de una tabla virtual 
        //                DataTable tableUsuario = new DataTable();

        //                //SqlDataAdapter permite leer la informacion de la consulta
        //                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

        //                //Llenamos la tabla virtual
        //                adapter.Fill(tableUsuario);

        //                //if para comprobar las filas de la tabla
        //                if (tableUsuario.Rows.Count > 0)
        //                {
        //                    result4.Objects = new List<object>();//creamos una lista con los objetos o registros

        //                    foreach (DataRow row in tableUsuario.Rows)
        //                    {
        //                        ML.Usuario usuario = new ML.Usuario();

        //                        usuario.idUsuario = int.Parse(row[0].ToString());
        //                        usuario.rfc = row[1].ToString();
        //                        usuario.nombre = row[2].ToString();
        //                        usuario.apellidoPaterno = row[3].ToString();
        //                        usuario.apellidoMaterno = row[4].ToString();
        //                        usuario.fechaNacimiento = DateTime.Parse(row[5].ToString());
        //                        usuario.genero = Char.Parse(row[6].ToString());
        //                        usuario.salario = float.Parse(row[7].ToString());
        //                        usuario.asegurado = bool.Parse(row[8].ToString());

        //                        result4.Objects.Add(usuario);
        //                    }
        //                    result4.Correct = true;
        //                }
        //                else
        //                {
        //                    result4.Correct = false;
        //                }
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result4.Correct = false;
        //        result4.ErrorMessage = ex.Message;
        //        result4.Ex = ex;
        //    }
        //    return result4;
        //}

        //public static ML.Result usuarioGetAllEF()
        //{
        //    ML.Result resultEntity4 = new ML.Result();

        //    try
        //    {
        //        using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
        //        {
        //            var query = contex.UsuarioGetAll().ToList();

        //            resultEntity4.Objects = new List<object>();

        //            foreach (var objetoUsuario in query)
        //            {
        //                ML.Usuario usuario = new ML.Usuario();

        //                usuario.idUsuario = int.Parse(objetoUsuario.id_usuario.ToString());
        //                usuario.rfc = objetoUsuario.RFC;
        //                usuario.nombre = objetoUsuario.nombre;
        //                usuario.apellidoPaterno = objetoUsuario.apelliidoP;
        //                usuario.apellidoMaterno = objetoUsuario.apellidoM;
        //                usuario.fechaNacimiento = DateTime.Parse(objetoUsuario.fechaNac.ToString());
        //                usuario.genero = Char.Parse(objetoUsuario.genero.ToString());
        //                usuario.salario = float.Parse(objetoUsuario.salario.ToString());
        //                usuario.asegurado = bool.Parse(objetoUsuario.asegurado.ToString());



        //                //PROPIEDAD DE NAVEGACION
        //                usuario.usuarioRol = new ML.Rol();
        //                usuario.usuarioRol.idRol = int.Parse(objetoUsuario.id_rol.ToString());

        //                resultEntity4.Objects.Add(usuario);
        //            }
        //            resultEntity4.Correct = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        resultEntity4 = new ML.Result();
        //        resultEntity4.Ex = ex;
        //        resultEntity4.Correct = false;
        //    }
        //    return resultEntity4;

        //}

        //public static ML.Result usuarioGetAllInnerJoin()
        //{
        //    ML.Result resultInner = new ML.Result();

        //    try
        //    {
        //        using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
        //        {
        //            var query = contex.UsuarioGetAll().ToList();

        //            resultInner.Objects = new List<object>();

        //            foreach (var objetoUsuario in query)
        //            {
        //                ML.Usuario usuario = new ML.Usuario();

        //                usuario.idUsuario = int.Parse(objetoUsuario.id_usuario.ToString());
        //                usuario.rfc = objetoUsuario.RFC;
        //                usuario.nombre = objetoUsuario.nombre;
        //                usuario.apellidoPaterno = objetoUsuario.apelliidoP;
        //                usuario.apellidoMaterno = objetoUsuario.apellidoM;
        //                usuario.fechaNacimiento = DateTime.Parse(objetoUsuario.fechaNac.ToString());
        //                usuario.genero = Char.Parse(objetoUsuario.genero.ToString());
        //                usuario.salario = float.Parse(objetoUsuario.salario.ToString());
        //                usuario.asegurado = bool.Parse(objetoUsuario.asegurado.ToString());



        //                //PROPIEDAD DE NAVEGACION
        //                usuario.usuarioRol = new ML.Rol();
        //                usuario.usuarioRol.idRol = int.Parse(objetoUsuario.id_rol.ToString());

        //                usuario.usuarioRol.descripcion = objetoUsuario.NombreRol;



        //                resultInner.Objects.Add(usuario);
        //            }
        //            resultInner.Correct = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        resultInner = new ML.Result();
        //        resultInner.Ex = ex;
        //        resultInner.Correct = false;
        //    }
        //    return resultInner;

        //}

        //public static ML.Result usuarioGetAllRightJoin()
        //{
        //    ML.Result resultRight = new ML.Result();

        //    try
        //    {
        //        using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
        //        {
        //            var query = contex.UsuarioGetAlRJ().ToList();

        //            resultRight.Objects = new List<object>();

        //            foreach (var objetoUsuario in query)
        //            {
        //                ML.Usuario usuario = new ML.Usuario();
        //                usuario.idUsuario = int.Parse(objetoUsuario.id_usuario.ToString());
        //                usuario.rfc = objetoUsuario.RFC;
        //                usuario.nombre = objetoUsuario.nombre;
        //                usuario.apellidoPaterno = objetoUsuario.apelliidoP;
        //                usuario.apellidoMaterno = objetoUsuario.apellidoM;
        //                usuario.salario = float.Parse(objetoUsuario.salario.ToString());
        //                usuario.asegurado = bool.Parse(objetoUsuario.asegurado.ToString());

        //                //PROPIEDAD DE NAVEGACION
        //                usuario.usuarioRol = new ML.Rol();
        //                usuario.usuarioRol.idRol = int.Parse(objetoUsuario.id_rol.ToString());
        //                usuario.usuarioRol.descripcion = objetoUsuario.descripcion;

        //                resultRight.Objects.Add(usuario);
        //            }
        //            resultRight.Correct = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        resultRight = new ML.Result();
        //        resultRight.Ex = ex;
        //        resultRight.Correct = false;
        //    }
        //    return resultRight;
        //}

        //OBTENER REGISTRO POR ID (GET/BY/ID)

        //public static ML.Result GetByid(ML.Usuario usr5)
        //{
        //    ML.Result result5 = new ML.Result();

        //    try
        //    {
        //        using (SqlConnection contex = new SqlConnection(DL.Conexion.GetConnectionString()))
        //        {
        //            //var query = "SELECT * FROM usuario WHERE id_usuario=@idUsuario";
        //            var query = "UsuarioGetById";

        //            using (SqlCommand cmd = new SqlCommand())
        //            {
        //                cmd.Connection = contex;
        //                cmd.CommandText = query;
        //                cmd.CommandType = CommandType.StoredProcedure;

        //                //PARAMETROS
        //                SqlParameter[] parameters = new SqlParameter[1];
        //                parameters[0] = new SqlParameter("@idUsuario", System.Data.SqlDbType.Int);
        //                parameters[0].Value = usr5.idUsuario;
        //                cmd.Parameters.AddRange(parameters);
        //                cmd.Connection.Open();
        //                cmd.ExecuteNonQuery();

        //                //CREACION DE LA TABLA
        //                DataTable tableUsuario = new DataTable();
        //                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //                adapter.Fill(tableUsuario);


        //                if (tableUsuario.Rows.Count > 0)
        //                {
        //                    result5.Object = new object();//new object propiedad

        //                    DataRow row = tableUsuario.Rows[0];//filas

        //                    ML.Usuario usuario = new ML.Usuario();//objeto usuario donde se almacena el registro


        //                    usr5.idUsuario = int.Parse(row[0].ToString());
        //                    usr5.rfc = row[1].ToString();
        //                    usr5.nombre = row[2].ToString();
        //                    usr5.apellidoPaterno = row[3].ToString();
        //                    usr5.apellidoMaterno = row[4].ToString();
        //                    usr5.fechaNacimiento = DateTime.Parse(row[5].ToString());
        //                    usr5.genero = Char.Parse(row[6].ToString());
        //                    usr5.salario = float.Parse(row[7].ToString());
        //                    usr5.asegurado = bool.Parse(row[8].ToString());

        //                    result5.Object = usuario;//añadimos a la propiedad el objeto o registro

        //                    result5.Correct = true;

        //                }
        //                else
        //                {
        //                    result5.Correct = false;
        //                }
        //            }

        //        }


        //    }
        //    catch (Exception ex)
        //    {
        //        result5.Correct = false;
        //        result5.ErrorMessage = ex.Message;
        //        result5.Ex = ex;
        //    }
        //    return result5;
        //}

        //public static ML.Result GetByIdEF(ML.Usuario usuarioEntity4)
        //{

        //    ML.Result resultEntity5 = new ML.Result();

        //    try
        //    {
        //        using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
        //        {
        //            var query = contex.UsuarioGetById(usuarioEntity4.idUsuario).FirstOrDefault();

        //            ML.Usuario usuarioET = new ML.Usuario();

        //            usuarioET.idUsuario = query.id_usuario;
        //            usuarioET.rfc = query.RFC;
        //            usuarioET.nombre = query.nombre;
        //            usuarioET.apellidoPaterno = query.apelliidoP;
        //            usuarioET.apellidoMaterno = query.apellidoM;
        //            usuarioET.fechaNacimiento = DateTime.Parse(query.fechaNac.ToString());
        //            usuarioET.genero = char.Parse(query.genero.ToString());
        //            usuarioET.salario = float.Parse(query.salario.ToString());
        //            usuarioET.asegurado = bool.Parse(query.asegurado.ToString());

        //            usuarioET.usuarioRol = new ML.Rol();
        //            usuarioET.usuarioRol.idRol = int.Parse(query.id_rol.ToString());


        //            //Boxing: guardar un modelo o tipo de dato de un object
        //            resultEntity5.Object = usuarioET;

        //            resultEntity5.Correct = true;

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        resultEntity5.Correct = false;
        //        resultEntity5.ErrorMessage = ex.Message;
        //        resultEntity5.Ex = ex;
        //    }

        //    return resultEntity5;

        //}

        //public static ML.Result GetByIdInnerJoin(ML.Usuario usuarioEntityInner)
        //{
        //    ML.Result resultEntity6 = new ML.Result();

        //    try
        //    {
        //        using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
        //        {
        //            var query = contex.UsuarioGetById(usuarioEntityInner.idUsuario).FirstOrDefault();

        //            ML.Usuario usuarioET = new ML.Usuario();

        //            usuarioET.idUsuario = query.id_usuario;
        //            usuarioET.rfc = query.RFC;
        //            usuarioET.nombre = query.nombre;
        //            usuarioET.apellidoPaterno = query.apelliidoP;
        //            usuarioET.apellidoMaterno = query.apellidoM;
        //            usuarioET.fechaNacimiento = DateTime.Parse(query.fechaNac.ToString());
        //            usuarioET.genero = char.Parse(query.genero.ToString());
        //            usuarioET.salario = float.Parse(query.salario.ToString());
        //            usuarioET.asegurado = bool.Parse(query.asegurado.ToString());

        //            usuarioET.usuarioRol = new ML.Rol();
        //            usuarioET.usuarioRol.idRol = int.Parse(query.id_rol.ToString());

        //            usuarioET.usuarioRol.descripcion = query.NombreRol;


        //            //Boxing: guardar un modelo o tipo de dato de un object
        //            resultEntity6.Object = usuarioET;

        //            resultEntity6.Correct = true;

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        resultEntity6.Correct = false;
        //        resultEntity6.ErrorMessage = ex.Message;
        //        resultEntity6.Ex = ex;
        //    }

        //    return resultEntity6;


        //}

        //METODOS CON LINQ

        //public static ML.Result AddLINQ(ML.Usuario usuario)
        //{
        //    ML.Result resultLINQ = new ML.Result();

        //    try
        //    {
        //        using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
        //        {
        //            DL.Usuario usuarioDL = new DL.Usuario);

        //            usuarioDL.UserName = usuario.userName;
        //            usuarioDL.Nombre= usuario.nombre;
        //            usuarioDL.ApellidoPaterno = usuario.apellidoPaterno;
        //            usuarioDL.ApellidoPaterno = usuario.apellidoMaterno;
        //            usuarioDL.Email= usuario.email;
        //            usuarioDL.Password= usuario.password;
        //            usuarioDL.FechaNacimiento= usuario.fechaNacimiento;
        //            usuarioDL.Sexo = usuario.sexo.ToString();
        //            usuarioDL.Telefono = usuario.telefono;
        //            usuarioDL.Celular = usuario.celular;
        //            usuarioDL.CURP = usuario.curp;
        //            usuarioDL.idRol = usuario.usuarioRol.idRol;


        //            contex.Usuarios.Add(usuarioDL);

        //            var query = contex.SaveChanges();

        //            if (query > 0)
        //            {
        //                resultLINQ.Correct = true;
        //            }
        //            else
        //            {
        //                resultLINQ.Correct = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultLINQ.Ex = ex;
        //        resultLINQ.Correct = false;
        //        resultLINQ.ErrorMessage = ex.Message;
        //    }
        //    return resultLINQ;
        //}

        //public static ML.Result updateLINQ(ML.Usuario usuario)
        //{
        //    ML.Result resultLINQ = new ML.Result();

        //    try
        //    {
        //        using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
        //        {
        //            var query = (from usr in contex.usuarios
        //                         where usr.id_usuario == usuario.idUsuario
        //                         select usr).SingleOrDefault();

        //            if (query != null)
        //            {
        //                query.RFC = usuario.rfc;
        //                query.nombre = usuario.nombre;
        //                query.apelliidoP = usuario.apellidoPaterno;
        //                query.apellidoM = usuario.apellidoMaterno;
        //                query.fechaNac = usuario.fechaNacimiento;
        //                query.genero = usuario.genero.ToString();
        //                query.salario = usuario.salario;
        //                query.asegurado = usuario.asegurado;
        //                query.id_rol = usuario.usuarioRol.idRol;

        //                contex.SaveChanges();
        //                resultLINQ.Correct = true;

        //            }
        //            else
        //            {
        //                resultLINQ.Correct = false;
        //                resultLINQ.ErrorMessage = "No se encontro el usuario " + usuario.idUsuario;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        resultLINQ.Ex = ex;
        //        resultLINQ.Correct = false;
        //        resultLINQ.ErrorMessage = ex.Message;

        //    }
        //    return resultLINQ;

        //}

        //public static ML.Result deleteLINQ(ML.Usuario usuario)
        //{
        //    ML.Result resultLINQ = new ML.Result();

        //    try
        //    {
        //        using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
        //        {
        //            var query = (from usr in contex.usuarios
        //                         where usr.id_usuario == usuario.idUsuario
        //                         select usr).FirstOrDefault();

        //            contex.usuarios.Remove(query);
        //            contex.SaveChanges();
        //            resultLINQ.Correct = true;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        resultLINQ.Ex = ex;
        //        resultLINQ.Correct = false;
        //        resultLINQ.ErrorMessage = ex.Message;
        //    }
        //    return resultLINQ;
        //}

        //public static ML.Result usuarioGetAllLINQ()
        //{
        //    ML.Result resultLINQ = new ML.Result();

        //    try
        //    {
        //        using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
        //        {
        //            var query = (from usuarioRol in contex.usuarios
        //                         join usuario in contex.usuarios on usuarioRol.id_rol equals usuario.id_rol
        //                         join urol in contex.rols on usuarioRol.rol.descripcion equals urol.descripcion
        //                         where usuarioRol.id_usuario == usuario.id_usuario
        //                         where usuarioRol.id_rol == urol.id_rol
        //                         select new
        //                         {
        //                             idUsuario = usuario.id_usuario,
        //                             rfcUsuario = usuario.RFC,
        //                             nombreUsuario = usuario.nombre,
        //                             apellidoPaterno = usuario.apelliidoP,
        //                             apellidoMaterno = usuario.apellidoM,
        //                             usuarioFechaN = usuario.fechaNac,
        //                             usuarioGen = usuario.genero,
        //                             usuarioSal = usuario.salario,
        //                             usuarioAse = usuario.asegurado,
        //                             idRol = urol.id_rol,
        //                             nombreRol = urol.descripcion
        //                         });
        //            resultLINQ.Objects = new List<object>();

        //            if (query != null && query.ToList().Count > 0)
        //            {
        //                foreach (var objetousuario in query)
        //                {
        //                    ML.Usuario usuario = new ML.Usuario();
        //                    usuario.idUsuario = objetousuario.idUsuario;
        //                    usuario.rfc = objetousuario.rfcUsuario;
        //                    usuario.nombre = objetousuario.nombreUsuario;
        //                    usuario.apellidoPaterno = objetousuario.apellidoPaterno;
        //                    usuario.apellidoMaterno = objetousuario.apellidoMaterno;
        //                    usuario.fechaNacimiento = DateTime.Parse(objetousuario.usuarioFechaN.ToString());
        //                    usuario.genero = char.Parse(objetousuario.usuarioGen.ToString());
        //                    usuario.salario = float.Parse(objetousuario.usuarioSal.ToString());
        //                    usuario.asegurado = bool.Parse(objetousuario.usuarioAse.ToString());

        //                    //INICIALIZAR PROPIEDAD DE NAVEGACION
        //                    usuario.usuarioRol = new ML.Rol();
        //                    usuario.usuarioRol.idRol = objetousuario.idRol;
        //                    usuario.usuarioRol.descripcion = objetousuario.nombreRol;

        //                    resultLINQ.Objects.Add(usuario);
        //                }
        //                resultLINQ.Correct = true;
        //            }
        //            else
        //            {
        //                resultLINQ.Correct = false;
        //                resultLINQ.ErrorMessage = "No se encontrar registros";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultLINQ.Ex = ex;
        //        resultLINQ.Correct = false;
        //        resultLINQ.ErrorMessage = ex.Message;
        //    }
        //    return resultLINQ;
        //}

        //public static ML.Result usuarioGetByIdLINQ(ML.Usuario usuarioLINQID)
        //{
        //    ML.Result resultLINQ = new ML.Result();
        //    try
        //    {
        //        using (DL.JRodriguezProgramacionNcapasEntities contex = new JRodriguezProgramacionNcapasEntities())
        //        {
        //            var query = (from usuarioRol in contex.usuarios
        //                         join usuario in contex.usuarios on usuarioRol.id_rol equals usuario.id_rol
        //                         join urol in contex.rols on usuarioRol.rol.descripcion equals urol.descripcion
        //                         where usuarioRol.id_usuario == usuarioLINQID.idUsuario
        //                         where usuarioRol.id_rol == urol.id_rol
        //                         select new
        //                         {
        //                             idUsuario = usuario.id_usuario,
        //                             rfcUsuario = usuario.RFC,
        //                             nombreUsuario = usuario.nombre,
        //                             apellidoPaterno = usuario.apelliidoP,
        //                             apellidoMaterno = usuario.apellidoM,
        //                             usuarioFechaN = usuario.fechaNac,
        //                             usuarioGen = usuario.genero,
        //                             usuarioSal = usuario.salario,
        //                             usuarioAse = usuario.asegurado,
        //                             idRol = urol.id_rol,
        //                             nombreRol = urol.descripcion
        //                         }).FirstOrDefault();

        //            ML.Usuario usuarioLINQ = new ML.Usuario();

        //            usuarioLINQ.idUsuario = query.idUsuario;
        //            usuarioLINQ.rfc = query.rfcUsuario;
        //            usuarioLINQ.nombre = query.nombreUsuario;
        //            usuarioLINQ.apellidoPaterno = query.apellidoPaterno;
        //            usuarioLINQ.apellidoMaterno = query.apellidoMaterno;
        //            usuarioLINQ.fechaNacimiento = DateTime.Parse(query.usuarioFechaN.ToString());
        //            usuarioLINQ.genero = char.Parse(query.usuarioGen.ToString());
        //            usuarioLINQ.salario = float.Parse(query.usuarioSal.ToString());
        //            usuarioLINQ.asegurado = bool.Parse(query.usuarioAse.ToString());

        //            //INSTACIAR PROPIEDDAD DE NAVEGACION
        //            usuarioLINQ.usuarioRol = new Rol();
        //            usuarioLINQ.usuarioRol.idRol = query.idRol;
        //            usuarioLINQ.usuarioRol.descripcion = query.nombreRol;

        //            resultLINQ.Object= usuarioLINQ;
        //            resultLINQ.Correct = true;

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        resultLINQ.Ex = ex;
        //        resultLINQ.Correct = false;
        //        resultLINQ.ErrorMessage = ex.Message;
        //    }
        //    return resultLINQ;
        //}

    }
}
