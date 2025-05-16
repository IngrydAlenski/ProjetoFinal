using APIProjetoFinal.Models;

namespace APIProjetoFinal.Interface
{
    public interface ICategoriaRepository
    {
        List<Categoria> ListarTodos();
        Categoria BuscarPorNome(string nome);
        void Atualizar (int id, Categoria categoria);
        void Deletar(int id);
        void Cadastrar(Categoria categoria);


    }
}
