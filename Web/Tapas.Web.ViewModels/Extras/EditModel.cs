namespace Tapas.Web.ViewModels.Extras
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class EditModel
    {
        [RequiredBg]
        public int Id { get; set; }

        [RequiredBg]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }

        [RequiredBg]
        [Range(typeof(decimal), minimum: "0,01", maximum: "999,99")]
        public decimal Price { get; set; }

        [RequiredBg]
        [Range(minimum: 1, maximum: 1000)]
        public int Weight { get; set; }
    }
}
