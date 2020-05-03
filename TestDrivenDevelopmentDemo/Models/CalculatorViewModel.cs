using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestDrivenDevelopmentDemo.WebUI.Models
{
    public class CalculatorViewModel
    {
        [Display(Name ="Value 1")]
        public double Value1 { get; set; }

        [Display(Name = "Value 2")]
        public double Value2 { get; set; }

        [Display(Name = "Result")]
        public double ResultValue { get; set; }

        [Display(Name = "Operators")]
        public List<SelectListItem> Operators { get; set; }

        [Display(Name = "Operator")]
        public string Operator { get; set; }

        [Display(Name = "Message")]
        public string Message { get; set; } 

        [Display(Name = "Is Result Valid")]
        public bool IsResultValid { get; set; }
    }
}
