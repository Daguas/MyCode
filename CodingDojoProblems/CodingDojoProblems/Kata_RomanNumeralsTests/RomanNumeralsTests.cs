using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata_RomanNumerals.Tests
{
    [TestClass()]
    public class RomanNumeralsTests
    {
        // TestTool Microsoft
        [TestMethod()]
        [DataRow(10, "X")]
        [DataRow(5, "V")]
        [DataRow(4, "IV")]
        [DataRow(9, "IX")]
        [DataRow(1999, "MCMXCIX")]
        public void ConvertToRomanTest(int value, string result)
        {
            Assert.AreEqual(result, RomanNumerals.ConvertToRoman(value));
        }

        [TestMethod()]
        [DataRow(10, "X")]
        [DataRow(5, "V")]
        [DataRow(4, "IV")]
        [DataRow(9, "IX")]
        [DataRow(1999, "MCMXCIX")]
        public void ConvertToNormalTest(int result, string value)
        {
            Assert.AreEqual(result.ToString(), RomanNumerals.ConvertToNormal(value));
        }
    }
}