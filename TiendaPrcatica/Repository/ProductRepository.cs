using TiendaPrcatica.DB;
using TiendaPrcatica.Models;

namespace TiendaPrcatica.Repository
{
    public interface IProductoRepository
    {
        List<Producto> GetList(String filtro);

        void Add(Producto nota);

        void Update(int id, Producto nota);

        void Delete(int id);

        Producto GetProductById(int id);

        int contarPorNombre(Producto nota);
        List<Producto> GetListId(int id, String? filtro);

    }
    public class ProductRepository : IProductoRepository
    {
        private readonly DbEntities _db;
        public ProductRepository(DbEntities db)
        {
            this._db = db;
        }
        public void Add(Producto producto)
        {
            _db.Productos.Add(producto);
            _db.SaveChanges();
        }

        public int contarPorNombre(Producto producto)
        {
            return _db.Productos.Count(o => o.Name == producto.Name);
        }

        public void Delete(int id)
        {
            var products = GetProductById(id);
            _db.Productos.Remove(products);
            _db.SaveChanges();
        }

        public List<Producto> GetList(String? filtro)
        {
            
            var query= _db.Productos.ToList();
            if (filtro != null && filtro.Length > 0)
            {
                filtro = filtro.Replace('.', ' ');
                query = query.Where(o => o.Name.Contains(filtro) || o.Price.ToString().Contains(filtro)).ToList();
            }
            return query;
        }

        public Producto GetProductById(int id)
        {
            return _db.Productos.First(o => o.Id == id);
        }

        public void Update(int id, Producto producto)
        {
            var product = GetProductById(id);
            product.Name = producto.Name;
            product.Stock = producto.Stock;
            product.Price = producto.Price;
            product.DateProd = producto.DateProd;
            product.DateVenc = producto.DateVenc;
            _db.SaveChanges();
        }

        public List<Producto> GetListId(int id,String? filtro)
        {

            var query = _db.Productos.Where(o=>o.IdUsuario==id).ToList();
            if (filtro != null && filtro.Length > 0)
            {
                query = query.Where(o => o.Name.Contains(filtro) || o.Price.ToString().Contains(filtro)).ToList();
            }
            return query;
        }
    }
}
