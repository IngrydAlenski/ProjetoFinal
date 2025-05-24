using APIProjetoFinal.DTO;
using APIProjetoFinal.Interface;
using APIProjetoFinal.Models;
using APIProjetoFinal.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace APIProjetoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpPost]
        public IActionResult Cadastrar(CadastroNotaDTO notaDTO)
        {
            _notaRepository.Cadastrar(notaDTO);
            return Created();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, AtualizarNotaDTO nota)
        {
            try //Se encontrar o produto
            {
                //_produtoRepository (acessar o context/banco de dados)
                //Editar (id) editar o produto pelo id
                _notaRepository.Atualizar(id, nota);
                // Retornar 200
                return Ok(nota);
            }
            //Caso dar erro ou nao encontrao o produto
            catch (Exception ex)
            {
                return NotFound("Nota nao encontrado");
            }
        }

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
