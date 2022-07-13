using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace w3schools_WEB.Models
{
    public class Message<T>
    {
        public bool IsSuccess { get; set; }
        public string ReturnMessage { get; set; }
        public T Data { get; set; }
    }
}
