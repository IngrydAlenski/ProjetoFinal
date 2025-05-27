using APIProjetoFinal.DTO;
using Azure;
using FluentValidation;

namespace APIProjetoFinal.Validators
{
    public class ValidacaoCategoriaDTO : AbstractValidator<CategoriaDTO>
    {
        public ValidacaoCategoriaDTO()
        {
            RuleFor(t => t.Nomecategoria)
            .NotEmpty().WithMessage("O nome da categoria é obrigatório.")
            .MaximumLength(50).WithMessage("O nome da tag deve ter no máximo 50 caracteres.");

        }
    }
}

