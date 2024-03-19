using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Products.Models;

namespace Products.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase {
    private readonly ILogger<ProductsController> _logger;
    public ProductsController(ILogger<ProductsController> logger) {
        _logger = logger;
    } 

    [HttpPost]
    [Consumes("application/x-www-form-urlencoded")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Product>> PostForm([FromForm] Product prod) {
        Product? p = await Connect.Insert(prod);

        return CreatedAtAction(null, p);
    }

    [HttpPost]
    [Consumes("application/json")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Product>> Post(Product prod) {
        Product? p = await Connect.Insert(prod);

        return CreatedAtAction(null, p);
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> Get() {
        List<Product> list = await Connect.GetAll();

        return list;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetOne(int id) {
        Product? p = await Connect.GetOne(id);

        if (p == null) {
            return NotFound();
        }

        return p;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Product>> Delete(int id) {
        Product? prod = await Connect.DeleteOne(id);

        if (prod == null) {
            return NotFound();
        }
        
        return prod;
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<Product>> UpdateField(int id, JsonDocument change) {
        var field = change.RootElement.GetProperty("field").ToString();
        var val = change.RootElement.GetProperty("value").ToString();


        Product? prod = await Connect.UpdateField(id, field, val);

        if (prod == null) {
            return NotFound();
        }
        
        return prod;
    }

    [HttpPut("{id}")]
    [Consumes("multipart/form-data")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Product>> UpdateProductForm(int id, [FromForm] Product prod) {
        Product? product = await Connect.UpdateProduct(id, prod);

        if (product == null) {
            return NotFound();
        }

        return product;
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Product>> UpdateProduct(int id, Product prod) {
        Product? product = await Connect.UpdateProduct(id, prod);

        if (product == null) {
            return NotFound();
        }

        return product;
    }
}
