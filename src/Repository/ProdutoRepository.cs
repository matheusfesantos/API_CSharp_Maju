using System.Collections.Generic;
using ProdutoEntity.Entity;

namespace ProdutoRepository.Repository
{
    public interface IProdutoRepository
    {
        IEnumerable<Produtos> GetAllProdutos();
        Produtos GetByID(int id);
        void Add(Produtos produtos);
        void Update(Produtos produtos);

        void Delete(int id);
    }
}