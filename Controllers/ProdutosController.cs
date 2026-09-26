using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//incluir o namespace dos serviços
using CadastroProdutos.Services;

namespace CadastroProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        // Interface do serviço de produtos
        private IProdutosService produtosService;

        public ProdutosController(IProdutosService produtosService)
        {
            this.produtosService = produtosService;
        }

        [HttpGet]
        public ActionResult<List<Produto>> GetProdutos()
        {
            return Ok(produtosService.ObterTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<Produto> GetById(int id)
        {
            var produto = produtosService.ObterPorId(id);

            if (produto is null)
            {
                return NotFound($"Produto {id} não encontrado!");
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Post(Produto novoProduto)
        {
            produtosService.Adicionar(novoProduto);

            return Created();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Produto produtoAtualizado)
        {
            var produto = produtosService.Atualizar(id, produtoAtualizado);

            if (produto is null)
            {
                return NotFound($"Produto {id} não encontrado!");
            }

            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var deletado = produtosService.Remover(id);

            if (deletado == false)
            {
                return NotFound($"Produto {id} não encontrado!");
            }

            return NoContent();
        }
    }
}
