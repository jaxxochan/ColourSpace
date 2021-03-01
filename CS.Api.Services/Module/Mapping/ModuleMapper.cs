using CS.Api.ResourceModels.Module;
using CS.Core.Module;

namespace CS.Api.Services.Module.Mapping
{
    public static class ModuleMapper
    {
        public static ModuleModel ToResource(this ModuleDto dto) => new ModuleModel
        {
            ModuleId = dto.ModuleId,
            Title = dto.Title,
            HasAction = dto.HasAction,
            Action = dto.Action,
            Controller = dto.Controller,
            Class = dto.Class,
            ParentModuleId = dto.ParentModuleId
        };
    }
}
