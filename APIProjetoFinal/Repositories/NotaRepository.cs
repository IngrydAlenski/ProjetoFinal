using APIProjetoFinal.Context;
using APIProjetoFinal.Interface;
using APIProjetoFinal.Models;
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

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Nota> ListarTodos()
        {
            //return _context.Notas.ToList();

            return _context.Notas
               .Include(p => p.Categorianota) // quando incuir os itens do pedidos, precisa usar o ThenInclude, desta forma vai incluir os produtos relacionados ao itens produtos
               .ThenInclude(p => p.IdcategoriaNavigation)
               .ToList();
        }
    }
}
