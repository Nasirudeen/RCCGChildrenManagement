#pragma checksum "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Change.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c0f8523d28c2b2abfab50470a595aeb5b4dfb0df"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Change), @"mvc.1.0.view", @"/Views/User/Change.cshtml")]
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
#line 1 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\_ViewImports.cshtml"
using RccgChildrenManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\_ViewImports.cshtml"
using RccgChildrenManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c0f8523d28c2b2abfab50470a595aeb5b4dfb0df", @"/Views/User/Change.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51458781d35daf9dc18259921d79ade52219dd21", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Change : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RccgChildrenManagement.Models.User>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 20rem; transition: width 2s"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/Rccg.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("RCCG Logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("text-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Change.cshtml"
  
    ViewData["Title"] = "User Page";
    Layout = "~/Views/Shared/LayoutNew.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<br />\r\n<br />\r\n\r\n<div class=\"container row reg-panel\">\r\n    <div class=\"col-md-4\">\r\n        <div id=\"center\">\r\n            <div>\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c0f8523d28c2b2abfab50470a595aeb5b4dfb0df5266", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

            </div>

            <h1>Children Church</h1>
            <p>Register your kids for church</p>
        </div>

        <div style=""background-color: none; color: white;  margin-top: 18rem"">
            <p style=""font-style: italic;"">Jesus Christ the same yesterday, today, and forever more. Amen</p>
        </div>
    </div>
    <div class=""col-xl-8"" style=""border: 1px;"" solid #ccc; padding-top: 1rem; width=""xl: 1340px;"">

        <h2>RCCG GWC Children Church Registration</h2>
        <p><b>Note:</b> You have to set a responsible party (last section) for drop off and pickup</p>
        <hr>
        <h2>Change Password</h2>
        <div class=""col-md-6"">
");
#nullable restore
#line 34 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Change.cshtml"
             using (@Html.BeginForm("Change", "User", FormMethod.Post, new { enctype = "multipart/form-data" }))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("div", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c0f8523d28c2b2abfab50470a595aeb5b4dfb0df7522", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ValidationSummaryTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper);
#nullable restore
#line 36 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Change.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary = global::Microsoft.AspNetCore.Mvc.Rendering.ValidationSummary.ModelOnly;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-validation-summary", __Microsoft_AspNetCore_Mvc_TagHelpers_ValidationSummaryTagHelper.ValidationSummary, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                <div class=""form-group row"" style=""margin-top:40px;"">

                    <div class=""col-md-6"">                    

                        <label style=""font-size:18px"" id=""NewPassword-Label"" class=""control-label col-sm-3"">NewPassword</label><br />

                        <input class=""form-control inputstl"" class=""form-control inputstl"" style=""width: 280px; font-size: 20px; height: 30x;"" name=""NewPassword"" id=""NewPassword"" type=""password"" required placeholder=""enter your NewPassword"" class=""form-control"" />
                        <span class=""text-danger""></span>
                        <label style=""font-size:18px"" id=""ConfirmPassword-Label"" class=""control-label col-sm-3"">ConfirmPassword</label><br />
                        <input class=""form-control inputstl"" class=""form-control inputstl"" style=""width: 280px; font-size: 20px; height: 30x;"" name=""ConfirmPassword"" id=""ConfirmPassword"" type=""password"" required placeholder=""enter your ConfirmPassword"" class=""form-control"" />
");
            WriteLiteral("                        <span class=\"text-danger\"></span>\r\n                    </div>\r\n                </div>\r\n");
            WriteLiteral(@"                <div class=""form-group row"">

                    <div style=""text-align: center; margin-bottom: 2rem; margin-top: 2rem;"">
                        <button class=""btn btn-lg btn-success btn-block mt-5"" type=""submit"" style=""width:100%; margin-top:5%; margin-left:10%;"">Change Password</button>

                    </div>

                </div>
");
#nullable restore
#line 59 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Change.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <script type=\"text/javascript\">\r\n");
#nullable restore
#line 63 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Change.cshtml"
 if (TempData["status"] != null)
{
    

#line default
#line hidden
#nullable disable
            WriteLiteral("alert(\'Password Chansged Successfully\'); ");
#nullable restore
#line 65 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Change.cshtml"
                                                          
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </script>\r\n        </div>\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RccgChildrenManagement.Models.User> Html { get; private set; }
    }
}
#pragma warning restore 1591
