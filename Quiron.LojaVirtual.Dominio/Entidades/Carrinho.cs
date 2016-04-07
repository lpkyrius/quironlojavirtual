using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Carrinho
    {

        private readonly List<ItemCarrinho> _ItemCarrinho = new List<ItemCarrinho>();

        // Adicionar

        public void AdicionarItem(Produto produto, int quantidade)
        {
            ItemCarrinho item = _ItemCarrinho.FirstOrDefault(p => p.Produto.ProdutoId == produto.ProdutoId);
            if (item == null)
            {
                _ItemCarrinho.Add(new ItemCarrinho
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                item.Quantidade += quantidade;
            }

        }

        // Remover item

        public void Remover(Produto produto)
        {
            _ItemCarrinho.RemoveAll(l => l.Produto.ProdutoId == produto.ProdutoId);
        }
        // Obter o valor total

        public decimal ObterValorTotal()
        {
            _ItemCarrinho.Sum(e => e.Produto.Preco * e.Quantidade);
        }

        // Limpara o carrinho

        public void LimparCarrinho()
        {
            _ItemCarrinho.Clear();
        }

        // Itens do carrinho

        public IEnumerable<ItemCarrinho> ItensCarrinho
        {
            get { return _ItemCarrinho; }
        }
    }

    public class ItemCarrinho
    {
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
