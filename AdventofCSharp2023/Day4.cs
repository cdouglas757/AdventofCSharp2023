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

        public static int SumOfTotalCardsAfterWinning(IEnumerable<string> cards)
        {
            Dictionary<int, int> cardCount = new Dictionary<int, int>();
            foreach (var card in cards)
            {
                var cardInfo = card.Split(':');
                var cardId = int.Parse(cardInfo[0].Split(" ").Where(i => !string.IsNullOrEmpty(i)).Last());

                if (!cardCount.ContainsKey(cardId)) cardCount.Add(cardId, 1);
                else cardCount[cardId]++;

                var numbers = cardInfo[1].Split("|");

                var winningNumbers = numbers[0].Trim().Split(" ").Where(i => !string.IsNullOrEmpty(i)).Select(i => int.Parse(i)).ToList();
                var playingNumbers = numbers[1].Trim().Split(" ").Where(i => !string.IsNullOrEmpty(i)).Select(i => int.Parse(i)).ToList();

                var winningCount = 0;
                foreach (var number in playingNumbers)
                { 
                    if (winningNumbers.Contains(number))
                    {
                        winningCount++;
                    }
                }

                var wonCardId = cardId;
                var wonCardAmount = cardCount[cardId];
                for(int i = 0; i < winningCount; i++)
                {
                    wonCardId++;

                    if (!cardCount.ContainsKey(wonCardId)) cardCount.Add(wonCardId, wonCardAmount);
                    else cardCount[wonCardId] += wonCardAmount;
                }

            }

            return cardCount.Sum(cc => cc.Value);
        }
    }
}
