namespace CS.Core.EFModel.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Module")]
    public partial class Module
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Module()
        {
            Module1 = new HashSet<Module>();
        }

        public int ModuleId { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        public bool HasAction { get; set; }

        [StringLength(200)]
        public string Action { get; set; }

        [StringLength(200)]
        public string Controller { get; set; }

        public string Class { get; set; }

        public int? ParentModuleId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Module> Module1 { get; set; }

        public virtual Module Module2 { get; set; }
    }
}
