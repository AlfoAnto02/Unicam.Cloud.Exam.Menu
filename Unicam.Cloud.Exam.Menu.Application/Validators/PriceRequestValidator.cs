using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Application.Models.Requests;

namespace Unicam.Cloud.Exam.Menu.Application.Validators {
    public class PriceRequestValidator : AbstractValidator<PriceRequest> {
        public PriceRequestValidator() {
            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Price is required")
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0");
        }
    }
}
