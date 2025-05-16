using APIProjetoFinal.Interface;
using APIProjetoFinal.Models;
using APIProjetoFinal.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProjetoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotaController : ControllerBase
    {
        private INotaRepository _notaRepository;
        public NotaController(INotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }


        [HttpGet("/ListarTodasNotas")]
        public IActionResult ListarTodos()
        {
            return Ok(_notaRepository.ListarTodos());
        }

        [HttpGet("/BuscarPorIdUsuario/{id}")]
        public IActionResult BuscarPorIdUsuario(int id)
        {
            Nota nota = _notaRepository.BuscarPorIdUsuario(id);

            if (nota == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(nota);
            }

        }

        [HttpGet("/BuscarNotaPorData/{date}")]
        public IActionResult BuscarNotaPorData(DateTime date)
        {
            Nota nota = _notaRepository.BuscarNotaPorData(date);

            if (nota == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(nota);
            }

        }


        //[HttpPut("/AtualizarCategoria/{id}")]
        //public IActionResult Atualizar(int id, Categoria categ)
        //{
        //    try
        //    {

        //        _categoriaRepository.Atualizar(id, categ);

        //        return Ok(categ);
        //    }

        //    catch (Exception ex)
        //    {
        //        return NotFound("Categoria não encontrada");
        //    }
        //}

        //[HttpDelete("/DeletarCategoria/{id}")]
        //public IActionResult Deletar(int id)
        //{
        //    try
        //    {
        //        _categoriaRepository.Deletar(id);

        //        return NoContent();
        //    }

        //    catch (Exception ex)
        //    {
        //        return NotFound("Categoria nao encontrado");
        //    }
        //}

        //[HttpPost("/CadastrarCategoria/")]
        //public IActionResult CadastrarPedido(Categoria categoria)
        //{
        //    _categoriaRepository.Cadastrar(categoria);
        //    return Created();
        //}


    }
}
