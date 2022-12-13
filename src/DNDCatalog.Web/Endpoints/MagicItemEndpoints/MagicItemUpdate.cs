using Ardalis.ApiEndpoints;
using AutoMapper;
using DNDCatalog.Core.Interfaces;
using DNDCatalog.Infrastructure.Identity;
using DNDCatalog.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DNDCatalog.Web.Endpoints.MagicItemEndpoints;

public class MagicItemUpdate : EndpointBaseAsync.WithRequest<UpdateMagicItemRequest>.WithActionResult<UpdateMagicItemResponse>
{
    private readonly IMagicItemRepository _repository;
    private readonly IMapper _mapper;

    public MagicItemUpdate(IMagicItemRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpPut("api/v1/MagicItems")]
    [SwaggerOperation(
        Summary = "Updates a MagicItem",
        Description = "Updates a MagicItem details",
        OperationId = "MagicItem.Update",
        Tags = new[] { "MagicItemEndpoints" })
    ]
    [Authorize(Roles = nameof(Roles.EDITORS), AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public override async Task<ActionResult<UpdateMagicItemResponse>> HandleAsync(UpdateMagicItemRequest request, CancellationToken cancellationToken = default)
    {
        var existingMagicItem = await _repository.GetByIdAsync(request.Id, cancellationToken);
        if (existingMagicItem is null)
        {
            return NotFound();
        }

        _mapper.Map(request, existingMagicItem);
        await _repository.UpdateAsync(existingMagicItem, cancellationToken);
        var response = _mapper.Map<UpdateMagicItemResponse>(existingMagicItem);

        return Ok(response);
    }
}
