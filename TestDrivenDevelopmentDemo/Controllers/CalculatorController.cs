using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDrivenDevelopmentDemo.WebUI.Models;
using TestDrivenDevelopmentDemo.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TestDrivenDevelopmentDemo.WebUI.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            var model = new CalculatorViewModel();
            model.Message = string.Empty;
            model.IsResultValid = false;
            model.Operator = CalculatorConstants.Message_ChooseAnOperator;
            model.Operators = GetOperators();
            return View(model);
        }

        private List<SelectListItem> GetOperators()
        {
            var operators = new List<SelectListItem>();
            operators.Add( string.Empty, CalculatorConstants.Message_ChooseAnOperator,true);

            operators.Add(CalculatorConstants.OperatorAdd, CalculatorConstants.OperatorAdd,false);
            operators.Add(CalculatorConstants.OperatorSubtract,CalculatorConstants.OperatorSubtract, false);
            operators.Add(CalculatorConstants.OperatorDivide, CalculatorConstants.OperatorDivide, false);
            operators.Add(CalculatorConstants.OperatorMultiply,CalculatorConstants.OperatorMultiply, false);
                
            return operators;
        }
    }
}
