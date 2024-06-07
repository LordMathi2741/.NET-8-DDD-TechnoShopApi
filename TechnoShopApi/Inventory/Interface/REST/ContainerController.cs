using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
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
public class ContainerController(IContainerCommandService commandService) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(201)]
    public async Task<IActionResult> CreateContainer([FromBody] CreateContainerResource resource)
    {
        var command = CreateContainerCommandFromResourceAssembler.ToCommandFromResource(resource);
        var container = await commandService.Handle(command);
        if (container == null ) return BadRequest();
        var containerResource = ContainerResourceFromEntityAssembler.ToResourceFromEntity(container);
        return StatusCode(201, containerResource);
    }
    
}