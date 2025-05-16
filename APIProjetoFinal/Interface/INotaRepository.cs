using APIProjetoFinal.Models;

namespace APIProjetoFinal.Interface
{
    public interface INotaRepository
    {
        List<Nota> ListarTodos();
        Nota BuscarPorIdUsuario(int id);
        Nota BuscarNotaPorData(DateTime date);
        void Atualizar(int id, Nota nota);
        void Deletar(int id);
        void Cadastrar(Nota nota);

    }
}
