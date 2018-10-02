using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Entities
{
    public class FraudResult
    {
        public int OrderId { get; set; }

        public bool IsFraudulent { get; set; }
    }
}
