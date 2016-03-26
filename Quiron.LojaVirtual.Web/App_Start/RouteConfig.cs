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

            // 1 - Início, lista todas as categorias

            routes.MapRoute(null,
              "",
              new {
                  Controller = "Vitrine",
                  action = "ListaProdutos",
                  categoria = (string)null,
                  pagina = 1 });

            // 2 - A página para todas as categorias

            routes.MapRoute(null,
                  "Pagina{pagina}",
                  new {
                      Controller = "Vitrine",
                      Action = "ListaProdutos",
                      categoria = (string) null},
                    new { pagina = @"\d" });

            // 3 - 1a página de uma categoria


            routes.MapRoute(null,
                "{categoria}", 
                new{
                    Controller = "Vitrine",
                    action = "ListaProdutos",
                    pagina = 1
                });

            // 4 - A página x da Categoria x

            routes.MapRoute(null,
                  "{categoria}Pagina{pagina}",
                  new
                  {
                      Controller = "Vitrine",
                      Action = "ListaProdutos"
                  },
                    new { pagina = @"\d" });

            // Final - Default

            routes.MapRoute(null, "{controller}/{action}");

        }
    }
}
