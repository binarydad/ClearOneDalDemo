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
            /* NOTES:
             * The StructureMap container will drive the instances of the DALs that will be invoked. 
             * DALs that inherit from AggregateDataAccess<T> will automatically aggregate types implementing T
             * and will invoke them. This means we can have implementations of QuickBaseXxxDataAccess and 
             * EfXxxDataAccess that focus solely on their own operations. Once we decide to turn off a feature
             * (i.e., we no longer need to save to QB for a particular DAL), we can change the .Use<T>()
             * to use a regular EfXxxDataAccess instance. 
             * 
             * NO OTHER PARTS OF THE CODEBASE WOULD NEED TO BE TOUCHED, as we're only changing the instance
             * of a DAL from an aggregate to a singular instance */

            return new Container(c =>
            {
                // when both DALs are needed (SQL and QuickBase)
                c.For<ISettlementAttemptDataAccess>().Singleton().Use<SettlementAttemptDataAccess>();

                // when only SQL is needed
                //c.For<ISettlementAttemptDataAccess>().Singleton().Use<EfSettlementAttemptDataAccess>();
            });
        }
    }
}