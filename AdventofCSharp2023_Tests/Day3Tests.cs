using AdventofCSharp_2023;

namespace AdventofCSharp2023_Tests
{
    public class Day3Tests
    {
        [Test]
        public void SampleInput()
        {
            var input = new List<string>()
            {
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598.."
            };

            var ret = Day3.SumOfPartNumbers(input);

            Assert.That(ret, Is.EqualTo(4361));
        }

        public void SampleInputV2()
        {
            var input = new List<string>()
            {
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598.."
            };

            var ret = Day3.SumOfPartNumbersV2(input);

            Assert.That(ret, Is.EqualTo(4361));
        }

        [Test]
        public void Day3InputTest()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day3", "Day3Input.txt");
            var input = File.ReadLines(path).ToList();

            var answer = Day3.SumOfPartNumbers(input);

            Assert.True(true);
        }

        [Test]
        public void SampleInputPart2()
        {
            var input = new List<string>()
            {
                "467..114..",
                "...*......",
                "..35..633.",
                "......#...",
                "617*......",
                ".....+.58.",
                "..592.....",
                "......755.",
                "...$.*....",
                ".664.598.."
            };

            var ret = Day3.SumOfGears(input);

            Assert.That(ret, Is.EqualTo(467835));
        }

        [Test]
        public void Day3InputTestPart2()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day3", "Day3Input.txt");
            var input = File.ReadLines(path).ToList();

            var answer = Day3.SumOfGears(input);

            Assert.True(true);
        }
    }

}
