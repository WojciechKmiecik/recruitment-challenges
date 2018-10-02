// -----------------------------------------------------------------------
// <copyright file="FraudRadar.cs" company="Payvision">
//     Payvision Copyright © 2017
// </copyright>
// -----------------------------------------------------------------------

namespace Payvision.CodeChallenge.Refactoring.FraudDetection
{
    using Payvision.CodeChallenge.Refactoring.FraudDetection.Entities;
    using Payvision.CodeChallenge.Refactoring.FraudDetection.Services;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class FraudRadar
    {
        private readonly IFraudReaderService fraudReader;
        private readonly INormalizeService normalizeService;
        private readonly IFraudCheckService fraudCheckService;
        public FraudRadar(/*IFraudReaderService fraudReader, INormalizeService normalizeService, IFraudCheckService fraudCheckService*/)
        {
            //this.fraudReader = fraudReader; // i dont have di container, so i  will create dependences manually
            fraudReader = new FraudReaderService();
            normalizeService = new NormalizeService();
            fraudCheckService = new FraudCheckService();
        }
        public IEnumerable<Entities.FraudResult> Check(string filePath)
        {
            var orders = new List<Order>();
            

            //// READ FRAUD LINES and parse
            orders = fraudReader.ReadOrders(filePath);


            // NORMALIZE
            orders = normalizeService.NormalizeOrders(orders);

            // CHECK FRAUD
            return fraudCheckService.CheckOrders(orders);
        }

        
    }
}