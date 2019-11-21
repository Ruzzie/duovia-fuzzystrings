using NUnit.Framework;

namespace Ruzzie.FuzzyStrings.UnitTests
{
    [TestFixture]
    public class StripTests
    {
        [TestCase("Doctor Who!", "Doctor Who")]
        [TestCase(" Flashback {4}{R}", " Flashback 4R")]
        [TestCase(" �ther Vial", " ther Vial")]
        [TestCase(" �ther Vial-", " ther Vial-")]
        public void SmokeTest(string input, string expected)
        {
            Assert.That(StringExtensions.StripAlternative(input), Is.EqualTo(expected));
            Assert.That(StringExtensions.StripAlternativeV2(input), Is.EqualTo(StringExtensions.StripAlternative(input)));
        }

        [TestCase(1,2,3,1)]
        [TestCase(3,2,1,1)]
        [TestCase(3,1,2,1)]
        [TestCase(3,3,2,2)]
        [TestCase(2,3,3,2)]
        [TestCase(3,2,3,2)]
        [TestCase(0,0,0,0)]
        [TestCase(0,0,-1,-1)]
        [TestCase(0,0,-1,-1)]
        [TestCase(-1,0,-1,-1)]
        [TestCase(1,0,-1,-1)]
        [TestCase(1,1,1,1)]
        public void FindMinimumOptimized(int a, int b, int c, int expected)
        {            
            Assert.That(LevenshteinDistanceExtensions.Min(a,b,c), Is.EqualTo(expected));
        }
    }
}