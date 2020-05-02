using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDrivenDevelopmentDemo.Api;

namespace TestDrivenDevelopmentDemo.Tests
{
    [TestClass]
    public class CalculatorFixture
    {
        [TestInitialize]
        public void OnTestInitialize()
        {
            _systemUnderTest = null;
        }

        private Calculator _systemUnderTest;
        public Calculator SystemUnderTest {
            get {
                if (_systemUnderTest == null)
                    return new Calculator();

                return _systemUnderTest;
            }
        }

        [TestMethod]
        public void Add()
        {
            //arrange
            int value1 = 2;
            int value2 = 3;
            int expected = 5;

            //act
            int actual = SystemUnderTest.Add(value1, value2);

            //assert
            Assert.AreEqual(expected, actual, "Wrong result");
        }

        [TestMethod]
        public void Subtract()
        {
            //arrange
            int value1 = 7;
            int value2 = 3;
            int expected = 4;

            //act
            int actual = SystemUnderTest.Subtract(value1, value2);

            //assert
            Assert.AreEqual(expected, actual, "Wrong result");
        }
    }
}
