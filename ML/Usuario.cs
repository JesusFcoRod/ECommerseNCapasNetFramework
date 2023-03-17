using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        //Propiedades de la tabla o atributos
        public int idUsuario { get; set; }
        public string userName { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string fechaNacimiento { get; set; }
        public string sexo { get; set; }
        public string telefono { get; set; }
        public string celular { get; set; }
        public string curp { get; set; }

        public string nombreCompleto { get; set; }
        public string direccionCompleta { get; set; }
        public string contacto { get; set; }

        public string nombreRol { get; set; }
        public string Imagen { get; set; }

        //Propiedades de navegacion para FK 
        public ML.Rol usuarioRol { get; set; }
        public ML.Direccion direccion { get; set; }

        //LISTA PARA EXTRAER LOS OBJETOS Y MOSTRAR EN TABAL WEB
        public List<object> Usuarios { get; set; }


    }
}
