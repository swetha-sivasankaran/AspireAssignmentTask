namespace Assignment.Contracts.DTO
{
    public class AppDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Developer { get; set; }
        public string Type { get; set; }
        public DateTime AddedOn { get; set; }
    }
}