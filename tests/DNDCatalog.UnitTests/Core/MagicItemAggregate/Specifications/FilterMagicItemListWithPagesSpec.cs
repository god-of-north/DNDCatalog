using DNDCatalog.Core.MagicItemAggregate;
using DNDCatalog.UnitTests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DNDCatalog.UnitTests.Core.MagicItemAggregate.Specifications;

public class FilterMagicItemListWithPagesSpec
{

    [Fact]
    public void QueryItems_WithPages_ReturnsExpectedItems()
    {
        //Arrange
        var data = FakeData.GetMagicItems();
        var specPage1 = new DNDCatalog.Core.MagicItemAggregate.Specifications.FilterMagicItemListWithPagesSpec(0, null, null, null, null, null, null, null, null, null);
        var specPage2 = new DNDCatalog.Core.MagicItemAggregate.Specifications.FilterMagicItemListWithPagesSpec(1, null, null, null, null, null, null, null, null, null);
        var specPage3 = new DNDCatalog.Core.MagicItemAggregate.Specifications.FilterMagicItemListWithPagesSpec(2, null, null, null, null, null, null, null, null, null);

        //Act
        var resultPage1 = specPage1.Evaluate(data).ToList();
        var resultPage2 = specPage2.Evaluate(data).ToList();
        var resultPage3 = specPage3.Evaluate(data).ToList();

        //Assert
        Assert.NotNull(resultPage1);
        Assert.NotNull(resultPage2);
        Assert.NotNull(resultPage3);
        Assert.NotEmpty(resultPage1);
        Assert.NotEmpty(resultPage2);
        Assert.Empty(resultPage3);
        Assert.Equal(MagicItemConstants.MagicItemsOnPage, resultPage1.Count());
        Assert.Equal(data.Count()-MagicItemConstants.MagicItemsOnPage, resultPage2.Count());
        Assert.Equal(
            MagicItemConstants.MagicItemsOnPage, 
            resultPage1
                .Select(c => c.Id)
                .Intersect(
                    data.Take(MagicItemConstants.MagicItemsOnPage)
                    .Select(x=>x.Id)
                ).Count());
        Assert.Equal(
            data.Count() - MagicItemConstants.MagicItemsOnPage, 
            resultPage2
                .Select(c => c.Id)
                .Intersect(
                    data.Skip(MagicItemConstants.MagicItemsOnPage)
                        .Take(MagicItemConstants.MagicItemsOnPage)
                        .Select(x=>x.Id)
                ).Count());
    }

}
