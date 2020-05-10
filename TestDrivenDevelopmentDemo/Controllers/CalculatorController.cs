using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDrivenDevelopmentDemo.WebUI.Models;
using TestDrivenDevelopmentDemo.WebUI.Helpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using TestDrivenDevelopmentDemo.Api;

namespace TestDrivenDevelopmentDemo.WebUI.Controllers
{    
    public class CalculatorController : Controller
    {
        private ICalculatorService _CalculatorService;

        public CalculatorController(ICalculatorService service)
        {
            if (service == null)
            {
                throw new ArgumentNullException("service", "argument cannot be null");
            }
            _CalculatorService = service;
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Calculate(CalculatorViewModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model", "Argument cannot be null");

            var operation = model.Operator;
            if(operation == CalculatorConstants.OperatorAdd)
            {
                //perform add
                model.ResultValue = _CalculatorService.Add(model.Value1, model.Value2);
                model.IsResultValid = true;
                model.Message = CalculatorConstants.Message_Success;
                PopulateOperators(model,operation);
                return View("Index",model);
            }else if (operation == CalculatorConstants.OperatorSubtract)
            {
                //perform subtract
                model.ResultValue = _CalculatorService.Subtract(model.Value1, model.Value2);
                model.IsResultValid = true;
                model.Message = CalculatorConstants.Message_Success;
                PopulateOperators(model, operation);
                return View("Index", model);
            }else if (operation == CalculatorConstants.OperatorMultiply)
            {
                //perform multiply
                model.ResultValue = _CalculatorService.Multiply(model.Value1, model.Value2);
                model.IsResultValid = true;
                model.Message = CalculatorConstants.Message_Success;
                PopulateOperators(model, operation);
                return View("Index", model);
            }else if (operation == CalculatorConstants.OperatorDivide)
            {
                if (model.Value2 == 0)
                {
                    model.ResultValue = 0;
                    model.Message = CalculatorConstants.Message_CantDivideByZero;
                    model.IsResultValid = false;
                }
                else
                {
                    //perform divide
                    model.ResultValue = _CalculatorService.Divide(model.Value1, model.Value2);
                    model.IsResultValid = true;
                    model.Message = CalculatorConstants.Message_Success;
                }
                PopulateOperators(model, operation);
                return View("Index", model);
            }
            else
            {
                return BadRequest();
            }
        }

        private void PopulateOperators(CalculatorViewModel model, string operation)
        {
            model.Operator = operation;
            var operators = GetOperators();
            foreach (var item in operators)
            {
                item.Selected = false;
            }

            var selectThisOperator = (from temp in operators
                                      where temp.Text == operation
                                      select temp).FirstOrDefault();

            if (selectThisOperator == null)
                selectThisOperator.Selected = true;

            model.Operators = operators;
        }
    }
}
