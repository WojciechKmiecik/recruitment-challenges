using Payvision.CodeChallenge.Refactoring.FraudDetection.Entities;
using System;
using System.Collections.Generic;


namespace Payvision.CodeChallenge.Refactoring.FraudDetection.Services
{
    public class NormalizeService : INormalizeService
    {

        public List<Order> NormalizeOrders(List<Order> orders)
        {
            foreach (var order in orders)
            {
                order.Email = NormalizeEmail(order.Email);
                order.State = NormalizeState(order.State);
                order.Street = NormalizeStreet(order.Street);
            }
            return orders;
        }
        public string NormalizeEmail(string basicEmail)
        {
            //Normalize email
            var aux = basicEmail.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
            if (aux.Length != 2)
            {
                throw new ArgumentException($"Email {basicEmail} is not valid."); // could be sspecial exception here
            }
            var atIndex = aux[0].IndexOf("+", StringComparison.InvariantCultureIgnoreCase); //faster
            aux[0] = aux[0].Replace(".", "");
            if (atIndex > -1 )
            {
                aux[0] = aux[0].Remove(atIndex);
            }
            return string.Join("@", new string[] { aux[0], aux[1] });
        }
        public string NormalizeState(string basicState)
        {
            //Normalize state
            switch (basicState)
            {
                case "il":
                    return "illinois";
                    break;
                case "ca":
                    return "california";
                    break;
                case "ny":
                    return "new york";
                    break;
                default:
                    return basicState;
                    break;
            }
        }
        public string NormalizeStreet(string basicStreet)
        {
            //Normalize street
            switch (basicStreet)
            {
                case "st.":
                    return "street";
                    break;
                case "rd.":
                    return "road";
                    break;
                default:
                    return basicStreet;
                    break;
            }
        }
    }
}
