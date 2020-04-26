namespace Tapas.Data.Models
{
    using Tapas.Data.Common.Models;

    public abstract class Product : BaseDeletableModel<string>
    {
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
