using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Departamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Departamento.svc or Departamento.svc.cs at the Solution Explorer and start debugging.
    public class Departamento : IDepartamento
    {
        public ML.Result Add(ML.Departamento departamento)
        {
            ML.Result resultAdd = BL.Departamento.DepartamentoAdd(departamento);

            if (resultAdd.Correct)
            {
                return resultAdd;
            }
            else
            {
                return null;
            }
        }

        public ML.Result Update(ML.Departamento departamento)
        {
            ML.Result resultUpdate = BL.Departamento.DepartamentoUpdate(departamento);

            if (resultUpdate.Correct)
            {
                return resultUpdate;
            }
            else
            {
                return null;
            }
        }

        public ML.Result Delete(int idDepartamento)
        {
            ML.Departamento departamento = new ML.Departamento();
            departamento.idDepartamento = idDepartamento;

            ML.Result resultDelete = BL.Departamento.DepartamentoDelete(idDepartamento);

            if (resultDelete.Correct)
            {
                return resultDelete;
            }
            else
            {
                return null;
            }
        }

        public ML.Result GetAll()
        {
            ML.Result result = BL.Departamento.DepartamentoGetAll();

            if (result.Correct)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public ML.Result GetById(int idDepartamento)
        {
            ML.Departamento departamento = new ML.Departamento();

            departamento.idDepartamento = idDepartamento;

            ML.Result restulId = BL.Departamento.DepartamentoGetById(idDepartamento);

            if (restulId.Correct)
            {
                return restulId;
            }
            else
            {
                return null;
            }
        }
    }
}
