using System.Collections.Generic;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Entities;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Services
{
    public interface IFraudReaderService
    {
        List<Order> ReadOrders(string filePath);
    }
}