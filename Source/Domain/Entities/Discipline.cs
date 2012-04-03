namespace Domain.Entities
{
    public class Discipline
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj) || (obj.GetType() != typeof(Discipline)))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            var other = (Discipline)obj;
            return Equals(other.Name, this.Name) && Equals(other.Code, this.Code);
        }

        public override int GetHashCode()
        {
            return (this.Name != null ? this.Name.GetHashCode() : 0);
        }
    }
}
