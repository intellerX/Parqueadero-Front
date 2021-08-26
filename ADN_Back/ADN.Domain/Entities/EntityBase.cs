namespace ADN.Domain.Entities
{
    public class EntityBase<DateType>: DomainEntity, IEntityBase<DateType>
    {
        public virtual DateType Id { get; set; } = default!;
    }

    public class DomainEntity {

    }
}