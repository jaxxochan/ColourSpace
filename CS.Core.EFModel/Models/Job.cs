namespace CS.Core.EFModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Job")]
    public partial class Job
    {
        public int JobId { get; set; }

        public int PartyId { get; set; }

        [Required]
        [StringLength(100)]
        public string BrandName { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int? BagQuantity { get; set; }

        public decimal? BagSizeLength { get; set; }

        public decimal? BagSizeWidth { get; set; }

        public decimal? BagWeight { get; set; }

        public bool? BagType { get; set; }

        public bool? BoppType { get; set; }

        public bool? BoppMetallize { get; set; }

        public decimal? Micron { get; set; }

        public bool? RateType { get; set; }

        public decimal? Rate { get; set; }

        public string BagMaking { get; set; }

        [StringLength(50)]
        public string CuttingSize { get; set; }

        public bool? CuttingType { get; set; }

        public bool? Bottom { get; set; }

        public bool? Gadget { get; set; }

        public bool? Yan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpectedDeliveryDate { get; set; }

        public int PreparedBy { get; set; }

        public string SpecialInstruction { get; set; }

        public bool Active { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? ChangedBy { get; set; }

        public DateTime ChangedOn { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
