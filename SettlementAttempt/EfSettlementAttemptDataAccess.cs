using BinaryDad.AggregateDal.Models;
using System;

namespace BinaryDad.AggregateDal
{
    public class EfSettlementAttemptDataAccess : ISettlementAttemptDataAccess
    {
        public bool AddAttempt(SettlementAttempt attempt)
        {
            // create attempt in SQL

            attempt.Id = 12376;

            Console.WriteLine($"Adding attempt ID {attempt.Id} to SQL");

            return true;
        }

        public SettlementAttempt GetAttempt(int recordId)
        {
            // get the attempt from SQL

            Console.WriteLine($"Getting attempt {recordId} from SQL");

            return new SettlementAttempt
            {
                Id = recordId
            };
        }
    }
}
