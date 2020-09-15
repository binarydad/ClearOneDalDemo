using System;

namespace BinaryDad.AggregateDal.Models
{
    public class BaseModel
    {
        /// <summary>
        /// The SQL key ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Quickbase Record ID
        /// </summary>
        public int RecordId { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;
        public string CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
    }

    public class SettlementAttempt : BaseModel
    {
        public string ClientFirstName { get; set; }
        public string ClientLastName { get; set; }
    }
}