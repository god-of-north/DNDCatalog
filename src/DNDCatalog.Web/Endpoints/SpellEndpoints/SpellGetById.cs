using Ardalis.ApiEndpoints;
using AutoMapper;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.Core.SpellAggregate.Specifications;
using DNDCatalog.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DNDCatalog.Web.Endpoints.SpellEndpoints;

public class SpellGetById : EndpointBaseAsync.WithRequest<GetSpellByIdRequest>.WithActionResult<GetSpellByIdResponse>
{
    private readonly IRepository<Spell> _repository;
    private readonly IMapper _mapper;

    public SpellGetById(IRepository<Spell> repository, IMapper mapper)
    {
        _repository = repository;   
        _mapper = mapper;
    }

    [HttpGet("/api/v1/Spells/{SpellId:guid}")]
    [SwaggerOperation(
      Summary = "Gets a single Spell",
      Description = "Gets a single Spell by Id",
      OperationId = "Spell.GetById",
      Tags = new[] { "SpellEndpoints" })
    ]
    public override async Task<ActionResult<GetSpellByIdResponse>> HandleAsync([FromRoute] GetSpellByIdRequest request, CancellationToken cancellationToken = default)
    {
        var spec = new SpellDetailsByIdSpec(request.SpellId);
        var spell = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        if (spell == null)
        {
            return NotFound();
        }

        var response = _mapper.Map<GetSpellByIdResponse>(spell);

        return Ok(response);
    }
}
