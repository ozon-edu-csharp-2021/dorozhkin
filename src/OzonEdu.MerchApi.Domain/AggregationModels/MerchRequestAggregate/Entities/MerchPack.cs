using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchItemAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.ValueObjects;
using OzonEdu.MerchApi.Domain.Events;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities
{
    public class MerchPack : Entity
    {
        public MerchPack(NamePack namePack, List<MerchItem> merchItems)
        {
            NamePack = namePack;
            MerchItems = merchItems;
        }

        public NamePack NamePack { get; }
        // public MerchItems MerchItems { get; }
        public List<MerchItem> MerchItems { get; }
    }
}