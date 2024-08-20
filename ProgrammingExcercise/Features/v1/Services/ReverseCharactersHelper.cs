namespace ProgrammingExercise.Features.v1.Services
{
    public static class ReverseCharactersHelper
    {
        public static string Reverse(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return string.Empty;
            }

            var reversedWord = string.Join("", word.Reverse());

            return reversedWord;
        }
    }
}
