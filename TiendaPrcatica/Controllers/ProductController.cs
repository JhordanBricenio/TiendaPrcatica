using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using TiendaPrcatica.Models;
using TiendaPrcatica.Repository;

namespace TiendaPrcatica.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IAuthRepository _authRepository;

        public ProductController(IProductoRepository productoRepository, IAuthRepository authRepository)
        {
            this._productoRepository = productoRepository;
            this._authRepository = authRepository;

        }

        public IActionResult Index(String? filtro)
        {
            var usuario = GetLoggerUser();
            var productos = _productoRepository.GetListId(usuario.Id, filtro);
            return View(productos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Producto producto)
        {
            var usuario = GetLoggerUser();
            producto.IdUsuario = usuario.Id;
            var cantidad = _productoRepository.contarPorNombre(producto);
            if (cantidad>0)
            {
                ModelState.AddModelError("Name", "Name no válido");
            }
            if (producto.DateProd.Date > DateTime.Now.Date)
            {
                ModelState.AddModelError("DateProd", "Fecha de Registro No válido");
            }
            if (producto.DateVenc.Date < DateTime.Now.Date)
            {
                ModelState.AddModelError("DateVenc", "Fecha de Registro No válido");
            }
            if (producto.Stock <= 0)
            {
                ModelState.AddModelError("Stock", "Stock no válido");
            }
            if (producto.Price<=0)
            {
                ModelState.AddModelError("Price", "Price no válido");
            }
            if (ModelState.IsValid)
            {
                _productoRepository.Add(producto);
                TempData["SuccessMessage"] = "Se agregó de forma correcta";
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var products = _productoRepository.GetProductById(id);
            return View(products);
        }
        [HttpPost]
        public IActionResult Update(int id, Producto producto)
        {
            var products = _productoRepository.GetProductById(id);
            if (producto.Stock <= 0)
            {
                ModelState.AddModelError("Stock", "Stock no válido");
            }
            if (producto.Price <= 0)
            {
                ModelState.AddModelError("Price", "Price no válido");
            }
            if (ModelState.IsValid)
            {
                _productoRepository.Update(id, producto);
                TempData["SuccessMessage"] = "Se editó de forma correcta";
                return RedirectToAction("Index");
            }
            return View(products);
        }

        public IActionResult Delete(int id)
        {
            _productoRepository.Delete(id);
            TempData["SuccessMessage"] = "Se eliminó de forma correcta";
            return RedirectToAction("Index");
        }


        public IActionResult Privacy()
        {
            return View();
        }
        private Usuario GetLoggerUser()
        {
            var claim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name);

            var username = claim.Value;
            return _authRepository.aunteticacion(username);
        }
    }
}