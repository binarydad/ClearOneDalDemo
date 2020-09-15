using BinaryDad.AggregateDal.Models;
using System.Linq;

namespace BinaryDad.AggregateDal
{
    public class SettlementAttemptDataAccess : AggregateDataAccess<ISettlementAttemptDataAccess>, ISettlementAttemptDataAccess
    {
        public bool AddAttempt(SettlementAttempt attempt) => Invoke(d => d.AddAttempt(attempt));
        public SettlementAttempt GetAttempt(int recordId) => Invoke(d => d.GetAttempt(recordId));
    }
}
