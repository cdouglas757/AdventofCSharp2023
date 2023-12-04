namespace AdventofCSharp_2023
{
    public static class Day4
    {
        public static int SumOfWinningCardValues(IEnumerable<string> cards)
        {
            var sum = 0;
            foreach (var card in cards)
            {
                var numbers = card.Split(':')[1].Split("|");

                var winningNumbers = numbers[0].Trim().Split(" ").Where(i => !string.IsNullOrEmpty(i)).Select(i => int.Parse(i)).ToList();
                var playingNumbers = numbers[1].Trim().Split(" ").Where(i => !string.IsNullOrEmpty(i)).Select(i => int.Parse(i)).ToList();

                var cardValue = 0;
                foreach(var number in playingNumbers)
                {
                    if (winningNumbers.Contains(number))
                    {
                        if (cardValue == 0)
                        {
                            cardValue = 1;
                            continue;
                        }

                        cardValue *= 2;
                    }
                }

                sum += cardValue;
            }

            return sum;
        }
    }
}
