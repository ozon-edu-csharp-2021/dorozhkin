using System;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.ValueObjects;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.ValueObjects;
using Xunit;

namespace OzonEdu.MerchApi.Domain.Tests
{
    public class MerchRequestTests
    {
        [Fact]
        public void ChangeOnInProcessStatus()
        {
            //Arrange 
            var skuList = new long[] {111, 222, 333};
            var merchRequest = new MerchRequest(2, 4565);
        
            //Act
            merchRequest.SetInProcessStatus(3232);
        
            //Assert
            Assert.Equal(MerchRequestStatus.InProcess, merchRequest.Status);
        }
        
        [Fact]
        public void ChangeOnInProcessStatusWithNegativeCode()
        {
            //Arrange 
            var skuList = new long[] {111, 222, 333};
            var merchRequest = new MerchRequest(1, 4565);
        
            //Act && Assert
            Assert.Throws<Exception>(() => merchRequest.SetInProcessStatus(-3232));
        }
        
        [Fact]
        public void ChangeOnWaitingSupplyStatus()
        {
            //Arrange 
            var skuList = new long[] {111, 222, 333};
            var merchRequest = new MerchRequest(3, 4565);
        
            //Act
            merchRequest.SetWaitingSupplyStatus(3232);
        
            //Assert
            Assert.Equal(MerchRequestStatus.WaitingSupply, merchRequest.Status);
        }
        
        [Fact]
        public void ChangeOnWaitingSupplyStatusWithNegativeCode()
        {
            //Arrange 
            var skuList = new long[] {111, 222, 333};
            var merchRequest = new MerchRequest(1, 4565);
        
            //Act && Assert
            Assert.Throws<Exception>(() => merchRequest.SetWaitingSupplyStatus(-3232));
        }
        
        [Fact]
        public void ChangeOnClosedStatus()
        {
            //Arrange 
            var skuList = new long[] {111, 222, 333};
            var merchRequest = new MerchRequest(2, 4565);
        
            //Act
            merchRequest.SetClosedStatus(2324);
        
            //Assert
            Assert.Equal(MerchRequestStatus.Closed, merchRequest.Status);
        }
        
        [Fact]
        public void ChangeOnClosedStatusWithNegativeCode()
        {
            //Arrange 
            var skuList = new long[] {111, 222, 333};
            var merchRequest = new MerchRequest(1, 4565);
        
            //Act && Assert
            Assert.Throws<Exception>(() => merchRequest.SetClosedStatus(-3232));
        }
    }
}