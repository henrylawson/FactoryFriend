namespace Domain.Entities
{
    public class Result
    {
        public Competition Competition { get; set; }

        public int Id { get; set; }

        public long MillisecondTime { get; set; }

        public Athlete Athlete { get; set; }

        public Event Event { get; set; }
    }
}
