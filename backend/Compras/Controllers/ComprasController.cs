using Compras.Models;
using Compras.Services;
using Microsoft.AspNetCore.Mvc;

namespace Compras.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComprasController : ControllerBase
{
    private readonly ComprasService _comprasService;

    public ComprasController(ComprasService comprasService) =>
        _comprasService = comprasService;

    [HttpGet]
    public async Task<List<Compra>> Get() =>
        await _comprasService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Compra>> Get(string id)
    {
        var compra = await _comprasService.GetAsync(id);

        if(compra is null)
        {
            return NotFound();
        }

        return compra;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Compra newCompra)
    {
        await _comprasService.CreateAsync(newCompra);

        return CreatedAtAction(nameof(Get), new { id = newCompra.Id }, newCompra);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Compra updatedCompra)
    {
        var compra = await _comprasService.GetAsync(id);

        if (compra is null )
        {
            return NotFound();
        }

        updatedCompra.Id = compra.Id;

        await _comprasService.UpdateAsync(id, updatedCompra);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var compra = await _comprasService.GetAsync(id);

        if (compra is null)
        {
            return NotFound();
        }

        await _comprasService.RemoveAsync(id);

        return NoContent();
    }
}