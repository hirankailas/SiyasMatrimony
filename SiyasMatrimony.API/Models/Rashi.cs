namespace SiyasMatrimony.API.Models
{
    public class Rashi
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StarId { get; set; }
        public Star Star { get; set; }
    }
}