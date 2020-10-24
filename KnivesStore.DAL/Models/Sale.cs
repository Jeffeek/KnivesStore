using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnivesStore.DAL.Models
{
    public class Sale : IEquatable<Sale>
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("KnifeId")]
        public int KnifeId { get; set; }
        [Column("Date")]
        public DateTime Date { get; set; }
        public Knife Knife { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(KnifeId)}: {KnifeId}, {nameof(Date)}: {Date.ToLongDateString()}";
        }
        public bool Equals(Sale other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return KnifeId == other.KnifeId && Date.Equals(other.Date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Sale)) return false;
            return Equals((Sale) obj);
        }
    }
}