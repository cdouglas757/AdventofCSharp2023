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
        public void SampleTest()
        {
            var input = new List<string>()
            {
                "1abc2",
                "pqr3stu8vwx",
                "a1b2c3d4e5f",
                "treb7uchet"
            };
            Assert.That(Day1.SumOfCalibrationValues(input), Is.EqualTo(142));
        }

        [Test]
        public void Day1InputTest()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "Day1", "Day1Input.txt");
            var input = File.ReadLines(path).ToList();

            var answer = Day1.SumOfCalibrationValues(input);

            Assert.True(true);
        }
    }
}