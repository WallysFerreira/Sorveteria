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
    [Consumes("application/x-www-form-urlencoded")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Produto>> PostForm([FromForm] Produto prod) {
        Produto? p = await Conectar.Inserir(prod);

        return CreatedAtAction(null, p);
    }

    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Produto>> Post(Produto prod) {
        Produto? p = await Conectar.Inserir(prod);

        return CreatedAtAction(null, p);
    }

    [HttpGet]
    public async Task<IEnumerable<Produto>> Get() {
        List<Produto> lista = await Conectar.PegarTodos();

        return lista;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Produto>> GetUm(int id) {
        Produto? p = await Conectar.PegarUm(id);

        if (p == null) {
            return NotFound();
        }

        return p;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Produto>> Delete(int id) {
        Produto? prod = await Conectar.DeletarUm(id);

        if (prod == null) {
            return NotFound();
        }
        
        return prod;
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<Produto>> AtualizarCampo(int id, JsonDocument mudanca) {
        var campo = mudanca.RootElement.GetProperty("campo").ToString();
        var valor = mudanca.RootElement.GetProperty("valor").ToString();


        Produto? prod = await Conectar.AtualizarCampo(id, campo, valor);

        if (prod == null) {
            return NotFound();
        }
        
        return prod;
    }

    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Produto>> AtualizarProduto(int id, [FromForm] Produto prod) {
        Produto? produto = await Conectar.AtualizarProduto(id, prod);

        if (produto == null) {
            return NotFound();
        }

        return produto;
    }
}