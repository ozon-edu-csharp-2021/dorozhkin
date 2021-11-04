using System;
using System.Diagnostics.CodeAnalysis;
using AutoFixture.Xunit2;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.ValueObject;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.ValueObjects;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.ValueObjects;
using OzonEdu.MerchApi.Domain.DomainServices;
using Xunit;
using Sku = OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.ValueObjects.Sku;

namespace OzonEdu.MerchApi.Domain.Tests
{
    public class MerchRequestDomainServiceTests
    {
        [Fact]
        public void CreateMerchRequest()
        {
            //Arrange
            var employee = new Employee(new Name("Vasya"), new EmailAddress("vasya@gmail.com"), new Phone("89999"));
            
            var thirt = new MerchItem(new NameItem("T-Shirt"), new Sku(111));
            var merchPack = new MerchPack(new NamePack("WelcomePack"), new[] {thirt});
            
            //Act
            var merchRequest = MerchRequestDomainService.CreateMerchRequest(employee, merchPack);

            //Assert
            Assert.Equal(MerchRequestStatus.Created, merchRequest.Status);
        }

        [AutoData]
        [Theory]
        public void CreateMerchRequestWithNullEmployee(MerchPack merchPack)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => MerchRequestDomainService.CreateMerchRequest(null, merchPack));
        }

        [AutoData]
        [Theory]
        public void CreateMerchRequestWithNullMerchPack(Employee employee)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => MerchRequestDomainService.CreateMerchRequest(employee, null));
        }
    }
}