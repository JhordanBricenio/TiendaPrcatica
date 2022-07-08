using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaPrcatica.DB;
using TiendaPrcatica.Models;
using TiendaPrcatica.Repository;
using TiendaTestProyect.Helpers;

namespace TiendaTestProyect.Repository
{
    public class ProductRepositoryTest
    {
        private static IQueryable<Producto>? data;
        [SetUp]
        public void Setup()
        {
            data = new List<Producto>
            {
                new Producto { Id = 1, Name = "Product 01", IdUsuario=1 },
                new Producto { Id = 2, Name = "Product 02" , IdUsuario=3},
                new Producto { Id = 2, Name = "product 02", IdUsuario=1 },
                new Producto { Id = 2, Name = "product 02", IdUsuario=2 },
                new Producto { Id = 2, Name = "product 02", IdUsuario=1 },

            }.AsQueryable();
        }
        [Test]
        public void ObtenerPorFiltroTestCaso01()
        {
            var mockBdSetProduct = new MockDbSet<Producto>(data);

            var mockBd = new Mock<DbEntities>();
            mockBd.Setup(x => x.Productos).Returns(mockBdSetProduct.Object);

            var productRepo = new ProductRepository(mockBd.Object);

            var result = productRepo.GetList("Product");

            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void ObtenerTodosTestCaso01()
        {
            var mockBdSetProduct = new MockDbSet<Producto>(data);

            var mockBd = new Mock<DbEntities>();
            mockBd.Setup(x => x.Productos).Returns(mockBdSetProduct.Object);

            var productRepo = new ProductRepository(mockBd.Object);

            var result = productRepo.GetList("");

            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void ObtenerPorIdTestCaso01()
        {
            var mockBdSetProduct = new MockDbSet<Producto>(data);

            var mockBd = new Mock<DbEntities>();
            mockBd.Setup(x => x.Productos).Returns(mockBdSetProduct.Object);

            var productRepo = new ProductRepository(mockBd.Object);

            var result = productRepo.GetProductById(1);

            Assert.IsNotNull(result);
        }

        [Test]
        public void ObtenerProductosPorUsuarioSinFiltroTestCaso01()
        {
            var mockBdSetProduct = new MockDbSet<Producto>(data);

            var mockBd = new Mock<DbEntities>();
            mockBd.Setup(x => x.Productos).Returns(mockBdSetProduct.Object);

            var productRepo = new ProductRepository(mockBd.Object);

            var result = productRepo.GetListId(1, "");

            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void ObtenerProductosPorUsuarioConnFiltroTestCaso01()
        {
            var mockBdSetProduct = new MockDbSet<Producto>(data);

            var mockBd = new Mock<DbEntities>();
            mockBd.Setup(x => x.Productos).Returns(mockBdSetProduct.Object);

            var productRepo = new ProductRepository(mockBd.Object);

            var result = productRepo.GetListId(1, "product");

            Assert.AreEqual(2, result.Count);
        }
    }
}
