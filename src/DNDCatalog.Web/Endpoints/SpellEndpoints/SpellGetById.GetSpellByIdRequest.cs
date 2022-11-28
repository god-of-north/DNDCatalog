namespace DNDCatalog.Web.Endpoints.SpellEndpoints;

public class GetSpellByIdRequest
{
    public const string Route = "/api/v1/Spells/{SpellId:guid}";

    public Guid SpellId { get; set; }
}
