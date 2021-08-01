#pragma checksum "C:\WebAPIProjects\MediShare\mainServer\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a37eda08ed1e187f668c3ab2db9ee62f6b99db2d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a37eda08ed1e187f668c3ab2db9ee62f6b99db2d", @"/Views/Shared/_Layout.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<mainServer.Controllers.LoginandProductPage>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "C:\WebAPIProjects\MediShare\mainServer\Views\Shared\_Layout.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n<!DOCTYPE html>\n<html lang=\"en\">\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a37eda08ed1e187f668c3ab2db9ee62f6b99db2d2963", async() => {
                WriteLiteral("\n        <meta charset=\"utf-8\" />\n        <meta name=\"viewport\" content=\"width=device-width, initial-scale=1, shrink-to-fit=no\" />\n        <meta name=\"description\"");
                BeginWriteAttribute("content", " content=\"", 283, "\"", 293, 0);
                EndWriteAttribute();
                WriteLiteral(" />\n        <meta name=\"author\"");
                BeginWriteAttribute("content", " content=\"", 325, "\"", 335, 0);
                EndWriteAttribute();
                WriteLiteral(@" />
        <title>MediShare - Your Daily Medical Store</title>
        <!-- Favicon-->
        <link rel=""icon"" type=""image/x-icon"" href=""dist/HomePageLayout/assets/favicon.ico"" />
        <!-- Core theme CSS (includes Bootstrap)-->
        <link href=""dist/HomePageLayout/css/styles.css"" rel=""stylesheet"" />

    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a37eda08ed1e187f668c3ab2db9ee62f6b99db2d4773", async() => {
                WriteLiteral(@"
        <!-- Navigation-->
        <nav class=""navbar navbar-expand-lg navbar-dark bg-dark"">
            <div class=""container"">
                <a href=""/"" class=""logo"">
                    <span class=""logo-lg""><i class=""fas fa-clinic-medical"" style=""color: #c5eaff""></i>MediShare</span>
                </a>
                <button class=""navbar-toggler"" type=""button"" data-toggle=""collapse"" data-target=""#navbarResponsive"" aria-controls=""navbarResponsive"" aria-expanded=""false"" aria-label=""Toggle navigation""><span class=""navbar-toggler-icon""></span></button>
                <div class=""collapse navbar-collapse"" id=""navbarResponsive"">
                    <ul class=""navbar-nav ml-auto"">
                        <li class=""nav-item""><a class=""nav-link"" href=""/CartPage"">
                            <svg xmlns=""http://www.w3.org/2000/svg"" width=""16"" height=""16"" fill=""currentColor"" class=""bi bi-cart"" viewBox=""0 0 16 16"">
                            <path d=""M0 1.5A.5.5 0 0 1 .5 1H2a.5.5 0 0 1 .485.379L2.89 3H14.5a.5");
                WriteLiteral(@".5 0 0 1 .491.592l-1.5 8A.5.5 0 0 1 13 12H4a.5.5 0 0 1-.491-.408L2.01 3.607 1.61 2H.5a.5.5 0 0 1-.5-.5zM3.102 4l1.313 7h8.17l1.313-7H3.102zM5 12a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm7 0a2 2 0 1 0 0 4 2 2 0 0 0 0-4zm-7 1a1 1 0 1 1 0 2 1 1 0 0 1 0-2zm7 0a1 1 0 1 1 0 2 1 1 0 0 1 0-2z""/>
                            </svg><i class=""bi bi-cart"">cart<p id=""cart_val""></p> </i></a></li>
                        <li class=""nav-item""><a class=""nav-link"" href=""#!"">Services</a></li>
");
#nullable restore
#line 38 "C:\WebAPIProjects\MediShare\mainServer\Views\Shared\_Layout.cshtml"
                          
                            if(Model.password != "n"){
                                

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <div class=\"btn-group\">\n                                    <button type=\"button\" class=\"btn btn-secondary dropdown-toggle\" data-toggle=\"dropdown\">\n                                                    ");
#nullable restore
#line 43 "C:\WebAPIProjects\MediShare\mainServer\Views\Shared\_Layout.cshtml"
                                               Write(Model.email);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </button>
                                        <div class=""dropdown-menu"">
                                            <a class=""dropdown-item"" href=""/UserDashboard"">Dashboard</a>
                                            <a class=""dropdown-item"" href=""/Logout"">Logout</a>
                                        </div>
                                </div>
");
#nullable restore
#line 50 "C:\WebAPIProjects\MediShare\mainServer\Views\Shared\_Layout.cshtml"
                            }else{

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <li class=\"nav-item\"><a class=\"nav-link\" href=\"/Login\">Login/Register</a></li>\n");
#nullable restore
#line 52 "C:\WebAPIProjects\MediShare\mainServer\Views\Shared\_Layout.cshtml"
                            }
                        

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </ul>\n                </div>\n            </div>\n        </nav>\n\n        <div>\n            ");
#nullable restore
#line 60 "C:\WebAPIProjects\MediShare\mainServer\Views\Shared\_Layout.cshtml"
       Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@";
        </div>


        <footer style=""position: sticky;top:100%"">
            <div class=""container"">
                <p class=""m-0 text-center text-white"">Copyright &copy; MediShare 2021</p>
            </div>
        </footer>
    

    
        <script src=""bower_components/jquery/dist/jquery.slim.min.js""></script>
        <script src=""https://cdn.jsdelivr.net/npm/bootstrap@4.6.0/dist/js/bootstrap.bundle.min.js""></script>
       
        <script src=""dist/HomePageLayout/js/scripts.js""></script>
        <script src=""https://code.jquery.com/jquery-3.1.1.min.js""></script>

        <script> 
            CartVal();
            function CartVal(){
                $.ajax({
                    type: ""GET"",
                    url: ""/Home/CartVal"",
                    success: function(response){
                        document.getElementById('cart_val').innerHTML = ""(""+ response + "")"";
                        console.log(response);
                    },
                    failure: function(response){
      ");
                WriteLiteral("                  alert(\"something wrong\");\n                    }\n                });\n            }\n        </script>\n        \n\n        \n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n</html>\n\n\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<mainServer.Controllers.LoginandProductPage> Html { get; private set; }
    }
}
#pragma warning restore 1591
