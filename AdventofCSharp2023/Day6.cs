namespace AdventofCSharp_2023
{
    public static class Day6
    {
        public static int PossibleWaysToWin(IEnumerable<string> races)
        {
            var totalPossibilities = 0;
            var times = races.First().Split(':').Last().Trim().Split(" ").Where(t => !string.IsNullOrEmpty(t)).Select(t => int.Parse(t)).ToList();
            var distances = races.Last().Split(':').Last().Trim().Split(" ").Where(t => !string.IsNullOrEmpty(t)).Select(t => int.Parse(t)).ToList();

            for (var i = 0; i < times.Count; i++)
            {
                var availableTime = times[i];
                var bestDistance = distances[i];

                var winningPossibilities = 0;
                for(int j = 1; j <= availableTime / 2; j++)
                {
                    var distance = j * (availableTime - j);

                    if(distance > bestDistance)
                    {
                        winningPossibilities++;
                    }
                }

                winningPossibilities = availableTime % 2 == 0 ? winningPossibilities * 2 - 1 : winningPossibilities * 2;

                if (totalPossibilities == 0)
                {
                    totalPossibilities = winningPossibilities;
                } else
                {
                    totalPossibilities *= winningPossibilities;
                }
            }

            return totalPossibilities;
        }

        public static int PossibleWaysToWinWithKerning(IEnumerable<string> races)
        {
            var totalPossibilities = 0;
            var timeString = string.Join("", races.First().Split(':').Last().Trim().Split(" ").Where(t => !string.IsNullOrEmpty(t)));
            var distanceString = string.Join("", races.Last().Split(':').Last().Trim().Split(" ").Where(t => !string.IsNullOrEmpty(t)));
            if (string.IsNullOrEmpty(timeString) || string.IsNullOrEmpty(distanceString))
                return -1;
            var availableTime = long.Parse(timeString);
            var bestDistance = long.Parse(distanceString);


            var winningPossibilities = 0;
            for (int j = 1; j <= availableTime / 2; j++)
            {
                var distance = j * (availableTime - j);

                if (distance > bestDistance)
                {
                    winningPossibilities++;
                }
            }

            winningPossibilities = availableTime % 2 == 0 ? winningPossibilities * 2 - 1 : winningPossibilities * 2;

            if (totalPossibilities == 0)
            {
                totalPossibilities = winningPossibilities;
            }
            else
            {
                totalPossibilities *= winningPossibilities;
            }

            return totalPossibilities;
        }
    }
}
