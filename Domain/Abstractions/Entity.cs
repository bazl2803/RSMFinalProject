namespace Domain.Abstractions
{
    public abstract class Entity<TId>
    {
        public required TId Id { get; init; }
        public DateTime ModifiedDate { get; private set; } = DateTime.Now;
    }
}