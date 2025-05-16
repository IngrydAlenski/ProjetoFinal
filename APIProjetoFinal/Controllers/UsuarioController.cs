using APIProjetoFinal.Interface;
using APIProjetoFinal.Models;
using APIProjetoFinal.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        //[HttpDelete("{id}")]
        //public IActionResult DeletarUsuario(int id)
        //{
        //    var usuarioBuscado = UsuarioRepository.(id);

        //    if (usuarioBuscado == null)
        //        return NotFound(); 

        //   UsuarioRepository.Deletar(id);

        //    return NoContent();
        //}
        //[HttpPut("{id}")]
        //public IActionResult AtualizarUsuario(int id, Usuario usuario)
        //{
        //    var clienteBuscado = UsuarioRepository.BuscarPorId(id);

        //    if (clienteBuscado == null)
        //        return NotFound(); 

        //   UsuarioRepository.Atualizar(id, usuario);

        //    return NoContent(); 
        //}


        //[HttpPost("Usuario")]
        //public IActionResult Login(Usuario usuario)
        //{
        //    var cliente = UsuarioRepository.BuscarPorEmailSenha(usuario.Senha, usuario.Email);

        //    if (cliente == null)
        //    {
        //        return Unauthorized("Email ou Senha invalidos!");
        //    }





        //    var tokenService = new TokenService();
        //    var token = tokenService.GenerateToken(cliente.Email);


        //    return Ok(token);
        //}
    }
}

