using Amsel.Rundown.Domain.Models.LogicEntities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amsel.Models.Rundown.Models
{
    public class DonationData : DataEntity
    {
        protected DonationData() { }

        public DonationData(string user, double amount) {
            Key = $"{nameof(DonationData)}.{user}";
            Amount = amount;
            User = user ?? throw new ArgumentNullException(nameof(user));
        }

        public virtual double Amount { get; set; }

        public virtual string User { get; set; }

        public override object GetData() => new { Amount, User };
    }
}