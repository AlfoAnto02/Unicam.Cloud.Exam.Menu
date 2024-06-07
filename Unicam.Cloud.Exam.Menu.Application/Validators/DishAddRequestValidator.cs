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
    public class DishAddRequestValidator : AbstractValidator<DishAddRequest>{
        public readonly DishRepository dishRepository;
        public readonly DishTypeRepository dishTypeRepository;
        public DishAddRequestValidator(DishRepository dishRepository, DishTypeRepository dishTypeRepository){
            this.dishRepository = dishRepository;
            this.dishTypeRepository = dishTypeRepository;
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is required")
                .Custom(BeUniqueName)
                .MaximumLengthWithMessage(100,"Name can't be longer than 100 characters!");
            RuleFor(x => x.Price)
                .GreaterThan(0)
                .WithMessage("Price must be greater than 0");
            RuleFor(x => x.TypeID)
                .NotEmpty()
                .WithMessage("Type is required")
                .Custom(MustExist);
        }

        private void BeUniqueName(string value, ValidationContext<DishAddRequest> context) {
            if (dishTypeRepository.ExistByNameAsync(value).Result){
                    context.AddFailure("Name", "Name must be unique");
                }
        }

        private void MustExist(int value, ValidationContext<DishAddRequest> context) {
            var dishType = dishTypeRepository.GetByIdAsync(value).Result;
            if (dishType == null){
                context.AddFailure("TypeId", "Type must exist");
            }
        }
    }
}

