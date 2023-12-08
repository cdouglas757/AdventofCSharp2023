using AdventofCSharp_2023;

namespace AdventofCSharp2023_Tests
{
    public class Day8Tests
    {
        [Test]
        public void Day8SampleInput1()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day8", "Day8SampleInput1.txt");
            var input = File.ReadLines(path).ToList();

            var ret = Day8.NumberOfStepsToExit(input);

            Assert.That(ret, Is.EqualTo(2));
        }

        [Test]
        public void Day8SampleInput2()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day8", "Day8SampleInput2.txt");
            var input = File.ReadLines(path).ToList();

            var ret = Day8.NumberOfStepsToExit(input);

            Assert.That(ret, Is.EqualTo(6));
        }

        [Test]
        public void Day8InputTest()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day8", "Day8Input.txt");
            var input = File.ReadLines(path).ToList();

            var answer = Day8.NumberOfStepsToExit(input);

            Assert.True(true);
        }

        [Test]
        public void Day8SampleInput3()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day8", "Day8SampleInput3.txt");
            var input = File.ReadLines(path).ToList();

            var ret = Day8.NumberOfStepsToGhostExit(input);

            Assert.That(ret, Is.EqualTo(6));
        }

        [Test]
        public void Day8InputTestPart2()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day8", "Day8Input.txt");
            var input = File.ReadLines(path).ToList();

            var answer = Day8.NumberOfStepsToGhostExit(input);

            Assert.True(true);
        }
    }
}
