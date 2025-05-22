using APIProjetoFinal.Context;
using APIProjetoFinal.DTO;
using APIProjetoFinal.Interface;
using APIProjetoFinal.Models;
using APIProjetoFinal.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace APIProjetoFinal.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly Dbg5Context _context;

        public NotaRepository(Dbg5Context context)
        {
            _context = context;
        }
        public void Atualizar(int id, Nota nota)
        {
            throw new NotImplementedException();
        }

        public Nota BuscarNotaPorData(DateTime date)
        {
            return _context.Notas.FirstOrDefault(d => d.Datanota == date);
        }

        public Nota BuscarPorIdUsuario(int id)
        {
            return _context.Notas.FirstOrDefault(n => n.Iduser == id);
        }

        public void Cadastrar(Nota nota)
        {
            throw new NotImplementedException();
        }

        //  public CadastrarNotaDTO? CadastrarNotaDTO (CadastrarNotaDTO notaDTO)
        //{
        //1- Percorrer a lista de notas 
        //1.1- Essa nota ja existe?
        //1.2- Se a nota ja existe eu tenho que pegar o id dela 
        //1.2- Se nao existe eu vou cadastrar a nota e pegar o id dela 

        //List<int>idNotas = new List<int>();
        //foreach (var item in notaDTO.Notas)
        //{

        // }
        //}

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<NotaViewModel> ListarTodos()
        {
            //return _context.Notas.ToList();

            return _context.Notas
               .Include(p => p.Categorianota) // quando incuir os itens do pedidos, precisa usar o ThenInclude, desta forma vai incluir os produtos relacionados ao itens produtos
               .ThenInclude(pa => pa.IdcategoriaNavigation)
               .Select(a => new NotaViewModel
               {
                   Idnota = a.Idnota,
                   Titulonota = a.Titulonota,
                   Descricao = a.Descricao,
                   Datanota = a.Datanota,
                   Atualizacaonota = a.Atualizacaonota,
                   Categorias = a.Categorianota.Select(pa => new CategoriaViewModel
                   {
                       Idcategoria = pa.IdcategoriaNavigation.Idcategoria,
                       Nomecategoria = pa.IdcategoriaNavigation.Nomecategoria
                   }).ToList()

               }) //o select vai permitir selecionar apenas os campos que eu quero apresentar no response da a api
               .ToList();
        }
    }
}
