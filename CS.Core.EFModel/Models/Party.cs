namespace CS.Core.EFModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Party")]
    public partial class Party
    {
        public int PartyId { get; set; }

        [StringLength(50)]
        public string PartyName { get; set; }

        public int? AddressId { get; set; }

        [StringLength(15)]
        public string GSTNumber { get; set; }

        [Required]
        [StringLength(10)]
        public string ContactNumber { get; set; }

        [StringLength(10)]
        public string AlternateContactNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string EmailId { get; set; }

        public bool Active { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? ChangedBy { get; set; }

        public DateTime ChangedOn { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
