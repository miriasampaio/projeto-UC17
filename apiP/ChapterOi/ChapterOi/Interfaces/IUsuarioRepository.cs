using ChapterOi.Models;
using System.ComponentModel.DataAnnotations;

namespace ChapterOi.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> Listar();

        Usuario BuscarPorId(int id);

        void Cadastrar(Usuario novoUsuario);

        void Atualizar(int id, Usuario usuario);

        void Deletar(int id);

        Usuario Login(string Email,string Senha);
    }
}
