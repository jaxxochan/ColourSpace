namespace CS.Core.EFModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Token")]
    public partial class Token
    {
        public int TokenId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(500)]
        public string AuthToken { get; set; }

        public DateTime IssuedOn { get; set; }

        public DateTime ExpiresOn { get; set; }

        public virtual User User { get; set; }
    }
}
