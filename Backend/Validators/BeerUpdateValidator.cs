using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators
{
    public class BeerUpdateValidator : AbstractValidator<BeerUpdateDto>
    {
        public BeerUpdateValidator() {
            RuleFor(x => x.Id).NotNull().WithMessage("El Id es obligatorio");
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre debe medir entre 2 y 20 caracteres");
            RuleFor(x => x.BrandID).NotNull().WithMessage("La marca es obligaria");
            RuleFor(x => x.BrandID).GreaterThan(0).WithMessage("Error en el valor enviado a marca");
            RuleFor(x => x.Alcohol).GreaterThan(0).WithMessage(x => "El {PropertyName} debe ser mayor a 0");
        }
    }
}
