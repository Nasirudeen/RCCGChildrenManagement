#pragma checksum "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ca0b10c50d6fcb4155b1778a6413a0631526202e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca0b10c50d6fcb4155b1778a6413a0631526202e", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51458781d35daf9dc18259921d79ade52219dd21", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RccgChildrenManagement.Models.User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
  
    ViewData["Title"] = "User  List";
    Layout = "~/Views/Shared/LayoutNew.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<br />\r\n<br />\r\n<br />\r\n<br />\r\n<CENTER><h4 style=\"margin-top: 30px; font-size:55px;\">USER LIST   </h4></CENTER>\r\n<h4 style=\"text-align :right;\">");
#nullable restore
#line 13 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                          Write(DateTime.Now.ToString("dd MMMM, yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 13 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                                                                   Write(DateTime.Now.ToShortTimeString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<div class=\"panel-body\">\r\n    <div class=\"row\">\r\n    </div>\r\n    \r\n            <div class=\"form-border table-responsive\" style=\"margin-top:40px;\">\r\n");
#nullable restore
#line 19 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                 if (Model.Count() > 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <table class=""table table-striped table-hover table"" id=""jayb1"" border=""1"">
                        <thead style=""background-color:azure;"">
                            <tr >
                                <th>
                                    SNo
                                </th>
                                <th>
                                    User Name
                                </th>
                                <th>
                                    Home Address
                                </th>
                                <th>
                                    EmailAddress
                                </th>
                                <th>
                                    Phone No
                                </th>
                                <th>
                                    Member_Visitor
                                </th>
                                <th>
                                    Kids ");
            WriteLiteral(@"Number
                                </th>
                                <th>
                                    Registered
                                </th>

                            </tr>
                        </thead>
                        <tbody>
");
#nullable restore
#line 52 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                             foreach (var item in Model)
                            {
                                var Id = item.UserId;


#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 58 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.UserId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 61 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                                        ");
#nullable restore
#line 63 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 66 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 69 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.EmailAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 72 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.PhoneNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 75 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Member_Visitor));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 78 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Kidnumber));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
#nullable restore
#line 81 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Created));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    </td>\r\n                                </tr>\r\n");
#nullable restore
#line 84 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n");
#nullable restore
#line 87 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <center> <p style=\"color:black; font-size:35px;\">No user is created</p></center>\r\n");
#nullable restore
#line 91 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\User\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n");
            WriteLiteral("           \r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RccgChildrenManagement.Models.User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
