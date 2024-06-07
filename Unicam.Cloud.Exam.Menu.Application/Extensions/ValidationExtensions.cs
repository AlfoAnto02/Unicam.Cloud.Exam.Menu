using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Cloud.Exam.Menu.Application.Extensions {
    public static class ValidationExtensions {
        public static void RegEx<T, TProperty>(this IRuleBuilderOptions<T, TProperty> ruleBuilder, string regex, string message) {
            ruleBuilder.Custom((value, context) => {
                var _regex = new System.Text.RegularExpressions.Regex(regex);
                if (_regex.IsMatch(value.ToString()) == false) {
                    context.AddFailure(message);
                }
            });
        }
        public static void MaximumLengthWithMessage<T>(this IRuleBuilder<T, string> ruleBuilder, int maxLength, string message) {
            ruleBuilder.Custom((value, context) => {
                if (value?.Length > maxLength) {
                    context.AddFailure(message);
                }
            });
        }
    }
}
