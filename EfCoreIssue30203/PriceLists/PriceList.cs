using EfCoreIssue30203.Domain.Abstractions;
using EfCoreIssue30203.Domain.PriceLists.ValueObjects;
using EfCoreIssue30203.Domain.Products.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreIssue30203.Domain.PriceLists;

public sealed class PriceList : AggregateRoot<PriceListId>
{
#pragma warning disable CS8618
    private PriceList()
    {
    }
#pragma warning restore CS8618

    public PriceListIdentifier Identifier { get; private set; }

    public ProductId ProductId { get; private set; }
}
