using CS.Api.ResourceModels.Module;
using CS.Api.Services.Module.Mapping;
using CS.Core.Module;
using System.Collections.Generic;
using System.Linq;

namespace CS.Api.Services.Module
{
    public interface IModuleService
    {
        List<ModuleModel> Get(int roleId);
    }

    public class ModuleService : IModuleService
    {
        private readonly IModuleAppService _moduleAppService;

        public ModuleService(IModuleAppService moduleAppService) => _moduleAppService = moduleAppService;

        public List<ModuleModel> Get(int roleId)
        {
            var result = _moduleAppService.Get(roleId);
            return result?.Select(t => t.ToResource()).ToList();
        }
    }
}