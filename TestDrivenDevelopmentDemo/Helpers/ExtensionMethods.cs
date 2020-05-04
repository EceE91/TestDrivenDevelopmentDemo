using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestDrivenDevelopmentDemo.WebUI.Helpers
{
    public static class ExtensionMethods
    {
        public static void Add(this List<SelectListItem> collection,string value, string text, bool isSelected )
        {
            if (collection == null)
                throw new ArgumentException($"{nameof(collection)} is null", nameof(collection));

            if (value == null)
                throw new ArgumentException($"{nameof(value)} is null", nameof(value));

            if (text == null)
                throw new ArgumentException($"{nameof(text)} is null", nameof(text));

            var item = new SelectListItem(text, value, isSelected);

            collection.Add(item);
        }
    }
}
