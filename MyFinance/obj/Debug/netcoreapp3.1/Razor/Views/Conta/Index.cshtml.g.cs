#pragma checksum "E:\CLENILDO\01-CURSOS E PROJETOS\C#\MyFinance\MyFinance\Views\Conta\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "27321256c2616e15b6e1ad14e514512df8e01c4b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Conta_Index), @"mvc.1.0.view", @"/Views/Conta/Index.cshtml")]
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
#line 1 "E:\CLENILDO\01-CURSOS E PROJETOS\C#\MyFinance\MyFinance\Views\_ViewImports.cshtml"
using MyFinance;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\CLENILDO\01-CURSOS E PROJETOS\C#\MyFinance\MyFinance\Views\_ViewImports.cshtml"
using MyFinance.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"27321256c2616e15b6e1ad14e514512df8e01c4b", @"/Views/Conta/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d05dd6abef5a8ff60f9a555c67ee727241a6c480", @"/Views/_ViewImports.cshtml")]
    public class Views_Conta_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ContaModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "E:\CLENILDO\01-CURSOS E PROJETOS\C#\MyFinance\MyFinance\Views\Conta\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>Minhas Contas</h3>\r\n<table class=\"table table-bordered\">\r\n    <thead>\r\n        <tr>\r\n            <th>#</th>\r\n            <th>ID</th>\r\n            <th>NOME</th>\r\n            <th>SALDO</th>\r\n        </tr>\r\n    </thead>\r\n");
#nullable restore
#line 16 "E:\CLENILDO\01-CURSOS E PROJETOS\C#\MyFinance\MyFinance\Views\Conta\Index.cshtml"
      
        foreach (var item in (List<ContaModel>)ViewBag.ListaConta)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tbody>\r\n                <tr>\r\n                    <th><button type=\"button\" class=\"btn btn-danger\"");
            BeginWriteAttribute("id", " id=\"", 482, "\"", 506, 1);
#nullable restore
#line 21 "E:\CLENILDO\01-CURSOS E PROJETOS\C#\MyFinance\MyFinance\Views\Conta\Index.cshtml"
WriteAttributeValue("", 487, item.Id.ToString(), 487, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 507, "\"", 550, 3);
            WriteAttributeValue("", 517, "ExcluirConta(", 517, 13, true);
#nullable restore
#line 21 "E:\CLENILDO\01-CURSOS E PROJETOS\C#\MyFinance\MyFinance\Views\Conta\Index.cshtml"
WriteAttributeValue("", 530, item.Id.ToString(), 530, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 549, ")", 549, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Excluir</button></th>\r\n                    <th>");
#nullable restore
#line 22 "E:\CLENILDO\01-CURSOS E PROJETOS\C#\MyFinance\MyFinance\Views\Conta\Index.cshtml"
                   Write(item.Id.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>");
#nullable restore
#line 23 "E:\CLENILDO\01-CURSOS E PROJETOS\C#\MyFinance\MyFinance\Views\Conta\Index.cshtml"
                   Write(item.Nome.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                    <th>R$ ");
#nullable restore
#line 24 "E:\CLENILDO\01-CURSOS E PROJETOS\C#\MyFinance\MyFinance\Views\Conta\Index.cshtml"
                      Write(item.Saldo.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                </tr>\r\n            </tbody>\r\n");
#nullable restore
#line 27 "E:\CLENILDO\01-CURSOS E PROJETOS\C#\MyFinance\MyFinance\Views\Conta\Index.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</table>
<button type=""button"" class=""btn btn-block btn-primary"" onclick=""CriarConta()"">Criar Conta</button>

<script>
    function CriarConta() {
        window.location.href = ""../Conta/CriarConta"";
    }

    function ExcluirConta(id) {
        window.location.href = ""../Conta/ExcluirConta/"" + id;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ContaModel> Html { get; private set; }
    }
}
#pragma warning restore 1591