using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Application.Models.Requests;
using Unicam.Cloud.Exam.Menu.Models.Repositories;

namespace Unicam.Cloud.Exam.Menu.Application.Validators {
    public class DishTypeUpdateRequestValidator : AbstractValidator<DishTypeUpdateRequest> {
        public readonly DishTypeRepository dishTypeRepository;

        public DishTypeUpdateRequestValidator(DishTypeRepository dishTypeRepository) {
            this.dishTypeRepository = dishTypeRepository;

            RuleFor(x => x.DishTypeId)
                .NotEmpty()
                .WithMessage("DishTypeId is required")
                .Custom(MustExist);
            RuleFor(x => x.DishType)
                .SetValidator(new DishTypeAddValidator(dishTypeRepository));
                
        }
        private void MustExist(int value, ValidationContext<DishTypeUpdateRequest> context) {
            var dishType = dishTypeRepository.GetByIdAsync(value).Result;
            if (dishType == null) {
                context.AddFailure("TypeId", "Type must exist");
            } else if (dishType.Dishes.Count > 0) {
                context.AddFailure("TypeId", "Cannot update a dish type with associated dishes");
            }
        }
    }
}
