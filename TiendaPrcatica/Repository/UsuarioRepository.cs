using TiendaPrcatica.DB;
using TiendaPrcatica.Models;

namespace TiendaPrcatica.Repository
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetUsers();

        void Add(Usuario nota);

        void Update(int id, Usuario nota);

        void Delete(int id);

        Usuario GetUsuarioById(int id);

        int contarPorNombre(Usuario nota);



    }
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DbEntities dbEntities;
        public UsuarioRepository(DbEntities dbEntities)
        {
            this.dbEntities = dbEntities;

        }
        public void Add(Usuario usuario)
        {
            dbEntities.Add(usuario);
            dbEntities.SaveChanges();
        }

        public int contarPorNombre(Usuario nota)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Usuario> GetUsers()
        {
            return dbEntities.Usuarios.ToList();
        }

        public Usuario GetUsuarioById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Usuario nota)
        {
            throw new NotImplementedException();
        }
    }
}
