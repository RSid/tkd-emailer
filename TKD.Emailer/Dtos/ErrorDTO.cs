using System;

namespace TKD.Emailer.Dtos
{
    internal class ErrorDTO
    {
       public string Message { get; set; }
       public Exception FullException { get; set; }
    }
}
