using Ardalis.ApiEndpoints;
using AutoMapper;
using DNDCatalog.Core.Interfaces;
using DNDCatalog.Web.Endpoints.ArchetypeEndpoints.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DNDCatalog.Web.Endpoints.ArchetypeEndpoints;

public class ArchetypeList : EndpointBaseAsync.WithoutRequest.WithActionResult<ArchetypeListResponse>
{
    private readonly IClassRepository _repository;
    private readonly IMapper _mapper;

    public ArchetypeList(IClassRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;   
    }

    [HttpGet("/api/v1/classes/Archetypes")]
    [SwaggerOperation(
        Summary = "Gets a list of all Archetypes",
        Description = "Gets a list of all Archetypes",
        OperationId = "Archetype.List",
        Tags = new[] { "ArchetypeEndpoints" })
    ]
    public override async Task<ActionResult<ArchetypeListResponse>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var archetypes = await _repository.ListArchetypesAsync(cancellationToken);
        var response = new ArchetypeListResponse
        {
            Archetypes = archetypes
                .Select(a => _mapper.Map<ArchetypeListItemDto>(a))
                .ToList()
        };

        return Ok(response);
    }
}
