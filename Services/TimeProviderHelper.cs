using ProgrammingExercise.Models.Internal;

namespace ProgrammingExercise.Services
{
    public static class TimeProviderHelper
    {
        public static async Task<ServiceResponse<DateTime?>> GetCurrentTime()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7039")
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
