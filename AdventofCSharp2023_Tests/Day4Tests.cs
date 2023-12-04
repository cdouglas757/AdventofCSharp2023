using AdventofCSharp_2023;

namespace AdventofCSharp2023_Tests
{
    public class Day4Tests
    {
        [Test]
        public void Day4SampleInput()
        {
            var input = new List<string>()
            {
                "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
                "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
                "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
                "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
                "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
                "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
            };

            var ret = Day4.SumOfWinningCardValues(input);

            Assert.That(ret, Is.EqualTo(13));
        }

        [Test]
        public void Day4InputTest()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day4", "Day4Input.txt");
            var input = File.ReadLines(path).ToList();

            var answer = Day4.SumOfWinningCardValues(input);

            Assert.True(true);
        }

        [Test]
        public void Day4SampleInputPart2()
        {
            var input = new List<string>()
            {
                "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
                "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
                "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
                "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
                "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
                "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11",
            };

            var ret = Day4.SumOfTotalCardsAfterWinning(input);

            Assert.That(ret, Is.EqualTo(30));
        }

        [Test]
        public void Day4InputTestPart2()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day4", "Day4Input.txt");
            var input = File.ReadLines(path).ToList();

            var answer = Day4.SumOfTotalCardsAfterWinning(input);

            Assert.True(true);
        }
    }
}
