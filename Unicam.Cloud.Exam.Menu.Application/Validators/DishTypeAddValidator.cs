using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Application.Extensions;
using Unicam.Cloud.Exam.Menu.Application.Models.Requests;
using Unicam.Cloud.Exam.Menu.Models.Repositories;

namespace Unicam.Cloud.Exam.Menu.Application.Validators {
    public class DishTypeAddValidator : AbstractValidator<DishTypeAddRequest>{
        public readonly DishTypeRepository _dishTypeRepository;

        public DishTypeAddValidator(DishTypeRepository dishTypeRepository) {
            this._dishTypeRepository = dishTypeRepository;

            RuleFor(x => x.Typology)
                .NotEmpty()
                .WithMessage("Typology is required")
                .Custom(BeUniqueTypology)
                .MinimumLength(3)
                .WithMessage("Typology must be at least 3 characters long!")
                .RegEx(@"^[a-zA-Z]+$", "Typology Name can only contains alphabetic character!");
                
               
        }

        private void BeUniqueTypology(string value, ValidationContext<DishTypeAddRequest> validationContext) {
            var dishType = _dishTypeRepository.GetByTypologyAsync(value).Result;
            if(dishType != null) {
                validationContext.AddFailure("Typology", "Typology must be unique");
            }
        }
    }
}
