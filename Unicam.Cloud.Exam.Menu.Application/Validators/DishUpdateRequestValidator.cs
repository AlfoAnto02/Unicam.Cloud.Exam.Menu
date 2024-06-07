using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Application.Models.Requests;
using Unicam.Cloud.Exam.Menu.Models.Repositories;

namespace Unicam.Cloud.Exam.Menu.Application.Validators {
    public class DishUpdateRequestValidator : AbstractValidator<DishUpdateRequest>{
        public readonly DishRepository dishRepository;
        public readonly DishTypeRepository dishTypeRepository;
        public DishUpdateRequestValidator(DishRepository dishRepository, DishTypeRepository dishTypeRepository) {
            this.dishRepository = dishRepository;
            this.dishTypeRepository = dishTypeRepository;

            RuleFor(x => x.DishId)
                .NotEmpty()
                .WithMessage("DishId is required")
                .Must(dishId => dishRepository.GetByIdAsync(dishId).Result != null)
                .WithMessage("Dish not found");

            RuleFor(x => x.Dish)
                .SetValidator(new DishAddRequestValidator(dishRepository, dishTypeRepository));
        }
    }
}
