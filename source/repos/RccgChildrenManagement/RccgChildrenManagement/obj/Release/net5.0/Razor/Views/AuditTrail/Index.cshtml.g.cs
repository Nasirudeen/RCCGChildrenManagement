#pragma checksum "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c3f3bbdb63844167da704cd4300a4cfefd7f8758"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AuditTrail_Index), @"mvc.1.0.view", @"/Views/AuditTrail/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3f3bbdb63844167da704cd4300a4cfefd7f8758", @"/Views/AuditTrail/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51458781d35daf9dc18259921d79ade52219dd21", @"/Views/_ViewImports.cshtml")]
    public class Views_AuditTrail_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RccgChildrenManagement.Models.AuditTrail>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
  
    ViewData["Title"] = "AuditTrail  List";
    Layout = "~/Views/Shared/LayoutNew.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<CENTER><h4 style=\"margin-top: 30px; font-size:55px;\">AUDIT TRAIL REPORT  </h4></CENTER>\r\n<h4 style=\"text-align :right;\">");
#nullable restore
#line 13 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                          Write(DateTime.Now.ToString("dd MMMM, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 13 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                                                                   Write(DateTime.Now.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<div class=\"panel-body\">\r\n    <div class=\"row\">\r\n    </div>\r\n    <div class=\"form-border table-responsive\" style=\"margin-top:40px;\">\r\n");
#nullable restore
#line 18 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
         if (Model.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <table class=\"table table-striped table-hover\" id=\"jayb1\" border=\"1\">\r\n                <thead style=\"background-color:azure;\">\r\n                    <tr>\r\n                        <th>\r\n                            ");
#nullable restore
#line 24 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.AuditTrailId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 27 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.Action));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 30 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.NewValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 33 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.IpAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 36 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 39 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.ObjectName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 42 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                       Write(Html.DisplayNameFor(model => model.Created));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </th>\r\n\r\n\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 49 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                     foreach (var item in Model)
                    {
                        var Id = item.AuditTrailId;


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 55 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.AuditTrailId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 58 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Action));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 61 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.NewValue));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 64 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.IpAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 67 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.CreatedBy));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 70 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ObjectName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 73 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                           Write(Html.DisplayFor(modelItem => item.Created));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </td>\r\n\r\n                        </tr>\r\n");
#nullable restore
#line 77 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 80 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <center> <p style=\"color:black; font-size:35px;\">No Audit Trail is created</p></center>\r\n");
#nullable restore
#line 84 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\AuditTrail\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n");
            WriteLiteral("   \r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RccgChildrenManagement.Models.AuditTrail>> Html { get; private set; }
    }
}
#pragma warning restore 1591
