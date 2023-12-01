namespace AdventofCSharp_2023
{
    public static class Day1
    {
        public static int SumOfCalibrationValuesDigitsOnly(IEnumerable<string> calibrationInput)
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
                for (int i = 0; i < input.Length; i++)
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
                for (int i = 0; i < input.Length; i++)
                {
                    if (Char.IsNumber(input[i]))
                    {
                        firstDigit = input[i] - '0';
                        firstIndex = i;
                        break;
                    }

                    for (int j = i; j >= 0; j--)
                    {
                        var word = input.Substring(j, (i - j) + 1);
                        if (wordToIntDictionary.ContainsKey(word))
                        {
                            firstDigit = wordToIntDictionary[word];
                            firstIndex = j;
                            break;
                        }
                    }

                    if (firstDigit != null)
                    {
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

                    for (int j = input.Length - 1; j >= i; j--)
                    {
                        var word = input.Substring(i, (j - i) + 1);
                        if (wordToIntDictionary.ContainsKey(word))
                        {
                            secondDigit = wordToIntDictionary[word];
                            break;
                        }
                    }

                    if (secondDigit != null)
                    {
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

        private static Dictionary<string, int> wordToIntDictionary = new Dictionary<string, int>()
        {
            { "zero", 0 },
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
        };
    }

}
