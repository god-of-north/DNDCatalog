using System;

namespace DNDCatalog.Web.Endpoints.AuthEndpoints;

public class RegisterResponse : BaseResponse
{
    public RegisterResponse(Guid correlationId) : base(correlationId)
    {
    }

    public RegisterResponse()
    {
    }
    public bool Result { get; set; } = false;
}
