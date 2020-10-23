namespace KnivesStore.BLL.DTO
{
    public class KnifeDTO
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public KnifeCategoryDto Category { get; set; }
        public int ProducerId { get; set; }
        public ProducerDTO Producer { get; set; }
    }
}
