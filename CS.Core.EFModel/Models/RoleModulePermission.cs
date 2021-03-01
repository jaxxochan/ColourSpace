namespace CS.Core.EFModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleModulePermission")]
    public partial class RoleModulePermission
    {
        public int RoleModulePermissionId { get; set; }

        public int RoleId { get; set; }

        public int ModuleId { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? ChangedBy { get; set; }

        public DateTime ChangedOn { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }
    }
}
