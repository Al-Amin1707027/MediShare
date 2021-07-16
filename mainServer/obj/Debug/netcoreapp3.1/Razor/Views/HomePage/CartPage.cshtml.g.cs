#pragma checksum "C:\WebAPIProjects\MediShare\mainServer\Views\HomePage\CartPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6106dc08b6fa18bb3d4a212e2f895fbb1a67c478"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_HomePage_CartPage), @"mvc.1.0.view", @"/Views/HomePage/CartPage.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6106dc08b6fa18bb3d4a212e2f895fbb1a67c478", @"/Views/HomePage/CartPage.cshtml")]
    public class Views_HomePage_CartPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\WebAPIProjects\MediShare\mainServer\Views\HomePage\CartPage.cshtml"
  
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

 

<div class=""small-container"" style=""margin-left: 50px auto;"">
    
    
    <div style=""margin-left: 10px ; margin-right: 10px;"">
        <div class=""table-responsive mailbox-messages"">
                        <table class=""table table-hover table-striped"">
                            <tbody id=""hosts"">


                            </tbody>
                        </table>
        </div>

        <br>
    
        <div>
            <a  class=""btn btn-outline-danger"" href=""/Payment/ClearCart"">Clear Cart</a>
            <div style=""justify-content: flex-end; display: flex; margin-right:200px;"">
                <P id=""total_price""></P>
            </div>
        </div>
        <div style="" display: flex; justify-content: flex-end; margin-right:200px;"">
            <p>Address:</p>
            <br>
            <p id=""address""></p><br>
            <a  class=""btn btn-outline-secondary"">Submit Order</a>
        </div>
    </div>

    
</div>




");
            WriteLiteral(@"<script src=""https://code.jquery.com/jquery-3.1.1.min.js""></script>



<script>



LoadCart();
function LoadCart(){

    var totalprice = 0;
    $.ajax({
            type: ""GET"",
            url: ""/Payment/GetCartList"",
            success: function(response) {
                var hosts = $(""#hosts"");
                hosts.empty();

                hosts.append(
                    $('<tr>').append(
                        $('<th>').text(""            ""),
                        $('<th>').text('Product Name'),
                        $('<th>').text('Quantity'),
                        $('<th>').text('SubTotal')
                    )
                );


                $.each(response, function(i, item) {
                        var file_path = ""ProductImages/"" + item.file_name;
                        $('<tr>').append(
                            $('<td class=""mailbox-name"">').append(
                                $('<img  src='+file_path+' height=""70"" width=""70"" alt=""..."">'");
            WriteLiteral(@")
                            ),
                            $('<td class=""mailbox-name"">').text(item.product_name),
                            $('<td class=""mailbox-name"">').text(item.quantity),
                            $('<td class=""mailbox-name"">').text(item.price)

                        ).appendTo(hosts);
                        totalprice+=item.price;
                    
                });

                document.getElementById('total_price').innerHTML = ""Total Price :   ""+totalprice;  
            },

            failure: function(response) {
                alert(response);
            }
        });
}


</script>



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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
