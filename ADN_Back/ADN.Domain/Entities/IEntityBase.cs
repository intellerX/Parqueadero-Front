namespace ADN.Domain.Entities
{
    public interface IEntityBase<T>
    {
        T Id { get; set; }
    }
}