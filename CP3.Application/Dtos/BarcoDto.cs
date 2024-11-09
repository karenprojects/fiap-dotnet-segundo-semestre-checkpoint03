using CP3.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP3.Application.Dtos
{
    public class BarcoDto : IBarcoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public int Ano { get; set; }
        public double Tamanho { get; set; }

        public void Validate()
        {
            var validator = new BarcoDtoValidation();
            var result = validator.Validate(this);

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }

    internal class BarcoDtoValidation : AbstractValidator<BarcoDto>
    {
        public BarcoDtoValidation()
        {
            RuleFor(barco => barco.Nome)
                .NotEmpty().WithMessage("O campo 'Nome' é obrigatório.");

            RuleFor(barco => barco.Modelo)
                .NotEmpty().WithMessage("O campo 'Modelo' é obrigatório.");

            RuleFor(barco => barco.Ano)
                .GreaterThan(1900).WithMessage("O ano de fabricação deve ser maior que 1900.");

            RuleFor(barco => barco.Tamanho)
                .GreaterThan(0).WithMessage("O campo 'Tamanho' deve ser maior que 0.");
        }
    }
}
