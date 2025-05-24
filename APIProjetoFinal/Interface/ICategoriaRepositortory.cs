using APIProjetoFinal.DTO;
using APIProjetoFinal.Models;

namespace APIProjetoFinal.Interface
{
    public interface ICategoriaRepository
    {
        List<Categoria> ListarTodos();
        Categoria BuscarPorNome(string nome);
        void Atualizar (int id, CategoriaDTO categoria);
        void Deletar(int id);
        void Cadastrar(CategoriaDTO categoria);


    }
}
