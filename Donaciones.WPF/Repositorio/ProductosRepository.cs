using System.Collections.Generic;
using System.Linq;

namespace Donaciones.WPF {
    public class ProductosRepository : IProductosRepository {
        private readonly DonacionesDBEntities context;

        public ProductosRepository(DonacionesDBEntities context) {
            this.context = context;
        }

        public Productos GetProducto(int productoID) {
            return context.Productos.Find(productoID);
        }

        public Productos GetFirstProducto() {
            return context.Productos.FirstOrDefault();
        }

        public Productos GetLastProducto() {
            var result = from p in context.Productos
                         orderby p.ProductoID descending
                         select new  {
                             p.ProductoID
                         };
            
            return (!result.Any()) ?null:context.Productos.Find((int)result.FirstOrDefault().ProductoID);
        }

        public IEnumerable<Productos> GetProductos() {
            return context.Productos.ToList();
        }

        public void UpdateProducto(Productos producto) {
            Productos productos = context.Productos.Find(producto.ProductoID);
            if (productos == null) {
                context.Productos.Add(producto);
            } else {
                context.Entry(producto).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();
        }

        public int NextProductoConsecutivo() {
            return context.Productos.Count() + 1;
        }

        public Productos GetNextProducto(int productoID) {
           List<Productos> productos = GetProductos().ToList();
            bool existeproducto = false;
            int nextProductID = 0;
            foreach (Productos product in productos) {
                if (!existeproducto) {
                    if (product.ProductoID == productoID) {
                        existeproducto = true;
                    }
                } else {
                    nextProductID = product.ProductoID;
                    break;
                }
            }
            return  context.Productos.Find(nextProductID);
        }

        public Productos GetPreviousProducto(int productoID) {
            List<Productos> productos = GetProductos().ToList();
            int previusProductID = 0;
            foreach (Productos product in productos) {
                if (product.ProductoID == productoID) {
                    break;
                } else {
                    previusProductID = product.ProductoID;
                }
            }
            return context.Productos.Find(previusProductID);
        }

        public bool DeleteProducto(int productoID) {
            Productos p = context.Productos.Find(productoID);
            context.Productos.Remove(p);
            return context.SaveChanges() > 0;
        }
    }
}
