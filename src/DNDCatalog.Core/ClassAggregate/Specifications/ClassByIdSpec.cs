﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace DNDCatalog.Core.ClassAggregate.Specifications;
public class ClassesByIdsSpec : Specification<Class>
{
    public ClassesByIdsSpec(IEnumerable<Guid> ids)
    {
        Query
            .Where(c => ids.Contains(c.Id));
    }
}
