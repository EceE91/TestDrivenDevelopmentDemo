using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TestDrivenDevelopmentDemo.WebUI.Controllers;

namespace TestDrivenDevelopmentDemo.Tests.Presentation
{
    [TestClass]
    public class CalculatorControllerFixture
    {
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
    }
}
