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


public class SourceList : EndpointBaseAsync.WithoutRequest.WithActionResult<SourceListResponse>
{
    private readonly ISourceRepository _repository;

    public SourceList(ISourceRepository repository)
    {
        _repository = repository;
    }


    [HttpGet("/api/v1/Sources")]
    [SwaggerOperation(
        Summary = "Gets a list of all Sources",
        Description = "Gets a list of all Sources",
        OperationId = "Archetype.List",
        Tags = new[] { "SourceEndpoints" })
    ]
    public override async Task<ActionResult<SourceListResponse>> HandleAsync(CancellationToken cancellationToken = default)
    {
        //var spec = new SourceListSpec();
        //var sources = await _repository.ListAsync(spec, cancellationToken);
        var sources = await _repository.ListSourcesAsync(cancellationToken);

        var response = new SourceListResponse
        {
            Sources = sources.ToList()
        };

        return Ok(response);
    }
}
