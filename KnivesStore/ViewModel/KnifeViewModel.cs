namespace KnivesStore.PL.ViewModel
{
    public class KnifeViewModel
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public KnifeCategoryViewModel Category { get; set; }
        public int ProducerId { get; set; }
        public ProducerViewModel Producer { get; set; }
    }
}
