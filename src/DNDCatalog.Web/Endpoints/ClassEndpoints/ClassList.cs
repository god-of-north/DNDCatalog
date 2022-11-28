using Ardalis.ApiEndpoints;
using AutoMapper;
using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Infrastructure.Identity;
using DNDCatalog.SharedKernel.Interfaces;
using DNDCatalog.Web.Endpoints.ClassEndpoints.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DNDCatalog.Web.Endpoints.ClassEndpoints;

public class ClassList : EndpointBaseAsync.WithoutRequest.WithActionResult<ClassListResponse>
{
    private readonly IRepository<Class> _repository;
    private readonly IMapper _mapper;

    public ClassList(IRepository<Class> repository, IMapper mapper)
    {
        _repository = repository;   
        _mapper = mapper;   
    }


    [HttpGet("/api/v1/Classes")]
    [SwaggerOperation(
        Summary = "Gets a list of all Classes",
        Description = "Gets a list of all Classes",
        OperationId = "Class.List",
        Tags = new[] { "ClassEndpoints" })
    ]
    public override async Task<ActionResult<ClassListResponse>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var classes = await _repository.ListAsync(cancellationToken);
        var response = new ClassListResponse
        {
            Classes = classes
                .Select(c => _mapper.Map<ClassListItemDto>(c))
                .ToList()
        };

        return Ok(response);
    }
}
