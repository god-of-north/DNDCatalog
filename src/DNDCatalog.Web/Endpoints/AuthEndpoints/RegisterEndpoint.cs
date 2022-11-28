using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using DNDCatalog.Core.Interfaces;
using DNDCatalog.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DNDCatalog.Web.Endpoints.AuthEndpoints;

/// <summary>
/// Registrates a user
/// </summary>
public class RegisterEndpoint : EndpointBaseAsync.WithRequest<RegisterRequest>.WithActionResult<RegisterResponse>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterEndpoint(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("api/v1/register")]
    [SwaggerOperation(
        Summary = "Regisrates a user",
        Description = "Regisrates a user",
        OperationId = "auth.registrate",
        Tags = new[] { "AuthEndpoints" })
    ]
    public override async Task<ActionResult<RegisterResponse>> HandleAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var response = new RegisterResponse(request.CorrelationId());

        var user = new ApplicationUser { UserName = request.Username };
        var result = await _userManager.CreateAsync(user, request.Password);
        user = await _userManager.FindByNameAsync(request.Username);
        await _userManager.AddToRoleAsync(user, Roles.USERS.ToString());

        response.Result = result.Succeeded;

        return response;
    }
}
