#pragma checksum "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7da7f3e72c77795c0804fbb5339b80aa5ccedb27"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Children_Display), @"mvc.1.0.view", @"/Views/Children/Display.cshtml")]
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
#line 1 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\_ViewImports.cshtml"
using RccgChildrenManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\_ViewImports.cshtml"
using RccgChildrenManagement.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7da7f3e72c77795c0804fbb5339b80aa5ccedb27", @"/Views/Children/Display.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51458781d35daf9dc18259921d79ade52219dd21", @"/Views/_ViewImports.cshtml")]
    public class Views_Children_Display : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RccgChildrenManagement.Models.Children>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Children/Create/"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-lg btn-success"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Children", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary mx-2"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
  
    ViewData["Title"] = "Children  List";
    Layout = "~/Views/Shared/LayoutNew.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<CENTER><h4 style=\"margin-top: 30px; font-size:55px;\">CHILDREN LIST  </h4></CENTER>\r\n<h4 style=\"text-align :right;\">");
#nullable restore
#line 13 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
                          Write(DateTime.Now.ToString("dd MMMM, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 13 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
                                                                   Write(DateTime.Now.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<div class=\"panel-body\">\r\n    <div class=\"row\">\r\n    </div>\r\n    <div class=\"form-border table-responsive\" style=\"margin-top:40px;\">\r\n");
#nullable restore
#line 18 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
         if (Model.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <table class=""table table-striped table-hover"" id=""jayb1"" border=""1"">
                <thead style=""background-color:azure;"">
                    <tr>
                        <th>
                            SNo
                        </th>
                        <th>
                            Children Name
                        </th>
                        <th>
                            DOB
                        </th>
                        <th>
                            Class
                        </th>
                        <th>
                            Registered
                        </th>
                        <th>
                        <th>
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7da7f3e72c77795c0804fbb5339b80aa5ccedb277326", async() => {
                WriteLiteral("<i class=\"fas fa-plus\"></i>Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </th>\r\n\r\n\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 47 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
                     foreach (var item in Model)
                    {
                        var Id = item.ChildrenId;


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 53 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ChildrenId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 56 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ChildFirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                ");
#nullable restore
#line 58 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ChildLastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 61 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
                           Write(Html.DisplayFor(modelItem => item.DOB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 64 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Class));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 67 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Created));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 70 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Created));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td class=\"text-center\">\r\n                                <div class=\"w-75 btn-group\" role=\"group\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7da7f3e72c77795c0804fbb5339b80aa5ccedb2711952", async() => {
                WriteLiteral("<i class=\"fas fa-edit\"></i>&nbspEdit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 74 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
                                                                   WriteLiteral(item.ChildrenId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                                </div>\r\n                        </tr>\r\n");
#nullable restore
#line 78 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 81 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <center> <p style=\"color:black; font-size:35px;\">No Audit Trail is created</p></center>\r\n");
#nullable restore
#line 85 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Children\Display.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
            WriteLiteral("    <script>\r\n        $(document).ready(function () {\r\n            $(\"#jayb1\").DataTable();\r\n\r\n            $(\"#dialog-form\").dialog({\r\n                modal: true\r\n            });\r\n        });\r\n\r\n\r\n\r\n    </script>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
        <script>


            $(document).ready(function () {
                $(""#jayb1"").DataTable({
                    dom: 'Bfrtip',
                    buttons: [
                        'excel', 'pdf', 'print'
                    ]
                });

                $(""#dialog-form"").dialog({
                    modal: true
                });

            });
        </script>
    ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RccgChildrenManagement.Models.Children>> Html { get; private set; }
    }
}
#pragma warning restore 1591