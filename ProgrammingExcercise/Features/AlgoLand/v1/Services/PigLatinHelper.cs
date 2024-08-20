using System.Text;

namespace ProgrammingExercise.Features.AlgoLand.v1.Services
{
    public static class PigLatinHelper
    {
        public static string ConvertToPigLatin(string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence))
            {
                return string.Empty;
            }

            var words = sentence.Split(' ');
            var pigLatinSentence = new StringBuilder();

            foreach (var word in words)
            {
                string pigLatinWord = ConvertWordToPigLatin(word);
                pigLatinSentence.Append(pigLatinWord + " ");
            }

            return pigLatinSentence.ToString().TrimEnd();
        }

        private static string ConvertWordToPigLatin(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                return word;
            }

            char firstLetter = word[0];
            string restOfWord = word.Substring(1);

            if (IsVowel(firstLetter))
            {
                return word + "yay";
            }
            else
            {
                return restOfWord + firstLetter + "ay";
            }
        }

        private static bool IsVowel(char c)
        {
            return "aeiouAEIOU".IndexOf(c) >= 0;
        }
    }
}
