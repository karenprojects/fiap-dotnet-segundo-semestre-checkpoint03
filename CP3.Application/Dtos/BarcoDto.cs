using CP3.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP3.Application.Dtos
{
    public class BarcoDto : IBarcoDto
    {

        public void Validate()
        {

        }
    }

    internal class BarcoDtoValidation : AbstractValidator<BarcoDto>
    {
        public BarcoDtoValidation()
        {

        }
    }

}
