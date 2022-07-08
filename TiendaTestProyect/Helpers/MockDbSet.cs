using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaTestProyect.Helpers
{

    //Creando clase genérica para reutlizar codigo
    public class MockDbSet<T> : Mock<DbSet<T>> where T : class
    {
        //private Mock<DbSet<T>> mockDbset;
        public MockDbSet(IQueryable<T> data)
        {
            base.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            base.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            base.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            base.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        }

      /*  public Mock<DbSet<T>> Get()
        {
            return mockDbset;
        }
      */
    }
}
