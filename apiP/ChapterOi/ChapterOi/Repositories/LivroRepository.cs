using ChapterOi.Contexts;
using ChapterOi.Models;

namespace ChapterOi.Repositories
{
    public class LivroRepository
    {
        private readonly SqlContext _context;
        public LivroRepository(SqlContext context)
        {
            _context = context;
        }

        public List<Livro> Listar()
        {
            return _context.Livros.ToList();
        }

        public Livro BuscarId(int id)
        {
            return _context.Livros.Find(id);
        }

        public void Cadastro(Livro l)
        {
            _context.Livros.Add(l);
            _context.SaveChanges();
        }

        public void deletar(int id)
        {
            Livro l = _context.Livros.Find(id);
            _context.Livros.Remove(l);
            _context.SaveChanges();
        }

        public void alterar(int id, Livro l)
        {
            Livro livroBuscado = _context.Livros.Find(id);

            if (livroBuscado != null)
            {
                livroBuscado.Titulo = l.Titulo;
                livroBuscado.QuantidadePaginas = l.QuantidadePaginas;
                livroBuscado.Disponivel = l.Disponivel;
                _context.Livros.Update(livroBuscado);
                _context.SaveChanges();
            }
        }
    }
}
