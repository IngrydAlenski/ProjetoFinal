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
        void Atualizar(int id, Nota nota);
        void Deletar(int id);
        void Cadastrar(CadastroNotaDTO notaDTO);

    }
}
