using System;
namespace Employee.Models.Client.Messages.Response
{
    public class ResponseBase<T> where T : class
    {
        public T Message { get; set; }

        public ErrorData Error { get; set; }
    }
}

