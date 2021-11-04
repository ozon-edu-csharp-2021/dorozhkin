using System;
using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.ValueObjects;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.ValueObjects;
using OzonEdu.MerchApi.Domain.Contracts;
using OzonEdu.MerchApi.Domain.Events.MerchRequestAggregate;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities
{
    public class MerchRequest : Entity, IAggregateRoot
    {
        public MerchRequest(NamePack namePack, long merchPackId, long employeeId, IReadOnlyCollection<long> skuList)
        {
            NamePack = namePack;
            MerchPackId = merchPackId;
            EmployeeId = employeeId;
            SkuList = skuList;
            SetMerchRequestDraftStatus();
        }

        public MerchRequestStatus Status { get; private set; }
        public IReadOnlyCollection<long> SkuList { get; }
        public NamePack NamePack { get; }
        public long MerchPackId { get; }
        public long EmployeeId { get; }
        public long? SupplyCodeStatus { get; private set; }
        public long? ReserveCodeStatus { get; private set; }
        public long? DeliveryCode { get; private set; }

        private void SetMerchRequestDraftStatus()
        {
            Status = MerchRequestStatus.Created;
        }

        public void SetInProcessStatus(long reserveCodeStatus) //todo not invariant
        {
            if (reserveCodeStatus < 0)
                throw new Exception("The code cannot be less than zero");

            Status = MerchRequestStatus.InProcess;
            ReserveCodeStatus = reserveCodeStatus;
            
            SaveMerchRequest();
        }

        public void SetWaitingSupplyStatus(long supplyCodeStatus)
        {
            if (supplyCodeStatus < 0)
                throw new Exception("The code cannot be less than zero");
            
            Status = MerchRequestStatus.WaitingSupply;
            SupplyCodeStatus = supplyCodeStatus;
            
            SaveMerchRequest();
        }
        
        public void SetClosedStatus(long deliveryCode)
        {
            if (deliveryCode < 0)
                throw new Exception("The code cannot be less than zero");
            
            Status = MerchRequestStatus.Closed;
            DeliveryCode = deliveryCode;
            
            SaveMerchRequest();
        }

        private void SaveMerchRequest()
        {
            var saveMerchRequestEvent = new SaveMerchRequestEvent(this);
            AddDomainEvent(saveMerchRequestEvent);
        }
    }
}