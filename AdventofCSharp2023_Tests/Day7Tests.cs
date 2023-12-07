using AdventofCSharp_2023;

namespace AdventofCSharp2023_Tests
{
    public class Day7Tests
    {
        [Test]
        public void Day7SampleInput()
        {
            var input = new List<string>()
            {
                "32T3K 765",
                "T55J5 684",
                "KK677 28 ",
                "KTJJT 220",
                "QQQJA 483",
            };

            var ret = Day7.CalculateTotalWinnings(input);

            Assert.That(ret, Is.EqualTo(6440));
        }

        [Test]
        public void Day7Input()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day7", "Day7Input.txt");
            var input = File.ReadLines(path).ToList();

            var answer = Day7.CalculateTotalWinnings(input);

            Assert.True(true);
        }

        [Test]
        public void Day7SampleInputPart2()
        {
            var input = new List<string>()
            {
                "32T3K 765",
                "T55J5 684",
                "KK677 28 ",
                "KTJJT 220",
                "QQQJA 483",
            };

            var ret = Day7.CalculateTotalWinningsWithJokers(input);

            Assert.That(ret, Is.EqualTo(5905));
        }

        [Test]
        public void Day7InputPart2()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day7", "Day7Input.txt");
            var input = File.ReadLines(path).ToList();

            var answer = Day7.CalculateTotalWinningsWithJokers(input);

            Assert.True(true);
        }
    }
}
