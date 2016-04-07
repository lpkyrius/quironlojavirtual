using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private Dominio.Repositorio.ProdutosRepositorio _repositorio;
        public int ProdutosPorPagina = 3; // Pode ser um parâmetro ou por o valor no webconfig
        // GET: Vitrine
        public ViewResult ListaProdutos(string categoria, int Pagina = 1)

        {
            _repositorio = new Dominio.Repositorio.ProdutosRepositorio();

            ProdutosViewModel model = new ProdutosViewModel
            {
                //feito o skip dos registros exibidos nas paginas anteriores, agora pega os n produtos que devem ser exibidos nesta pagina (atual)
                // recebe a página que vai exibir, multiplca para pegar a quantidade (por pagina) que deve descosiderar pois já foram exibidos nas paginas anteriores
                // na primeira vez, categoria vai vir nulo

                Produtos = _repositorio.Produtos
                .Where(p => categoria == null || p.Categoria == categoria)
                .OrderBy(p => p.Descricao)
                .Skip((Pagina - 1) * ProdutosPorPagina)
                .Take(ProdutosPorPagina),

                Paginacao = new Paginacao
                {
                    PaginaAtual = Pagina,
                    ItensPorPagina = ProdutosPorPagina,
                    ItensTotal = _repositorio.Produtos.Count()
                },

                CategoriaAtual = categoria

            };

            return View(model);
        }
    }
}