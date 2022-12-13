using DNDCatalog.Core.MagicItemAggregate;
using System.ComponentModel.DataAnnotations;


namespace DNDCatalog.Web.Endpoints.MagicItemEndpoints;


public class UpdateMagicItemRequest
{
    [Required]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Source { get; set; }
    public bool? Attunement { get; set; }
    public int? MagicBonus { get; set; }
    public MagicItemType? Type { get; set; }
    public bool? Consumable { get; set; } 
    public bool? Charged { get; set; } 
    public Rarity? Rarity { get; set; }
    public RecomendedPrice? Price { get; set; }

}
