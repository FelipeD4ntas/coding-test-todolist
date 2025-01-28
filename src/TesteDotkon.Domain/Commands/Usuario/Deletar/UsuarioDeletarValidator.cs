using FluentValidation;

namespace TesteDotkon.Domain.Commands.Usuario.Deletar;

public class UsuarioDeletarValidator : AbstractValidator<UsuarioDeletarRequest>
{
    public UsuarioDeletarValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id usuario é obrigatório");
    }
}
