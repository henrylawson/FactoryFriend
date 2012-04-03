namespace Domain.Entities
{
    using System.Text;

    public class Event
    {
        public int Id;

        public decimal Distance { get; set; }

        public Discipline Discipline { get; set; }
    }
}
