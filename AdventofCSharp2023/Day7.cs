namespace AdventofCSharp_2023
{
    public static class Day7
    {
        public static int CalculateTotalWinnings(IEnumerable<string> hands)
        {
            int totalWinnings = 0;
            var listOfHands = new List<PokerHand>();
            foreach (var hand in hands)
            {
                listOfHands.Add(new PokerHand(hand, false));
            }

            var handGroups = listOfHands.OrderBy(h => h.HandType).GroupBy(h => h.HandType);

            int winningValue = 1;

            foreach (var handGroup in handGroups)
            {
                foreach (var hand in handGroup.OrderBy(h => h.Cards, new PokerHandComparer()))
                {
                    totalWinnings += hand.BetAmount * winningValue;
                    winningValue++;
                }
            }

            return totalWinnings;
        }

        public static int CalculateTotalWinningsWithJokers(IEnumerable<string> hands)
        {
            int totalWinnings = 0;
            var listOfHands = new List<PokerHand>();
            foreach (var hand in hands)
            {
                listOfHands.Add(new PokerHand(hand, true));
            }

            var handGroups = listOfHands.OrderBy(h => h.HandType).GroupBy(h => h.HandType);

            int winningValue = 1;

            foreach (var handGroup in handGroups)
            {
                foreach (var hand in handGroup.OrderBy(h => h.Cards, new PokerHandComparerWithJokers()))
                {
                    totalWinnings += hand.BetAmount * winningValue;
                    winningValue++;
                }
            }

            return totalWinnings;
        }

        private class PokerHand()
        {
            public List<char>? Cards { get; private set; }
            public HandType HandType { get; private set; }
            public int BetAmount { get; private set; }
            public Dictionary<char, int> CardCount { get; private set; } = new Dictionary<char, int>();


            public PokerHand(string hand, bool useJokers)
                : this()
            {
                var handDetails = hand.Split(' ');
                BetAmount = int.Parse(handDetails[1]);

                Cards = handDetails[0].ToList();

                foreach (var c in Cards.OrderBy(c => GetCardValue(c)))
                {
                    if (!CardCount.ContainsKey(c))
                    {
                        CardCount.Add(c, 1);
                    }
                    else
                    {
                        CardCount[c]++;
                    }
                }

                CardCount = CardCount.OrderByDescending(cc => cc.Value).ToDictionary();

                if (useJokers)
                {
                    if (CardCount.Any(cc => cc.Key == 'J') && CardCount.Any(cc => cc.Key != 'J'))
                    {
                        var topKey = CardCount.Where(cc => cc.Key != 'J').First().Key;

                        CardCount[topKey] += CardCount['J'];
                        CardCount.Remove('J');
                    }
                }

                HandType = CardCount.Count switch
                {
                    5 => HandType.HighCard,
                    4 => HandType.OnePair,
                    3 => CardCount.First().Value == 3 ? HandType.ThreeOfAKind : HandType.TwoPair,
                    2 => CardCount.First().Value == 3 ? HandType.FullHouse : HandType.FourOfAKind,
                    1 => HandType.FiveOfAKind,
                    _ => throw new NotImplementedException()
                };

                //switch (HandType)
                //{
                //    case HandType.HighCard:
                //        var orderdCards = CardCount.OrderByDescending(cc => Day7.GetCardValue(cc.Key)).ToList();
                //        HighValue = GetCardValue(orderdCards[0].Key);
                //        break;
                //    case HandType.FiveOfAKind:
                //    case HandType.FourOfAKind:
                //        HighValue = GetCardValue(CardCount.First().Key);
                //        break;
                //    case HandType.TwoPair:
                //    case HandType.ThreeOfAKind:
                //    case HandType.OnePair:
                //        var orderedPairs = CardCount.Where(cc => cc.Value > 1).OrderByDescending(cc => Day7.GetCardValue(cc.Key)).ToList();
                //        HighValue = GetCardValue(orderedPairs[0].Key);
                //        if (orderedPairs.Count > 1)
                //        {
                //            SecondHighValue = GetCardValue(orderedPairs[1].Key);
                //        }
                //        else
                //        {
                //            var highCard = CardCount.Where(cc => cc.Value == 1).OrderByDescending(cc => GetCardValue(cc.Key)).First().Key;
                //            SecondHighValue = GetCardValue(highCard);
                //        }
                //        break;
                //    case HandType.FullHouse:
                //        HighValue = GetCardValue(CardCount.Where(cc => cc.Value == 3).First().Key);
                //        SecondHighValue = GetCardValue(CardCount.Where(cc => cc.Value == 2).First().Key);
                //        break;
                //};
            }
        }

        private static int GetCardValue(char card)
        {
            return card switch
            {
                '2' => 2,
                '3' => 3,
                '4' => 4,
                '5' => 5,
                '6' => 6,
                '7' => 7,
                '8' => 8,
                '9' => 9,
                'T' => 10,
                'J' => 11,
                'Q' => 12,
                'K' => 13,
                'A' => 14,
                _ => throw new NotImplementedException()
            };
        }

        private static int GetCardValueWithJoker(char card)
        {
            return card switch
            {
                'J' => 1,
                '2' => 2,
                '3' => 3,
                '4' => 4,
                '5' => 5,
                '6' => 6,
                '7' => 7,
                '8' => 8,
                '9' => 9,
                'T' => 10,
                'Q' => 12,
                'K' => 13,
                'A' => 14,
                _ => throw new NotImplementedException()
            };
        }

        private enum HandType
        {
            HighCard,
            OnePair,
            TwoPair,
            ThreeOfAKind,
            FullHouse,
            FourOfAKind,
            FiveOfAKind
        }

        public class PokerHandComparer : IComparer<IList<char>>
        {
            public int Compare(IList<char>? x, IList<char>? y)
            {
                if (x == null || y == null)
                    return 0;
                else if (x == null)
                    return -1;
                else if (y == null)
                    return 1;


                int idx = 0;

                while (idx < x.Count && x[idx] == y[idx])
                {
                    idx++;
                }

                if (idx == x.Count)
                {
                    return 0;
                }

                if (GetCardValue(x[idx]) > GetCardValue(y[idx]))
                    return 1;
                else
                    return -1;
            }
        }

        public class PokerHandComparerWithJokers : IComparer<IList<char>>
        {
            public int Compare(IList<char>? x, IList<char>? y)
            {
                if (x == null || y == null)
                    return 0;
                else if (x == null)
                    return -1;
                else if (y == null)
                    return 1;


                int idx = 0;

                while (idx < x.Count && x[idx] == y[idx])
                {
                    idx++;
                }

                if (idx == x.Count)
                {
                    return 0;
                }

                if (GetCardValueWithJoker(x[idx]) > GetCardValueWithJoker(y[idx]))
                    return 1;
                else
                    return -1;
            }
        }
    }
}
