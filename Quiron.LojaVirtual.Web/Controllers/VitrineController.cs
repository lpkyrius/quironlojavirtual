using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private Dominio.Repositorio.ProdutosRepositorio _repositorio;
        public int ProdutosPorPagina = 3; // Pode ser um parâmetro ou por o valor no webconfig
        // GET: Vitrine
        public ActionResult ListaProdutos(int Pagina = 1)
        {
            _repositorio = new Dominio.Repositorio.ProdutosRepositorio();
            var produtos = _repositorio.Produtos
                .OrderBy(p => p.Descricao)
                .Skip((Pagina - 1)*ProdutosPorPagina) // recebe a página que vai exibir, multiplca para pegar a quantidade (por pagina) que deve descosiderar pois já foram exibidos nas paginas anteriores
                .Take(ProdutosPorPagina); //feito o skip dos registros exibidos nas paginas anteriores, agora pega os n produtos que devem ser exibidos nesta pagina (atual)

            return View(produtos);
        }
    }
}