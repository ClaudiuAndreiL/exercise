using Bogus;
using ProgrammingExercise.Features.v1.Services;
using ProgrammingExercise.Models.Internal;

namespace ProgrammingExercise.Features.v2
{
    public interface IAlgoRunnerServiceV2
    {

    }

    public class AlgoRunnerServiceV2 : IAlgoRunnerServiceV2
    {
        private readonly ITimeProviderService _timeProviderService;
        private readonly IPigLatinService _pigLatinService;

        public AlgoRunnerServiceV2(
            ITimeProviderService timeProviderService,
            IPigLatinService pigLatinService)
        {
            _timeProviderService = timeProviderService;
            _pigLatinService = pigLatinService;
        }

        public async Task<ServiceResponse<string>> GetResult()
        {
            var currentTimeResponse = await _timeProviderService.GetCurrentTime();
            var someImportantData = new Faker().Lorem.Paragraph();

            if (!currentTimeResponse.IsValid)
                return new ServiceResponse<string>(currentTimeResponse.Error!);

            if (currentTimeResponse.Data!.Value.Second % 2 == 0)
            {
                return new ServiceResponse<string>(_pigLatinService.ConvertToPigLatin(someImportantData));
            }

            if (currentTimeResponse.Data.Value.Second % 3 == 0)
            {
                return new ServiceResponse<string>(IsPalindromeV2(someImportantData).ToString());
            }

            if (currentTimeResponse.Data.Value.Second % 5 == 0)
            {
                return new ServiceResponse<string>(new string(someImportantData.Reverse().ToArray()));
            }

            return currentTimeResponse.IsValid
                ? new ServiceResponse<string>(new Faker().Lorem.Paragraph())
                : new ServiceResponse<string>(currentTimeResponse.Error!);
        }

        private static bool IsPalindromeV2(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            // Convert the string to lowercase and remove non-alphanumeric characters
            string cleanedInput = CleanString(input);

            // Check if the cleaned string is the same forwards and backwards
            int left = 0;
            int right = cleanedInput.Length - 1;

            while (left < right)
            {
                if (cleanedInput[left] != cleanedInput[right])
                {
                    return false;
                }
                left++;
                right--;
            }

            return true;
        }

        private static string CleanString(string input)
        {
            char[] arr = input.ToLower().ToCharArray();
            return new string(Array.FindAll(arr, char.IsLetterOrDigit));
        }
    }
}
