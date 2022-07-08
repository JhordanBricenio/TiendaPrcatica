using TiendaPrcatica.DB;
using TiendaPrcatica.Models;

namespace TiendaPrcatica.Repository
{
    public interface IAuthRepository
    {
        Usuario aunteticacion(string username);
        bool aunteticacionCokie(string username, string password);

        Usuario aunteticacionCok(string username, string password);



    }
    public class AuthRepository : IAuthRepository
    {
        private readonly DbEntities dbEntities;

        public AuthRepository(DbEntities dbEntities)
        {
            this.dbEntities = dbEntities;
        }
        public Usuario aunteticacion(string username)
        {
            return dbEntities.Usuarios.First(o => o.Username == username);
        }

        public Usuario aunteticacionCok(string username, string password)
        {
            throw new NotImplementedException();
        }

        public bool aunteticacionCokie(string username, string password)
        {
            return dbEntities.Usuarios.Any(o => o.Username == username && o.Password == password);
        }
    }
}
