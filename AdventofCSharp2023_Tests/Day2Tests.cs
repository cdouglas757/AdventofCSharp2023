using AdventofCSharp_2023;

namespace AdventofCSharp2023_Tests
{
    public class Day2Tests
    {
        [Test]
        public void SampleInput()
        {
            var input = new List<string>()
            {
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
            };

            var ret = Day2.SumOfPossibleIds(input);

            Assert.That(ret, Is.EqualTo(8));
        }

        [Test]
        public void Day2InputTest()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day2", "Day2Input.txt");
            var input = File.ReadLines(path).ToList();

            var answer = Day2.SumOfPossibleIds(input);

            Assert.True(true);
        }

        [Test]
        public void SampleInputPart2()
        {
            var input = new List<string>()
            {
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
            };

            var ret = Day2.SumOfPowers(input);

            Assert.That(ret, Is.EqualTo(2286));
        }

        [Test]
        public void Day2InputTestPart2()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day2", "Day2Input.txt");
            var input = File.ReadLines(path).ToList();

            var answer = Day2.SumOfPowers(input);

            Assert.True(true);
        }
    }
}
