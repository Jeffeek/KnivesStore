using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnivesStore.DAL.Models
{
    public class KnifeCategory : IEquatable<KnifeCategory>
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Category")]
        public string Category { get; set; }

        public ICollection<Knife> Knives { get; set; }

        public bool Equals(KnifeCategory other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Category, other.Category);
        }
    }
}