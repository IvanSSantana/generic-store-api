using GenericStore.API.Data;
using GenericStore.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GenericStore.API.Controllers;

[ApiController]
[Route("api/categorias")]
public class CategoriasController : ControllerBase
{

    private readonly AppDbContext _context;

    public CategoriasController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<Categoria>), StatusCodes.Status200OK)]
    public ActionResult<List<Categoria>> GetAll()
    {
        return Ok(_context.Categorias.ToList());
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Categoria> GetById(int id)
    {
        var categoria = _context.Categorias.Find(id);
        return categoria == null ? NotFound("Categoria não encontrada.") : Ok(categoria);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Categoria> Post([FromBody] Categoria categoria)
    {
        if (!ModelState.IsValid) return BadRequest("Os dados passados estão com formato inválido.");

        _context.Categorias.Add(categoria);
        _context.SaveChanges();

        return CreatedAtAction("Post", new { id = categoria.Id }, categoria);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(Categoria), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Categoria> Put(int id, [FromBody] Categoria categoria)
    {
        if (!ModelState.IsValid || id != categoria.Id)
            return BadRequest("Os dados passados estão com formato inválido.");

        var oldCategoria = _context.Categorias.Find(id);
        if (oldCategoria == null) return NotFound("Categoria não encontrada.");

        oldCategoria.Nome = categoria.Nome;
        oldCategoria.Foto = categoria.Foto ?? oldCategoria.Foto;
        oldCategoria.Cor = categoria.Cor ?? oldCategoria.Cor;

        _context.Entry(oldCategoria).State = EntityState.Modified;
        _context.SaveChanges();

        var novaCategoria = _context.Categorias.Find(id);

        return Ok(novaCategoria);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult Delete(int id)
    {
        var oldCategoria = _context.Categorias.Find(id);

        if (oldCategoria == null) return NotFound("Categoria não encontrada.");

        _context.Categorias.Remove(oldCategoria);
        _context.SaveChanges();

        return NoContent();
    }
}
