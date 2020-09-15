using BinaryDad.AggregateDal.Models;
using System;

namespace BinaryDad.AggregateDal
{
    public class QuickBaseSettlementAttemptDataAccess : ISettlementAttemptDataAccess
    {
        public bool AddAttempt(SettlementAttempt attempt)
        {
            attempt.RecordId = 9999;

            // create attempt in Quickbase

            Console.WriteLine($"Adding attempt ID {attempt.RecordId} to Quickbase with SQL ID {attempt.Id}");

            return true;
        }

        public SettlementAttempt GetAttempt(int recordId)
        {
            // get the attempt from Quickbase

            Console.WriteLine($"Getting attempt {recordId} from Quickbase");

            return new SettlementAttempt
            {
                Id = recordId
            };
        }
    }
}
