using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Application.Models.Requests;
using Unicam.Cloud.Exam.Menu.Models.Repositories;

namespace Unicam.Cloud.Exam.Menu.Application.Validators {
    public class TypologyRequestValidator : AbstractValidator<TypologyRequest>{
        public readonly DishTypeRepository dishTypeRepository;

        public TypologyRequestValidator(DishTypeRepository dishTypeRepository) {
            this.dishTypeRepository = dishTypeRepository;

            RuleFor(x => x.Typology)
                .NotEmpty()
                .WithMessage("Typology is required")
                .Custom(ValidTypology);
        }

        private void ValidTypology(string typology, ValidationContext<TypologyRequest> context) {
            var type = dishTypeRepository.GetByTypologyAsync(typology).Result;
            if (type == null) {
                context.AddFailure("Typology not found");
            }
        }
    }
}
