using Ardalis.ApiEndpoints;
using AutoMapper;
using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.ClassAggregate.Specifications;
using DNDCatalog.Core.Interfaces;
using DNDCatalog.Core.SpellAggregate;
using DNDCatalog.Core.SpellAggregate.Specifications;
using DNDCatalog.Infrastructure.Identity;
using DNDCatalog.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DNDCatalog.Web.Endpoints.SpellEndpoints;

public class SpellUpdate : EndpointBaseAsync.WithRequest<UpdateSpellRequest>.WithActionResult<UpdateSpellResponse>
{
    private readonly IRepository<Spell> _repository;
    private readonly IMapper _mapper;

    public SpellUpdate(IRepository<Spell> repository, IMapper mapper)
    {
        _repository = repository;   
        _mapper = mapper;
    }

    [HttpPut("api/v1/spells")]
    [SwaggerOperation(
        Summary = "Updates a Spell",
        Description = "Updates a Spell details",
        OperationId = "Spell.Update",
        Tags = new[] { "SpellEndpoints" })
    ]
    [Authorize(Roles = nameof(Roles.EDITORS), AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public override async Task<ActionResult<UpdateSpellResponse>> HandleAsync(UpdateSpellRequest request, CancellationToken cancellationToken = default)
    {
        var existingSpell = await _repository.SingleOrDefaultAsync(new SpellDetailsByIdSpec(request.Id), cancellationToken);
        if (existingSpell is null)
        {
            return NotFound();
        }

        _mapper.Map(request, existingSpell);
        await _repository.UpdateAsync(existingSpell, cancellationToken);
        var response = _mapper.Map<UpdateSpellResponse>(existingSpell);

        return Ok(response);
    }
}
