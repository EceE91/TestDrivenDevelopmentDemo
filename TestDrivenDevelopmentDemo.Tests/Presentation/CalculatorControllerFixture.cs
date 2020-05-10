using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDrivenDevelopmentDemo.Api;
using TestDrivenDevelopmentDemo.WebUI.Controllers;
using TestDrivenDevelopmentDemo.WebUI.Models;

namespace TestDrivenDevelopmentDemo.Tests.Presentation
{
    [TestClass]
    public class CalculatorControllerFixture
    {
        private ICalculatorService _CalculatorService;

        public ICalculatorService CalculatorServiceInstance
        {
            get
            {
                if (_CalculatorService == null)
                    _CalculatorService = new Calculator();
                return _CalculatorService;
            }
        }

        [TestInitialize]
        public void OnTestInitialize()
        {
            _systemUnderTest = null;
        }

        private CalculatorController _systemUnderTest;
        public CalculatorController SystemUnderTest
        {
            get
            {
                if (_systemUnderTest == null)
                    _systemUnderTest = new CalculatorController(CalculatorServiceInstance);

                return _systemUnderTest;
            }
        }

        [TestMethod]
        public void CalculatorController_Index_ModelIsNotNull()
        {
            var model = TestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());

            Assert.IsNotNull(model, "Model was null");
        }

        [TestMethod]
        public void CalculatorController_Index_Model_Value1IsInitialized()
        {
            var model = TestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());
            
            var actual = model.Value1;

            var expected = 0d;

            Assert.AreEqual(expected, actual, "Value1 field value was wrong");
        }

        [TestMethod]
        public void CalculatorController_Index_Model_Value2IsInitialized()
        {
            var model = TestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());

            var actual = model.Value2;

            var expected = 0d;

            Assert.AreEqual(expected, actual, "Value2 field value was wrong");
        }

        [TestMethod]
        public void CalculatorController_Index_Model_OperatorIsInitialized()
        {
            var model = TestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());

            var actual = model.Operator;

            var expected = CalculatorConstants.Message_ChooseAnOperator;

            Assert.AreEqual<string>(expected, actual, "Operator field value was wrong");
        }

        [TestMethod]
        public void CalculatorController_Index_Model_MessageIsInitialized()
        {
            var model = TestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());

            var actual = model.Message;

            var expected = string.Empty;

            Assert.AreEqual(expected, actual, "Message field value was wrong");
        }

        [TestMethod]
        public void CalculatorController_Index_Model_IsResultValidShouldBeFalse()
        {
            var model = TestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());

            var actual = model.IsResultValid;

            var expected = false;

            Assert.AreEqual(expected, actual, "IsResultValid field value was wrong");
        }

        [TestMethod]
        public void CalculatorController_Index_Model_OperatorsCollectionIsPopulated()
        {
            var model = TestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());
            Assert.IsNotNull(model.Operators, "Operators collection was null");

            var actual = model.Operators.Select(x=>x.Text).ToList();

            var expected = new List<string>();
            expected.Add(CalculatorConstants.Message_ChooseAnOperator);
            expected.Add(CalculatorConstants.OperatorAdd);
            expected.Add(CalculatorConstants.OperatorSubtract);
            expected.Add(CalculatorConstants.OperatorDivide);
            expected.Add(CalculatorConstants.OperatorMultiply);

            CollectionAssert.AreEqual(expected, actual, "Wrong values in operators collection.");
        }


        [TestMethod]
        public void CalculatorController_Calculate_Add()
        {
            //arrange
            var model = TestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Index());
            double value1 = 2;
            double value2 = 3;
            double expected = 5;

            model.Value1 = value1;
            model.Value2 = value2;
            model.Operator = CalculatorConstants.OperatorAdd;

            //act
            var actual = TestUtility.GetModel<CalculatorViewModel>(SystemUnderTest.Calculate(model));

            //assert
            Assert.IsTrue(model.IsResultValid, "Result should be valid");
            Assert.AreEqual<double>(expected, actual.ResultValue, "Result was wrong");
            Assert.AreEqual<string>(CalculatorConstants.Message_Success, actual.Message, "Message was wrong");

            AssertOperatorsAndSelectedOperator(model, CalculatorConstants.OperatorAdd);
        }

        private void AssertOperatorsAndSelectedOperator(CalculatorViewModel model, string expectedSelectedOpeator)
        {
            Assert.IsNotNull(model.Operators, "Operators collection was null");

            var actual = model.Operators.Select(x => x.Text).ToList();

            var expected = new List<string>();
            expected.Add(CalculatorConstants.Message_ChooseAnOperator);
            expected.Add(CalculatorConstants.OperatorAdd);
            expected.Add(CalculatorConstants.OperatorSubtract);
            expected.Add(CalculatorConstants.OperatorDivide);
            expected.Add(CalculatorConstants.OperatorMultiply);            

            CollectionAssert.AreEqual(expected, actual, "Operators in collection were wrong");
            AssertSelectedOperator(model, expectedSelectedOpeator);
        }

        private void AssertSelectedOperator(CalculatorViewModel model, string expectedSelectedOpeator)
        {
            Assert.IsNotNull(model.Operators, "Operators collection was null");

            Assert.AreEqual(expectedSelectedOpeator, model.Operator, "Operator property was wrong");
            var match = (from temp in model.Operators where temp.Text == expectedSelectedOpeator select temp).FirstOrDefault();

            Assert.IsNotNull(match, $"Could not find operator {0}", expectedSelectedOpeator);
            Assert.IsNotNull(match.Selected, $"Operator {0} should be selected", expectedSelectedOpeator);
        }
    }
}
