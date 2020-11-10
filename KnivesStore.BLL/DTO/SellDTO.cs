namespace KnivesStore.BLL.DTO
{
    public class SellDTO
    {
        public int Id { get; set; }
        public int KnifeId { get; set; }
        public KnifeDTO Knife { get; set; }
        public int CheckId { get; set; }
        public CheckDTO Check { get; set; }
        public int Quantity { get; set; }
    }
}
