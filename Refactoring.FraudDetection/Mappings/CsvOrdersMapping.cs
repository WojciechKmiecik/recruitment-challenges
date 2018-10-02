using Payvision.CodeChallenge.Refactoring.FraudDetection.Entities;
using TinyCsvParser.Mapping;
using TinyCsvParser.TypeConverter;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Mappings
{
    internal class CsvOrdersMapping : CsvMapping<Order>
    {
        public CsvOrdersMapping() : base()
        {
            MapProperty(0, x => x.OrderId, new Int32Converter());
            MapProperty(1, x => x.DealId, new Int32Converter());
            MapProperty(2, x => x.Email);
            MapProperty(3, x => x.Street);
            MapProperty(4, x => x.City);
            MapProperty(5, x => x.State);
            MapProperty(6, x => x.ZipCode);
            MapProperty(7, x => x.CreditCard);
        }
    }
}
