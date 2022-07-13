using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace w3schools_API.Models
{
    public class DataResults<T>
    {
        public int Status { get; set; }

        public string Message { get; set; }

        public T Data { get; set; }
        
        public DataResults(int st, string mess, T d)
        {
            Status = st;
            Message = mess;
            Data = d;
        }
        public DataResults() { }
        
    }
    public class UpdateBatchData<T>
    {
        public T key { get; set; }
        public T data { get; set; }
        public string type { get; set; }

    }
}
