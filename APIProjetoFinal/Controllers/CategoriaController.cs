using APIProjetoFinal.Context;
using APIProjetoFinal.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIProjetoFinal.Interface;
using APIProjetoFinal.Models;

namespace APIProjetoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaRepository _categoriaRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet("/ListarTodasCategorias")]
        public IActionResult ListarTodos()
        {
            return Ok(_categoriaRepository.ListarTodos());
        }

        [HttpGet("/BuscarCategoriaPorNome/{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            Categoria categoria = _categoriaRepository.BuscarPorNome(nome);

            if (categoria == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(categoria);
            }

        }

        [HttpPut("/AtualizarCategoria/{id}")]
        public IActionResult Atualizar(int id, Categoria categ)
        {
            try 
            {

                _categoriaRepository.Atualizar(id, categ);

                return Ok(categ);
            }

            catch (Exception ex)
            {
                return NotFound("Categoria não encontrada");
            }
        }

        [HttpDelete("/DeletarCategoria/{id}")]
        public IActionResult Deletar(int id) 
        {
            try 
            {
                _categoriaRepository.Deletar(id);

                return NoContent();
            }

            catch (Exception ex)
            {
                return NotFound("Categoria nao encontrado");
            }
        }

        [HttpPost("/CadastrarCategoria/")]
        public IActionResult CadastrarPedido(Categoria categoria)
        {
            _categoriaRepository.Cadastrar(categoria);
            return Created();
        }

    }
}
