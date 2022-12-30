using FluentValidation;
using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.FluentValidators
{
    public class AdressValidator:AbstractValidator<Adress>
    {
        public string NotEmptyMessage = "{PropertName} boş olamaz";
        public AdressValidator()
        {
            RuleFor(x=>x.Content).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x => x.PostCode).NotEmpty().WithMessage(NotEmptyMessage).MaximumLength(5).WithMessage("{PropertyName} {MaxLength} karakterli olabilir.");
            RuleFor(x => x.Content).NotEmpty().WithMessage(NotEmptyMessage);


        }
    }
}
