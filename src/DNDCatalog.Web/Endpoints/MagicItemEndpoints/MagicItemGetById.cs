using Ardalis.ApiEndpoints;
using AutoMapper;
using DNDCatalog.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DNDCatalog.Web.Endpoints.MagicItemEndpoints;

public class MagicItemGetById : EndpointBaseAsync.WithRequest<GetMagicItemByIdRequest>.WithActionResult<GetMagicItemByIdResponse>
{
    private readonly IMagicItemRepository _repository;
    private readonly IMapper _mapper;

    public MagicItemGetById(IMagicItemRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("/api/v1/MagicItems/{MagicItemId:guid}")]
    [SwaggerOperation(
      Summary = "Gets a single MagicItem",
      Description = "Gets a single MagicItem by Id",
      OperationId = "MagicItem.GetById",
      Tags = new[] { "MagicItemEndpoints" })
    ]
    public override async Task<ActionResult<GetMagicItemByIdResponse>> HandleAsync([FromRoute] GetMagicItemByIdRequest request, CancellationToken cancellationToken = default)
    {
        var magicItem = await _repository.GetByIdAsync(request.MagicItemId, cancellationToken);
        if (magicItem == null)
        {
            return NotFound();
        }

        var response = _mapper.Map<GetMagicItemByIdResponse>(magicItem);

        return Ok(response);
    }
}
