namespace Tapas.Services.Dto.Mistral
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class OrderMDto
    {
        public OrderMDto()
        {
            this.Sales = new List<OrderItemMDto>();
        }

        [DefaultValue(true)]
        public bool Temp { get; set; }

        [Required]
        [DefaultValue(1)]
        public int LocationId { get; set; }

        public string Location { get; set; }

        [Required]
        [DefaultValue(1)]
        public int StoreId { get; set; }

        public string Store { get; set; }

        public string Acct { get; set; }

        public string PartnerNo { get; set; }

        public string Company { get; set; }

        public int Print { get; set; }

        public int Credit { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        public string PrinterName { get; set; }

        [DefaultValue(1)]
        public int PrinterCountCopy { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        [DefaultValue(false)]
        public bool TestMode { get; set; }

        [DefaultValue(false)]
        public bool IsOrder { get; set; }

        public string Info { get; set; }

        public string Note { get; set; }

        public List<OrderItemMDto> Sales { get; set; }
    }
}
