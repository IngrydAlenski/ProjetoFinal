using APIProjetoFinal.Context;
using APIProjetoFinal.DTO;
using APIProjetoFinal.Interface;
using APIProjetoFinal.Models;

namespace APIProjetoFinal.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly Dbg5Context _context;

        public CategoriaRepository(Dbg5Context context)
        {
            _context = context;
        }
        public void Atualizar(int id, CategoriaDTO categoria)
        {
            Categoria categoriaEncontrado = _context.Categorias.Find(id);

            if (categoriaEncontrado == null)
            {
                throw new Exception();
            }

            categoriaEncontrado.Nomecategoria = categoria.Nomecategoria;
            //categoriaEncontrado.Criacaodata = categoria.Criacaodata;
            categoriaEncontrado.Atualizacaodata = DateTime.Now;

            _context.SaveChanges();

        }

        public Categoria BuscarPorNome(string nome)
        {
            return _context.Categorias.FirstOrDefault(n => n.Nomecategoria == nome);    
        }

        public void Deletar(int id)
        {
            Categoria categoriaEncontrado = _context.Categorias.Find(id);

            if (categoriaEncontrado == null)
            {
                throw new Exception();
            }
   
            _context.Categorias.Remove(categoriaEncontrado);
           
            _context.SaveChanges();
        }

        public List<Categoria> ListarTodos()
        {
            return _context.Categorias.ToList();
        }

        public void Cadastrar(CategoriaDTO categoria)
        {
            
            Categoria categoriCadastro = new Categoria 
            {
                Nomecategoria = categoria.Nomecategoria, 
                Criacaodata = DateTime.Now,
                Atualizacaodata = DateTime.Now
            };
            _context.Categorias.Add(categoriCadastro);
            _context.SaveChanges();
        }
    }
}
