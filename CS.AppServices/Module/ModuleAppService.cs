using CS.Core.AppServices.Module.Mapping;
using CS.Core.DomainModel.Module;
using CS.Core.Module;
using System.Collections.Generic;
using System.Linq;

namespace CS.Core.AppServices.Module
{
    public class ModuleAppService : IModuleAppService
    {
        private readonly IModuleQuery _moduleQuery;

        public ModuleAppService(IModuleQuery moduleQuery) => _moduleQuery = moduleQuery;

        public List<ModuleDto> Get(int roleId)
        {
            var result = _moduleQuery.Get(roleId);
            return result?.Select(t => t.ToDto()).ToList();
        }
    }
}