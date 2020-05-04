using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDrivenDevelopmentDemo.WebUI.Controllers;
using TestDrivenDevelopmentDemo.WebUI.Models;

namespace TestDrivenDevelopmentDemo.Tests.Presentation
{
    [TestClass]
    public class CalculatorControllerFixture
    {
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
                    _systemUnderTest = new CalculatorController();

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


    }
}
