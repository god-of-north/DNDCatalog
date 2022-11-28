using Ardalis.ApiEndpoints;
using AutoMapper;
using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.Interfaces;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.Core.SpellAggregate.Specifications;
using DNDCatalog.SharedKernel.Interfaces;
using DNDCatalog.Web.Endpoints.SpellEndpoints.Dtos;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DNDCatalog.Web.Endpoints.SpellEndpoints;

public class SpellList : EndpointBaseAsync.WithRequest<SpellListRequest>.WithActionResult<SpellListResponse>
{
    private readonly ISpellRepository _repository;
    private readonly IMapper _mapper;


    public SpellList(ISpellRepository repository, IMapper mapper)
    {
        _repository = repository;   
        _mapper = mapper;
    }

    [HttpGet("/api/v1/Spells")]
    [SwaggerOperation(
        Summary = "Gets a filtred list of Spells",
        Description = "Gets a filtred list of Spells",
        OperationId = "Spell.List",
        Tags = new[] { "SpellEndpoints" })
    ]
    public override async Task<ActionResult<SpellListResponse>> HandleAsync([FromQuery] SpellListRequest request, CancellationToken cancellationToken = default)
    {
        var filterSpec = _mapper.Map<FilterSpellListSpec>(request);
        var paginatedSpec = _mapper.Map<FilterSpellListWithPagesSpec>(request);
        var spells = await _repository.ListAsync(paginatedSpec, cancellationToken);
        var totalCount = await _repository.CountAsync(filterSpec, cancellationToken);

        var response = new SpellListResponse
        {
            Spells = spells
                .Select(spell => _mapper.Map<SpellListItemDto>(spell))
                .ToList(),
            TotalCount = totalCount,
        };

        return Ok(response);
    }
}
