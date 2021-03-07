using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(car => car.Description).MinimumLength(2);
            RuleFor(car => car.Description).NotNull();
            RuleFor(car => car.CarId).NotNull();
            RuleFor(car => car.BrandId).NotNull();
            RuleFor(car => car.ColorId).NotNull();
            RuleFor(car => car.DailyPrice).GreaterThan(0);
            RuleFor(car => car.ModelYear).GreaterThan(0);
            RuleFor(car => car.DailyPrice).GreaterThanOrEqualTo(10).When(car => car.BrandId == 1); //brand id si 1 ise dailyprice 10 a eşit veya büyük olmak zorunda.
            RuleFor(car => car.Description).Must(StartWithA).WithMessage("Araba ismi 'A' ile başlamalı");

        }

        private bool StartWithA(string arg) //arg=productname
        {
            return arg.StartsWith("A");   //StartsWith = string fonksiyonu
        }
    }
}
