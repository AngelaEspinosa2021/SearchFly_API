using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchFly_API.Models.Dto
{
    public class ResponseDto
    {
        public bool IsSucess { get; set; }

        public object Result { get; set; }

        public string DisplayMessage { get; set; }

        public List<string> ErrorMessage { get; set; }
    }
}
