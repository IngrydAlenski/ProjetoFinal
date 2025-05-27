using APIProjetoFinal.DTO;
using FluentValidation;
namespace APIProjetoFinal.Validators

{
    public class ValidacaoNotaDTO : AbstractValidator<CadastroNotaDTO>
    {
        public ValidacaoNotaDTO()
        {
            RuleFor(a => a.Titulonota)
           .NotEmpty().WithMessage("O título da anotação é obrigatório.")
           .MaximumLength(100).WithMessage("O título da anotação deve ter no máximo 100 caracteres.");

            RuleFor(a => a.Descricao)
                .NotEmpty().WithMessage("A descrição da anotação é obrigatória.")
                .MaximumLength(300).WithMessage("A descricao da anotação deve ter no máximo 300 caracteres.");
            RuleFor(a => a.Iduser)
                .NotNull().WithMessage("O usuário da anotação é obrigatório.");
        }
    }

}

