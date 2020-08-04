using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Helpers
{
    public class CustomEmailTagHelper : TagHelper
    {
        public string MyEmail { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            /*output.TagName = "a";
            output.Attributes.SetAttribute("href", "mailto:shashwat22.14sep@gmail.com");
            output.Content.SetContent("sp");*/

            //2nd approach
            output.TagName = "a";
            output.Attributes.SetAttribute("href", $"mailto:{MyEmail}");
            output.Content.SetContent("prk");
        }
    }
}
