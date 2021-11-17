using System;
using System.Linq;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities;

namespace OzonEdu.MerchApi.Domain.DomainServices
{
    public sealed class MerchRequestDomainService
    {
        public static MerchRequest CreateMerchRequest(Employee employee, MerchPack merchPack)
        {
            if (employee is null || merchPack is null)
                throw new ArgumentNullException();
            
            var skuList = merchPack.MerchItems.Select(merchItem => merchItem.Sku.Value).ToList();
            var merchRequest = new MerchRequest(merchPack.NamePack, merchPack.Id, employee.Id, skuList);
            
            return merchRequest;
        }
    }
}