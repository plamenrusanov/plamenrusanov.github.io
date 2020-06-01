namespace Tapas.Web.ViewModels.Administration.CateringEquipment
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Text;

    using Microsoft.AspNetCore.Http;

    public class Edit
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Името трябва да е между 3 и 30 символа.")]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(300)]
        public string Description { get; set; }

        [Required]
        [Range(typeof(decimal), "0,01", "999,99")]
        public decimal Price { get; set; }

        public IFormFile Image { get; set; }
    }
}
