using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TiendaPrcatica.Controllers;
using TiendaPrcatica.Models;
using TiendaPrcatica.Repository;

namespace TiendaTestProyect.Controller
{
    public class ProductControllerTest
    {
        [Test]
        public void IndexCorrecto()
        {
            var mock = new Mock<IProductoRepository>();
                mock.Setup(o=>o.GetListId(1, "Product")).Returns(new List<Producto>() { new Producto { Id = 1, Name = "papa" } });
            var mockAuth = new Mock<IAuthRepository>();
                mockAuth.Setup(o => o.aunteticacion("admin")).Returns(new Usuario { Id = 1, Username = "admin" });

            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
                mockClaimsPrincipal.Setup(x => x.Claims).Returns(new List<Claim> { new Claim(ClaimTypes.Name, "admin") });
            //Para crear el http context creamos un mock de la clase http context (mockContext)
            var mockContext = new Mock<HttpContext>();//Configurando user el cual usa htppcontext
                mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var controller = new ProductController(mock.Object, mockAuth.Object);

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
            var result = (ViewResult)controller.Index("Product");
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);//Modelo  enviado hacia la vsita no es nulo
        }


        [Test]
        public void CreatePostInCorrectoProductoVacio()
        {
            var mock = new Mock<IProductoRepository>();
                mock.Setup(o=>o.Add(new Producto()));
            var mockAuth = new Mock<IAuthRepository>();
                mockAuth.Setup(o => o.aunteticacion("admin")).Returns(new Usuario { Id = 1, Username = "admin" });

            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
                mockClaimsPrincipal.Setup(x => x.Claims).Returns(new List<Claim> { new Claim(ClaimTypes.Name, "admin") });
            //Para crear el http context creamos un mock de la clase http context (mockContext)
            var mockContext = new Mock<HttpContext>();//Configurando user el cual usa htppcontext
                mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var controller = new ProductController(mock.Object, mockAuth.Object);

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
            var result =controller.Create(new Producto());
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }



        [Test]
        public void CreatePostInCorrectoNombreRepetido()
        {
            var mock = new Mock<IProductoRepository>();
                
                mock.Setup(o=>o.contarPorNombre(new Producto() {Id=1, Name="leche"})).Returns(1);
                mock.Setup(o => o.Add(new Producto()));

            var mockAuth = new Mock<IAuthRepository>();
                mockAuth.Setup(o => o.aunteticacion("admin")).Returns(new Usuario { Id = 1, Username = "admin" });

            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
                mockClaimsPrincipal.Setup(x => x.Claims).Returns(new List<Claim> { new Claim(ClaimTypes.Name, "admin") });
            //Para crear el http context creamos un mock de la clase http context (mockContext)
            var mockContext = new Mock<HttpContext>();//Configurando user el cual usa htppcontext
                mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var controller = new ProductController(mock.Object, mockAuth.Object);

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
            var result = controller.Create(new Producto());
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void CreatePostInCorrectoFechaProduccionMayorAHoy()
        {
            string dateInput = "Jan 1, 2023";
            var fechaProd = DateTime.Parse(dateInput);

            string dateInpu = "Jan 1, 2023";
            var fechaVenc = DateTime.Parse(dateInpu);


            var mock = new Mock<IProductoRepository>();


            var mockAuth = new Mock<IAuthRepository>();
                mockAuth.Setup(o => o.aunteticacion("admin")).Returns(new Usuario { Id = 1, Username = "admin" });

            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
                mockClaimsPrincipal.Setup(x => x.Claims).Returns(new List<Claim> { new Claim(ClaimTypes.Name, "admin") });
            //Para crear el http context creamos un mock de la clase http context (mockContext)
            var mockContext = new Mock<HttpContext>();//Configurando user el cual usa htppcontext
                mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var controller = new ProductController(mock.Object, mockAuth.Object);

                controller.ControllerContext = new ControllerContext()
                {
                    HttpContext = mockContext.Object
                };
            var result = controller.Create(new Producto() { Id = 1, Name = "Leche", Stock = 10, Price = 12, DateProd = fechaProd, DateVenc = fechaVenc });
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void CreatePostInCorrectoFechaVencimientoMenorAHoy()
        {
            string dateInput = "Jan 1, 2019";
            var fechaProd = DateTime.Parse(dateInput);

            string dateInpu = "Jan 1, 2022";
            var fechaVenc = DateTime.Parse(dateInpu);


            var mock = new Mock<IProductoRepository>();


            var mockAuth = new Mock<IAuthRepository>();
            mockAuth.Setup(o => o.aunteticacion("admin")).Returns(new Usuario { Id = 1, Username = "admin" });

            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(x => x.Claims).Returns(new List<Claim> { new Claim(ClaimTypes.Name, "admin") });
            //Para crear el http context creamos un mock de la clase http context (mockContext)
            var mockContext = new Mock<HttpContext>();//Configurando user el cual usa htppcontext
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var controller = new ProductController(mock.Object, mockAuth.Object);

            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = mockContext.Object
            };
            var result = controller.Create(new Producto() { Id = 1, Name = "Leche", Stock = 10, Price = 12, DateProd = fechaProd, DateVenc = fechaVenc });
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }

        [Test]
        public void CreatePostCorrectoDatosCompletados()
        {
            string dateInput = "Jan 1, 2019";
            var fechaProd = DateTime.Parse(dateInput);

            string dateInpu = "Jan 1, 2023";
            var fechaVenc = DateTime.Parse(dateInpu);


            var mock = new Mock<IProductoRepository>();

            //craer Mock para Tempdata
            var httpContext = new DefaultHttpContext();
            var tempData = new TempDataDictionary(httpContext, Mock.Of<ITempDataProvider>());
                tempData["SuccessMessage"] = "admin";

            var mockAuth = new Mock<IAuthRepository>();
            mockAuth.Setup(o => o.aunteticacion("admin")).Returns(new Usuario { Id = 1, Username = "admin" });

            var mockClaimsPrincipal = new Mock<ClaimsPrincipal>();
            mockClaimsPrincipal.Setup(x => x.Claims).Returns(new List<Claim> { new Claim(ClaimTypes.Name, "admin") });
            //Para crear el http context creamos un mock de la clase http context (mockContext)
            var mockContext = new Mock<HttpContext>();//Configurando user el cual usa htppcontext
            mockContext.Setup(o => o.User).Returns(mockClaimsPrincipal.Object);

            var controller = new ProductController(mock.Object, mockAuth.Object)
                {
                    TempData = tempData
                };
                controller.ControllerContext = new ControllerContext()
                {
                    HttpContext = mockContext.Object
                };
                
            var result = controller.Create(new Producto() { Id = 1, Name = "Leche", Stock = 10, Price = 12, DateProd = fechaProd, DateVenc = fechaVenc });
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RedirectToActionResult>(result);
        }
    }

}
