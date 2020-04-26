namespace Tapas.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class BaseModel<TKey> : IAuditInfo
    {
        [Key]
        public TKey Id { get; set; }

        public virtual DateTime CreatedOn { get; set; }

        public virtual DateTime? ModifiedOn { get; set; }
    }
}
