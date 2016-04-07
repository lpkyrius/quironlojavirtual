using System.Web.Mvc;
using System.Web.Routing;

namespace Quiron.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // a ideia é trazer as rotas da mais simples para a mais complexas
            // apenas / trará todas as categorias
            // Pagina2 trará a página 2 de todas as categorias
            // Futebol trará a 1a pagina da categoria futebol]
            // Futebol/Pagina2 trará a página 2 da categoria futebol
            // @"\d"  é uma regular expression para que só aceite números inteiros

            // 1 - Home

            routes.MapRoute(null, "", new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null, pagina = 1 });



            // 2 - 
            routes.MapRoute(null,
                "Pagina{pagina}",
                new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null }, new { pagina = @"\d+" });


            routes.MapRoute(null,
                "{categoria}", new { controller = "Vitrine", action = "ListaProdutos", pagina = 1 });



            routes.MapRoute(null,
                "{categoria}/Pagina{pagina}", new { controller = "Vitrine", action = "ListaProdutos" }, new { pagina = @"\d+" });



            routes.MapRoute(null, "{controller}/{action}");


        }
    }
}
