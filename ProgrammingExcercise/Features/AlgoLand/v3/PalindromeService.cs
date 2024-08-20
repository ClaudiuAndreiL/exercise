namespace ProgrammingExercise.Features.AlgoLand.v3
{
    public interface IPalindromeService
    {
        bool IsPalindrome(string input);
    }

    public class PalindromeService : IPalindromeService
    {
        public bool IsPalindrome(string input)
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
