using CS.Api.ResourceModels.Module;
using System;

namespace CS.Api.Facade.Models.Dashboard
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
        public bool IsActive { get; set; }
    }
    public static class UserModuleMapper
    {
        public static UserModule ToView(this ModuleModel resource) => new UserModule
        {
            Action = resource.Action,
            Class = resource.Class,
            Controller = resource.Controller,
            HasAction = resource.HasAction,
            ModuleId = resource.ModuleId,
            ParentModuleId = resource.ParentModuleId,
            Title = resource.Title
        };
    }
}