using System.Collections.Generic;

namespace Donaciones.WPF {
    public interface IProductosRepository {
        Productos GetProducto(int productoID);
        Productos GetFirstProducto();
        Productos GetNextProducto(int productoID);
        Productos GetPreviousProducto(int productoID);
        IEnumerable<Productos> GetProductos();
        Productos GetLastProducto();
        void UpdateProducto(Productos producto);
        int NextProductoConsecutivo();
        bool DeleteProducto(int productoID);
    }
}
