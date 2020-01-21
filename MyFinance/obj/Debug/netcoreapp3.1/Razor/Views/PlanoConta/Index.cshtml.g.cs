#pragma checksum "C:\Clenildo\C#\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "973d01fdf765952f5acf17626028dafabacd3280"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_PlanoConta_Index), @"mvc.1.0.view", @"/Views/PlanoConta/Index.cshtml")]
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
#line 1 "C:\Clenildo\C#\MyFinance\MyFinance\Views\_ViewImports.cshtml"
using MyFinance;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Clenildo\C#\MyFinance\MyFinance\Views\_ViewImports.cshtml"
using MyFinance.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"973d01fdf765952f5acf17626028dafabacd3280", @"/Views/PlanoConta/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d05dd6abef5a8ff60f9a555c67ee727241a6c480", @"/Views/_ViewImports.cshtml")]
    public class Views_PlanoConta_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PlanoContaModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Clenildo\C#\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h3>Planos de Contas</h3>\r\n<table class=\"table table-bordered\">\r\n    <thead>\r\n        <tr>\r\n            <th>#</th>\r\n            <th>#</th>\r\n            <th>ID</th>\r\n            <th>DESCRIÇÃO</th>\r\n            <th>TIPO</th>\r\n        </tr>\r\n    </thead>\r\n");
#nullable restore
#line 17 "C:\Clenildo\C#\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
      
        foreach (var item in (List<PlanoContaModel>)ViewBag.ListaPlanoConta)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tbody>\r\n                    <tr>\r\n                        <td><button type=\"button\" class=\"btn btn-primary\"");
            BeginWriteAttribute("id", " id=\"", 537, "\"", 561, 1);
#nullable restore
#line 22 "C:\Clenildo\C#\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
WriteAttributeValue("", 542, item.Id.ToString(), 542, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 562, "\"", 609, 3);
            WriteAttributeValue("", 572, "EditarPlanoConta(", 572, 17, true);
#nullable restore
#line 22 "C:\Clenildo\C#\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
WriteAttributeValue("", 589, item.Id.ToString(), 589, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 608, ")", 608, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Editar</button></td>\r\n                        <td><button type=\"button\" class=\"btn btn-danger\"");
            BeginWriteAttribute("id", " id=\"", 705, "\"", 729, 1);
#nullable restore
#line 23 "C:\Clenildo\C#\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
WriteAttributeValue("", 710, item.Id.ToString(), 710, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 730, "\"", 778, 3);
            WriteAttributeValue("", 740, "ExcluirPlanoConta(", 740, 18, true);
#nullable restore
#line 23 "C:\Clenildo\C#\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
WriteAttributeValue("", 758, item.Id.ToString(), 758, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 777, ")", 777, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Excluir</button></td>\r\n                        <td>");
#nullable restore
#line 24 "C:\Clenildo\C#\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
                       Write(item.Id.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 25 "C:\Clenildo\C#\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
                       Write(item.Descricao.ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 26 "C:\Clenildo\C#\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
                       Write(item.Tipo.ToString().Replace("R", "Receita").Replace("D", "Despesa"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    </tr>\r\n            </tbody>\r\n");
#nullable restore
#line 29 "C:\Clenildo\C#\MyFinance\MyFinance\Views\PlanoConta\Index.cshtml"
        }
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</table>
<button type=""button"" class=""btn btn-block btn-primary"" onclick=""CriarPlanoConta()"">Criar Conta</button>

<script>
    function CriarPlanoConta() {
        window.location.href = ""../PlanoConta/CriarPlanoConta"";
    }

    function ExcluirPlanoConta(id) {
        window.location.href = ""../PlanoConta/ExcluirPlanoConta/"" + id;
    }

        function EditarPlanoConta(id) {
        window.location.href = ""../PlanoConta/CriarPlanoConta/"" + id;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PlanoContaModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
