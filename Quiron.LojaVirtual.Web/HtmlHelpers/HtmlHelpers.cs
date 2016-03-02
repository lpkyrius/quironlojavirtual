using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.Models;
using System.Text;

namespace Quiron.LojaVirtual.Web.HtmlHelpers
{
    public static class HtmlHelpers
    {
        // parametros: extentions chamado HtmlHelper, Consumir o paginacao e uma função delegate
        public static MvcHtmlString PageLinks (this HtmlHelper html, Paginacao paginacao, Func<int, string> paginaUrl)
        {
            StringBuilder resultado = new StringBuilder();

            for (int i = 0; i < paginacao.TotalPaginas; i++)
            {

            }
        }
    }
}