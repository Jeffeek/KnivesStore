using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnivesStore.DAL.Models
{
    public enum CheckStatus : byte { Paid, InBasket, Cancelled }

    public class Check : IEquatable<Check>
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("Sum")]
        public int Sum { get; set; }
        [Column("Status")]
        public CheckStatus Status { get; set; }

        public User User { get; set; }
        public ICollection<Sell> Sells { get; set; }

        public bool Equals(Check other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && Date.Equals(other.Date) && UserId == other.UserId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Check) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ Date.GetHashCode();
                hashCode = (hashCode * 397) ^ UserId;
                return hashCode;
            }
        }
    }
}