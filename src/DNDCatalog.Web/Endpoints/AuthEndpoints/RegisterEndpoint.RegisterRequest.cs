using DNDCatalog.Infrastructure.Identity;

namespace DNDCatalog.Web.Endpoints.AuthEndpoints;

public class RegisterRequest : BaseRequest
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;

}
