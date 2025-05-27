namespace APIProjetoFinal.DTO
{
    public class CadastraNotaSemImagem
    {
        public int Iduser { get; set; }

        // public DateTime Datanota { get; set; }

        public string Titulonota { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        public bool? Statusnote { get; set; }

        //public DateTime Atualizacaonota { get; set; }
        public string? Imagenote { get; set; }

        public List<string> Categorias { get; set; }//Lista par retornar as categorias
    }
}
