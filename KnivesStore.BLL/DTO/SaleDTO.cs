using System;

namespace KnivesStore.BLL.DTO
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public int KnifeId { get; set; }
        public KnifeDTO Knife { get; set; }
        public DateTime Date { get; set; }
        public int Sum { get; set; }
    }
}
