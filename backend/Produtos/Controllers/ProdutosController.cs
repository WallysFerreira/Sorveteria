using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Produtos.Models;

namespace Produtos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase {
    private readonly ILogger<ProdutosController> _logger;
    public ProdutosController(ILogger<ProdutosController> logger) {
        _logger = logger;
    } 

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<Produto> Post(Produto prod) {
        Conectar.Inserir(prod);

        return CreatedAtAction(null, prod);
    }

    [HttpGet]
    public async Task<IEnumerable<Produto>> Get() {
        List<Produto> lista = await Conectar.PegarTodos();

        return lista;
    }
}