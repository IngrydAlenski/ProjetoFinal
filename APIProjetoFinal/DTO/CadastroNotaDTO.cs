﻿using APIProjetoFinal.Models;

namespace APIProjetoFinal.DTO
{
    public class CadastroNotaDTO
    {

        public int Iduser { get; set; }

       // public DateTime Datanota { get; set; }

        public string Titulonota { get; set; } = null!;

        public string Descricao { get; set; } = null!;

        //public IFormFile? ArquivoAnotacao { get; set; }
        public bool? Statusnote { get; set; }

        //public DateTime Atualizacaonota { get; set; }
        public string? Imagenote { get; set; }

        public IFormFile? ArquivoNota { get; set; }//para armazenar a imagem, ou excel etc
        public List<string> Categorias { get; set; }//Lista par retornar as categorias


    }
}
