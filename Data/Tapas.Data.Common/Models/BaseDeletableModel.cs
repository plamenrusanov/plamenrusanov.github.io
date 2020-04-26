namespace Tapas.Data.Common.Models
{
    using System;

    public abstract class BaseDeletableModel<TKey> : BaseModel<TKey>, IDeletableEntity
    {
        public virtual bool IsDeleted { get; set; }

        public virtual DateTime? DeletedOn { get; set; }
    }
}
