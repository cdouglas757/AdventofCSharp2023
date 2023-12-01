namespace AdventofCSharp_2023
{
    public static class Day1
    {
        public static int SumOfCalibrationValues(IEnumerable<string> calibrationInput)
        {
            int sum = 0;

            foreach (var input in calibrationInput)
            {
                if (string.IsNullOrEmpty(input))
                {
                    continue;
                }

                int toAdd = 0;

                int? firstDigit = null;
                int? firstIndex = null;
                for(int i = 0; i < input.Length; i++)
                {
                    if (Char.IsNumber(input[i]))
                    {
                        firstDigit = input[i] - '0';
                        firstIndex = i;
                        break;
                    }
                }

                if (firstDigit == null || firstIndex == null)
                {
                    continue;
                }

                if (firstIndex == input.Length)
                {
                    toAdd = (firstDigit.Value * 10) + firstDigit.Value;
                    sum += toAdd;
                    continue;
                }

                int? secondDigit = null;
                for (int i = input.Length - 1; i > firstIndex.Value; i--)
                {
                    if (Char.IsNumber(input[i]))
                    {
                        secondDigit = input[i] - '0';
                        break;
                    }
                }

                if (secondDigit == null)
                {
                    secondDigit = firstDigit;
                }

                toAdd = (firstDigit.Value * 10) + secondDigit.Value;
                sum += toAdd;
            }

            return sum;
        }
    }
}
