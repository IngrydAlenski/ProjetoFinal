using APIProjetoFinal.DTO;
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
            public IActionResult Cadastrar(UsuarioDTO usuarioDTO)
            {
                _repository.Cadastrar(usuarioDTO);
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
        public IActionResult Login(LoginDTO loginDTO)
        {
            var cliente = _repository.BuscarPorEmailSenha(loginDTO.Senha, loginDTO.Email);

            if (loginDTO == null)
            {
                return Unauthorized("Email ou Senha invalidos!");
            }

            var tokenService = new TokenService();
            var token = tokenService.GenerateToken(cliente.Email);


            return Ok(token);
        }
    }
    }

