using AdventofCSharp_2023;

namespace AdventofCSharp2023_Tests
{
    public class Day6Tests
    {
        [Test]
        public void Day6SampleInput()
        {
            var input = new List<string>()
            {
                "Time:      7  15   30",
                "Distance:  9  40  200",
            };

            var ret = Day6.PossibleWaysToWin(input);

            Assert.That(ret, Is.EqualTo(288));
        }

        [Test]
        public void Day6Input()
        {
            var input = new List<string>()
            {
                "Time:        46     85     75     82",
                "Distance:   208   1412   1257   1410",
            };

            var answer = Day6.PossibleWaysToWin(input);

            Assert.True(true);
        }

        [Test]
        public void Day6SampleInputPart2()
        {
            var input = new List<string>()
            {
                "Time:      7  15   30",
                "Distance:  9  40  200",
            };

            var ret = Day6.PossibleWaysToWinWithKerning(input);

            Assert.That(ret, Is.EqualTo(71503));
        }

        [Test]
        public void Day6InputPart2()
        {
            var input = new List<string>()
            {
                "Time:        46     85     75     82",
                "Distance:   208   1412   1257   1410",
            };

            var answer = Day6.PossibleWaysToWinWithKerning(input);

            Assert.True(true);
        }
    }
}
