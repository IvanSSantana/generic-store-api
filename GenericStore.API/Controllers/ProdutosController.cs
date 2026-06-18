using GenericStore.API.Data;
using GenericStore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GenericStore.API.Controllers;

[ApiController]
[Route("api/Produtos")]
public class ProdutosController : ControllerBase
{

    private readonly AppDbContext _context;

    public ProdutosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Produto>), StatusCodes.Status200OK)]
    public ActionResult<List<Produto>> GetAll()
    {
        return Ok(_context.Produtos.ToList());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Produto> GetById(int id)
    {
        var produto = _context.Produtos.Find(id);
        return produto == null ? NotFound("Produto não encontrada.") : Ok(produto);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Produto> Post([FromBody] Produto Produto)
    {
        if (!ModelState.IsValid) return BadRequest("Os dados passados estão com formato inválido.");

        _context.Produtos.Add(Produto);
        _context.SaveChanges();

        return CreatedAtAction("Post", new { id = Produto.Id }, Produto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Produto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Produto> Put(int id, [FromBody] Produto produto)
    {
        if (!ModelState.IsValid || id != produto.Id)
            return BadRequest("Os dados passados estão com formato inválido.");

        var oldProduto = _context.Produtos.Find(id);
        if (oldProduto == null) return NotFound("Produto não encontrada.");

        oldProduto.Nome = produto.Nome;
        oldProduto.CategoriaId = produto.CategoriaId; 

        var categoriaNoDb = _context.Categorias.Find(produto.CategoriaId);
        if (categoriaNoDb == null) return BadRequest("Categoria não encontrada.");

        oldProduto.Descricao = produto.Descricao ?? oldProduto.Descricao;
        oldProduto.Qtde = produto.Qtde;
        oldProduto.ValorCusto = produto.ValorCusto;
        oldProduto.ValorVenda = produto.ValorVenda;
        oldProduto.Destaque = produto.Destaque || oldProduto.Destaque;
        oldProduto.Foto = produto.Foto ?? oldProduto.Foto;

        _context.Entry(oldProduto).State = EntityState.Modified;
        _context.SaveChanges();

        var novaProduto = _context.Produtos.Find(id);

        return Ok(novaProduto);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Delete(int id)
    {
        var oldProduto = _context.Produtos.Find(id);

        if (oldProduto == null) return NotFound("Produto não encontrada.");

        _context.Produtos.Remove(oldProduto);
        _context.SaveChanges();

        return NoContent();
    }
}
