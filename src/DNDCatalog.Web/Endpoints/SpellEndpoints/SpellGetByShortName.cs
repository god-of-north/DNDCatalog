using Ardalis.ApiEndpoints;
using AutoMapper;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.Core.SpellAggregate.Specifications;
using DNDCatalog.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DNDCatalog.Web.Endpoints.SpellEndpoints;

public class SpellGetByShortName : EndpointBaseAsync.WithRequest<GetSpellByShortNameRequest>.WithActionResult<GetSpellByShortNameResponse>
{
    private readonly IRepository<Spell> _repository;
    private readonly IMapper _mapper;

    public SpellGetByShortName(IRepository<Spell> repository, IMapper mapper)
    {
        _repository = repository;   
        _mapper = mapper;
    }

    [HttpGet("/api/v1/Spells/{ShortName}")]
    [SwaggerOperation(
      Summary = "Gets a single Spell",
      Description = "Gets a single Spell by ShortName",
      OperationId = "Spell.SpellGetByShortName",
      Tags = new[] { "SpellEndpoints" })
    ]
    public override async Task<ActionResult<GetSpellByShortNameResponse>> HandleAsync([FromRoute] GetSpellByShortNameRequest request, CancellationToken cancellationToken = default)
    {
        var spec = new SpellDetailsByShortNameSpec(request.ShortName);
        var spell = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        if (spell == null)
        {
            return NotFound();
        }

        var response = _mapper.Map<GetSpellByShortNameResponse>(spell);

        return Ok(response);
    }
}
