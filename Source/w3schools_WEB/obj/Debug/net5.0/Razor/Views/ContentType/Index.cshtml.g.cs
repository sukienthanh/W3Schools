#pragma checksum "C:\Users\PC\OneDrive - actvn.edu.vn\Desktop\w3schools-update_source\w3schools-update_source\Source\w3schools_WEB\Views\ContentType\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12b9ee59870f7d999e94c97417f72aff7b27690a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ContentType_Index), @"mvc.1.0.view", @"/Views/ContentType/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12b9ee59870f7d999e94c97417f72aff7b27690a", @"/Views/ContentType/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b166d5c8fad5b65a1e16c94fa743cc29c788d6a", @"/Views/_ViewImports.cshtml")]
    public class Views_ContentType_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/initTable.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\PC\OneDrive - actvn.edu.vn\Desktop\w3schools-update_source\w3schools-update_source\Source\w3schools_WEB\Views\ContentType\Index.cshtml"
  
    ViewData["Title"] = "Content Type";
    Layout = "Admin_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""page-content"">
    <div class=""p-4"">
        <div class=""justify-content-end d-inline-flex w-100"">
            <button id=""addBtn"" type=""button"" class=""btn mr-2""><i class=""mr-2 fa fa-plus""></i>Add</button>
            <button id=""saveBtn"" type=""button"" class=""btn mr-2""><i class=""mr-2 fa fa-save""></i>Save</button>
            <button id=""refreshBtn"" type=""button"" class=""btn mr-2""><i class=""mr-2 fa fa-refresh""></i>Refresh</button>
        </div>
        <div class=""clearfix""></div>
    </div>
    <div class=""text-center grid-ctn"">
        <div id=""grid""></div>
    </div>
</div>
<script>
    var table = ""ContentType"";

    var columns = [{
        caption: ""ContentType Id"",
        dataField: ""contentTypeId"",
        visible: false,
        allowEditing: false,
    }, {
        allowFixing: true,
        allowHiding: true,
            caption: ""Content Type Name"",
            dataField: ""contentTypeName"",
        validationRules: [{
            type: ""required"",
            message: ""ContentTypeName ");
            WriteLiteral(@"field is required""
        }]
    }, {
        allowFixing: true,
        allowHiding: true,
            caption: ""Descriptions"",
            dataField: ""descriptions"",
        validationRules: [{
            type: ""required"",
            message: ""Descriptions field is required""
        }]
    }];

    $(function () {
        $("".breadcrumb"").children().last().find(""span"").text(""Content Type"");
    })
</script>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "12b9ee59870f7d999e94c97417f72aff7b27690a5481", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n");
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