using AdventofCSharp_2023;

namespace AdventofCSharp2023_Tests
{
    public class Day1Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.That(Day1.SumOfCalibrationValues(new List<string>()), Is.EqualTo(-1));
        }
    }
}