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
                var gameIdString = gameDetails[0].Split(" ").Last();
                if(string.IsNullOrEmpty(gameIdString) ) continue;
                var gameId = int.Parse(gameIdString);

                //split right side by ;
                var handsShown = gameDetails[1].Split(";");

                //loop through hands shown
                foreach(var hand in handsShown)
                {
                    //split by space
                    var diceShown = hand.Trim().Split(" ");

                    for(int i = 0; i < diceShown.Length - 1; i += 2)
                    {
                        var count = int.Parse(diceShown[i]);
                        var color = diceShown[i + 1];
                        var commaIndex = color.IndexOf(',');

                        if(commaIndex >= 0 )
                        {
                            color = color.Remove(commaIndex, 1);
                        }

                        //if number of color is greater than allowable, invalid game
                        if (!_allowableCounts.ContainsKey(color) || count > _allowableCounts[color])
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

        private static Dictionary<string, int> _allowableCounts = new Dictionary<string, int>()
        {
            { "red", 12 },
            { "green", 13 },
            { "blue", 14 }
        };
    }
}
