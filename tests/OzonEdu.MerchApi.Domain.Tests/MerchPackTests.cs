using AutoFixture.Xunit2;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.ValueObjects;
using Xunit;

namespace OzonEdu.MerchApi.Domain.Tests
{
    public class MerchPackTests
    {
        [Fact]
        public void AddMerchItem()
        {
            //Arrange
            var merchPack = new MerchPack(new NamePack("TestPack"),
                new[] {new MerchItem(new NameItem("TestItem0"), new Sku(100))});

            //Act
            merchPack.AddMerchItem(new NameItem("TestItem1"), new Sku(140));

            //Assert
            Assert.Equal("TestItem1", merchPack.MerchItems[1].NameItem.Value);
        }
    }
}