#pragma checksum "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0219706cd5cd5b1c2ec8ce059a8433eb10445936"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Attendance_Index), @"mvc.1.0.view", @"/Views/Attendance/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0219706cd5cd5b1c2ec8ce059a8433eb10445936", @"/Views/Attendance/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51458781d35daf9dc18259921d79ade52219dd21", @"/Views/_ViewImports.cshtml")]
    public class Views_Attendance_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RccgChildrenManagement.Models.Attendance>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
  
    ViewData["Title"] = "Attendance  List";
    Layout = "~/Views/Shared/LayoutNew.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<CENTER><h4 style=\"margin-top: 30px; font-size:55px;\">ATTENDANCE LIST  </h4></CENTER>\r\n<h4 style=\"text-align :right;\">");
#nullable restore
#line 13 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
                          Write(DateTime.Now.ToString("dd MMMM, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 13 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
                                                                   Write(DateTime.Now.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<div class=\"panel-body\">\r\n    <div class=\"row\">\r\n    </div>\r\n    <div class=\"form-border table-responsive\" style=\"margin-top:40px;\">\r\n");
#nullable restore
#line 18 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
         if (Model.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <table class=""table table-striped table-hover"" id=""jayb1"" border=""1"">
                <thead class=""success"" style=""background-color:azure;"">
                    <tr>
                        <th>
                            SNo
                        </th>
                        <th>
                            EmaillAddress
                        </th>
                        <th>
                            Parent Code
                        </th>
                        <th>
                            Children Id
                        </th>

                        <th>
                            Children Code
                        </th>
                        <th>
                            Dropped Off
                        </th>
                        <th>
                            Picked Up
                        </th>
                        <th>
                            Registered
                        </th>


                    </tr>
");
            WriteLiteral("                </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 53 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
                     foreach (var item in Model)
                    {
                        var Id = item.AttendanceId;


#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 59 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.AttendanceId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 62 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.EmailAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 65 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ParentCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 68 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ChildrenId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 71 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.ChildrenCode));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 74 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DroppedOff));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 77 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.PickedUp));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 80 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Created));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 83 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 86 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <center> <p style=\"color:black; font-size:35px;\">No Attendance is created</p></center>\r\n");
#nullable restore
#line 90 "C:\Users\USER\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RccgChildrenManagement.Models.Attendance>> Html { get; private set; }
    }
}
#pragma warning restore 1591
