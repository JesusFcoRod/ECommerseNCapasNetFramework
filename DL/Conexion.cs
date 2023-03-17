using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        //Obtener la cadena de conexion a la base de datos
        public static string GetConnectionString()
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["JRodriguezProgramacionNCapas"].ConnectionString.ToString();
        }
    }
}
