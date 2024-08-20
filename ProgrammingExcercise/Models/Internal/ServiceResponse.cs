using System.Runtime.InteropServices;

namespace ProgrammingExercise.Models.Internal
{
    public class ServiceResponse<T>
    {
        public string? Error { get; set; }
        public bool IsValid => string.IsNullOrWhiteSpace(Error);

        public T? Data { get; set; }


        public ServiceResponse()
        {

        }

        public ServiceResponse(T data)
        {
            Data = data;
        }

        public ServiceResponse(string error)
        {
            Error = error;
        }
    }


}
