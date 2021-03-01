namespace CS.Core.EFModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserDetail")]
    public partial class UserDetail
    {
        public int UserDetailId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [StringLength(100)]
        public string MiddleName { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string EmailId { get; set; }

        public string ProfilePicture { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [StringLength(10)]
        public string ContactNumber { get; set; }

        [StringLength(10)]
        public string AlternateContactNumber { get; set; }

        public bool? Gender { get; set; }

        public bool? MaritalStatus { get; set; }

        public int? PermanentAddressId { get; set; }

        public int? CurrentAddressId { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? ChangedBy { get; set; }

        public DateTime ChangedOn { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
