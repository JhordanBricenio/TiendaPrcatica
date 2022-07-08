using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaPrcatica.Repository;

namespace TiendaPrcatica.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUsuarioRepository usuarioRepository;

        public HomeController(IProductoRepository productoRepository, IUsuarioRepository usuarioRepository)
        {
            this._productoRepository = productoRepository;
            this.usuarioRepository = usuarioRepository;

        }
        public ActionResult Index(String? filtro)
        {
            var productos = _productoRepository.GetList(filtro);
            ViewBag.Usuarios = usuarioRepository.GetUsers();
            return View(productos);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }



       
    }
}
