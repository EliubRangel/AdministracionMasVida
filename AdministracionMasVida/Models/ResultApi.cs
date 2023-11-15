using System;
namespace AdministracionMasVida.Models
{
    public class ResultApi
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
        public int StatusCode { get; set; }
        public object Data { get; set; }

    }
}
