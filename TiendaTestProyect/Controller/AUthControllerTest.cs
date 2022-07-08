using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaPrcatica.Controllers;
using TiendaPrcatica.Repository;

namespace TiendaTestProyect.Controller
{
    public class AUthControllerTest
    {
        [Test]
        public void LoginInCorrectoTest()
        {
            var mock = new Mock<IAuthRepository>();
                mock.Setup(o=>o.aunteticacionCokie("admin", "12345")).Returns(false);
            var mockProduct = new Mock<IProductoRepository>();

            var controller = new AuthController(mock.Object);
            var result = controller.Login("admin", "123");

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);

        }

    }
}
