using System;
using System.Net.Http.Headers;
using System.Reflection.Emit;

namespace AdventofCSharp_2023
{
    public static class Day5
    {
        public static long ClosestSeedLocation(List<string> almanac)
        {
            var seeds = almanac.First().Split(':').Last().Trim().Split(" ").Select(i => long.Parse(i)).ToList();

            int currentLine = 3;

            //Extract Seed to soil map
            List<MapInfo> seedToSoilMap = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract soil to fertilizer map
            List<MapInfo> soilToFertilizer = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract fertilizer to water map
            List<MapInfo> fertilizerToWaterMap = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract water to light map
            List<MapInfo> waterToLightMap = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract light to temperature map
            List<MapInfo> lightToTemperature = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract temperature to humidity map
            List<MapInfo> temperatureToHumidity = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract humidity to location map
            List<MapInfo> humidityToLocation = GetMapInfo(almanac, currentLine, out currentLine);

            var closestLocation = long.MaxValue;
            foreach (var seed in seeds)
            {
                var soilId = FindId(seedToSoilMap, seed);
                var fertilizerId = FindId(soilToFertilizer, soilId);
                var waterId = FindId(fertilizerToWaterMap, fertilizerId);
                var lightId = FindId(waterToLightMap, waterId);
                var tempId = FindId(lightToTemperature, lightId);
                var humidityId = FindId(temperatureToHumidity, tempId);
                var locationId = FindId(humidityToLocation, humidityId);

                closestLocation = Math.Min(closestLocation, locationId);
            }

            return closestLocation;
        }

        public static long ClosestSeedLocationV2(List<string> almanac)
        {
            var seeds = almanac.First().Split(':').Last().Trim().Split(" ").Select(i => long.Parse(i)).ToList();

            int currentLine = 3;

            //Extract Seed to soil map
            List<MapInfo> seedToSoilMap = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract soil to fertilizer map
            List<MapInfo> soilToFertilizerMap = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract fertilizer to water map
            List<MapInfo> fertilizerToWaterMap = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract water to light map
            List<MapInfo> waterToLightMap = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract light to temperature map
            List<MapInfo> lightToTemperature = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract temperature to humidity map
            List<MapInfo> temperatureToHumidity = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract humidity to location map
            List<MapInfo> humidityToLocation = GetMapInfo(almanac, currentLine, out currentLine);

            var humidityRanges = GetMapRanges(humidityToLocation, null);
            var tempRanges = GetMapRanges(temperatureToHumidity, humidityRanges);
            var lightRanges = GetMapRanges(lightToTemperature, tempRanges);
            var waterRanges = GetMapRanges(waterToLightMap, lightRanges);
            var fertilizerRanges = GetMapRanges(fertilizerToWaterMap, waterRanges);
            var soilRanges = GetMapRanges(soilToFertilizerMap, fertilizerRanges);
            var seedRanges = GetMapRanges(seedToSoilMap, soilRanges);

            var seedsInLowestRange = new List<long>();

            foreach (var range in seedRanges)
            {
                foreach (var seed in seeds)
                {
                    if (seed >= range.Item1 && seed <= range.Item2)
                    {
                        seedsInLowestRange.Add(seed);
                    }
                }

                if (seedsInLowestRange.Count > 0)
                    break;
            }

            var closestLocation = long.MaxValue;
            foreach (var seed in seedsInLowestRange)
            {
                var soilId = FindId(seedToSoilMap, seed);
                var fertilizerId = FindId(soilToFertilizerMap, soilId);
                var waterId = FindId(fertilizerToWaterMap, fertilizerId);
                var lightId = FindId(waterToLightMap, waterId);
                var tempId = FindId(lightToTemperature, lightId);
                var humidityId = FindId(temperatureToHumidity, tempId);
                var locationId = FindId(humidityToLocation, humidityId);

                closestLocation = Math.Min(closestLocation, locationId);
            }

            return closestLocation;
        }

        public static long ClosestSeedLocationWithSeedRange(List<string> almanac)
        {
            var seeds = almanac.First().Split(':').Last().Trim().Split(" ").Select(i => long.Parse(i)).ToList();
            var seedRanges = new List<Tuple<long, long>>();

            for (int i = 0; i < seeds.Count; i += 2)
            {
                seedRanges.Add(new Tuple<long, long>(seeds[i], seeds[i] + seeds[i + 1] - 1));
            }

            int currentLine = 3;

            //Extract Seed to soil map
            List<MapInfo> seedToSoilMap = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract soil to fertilizer map
            List<MapInfo> soilToFertilizerMap = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract fertilizer to water map
            List<MapInfo> fertilizerToWaterMap = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract water to light map
            List<MapInfo> waterToLightMap = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract light to temperature map
            List<MapInfo> lightToTemperature = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract temperature to humidity map
            List<MapInfo> temperatureToHumidity = GetMapInfo(almanac, currentLine, out currentLine);

            currentLine += 2;
            //Extract humidity to location map
            List<MapInfo> humidityToLocation = GetMapInfo(almanac, currentLine, out currentLine);

            var humidityRanges = GetMapRanges(humidityToLocation, null);
            var tempRanges = GetMapRanges(temperatureToHumidity, humidityRanges);
            var lightRanges = GetMapRanges(lightToTemperature, tempRanges);
            var waterRanges = GetMapRanges(waterToLightMap, lightRanges);
            var fertilizerRanges = GetMapRanges(fertilizerToWaterMap, waterRanges);
            var soilRanges = GetMapRanges(soilToFertilizerMap, fertilizerRanges);
            var idealSeedRanges = GetMapRanges(seedToSoilMap, soilRanges);

            var seedsInLowestRange = new List<long>();

            foreach(var range in idealSeedRanges)
            {
                foreach(var seedRange in seedRanges)
                {
                    if(seedRange.Item1 >= range.Item1 && seedRange.Item1 <= range.Item2)
                    {
                        seedsInLowestRange.Add(seedRange.Item1);
                    } else if(seedRange.Item1 <= range.Item1 && seedRange.Item2 >= range.Item1)
                    {
                        seedsInLowestRange.Add(range.Item1);
                    }
                }

                if (seedsInLowestRange.Count > 0)
                    break;
            }

            var closestLocation = long.MaxValue;
            foreach (var seed in seedsInLowestRange)
            {
                var soilId = FindId(seedToSoilMap, seed);
                var fertilizerId = FindId(soilToFertilizerMap, soilId);
                var waterId = FindId(fertilizerToWaterMap, fertilizerId);
                var lightId = FindId(waterToLightMap, waterId);
                var tempId = FindId(lightToTemperature, lightId);
                var humidityId = FindId(temperatureToHumidity, tempId);
                var locationId = FindId(humidityToLocation, humidityId);

                closestLocation = Math.Min(closestLocation, locationId);
            }

            return closestLocation;
        }

        private static List<Tuple<long, long>> GetMapRanges(List<MapInfo> mapInfoList, List<Tuple<long, long>>? previousMap)
        {
            mapInfoList = mapInfoList.OrderBy(mi => mi.DestinationStart).ToList();

            List<Tuple<long, long>> ranges = new List<Tuple<long, long>>();
            if (previousMap == null)
            {
                var end = long.MinValue;
                if (mapInfoList[0].DestinationStart > 0)
                {
                    ranges.Add(new Tuple<long, long>(0, mapInfoList[0].DestinationStart - 1));
                    end = mapInfoList[0].DestinationStart - 1;
                }

                foreach (var mapInfo in mapInfoList)
                {
                    ranges.Add(new Tuple<long, long>(mapInfo.SourceStart, mapInfo.SourceStart + mapInfo.Length - 1));

                    end = Math.Max(end, mapInfo.SourceStart + mapInfo.Length - 1);
                }

                ranges.Add(new Tuple<long, long>(end + 1, long.MaxValue));
            }
            else
            {
                var maxValueUsed = long.MinValue;
                foreach (var range in previousMap)
                {
                    var currentStart = range.Item1;
                    var currentEnd = range.Item2;
                    foreach (var map in mapInfoList)
                    {
                        if (map.DestinationStart <= currentStart && currentStart <= (map.DestinationStart + map.Length))
                        {
                            var distance = currentStart - map.DestinationStart;
                            var availableLength = map.Length - distance;
                            if(availableLength == 0)
                            {
                                break;
                            }
                            if (currentStart + availableLength - 1 <= currentEnd)
                            {
                                var newRange = new Tuple<long, long>(map.SourceStart + distance, map.SourceStart + distance + availableLength - 1);
                                ranges.Add(newRange);
                                maxValueUsed = Math.Max(maxValueUsed, newRange.Item2);

                                currentStart = currentStart + availableLength;

                                if(currentEnd <= currentStart)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                var takenlength = currentEnd - currentStart;

                                var newRange = new Tuple<long, long>(map.SourceStart + distance, map.SourceStart + distance + takenlength);
                                currentStart += takenlength + 1;
                                ranges.Add(newRange);
                                maxValueUsed = Math.Max(maxValueUsed, newRange.Item2);
                                break;

                            }
                        }
                        else if (map.DestinationStart <= currentEnd && currentEnd <= (map.DestinationStart + map.Length))
                        {
                            var length = currentEnd - map.DestinationStart;
                            var newRange = new Tuple<long, long>(map.SourceStart, map.SourceStart + length);
                            ranges.Add(newRange);
                            maxValueUsed = Math.Max(maxValueUsed, newRange.Item2);

                            currentEnd = map.DestinationStart - 1;
                        }
                    } 

                    if (currentStart == range.Item1)
                    {
                        ranges.Add(new Tuple<long, long>(currentStart, currentEnd));
                        maxValueUsed = Math.Max(maxValueUsed, currentEnd);
                    }
                }

                if(ranges.Last().Item2 != long.MaxValue)
                {
                    var maxRange = new Tuple<long, long>(maxValueUsed + 1, long.MaxValue);
                    ranges.Add(maxRange);
                }
            }

            return ranges;
        }

        //private static List<Tuple<long, long>> FindIdWithRange(List<MapInfo> mapInfo, Tuple<long, long> range)
        //{
        //    var ret = new List<Tuple<long, long>>();
        //    foreach (var map in mapInfo)
        //    {
        //        if (range.Item1 >= map.SourceStart)
        //        {
        //            if(range.Item1 <= (map.SourceStart + map.Length))
        //            {
        //                ret.Add(new Tuple<long, long>(map.sou, range.Item2));
        //            }
        //            seedsInLowestRange.Add(seedRange.Item1);
        //        }
        //        else if (seedRange.Item1 <= range.Item1 && seedRange.Item2 >= range.Item1)
        //        {
        //            seedsInLowestRange.Add(range.Item1);
        //        }
        //        if (previousId >= map.SourceStart)
        //        {
        //            if (previousId < map.SourceStart + map.Length)
        //            {
        //                ret = map.DestinationStart + (previousId - map.SourceStart);
        //            }
        //        }
        //        else break;
        //    }

        //    return ret;
        //}

        private static long FindId(List<MapInfo> mapInfo, long previousId)
        {
            long ret = previousId;
            foreach (var map in mapInfo)
            {
                if (previousId >= map.SourceStart)
                {
                    if (previousId < map.SourceStart + map.Length)
                    {
                        ret = map.DestinationStart + (previousId - map.SourceStart);
                    }
                }
                else break;
            }

            return ret;
        }

        private static List<MapInfo> GetMapInfo(List<string> almanac, int currentLine, out int lastLine)
        {
            var ret = new List<MapInfo>();
            while (currentLine < almanac.Count && !string.IsNullOrEmpty(almanac[currentLine]) && Char.IsNumber(almanac[currentLine][0]))
            {
                var toInt = almanac[currentLine].Split(" ").Select(i => long.Parse(i)).ToList();

                var mapInfo = new MapInfo()
                {
                    DestinationStart = toInt[0],
                    SourceStart = toInt[1],
                    Length = toInt[2]
                };
                ret.Add(mapInfo);
                currentLine++;
            }

            lastLine = currentLine;

            return ret.OrderBy(mi => mi.SourceStart).ToList();
        }

        private class MapInfo
        {
            public long DestinationStart { get; set; }
            public long SourceStart { get; set; }
            public long Length { get; set; }
        }
    }
}
