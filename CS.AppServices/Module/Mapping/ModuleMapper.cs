using CS.Core.DomainModel.Module;
using CS.Core.Module;

namespace CS.Core.AppServices.Module.Mapping
{
    public static class ModuleMapper
    {
        public static ModuleDto ToDto(this UserModule module) => new ModuleDto()
        {
            ModuleId = module.ModuleId,
            Title = module.Title,
            HasAction = module.HasAction,
            Action = module.Action,
            Controller = module.Controller,
            Class = module.Class,
            ParentModuleId = module.ParentModuleId
        };
    }
}
