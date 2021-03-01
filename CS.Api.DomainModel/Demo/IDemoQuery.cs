using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS.Core.DomainModel.Demo
{
    public interface IDemoQuery
    {
        Employee Get(int employeeId);
    }

    public interface IDemoRepository
    {
        Employee Get(int employeeId);
    }
}
