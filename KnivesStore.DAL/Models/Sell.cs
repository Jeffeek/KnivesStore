using System;
using System.ComponentModel.DataAnnotations;

namespace KnivesStore.DAL.Models
{
    public class Sell : IEquatable<Sell>
    {
        [Key]
        public int Id { get; set; }
        public int KnifeId { get; set; }
        public Knife Knife { get; set; }
        public int CheckId { get; set; }
        public Check Check { get; set; }

        public bool Equals(Sell other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Id == other.Id && KnifeId == other.KnifeId && CheckId == other.CheckId;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Sell) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Id;
                hashCode = (hashCode * 397) ^ KnifeId;
                hashCode = (hashCode * 397) ^ CheckId;
                return hashCode;
            }
        }
    }
}
