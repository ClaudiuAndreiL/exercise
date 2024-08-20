using Bogus;
using ProgrammingExercise.Models.Internal;

namespace ProgrammingExercise.Features.v1.Services
{


    /// <summary>
    ///  based on externally retrieved data (a datetime) we alter a generated paragraph
    ///  if second is even then return pig latin
    ///  if second divides by 3 returns palindrome
    ///  if second divides by 5 returns reverse
    /// </summary>
    public interface IAlgoRunnerService
    {
        Task<ServiceResponse<string>> GetResult();
    }

    public class AlgoRunnerService : IAlgoRunnerService
    {
        public async Task<ServiceResponse<string>> GetResult()
        {
            var currentTimeResponse = await TimeProviderHelper.GetCurrentTime();
            var someImportantData = new Faker().Lorem.Paragraph();

            if(!currentTimeResponse.IsValid)
                return new ServiceResponse<string>(currentTimeResponse.Error!);

            if(currentTimeResponse.Data!.Value.Second % 2 == 0)
            {
                return new ServiceResponse<string>(PigLatinHelper.ConvertToPigLatin(someImportantData));
            }

            if(currentTimeResponse.Data.Value.Second % 3 == 0)
            {
                return new ServiceResponse<string>(someImportantData.IsPalindrome().ToString());
            }

            if(currentTimeResponse.Data.Value.Second % 5 == 0)
            {
                return new ServiceResponse<string>(ReverseCharactersHelper.Reverse(someImportantData));
            }

            return currentTimeResponse.IsValid
                ? new ServiceResponse<string>(new Faker().Lorem.Paragraph())
                : new ServiceResponse<string>(currentTimeResponse.Error!);
        }
    }
}
