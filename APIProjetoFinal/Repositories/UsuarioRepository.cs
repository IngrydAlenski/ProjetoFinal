using APIProjetoFinal.Context;
using APIProjetoFinal.Interface;
using APIProjetoFinal.Models;
using APIProjetoFinal.Serveces;

namespace APIProjetoFinal.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Dbg5Context _context;

        public UsuarioRepository(Dbg5Context context)
        {
            _context = context;
        }

        public void Atualizar(int id, Usuario usuario)
        {
            var usuarioEncontrado = _context.Usuarios.FirstOrDefault(c => c.Iduser == id);

            if (usuarioEncontrado == null)
            {
                throw new ArgumentException("Usuario não encontrado");
            }

            usuarioEncontrado.Nomeuser = usuario.Nomeuser;
            usuarioEncontrado.Email = usuario.Email;
            usuarioEncontrado.Nota = usuario.Nota;
            usuarioEncontrado.Senha = usuario.Senha;
            _context.SaveChanges();
        }

        public Usuario BuscarPorEmailSenha(string senha, string E_mail)
        {
            Usuario? usuarioEncontrado = _context.Usuarios.FirstOrDefault(c => c.Email == E_mail);

            if (usuarioEncontrado == null)
                return null;

            var passwordService = new PasswordService();

            var resultado = passwordService.VerificarSenha(usuarioEncontrado, senha);

            if (resultado == true) return usuarioEncontrado;
            return null;
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuariocontrado = _context.Usuarios.Find(id);

            if (usuariocontrado == null)
            {
                throw new Exception();
            }

            _context.Usuarios.Remove(usuariocontrado);

            _context.SaveChanges();
        }
    }
    }

