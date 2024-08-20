using ProgrammingExercise.Models.Internal;

namespace ProgrammingExercise.Features.AlgoLand.v2
{
    public interface ITimeProviderService
    {
        Task<ServiceResponse<DateTime?>> GetCurrentTime();
    }

    public class TimeProviderService : ITimeProviderService
    {

        public async Task<ServiceResponse<DateTime?>> GetCurrentTime()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5092")
            };

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("timeprovider/current-time");

                var responseString = await response.Content.ReadAsStringAsync();

                if (DateTime.TryParse(responseString.Trim('"'), out DateTime dateTime))
                {
                    return new(dateTime);
                }
                else
                {
                    return new ServiceResponse<DateTime?>("Invalid DateTime format in response.");
                }
            }
            catch (Exception e)
            {
                return new ServiceResponse<DateTime?>($"Request error: {e.Message}");
            }
        }
    }
}
