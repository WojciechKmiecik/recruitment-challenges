using System.Collections.Generic;
using Payvision.CodeChallenge.Refactoring.FraudDetection.Entities;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Services
{
    public interface INormalizeService
    {
        string NormalizeEmail(string basicEmail);
        List<Order> NormalizeOrders(List<Order> orders);
        string NormalizeState(string basicState);
        string NormalizeStreet(string basicStreet);
    }
}