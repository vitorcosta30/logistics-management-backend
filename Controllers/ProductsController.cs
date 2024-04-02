using logistics_management_backend.Domain.Shared;
using logistics_management_backend.DTO.Products;
using logistics_management_backend.Services.Products;
using Microsoft.AspNetCore.Mvc;

namespace logistics_management_backend.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;
    public ProductsController( IProductService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<ProductDTO>> CreateProduct(ProductDTO newProduct)
    {
        try
        {
            var prod = await _service.addProduct(newProduct);
            return CreatedAtAction("CreateProduct", new { id = prod.Id}, prod);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll(){
        return await _service.getAllAsync();
    }
}