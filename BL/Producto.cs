using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
                {
                    var query = contex.ProductoAdd(producto.Nombre,producto.PrecioUnitario, producto.Stock,producto.Proveedor.IdProveedor,producto.Departamento.idDepartamento,producto.Descripcion,producto.Imagen);
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

        public static ML.Result GetAll(ML.Producto producto)
        {
            ML.Result resultAll = new ML.Result();

            try
            {
                using (DL.JRodriguezProgramacionNcapasEntities contex = new DL.JRodriguezProgramacionNcapasEntities())
                {
                    var query = contex.ProductoGetAll(producto.Departamento.idDepartamento).ToList();

                    resultAll.Objects = new List<object>();

                    foreach (var objProd in query)
                    {
                        producto = new ML.Producto();

                        producto.IdProducto = objProd.idProducto;
                        producto.Nombre = objProd.Nombre;
                        producto.PrecioUnitario = objProd.PrecioUnitario;
                        producto.Stock = objProd.Stock;

                        producto.Proveedor = new ML.Proveedor();
                        producto.Proveedor.IdProveedor = objProd.idProveedor.Value;

                        producto.Departamento = new ML.Departamento();
                        producto.Departamento.idDepartamento = objProd.idDepartamento.Value;
                        producto.Departamento.nombre = objProd.DepartamentoNombre;

                        producto.Descripcion = objProd.Descripcion;

                        producto.Imagen = objProd.Imagen;

                        resultAll.Objects.Add(producto);

                        resultAll.Correct = true;
                    }
                }
                }
            catch (Exception ex)
            {
                resultAll.Ex = ex;
                resultAll.Correct = false;
                resultAll.ErrorMessage = ex.Message;
            }
            return resultAll;
        }
    }
}
