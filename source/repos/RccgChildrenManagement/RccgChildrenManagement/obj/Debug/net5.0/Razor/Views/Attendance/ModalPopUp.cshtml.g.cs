#pragma checksum "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\ModalPopUp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dabd7042abce0ad471a34b81f8825b6e05267b4e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Attendance_ModalPopUp), @"mvc.1.0.view", @"/Views/Attendance/ModalPopUp.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dabd7042abce0ad471a34b81f8825b6e05267b4e", @"/Views/Attendance/ModalPopUp.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51458781d35daf9dc18259921d79ade52219dd21", @"/Views/_ViewImports.cshtml")]
    public class Views_Attendance_ModalPopUp : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<RccgChildrenManagement.Models.FetchQrDetails>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\ModalPopUp.cshtml"
  
    ViewData["Title"] = "Fetch Page";
    Layout = "~/Views/Shared/LayoutNew.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<br />
<br />
<br />
<br />

<script src=""https://code.jquery.com/jquery-3.5.1.slim.min.js""
        integrity=""sha256-4+XzXVhsDmqanXGHaHvgh1gMQKX40OUvDEBTu8JcmNs=""
        crossorigin=""anonymous""></script>
<script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.bundle.min.js""
        integrity=""sha384-1CmrxMRARb6aLqgBO7yyAxTOQE2AKb9GfXnEo760AUcUmFx3ibVJJAzGytlQcNXd""
        crossorigin=""anonymous""></script>
<script src=""./Main.js"" defer></script>


!-- Button trigger modal -->
<section>
    <button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#exampleModalCenter2"">
        View
    </button>

    <!-- Modal -->
    <div class=""modal fade"" id=""exampleModalCenter2"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">

                <div class=""modal-header"">
                    <button type");
            WriteLiteral(@"=""button"" value=""Print Above Section"" class=""btn btn-primary print"">Print QRCode</button>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body-wrapper"">
                    <img");
            BeginWriteAttribute("src", " src=\"", 1570, "\"", 1675, 3);
            WriteAttributeValue("", 1576, "https://chart.googleapis.com/chart?cht=qr&chl=", 1576, 46, true);
#nullable restore
#line 39 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\ModalPopUp.cshtml"
WriteAttributeValue("", 1622, ViewBag.id, 1622, 11, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1633, "&chs=180x180&choe=UTF-8&chld=L|2%27%20alt=", 1633, 42, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n<div class=\"panel-body\">\r\n    <div class=\"row\">\r\n\r\n    </div>\r\n\r\n    <hr />\r\n    <div class=\"form-border\" style=\"margin-top:40px;\">\r\n");
#nullable restore
#line 54 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\ModalPopUp.cshtml"
         if (Model.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <table class=""table table-striped table-hover"" id=""jayb1"" border=""1"">
                <thead style=""background-color:azure;"">
                    <tr bgcolor=""yellow"" style=""color:blue; font-size:35px;"">

                        <th>
                            Name
                        </th>


                        <th>
                            Click the image to print
                        </th>

                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 72 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\ModalPopUp.cshtml"
                     foreach (var item in Model)
                    {


#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr>\r\n                            <td style=\"color: black; font-size: 35px;\">\r\n                                ");
#nullable restore
#line 77 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\ModalPopUp.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ChildFirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                ");
#nullable restore
#line 78 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\ModalPopUp.cshtml"
                           Write(Html.DisplayFor(modelItem => item.ChildLastName));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                            </td>


                            <td style=""color: black; font-size: 35px;"">
                                <section>
                                    <button type=""button"" class=""btn btn-primary"" data-toggle=""modal"" data-target=""#exampleModalCenter2"">
                                        View
                                    </button>

                                    <!-- Modal -->
                                    <div class=""modal fade"" id=""exampleModalCenter2"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalCenterTitle"" aria-hidden=""true"">
                                        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
                                            <div class=""modal-content"">

                                                <div class=""modal-header"">
                                                    <button type=""button"" value=""Print Above Section"" class=""btn btn-primary print"">Print QRCode</bu");
            WriteLiteral(@"tton>
                                                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                                        <span aria-hidden=""true"">&times;</span>
                                                    </button>
                                                </div>
                                                <div class=""modal-body-wrapper"">
                                                    <img");
            BeginWriteAttribute("src", " src=\"", 4319, "\"", 4431, 3);
            WriteAttributeValue("", 4325, "https://chart.googleapis.com/chart?cht=qr&chl=", 4325, 46, true);
#nullable restore
#line 100 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\ModalPopUp.cshtml"
WriteAttributeValue("", 4371, item.ChildrenCode, 4371, 18, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 4389, "&chs=180x180&choe=UTF-8&chld=L|2%27%20alt=", 4389, 42, true);
            EndWriteAttribute();
            WriteLiteral(@" />
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                                </section>
                            </td>

                        </tr>
");
#nullable restore
#line 110 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\ModalPopUp.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 113 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\ModalPopUp.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <center> <p style=\"color:black; font-size:35px;\">No Children is Dropped Off</p></center>\r\n");
#nullable restore
#line 117 "C:\Users\KAZEEM\source\repos\RccgChildrenManagement\RccgChildrenManagement\Views\Attendance\ModalPopUp.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </div>

    <script>
        $(document).ready(function () {
            $(""#jayb1"").DataTable();

            $(""#dialog-form"").dialog({
                modal: true
            });
        });
    </script>
    //JQuery Code
    <script>
        $(document).on(""click"", "".print"", function () {
            const section = $(""section"");
            const modalBody = $("".modal-body-wrapper"").detach();

            const content = $("".content"").detach();
            section.append(modalBody);
            window.print();
            section.empty();
            section.append(content);
            $("".modal-body-wrapper"").append(modalBody);
        });
    </script>
    // Css Code
    <style>
        .body {
            background: antiquewhite;
        }

        .modal-body-wrapper {
            overflow-y: scroll;
            height: 60vh;
        }
    </style>



");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<RccgChildrenManagement.Models.FetchQrDetails>> Html { get; private set; }
    }
}
#pragma warning restore 1591
