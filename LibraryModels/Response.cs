using System;
namespace LibraryModels
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Msg { get; set; }

        public T Data { get; set; }

        public Response()
        {
            Data = default(T);
        }
    }
}

