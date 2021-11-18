using System;
using System.Collections.Generic;
using System.Text;

namespace FundooModel
{
    public class ResponseModel<T> //ResponseModel class with generic type
    {
        //using get set property
        public bool Status { get; set; } //to see status
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
