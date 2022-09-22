using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogue.Base.Response
{
    public class ApplicationResult<T> : CommonApplicationResult
    {
        public ApplicationResult(T data)
        {
            Result = data;
        }
        public ApplicationResult(string error)
        {
            ErrorMessage = error;
            Succeeded = false;
        }

        public T Result { get; set; }
    }

    public class ApplicationResult : CommonApplicationResult
    {

    }
    public class CommonApplicationResult
    {
        public DateTime ResponseTime { get; set; } = DateTime.UtcNow;
        public bool Succeeded { get; set; }
        public string ErrorMessage { get; set; }

    }
}
