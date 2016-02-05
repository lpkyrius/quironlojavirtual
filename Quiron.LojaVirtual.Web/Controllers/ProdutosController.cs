using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class ProdutosController : Controller
    {
        private Dominio.Repositorio.ProdutosRepositorio _repositorio;

        // GET: Produtos
        public ActionResult Index()
        {
            _repositorio = new Dominio.Repositorio.ProdutosRepositorio();
            var produtos = _repositorio.Produtos.Take(10); // Take seria o Top do Sql, retornará os 10 primeiros produtos

            return View(produtos);
        }
    }
}