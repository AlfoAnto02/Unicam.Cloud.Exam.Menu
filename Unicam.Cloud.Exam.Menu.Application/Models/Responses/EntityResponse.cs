using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unicam.Cloud.Exam.Menu.Application.Models.Responses {
    public class EntityResponse <T>{
        public T? Result { get; set; } = default;
    }
}
