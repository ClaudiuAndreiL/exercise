namespace ProgrammingExercise.Features.AlgoLand.v3
{
    public static class StringExtensions
    {
        public static string Reverse(this string word)
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
