using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Producto" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Producto.svc or Producto.svc.cs at the Solution Explorer and start debugging.
    public class Producto : IProducto
    {

        public ML.Result Add(ML.Producto producto)
        {
            ML.Result resultAdd = BL.Producto.Add(producto);

            if (resultAdd.Correct)
            {
                return resultAdd;
            }
            else
            {
                return null;
            }
        }
        public ML.Result Update(ML.Producto producto)
        {
            ML.Result resultUpdate= BL.Producto.Update(producto);

            if (resultUpdate.Correct)
            {
                return resultUpdate;
            }
            else
            {
                return null;
            }
        }

        public ML.Result Delete (int idProducto)
        {
            ML.Producto producto = new ML.Producto();
            producto.IdProducto= idProducto;

            ML.Result resultDelete = BL.Producto.Delete(idProducto);

            if (resultDelete.Correct)
            {
                return resultDelete;
            }
            else
            {
                return null;
            }
        }
        public ML.Result GetAll(ML.Producto producto)
        {
            ML.Result resultAll = BL.Producto.GetAll(producto);

            if(resultAll.Correct)
            {
                return resultAll;
            }
            else
            {
                return null;
            }
        }

        public ML.Result GetById(int idProducto)
        {
            ML.Producto producto = new ML.Producto();
            producto.IdProducto = idProducto;

            ML.Result resultId =BL.Producto.GetById(idProducto);

            if (resultId.Correct)
            {
                return resultId;
            }
            else
            {
                return null;
            }
        }
    }
}
