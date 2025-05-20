using APIProjetoFinal.Interface;
using APIProjetoFinal.Models;
using APIProjetoFinal.Repositories;
using APIProjetoFinal.Serveces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APIProjetoFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

            private readonly IUsuarioRepository _repository;

            public UsuarioController(IUsuarioRepository repository)
            {
                _repository = repository;
            }
            [HttpPost]
            public IActionResult Cadastrar(Usuario usuario)
            {
                _repository.Cadastrar(usuario);
                return Created();

            }
        [HttpDelete("{id}")]
        public IActionResult DeletarUsuario(int id)
        {
            try
            {
                _repository.Deletar(id);


                return NoContent();
            }

            catch (Exception ex)
            {
                return NotFound("Usuario não encontrado");
            }
        }
        [HttpPut("{id}")]
        public IActionResult AtualizarUsuario(int id, Usuario usuario)
        {
            try
            {

                _repository.Atualizar(id, usuario);

                return Ok(usuario);
            }

            catch (Exception ex)
            {
                return NotFound("Usuario não encontrado");
            }
        }


        [HttpPost("Login")]
        public IActionResult Login(Usuario usuario)
        {
            var cliente = _repository.BuscarPorEmailSenha(usuario.Senha, usuario.Email);

            if (usuario == null)
            {
                return Unauthorized("Email ou Senha invalidos!");
            }

            var tokenService = new TokenService();
            var token = tokenService.GenerateToken(cliente.Email);


            return Ok(token);
        }
    }
    }

