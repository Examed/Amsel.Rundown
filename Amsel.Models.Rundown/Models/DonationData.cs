using Amsel.Model.Tenant.TenantModels;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amsel.Models.Rundown.Models
{
    [ComplexType]
    public class DonationData : DataEntity
    {
        public virtual double Amount { get; set; }

        public virtual string User { get; set; }

        protected DonationData() { }

        public DonationData(string user, double amount)
        {
            Name = $"{Id}:{user}";
            Amount = amount;
            User = user ?? throw new ArgumentNullException(nameof(user));
        }

        #region PUBLIC METHODES
        public override object GetData() => new { Amount, User };
        #endregion
    }
}