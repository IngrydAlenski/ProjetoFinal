using APIProjetoFinal.Models;

namespace APIProjetoFinal.ViewModels
{
    public class NotaViewModel
    {
        public int Idnota { get; set; }

        public int Iduser { get; set; }

        public DateTime Datanota { get; set; }

        public string Titulonota { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        public DateTime Atualizacaonota { get; set; }

        public bool? Statusnote { get; set; } = null!;

        public List<CategoriaViewModel> Categorias { get; set; }
    }
}
