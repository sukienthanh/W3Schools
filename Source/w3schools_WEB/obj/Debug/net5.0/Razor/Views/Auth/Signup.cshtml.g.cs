#pragma checksum "C:\Users\PC\OneDrive - actvn.edu.vn\Desktop\w3schools-update_source\w3schools-update_source\Source\w3schools_WEB\Views\Auth\Signup.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9fb3a1d28496c151b145398058d83111b67c312d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Auth_Signup), @"mvc.1.0.view", @"/Views/Auth/Signup.cshtml")]
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
#line 1 "C:\Users\PC\OneDrive - actvn.edu.vn\Desktop\w3schools-update_source\w3schools-update_source\Source\w3schools_WEB\Views\_ViewImports.cshtml"
using w3schools;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\PC\OneDrive - actvn.edu.vn\Desktop\w3schools-update_source\w3schools-update_source\Source\w3schools_WEB\Views\_ViewImports.cshtml"
using w3schools.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9fb3a1d28496c151b145398058d83111b67c312d", @"/Views/Auth/Signup.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b166d5c8fad5b65a1e16c94fa743cc29c788d6a", @"/Views/_ViewImports.cshtml")]
    public class Views_Auth_Signup : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 2 "C:\Users\PC\OneDrive - actvn.edu.vn\Desktop\w3schools-update_source\w3schools-update_source\Source\w3schools_WEB\Views\Auth\Signup.cshtml"
  
    Layout = "_AuthLayout";
    ViewData["Title"] = "Sign up";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"container\">\n    <div id=\"box\">\n        <div id=\"inside-box\">\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9fb3a1d28496c151b145398058d83111b67c312d4139", async() => {
                WriteLiteral("\n                <div class=\"form-group\">\n                    <h1>Signup</h1>\n                </div>\n                <div class=\"form-group\">\n                    <div class=\"d-flex justify-content-between\">\n                        <label");
                BeginWriteAttribute("class", " class=\"", 407, "\"", 415, 0);
                EndWriteAttribute();
                WriteLiteral(" for=\"username\">Username</label>\n                        <span>\n                            Already have an account?\n                            <a");
                BeginWriteAttribute("href", " href=\"", 563, "\"", 597, 1);
#nullable restore
#line 18 "C:\Users\PC\OneDrive - actvn.edu.vn\Desktop\w3schools-update_source\w3schools-update_source\Source\w3schools_WEB\Views\Auth\Signup.cshtml"
WriteAttributeValue("", 570, Url.Action("Login","Auth"), 570, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@"><span class=""text-success"">Login</span></a>
                        </span>
                    </div>
                    <input type=""text"" class=""form-control"" name=""username"" id=""UserName"" placeholder=""Enter Username"">
                </div>
                <div class=""form-group"">
                    <label for=""email"">Email</label>
                    <input type=""email"" class=""form-control"" name=""email"" id=""Email"" placeholder=""Enter Email"">
                </div>
                <div class=""form-group"">
                    <label for=""password"">Password</label>
                    <input type=""password"" class=""form-control"" name=""password"" id=""PassWord"" placeholder=""Password"">
                </div>
                <div class=""form-group"">
                    <label for=""rePassword"">Re-enter Password</label>
                    <input type=""password"" class=""form-control"" name=""rePassword"" id=""RePassWord"" placeholder=""Re-enter Password"">
                </div>
                <div class=""form-group"">  ");
                WriteLiteral(@"                  
                    <div id=""err"" style=""display:none"" class=""text-danger"">
                        
                    </div>
                </div>
                <div class=""form-group"">
                    <button type=""submit"" id=""btn"" class=""w-100 btn btn-success"">Signup</button>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
    </div>
</div>
<style>
    #box {
        position: absolute;
        top: 50%;
        left: 50%;
        -webkit-transform: translate(-50%,-50%);
        transform: translate(-50%,-50%);
        width: 478px;
        max-width: 100%;
        max-height: 100%;
        z-index: 150;
        border-radius: 4px;
        box-shadow: inset 0 0 15px 4px rgba(0,0,0,.06),0 0 15px 4px rgba(0,0,0,.06);
    }

    #inside-box {
        position: relative;
        box-sizing: border-box;
        top: 0;
        left: 0;
        width: 100%;
        height: 100%;
        padding: 48px;
        background-color: #fff;
        border: 1px solid #e3e3e3;
        border-radius: 16px;
        text-align: left;
    }

        #inside-box h1 {
            font-weight: 700;
            font-size: 3rem;
            text-align: center;
            color: #282a35;
            margin: 0;
        }

    input {
        margin-top: 10px;
        font-size: 1.4rem !important;
 ");
            WriteLiteral(@"   }

    .form-group span {
        font-size: 1.3rem;
    }

    #form label {
        font-size: 1.6rem;
        font-weight: 500;
    }

    #form .form-group {
        padding-top: 1.2rem;
    }

    #form button {
        border-radius: 25px;
        font-size: 1.8rem;
    }
</style>
<script>
    $(function () {
        $(""#form"").submit(function (e) {
        e.preventDefault();
        data = new FormData($(""#form"")[0]);
        $.ajax({
            url: """);
#nullable restore
#line 113 "C:\Users\PC\OneDrive - actvn.edu.vn\Desktop\w3schools-update_source\w3schools-update_source\Source\w3schools_WEB\Views\Auth\Signup.cshtml"
             Write(Url.Action("SignupMethod","Auth"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@""",
            data: data,
            contentType:false,
            processData: false,
            type: 'post',
            dataType:""json"",

        }).done(function (e) {            
            if (e.status === 1) {
                location.href = ""/Home/Index"";
            } else {
                let messArray = (e.message).split(""!"");
                $(""#err"").empty();
                messArray.forEach(function (value, index) {
                    $(""#err"").append(""<div class='p-2'>""+value+""</div>"").css(""display"", ""block"");
                })                
            }
        }).fail(function(e){
            DevExpress.ui.notify(""Error"",""warning"", 5000);
        })
        
    })
    })


</script>");
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
