using APIProjetoFinal.DTO;
using APIProjetoFinal.Models;
using APIProjetoFinal.ViewModels;

namespace APIProjetoFinal.Interface
{
    public interface INotaRepository
    {
        List<NotaViewModel> ListarTodos();
        Nota BuscarPorIdUsuario(int id);
        Nota BuscarNotaPorData(DateTime date);
        void Atualizar(int id, AtualizarNotaDTO nota);
        void Deletar(int id);
        CadastroNotaDTO Cadastrar(CadastroNotaDTO notaDTO);
        CadastraNotaSemImagem CadastrarSemImagem(CadastraNotaSemImagem notaSemImagemDTO);
        Nota? ArquivarNota(int id); 

    }
}
