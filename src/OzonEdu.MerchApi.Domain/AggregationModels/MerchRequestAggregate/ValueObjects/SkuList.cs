using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.ValueObjects
{
    public class SkuList : ValueObject, IEnumerable<Sku>
    {
        public SkuList(IEnumerable<Sku> items) => Items = new List<Sku>(items);

        private List<Sku> Items { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Items;
        }

        public IEnumerator<Sku> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public SkuList AddSku(long sku)
        {
            var items = Items.ToList();
            items.Add(new Sku(sku));
            return new SkuList(items);
        }
    }
}