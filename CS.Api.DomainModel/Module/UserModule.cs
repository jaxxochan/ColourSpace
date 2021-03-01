using System;

namespace CS.Core.DomainModel.Module
{
    public class UserModule
    {
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public bool HasAction { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Class { get; set; }
        public Nullable<int> ParentModuleId { get; set; }
    }
}
