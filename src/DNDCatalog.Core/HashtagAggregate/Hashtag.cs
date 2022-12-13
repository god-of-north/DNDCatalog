using DNDCatalog.Core.MagicItemAggregate;
using DNDCatalog.SharedKernel;
using DNDCatalog.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDCatalog.Core.HashtagAggregate;

public class Hashtag : EntityBase, IAggregateRoot
{
    public string Name { get; set; } = null!;

    public List<MagicItem> MagicItems { get; set; } = null!;
}
