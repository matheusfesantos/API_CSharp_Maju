using Microsoft.AspNetCore.Mvc;
using ProdutoEntity.Entity;
using ProdutoRepository.Repository;
using ProdutoService.Services;

namespace ProdutoController.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutosService _produtoServ; // Declarando a interface
        // ProdutoService é uma classe que implementa a lógica de negócios para os produtos.

        [HttpGet]//Requisição do tipo GET
        public ActionResult<IEnumerable<Produtos>> GetAllProdutos()
        {
            var produtos = _produtoServ.GetAllProdutos();
            return Ok(produtos);
        }

        [HttpGet("{id}")]//Requisição do tipo GET
        public ActionResult<Produtos> GetByID(int id)
        {
            var produto = _produtoServ.GetByID(id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]//Requisição do tipo POST
        public ActionResult Add([FromBody] Produtos produtos)
        {
            if (produtos == null)
            {
                return BadRequest("Produto não pode ser nulo.");
            }
            _produtoServ.Add(produtos);
            return CreatedAtAction(nameof(GetByID), new { id = produtos.Id }, produtos);
        }

        [HttpDelete("{id}")]//Requisição do tipo DELETE
        public ActionResult DeletarProduto(int id)
        {
            try
            {
                _produtoServ.DeletarProduto(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}