namespace ProgrammingExercise.Models.Internal
{
    public class ApiServiceResponse<T> 
    {
        public string? Error { get; set; }
        public bool IsValid => string.IsNullOrWhiteSpace(Error);

        public T? Data { get; set; }
    }
}
