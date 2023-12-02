using System.Reflection.Metadata.Ecma335;

namespace AdventofCSharp_2023
{
    public static class Day2
    {
        public static int SumOfPossibleIds(IEnumerable<string> games)
        {
            int sum = 0;

            //go through each line

            foreach (var game in games)
            {
                if(string.IsNullOrEmpty(game)) continue;
                bool invalidGame = false;

                //split string by :
                var gameDetails = game.Split(':');

                if(gameDetails.Length != 2) continue;
                
                //extract game id
                var gameId = GetGameId(gameDetails[0]);

                //split right side by ;
                var handsShown = gameDetails[1].Split(";");

                //loop through hands shown
                foreach(var hand in handsShown)
                {
                    //split by space
                    var diceShown = hand.Trim().Split(" ");

                    for(int i = 0; i < diceShown.Length - 1; i += 2)
                    {
                        var colorCount = GetColorAndCount(diceShown[i], diceShown[i + 1]);

                        //if number of color is greater than allowable, invalid game
                        if (!_allowableCounts.ContainsKey(colorCount.Item1) || colorCount.Item2 > _allowableCounts[colorCount.Item1])
                        {
                            invalidGame = true;
                            break;
                        }
                    }

                    if (invalidGame) break;
                }

                //add game id to sum if valid
                if(!invalidGame)
                {
                    sum += gameId;
                }

            }

            return sum;
        }

        public static int SumOfPowers(IEnumerable<string> games)
        {
            int sum = 0;

            foreach (var game in games)
            {
                if (string.IsNullOrEmpty(game)) continue;

                var gameDetails = game.Split(':');

                if (gameDetails.Length != 2) continue;

                var handsShown = gameDetails[1].Split(";");

                var maxRed = 0;
                var maxGreen = 0;
                var maxBlue = 0;
            
                foreach (var hand in handsShown)
                {
                    var diceShown = hand.Trim().Split(" ");

                    for (int i = 0; i < diceShown.Length - 1; i += 2)
                    {
                        var colorCount = GetColorAndCount(diceShown[i], diceShown[i + 1]);

                        if(string.IsNullOrEmpty(colorCount.Item1) || colorCount.Item2 < 0) continue;

                        switch(colorCount.Item1)
                        {
                            case "red":
                                maxRed = Math.Max(maxRed, colorCount.Item2);
                                break;
                            case "green":
                                maxGreen = Math.Max(maxGreen, colorCount.Item2);
                                break;
                            case "blue":
                                maxBlue = Math.Max(maxBlue, colorCount.Item2);
                                break;
                        }
                    }
                }
                var power = maxRed * maxGreen * maxBlue;
                sum += power;
            }

            return sum;
        }

        private static Tuple<string, int> GetColorAndCount(string countString, string colorString)
        {
            var count = int.Parse(countString);

            var color = colorString;
            var commaIndex = color.IndexOf(',');

            if (commaIndex >= 0)
            {
                color = color.Remove(commaIndex, 1);
            }

            return new Tuple<string, int>(color, count);
        }

        private static int GetGameId(string gameIdString)
        {
            gameIdString = gameIdString.Split(" ").Last();

            if (string.IsNullOrEmpty(gameIdString)) return -1;

            return int.Parse(gameIdString);
        }

        private static Dictionary<string, int> _allowableCounts = new Dictionary<string, int>()
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };
    }
}
