using Quiron.LojaVirtual.Web.Models;
using System;
using System.Text;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.HtmlHelpers
{
    public static class PaginacaoHelpers
    {
        // Total de páginas = 3
        // parametros: extentions chamado HtmlHelper, Consumir o paginacao e uma função delegate
        public static MvcHtmlString PageLinks (this HtmlHelper html, Paginacao paginacao, Func<int, string> paginaUrl)
        {
            StringBuilder resultado = new StringBuilder(); // monta a numeração das paginas, o array na parte debaixo da tela 3 4 5 6 ...

            for (int i = 1; i <= paginacao.TotalPaginas; i++)
            {
                TagBuilder tag = new TagBuilder("a"); // porque o texto de hrefs será grande, uma simples string não funciona
                tag.MergeAttribute("href", paginaUrl(i)); // MergeAttributes adiciona atributo que é o hrefs e passo o paginaUrl indice i
                tag.InnerHtml = i.ToString();
                // para marcar com cor diferente a pagina atual usando o bootstrap
                if (i == paginacao.PaginaAtual)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                resultado.Append(tag);
            }
            return MvcHtmlString.Create(resultado.ToString());
        }
    }
}