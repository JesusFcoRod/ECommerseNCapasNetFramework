using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estado
    { 
        public static ML.Result EstadoGetByIdPais(int idPais)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities ())
                {
                    var query = contex.EstadoGetByIdPais(idPais).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach ( var objeto in query)
                        {
                            ML.Estado estadoId = new ML.Estado();

                            estadoId.idEstado = objeto.idEstado;
                            estadoId.nombre = objeto.Nombre;

                            result.Objects.Add(estadoId);
                        }
                    }
                }
                result.Correct = true;

            }
            catch (Exception ex)
            {
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }
    }
}
