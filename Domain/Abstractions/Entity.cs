namespace Domain.Abstractions
{
    public abstract class Entity
    {
        public int Id { get; init; }
        public DateTime ModifiedDate { get; private set; } = DateTime.Now;
    }
}