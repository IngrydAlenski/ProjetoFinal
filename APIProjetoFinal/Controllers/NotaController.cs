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
            if(notaDTO != null)
            {
                //Extra - Verificar se o arquivo e uma imagem

                // 1- criar uma variavel que vai ser a pasta de destino das imagens
                var pastaDestino = Path.Combine(Directory.GetCurrentDirectory(), "Uploads"); //Path para gerenciar rotas. Directory.GetCurrentDirectory() vai pegar a pasta do projeto, ou seja, onde vai salvar as imagens
                  //2- Salvar o arquivo

                //Extra - criar um nome personalizado para o arquivo, como sugestao o nome pode ter data, hora, minuto e segundo

                var nomeArquivo = notaDTO.ArquivoNota.FileName;
                var caminhoCompleto = Path.Combine(pastaDestino, nomeArquivo);
                
                //metodo para salvar o arquivo, ele pode usar uma classe do c# e depois de usar ele descarta a classe.
                using (var stream = new FileStream(caminhoCompleto, FileMode.Create) ) //criar variavel para representar a classe, o FileStream recebe 2 informacoes, o caminho completo e o modo de criacao, mas tbm pode ser usado para ler arquivo, deletar arquivo
                {
                    notaDTO.ArquivoNota.CopyTo(stream); //pegar o arquivo o controlle e vai jogar para o caminho completo
                }

                //3- Guardar o local do arquivo no BD

                notaDTO.Imagenote = nomeArquivo;


            }


            _notaRepository.Cadastrar(notaDTO);

            //  if (notaDTO.ArquivoAnotacao != null)
            //  {
            //   var pastaDestino = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
            //   var nomeArquivo = notaDTO.ArquivoAnotacao.FileName;
            //   var caminhoCompleto = Path.Combine(pastaDestino, nomeArquivo);
            // using (var stream = new FileStream(caminhoCompleto, FileMode.Create)
            //  {
            // notaDTO.ArquivoAnotacao.CopyTo(stream);
            //   }

            return Created();

        }
        

        [HttpPost("CadastroSemImagem")]
        public IActionResult Cadastrar(CadastraNotaSemImagemDTO notaSemImageDTO)
        {
            _notaRepository.CadastrarSemImagem(notaSemImageDTO);
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

        [HttpDelete("/DeletarNota/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _notaRepository.Deletar(id);

                return NoContent();
            }

            catch (Exception ex)
            {
                return NotFound("Nota nao encontrado");
            }
        }

    }
}
