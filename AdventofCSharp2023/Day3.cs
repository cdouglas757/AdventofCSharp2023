using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AdventofCSharp_2023
{
    public static class Day3
    {

        public static int SumOfPartNumbers(List<string> lines)
        {
            int sum = 0;
            for(int i = 0; i < lines.Count; i++)
            {
                string currentNumberString = string.Empty;
                bool currentNumberIsValid = false;

                for(int charIdx = 0; charIdx < lines[i].Length; charIdx++) 
                { 
                    if (Char.IsNumber(lines[i][charIdx]))
                    {
                        currentNumberString += lines[i][charIdx];

                        if(!currentNumberIsValid)
                        {
                            currentNumberIsValid = HasAdjacentSymbol(lines, i, charIdx);
                        }
                    } 

                    if(!Char.IsNumber(lines[i][charIdx]) || charIdx == lines[i].Length - 1)
                    {
                        //if (!string.IsNullOrEmpty(currentNumberString))
                        //{
                        //    Debug.WriteLine($"Current number string: {currentNumberString}; IsValid: {currentNumberIsValid}");
                        //}
                        if(!string.IsNullOrEmpty(currentNumberString) && currentNumberIsValid)
                        {
                            sum += int.Parse(currentNumberString);
                        }

                        currentNumberString = string.Empty;
                        currentNumberIsValid = false;
                    }
                }
            }
            return sum;
        }

        public static int SumOfPartNumbersV2(List<string> lines)
        {
            var linesArray = lines.Select(i => i.ToArray()).ToArray();
            int sum = 0;
            for (int i = 0; i < linesArray.Length; i++)
            {
                for (int charIdx = 0; charIdx < linesArray[i].Length; charIdx++)
                {
                    if (!Char.IsNumber(linesArray[i][charIdx]) && linesArray[i][charIdx] != '.')
                    {
                        var adjacentNumbers = GetAdjacentNumbers(linesArray, i, charIdx);

                        sum += adjacentNumbers.Sum();
                    }
                }
            }
            return sum;
        }

        public static int SumOfGears(List<string> lines)
        {
            var linesArray = lines.Select(i => i.ToArray()).ToArray();
            int sum = 0;
            for (int i = 0; i < linesArray.Length; i++)
            {
                for (int charIdx = 0; charIdx < linesArray[i].Length; charIdx++)
                {
                    if (linesArray[i][charIdx] == '*')
                    {
                        var adjacentNumbers = GetAdjacentNumbers(linesArray, i, charIdx);

                        if(adjacentNumbers.Count() == 2)
                        {
                            sum += adjacentNumbers.Aggregate((x, y) => x * y);
                        }
                    }
                }
            }
            return sum;
        }

        private static List<int> GetAdjacentNumbers(char[][] lines, int lineIdx, int charIdx)
        {
            var ret = new List<int>();

            var directions = new List<Tuple<int, int>>()
            {
                new Tuple<int, int>(-1, 0),
                new Tuple<int, int>(-1, -1),
                new Tuple<int, int>(-1, 1),
                new Tuple<int, int>(0, -1),
                new Tuple<int, int>(0, 1),
                new Tuple<int, int>(1, 0),
                new Tuple<int, int>(1, -1),
                new Tuple<int, int>(1, 1),
            };

            foreach(var direction in directions)
            {
                var lidx = lineIdx + direction.Item1;
                var cidx = charIdx + direction.Item2;

                if(lidx >= 0 && lidx < lines.Length && cidx >= 0 && cidx < lines[lidx].Length)
                {
                    if (Char.IsNumber(lines[lidx][cidx]))
                    {
                        ret.Add(GetFullNumber(lines, lidx, cidx));
                    }
                }
            }

            return ret;
        }

        private static int GetFullNumber(char[][] lines, int lineIdx, int charIdx)
        {
            var currIdx = charIdx;

            while (currIdx >= 0 && Char.IsNumber(lines[lineIdx][currIdx]))
            {
                currIdx--;
            }
            currIdx++;

            var currentNumberString = string.Empty;
            while (currIdx < lines[lineIdx].Length && Char.IsNumber(lines[lineIdx][currIdx]))
            {
                currentNumberString += lines[lineIdx][currIdx];
                lines[lineIdx][currIdx] = '.';

                currIdx++;
            }

            return int.Parse(currentNumberString);
        }

        private static bool HasAdjacentSymbol(List<string> lines, int lineIdx, int charIdx)
        {
            if (lineIdx != 0)
            {
                //check up
                if (!Char.IsNumber(lines[lineIdx - 1][charIdx]) && lines[lineIdx - 1][charIdx] != '.')
                {
                    return true;
                }

                //up left
                if(charIdx != 0)
                {
                    if (!Char.IsNumber(lines[lineIdx - 1][charIdx - 1]) && lines[lineIdx - 1][charIdx - 1] != '.')
                    {
                        return true;
                    }
                }

                //up right
                if(charIdx != lines[0].Length - 1)
                {
                    if (!Char.IsNumber(lines[lineIdx - 1][charIdx + 1]) && lines[lineIdx - 1][charIdx + 1] != '.')
                    {
                        return true;
                    }
                }    
            }

            //left
            if(charIdx != 0)
            {
                if (!Char.IsNumber(lines[lineIdx][charIdx - 1]) && lines[lineIdx][charIdx - 1] != '.')
                {
                    return true;
                }
            }

            //right
            if (charIdx != lines[0].Length - 1)
            {
                if (!Char.IsNumber(lines[lineIdx][charIdx + 1]) && lines[lineIdx][charIdx + 1] != '.')
                {
                    return true;
                }
            }

            if (lineIdx != lines.Count - 1)
            {
                //check down
                if (!Char.IsNumber(lines[lineIdx + 1][charIdx]) && lines[lineIdx + 1][charIdx] != '.')
                {
                    return true;
                }

                //down left
                if (charIdx != 0)
                {
                    if (!Char.IsNumber(lines[lineIdx + 1][charIdx - 1]) && lines[lineIdx + 1][charIdx - 1] != '.')
                    {
                        return true;
                    }
                }

                //down right
                if (charIdx != lines[0].Length - 1)
                {
                    if (!Char.IsNumber(lines[lineIdx + 1][charIdx + 1]) && lines[lineIdx + 1][charIdx + 1] != '.')
                    {
                        return true;
                    }
                }
            }


            return false;
        }

    }
}
