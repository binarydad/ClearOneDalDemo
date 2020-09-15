using BinaryDad.AggregateDal.Models;
using StructureMap;
using System;

namespace BinaryDad.AggregateDal
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // build container
            var container = CreateContainer();

            // get instance via structuremap, as is typical
            var settlementAttemptDataAccess = container.GetInstance<ISettlementAttemptDataAccess>();

            #region Add attempt

            var newAttempt = new SettlementAttempt
            {
                ClientFirstName = "Ryan",
                ClientLastName = "Peters",
                CreatedBy = "rpeters"
            };

            settlementAttemptDataAccess.AddAttempt(newAttempt);

            // in most cases, the QuickBase DAL will update "RecordId" and 
            // the EF DAL will update "Id"
            Console.WriteLine($"Attempt ID (SQL) => {newAttempt.Id}");
            Console.WriteLine($"Attempt ID (QuickBase) => {newAttempt.RecordId}");

            #endregion

            #region Get attempt

            var attempt = settlementAttemptDataAccess.GetAttempt(1234);

            // dump the attempt
            Console.WriteLine($"{nameof(attempt.Id)} => {attempt.Id}");
            Console.WriteLine($"{nameof(attempt.RecordId)} => {attempt.RecordId}");
            Console.WriteLine($"{nameof(attempt.ClientFirstName)} => {attempt.ClientFirstName}");
            Console.WriteLine($"{nameof(attempt.ClientLastName)} => {attempt.ClientLastName}");
            Console.WriteLine($"{nameof(attempt.Created)} => {attempt.Created}");
            Console.WriteLine($"{nameof(attempt.CreatedBy)} => {attempt.CreatedBy}");

            #endregion

            // pause
            Console.ReadLine();
        }

        private static IContainer CreateContainer()
        {
            return new Container(c =>
            {
                // when saving to QuickBase is needed (as well as SQL)
                c.For<ISettlementAttemptDataAccess>().Singleton().Use<QuickBaseSettlementAttemptDataAccess>();

                // when only SQL is needed
                //c.For<ISettlementAttemptDataAccess>().Singleton().Use<EfSettlementAttemptDataAccess>();
            });
        }
    }
}