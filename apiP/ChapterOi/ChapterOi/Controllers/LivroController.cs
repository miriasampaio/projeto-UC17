using ChapterOi.Models;
using ChapterOi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterOi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LivroController : ControllerBase
    {
        private readonly LivroRepository _livroRepository;

        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        [HttpGet]

        public IActionResult ler()
        {
            try
            {
                return Ok(_livroRepository.Listar());
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        [HttpGet("{id}")]

        public IActionResult BuscaId(int id)
        {
            try
            {
                Livro livrobuscado = _livroRepository.BuscarId(id);

                if (livrobuscado == null)
                {
                    return NotFound("Não encontrado!");
                }
                return Ok(livrobuscado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Livro l)
        {
            try
            {
                _livroRepository.Cadastro(l);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]

        public IActionResult deletar(int id)
        {
            try
            {
                _livroRepository.deletar(id);
                return Ok("Livro removido");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]

        public IActionResult alterar(int id, Livro l)
        {
            try
            {
                _livroRepository.alterar(id, l);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
