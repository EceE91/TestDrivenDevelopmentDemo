using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
                    _systemUnderTest = new Calculator();

                return _systemUnderTest;
            }
        }

        [TestMethod]
        public void Add()
        {
            //arrange
            double value1 = 2;
            double value2 = 3;
            double expected = 5;

            //act
            double actual = SystemUnderTest.Add(value1, value2);

            //assert
            Assert.AreEqual(expected, actual, "Wrong result");
        }

        [TestMethod]
        public void Subtract()
        {
            //arrange
            double value1 = 7;
            double value2 = 3;
            double expected = 4;

            //act
            double actual = SystemUnderTest.Subtract(value1, value2);

            //assert
            Assert.AreEqual(expected, actual, "Wrong result");
        }

        [TestMethod]
        public void Multiply()
        {
            //arrange
            double value1 = 7;
            double value2 = 3;
            double expected = 21;

            //act
            double actual = SystemUnderTest.Multiply(value1, value2);

            //assert
            Assert.AreEqual(expected, actual, "Wrong result");
        }

        [TestMethod]
        public void Divide()
        {
            //arrange
            double value1 = 30;
            double value2 = 3;
            double expected = 10;

            //act
            double actual = SystemUnderTest.Divide(value1, value2);

            //assert
            Assert.AreEqual(expected, actual, "Wrong result");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DivideByZeroThrowsException()
        {
            //arrange
            int value1 = 30;
            int value2 = 0;
            
            //act
            SystemUnderTest.Divide(value1, value2);
        }

    }
}
