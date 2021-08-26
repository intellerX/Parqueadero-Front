namespace ADN.Domain.Entities
{
    public interface IEntityBase<DateType>
    {
        DateType Id { get; set; }
    }
}