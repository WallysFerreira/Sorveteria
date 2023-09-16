using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Produtos.Models;

namespace Produtos.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutosController : ControllerBase {
    private readonly ILogger<ProdutosController> _logger;
    public ProdutosController(ILogger<ProdutosController> logger) {
        _logger = logger;
    } 

    [HttpGet]
    public IEnumerable<Produto> Get() {
        return Enumerable.Range(1,3).Select(index => new Produto {
            Categoria = "Sorvetes",
            Nome = "Flocos",
            Preco = 10.0f,
            Descricao = "Sorvete de flocos",
            Foto = "/flocos.jpg",
        }).ToArray();
    }

}