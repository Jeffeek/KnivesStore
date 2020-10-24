using System;

namespace KnivesStore.PL.ViewModel
{
    public class SaleViewModel
    {
        public int Id { get; set; }
        public int KnifeId { get; set; }
        public KnifeViewModel Knife { get; set; }
        public DateTime Date { get; set; }
        public int Sum { get; set; }
        public int MaxKnifeId { get; set; }
    }
}
