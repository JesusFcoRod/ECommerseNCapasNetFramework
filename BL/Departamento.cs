using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Departamento
    {
        public static ML.Result DepartamentoAdd(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
                {
                    var query = contex.DepartamentoAdd(departamento.nombre, departamento.Area.idArea);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result DepartamentoUpdate(ML.Departamento departamento)
        {
            ML.Result resultUpdate = new ML.Result();
            try
            {
                using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
                {
                    var query = contex.DepartamentoUpdate(departamento.nombre, departamento.Area.idArea,
                        departamento.idDepartamento);

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

        public static ML.Result DepartamentoDelete(int idDepartamento)
        {
            ML.Result resultDelete = new ML.Result();
            try
            {
                using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
                {
                    var query = contex.DepartamenteDelete(idDepartamento);
                    if (query > 0)
                    {
                        resultDelete.Correct = true;
                    }
                    else { resultDelete.Correct = false; }
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

        public static ML.Result DepartamentoGetAll()
        {
            ML.Result resultGetAll = new ML.Result();

            try
            {
                using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
                {
                    var query = contex.DepartamentoGetAll().ToList();

                    resultGetAll.Objects = new List<object>();

                    foreach (var objDepa in query)
                    {
                        ML.Departamento departamento = new ML.Departamento();
                        departamento.idDepartamento = objDepa.idDepartamento;
                        departamento.nombre = objDepa.Nombre;

                        departamento.Area = new ML.Area();

                        departamento.Area.idArea = objDepa.IDArea.Value;
                        departamento.Area.nombre = objDepa.AreaNombre;

                        resultGetAll.Objects.Add(departamento);

                    }
                    resultGetAll.Correct = true;
                }
            }
            catch(Exception ex)
            {
                resultGetAll.Ex = ex;
                resultGetAll.Correct = false;
                resultGetAll.ErrorMessage = ex.Message;
            }
            return resultGetAll;
        }

        public static ML.Result DepartamentoGetById(int idDepartamento)
        {
            ML.Result resultGI = new ML.Result();

            try
            {
                using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
                {
                    var query = contex.DepartamentoGetByID(idDepartamento).FirstOrDefault();

                    ML.Departamento departamentoG = new ML.Departamento();

                    departamentoG.idDepartamento = query.idDepartamento;
                    departamentoG.nombre = query.Nombre;

                    departamentoG.Area = new ML.Area();

                    departamentoG.Area.idArea = query.IDArea.Value;
                    departamentoG.Area.nombre = query.AreaNombre;

                    resultGI.Object = departamentoG;

                    resultGI.Correct = true;
                }

            }
            catch(Exception ex)
            {
                resultGI.Ex = ex;
                resultGI.Correct = false;
                resultGI.ErrorMessage = ex.Message;
            }
            return resultGI;
        }
    }
}
