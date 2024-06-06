using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechnoShopApi.Inventory.Domain.Model.Commands;
using TechnoShopApi.Inventory.Domain.Model.Queries;
using TechnoShopApi.Inventory.Domain.Services;
using TechnoShopApi.Inventory.Interface.REST.Resources;
using TechnoShopApi.Inventory.Interface.REST.Transform;

namespace TechnoShopApi.Inventory.Interface.REST;

[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[ProducesResponseType(500)]
[ProducesResponseType(409)]
[Route("api/v1/[controller]")]
public class ProductController(IProductCommandService commandService, IProductQueryService queryService) : ControllerBase
{
    
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(409)]
     public async Task<IActionResult> CreateProduct([FromBody] CreateProductResource resource)
    {
        var command = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var product = await commandService.Handle(command); 
        if(product == null) return BadRequest();
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return StatusCode(201, productResource);
    }
     
     [HttpGet]
     [ProducesResponseType(200)]
     [ProducesResponseType(404)]
     public async Task<IActionResult> GetProducts()
     {
         var query = new GetAllProductsQuery();
         var products = await queryService.Handle(query);
         var productResource = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
         return Ok(productResource);
     }

     [HttpGet]
     [Route("{id}")]
     [ProducesResponseType(200)]
     [ProducesResponseType(404)]
     public async Task<IActionResult> GetProductById(long id)
     {
         var query = new GetProductByIdQuery(id);
         var product = await queryService.Handle(query);
         if (product != null)
         {
             var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
             return Ok(productResource);
         }
         return NotFound();
     }
     
     [HttpPut]
     [Route("{id}")]
     [ProducesResponseType(200)]
     [ProducesResponseType(404)]
     public async Task<IActionResult> UpdateProduct(long id, [FromBody] UpdateProductResource resource)
     {
         var query = new GetProductByIdQuery(id);
         var product = await queryService.Handle(query);
         if (product == null) return NotFound();
         var command = UpdateProductCommandFromResourceAssembler.ToCommandFromResource(resource); 
         var updatedProduct = await commandService.Handle(id,command);
         var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(updatedProduct);
         return Ok(productResource);
     }
     
     [HttpDelete]
     [Route("{id}")]
     [ProducesResponseType(200)]
     [ProducesResponseType(404)]
     public async Task<IActionResult> DeleteProduct(long id)
     {
         var command = new DeleteProductCommand(id);
         var product = await commandService.Handle(command);
         if (product == null) return NotFound();
         var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
         return Ok(productResource);
     }

}