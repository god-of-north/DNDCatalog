using DNDCatalog.UnitTests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DNDCatalog.UnitTests.Core.ClassAgreagate.Specifications;


public class ClassesByIdSpec
{
    public static IEnumerable<object[]> TestData
    {
        get 
        {
            yield return new object[] { 1, new Guid[] { FakeData.classPaladin.Id } };
            yield return new object[] { 2, new Guid[] { FakeData.classDruid.Id, FakeData.classCleric.Id } };
            yield return new object[] { 3, new Guid[] { FakeData.classBard.Id, FakeData.classArtificer.Id, FakeData.classRanger.Id } };
            yield return new object[] { 4, new Guid[] { FakeData.classWizard.Id, FakeData.classWarlock.Id, FakeData.classSorcerer.Id, FakeData.classRogue.Id } };
            yield return new object[] { 5, new Guid[] { FakeData.classPaladin.Id, FakeData.classRanger.Id, FakeData.classDruid.Id, FakeData.classArtificer.Id, FakeData.classMonk.Id } };
        }
    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void Query_WithExistingIds_ReturnsEpectedSetOfClasses(int expectedCount, Guid[] classesIds)
    {
        //Arrange
        var spec = new DNDCatalog.Core.ClassAggregate.Specifications.ClassesByIdsSpec(classesIds);

        //Act
        var result = spec.Evaluate(FakeData.GetClasses()).ToList();

        //Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(expectedCount, result.Count());
        Assert.Equal(expectedCount, result.Select(c=>c.Id).Intersect(classesIds).Count());

    }

    [Fact]
    public void Query_WithNotExistingIds_ReturnsSetEmptySet()
    {
        //Arrange
        Guid[] classesIds = Enumerable.Range(1, 5).Select(x=>Guid.NewGuid()).ToArray();
        var spec = new DNDCatalog.Core.ClassAggregate.Specifications.ClassesByIdsSpec(classesIds);

        //Act
        var result = spec.Evaluate(FakeData.GetClasses()).ToList();

        //Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }

    [Fact]
    public void Query_WithEmptyParam_ReturnsSetEmptySet()
    {
        //Arrange
        var classesIds = Enumerable.Empty<Guid>();
        var spec = new DNDCatalog.Core.ClassAggregate.Specifications.ClassesByIdsSpec(classesIds);

        //Act
        var result = spec.Evaluate(FakeData.GetClasses()).ToList();

        //Assert
        Assert.NotNull(result);
        Assert.Empty(result);
    }
}
