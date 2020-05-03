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

        [TestMethod]
        public void Multiply()
        {
            //arrange
            int value1 = 7;
            int value2 = 3;
            int expected = 21;

            //act
            int actual = SystemUnderTest.Multiply(value1, value2);

            //assert
            Assert.AreEqual(expected, actual, "Wrong result");
        }

        [TestMethod]
        public void Divide()
        {
            //arrange
            int value1 = 30;
            int value2 = 3;
            int expected = 10;

            //act
            int actual = SystemUnderTest.Divide(value1, value2);

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
