using Entities.Concrete;
using FluentValidation;
using System;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {                        
            RuleFor(cI => cI.CarId).NotEmpty();

            //RuleFor(cI => cI.Date).Equal(DateTime.Now);
        }

    }
}
