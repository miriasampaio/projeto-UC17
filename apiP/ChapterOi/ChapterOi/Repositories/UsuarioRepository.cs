using ChapterOi.Contexts;
using ChapterOi.Interfaces;
using ChapterOi.Models;

namespace ChapterOi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlContext _Context;

        public UsuarioRepository(SqlContext Context)
        {
            _Context = Context;
        }   

        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioEncontrado = _Context.Usuarios.Find(id);

            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Email = usuario.Email;
                usuarioEncontrado.Senha = usuario.Senha;
                usuarioEncontrado.Tipo = usuario.Tipo;

                _Context.Usuarios.Update(usuarioEncontrado);
                _Context.SaveChanges();
            }
        }

        public Usuario BuscarPorId(int id)
        {
            return _Context.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            _Context.Usuarios.Add(novoUsuario);
            _Context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuario = _Context.Usuarios.Find(id);

            _Context.Usuarios.Remove(usuario);
            _Context.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _Context.Usuarios.ToList();
        }

        public Usuario Login(string Email, string Senha)
        {
            return _Context.Usuarios.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);
        }
    }
}
