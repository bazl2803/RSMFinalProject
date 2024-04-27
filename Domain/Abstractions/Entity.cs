namespace Domain.Abstractions
{
    public abstract class Entity<TId>
    {
        protected Entity(TId id)
        {
            Id = id;
        }

        protected Entity()
        {
        }

        public TId Id { get; init; }
        public DateTime ModifiedDate { get; private set; }
    }
}