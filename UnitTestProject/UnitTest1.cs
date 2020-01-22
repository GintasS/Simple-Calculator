using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDivideByZero()
        {
            var calculation = "5 / 0";
            var expected = Constants.Symbol.Infinity.ToString();
            var actual = ResultsManager.Calculate(calculation);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNaNValue()
        {
            var calculation = "0 / 0";
            var expected = Constants.Symbol.NaN;
            var actual = ResultsManager.Calculate(calculation);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSimpleCalculation()
        {
            var calculation = "5 + 6";
            var expected = "11";
            var actual = ResultsManager.Calculate(calculation);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSimpleCalculation2()
        {
            var calculation = "5 / 6";
            var expected = "0.833333333333333";
            var actual = ResultsManager.Calculate(calculation);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSimpleCalculation3()
        {
            var calculation = "5 * 6";
            var expected = "30";
            var actual = ResultsManager.Calculate(calculation);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSimpleCalculation4()
        {
            var calculation = "5 - 6";
            var expected = "-1";
            var actual = ResultsManager.Calculate(calculation);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSimpleCalculation5()
        {
            var calculation = "5.3*6.3";
            var expected = "33.39";
            var actual = ResultsManager.Calculate(calculation);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSimpleCalculation6()
        {
            var calculation = "-4 * 5";
            var expected = "-20";
            var actual = ResultsManager.Calculate(calculation);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestConvertDisplaySymbols()
        {
            var calculatorInput = "55 ÷ 5 + 66 × 0";
            var expected = "55 / 5 + 66 * 0";
            var actual = ResultsManager.ConvertDisplaySymbols(calculatorInput);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestReplaceIllegalUserInput()
        {
            var calculatorInput = "55 + 6.";
            var expected = "55 + 6.0";
            var actual = UserInput.RemoveIllegalUserInput(calculatorInput);

            Assert.AreEqual(expected, actual);
        }



    }
}