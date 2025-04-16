using System;
using System.Collections.Generic;
using ProdutoEntity.Entity;
using ProdutoRepository.Repository;

namespace ProdutoService.Services
{
    public class ProdutosService
    {
        private readonly IProdutoRepository _produtoRepos; // Declarando a interface
        // IProdutoRepository é uma interface que define os métodos que a classe ProdutosService deve implementar.

        public ProdutosService(IProdutoRepository produtoRepos)
        {
            _produtoRepos = produtoRepos;
        }

        public IEnumerable<Produtos> GetAllProdutos()
        {
            return _produtoRepos.GetAllProdutos();
        }

        public Produtos GetByID(int id)
        {
            return _produtoRepos.GetByID(id);
        }

        public void Add(Produtos produtos)
        {
            if (produtos == null)
            {
                throw new ArgumentNullException(nameof(produtos));
            }
            _produtoRepos.Add(produtos);
        }

        public void DeletarProduto(int id)
        {
            var produto = _produtoRepos.GetByID(id); // Ver se o produto existe
            if (produto == null)
            {
                throw new KeyNotFoundException($"Produto com ID {id} não encontrado.");
            }
            _produtoRepos.Delete(id);
        }
    }
}