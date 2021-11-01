using System;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchItemAggregate;
using Xunit;

namespace OzonEdu.MerchApi.Domain.Tests
{
    public class QuantityValueObjectTests
    {
        [Fact]
        public void CreateQuantityInstanseSucces()
        {
            //Arrange
            var quantity = 228;
            var minQuantity = 5;

            //Act
            var result = new MerchType(1, "WelcomePack", new Sku(228));
            
            //Assert
            Assert.Equal(quantity, result.Sku.Value);
        }
    }
}