
using Amsel.Model.Tenant.TenantModels;
using System;

namespace Amsel.Endpoint.Rundown.Models
{
    public class DonationData : DataEntity
    {
        public virtual double Amount { get; set; }

        public virtual string User { get; set; }

        #region PUBLIC METHODES
    
        public override object GetData() => new { Amount, User };
        #endregion

        #region  CONSTRUCTORS

        public DonationData(string user, double amount)
        {
            Name = $"{Id}:{user}";
            Amount = amount;
            User = user ?? throw new ArgumentNullException(nameof(user));
        }

        protected DonationData()
        {
        }
        #endregion
    }
}