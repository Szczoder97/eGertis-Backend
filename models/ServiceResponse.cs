using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eGertis.models
{
    public class ServiceResponse<T>
    {
        T data {get; set;}
        bool succes {get; set;} = true;
        string message {get; set;} = null;
    }
}