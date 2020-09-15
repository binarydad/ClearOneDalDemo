using BinaryDad.AggregateDal.Models;

namespace BinaryDad.AggregateDal
{
    public interface ISettlementAttemptDataAccess
    {
        /// <summary>
        /// Adds a new settlement attempt
        /// </summary>
        /// <param name="attempt"></param>
        /// <returns>Whether the add operation was successful</returns>
        bool AddAttempt(SettlementAttempt attempt);

        /// <summary>
        /// Retrieves an existing settlement attempt
        /// </summary>
        /// <param name="recordId"></param>
        /// <returns></returns>
        SettlementAttempt GetAttempt(int recordId);
    }
}
