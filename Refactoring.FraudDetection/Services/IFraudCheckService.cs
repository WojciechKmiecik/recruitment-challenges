using System.Collections.Generic;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Entities;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Services
{
    public interface IFraudCheckService
    {
        List<FraudResult> CheckOrders(List<Order> orders);
    }
}