using FluentValidation;

namespace TesteDotkon.Domain.Commands.Tarefa.Editar;

public class TarefaEditarValidator : AbstractValidator<TarefaEditarRequest>
{
    public TarefaEditarValidator()
    {
        RuleFor(x => x.Titulo)
        .NotEmpty()
        .WithMessage("Título é obrigatório")
        .MaximumLength(50)
        .WithMessage("Título deve ter no máximo 50 caracteres");

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .WithMessage("Descrição é obrigatória")
            .MaximumLength(500)
            .WithMessage("Descrição deve ter no máximo 500 caracteres");

        RuleFor(x => x.DataFechamento)
            .NotEmpty()
            .WithMessage("Data de término é obrigatória")
            .GreaterThanOrEqualTo(x => x.DataPublicacao)
            .WithMessage("Data de término deve ser maior ou igual à data de cadastro");
    }
}

