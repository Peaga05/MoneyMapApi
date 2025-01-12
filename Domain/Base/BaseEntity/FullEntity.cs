namespace Domain.Base.BaseEntity
{
    public class FullEntity
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? DeletionTime { get; set; }

        public FullEntity()
        {
            Active = true;
            CreationTime = DateTime.Now;
            Id = Guid.NewGuid();
        }
    }
}
