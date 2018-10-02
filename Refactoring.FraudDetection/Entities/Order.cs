using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Entities
{
    public class Order
    {
        private string email;
        private string street;
        private string city;
        private string state;

        public int OrderId { get; set; }
        public int DealId { get; set; }
        public string Email { get { return email; } set { email = value?.ToLower(); } }
        public string Street { get { return street; } set { street = value?.ToLower(); } }
        public string City { get { return city; } set { city = value?.ToLower(); } }
        public string State { get { return state; } set { state = value?.ToLower(); } }
        public string ZipCode { get; set; }
        public string CreditCard { get; set; }
    }
}
