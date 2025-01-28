using FluentValidation;

namespace TesteDotkon.Domain.Commands.Tarefa.Deletar;

public class TarefaDeletarValidator : AbstractValidator<TarefaDeletarRequest>
{
    public TarefaDeletarValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id tarefa é obrigatório");
    }
}
