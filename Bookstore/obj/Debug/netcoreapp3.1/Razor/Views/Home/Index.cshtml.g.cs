#pragma checksum "D:\Learning ASP.NET Core\Bookstore\Bookstore\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e7dd2f803c1a8d2488611f839e0193566814c992"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\Learning ASP.NET Core\Bookstore\Bookstore\Views\_ViewImports.cshtml"
using Bookstore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e7dd2f803c1a8d2488611f839e0193566814c992", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4b40d068eda723bca87826f79b448603c5dade6c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\Learning ASP.NET Core\Bookstore\Bookstore\Views\Home\Index.cshtml"
   
    dynamic data = ViewBag.Data;
    var bookdata = ViewData["book"] as BookModel; // casting of data is required as shown
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<section class=\"jumbotron text-center\">\r\n    <div class=\"container\">\r\n        <h1>");
#nullable restore
#line 9 "D:\Learning ASP.NET Core\Bookstore\Bookstore\Views\Home\Index.cshtml"
       Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 9 "D:\Learning ASP.NET Core\Bookstore\Bookstore\Views\Home\Index.cshtml"
                      Write(ViewData["property"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 9 "D:\Learning ASP.NET Core\Bookstore\Bookstore\Views\Home\Index.cshtml"
                                            Write(ViewData["ViewAttribute1"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n        <p>");
#nullable restore
#line 10 "D:\Learning ASP.NET Core\Bookstore\Bookstore\Views\Home\Index.cshtml"
      Write(data.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("  ");
#nullable restore
#line 10 "D:\Learning ASP.NET Core\Bookstore\Bookstore\Views\Home\Index.cshtml"
                Write(data.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>");
#nullable restore
#line 11 "D:\Learning ASP.NET Core\Bookstore\Bookstore\Views\Home\Index.cshtml"
      Write(ViewBag.BookDetails.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>");
#nullable restore
#line 12 "D:\Learning ASP.NET Core\Bookstore\Bookstore\Views\Home\Index.cshtml"
      Write(ViewBag.BookDetails.Language);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>Buy books online? From bestsellers to niche books..</p>\r\n        <p>Id= ");
#nullable restore
#line 14 "D:\Learning ASP.NET Core\Bookstore\Bookstore\Views\Home\Index.cshtml"
          Write(bookdata.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>Total pages= ");
#nullable restore
#line 15 "D:\Learning ASP.NET Core\Bookstore\Bookstore\Views\Home\Index.cshtml"
                   Write(bookdata.TotalPages);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
        <p>Bookstore is the fastest way to compare book prices and buy books from online book sellers in India.</p>
        <p>
            <a class=""btn btn-secondary"">Search</a>
        </p>
    </div>
</section>
<div class=""py-5 bg-light"">
    <div class=""container"">
        <h3 class=""h3"">Top books</h3>
        <div class=""row"">
            <div class=""col-md-4"">
");
            WriteLiteral("            </div>\r\n            <div class=\"col-md-4\">\r\n");
            WriteLiteral("            </div>\r\n            <div class=\"col-md-4\">\r\n");
            WriteLiteral("\r\n            </div>\r\n            <div class=\"col-md-4\">\r\n");
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n\r\n");
            DefineSection("IndexScript", async() => {
                WriteLiteral(" \r\n    <script>\r\n        $(document).ready(function () {\r\n");
                WriteLiteral("        });\r\n    </script>\r\n");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
