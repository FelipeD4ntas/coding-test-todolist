using FluentValidation;

namespace TesteDotkon.Domain.Commands.Usuario.Adicionar;

public class UsuarioAdicionarValidator : AbstractValidator<UsuarioAdicionarRequest>
{
    public UsuarioAdicionarValidator()
    {
        RuleFor(x => x.Nome)
           .NotEmpty()
           .WithMessage("Nome é obrigatório")
           .Matches(@"^[a-zA-Z\s]+$")
           .WithMessage("Nome deve conter apenas letras")
           .MaximumLength(50)
           .WithMessage("Nome deve ter no máximo 50 caracteres");

        RuleFor(x => x.NomeDeUsuario)
            .NotEmpty()
            .WithMessage("Nome de Usuário é obrigatório")
            .Matches(@"^[a-zA-Z][a-zA-Z0-9._]{0,29}$")
            .WithMessage("Usuário deve começar com uma letra e conter apenas alfanuméricos, pontos ou underscores, com no máximo 30 caracteres");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email é obrigatório");

        RuleFor(x => x.Senha)
            .NotEmpty()
            .WithMessage("Senha é obrigatória");

        RuleFor(x => x.ConfirmacaoSenha)
            .NotEmpty()
            .WithMessage("Confirmação de senha é obrigatória")
            .Equal(x => x.Senha)
            .WithMessage("As senhas não conferem");
    }
}
