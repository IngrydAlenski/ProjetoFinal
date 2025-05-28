using APIProjetoFinal.DTO;
using APIProjetoFinal.Interface;
using APIProjetoFinal.Models;
using APIProjetoFinal.Repositories;
using APIProjetoFinal.Serveces;
using APIProjetoFinal.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
            [HttpPost("/CadastrarUmUsuario")]
            public IActionResult Cadastrar(UsuarioDTO usuarioDTO)
            {
            var resultado = new ValidacaoUsuario().Validate(usuarioDTO);

            if (!resultado.IsValid)
                return BadRequest(resultado.Errors);

            _repository.Cadastrar(usuarioDTO);
                return Created();

            }
        [HttpDelete("/DeletarUsuario\"")]
        [Authorize]
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
        [HttpPut("/AtualizarUsuario/{id}")]
        [Authorize]
        public IActionResult AtualizarUsuario(int id, UsuarioDTO usuario)
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
        [HttpPost("/LoginDeUsuario\"")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var usuario = _repository.BuscarPorEmailSenha(loginDTO.Senha, loginDTO.Email);

            if (loginDTO == null)
            {
                return Unauthorized("Email ou Senha invalidos!");
            }
            var tokenService = new TokenService();
            var token = tokenService.GenerateToken(usuario.Email);
            return Ok(new
            {
                token,
                usuario.Iduser,
                usuario.Nomeuser,
                usuario.Email
            }
            );
          
        }
    }
    }

