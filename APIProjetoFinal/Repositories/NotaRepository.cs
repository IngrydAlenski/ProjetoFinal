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

        private ICategoriaRepository _categoriaRepository;
        private Dbg5Context _context;

        public NotaRepository(Dbg5Context context, ICategoriaRepository categoriaRepository) //: base(context)
        {
            _categoriaRepository = categoriaRepository;
            _context = context;
        }

        public void Atualizar(int id, AtualizarNotaDTO nota)
        {
            var notaAntiga = _context.Notas.Find(id);

            if (notaAntiga == null) 
            {
                throw new ArgumentNullException("Nota nao encontrado");
            }

            notaAntiga.Titulonota = nota.Titulonota;
            notaAntiga.Descricao = nota.Descricao;
            //notaAntiga.Statusnote = nota.Statusnote;
            notaAntiga.Atualizacaonota = DateTime.Now;

            _context.SaveChanges();
        }

        public Nota BuscarNotaPorData(DateTime date)
        {
            return _context.Notas.FirstOrDefault(d => d.Datanota == date);
        }

        public Nota BuscarPorIdUsuario(int id)
        {
            return _context.Notas.FirstOrDefault(n => n.Iduser == id);
        }


        public CadastroNotaDTO? Cadastrar(CadastroNotaDTO notaDTO)
        {
        // 1 - Percorrer a Lista de Categorias
        //1.1 - Verificar se a Categoria ja existe ?
        //1.2 - Se existir, precisa pegar o Id da Categoria
        //1.2 - Se nao existir, precisa cadastrar a categoria e pegar o id

         List<int> idCategorias = new List<int>(); //criando uma lista para guardar os ids

            foreach (string item in notaDTO.Categorias)
            {
                var categoria = _categoriaRepository.BuscarPorNome(item); //verificando se a categoria existe

                if (categoria == null)
                {
                    categoria = new Categoria
                    {
                        Nomecategoria = item,
                        Atualizacaodata = DateTime.Now,
                        Criacaodata = DateTime.Now
                        
                    };
                    // TODO: Cadastrar a categoria
                    _context.Add(categoria);
                    _context.SaveChanges();

                }
                idCategorias.Add(categoria.Idcategoria);
            }

            //Cadastrar Nota
            var novaNota = new Nota
            {
                Titulonota = notaDTO.Titulonota,
                Descricao = notaDTO.Descricao,
                Datanota = DateTime.Now,
                Atualizacaonota = DateTime.Now,
                //TODO: implementar o campo de status da nota 
                Iduser = notaDTO.Iduser,
               // Imagenote = null,
                Statusnote = false
            };

            _context.Add(novaNota);
            _context.SaveChanges();

            //Cadastrar a Categorianota
            foreach (var item in idCategorias)
            {
                var categoriaNota = new Categorianota
                {
                    Idcategoria = novaNota.Idnota,
                    Notaid = item
                };
                _context.Add(categoriaNota);
                _context.SaveChanges();
            }

            return notaDTO;
        }


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
                   Iduser = a.Iduser,
                   Idnota = a.Idnota,
                   Titulonota = a.Titulonota,
                   Descricao = a.Descricao,
                   Datanota = a.Datanota,
                   Atualizacaonota = a.Atualizacaonota,
                   Statusnote = a.Statusnote,
                   Categorias = a.Categorianota.Select(pa => new CategoriaViewModel
                   {
                       Idcategoria = pa.IdcategoriaNavigation.Idcategoria,
                       Nomecategoria = pa.IdcategoriaNavigation.Nomecategoria
                   }).ToList()

               }) //o select vai permitir selecionar apenas os campos que eu quero apresentar no response da a api
               .ToList();
        }


        public Nota? ArquivarNota(int id)
        {
            var nota = _context.Notas.Find(id);

            if (nota == null) return null;

            nota.Statusnote = !nota.Statusnote;

            _context.SaveChanges();

            return nota;
        }
    }
}
