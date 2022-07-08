using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaPrcatica.Models;
using TiendaPrcatica.Repository;

namespace TiendaPrcatica.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsuarioRepository usuarioRepository;
        public UserController(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }
        public ActionResult Index()
        {
          var users=  usuarioRepository.GetUsers();
            return View(users);
        }


        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }


        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            usuarioRepository.Add(usuario);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id,Usuario usuario )
        {
            return View();
        }


        public ActionResult Delete(int id)
        {
            return View();
        }


    }
}
