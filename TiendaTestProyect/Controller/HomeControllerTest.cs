using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaPrcatica.Controllers;
using TiendaPrcatica.Models;
using TiendaPrcatica.Repository;

namespace TiendaTestProyect.Controller
{
    public class HomeControllerTest
    {
        [Test]
        public void IndexCorrecto()
        {
            var mock = new Mock<IProductoRepository>();
                mock.Setup(o=>o.GetList("Product")).Returns(new List<Producto> { new Producto() {Id=1, Name="papa" } });
            var mockUsuario= new Mock<IUsuarioRepository>();
            var controller = new HomeController(mock.Object, mockUsuario.Object);
            var result =(ViewResult) controller.Index("Product");
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);//Modelo  enviado hacia la vsita no es nulo
            Assert.IsInstanceOf<ViewResult>(result);
        }


    }
}
