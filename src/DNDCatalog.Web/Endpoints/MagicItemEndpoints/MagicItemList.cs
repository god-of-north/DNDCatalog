using Ardalis.ApiEndpoints;
using AutoMapper;
using DNDCatalog.Core.Interfaces;
using DNDCatalog.Core.MagicItemAggregate.Specifications;
using DNDCatalog.Web.Endpoints.MagicItemEndpoints.Dtos;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DNDCatalog.Web.Endpoints.MagicItemEndpoints;

public class MagicItemList : EndpointBaseAsync.WithRequest<MagicItemListRequest>.WithActionResult<MagicItemListResponse>
{
    private readonly IMagicItemRepository _repository;
    private readonly IMapper _mapper;


    public MagicItemList(IMagicItemRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet("/api/v1/MagicItems")]
    [SwaggerOperation(
        Summary = "Gets a filtred list of MagicItems",
        Description = "Gets a filtred list of MagicItems",
        OperationId = "MagicItem.List",
        Tags = new[] { "MagicItemEndpoints" })
    ]
    public override async Task<ActionResult<MagicItemListResponse>> HandleAsync([FromQuery] MagicItemListRequest request, CancellationToken cancellationToken = default)
    {
        var filterSpec = _mapper.Map<FilterMagicItemListSpec>(request);
        var paginatedSpec = _mapper.Map<FilterMagicItemListWithPagesSpec>(request);
        var magicItems = await _repository.SearchByNameWithFilterAsync(paginatedSpec, request.Search, cancellationToken);
        var totalCount = await _repository.SearchByNameWithFilterCountAsync(filterSpec, request.Search, cancellationToken);

        var response = new MagicItemListResponse
        {
            MagicItems = magicItems
                .Select(magicItem => _mapper.Map<MagicItemListItemDto>(magicItem))
                .ToList(),
            TotalCount = totalCount,
        };

        return Ok(response);
    }
}
