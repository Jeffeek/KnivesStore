using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnivesStore.DAL.Models
{
    public class Knife : IEquatable<Knife>
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("ProducerId")]
        public int ProducerId { get; set; }
        [Column("Price")]
        public int Price { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("CategoryId")]
        public int CategoryId { get; set; }
        public KnifeCategory Category { get; set; }
        public Producer Producer { get; set; }

        public override string ToString()
        {
            return $"{nameof(Producer)}: {Producer.Name}, {nameof(Price)}: {Price}, {nameof(Name)}: {Name}, {nameof(Category)}: {Category.Category}";
        }

        public bool Equals(Knife other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ProducerId == other.ProducerId && Price == other.Price && string.Equals(Name, other.Name) && Category.Category == other.Category.Category;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Knife)) return false;
            return Equals((Knife) obj);
        }
    }
}