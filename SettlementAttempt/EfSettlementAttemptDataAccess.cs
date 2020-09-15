using BinaryDad.AggregateDal.Models;
using System;

namespace BinaryDad.AggregateDal
{
    public class EFSettlementAttemptDataAccess : ISettlementAttemptDataAccess
    {
        public bool AddAttempt(SettlementAttempt attempt)
        {
            // 1. create attempt in SQL using entity framework
            // 2. update the "Id" property/PK of attempt upon insertion
            // 3. return if operation is successful

            // auto-generated value from PK insert
            attempt.Id = 12376;

            Console.WriteLine($"Adding attempt ID {attempt.Id} to SQL");

            return true;
        }

        public SettlementAttempt GetAttempt(int recordId)
        {
            Console.WriteLine($"Getting attempt {recordId} from SQL");

            // get the attempt from SQL/EF
            return new SettlementAttempt
            {
                Id = recordId,
                RecordId = 9999, // will already be in SQL via webhook
                ClientFirstName = "Ryan",
                ClientLastName = "Peters",
                Created = DateTime.Parse("9/1/2020"),
                CreatedBy = "rpeters"
            };
        }
    }
}
