using APIProjetoFinal.DTO;
using APIProjetoFinal.Models;
using FluentValidation;

namespace APIProjetoFinal.Validators
{
    public class ValidacaoUsuario : AbstractValidator<UsuarioDTO>
    {
        public ValidacaoUsuario()
        {
            RuleFor(u => u.Nomeuser)
           .NotEmpty().WithMessage("O nome do usuário é obrigatório.")
           .MaximumLength(100).WithMessage("O nome do usuário deve ter no máximo 100 caracteres.");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O e-mail do usuário é obrigatório.")
                .EmailAddress().WithMessage("O e-mail do usuário deve ser válido.");

            RuleFor(u => u.Senha)
                .NotEmpty().WithMessage("A senha do usuário é obrigatória.")
                .MinimumLength(6).WithMessage("A senha deve ter no mínimo 6 caracteres.");
        }
    }

}

