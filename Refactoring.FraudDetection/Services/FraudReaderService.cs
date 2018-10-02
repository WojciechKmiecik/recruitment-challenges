using Payvision.CodeChallenge.Refactoring.FraudDetection.Entities;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Services
{
    public class FraudReaderService : IFraudReaderService
    {
        private readonly CsvParserOptions CsvParserOptions = new CsvParserOptions(false, ',');
        private readonly CsvOrdersMapping csvOrdersMapping = new CsvOrdersMapping();
        private readonly CsvParser<Order> csvOrdersParser;
        public FraudReaderService()
        {
            csvOrdersParser = new TinyCsvParser.CsvParser<Order>(CsvParserOptions, csvOrdersMapping);
        }
        public List<Order> ReadOrders(string filePath)
        {
            var ParseResult = csvOrdersParser.ReadFromFile(filePath, Encoding.ASCII).ToList();
            var result = new List<Order>();
            foreach (var item in ParseResult)
            {
                if (item.IsValid)
                {
                    result.Add(item.Result);
                }
            }
            return result;
        }


    }
}
