using System.Diagnostics;

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
                        if (!string.IsNullOrEmpty(currentNumberString))
                        {
                            Debug.WriteLine($"Current number string: {currentNumberString}; IsValid: {currentNumberIsValid}");
                        }
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
