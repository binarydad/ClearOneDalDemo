using BinaryDad.AggregateDal.Models;
using System;

namespace BinaryDad.AggregateDal
{
    public class QuickBaseSettlementAttemptDataAccess : ISettlementAttemptDataAccess
    {
        public bool AddAttempt(SettlementAttempt attempt)
        {
            // 1. create attempt in QuickBase ("Id" SQL PK should already be populated)
            // 2. update the "RecordId" property/PK of attempt upon insertion
            // 3. return if operation is successful

            // auto-generated value from QB record insert
            attempt.RecordId = 9999;

            Console.WriteLine($"Adding attempt ID {attempt.RecordId} to Quickbase with SQL ID {attempt.Id}");

            return true;
        }

        // NOTE: we have no need to retrieve a record from QB, as it will come from SQL
        public SettlementAttempt GetAttempt(int recordId) => null;
    }
}
