using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KnivesStore.DAL.Models
{
    public class KnifeCategory
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }
        [Column("Category")]
        public string Category { get; set; }
        public IEnumerable<Knife> Knives { get; set; }
    }
}