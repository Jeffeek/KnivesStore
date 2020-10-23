using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnivesStore.DAL.Models
{
    public class Producer : IEquatable<Producer>
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Country")]
        public string Country { get; set; }
        [Column("Name")]
        public string Name { get; set; }

        public bool Equals(Producer other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Country, other.Country) && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Producer)) return false;
            return Equals((Producer) obj);
        }
    }
}