using Bogus;
using ProgrammingExercise.Features.v2;
using ProgrammingExercise.Models.Internal;

namespace ProgrammingExercise.Features.v3
{
    public interface IAlgoRunnerServiceV3
    {
        Task<ServiceResponse<string>> GetResult();
    }

    public class AlgoRunnerServiceV3 : IAlgoRunnerServiceV3
    {
        private readonly ITimeProviderService _timeProviderService;
        private readonly IPigLatinService _pigLatinService;
        private readonly IPalindromeService _palindromeService;

        public AlgoRunnerServiceV3(
            ITimeProviderService timeProviderService,
            IPigLatinService pigLatinService,
            IPalindromeService palindromeService)
        {
            _timeProviderService = timeProviderService;
            _pigLatinService = pigLatinService;
            _palindromeService = palindromeService;
        }

        public async Task<ServiceResponse<string>> GetResult()
        {
            var currentTimeResponse = await _timeProviderService.GetCurrentTime();
            var someImportantData = new Faker().Lorem.Paragraph();

            if (!currentTimeResponse.IsValid)
                return new ServiceResponse<string>(currentTimeResponse.Error!);

            if (currentTimeResponse.Data!.Value.Second % 2 == 0)
            {
                return new ServiceResponse<string> { Data = _pigLatinService.ConvertToPigLatin(someImportantData) };
            }

            if (currentTimeResponse.Data.Value.Second % 3 == 0)
            {
                return new ServiceResponse<string> { Data = _palindromeService.IsPalindrome(someImportantData).ToString() };
            }

            if (currentTimeResponse.Data.Value.Second % 5 == 0)
            {
                return new ServiceResponse<string> { Data = someImportantData.Reverse() };
            }

            return currentTimeResponse.IsValid
                ? new ServiceResponse<string> { Data = new Faker().Lorem.Paragraph() }
                : new ServiceResponse<string>(currentTimeResponse.Error!);
        }
    }
}
