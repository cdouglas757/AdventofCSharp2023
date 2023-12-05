using AdventofCSharp_2023;

namespace AdventofCSharp2023_Tests
{
    public class Day5Tests
    {

        [Test]
        public void Day5SampleInput()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day5", "SampleInput.txt");
            var input = File.ReadLines(path).ToList();

            var ret = Day5.ClosestSeedLocation(input);

            Assert.That(ret, Is.EqualTo(35));
        }

        [Test]
        public void Day5InputTest()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day5", "Day5Input.txt");
            var input = File.ReadLines(path).ToList();

            var answer = Day5.ClosestSeedLocation(input);

            Assert.True(true);
        }

        [Test]
        public void Day5SampleInputV2()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day5", "SampleInput.txt");
            var input = File.ReadLines(path).ToList();

            var ret = Day5.ClosestSeedLocationV2(input);

            Assert.That(ret, Is.EqualTo(35));
        }

        [Test]
        public void Day5SampleInputPart2()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day5", "SampleInput.txt");
            var input = File.ReadLines(path).ToList();

            var ret = Day5.ClosestSeedLocationWithSeedRange(input);

            Assert.That(ret, Is.EqualTo(46));
        }

        [Test]
        public void Day5InputTestPart2()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day5", "Day5Input.txt");
            var input = File.ReadLines(path).ToList();

            var answer = Day5.ClosestSeedLocationWithSeedRange(input);

            Assert.True(true);
        }
    }
}
