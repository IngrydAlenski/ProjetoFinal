using APIProjetoFinal.Context;
using APIProjetoFinal.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using APIProjetoFinal.Interface;
using APIProjetoFinal.Models;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using APIProjetoFinal.DTO;
using APIProjetoFinal.Validators;

namespace APIProjetoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public IActionResult Atualizar(int id, CategoriaDTO categ)
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
        public IActionResult CadastrarPedido(CategoriaDTO categoria)
        {
            var resultado = new ValidacaoCategoriaDTO().Validate(categoria);

            if(!resultado.IsValid)
                return BadRequest(resultado.Errors);

            _categoriaRepository.Cadastrar(categoria);
            return Created();
        }

    }
}
