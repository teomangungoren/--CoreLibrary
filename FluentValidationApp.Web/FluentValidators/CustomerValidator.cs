using FluentValidation;
using FluentValidationApp.Web.Models;
using System;
using System.Security.Cryptography.Xml;

namespace FluentValidationApp.Web.FluentValidators
{
    public class CustomerValidator:AbstractValidator<Customer>
    {
        public string NotEmptyMessage = "{PropertyName} boş olamaz";
        public CustomerValidator()
        {
            RuleFor(x=> x.Name).NotEmpty().WithMessage(NotEmptyMessage);
            RuleFor(x=>x.Email).NotEmpty().WithMessage(NotEmptyMessage).EmailAddress().WithMessage("Email adresi doğru formatta olmalıdır.");
            RuleFor(x => x.Age).NotEmpty().WithMessage(NotEmptyMessage).InclusiveBetween(18,60).WithMessage("Yaşınız 18den büyük olmalıdır.");
            RuleFor(x => x.BirthDay).NotEmpty().WithMessage(NotEmptyMessage).Must(x =>
            {
                return DateTime.Now.AddYears(-18) >= x;
            }).WithMessage("Yaşınız 18den büyük olmalıdır");

            RuleFor(x => x.Gender).IsInEnum().WithMessage("{PropertyName} alanı Erkek=1,Kadın=2 olmalıdır.");

            RuleForEach(x => x.Adresses).SetValidator(new AdressValidator());
        }
    }
}
