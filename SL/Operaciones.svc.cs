using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Operaciones" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Operaciones.svc or Operaciones.svc.cs at the Solution Explorer and start debugging.
    public class Operaciones : IOperaciones
    {
        public int SumarNumeros(int a, int b)
        {
            return a + b;
        }

        public int RestarNumeros(int a, int b)
        {
            return a - b;
        }

        public int MultiplicarNumeros(int a, int b)
        {
            return a * b;
        }

        public float DividirNumeros(float a, float b)
        {
            return a / b;
        }

    }
}
