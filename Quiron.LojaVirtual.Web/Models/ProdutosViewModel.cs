using Quiron.LojaVirtual.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// A view model fica aqui no Quiron.LojaVirtual.Web e não no Dominio porque ela não faz parte do domínio, ela representa classes do dominio.
// Conceito de view model é representar além da sua classe 
namespace Quiron.LojaVirtual.Web.Models
{
    public class ProdutosViewModel
    {
        public IEnumerable<Produto> Produtos { get; set; }

        public Paginacao Paginacao { get; set; }  
    }
}