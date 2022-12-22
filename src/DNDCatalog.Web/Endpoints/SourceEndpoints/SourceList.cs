using Ardalis.ApiEndpoints;
using Ardalis.Specification;
using DNDCatalog.Core.Interfaces;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.Core.SpellAggregate.Specifications;
using DNDCatalog.SharedKernel.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DNDCatalog.Web.Endpoints.SourceEndpoints;


public class SourceList : EndpointBaseAsync.WithRequest<SourceListRequest>.WithActionResult<SourceListResponse>
{
    private readonly ISourceRepository _repository;

    public SourceList(ISourceRepository repository)
    {
        _repository = repository;
    }


    [HttpGet("/api/v1/Sources/{Section?}")]
    [SwaggerOperation(
        Summary = "Gets a list of Sources",
        Description = "Gets a list of Sources",
        OperationId = "Source.List",
        Tags = new[] { "SourceEndpoints" })
    ]
    public override async Task<ActionResult<SourceListResponse>> HandleAsync([FromRoute] SourceListRequest request, CancellationToken cancellationToken = default)
    {
        IReadOnlyList<string?> sources = null!;

        sources = request.Section?.ToLower() switch
        {
            "spells" => await _repository.ListSpellsSourcesAsync(cancellationToken),
            "magic-items" => await _repository.ListMagicItemsSourcesAsync(cancellationToken),
            _ => await _repository.ListSourcesAsync(cancellationToken),
        };


        var response = new SourceListResponse
        {
            Sources = sources.ToList()
        };

        return Ok(response);
    }
}
