using APIProjetoFinal.DTO;
using APIProjetoFinal.Models;

namespace APIProjetoFinal.Interface
{
    public interface IUsuarioRepository 
    {
        void Cadastrar(UsuarioDTO usuarioDTO);
        void Atualizar(int id, Usuario usuario);
        void Deletar(int id);
        Usuario BuscarPorEmailSenha(string senha, string E_mail);
        
    }
}
