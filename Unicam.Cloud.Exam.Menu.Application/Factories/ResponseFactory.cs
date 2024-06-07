using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unicam.Cloud.Exam.Menu.Application.Models.Responses;

namespace Unicam.Cloud.Exam.Menu.Application.Factories {
    public class ResponseFactory {
        public static BaseResponse<T> WithSuccess<T>(T result) {
            var response = new BaseResponse<T>();
            response.Success = true;
            response.Result = result;
            return response;
        }

        public static BaseResponse<string> WithError(Exception exception) {
            var response = new BaseResponse<string>();
            response.Success = false;
            response.Errors = new HashSet<string>() { exception.Message };
            return response;
        }
    }
}
