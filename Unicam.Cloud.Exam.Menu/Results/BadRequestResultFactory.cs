using Microsoft.AspNetCore.Mvc;
using Unicam.Cloud.Exam.Menu.Application.Models.Responses;

namespace Unicam.Cloud.Exam.Menu.Web.Results {
    public class BadRequestResultFactory : BadRequestObjectResult {
        public BadRequestResultFactory(ActionContext context) : base(new BadResponse()) {
            var returnedErrors = new HashSet<String>();
            foreach (var key in context.ModelState) {
                var errors = key.Value.Errors;
                for (int i = 0; i < errors.Count; i++) {
                    returnedErrors.Add(errors[i].ErrorMessage);
                }
            }
            var response = (BadResponse)Value;
            response.Errors = returnedErrors;
        }
    }
}

