using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrivenDevelopmentDemo.Tests
{
    public class TestUtility
    {
        public static T GetModel<T>(IActionResult actionResult)
        {
            var viewResult = actionResult as ViewResult;
            return (T)viewResult.Model;
        }
    }
}
