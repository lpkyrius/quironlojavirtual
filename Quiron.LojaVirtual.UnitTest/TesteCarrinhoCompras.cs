using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidades;
using System.Linq;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        // Teste adicionar itens ao carrinho

        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            // Arrange - criação dos produtos
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };
            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            // Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 2);

            carrinho.AdicionarItem(produto2, 3);

            // Act
            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            // Assert
            Assert.AreEqual(itens.Length, 2); // verifica se a quantidade de itens do carrinho é igual a 2
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);
        }

        [TestMethod]
        public void AdicionarProdutoExistenteParaCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };
            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            Produto produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Teste 3"
            };

            // Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);

            carrinho.AdicionarItem(produto2, 1);

            carrinho.AdicionarItem(produto1, 10);

            // Act
            ItemCarrinho[] resultado = carrinho.ItensCarrinho
                .OrderBy(c => c.Produto.ProdutoId).ToArray();

            Assert.AreEqual(resultado.Length, 2); // valida quantidade de produtos

            Assert.AreEqual(resultado[0].Quantidade, 11); // valida quantidade do produto 1

            Assert.AreEqual(resultado[1].Quantidade, 1); // valida quantidade do produto 2


        }


        [TestMethod]

        public void RemoverItensCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };
            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            Produto produto3 = new Produto
            {
                ProdutoId = 3,
                Nome = "Teste 3"
            };

            // Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);

            carrinho.AdicionarItem(produto2, 3);

            carrinho.AdicionarItem(produto3, 5);

            carrinho.AdicionarItem(produto2, 1);

            carrinho.RemoverItem(produto2); // vou remover somente o produto 2

            Assert.AreEqual(carrinho.ItensCarrinho.Where(c => c.Produto == produto2).Count(), 0); // teste se tem zero porque removi tudo

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 2); // testa se só ficaram realmente dois produtos no carrinho

        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M // M porque a variável é decimal
            };
            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M // M porque a variável é decimal
            };

            // Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);

            carrinho.AdicionarItem(produto2, 1);

            carrinho.AdicionarItem(produto1, 3);

            decimal resultado = carrinho.ObterValorTotal(); // pegando o valor

            Assert.AreEqual(resultado, 450M);
            
        }

        [TestMethod]
        public void LimparItensCarrinho()
        {
            Produto produto1 = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M // M porque a variável é decimal
            };
            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M // M porque a variável é decimal
            };

            // Arrange
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);

            carrinho.AdicionarItem(produto2, 1);

            carrinho.LimparCarrinho(); // limpando todo o carrinho para testar

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);

        }

    }

}
