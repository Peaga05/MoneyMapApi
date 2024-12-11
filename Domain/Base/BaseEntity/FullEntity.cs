namespace Domain.Base.BaseEntity
{
    public class FullEntity
    {
        public Guid Id { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataDesativacao { get; set; }

        public FullEntity()
        {
            Ativo = true;
            DataCriacao = DateTime.Now;
            Id = Guid.NewGuid();
        }
    }
}
