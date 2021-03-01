using System.Collections.Generic;

namespace CS.Core.DomainModel.Module
{
    public interface IModuleQuery
    {
        List<UserModule> Get(int roleId);
    }
}
