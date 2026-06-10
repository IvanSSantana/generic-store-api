using GenericStore.API.Data;
using GenericStore.API.Models;
using Microsoft.AspNetCore.Mvc;

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
}
